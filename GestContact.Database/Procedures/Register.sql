CREATE PROCEDURE [dbo].[Register]
	@LastName NVARCHAR(50), 
    @FirstName NVARCHAR(50), 
    @Email NVARCHAR(320), 
    @Passwd NVARCHAR(20) 
AS
BEGIN
	insert into [Utilisateur] (LastName, FirstName, Email, Passwd)
    output inserted.Id
    values (@LastName, @FirstName, @Email, HASHBYTES('SHA2_512', dbo.GetPreSalt() + @Passwd + dbo.GetPostSalt()));
END
