CREATE TABLE [dbo].[OffreClient] (
    [Identifiant]       INT IDENTITY (1, 1) NOT NULL,
    [IdentifiantOffre]  INT NOT NULL,
    [IdentifiantClient] INT NOT NULL,
    CONSTRAINT [PK_OffreClient] PRIMARY KEY CLUSTERED ([Identifiant] ASC),
    CONSTRAINT [FK_OffreClient_Client] FOREIGN KEY ([IdentifiantClient]) REFERENCES [dbo].[Client] ([Identifiant]),
    CONSTRAINT [FK_OffreClient_Offre] FOREIGN KEY ([IdentifiantOffre]) REFERENCES [dbo].[Offre] ([Identifiant])
);

