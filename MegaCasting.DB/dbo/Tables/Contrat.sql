CREATE TABLE [dbo].[Contrat] (
    [Identifiant] INT           IDENTITY (1, 1) NOT NULL,
    [Libelle]     NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Contrat] PRIMARY KEY CLUSTERED ([Identifiant] ASC)
);

