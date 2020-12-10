CREATE TABLE [dbo].[Offre] (
    [Identifiant]        INT            IDENTITY (1, 1) NOT NULL,
    [Intitule]           NVARCHAR (50)  NOT NULL,
    [Reference]          INT            NOT NULL,
    [DateDebut]          DATETIME2 (7)  NOT NULL,
    [DureeDiffusion]     NVARCHAR (50)  NULL,
    [NbPostes]           INT            NOT NULL,
    [Localisation]       INT            NOT NULL,
    [DescriptionPoste]   NVARCHAR (300) NOT NULL,
    [DescriptionProfil]  NVARCHAR (300) NOT NULL,
    [Coordonnées]        NVARCHAR (50)  NOT NULL,
    [EstValide]          BIT            NOT NULL,
    [IdentifiantContrat] INT            NOT NULL,
    [DateAjout]          DATETIME2 (7)  NULL,
    CONSTRAINT [PK_Offre] PRIMARY KEY CLUSTERED ([Identifiant] ASC),
    CONSTRAINT [FK_Offre_Contrat] FOREIGN KEY ([IdentifiantContrat]) REFERENCES [dbo].[Contrat] ([Identifiant]),
    CONSTRAINT [FK_Offre_Ville] FOREIGN KEY ([Localisation]) REFERENCES [dbo].[Ville] ([Identifiant])
);



GO

GO
CREATE   TRIGGER TR_OFFRE_REFERENCE ON [dbo].[Offre]
AFTER INSERT
AS
	IF EXISTS(SELECT inserted.Reference FROM inserted WHERE inserted.Reference=0)
	BEGIN
		UPDATE Offre SET Reference = Identifiant+IdentifiantContrat WHERE Offre.Reference = 0
	END;


GO
-- =============================================
-- Author:		<Alexandre,BREAULT>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER TR_OFFRE_INTITULE
   ON  OFFRE 
   AFTER INSERT, UPDATE
AS 
BEGIN
	IF EXISTS(SELECT inserted.Intitule FROM inserted WHERE inserted.Intitule ='' OR inserted.Intitule='Intitulé')
	BEGIN
		ROLLBACK TRANSACTION
	END;
END