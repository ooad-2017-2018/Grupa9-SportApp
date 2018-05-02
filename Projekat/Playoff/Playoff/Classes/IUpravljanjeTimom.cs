using System.Collections.Generic;

namespace Playoff.Classes {
    public interface IKomunikacijaTimovi {
        void PosaljiZahtjevZaTim(string imeTima, Sport sport, Korisnik primalac, Korisnik kapiten);
        void PosaljiZahtjevZaTim(string imeTima, Sport sport, List<Korisnik> primalac, Korisnik kapiten);
    }
}