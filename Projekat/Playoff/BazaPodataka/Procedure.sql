CREATE PROCEDURE Registruj(@user varchar(50), @password varchar(255), @ime varchar(255), @prezime varchar(255),@rodjen Date, @drzava varchar(50), @grad varchar(50), @dostupnost int)
AS
BEGIN
BEGIN TRANSACTION
INSERT INTO OOADKorisnici
VALUES(NEXT VALUE FOR seq_kor_id,@user,@password,@ime,@prezime,@rodjen,@drzava,@grad,@dostupnost);
COMMIT;
END;



