Playoff
=======

## Članovi Tima
* [Muminović Amir](https://github.com/amirmuminovic)
* [Mujić Sulejman](https://github.com/spetsnazr)
* [Salman Haris](https://github.com/InfernalWraith)

## Opis Teme
Playoff je aplikacija namijenjena sportistima i rekreativcima. 
Prilikom organizovanja prijateljskih susreta postoji mnogo problema koje nemaju sistematično rješenje. 
Često timovi igraju protiv istih timova i ne mogu naći nove adekvatne protivnike. 
Nekim timovima fali igrača dok također postoje igrači koji ne mogu naći tim. 
Ovom aplikacijom omogućavamo korisniku da nađe/formira tim i suigrače na njegovom nivou vještine, 
organizuje utakmice sa adekvatnim protivnicima te da ima pregled nad ostvarenim rezultatima u prošlim mečevima. 

Algoritam koji će pronalaziti protivnike koristit će kombinaciju informacija unesenih od strane korisnika te ostvarenih 
rezultata u prijašnjim mečevima da formira relativno preciznu sliku o sportskim sposobnostima svakog korisnika i 
upari ga sa drugim igračima istog nivoa, eliminirajući standardnu zamisao najboljih i najslabijih igrača. 

Svaki korisnik će imati profil gdje će biti prikazane najvažnije informacije i ostvareni rezultati. 
Playoff će prvobitno podržavati pet sportova – fudbal, košarka, odbojka, tenis i trčanje. 
Korištenjem principa objektno orijentisanog programiranja će se omogućiti buduća implementacija novih sportova.

## Procesi
Korisnik odabere _Sign-up_ u meniju. Otvori se forma za podatke koje korisnik popunjava. 
Ako su uneseni nevažeći podaci, prijavljuje se greška. Inače, kreira se korisnički račun. 
U svrhu prebacivanja odgovornosti na korisnika u slučaju izvjesne zloupotrebe aplikacije, korisnik mora imati 
preko 18 godina i mora prihvatiti EULA.

Korisnik (kapiten tima) bira opciju _Kreiraj Tim_ u meniju nakon uspješnog prijavljivanja. 
Tu se bira sport, uz odgovarajući raspored po pozicijama u timu. Korisnik odabere poziciju i može da bira između 
biranja suigrača koji mu se nalaze u listi prijatelja i pretrage igrača po određenim parametrima (lokacija, dostupnost...). 
Prikazanim korisnicima može poslati zahtjev za igranje u timu. Ti korisnici moraju da potvrde taj zahtjev. 

Kapiten tima će imati opciju _Uredi Tim_, pomoću koje će moći da zove nove igrače u tim 
ili da izbaci trenutne.

Korisnik bez tima može da koristi opciju _Pronađi Ekipu_, pri čemu se vrši pretraga po igračima ili timovima za željeni sport. 
Korisniku će biti izlistani svi timovi ili korisnici koji imaju slobodna mjesta a nalaze se u njegovom geografskom području. 
Korisnik može poslati kapitenu tima zahtjev za ulazak u tim.

Kapiten tima ima opciju _Organizuj Meč_. 
Prvenstveno bira za koji tim želi da organizuje meč, jer kapiten može imati više timova. 
U tom dijelu, specijalno konstruisani algoritam pronalazi timove iz istog geografskog područja. 
Kapiten tima može odabrati tim, unijeti predloženo vrijeme igranja meča te lokaciju igranja 
**(možda na mapi, eventualno proširenje da korisnici mogu javno označiti igrališta)**. 
Nakon toga šalje zahtjev za meč. Kapiten drugog tima dobija zahtjev. 
Ima mogućnost da prihvati zahtjev ili da promijeni vrijeme i mjesto. 
Ako prihvati zahtjev, šalje se dodatni zahtjev svakom članu oba tima. 
Ako dovoljno igrača potvrdi da dolazi na termin u roku od 24 sata, termin će se održati. 
Inače termin se otkazuje. Ako promijeni vrijeme i mjesto, šalje se zahtjev kapitenu drugog tima i tako sve dok se ne usaglase. 

Nakon odigranog meča, oba tima mogu da protivnički tim označe kao prijateljski i fer, ili kao tim sa kojim je neugodno igrati. 
Na ovaj način sami korisnici prave ocjene drugih timova, tako da se timovi koji prave probleme mogu lagano uočiti 
i izbjeći pri pretrazi u vidu opcije filterovanja timova sa niskom ocjenom. 
Ovaj sistem će također pomoći pri evaluaciji ako je unesen ispravan rezultat i pri adekvatnoj dodjeli bodova za ranking.

Svaki korisnik ima opciju _Centar za Notifikacije_. 
U ovom dijelu će biti prikazane notifikacije. 
Notifikacije su podijeljene na viđene i neviđene, te mogu biti pasivne (samo prikazuju poruku) 
ili aktivne (zahtjevaju interakciju korisnika).

Svaki korisnik ima mogućnost da otkaže dolazak na dogovoreni meč. 
Prvenstveno bira opciju _Pregled Mečeva_ gdje može da otkaže dolazak na izabranu utakmicu. 
Ako tim još uvijek ima dovoljno igrača da se održi meč, ništa se ne desi. 
Ako fali igrača – šalje se notifikacija kapitenu tima. Ako nema dovoljno igrača za održavanje utakmice 8 sati prije 
dogovorenog termina, termin se otkazuje.

Svaki korisnik ima pristup opciji _Hitna potražnja_. 
Kapiteni timova mogu tu postaviti oglas ako im hitno treba igrač za neku poziciju. 
Drugi korisnici mogu poslati zahtjev kapitenu te on može da odluči koga će prihvatiti.

## Funkcionalnost
* Mogućnost kreiranja korisničkog računa
* Mogućnost prijave u sistem sa različitim privilegijama
* Mogućnost praćenja prošlih i budućih mečeva
* Mogućnost kreiranja timova
* Mogućnost pronalaska suigrača i/ili protivničkog tima po raznim kriterijima
* Mogućnost ocjenjivanja susreta
* Mogućnost praćenja rezultata igrača

## Akteri
* Kapiten tima – korisnik koji ima kreirani tim
* Član tima – članovi tima koji nisu kapiteni
* Privremeni član tima – član koji nije prihvaćen u tim ali igra sa timom
