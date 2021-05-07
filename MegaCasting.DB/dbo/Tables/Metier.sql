CREATE TABLE [dbo].[Metier] (
    [Identifiant]        INT           IDENTITY (1, 1) NOT NULL,
    [Libelle]            NVARCHAR (50) NOT NULL,
    [Fiche]              NVARCHAR (50) NOT NULL,
    [IdentifiantDomaine] INT           NOT NULL,
    CONSTRAINT [PK_Metier] PRIMARY KEY CLUSTERED ([Identifiant] ASC),
    CONSTRAINT [FK_Metier_Domaine] FOREIGN KEY ([IdentifiantDomaine]) REFERENCES [dbo].[Domaine] ([Identifiant])
);




GO
CREATE TRIGGER Tr_VerifieMetier ON Metier
   AFTER INSERT,UPDATE
AS 
BEGIN
	IF EXISTS(
		SELECT * 
		FROM inserted 
		WHERE inserted.Libelle='' 
		OR inserted.Libelle=' ' 
		OR inserted.Libelle = 'Nom du métier'
		)
		BEGIN 
			ROLLBACK
			RAISERROR('Nom du métier incorrect',16,1)
		END;
	IF EXISTS(
		SELECT * 
		FROM inserted 
		WHERE inserted.Fiche='' 
		OR inserted.Fiche=' ' 
		OR inserted.Fiche = 'Fiche du métier'
		)
		BEGIN 
			ROLLBACK
			RAISERROR('Fiche du métier incorrecte',16,1)
		END;
	IF EXISTS(
		SELECT COUNT(Metier.Libelle), Metier.Libelle 
		FROM Metier
		GROUP BY Metier.Libelle
		HAVING COUNT(Metier.Libelle) != 1)
		
		BEGIN
			ROLLBACK
			RAISERROR('Ce métier existe déjà',16,1)
		END;
END