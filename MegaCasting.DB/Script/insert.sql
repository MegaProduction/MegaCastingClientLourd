USE [MegaCasting]
GO
SET IDENTITY_INSERT [dbo].[Domaine] ON 

INSERT [dbo].[Domaine] ([Identifiant], [Libelle]) VALUES (1, N'Art')
INSERT [dbo].[Domaine] ([Identifiant], [Libelle]) VALUES (2, N'Production')
INSERT [dbo].[Domaine] ([Identifiant], [Libelle]) VALUES (3, N'Spectacle')
INSERT [dbo].[Domaine] ([Identifiant], [Libelle]) VALUES (4, N'Théatre')
INSERT [dbo].[Domaine] ([Identifiant], [Libelle]) VALUES (5, N'Cinéma')
SET IDENTITY_INSERT [dbo].[Domaine] OFF
SET IDENTITY_INSERT [dbo].[Metier] ON 

INSERT [dbo].[Metier] ([Identifiant], [Libelle], [Fiche], [IdentifiantDomaine]) VALUES (3, N'Acteur', N'Joue des rôles principaux', 5)
INSERT [dbo].[Metier] ([Identifiant], [Libelle], [Fiche], [IdentifiantDomaine]) VALUES (4, N'Acteur secondaire', N'Joue des rôles secondaires', 5)
INSERT [dbo].[Metier] ([Identifiant], [Libelle], [Fiche], [IdentifiantDomaine]) VALUES (6, N'Comédien', N'Joue des pièces de théâtre', 4)
INSERT [dbo].[Metier] ([Identifiant], [Libelle], [Fiche], [IdentifiantDomaine]) VALUES (7, N'Artiste de rue', N'Prestation', 3)
SET IDENTITY_INSERT [dbo].[Metier] OFF
SET IDENTITY_INSERT [dbo].[Contrat] ON 

INSERT [dbo].[Contrat] ([Identifiant], [Libelle]) VALUES (1, N'CDD')
INSERT [dbo].[Contrat] ([Identifiant], [Libelle]) VALUES (2, N'CDI')
INSERT [dbo].[Contrat] ([Identifiant], [Libelle]) VALUES (3, N'Offre casting artiste de rue')
INSERT [dbo].[Contrat] ([Identifiant], [Libelle]) VALUES (4, N'Offre casting second role')
SET IDENTITY_INSERT [dbo].[Contrat] OFF
SET IDENTITY_INSERT [dbo].[Pays] ON 

INSERT [dbo].[Pays] ([Identifiant], [Libelle]) VALUES (1, N'FRANCE')
INSERT [dbo].[Pays] ([Identifiant], [Libelle]) VALUES (2, N'ETATS-UNIS')
SET IDENTITY_INSERT [dbo].[Pays] OFF
SET IDENTITY_INSERT [dbo].[Ville] ON 

INSERT [dbo].[Ville] ([Identifiant], [Libelle], [CodePostal], [IdentifiantPays]) VALUES (1, N'Laval', N'53000', 1)
INSERT [dbo].[Ville] ([Identifiant], [Libelle], [CodePostal], [IdentifiantPays]) VALUES (2, N'Angers', N'49000', 1)
INSERT [dbo].[Ville] ([Identifiant], [Libelle], [CodePostal], [IdentifiantPays]) VALUES (4, N'Paris', N'75000', 1)
INSERT [dbo].[Ville] ([Identifiant], [Libelle], [CodePostal], [IdentifiantPays]) VALUES (5, N'Nantes', N'44000', 1)
INSERT [dbo].[Ville] ([Identifiant], [Libelle], [CodePostal], [IdentifiantPays]) VALUES (6, N'Los Angeles', N'90001', 2)
SET IDENTITY_INSERT [dbo].[Ville] OFF
SET IDENTITY_INSERT [dbo].[Offre] ON 

