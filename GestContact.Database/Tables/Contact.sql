CREATE TABLE [dbo].[Contact]
(
	[Id] INT NOT NULL IDENTITY, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [Phone] NVARCHAR(50) NULL, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [PK_Contact] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Contact_Utilisateur] FOREIGN KEY ([UserId]) REFERENCES [Utilisateur]([Id]) 
)
