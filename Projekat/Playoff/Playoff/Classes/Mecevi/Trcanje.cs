using System;
using System.Collections.Generic;

namespace Playoff.Classes.Mecevi {
    public class Trcanje : Mec {

        // predjena distanca i vrijeme
        Tuple<double, DateTime> rezultat;

        public Trcanje(DateTime vrijemeOdrzavanja, string mjestoOdrzavanja, List<Tim> ucesnici) : base(vrijemeOdrzavanja, mjestoOdrzavanja, ucesnici) { }

        public Tuple<double, DateTime> Rezultat { get => rezultat; set => rezultat = value; }

        public override List<Korisnik> DajIgrace() {
            List<Korisnik> nova = new List<Korisnik>();
            foreach(var i in Ucesnici)
                foreach(var j in i.ClanoviTima)
                    nova.Add(j);

            return nova;
        }

        public override Tim OdrediPobjednika() {
            return Ucesnici[0];
        }

        public void UnesiRezultat(double distanca, DateTime vrijeme) {
            rezultat = new Tuple<double, DateTime>(distanca, vrijeme);
        }
    }
}