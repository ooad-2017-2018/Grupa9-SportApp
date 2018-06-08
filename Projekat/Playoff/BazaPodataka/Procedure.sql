CREATE PROCEDURE Registruj(@user varchar(50), @password varchar(255), @ime varchar(255), @prezime varchar(255),@rodjen Date, @drzava varchar(50), @grad varchar(50), @dostupnost int)
AS
BEGIN
BEGIN TRANSACTION
declare @ID int, @N int, @I int;
SET @ID = NEXT VALUE FOR seq_kor_id;
SET @N = 0;
SET @I = (Select Count(*)
		  from OOADSport);

INSERT INTO OOADKorisnici
VALUES(@ID,@user,@password,@ime,@prezime,@rodjen,@drzava,@grad,@dostupnost);

INSERT INTO MMRKor
VALUES(@ID,2500,1);

INSERT INTO MMRKor
VALUES(@ID,2500,2);

INSERT INTO MMRKor
VALUES(@ID,2500,3);

INSERT INTO MMRKor
VALUES(@ID,2500,4);

INSERT INTO MMRKor
VALUES(@ID,2500,5);

COMMIT;
END

CREATE PROCEDURE KreirajTim(@ime varchar(50), @kapiten varchar(50), @sport varchar(50))
AS
BEGIN
BEGIN TRANSACTION
Declare @kapID int, @spID int;
SET @kapID = (Select ID
			  from OOADKorisnici
			  where Username = @kapiten);
SET @spID = (Select ID	
			 from OOADSport
			 where Naziv = @sport);

INSERT INTO OOADTimovi
VALUES(NEXT VALUE FOR seq_tim_id,@ime,@kapID,@spID,0);
COMMIT;
END

CREATE PROCEDURE DodajReview(@kom varchar(255), @ocjena int, @tim varchar(50))
AS
BEGIN
BEGIN TRANSACTION
Declare @TID int;
SET @TID = (SELECT ID
			FROM OOADTimovi
			WHERE ime = @tim);

INSERT INTO OOADReview
VALUES(NEXT VALUE FOR seq_rev_id,@kom,@ocjena,@TID);

COMMIT;
END

CREATE PROCEDURE DodajMec(@vrijeme Date, @mjesto varchar(25), @tim1 varchar(50), @tim2 varchar(50))
AS
BEGIN
BEGIN TRANSACTION
Declare @T1ID int, @T2ID int;

SET @T1ID = (SELECT ID
			 FROM OOADTimovi
			 WHERE @tim1 = Ime);

SET @T2ID = (SELECT ID
			 FROM OOADTimovi
			 WHERE @tim2 = Ime);
INSERT INTO OOADMec
VALUES(NEXT VALUE FOR seq_mec_id, @vrijeme,@mjesto,@T1ID,@T2ID);

COMMIT;
END;

CREATE PROCEDURE DodajRezultat(@mec int, @tim1 int, @tim2 int)
AS
BEGIN
BEGIN TRANSACTION

INSERT INTO OOADRezultat
VALUES(@mec,@tim1,@tim2);

COMMIT;
END;

CREATE PROCEDURE PosaljiZahtjev(@naziv varchar(50), @posiljaoc int, @sadrzaj varchar(200))
AS
BEGIN
BEGIN TRANSACTION
	Declare @prima int;
	SET @prima = (Select t.ID
				  FROM OOADTimovi t
				  WHERE naziv LIKE t.ime);

	INSERT INTO OOADZahtjev
	VALUES(@sadrzaj,0,@prima,@posiljaoc,NEXT VALUE FOR seq_rev_id);

COMMIT;
END;

CREATE PROCEDURE DodajUTim(@id int, @kor int)
AS
BEGIN
BEGIN TRANSACTION

INSERT INTO OOADClanoviTima
VALUES(@kor,@id);

declare @br int,@mmrkor int, @spID int;
SET @br = (Select count(*)
		   FROM OOADClanoviTima
		   WHERE Tim = @id);
		   
SET @spID = (Select SportID
             FROM OOADTimovi
			 WHERE ID = @id);
			 
SET @mmrkor = (Select MMR
			   FROM MMRKor
			   WHERE @kor = KorID AND @spID = SportID);


UPDATE OOADTimovi
SET MMR = (MMR + @mmrkor)/@br
WHERE @id = ID;
		   

COMMIT;
END;

CREATE PROCEDURE IzbacIzTima(@id int, @kor int)
AS
BEGIN
BEGIN TRANSACTION

DELETE FROM OOADClanoviTima
WHERE Korisnik = @kor;

declare @naziv varchar(50);

SET @naziv = (SELECT ime
			  FROM OOADTimovi
			  WHERE ID = @id)
			  declare @br int,@mmrkor int, @spID int;
SET @br = (Select count(*)
		   FROM OOADClanoviTima
		   WHERE Tim = @id);
		   
SET @spID = (Select SportID
             FROM OOADTimovi
			 WHERE ID = @id);
			 
SET @mmrkor = (Select MMR
			   FROM MMRKor
			   WHERE @kor = KorID AND @spID = SportID);

IF @br == 0 SET @br = @br +1;


UPDATE OOADTimovi
SET MMR = (MMR - @mmrkor)/@br
WHERE @id = ID;

INSERT INTO OOADProsliTimovi
VALUES(@kor,@naziv,SYSDATETIME());

COMMIT;
END;


CREATE PROCEDURE ObrisiPoruku(@id int)
AS
BEGIN
BEGIN TRANSACTION

DELETE FROM OOADPoruka
WHERE ID = @id;

COMMIT;
END;

CREATE FUNCTION DajIme(@id int)
RETURNS varchar(50)
AS
BEGIN
declare @ime varchar(50);
SET @ime = (SELECT Ime
		    FROM OOADKorisnici
			WHERE ID = @id)
RETURN(@ime);

END;
