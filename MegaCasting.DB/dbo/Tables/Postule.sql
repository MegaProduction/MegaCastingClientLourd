CREATE TABLE [dbo].[Postule] (
    [Identifiant]         INT IDENTITY (1, 1) NOT NULL,
    [IdentifiantOffre]    INT NOT NULL,
    [IdentifiantCandidat] INT NOT NULL,
    CONSTRAINT [PK_Postule] PRIMARY KEY CLUSTERED ([Identifiant] ASC),
    CONSTRAINT [FK_Postule_Candidat] FOREIGN KEY ([IdentifiantCandidat]) REFERENCES [dbo].[Candidat] ([Identifiant]),
    CONSTRAINT [FK_Postule_Offre] FOREIGN KEY ([IdentifiantOffre]) REFERENCES [dbo].[Offre] ([Identifiant])
);

