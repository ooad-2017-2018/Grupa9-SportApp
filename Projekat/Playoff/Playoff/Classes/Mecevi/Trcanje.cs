using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Trcanje : Mec {

    // predjena distanca i vrijeme
    Tuple<double, DateTime> rezultat;

    public Trcanje(DateTime vrijemeOdrzavanja, string mjestoOdrzavanja, List<Tim> ucesnici) : base(vrijemeOdrzavanja, mjestoOdrzavanja, ucesnici) {
    }

    public Tuple<double, DateTime> Rezultat { get => rezultat; set => rezultat = value; }

    public override List<Korisnik> DajIgrace() {
        List<Korisnik> nova = new List<Korisnik>();
        foreach (var i in Ucesnici)
            foreach (var j in i.ClanoviTima)
                nova.Add(j);

        return nova;
    }

    public override Tim OdrediPobjednika() {
        return Ucesnici[0];
    }

    public void unesiRezultat(double distanca, DateTime vrijeme) {
        rezultat = new Tuple<double, DateTime>(distanca, vrijeme);
    }
}

