using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IKomunikacijaTimovi {
    
    void PosaljiZahtjevZaTim(string imeTima, Sport sport, Korisnik primalac, Korisnik kapiten);

    void PosaljiZahtjevZaTim(string imeTima, Sport sport, List<Korisnik> primalac, Korisnik kapiten);
}

