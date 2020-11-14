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

CREATE   TRIGGER Tr_TextBox ON Client
AFTER INSERT, UPDATE
AS
	IF EXISTS(
		SELECT *
		FROM inserted
		WHERE inserted.Libelle = ' ' OR inserted.Libelle = '' OR inserted.Login = '' OR inserted.Login = ' ' OR inserted.Password = '' OR inserted.Password = ' '
		OR inserted.Libelle = 'Libellé'
		)
		BEGIN
			ROLLBACK;
		END;