CREATE  FUNCTION uzmi_password (@username VARCHAR(255))
RETURNS VARCHAR(255)

BEGIN

Declare @pw  VARCHAR(255)

  
SET @pw = (SELECT password 
  FROM OOADkorisnici k
  WHERE @username = k.username);
  
RETURN (@pw)

END



 



CREATE FUNCTION DajSport(@ime varchar(50))
RETURNS varchar(50)
AS
BEGIN
declare @ime2 varchar(50);
SET @ime2 = (Select S.Naziv
			FROM OOADSport S, OOADTimovi t
			Where t.Ime = @ime AND t.SportID = S.ID);

RETURN(@ime2);
END;
