CREATE TABLE [dbo].[Payee]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[CustomerNumber] nvarchar(50),
	[Name] nvarchar(50),
	[AccountNumber] nvarchar(50),
	[Bsb] nvarchar(20), 
    [Description] NCHAR(10) NULL,
	[IsDeleted] BIT NOT NULL
)
