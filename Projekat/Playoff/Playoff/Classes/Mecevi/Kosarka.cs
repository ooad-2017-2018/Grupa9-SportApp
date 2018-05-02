using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum PozicijeKosarka { Center, Shooting_Guard, Power_Forward, Point_Guard, Small_Forward };

public class KosarkaskiMec : Mec {
    // User id, koji tim
    List<KeyValuePair<int, int>> bodoviTimJedan, bodoviTimDva;
    List<Tuple<Korisnik, PozicijeKosarka>> t1, t2;


    public KosarkaskiMec(DateTime vrijemeOdrzavanja, string mjestoOdrzavanja, List<Tim> ucesnici, List<Tuple<Korisnik, PozicijeKosarka>> t1, List<Tuple<Korisnik, PozicijeKosarka>> t2) : base(vrijemeOdrzavanja, mjestoOdrzavanja, ucesnici) {
        this.t1 = t1;
        this.t2 = t2;
        bodoviTimJedan = bodoviTimDva = new List<KeyValuePair<int, int>>();
    }

    public void UnesiKoseve(Korisnik k, int brojDvica, int brojTrica) {
        foreach (Tuple<Korisnik, PozicijeKosarka> i in t1) {
            if (i.Item1.UserID == k.UserID)
                bodoviTimJedan.Add(new KeyValuePair<int, int>(k.UserID, 2 * brojDvica + 3 * brojTrica));
        }

        foreach (Tuple<Korisnik, PozicijeKosarka> i in t2) {
            if (i.Item1.UserID == k.UserID)
                bodoviTimDva.Add(new KeyValuePair<int, int>(k.UserID, 2 * brojDvica + 3 * brojTrica));
        }
    }

    public override Tim OdrediPobjednika() {
        int b1 = 0, b2 = 0;

        foreach (var item in bodoviTimJedan) 
            b1 += item.Value;
        foreach (var item in bodoviTimDva)
            b2 += item.Value;

        if (b1 > b2)
            return Ucesnici[0];
        else if (b1 == b2) return null;
        return Ucesnici[1];
    }

    public override List<Korisnik> DajIgrace() {
        List<Korisnik> nova = new List<Korisnik>();
        foreach (var i in t1)
            nova.Add(i.Item1);
        foreach (var i in t2)
            nova.Add(i.Item1);
        return nova; 
    }
}