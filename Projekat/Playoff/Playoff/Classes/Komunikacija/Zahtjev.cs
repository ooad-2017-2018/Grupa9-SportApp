using Playoff.Classes.Mecevi;
using System.Collections.Generic;
using System;
namespace Playoff.Classes.Mecevi {
    public class Zahtjev : Poruka {
        Tim tim;
        public Zahtjev(Korisnik posiljalac, string sadrzaj, ref Tim tim) : base(posiljalac, sadrzaj) {
            Tim = tim;
        }

        public Tim Tim { get => tim; set => tim = value; }


        public void PosaljiZahtjevZaTim(string imeTima, Sport sport, Korisnik primalac, Korisnik posiljalac) {
            Tim t = posiljalac.Timovi.Find(x => (x.Ime == imeTima) && (sport.SportId == x.Sport.SportId) && (posiljalac.UserID == x.Kapiten.UserID));
            if(t == null) return; // + Prijavi gresku da nema takvog tima
            Zahtjev zahtjev = new Zahtjev(posiljalac, "Zahtjev za ulazak u tim" + t.Ime + ". Sport: " + t.Sport.ImeSporta, ref t);
            zahtjev.PosaljiPoruku(primalac);
        }
        public void PosaljiZahtjevZaTim(string imeTima, Sport sport, List<Korisnik> primalac, Korisnik posiljalac) {
            foreach(var item in primalac) {
                PosaljiZahtjevZaTim(imeTima, sport, item, posiljalac);
            }
        }
        public void ObradiZahtjev(Zahtjev z, bool odluka, Korisnik k) {
            z.OdgovoriNaZahtjev(k, odluka);
        }
        public void OdgovoriNaZahtjev(Korisnik primalac, bool odluka) {
            if(odluka) {
                primalac.Timovi.Add(tim);
                tim.ClanoviTima.Add(primalac);

                Poruka p = new Poruka(Posiljalac, "Uspjesno ste dodani u tim " + tim.Ime);
                p.PosaljiPoruku(primalac);

                p = new Poruka(primalac, primalac.Ime + " " + primalac.Prezime + " je dodan u tim " + tim.Ime);
                p.PosaljiPoruku(Posiljalac);
            } else {
                Poruka p = new Poruka(primalac, primalac.Ime + " " + primalac.Prezime + " ne želi da se pridruži timu " + tim.Ime);
                p.PosaljiPoruku(Posiljalac);
            }
        }
    }
}