using System;
using System.Collections.Generic;

namespace Playoff.Classes.Mecevi {
    public enum PozicijeNogomet { Golman, Odbrana, Veza, Napad };
    public class NogometniMec : Mec {
        // User id, kad, koji tim

        List<KeyValuePair<int, int>> bodoviTimJedan, bodoviTimDva;
        List<Tuple<Korisnik, PozicijeNogomet>> t1, t2;


        public NogometniMec(DateTime vrijemeOdrzavanja, string mjestoOdrzavanja, List<Tim> ucesnici, List<Tuple<Korisnik, PozicijeNogomet>> t1, List<Tuple<Korisnik, PozicijeNogomet>> t2) : base(vrijemeOdrzavanja, mjestoOdrzavanja, ucesnici) {
            bool ok = false;
            foreach(var i in t1) {
                if(i.Item2 == PozicijeNogomet.Golman)
                    ok = true;
            }
            if(!ok) throw new Exception("Tim 1 nema golmana");

            ok = false;
            foreach(var i in t1) {
                if(i.Item2 == PozicijeNogomet.Golman)
                    ok = true;
            }
            if(!ok) throw new Exception("Tim 2 nema golmana");

            this.t1 = t1;
            this.t2 = t2;
            bodoviTimJedan = bodoviTimDva = new List<KeyValuePair<int, int>>();
        }

        public void UnesiGol(Korisnik k, int brojGolova) {
            foreach(Tuple<Korisnik, PozicijeNogomet> i in t1) {
                if(i.Item1.UserID == k.UserID)
                    bodoviTimJedan.Add(new KeyValuePair<int, int>(k.UserID, brojGolova));
            }

            foreach(Tuple<Korisnik, PozicijeNogomet> i in t2) {
                if(i.Item1.UserID == k.UserID)
                    bodoviTimDva.Add(new KeyValuePair<int, int>(k.UserID, brojGolova));
            }
        }

        public override Tim OdrediPobjednika() {
            int b1 = 0, b2 = 0;

            foreach(var item in bodoviTimJedan)
                b1 += item.Value;
            foreach(var item in bodoviTimDva)
                b2 += item.Value;

            if(b1 > b2)
                return Ucesnici[0];
            else if(b1 == b2) return null;
            return Ucesnici[1];
        }

        public override List<Korisnik> DajIgrace() {
            List<Korisnik> nova = new List<Korisnik>();
            foreach(var i in t1)
                nova.Add(i.Item1);
            foreach(var i in t2)
                nova.Add(i.Item1);
            return nova;
        }
    }
}