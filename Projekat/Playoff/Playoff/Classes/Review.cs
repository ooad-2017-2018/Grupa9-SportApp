using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Review {
    string komentar;
    int ocjena;
    Tim tim;

    public Review(string komentar, int ocjena, Tim tim) {
        Komentar = komentar;
        Ocjena = ocjena;
        Tim = tim;
    }

    public string Komentar { get => komentar; set => komentar = value; }
    public int Ocjena { get => ocjena; set => ocjena = value; }
    public Tim Tim { get => tim; set => tim = value; }

    public void PosaljiReview(Tim primalac) {
        // Pri finalizaciji meca (unosu rezultata), oba kapitena pisu reviews za protivnicki tim
        // Dodatna opcija da reviews postanu javni tek sat vremena nakon unosa (da se ne onemoguce negativni)
        // Dodatni zahtjev da se review moze poslati jedino timu protiv kojeg su prije igrali (timu u prosliMecevi)
        // Maksimalno jedan review za jedan tim
        // Pri prikazu review-a provjeriti ako je komentar prazan ili whitespace, i onda komentar ne prikazivati
        primalac.TeamRating.Add(this);
    }
}