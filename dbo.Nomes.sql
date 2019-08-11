use ListaNomes

CREATE TABLE [dbo].[Nomes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nome] VARCHAR(100) NOT NULL, 
    [snome] VARCHAR(100) NOT NULL
)
