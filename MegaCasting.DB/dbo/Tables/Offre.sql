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
    CONSTRAINT [PK_Offre] PRIMARY KEY CLUSTERED ([Identifiant] ASC),
    CONSTRAINT [FK_Offre_Contrat] FOREIGN KEY ([IdentifiantContrat]) REFERENCES [dbo].[Contrat] ([Identifiant]),
    CONSTRAINT [FK_Offre_Ville] FOREIGN KEY ([Localisation]) REFERENCES [dbo].[Ville] ([Identifiant])
);

GO
CREATE   TRIGGER TR_OFFRE_VALID ON Offre
AFTER INSERT, UPDATE
AS 
	IF EXISTS(SELECT * FROM inserted WHERE inserted.Intitule ='' OR inserted.Intitule='Intitulé' OR inserted.DureeDiffusion='' OR inserted.DureeDiffusion='Durée de diffusion' OR inserted.NbPostes='' OR ISNUMERIC(inserted.NbPostes)=0 OR inserted.DescriptionPoste ='' OR inserted.DescriptionPoste='Description du poste' OR  inserted.DescriptionProfil='' OR inserted.DescriptionProfil='Description du profil' OR inserted.Coordonnées='' OR inserted.Coordonnées='Coordonnées')
	BEGIN
		ROLLBACK TRANSACTION
	END;
GO
CREATE   TRIGGER TR_OFFRE_REFERENCE ON Offre
AFTER INSERT
AS
	IF EXISTS(SELECT inserted.Reference FROM inserted WHERE inserted.Reference=0)
	BEGIN
		UPDATE Offre SET Reference = Identifiant+IdentifiantContrat WHERE Offre.Reference = 0
	END;

