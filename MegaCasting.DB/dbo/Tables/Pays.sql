CREATE TABLE [dbo].[Pays] (
    [Identifiant] INT           IDENTITY (1, 1) NOT NULL,
    [Libelle]     NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Pays] PRIMARY KEY CLUSTERED ([Identifiant] ASC)
);

