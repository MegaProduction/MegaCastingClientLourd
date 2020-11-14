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
