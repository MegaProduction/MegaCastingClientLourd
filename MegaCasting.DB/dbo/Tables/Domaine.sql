CREATE TABLE [dbo].[Domaine] (
    [Identifiant] INT           IDENTITY (1, 1) NOT NULL,
    [Libelle]     NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Domaine] PRIMARY KEY CLUSTERED ([Identifiant] ASC)
);

