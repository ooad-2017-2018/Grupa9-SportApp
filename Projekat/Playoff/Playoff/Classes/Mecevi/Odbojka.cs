using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum BrojSetovaOdbojka { Tri, Pet };


class Odbojka : Mec {
    List<List<Tuple<int, int>>> rezultat;

    public Odbojka(DateTime vrijemeOdrzavanja, string mjestoOdrzavanja, List<Tim> ucesnici, BrojSetovaOdbojka b) : base(vrijemeOdrzavanja, mjestoOdrzavanja, ucesnici) {

        if (b == BrojSetovaOdbojka.Tri)
            rezultat = new List<List<Tuple<int, int>>>(3);

        else if (b == BrojSetovaOdbojka.Pet)
            rezultat = new List<List<Tuple<int, int>>>(5);

        for (int i = 0; i < rezultat.Capacity; i++)
            rezultat.Add(new List<Tuple<int, int>>(6));
    }

    public override List<Korisnik> DajIgrace() {
        List<Korisnik> nova = new List<Korisnik>();
        foreach (var i in Ucesnici)
            foreach (var j in i.ClanoviTima)
                nova.Add(j);

        return nova;
    }

    public override Tim OdrediPobjednika() {
        int s1 = 0, s2 = 0;
        foreach (var set in rezultat) {
            int g1 = 0, g2 = 0;
            foreach (var game in set) {
                if (game.Item1 > game.Item2) g1++;
                else g2++;
            }
            if (g1 > g2) s1++;
            else s2++;
        }
        if (s1 > s2)
            return Ucesnici[0];
        return Ucesnici[1];
    }

    //Nisam jos skontao kako da unesemo sve ove info...
    public void UnesiGame(int set, int game, int rezultatPrvi, int rezultatDrugi) {
        rezultat[set][game] = new Tuple<int, int>(rezultatPrvi, rezultatDrugi);
    }

}