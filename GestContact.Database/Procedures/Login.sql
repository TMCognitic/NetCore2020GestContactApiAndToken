CREATE PROCEDURE [dbo].[Login]
	@Email NVARCHAR(320), 
    @Passwd NVARCHAR(20) 
AS
Begin
	SELECT Id, LastName, FirstName, Email
	From Utilisateur
	where Email = @Email and Passwd = HASHBYTES('SHA2_512', dbo.GetPreSalt() + @Passwd + dbo.GetPostSalt());
End
