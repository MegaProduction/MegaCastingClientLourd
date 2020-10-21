CREATE TABLE [dbo].[Metier] (
    [Identifiant]        INT           IDENTITY (1, 1) NOT NULL,
    [Libelle]            NVARCHAR (50) NOT NULL,
    [Fiche]              NVARCHAR (50) NOT NULL,
    [IdentifiantDomaine] INT           NOT NULL,
    CONSTRAINT [PK_Metier] PRIMARY KEY CLUSTERED ([Identifiant] ASC),
    CONSTRAINT [FK_Metier_Domaine] FOREIGN KEY ([IdentifiantDomaine]) REFERENCES [dbo].[Domaine] ([Identifiant])
);

