CREATE TABLE [dbo].[Utilisateur]
(
	[Id] INT NOT NULL IDENTITY, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(320) NOT NULL, 
    [Passwd] BINARY(64) NOT NULL, 
    CONSTRAINT [PK_Utilisateur] PRIMARY KEY ([Id]),
    CONSTRAINT [UK_Utilisateur_Email] UNIQUE ([Email])
)
