CREATE TABLE [dbo].[Erreur] (
    [Identifiant] INT            NOT NULL,
    [CodeErreur]  NCHAR (10)     NOT NULL,
    [MessageFR]   NVARCHAR (MAX) NULL,
    [MessageEN]   NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Erreur_1] PRIMARY KEY CLUSTERED ([Identifiant] ASC)
);

