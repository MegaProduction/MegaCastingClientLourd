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
-- =============================================
-- Author:		<Author,Alexandre>
-- Create date: <Create Date,08/03/2021>
-- Description:	<Description,Verification sur l'ajout et edition des offres>
-- =============================================
CREATE   TRIGGER TR_VERIF_OFFRE 
   ON  Offre 
   AFTER INSERT,UPDATE
AS 
BEGIN
	IF EXISTS(SELECT * FROM inserted WHERE inserted.Intitule = '' OR inserted.Intitule = 'Intitulé')
	BEGIN
	ROLLBACK
	RAISERROR('Champ Intitulé incorrecte', 16,1);
	END;
	IF EXISTS(SELECT * FROM inserted WHERE inserted.NbPostes = '' OR ISNUMERIC(inserted.NbPostes)=0)
	BEGIN
	ROLLBACK
	RAISERROR('Champ Nombre de poste incorrecte', 16,1);
	END;
	IF EXISTS(SELECT * FROM inserted WHERE inserted.Coordonnées = '' OR inserted.Coordonnées = 'Coordonnées')
	BEGIN
	ROLLBACK
	RAISERROR('Champ Coordonnées incorrecte', 16,1);
	END;
	IF EXISTS(SELECT * FROM inserted WHERE inserted.DescriptionPoste = '' OR inserted.DescriptionPoste = 'Description du poste')
	BEGIN
	ROLLBACK
	RAISERROR('Champ Description du poste incorrecte', 16,1);
	END;
	IF EXISTS(SELECT * FROM inserted WHERE inserted.DescriptionProfil = '' OR inserted.DescriptionProfil = 'Description du profil')
	BEGIN
	ROLLBACK
	RAISERROR('Champ Description du profil incorrecte', 16,1);
	END;
	IF EXISTS(SELECT * FROM inserted WHERE inserted.DureeDiffusion = '' OR inserted.DureeDiffusion = 'Durée de diffusion')
	BEGIN
	ROLLBACK
	RAISERROR('Champ Durée de diffusion incorrecte', 16,1);
	END;
END

