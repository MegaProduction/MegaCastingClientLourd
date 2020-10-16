CREATE TABLE [dbo].[Client] (
    [Identifiant]      INT           IDENTITY (1, 1) NOT NULL,
    [Login]            NVARCHAR (50) NOT NULL,
    [Password]         NVARCHAR (50) NOT NULL,
    [Libelle]          NVARCHAR (50) NOT NULL,
    [VilleIdentifiant] INT           NULL,
    CONSTRAINT [PK_Partenaire] PRIMARY KEY CLUSTERED ([Identifiant] ASC),
    CONSTRAINT [FK_Client_Ville] FOREIGN KEY ([VilleIdentifiant]) REFERENCES [dbo].[Ville] ([Identifiant])
);

