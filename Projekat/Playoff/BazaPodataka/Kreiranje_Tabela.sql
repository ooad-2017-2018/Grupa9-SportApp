Create table OOADKorisnici( 
                         ID int,
                         Username varchar(50)  unique not null,
                         Password varchar(255) not null,
                         Ime varchar(255) not null,
                         Prezime varchar(255) not null ,
                         Rodjen date not null,
                         drzava varchar(50)not null,
                         grad varchar(50)not null,
                         dostupnost int not null,
Constraint pk_OOADKor_ID primary key (ID));

CREATE TABLE OOADProsliTimovi(
                              Korisnik int not null,
                              Naziv varchar(50) not null,
                              datumprestanka date not null,
constraint fk_proslitimovi foreign key (Korisnik) references OOADKorisnici(ID));


CREATE TABLE OOADSport(
                       ID int,
                       Naziv varchar(25) not null,
                       MaxBrojIgraca int not null,
                       MinBrojIgraca int not null,
CONSTRAINT pk_OOADsport_ID primary key(ID));

CREATE TABLE OOADTimovi(
                        ID int,
                        Ime varchar(50) not null unique,
                        KorisnikID int not null,
                        SportID int not null,
constraint pk_Timovi_ID primary key(ID),
constraint fk_Timovi_KorisnikID foreign key(KorisnikID) references OOADKorisnici(ID),
constraint fk_Timovi_SportID foreign key (SportID) references OOADSport(ID));

CREATE TABLE OOADZahtjev(
                        Sadrzaj varchar(200),
                        Vidjenost int,
                        Primaoc int,
                        Posiljaoc int,
constraint fk_zahtjev_Primaoc_TimoviID foreign key (primaoc) references OOADTimovi(ID),
constraint fk_zahtjev_Posiljaoc_KorisniciID foreign key (posiljaoc) references OOADKorisnici(ID));

CREATE TABLE OOADMec(
					ID int,
					VrijemeOdrzavanja date not null,
					MjestoOdrzavanja varchar(25) not null,
					TIM1 int not null,
					TIM2 int not null,
constraint pk_Mec primary key(ID),
constraint fk_Mec_TIM1 foreign key(TIM1) references OOADTimovi(ID),
constraint fk_Mec_TIM2 foreign key(TIM2) references OOADTimovi(ID)
)

CREATE TABLE OOADReview(
						ID int,
						komentar varchar(255),
						ocjena int not null,
						TIM int,
constraint pk_Review_ID primary key(ID),
constraint fk_Review_TIM foreign key (TIM) references OOADTimovi(ID));



CREATE TABLE OOADClanoviTima(
							Korisnik int not null,
							Tim int not null,
constraint fk_ClanoviTima_Tim foreign key(Tim) references OOADTimovi(ID),
constraint fk_ClanoviTima_Korisnik foreign key(Tim) references OOADKorisnici(ID))

CREATE TABLE OOADPoruka(
						ID int,
						Sadrzaj varchar(255) not null,
						Posiljaoc int not null,
						Primaoc int not null,
						Vidjenost int not null,
constraint pk_Poruka_ID primary key(ID),
constraint fk_Poruka_Poslijaoc foreign key (Posiljaoc) references OOADKorisnici(ID),
constraint fk_Poruka_Primaoc foreign key (Primaoc) references OOADKorisnici(ID)
)

CREATE TABLE OOADSampionat(
							ID int,
							Naziv varchar(25) not null,
							TimoviID int not null,
constraint pk_Sampionar_ID primary key(ID),
constraint fk_Poruka_TimoviID foreign key (TimoviID) references OOADTimovi(ID)
)

CREATE TABLE OOADNaziviPozicija (
						ID int,
						Naziv varchar(25),
constraint pk_NaziviPozicija primary key(ID)						
)

CREATE TABLE OOADPozicije(
						SportID int not null,
						PozID int not null,
constraint fk_Pozicije_SportID foreign key(SportID) references OOADSport(ID),
constraint fk_Pozicije_PozID foreign key (PozID) references OOADNaziviPozicija(ID)
)

CREATE TABLE OOADRezultat(
						MecID int not null,
						TIM1rez int not null,
						TIM2rez int not null,
constraint fk_Rezultat_MecID foreign key(MecID) references OOADMec(ID))