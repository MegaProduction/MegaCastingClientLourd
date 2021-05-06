CREATE TABLE [dbo].[Pays] (
    [Identifiant] INT           IDENTITY (1, 1) NOT NULL,
    [Libelle]     NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Pays] PRIMARY KEY CLUSTERED ([Identifiant] ASC)
);






GO
CREATE   TRIGGER [dbo].[Tr_Pays] ON [dbo].[Pays]
AFTER INSERT, UPDATE
AS
	IF EXISTS(
		SELECT *
		FROM inserted
		WHERE inserted.Libelle = '' OR inserted.Libelle = ' ' OR inserted.Libelle = 'Pays'
		)
		BEGIN
			ROLLBACK;
			RAISERROR('Champ Pays incorrect', 16, 1);
		END;