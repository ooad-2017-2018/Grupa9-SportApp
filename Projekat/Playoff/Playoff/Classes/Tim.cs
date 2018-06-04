using Playoff.Classes.Mecevi;
using System;
using System.Collections.Generic;

namespace Playoff.Classes {
    public class Tim : Object, IKomunikacijaTimovi{
        static int autoincrement = 0;
        int timID, pobjede, gubitci, nerijeseni,mmr;
        Sport sport;
        Korisnik kapiten;
        string ime;
        List<Korisnik> clanoviTima;
        List<Review> teamRating;
        List<Mec> prosliMecevi, buduciMecevi;

        public Tim(Sport sport, Korisnik kapiten, string ime) {
            TimID = autoincrement++;
            Sport = sport;
            Kapiten = kapiten;
            Ime = ime;
            ClanoviTima = new List<Korisnik>();
            TeamRating = new List<Review>();
            ProsliMecevi = new List<Mec>();
            BuduciMecevi = new List<Mec>();
            Pobjede = 0;
            Gubitci = 0;
            Nerijeseni = 0;
            mmr = 0;
        }

        public Sport Sport { get => sport; set => sport = value; }
        public Korisnik Kapiten { get => kapiten; set => kapiten = value; }
        public string Ime { get => ime; set => ime = value; }
        public List<Korisnik> ClanoviTima { get => clanoviTima; set => clanoviTima = value; }
        public int TimID { get => timID; set => timID = value; }
        public List<Review> TeamRating { get => teamRating; set => teamRating = value; }
        public List<Mec> ProsliMecevi { get => prosliMecevi; set => prosliMecevi = value; }
        public List<Mec> BuduciMecevi { get => buduciMecevi; set => buduciMecevi = value; }
        public int Gubitci { get => gubitci; set => gubitci = value; }
        public int Pobjede { get => pobjede; set => pobjede = value; }
        public int Nerijeseni { get => nerijeseni; set => nerijeseni = value; }
        public int MMR { get => mmr; set => mmr = value; }

        // Kreiranje tima
        public Tim KreirajTim(Korisnik kapiten, Sport sport, string imeTima) {
            Tim novi = new Tim(sport, kapiten, imeTima);
            kapiten.Timovi.Add(novi);
            return novi;
        }

        // Uređivanje tima
        public void PromijeniIme(Korisnik kapiten, int timID, string novoIme) {
            Tim t = kapiten.Timovi.Find(x => (x.TimID == timID) && (kapiten == x.Kapiten));
            if(t == null) throw new KeyNotFoundException("Dati tim nije nađen!"); // + Prijavi gresku da nema takvog tima
            t.Ime = novoIme;
        }

        public void IzbaciClana(Korisnik kapiten, int timID, Korisnik k) {
            Tim t = kapiten.Timovi.Find(x => (x.TimID == timID) && (kapiten == x.Kapiten) && x.ClanoviTima.Exists(y => y.Username == k.Username));
            if(t == null) throw new KeyNotFoundException("Dati tim nije nađen!"); // + Prijavi gresku da nema takvog tima

            t.ClanoviTima.Remove(k);
            k.Timovi.Remove(t);
            k.ProsliTimovi.Add(t, DateTime.Now);
        }

        public void PromijeniKapitena(Korisnik kapiten, int timID, Korisnik k) {
            Tim t = kapiten.Timovi.Find(x => (x.TimID == timID) && (kapiten == x.Kapiten) && x.ClanoviTima.Exists(y => y.Username == k.Username));
            if(t == null) throw new KeyNotFoundException("Dati tim nije nađen!"); // + Prijavi gresku da nema takvog tima
            t.Kapiten = k;
        }

        // Opće fje
        public void PosaljiZahtjevZaTim(string imeTima, Sport sport, Korisnik primalac, Korisnik kapiten) {
            Tim t = kapiten.Timovi.Find(x => (x.Ime == imeTima) && (sport.SportId == x.Sport.SportId) && (kapiten == x.Kapiten));
            if(t == null) return; // + Prijavi gresku da nema takvog tima
            Zahtjev zahtjev = new Zahtjev(kapiten, "Zahtjev za ulazak u tim" + t.Ime + ". Sport: " + t.Sport.ImeSporta, ref t);
            zahtjev.PosaljiPoruku(primalac);
        }

        public void PosaljiZahtjevZaTim(string imeTima, Sport sport, List<Korisnik> primalac, Korisnik kap) {
            foreach(Korisnik i in primalac) {
                PosaljiZahtjevZaTim(imeTima, sport, i, kap);
            }
        }
    }
}