INSERT [dbo].[Offre] ([Identifiant], [Intitule], [Reference], [DateDebut], [DureeDiffusion], [NbPostes], [Localisation], [DescriptionPoste], [DescriptionProfil], [Coordonnées], [EstValide], [IdentifiantContrat], [DateAjout]) VALUES (2, N'Offre de casting Comédien', 1, CAST(N'2020-10-09T00:00:00.000' AS DateTime), N'15', 3, 1, N'Jouer un role dans un film', N'Comédien avec 2 ans d''expérience', N'0243585960', 1, 2, NULL)
INSERT [dbo].[Offre] ([Identifiant], [Intitule], [Reference], [DateDebut], [DureeDiffusion], [NbPostes], [Localisation], [DescriptionPoste], [DescriptionProfil], [Coordonnées], [EstValide], [IdentifiantContrat], [DateAjout]) VALUES (5, N'Offre de casting acteur', 2, CAST(N'2021-02-28T00:00:00.000' AS DateTime), N'15', 5, 4, N'Jouer un role principal dans un petit film', N'Acteur jeune', N'0243568574', 1, 1, NULL)
INSERT [dbo].[Offre] ([Identifiant], [Intitule], [Reference], [DateDebut], [DureeDiffusion], [NbPostes], [Localisation], [DescriptionPoste], [DescriptionProfil], [Coordonnées], [EstValide], [IdentifiantContrat], [DateAjout]) VALUES (1023, N'offre avec date d''ajout', 0, CAST(N'2020-11-09T00:00:00.000' AS DateTime), N'10', 10, 2, N'dgbiudgkj', N'dgbed', N'1010101', 1, 1, CAST(N'2020-11-09T11:46:44.7105069' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Offre] OFF
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([Identifiant], [Login], [Password], [Libelle], [VilleIdentifiant]) VALUES (1, N' Hollywood Studios
', N'Hollywood123', N'Hollywood Studios
', 1)
INSERT [dbo].[Client] ([Identifiant], [Login], [Password], [Libelle], [VilleIdentifiant]) VALUES (2, N'Studio 9
', N'Studio9123
', N'Studio 9
', 1)
INSERT [dbo].[Client] ([Identifiant], [Login], [Password], [Libelle], [VilleIdentifiant]) VALUES (3, N'Marvel Production', N'MarvelProduction', N'MarvelProduction', 6)
INSERT [dbo].[Client] ([Identifiant], [Login], [Password], [Libelle], [VilleIdentifiant]) VALUES (4, N'Loft Production', N'LoftProduction123', N'Loft Production', 2)
SET IDENTITY_INSERT [dbo].[Client] OFF
SET IDENTITY_INSERT [dbo].[OffreClient] ON 

INSERT [dbo].[OffreClient] ([Identifiant], [IdentifiantOffre], [IdentifiantPartenaire]) VALUES (5, 2, 2)
INSERT [dbo].[OffreClient] ([Identifiant], [IdentifiantOffre], [IdentifiantPartenaire]) VALUES (6, 5, 4)
INSERT [dbo].[OffreClient] ([Identifiant], [IdentifiantOffre], [IdentifiantPartenaire]) VALUES (1015, 1023, 1)
SET IDENTITY_INSERT [dbo].[OffreClient] OFF
SET IDENTITY_INSERT [dbo].[Candidat] ON 

INSERT [dbo].[Candidat] ([Identifiant], [Login], [Password], [Firstname], [Lastname], [Competence]) VALUES (1, N'Jean', N'tetete', N'Jean', N'Dupont', N'Second role')
INSERT [dbo].[Candidat] ([Identifiant], [Login], [Password], [Firstname], [Lastname], [Competence]) VALUES (2, N'Bernad', N'tetet', N'Bernad', N'Dupont', N'second role')
INSERT [dbo].[Candidat] ([Identifiant], [Login], [Password], [Firstname], [Lastname], [Competence]) VALUES (3, N'BACARD', N'BACARD1979$', N'HUGO', N'BACARD', N'Artiste')
INSERT [dbo].[Candidat] ([Identifiant], [Login], [Password], [Firstname], [Lastname], [Competence]) VALUES (4, N'BAKER', N'Allon1996$', N'MATTHEW', N'BAKER', N'Comédien')
INSERT [dbo].[Candidat] ([Identifiant], [Login], [Password], [Firstname], [Lastname], [Competence]) VALUES (5, N'BALWE', N'Allon1996$', N'CHETAN', N'BALWE', N'Comédien')
INSERT [dbo].[Candidat] ([Identifiant], [Login], [Password], [Firstname], [Lastname], [Competence]) VALUES (6, N'BELAIR', N'Allon1996$', N'LUC', N'BELAIR', N'Comédien')
INSERT [dbo].[Candidat] ([Identifiant], [Login], [Password], [Firstname], [Lastname], [Competence]) VALUES (7, N'BERKOVICH', N'Allon1996$', N'VLADIMIR', N'BERKOVICH', N'Comédien')
INSERT [dbo].[Candidat] ([Identifiant], [Login], [Password], [Firstname], [Lastname], [Competence]) VALUES (8, N'BHOWIK', N'Allon1996$', N'BENOIT', N'BHOWIK', N'Comédien')
INSERT [dbo].[Candidat] ([Identifiant], [Login], [Password], [Firstname], [Lastname], [Competence]) VALUES (9, N'BLOSSIER', N'Allon1996$', N'PRASENJIT', N'BLOSSIER', N'Comédien')
INSERT [dbo].[Candidat] ([Identifiant], [Login], [Password], [Firstname], [Lastname], [Competence]) VALUES (11, N'Allon', N'Allon1996$', N'Levy', N'Allon', N'Comédien')
INSERT [dbo].[Candidat] ([Identifiant], [Login], [Password], [Firstname], [Lastname], [Competence]) VALUES (13, N'MARTIN', N'MARTIN2514$', N'FLORENT', N'MARTIN', N'Acteur')
INSERT [dbo].[Candidat] ([Identifiant], [Login], [Password], [Firstname], [Lastname], [Competence]) VALUES (14, N'TEPPER', N'TEPPER154', N'MICKAEL', N'TEPPER', N'Acteur')
SET IDENTITY_INSERT [dbo].[Candidat] OFF
SET IDENTITY_INSERT [dbo].[Postule] ON 

INSERT [dbo].[Postule] ([Identifiant], [IdentifiantOffre], [IdentifiantCandidat]) VALUES (1, 2, 4)
INSERT [dbo].[Postule] ([Identifiant], [IdentifiantOffre], [IdentifiantCandidat]) VALUES (2, 2, 5)
INSERT [dbo].[Postule] ([Identifiant], [IdentifiantOffre], [IdentifiantCandidat]) VALUES (3, 2, 6)
INSERT [dbo].[Postule] ([Identifiant], [IdentifiantOffre], [IdentifiantCandidat]) VALUES (4, 2, 7)
INSERT [dbo].[Postule] ([Identifiant], [IdentifiantOffre], [IdentifiantCandidat]) VALUES (5, 2, 8)
INSERT [dbo].[Postule] ([Identifiant], [IdentifiantOffre], [IdentifiantCandidat]) VALUES (6, 2, 9)
INSERT [dbo].[Postule] ([Identifiant], [IdentifiantOffre], [IdentifiantCandidat]) VALUES (7, 2, 11)
INSERT [dbo].[Postule] ([Identifiant], [IdentifiantOffre], [IdentifiantCandidat]) VALUES (9, 5, 13)
INSERT [dbo].[Postule] ([Identifiant], [IdentifiantOffre], [IdentifiantCandidat]) VALUES (10, 5, 14)
SET IDENTITY_INSERT [dbo].[Postule] OFF
