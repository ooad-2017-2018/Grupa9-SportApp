using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

public class Korisnik {
    static int autoIncrement = 1;
    static MD5 md5Hash = MD5.Create();

    int userID;
    string ime, prezime, username, password, drzava, grad;
    bool dostupnost;
    DateTime datumRodjenja;
    List<Tim> timovi;
    List<Poruka> poruke;
    Dictionary<Tim, DateTime> prosliTimovi;
    List<Mec> prosliMecevi, buduciMecevi;


    public Korisnik(string ime, string prezime, string username, string password, string drzava, string grad, DateTime datumRodjenja) {
        userID = autoIncrement++;
        Ime = ime;
        Prezime = prezime;
        Username = username;
        Password = KodirajMD5(md5Hash, password);
        Drzava = drzava;
        Grad = grad;
        Dostupnost = false;
        DatumRodjenja = datumRodjenja;
        Timovi = new List<Tim>();
        ProsliTimovi = new Dictionary<Tim, DateTime>();
        Poruke = new List<Poruka>();
        ProsliMecevi = new List<Mec>();
        BuduciMecevi = new List<Mec>();
    }

    //Properties
    public string Ime { get => ime; set => ime = value; }
    public string Prezime { get => prezime; set => prezime = value; }
    public string Username { get => username; set => username = value; }
    public string Password { get => password; set => password = value; }
    public string Drzava { get => drzava; set => drzava = value; }
    public string Grad { get => grad; set => grad = value; }
    public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
    public List<Tim> Timovi { get => timovi; set => timovi = value; }
    public List<Poruka> Poruke { get => poruke; set => poruke = value; }
    public bool Dostupnost { get => dostupnost; set => dostupnost = value; }
    public Dictionary<Tim, DateTime> ProsliTimovi { get => prosliTimovi; set => prosliTimovi = value; }
    public int UserID { get => UserID; set => UserID = value; }
    public List<Mec> ProsliMecevi { get => prosliMecevi; set => prosliMecevi = value; }
    public List<Mec> BuduciMecevi { get => buduciMecevi; set => buduciMecevi = value; }

    public string OtkaziMec(Korisnik kapiten, Mec mec) {
        Mec m = BuduciMecevi.Find(x => (x == mec));
        if (m == null) return "Dati meč nije pronađen!";
        if (m.DajIgrace().Contains(kapiten)) {
            m.DajIgrace().Remove(kapiten);
            BuduciMecevi.Remove(mec);
            return "Uspješno ste odjavljeni sa datog meča.";
        }
        else return "Već niste dio datog meča!";
    }

    // MD5 Heširanje
    static string KodirajMD5(MD5 md5Hash, string pw) {
        // Konverzija unesenog passworda u niz bita koji se kodiraju
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(pw));
        // Vracanje bita nazad u string
        StringBuilder sBuilder = new StringBuilder();
        // Formatiranje svakog bita kao heksadecimalni string
        for (int i = 0; i < data.Length; i++) sBuilder.Append(data[i].ToString("x2"));

        return sBuilder.ToString();
    }

    // Poređenje običnog stringa i MD5 kodiranog stringa
    static bool ProvjeriMD5(MD5 md5Hash, string unos, string kodirani) {
        // Heširanje unosa
        string kodiraniUnos = KodirajMD5(md5Hash, unos);

        // Poređenje heševa
        StringComparer comparer = StringComparer.OrdinalIgnoreCase;
        if (comparer.Compare(kodiraniUnos, kodirani) == 0) return true;
        else return false;
    }
}