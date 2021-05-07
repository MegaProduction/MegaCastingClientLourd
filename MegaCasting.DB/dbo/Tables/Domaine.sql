CREATE TABLE [dbo].[Domaine] (
    [Identifiant] INT           IDENTITY (1, 1) NOT NULL,
    [Libelle]     NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Domaine] PRIMARY KEY CLUSTERED ([Identifiant] ASC)
);




GO
CREATE   TRIGGER [dbo].[Tr_VerifieDomaine] ON [dbo].[Domaine]
   AFTER INSERT,UPDATE
AS 
BEGIN
	IF EXISTS(
		SELECT * FROM inserted WHERE inserted.Libelle='' OR inserted.Libelle=' ' OR inserted.Libelle = 'Nom du domaine')
		BEGIN 
			ROLLBACK
			RAISERROR('Libellé incorrect',16,1)
		END;
END
GO
CREATE   TRIGGER Tr_ExisteDomaine ON Domaine
   AFTER INSERT,UPDATE
AS 
BEGIN
	IF EXISTS(SELECT COUNT(Domaine.Libelle), Domaine.Libelle FROM Domaine
		GROUP BY Domaine.Libelle
		HAVING COUNT(Domaine.Libelle) != 1)
		
		BEGIN
			ROLLBACK
			RAISERROR('Ce domaine existe déjà',16,1)
		END;
END