using System;
using System.Collections.Generic;

public abstract class Mec {
    static int autoincrement=0;
    int mecId;
    DateTime vrijemeOdrzavanja;
    string mjestoOdrzavanja;
    List<Tim> ucesnici;
    bool registrovan;

    Tuple<int, int> rezultat1, rezultat2;

    public Mec(DateTime vrijemeOdrzavanja, string mjestoOdrzavanja, List<Tim> ucesnici) {
        mecId = autoincrement++;
        VrijemeOdrzavanja = vrijemeOdrzavanja;
        MjestoOdrzavanja = mjestoOdrzavanja;
        Ucesnici = ucesnici;
        Registrovan = false;
    }


    public DateTime VrijemeOdrzavanja { get => vrijemeOdrzavanja; set => vrijemeOdrzavanja = value; }
    public string MjestoOdrzavanja { get => mjestoOdrzavanja; set => mjestoOdrzavanja = value; }
    public List<Tim> Ucesnici { get => ucesnici; set => ucesnici = value; }
    public bool Registrovan { get => registrovan; set => registrovan = value; }
    public abstract List<Korisnik> DajIgrace();

    public abstract Tim OdrediPobjednika();
    public void ObracunajBodove(int bod1, int bod2) {
        if (OdrediPobjednika().TimID == Ucesnici[0].TimID) {
            Ucesnici[0].Pobjede++;
            Ucesnici[1].Gubitci++;
        }
        else if (OdrediPobjednika().TimID == Ucesnici[1].TimID) {
            Ucesnici[0].Gubitci++;
            Ucesnici[1].Pobjede++;
        }
        else {
            Ucesnici[0].Nerijeseni++;
            Ucesnici[1].Nerijeseni++;
        }
    }

    // Metoda se poziva na kraju meca, nakon sto se oba tima dogovore oko rezultata
        // Eventualno koristiti samo jednu varijablu za rezultat koja se provjeri prije poziva metode, obrisati atribute rezultat
        // Da se provjera saglasnosti vrsi jednom svakih sat vremena (ili češće) dok se meč ne finalizuje
        public string FinalizirajMec(Tuple<int, int> rez1, Tuple<int, int> rez2, Review r1, Review r2) {
            if(rez1 == rez2) {
                // Ažuriranje pobjeda/gubitaka
                ObracunajBodove(rez1.Item1, rez1.Item2);

                // Slanje review-a za oba tima
                r1.PosaljiReview(Ucesnici[1]);
                r2.PosaljiReview(Ucesnici[0]);

            // Ažuriranje spiska prošlih i budućih mečeva
            foreach (var i in Ucesnici) {
                i.BuduciMecevi.Remove(this);
                i.ProsliMecevi.Add(this);
            }
                Registrovan = true;
                return "Meč finaliziran.";
            } else return "Timovi se ne slažu oko rezultata.";
        }
}

