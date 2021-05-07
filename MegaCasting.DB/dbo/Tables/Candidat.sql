CREATE TABLE [dbo].[Candidat] (
    [Identifiant] INT            IDENTITY (1, 1) NOT NULL,
    [Login]       NVARCHAR (50)  NOT NULL,
    [Password]    NVARCHAR (150) NOT NULL,
    [Firstname]   NVARCHAR (50)  NOT NULL,
    [Lastname]    NVARCHAR (50)  NOT NULL,
    [Competence]  NVARCHAR (50)  NOT NULL,
    [is_verified] BIT            NOT NULL,
    CONSTRAINT [PK_Candidat] PRIMARY KEY CLUSTERED ([Identifiant] ASC)
);



