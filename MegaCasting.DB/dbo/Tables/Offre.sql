CREATE TABLE [dbo].[Offre] (
    [Identifiant]        INT           IDENTITY (1, 1) NOT NULL,
    [Intitule]           NVARCHAR (50) NOT NULL,
    [Reference]          INT           NOT NULL,
    [DateDebut]          DATETIME2 (7) NOT NULL,
    [DureeDiffusion]     NVARCHAR (50) NULL,
    [NbPostes]           INT           NOT NULL,
    [Localisation]       INT           NOT NULL,
    [DescriptionPoste]   NVARCHAR (50) NOT NULL,
    [DescriptionProfil]  NVARCHAR (50) NOT NULL,
    [Coordonnées]        NVARCHAR (50) NOT NULL,
    [EstValide]          BIT           NOT NULL,
    [IdentifiantContrat] INT           NOT NULL,
    [DateAjout]          DATETIME2 (7) NULL,
    [IdentifiantMetier]  INT           NOT NULL,
    CONSTRAINT [PK_Offre] PRIMARY KEY CLUSTERED ([Identifiant] ASC),
    CONSTRAINT [FK_Offre_Contrat] FOREIGN KEY ([IdentifiantContrat]) REFERENCES [dbo].[Contrat] ([Identifiant]),
    CONSTRAINT [FK_Offre_Metier] FOREIGN KEY ([IdentifiantMetier]) REFERENCES [dbo].[Metier] ([Identifiant]),
    CONSTRAINT [FK_Offre_Ville] FOREIGN KEY ([Localisation]) REFERENCES [dbo].[Ville] ([Identifiant])
);





GO

GO



GO
