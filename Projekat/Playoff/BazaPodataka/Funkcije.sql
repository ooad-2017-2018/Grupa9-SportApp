CREATE  FUNCTION uzmi_password (@username VARCHAR(255))
RETURNS VARCHAR(255)
BEGIN
Declare @pw  VARCHAR(255)

  SET @pw = (SELECT password 
  FROM OOADkorisnici k
  WHERE @username = k.username);
  RETURN (@pw)
END



 


