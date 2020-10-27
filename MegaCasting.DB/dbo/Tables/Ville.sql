CREATE TABLE [dbo].[Ville] (
    [Identifiant]     INT           IDENTITY (1, 1) NOT NULL,
    [Libelle]         NVARCHAR (50) NOT NULL,
    [CodePostal]      NVARCHAR (10) NOT NULL,
    [IdentifiantPays] INT           NOT NULL,
    CONSTRAINT [PK_Ville] PRIMARY KEY CLUSTERED ([Identifiant] ASC),
    CONSTRAINT [FK_Ville_Pays] FOREIGN KEY ([IdentifiantPays]) REFERENCES [dbo].[Pays] ([Identifiant])
);

