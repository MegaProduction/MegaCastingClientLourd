CREATE TABLE [dbo].[Ville] (
    [Identifiant]     INT           IDENTITY (1, 1) NOT NULL,
    [Libelle]         NVARCHAR (50) NOT NULL,
    [CodePostal]      NVARCHAR (15) NULL,
    [IdentifiantPays] INT           NOT NULL,
    CONSTRAINT [PK_Ville] PRIMARY KEY CLUSTERED ([Identifiant] ASC),
    CONSTRAINT [FK_Ville_Pays] FOREIGN KEY ([IdentifiantPays]) REFERENCES [dbo].[Pays] ([Identifiant])
);










GO
CREATE   TRIGGER [dbo].[Tr_Ville] ON [dbo].[Ville]
AFTER INSERT, UPDATE
AS
	IF EXISTS(
		SELECT *
		FROM inserted
		WHERE inserted.Libelle = '' OR inserted.Libelle = ' ' OR inserted.Libelle = 'Ville'
		)
		BEGIN
			ROLLBACK;
			RAISERROR('Champ Ville incorrect', 16, 1);
		END;
	IF EXISTS(
		SELECT *
		FROM inserted
		WHERE inserted.CodePostal = '' OR inserted.CodePostal = ' ' OR inserted.CodePostal = 'Code postal'
		)
		BEGIN
			ROLLBACK;
			RAISERROR('Champ Code postal incorrect', 16, 1);
		END;