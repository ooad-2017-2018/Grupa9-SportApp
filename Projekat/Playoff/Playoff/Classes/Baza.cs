using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace Playoff.Classes {
    public static class Baza {
        // Login varijabla
        static SqlConnectionStringBuilder cb = new SqlConnectionStringBuilder();
        // Pamti trenutno logovanog korisnika
        static string Logged;
        static int ID = -1;
        // Web API
        static string[] podaci = new string[11]{"OOADKorisnicis","OOADTimovis","OOADProsliTimovis","OOADPorukas",
            "OOADSports","OOADMecs","OOADRezultats","OOADReviews","OOADNaziviPozicijas","OOADClanoviTimas","OOADSampionats" };

        public static string Logged1 { get => Logged; set => Logged = value; }
        public static int ID1 { get => ID; set => ID = value; }

        // Login na bazu podataka (pri pokretanju applikacije, ovaj user ima ograničene permisije)
        public static void LogNaBazu() {
            cb.DataSource = "playoff.database.windows.net";
            cb.UserID = "APP";
            cb.Password = "Playoff1";
            cb.InitialCatalog = "PlayOff";
        }

        // Registracija korisnika na bazu podataka
        public static string RegistrujKorisnika(string user, string password, string ime, string prezime, DateTime rodjen, string drzava, string grad, int dostupnost) {
            string komanda = "Exec dbo.Registruj " + "'" + user + "','" + password + "','" + ime + "','" + prezime + "'," + "'" + rodjen.Year.ToString() + "-" + rodjen.Month.ToString() + "-" + rodjen.Day.ToString() + "','" + drzava + "','" + grad + "'," + dostupnost;
            return IzvrsiKomandu(komanda, false);
        }

        // Vraća password korisnika sa unesenim username
        public static string DajPassword(string username) {
            string komanda = "Select dbo.uzmi_password('" + username + "')";
            return IzvrsiKomandu(komanda, true);
        }

        public static string KreirajTim(string ImeTima, string sport) {
            string komanda = "Exec dbo.KreirajTim " + "'" + ImeTima + "','" + Logged1 + "','" + sport + "'";
            return IzvrsiKomandu(komanda, false);
        }

        public static string ZakaziMec(string Tim1, string Tim2, DateTime vrodrzavanja, string mjesto) {
            string komanda = "Exec dbo.DodajMec " + "'" + vrodrzavanja.Year.ToString() + "-" + vrodrzavanja.Month.ToString() + "-" + vrodrzavanja.Day.ToString() + "','" + mjesto + "','" + Tim1 + "','" + Tim2 + "'";
            return IzvrsiKomandu(komanda, false);
        }

        public static string DodajReview(string komentar, int ocjena, string tim) {
            string komanda = "Exec dbo.DodajReview " + "','" + komentar + "'," + ocjena.ToString() + ",'" + tim + "'";
            return IzvrsiKomandu(komanda, false);
        }

        public static async Task<string> UpisiRezultat(string tim1, string tim2, int timrez, int tim2rez) {
            var tim = await DajTimove();
            var rez = await DajRezultate(tim1, tim2);
            var mecevi = await DajMeceve(tim1);
            foreach (var x in mecevi)
                foreach (var y in rez)
                    if (x.ID == y.MecID) mecevi.Remove(x);

            if (mecevi.Count == 0) throw new Exception("Ne postoji mec za koji nisu upisani rezultati sa navedena dva tima");


            string komanda = "Exec dbo.DodajRezultat " + mecevi[0].ID + "," + mecevi[0].TIM1 + "," + mecevi[0].TIM2;
            return IzvrsiKomandu(komanda, false);
        }

        // Izvršavanje potrebne komande
        static string IzvrsiKomandu(string komanda, bool param) {
            using (var connection = new SqlConnection(cb.ConnectionString)) {
                try {
                    connection.Open();
                    return Submit_Tsql_NonQuery(connection, komanda, param);
                } catch (SqlException ex) {
                    if (ex.Message.Contains("network")) Registration.Poruka("Nije moguce uspostaviti konekciju", "Greska");
                }
                return "N";
            }
        }

        // Pomocna funkcija za slanje podataka bazi - param = true izvršava funkciju, a inače proceduru
        static string Submit_Tsql_NonQuery(SqlConnection connection, string tsqlSourceCode, bool param) {
            using (var command = new SqlCommand(tsqlSourceCode, connection)) {
                if (param) return command.ExecuteScalar().ToString();
                int rowsAffected = command.ExecuteNonQuery();
                return "";
            }

        }

        static public async Task<List<OOADKorisnici>> DajKorisnike() {
            return JsonConvert.DeserializeObject<List<OOADKorisnici>>(await Povrat(podaci[0]));
        }

        static public async Task<List<OOADTimovi>> DajTimove() {
            return JsonConvert.DeserializeObject<List<OOADTimovi>>(await Povrat(podaci[1]));
        }
        static public async Task<List<OOADTimovi>> DajMojeTimove() {
            var my = await DajTimove();
            foreach (var x in my) if (x.KorisnikID != ID1) my.Remove(x);
            return my;
        }

        static public async Task<List<OOADMec>> DajMeceve(string tim) {
            var c = await DajTimove();
            int ID = -1;
            foreach (var x in c) if (x.Ime.ToLower() == tim) ID = x.ID;
            var mec = JsonConvert.DeserializeObject<List<OOADMec>>(await Povrat(podaci[5]));
            foreach (var x in mec) if (x.TIM1 != ID && x.TIM2 != ID) mec.Remove(x);
            return mec;
        }

        static public async Task<List<OOADRezultat>> DajRezultate(string tim1, string tim2) {
            var c = await DajTimove();
            int ID1, ID2;
            List<int> mecevi = new List<int>();
            ID1 = ID2 = -1;
            foreach (var x in c) {
                if (x.Ime.ToLower() == tim2) {
                    ID2 = x.ID;
                    break;
                }
            }
            var mec = await DajMeceve(tim1);
            foreach (var x in mec) {
                if (x.TIM2 == ID2 || x.TIM1 == ID2) mecevi.Add(x.ID);
            }
            var k = JsonConvert.DeserializeObject<List<OOADRezultat>>(await Povrat(podaci[6]));
            foreach (var x in k) {
                bool brisi = true;
                foreach (var y in mecevi)
                    if (x.MecID == y) brisi = false;
                if (brisi) k.Remove(x);
            }
            return k;
        }

        static public async Task<List<OOADPoruka>> DajPoruke() {
            var Vrati = JsonConvert.DeserializeObject<List<OOADPoruka>>(await Povrat(podaci[3]));
            foreach (var x in Vrati) if (x.Primaoc != ID1) Vrati.Remove(x);
            return Vrati;
        }

        static public async Task<List<OOADPoruka>> DajPorukuOd(string od) {
            var vrati = await DajPoruke();
            var kor = await DajKorisnike();
            int ID = -1;
            foreach (var x in kor) if (x.Username == od) ID = x.ID;
            foreach (var x in vrati) if (x.Posiljaoc != ID) vrati.Remove(x);
            return vrati;
        }

        static public async Task<List<OOADProsliTimovi>> DajProsleTimove() {
            var PT = JsonConvert.DeserializeObject<List<OOADProsliTimovi>>(await Povrat(podaci[2]));
            foreach (var x in PT) if (x.Korisnik != ID1) PT.Remove(x);
            return PT;
        }

        static public async Task<List<OOADReview>> DajReview(int id) {
            var rev = JsonConvert.DeserializeObject<List<OOADReview>>(await Povrat(podaci[7]));
            foreach (var x in rev) if (x.TIM != id) rev.Remove(x);
            return rev;
        }

        static public async Task<List<OOADKorisnici>> DajClanoveTima(int id) {
            var Cl = JsonConvert.DeserializeObject<List<OOADClanoviTima>>(await Povrat(podaci[8]));
            var Kor = await DajKorisnike();
            foreach (var x in Cl) if (x.Tim != id) Cl.Remove(x);

            foreach (var x in Kor)
                foreach (var y in Cl)
                    if (x.ID != y.Korisnik) Kor.Remove(x);

            return Kor;
        }

        static public async Task<List<OOADSampionat>> DajSampionate() {
            return JsonConvert.DeserializeObject<List<OOADSampionat>>(await Povrat(podaci[9]));
        }

        static public async Task<int> DajID() {
            var kor = await DajKorisnike();
            foreach (var x in kor) if (x.Username.ToLower() == Logged1) return x.ID;
            return -1;
        }

        static async Task<string> Povrat(string link, string opc = "") {
            using (var client = new HttpClient(new HttpClientHandler { UseProxy = false })) {
                string apiUrl = "http://playoffweb.azurewebsites.net/" + link;
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/JSON"));
                var Res = await client.GetAsync("api/" + link + "1/" + opc);
                var rez = Res.Content.ReadAsStringAsync().Result;
                return rez;

            }
        }
    }
}