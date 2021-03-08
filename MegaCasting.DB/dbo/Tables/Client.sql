CREATE TABLE [dbo].[Client] (
    [Identifiant]      INT           IDENTITY (1, 1) NOT NULL,
    [Login]            NVARCHAR (50) NOT NULL,
    [Password]         NVARCHAR (50) NOT NULL,
    [Libelle]          NVARCHAR (50) NOT NULL,
    [VilleIdentifiant] INT           NOT NULL,
    CONSTRAINT [PK_Partenaire] PRIMARY KEY CLUSTERED ([Identifiant] ASC),
    CONSTRAINT [FK_Client_Ville] FOREIGN KEY ([VilleIdentifiant]) REFERENCES [dbo].[Ville] ([Identifiant])
);



GO
CREATE     TRIGGER [dbo].[Tr_ClientVide] ON [dbo].[Client]
AFTER INSERT, UPDATE
AS
	IF EXISTS(
		SELECT *
		FROM inserted
		WHERE inserted.Libelle = ' ' OR inserted.Libelle = '' OR inserted.Libelle = 'Libellé'
		)
		BEGIN
			ROLLBACK;
			RAISERROR('Champ Libellé incorrect', 16, 1);
		END;
	IF EXISTS(
		SELECT *
		FROM inserted
		WHERE inserted.Login = ' ' OR inserted.Login = '' OR inserted.Login = 'Login'
		)
		BEGIN
			ROLLBACK;
			RAISERROR('Champ Login incorrect', 16, 1);
		END;
	IF EXISTS(
		SELECT *
		FROM inserted
		WHERE inserted.Password = ' ' OR inserted.Password = '' OR inserted.Password = 'Mot de passe'
		)
		BEGIN
			ROLLBACK;
			RAISERROR('Champ Mot de passe incorrect', 16, 1);
		END;