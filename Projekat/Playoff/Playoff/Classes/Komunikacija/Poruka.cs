using System.Collections.Generic;

namespace Playoff.Classes.Mecevi {
    public class Poruka {
        Korisnik posiljalac;
        string sadrzaj;
        bool vidjenostPoruke;

        public Poruka(Korisnik posiljalac, string sadrzaj) {
            this.posiljalac = posiljalac;
            this.sadrzaj = sadrzaj;
            this.vidjenostPoruke = false;
        }

        public string Sadrzaj { get => sadrzaj; set => sadrzaj = value; }
        public bool VidjenostPoruke { get => vidjenostPoruke; set => vidjenostPoruke = value; }
        public Korisnik Posiljalac { get => posiljalac; set => posiljalac = value; }

        public void ProcitajPoruku() {
            if(vidjenostPoruke == false) vidjenostPoruke = true;
            ToString();
        }

        public void PosaljiPoruku(Korisnik primalac) {
            primalac.Poruke.Add(this);
        }
        public void PosaljiPoruku(List<Korisnik> primaoci) {
            foreach(Korisnik k in primaoci) k.Poruke.Add(this);
        }

        public override string ToString() {
            if(vidjenostPoruke) return "Poruka: Procitana \n Posiljalac: " + posiljalac.Username + "\n" + sadrzaj;
            return "Poruka: Nova \n Posiljalac: " + posiljalac.Username + "\n" + sadrzaj;
        }
    }
}