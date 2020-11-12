CREATE TABLE [dbo].[Pays] (
    [Identifiant] INT           IDENTITY (1, 1) NOT NULL,
    [Libelle]     NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Pays] PRIMARY KEY CLUSTERED ([Identifiant] ASC)
);




GO
CREATE   TRIGGER Tr_Pays ON Pays
AFTER INSERT, UPDATE
AS
	IF EXISTS(
		SELECT *
		FROM inserted
		WHERE inserted.Libelle = '' OR inserted.Libelle = ' ' OR inserted.Libelle = 'Pays'
		)
		BEGIN
			ROLLBACK;
		END;