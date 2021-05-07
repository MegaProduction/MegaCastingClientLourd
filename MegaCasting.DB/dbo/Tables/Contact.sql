CREATE TABLE [dbo].[Contact] (
    [Identifiant] INT            IDENTITY (1, 1) NOT NULL,
    [Prenom]      NVARCHAR (50)  NOT NULL,
    [Nom]         NVARCHAR (50)  NOT NULL,
    [Mail]        NVARCHAR (MAX) NOT NULL,
    [Adresse]     NVARCHAR (MAX) NOT NULL,
    [Objet]       NVARCHAR (MAX) NOT NULL,
    [Message]     NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([Identifiant] ASC)
);



