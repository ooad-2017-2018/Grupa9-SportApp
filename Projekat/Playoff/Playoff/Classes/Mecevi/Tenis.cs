using System;
using System.Collections.Generic;

namespace Playoff.Classes.Mecevi {
    public enum BrojSetova { Jedan, Tri, Pet };
    public enum GameOutcome { Nula, Petnaest, Trideset, CetrdesetPet, AD, DAD };

    public class Tenis : Mec {
        List<List<Tuple<GameOutcome, GameOutcome>>> rezultat;

        public Tenis(DateTime vrijemeOdrzavanja, string mjestoOdrzavanja, List<Tim> ucesnici, BrojSetova b) : base(vrijemeOdrzavanja, mjestoOdrzavanja, ucesnici) {
            if(b == BrojSetova.Jedan)
                rezultat = new List<List<Tuple<GameOutcome, GameOutcome>>>(1);

            else if(b == BrojSetova.Tri)
                rezultat = new List<List<Tuple<GameOutcome, GameOutcome>>>(3);

            else if(b == BrojSetova.Pet)
                rezultat = new List<List<Tuple<GameOutcome, GameOutcome>>>(5);

            for(int i = 0; i < rezultat.Capacity; i++)
                rezultat.Add(new List<Tuple<GameOutcome, GameOutcome>>(6));
        }

        public override List<Korisnik> DajIgrace() {
            List<Korisnik> nova = new List<Korisnik>();
            foreach(var i in Ucesnici)
                foreach(var j in i.ClanoviTima)
                    nova.Add(j);

            return nova;
        }

        public override Tim OdrediPobjednika() {
            int s1 = 0, s2 = 0;
            foreach(var set in rezultat) {
                int g1 = 0, g2 = 0;
                foreach(var game in set) {
                    if(game.Item1 == GameOutcome.CetrdesetPet && game.Item2 == GameOutcome.Nula && game.Item2 == GameOutcome.Petnaest && game.Item2 == GameOutcome.Trideset)
                        g1++;
                    else if(game.Item2 == GameOutcome.CetrdesetPet && game.Item1 == GameOutcome.Nula && game.Item1 == GameOutcome.Petnaest && game.Item1 == GameOutcome.Trideset)
                        g2++;
                    else if(game.Item1 == GameOutcome.DAD && game.Item2 == GameOutcome.CetrdesetPet) g1++;
                    else if(game.Item2 == GameOutcome.DAD && game.Item1 == GameOutcome.CetrdesetPet) g2++;
                }
                if(g1 > g2) s1++;
                else s2++;
            }
            if(s1 > s2)
                return Ucesnici[0];
            return Ucesnici[1];
        }

        //Nisam jos skontao kako da unesemo sve ove info...
        public void UnesiGame(int set, int game, GameOutcome rezultatPrvi, GameOutcome rezultatDrugi) {
            rezultat[set][game] = new Tuple<GameOutcome, GameOutcome>(rezultatPrvi, rezultatDrugi);
        }
    }
}