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
        static OOADTimovi odabraniTim;
        static int ID = -1;
        
        // Web API
        static string[] podaci = new string[12]{"OOADKorisnicis","OOADTimovis","OOADProsliTimovis","OOADPorukas",
            "OOADSports","OOADMecs","OOADRezultats","OOADReviews","OOADNaziviPozicijas","OOADClanoviTimas","OOADSampionats","OOADZahtjevs" };

        public static string Logged1 { get => Logged; set => Logged = value; }
        public static int ID1 { get => ID; set => ID = value; }
        public static OOADTimovi OdabraniTim { get => odabraniTim; set => odabraniTim = value; }

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
        public static string DajSport(string tim) {
            string komanda = "Select dbo.DajSport('" + tim + "')";
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
            string komanda = "Exec dbo.DodajReview '" + komentar + "'," + ocjena.ToString() + ",'" + tim + "'";
            return IzvrsiKomandu(komanda, false);
        }
        public static string PosaljiZahtjev(string IDTima,string sadrzaj) {
            string komanda = "Exec dbo.PosaljiZahtjev '" + IDTima + "'," + ID1 + ",'" + sadrzaj + "'";
            return IzvrsiKomandu(komanda, false);
        }
        public static int DajMojID(string user) {
            string komanda = "Select dbo.DajID('" + user + "')";
            return Convert.ToInt32(IzvrsiKomandu(komanda, true));
        }
        public static string DodajUTim(int IDtima, int IDkor) {
            string komanda = "Exec dbo.DodajUTim " + IDtima + "," + IDkor;
            return IzvrsiKomandu(komanda, false);
        }
        public static string IzbacIzTima(int IDTima, int IDkor) {
            string komanda = "Exec dbo.IzbacIzTima " + IDTima + "," + IDkor;
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

        public static string PosaljiPoruku(string primaoc, string poruka) {
            string komanda = "Exec dbo.PosaljiPoruku '" + Logged1 + "','" + primaoc + "','" + "','" + poruka + "'";
            try {
                return IzvrsiKomandu(komanda, false);
            } catch (SqlException e) {
                if (e.Message.Contains("Ne postoji korisnik kojem zelite poslati poruku")) Registration.Poruka("Ne postoji korisnik kojem zelite poslati poruku", "Greska");
                return "";
            }
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
            List<OOADTimovi> vr = new List<OOADTimovi>();
            foreach (var x in my) if (x.KorisnikID == ID1) vr.Add(x);
            return vr;
        }

        static public async Task<List<OOADMec>> DajMeceve(string tim) {
            var c = await DajTimove();
            int ID = -1;
            foreach (var x in c) if (x.Ime.ToLower() == tim) ID = x.ID;
            var mec = JsonConvert.DeserializeObject<List<OOADMec>>(await Povrat(podaci[5]));
            List<OOADMec> vr = new List<OOADMec>();
            foreach (var x in mec) if (x.TIM1 == ID || x.TIM2 == ID) vr.Add(x);
            return vr;
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
            List<OOADRezultat> vr = new List<OOADRezultat>();

            foreach (var x in k) {
                bool brisi = true;
                foreach (var y in mecevi)
                    if (x.MecID == y) brisi = false;
                if (!brisi) vr.Add(x);
            }
            return vr;
        }

        static public async Task<List<OOADPoruka>> DajPoruke() {
            var Vrati = JsonConvert.DeserializeObject<List<OOADPoruka>>(await Povrat(podaci[3]));
            List<OOADPoruka> vr = new List<OOADPoruka>();
            foreach (var x in Vrati) if (x.Primaoc == ID1) vr.Add(x);
            return vr;
        }

        static public async Task<List<OOADPoruka>> DajPorukuOd(string od) {
            var vrati = await DajPoruke();
            var kor = await DajKorisnike();
            int ID = -1;
            foreach (var x in kor) if (x.Username == od) ID = x.ID;
            List<OOADPoruka> vr = new List<OOADPoruka>();
            foreach (var x in vrati) if (x.Posiljaoc == ID) vr.Add(x);
            return vr;
        }

        static public async Task<List<OOADProsliTimovi>> DajProsleTimove() {
            var PT = JsonConvert.DeserializeObject<List<OOADProsliTimovi>>(await Povrat(podaci[2]));
            List<OOADProsliTimovi> vr = new List<OOADProsliTimovi>();
            foreach (var x in PT) if (x.Korisnik == ID1) vr.Add(x);
            return vr;
        }

        static public async Task<List<OOADReview>> DajReview(int id) {
            var rev = JsonConvert.DeserializeObject<List<OOADReview>>(await Povrat(podaci[7]));
            List<OOADReview> vr = new List<OOADReview>();
            foreach (var x in rev) if (x.TIM == id) vr.Add(x);
            return vr;
        }

        static public async Task<List<OOADKorisnici>> DajClanoveTima(int id) {
            var Cl = JsonConvert.DeserializeObject<List<OOADClanoviTima>>(await Povrat(podaci[9]));
            var Kor = await DajKorisnike();
            List<OOADClanoviTima> j = new List<OOADClanoviTima>();
            foreach (var x in Cl) if (x.Tim == id) j.Add(x);

            List<OOADKorisnici> vr = new List<OOADKorisnici>();
            foreach (var x in Kor)
                foreach (var y in j)
                    if (x.ID == y.Korisnik) vr.Add(x);

            return vr;
        }

        static public async Task<List<OOADSampionat>> DajSampionate() {
            return JsonConvert.DeserializeObject<List<OOADSampionat>>(await Povrat(podaci[10]));
        }

        static public async Task<int> DajID() {
            var kor = await DajKorisnike();
            foreach (var x in kor) if (x.Username.ToLower() == Logged1) return x.ID;
            return -1;
        }
        static public async Task<List<OOADZahtjev>> DajPrimljeneZahtjeve() {
            var x = JsonConvert.DeserializeObject<List<OOADZahtjev>>(await Povrat(podaci[11]));
            List<OOADZahtjev> vr = new List<OOADZahtjev>();
            foreach (var y in x) if (y.Primaoc == ID1) vr.Add(y);
            return x;
        }
        static public async Task<List<OOADZahtjev>> DajPoslaneZahtjeve() {
            var x = JsonConvert.DeserializeObject<List<OOADZahtjev>>(await Povrat(podaci[11]));
            List<OOADZahtjev> vr = new List<OOADZahtjev>();
            foreach (var y in x) if (y.Posiljaoc == ID1) vr.Add(y);
            return x;
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
