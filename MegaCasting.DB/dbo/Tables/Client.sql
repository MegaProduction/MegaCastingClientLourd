CREATE TABLE [dbo].[Client] (
    [Identifiant]      INT           IDENTITY (1, 1) NOT NULL,
    [Login]            NVARCHAR (50) NOT NULL,
    [Password]         NVARCHAR (50) NOT NULL,
    [Libelle]          NVARCHAR (50) NOT NULL,
    [IdentifiantVille] INT           NOT NULL,
    CONSTRAINT [PK_Partenaire] PRIMARY KEY CLUSTERED ([Identifiant] ASC)
);

