CREATE TABLE [dbo].[Contrat] (
    [Identifiant] INT           IDENTITY (1, 1) NOT NULL,
    [Libelle]     NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Contrat] PRIMARY KEY CLUSTERED ([Identifiant] ASC)
);



GO
CREATE  TRIGGER [dbo].[TR_LIBELLE_CONTRAT] ON [dbo].[Contrat]
AFTER INSERT, UPDATE
AS
	IF EXISTS(SELECT * FROM inserted WHERE inserted.Libelle='' OR inserted.Libelle=' ' OR inserted.Libelle = 'Nom du type de contrat')
	BEGIN
		ROLLBACK TRANSACTION
	END;

GO
-- =============================================
-- Author:		<Alexandre,BREAULT>
-- Create date: <08/12/2020>
-- Description:	<reload>
-- =============================================
CREATE TRIGGER TR_CONTRAT_RELOAD
   ON  Contrat 
   AFTER INSERT,UPDATE
AS 
IF EXISTS(SELECT inserted.Identifiant FROM inserted WHERE LEN(inserted.Libelle)>50)
BEGIN
	ROLLBACK
END;