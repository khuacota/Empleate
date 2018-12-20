USE [Empleate_db]
GO
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3c2b6cad-b737-4071-9a77-e7c5f8af44fa', N'pedro@gmail.com', N'PEDRO@GMAIL.COM', N'pedro@gmail.com', N'PEDRO@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEFLg45auBog3h/D0DnT0tvTCNrLvCKRymvYUKyKNpQiMOewELAdVvCXktTCBPIrXSA==', N'GZUM2YRMMLXP6OJ4FND66WGUZALIIEJV', N'81093544-e2a8-427a-aec0-f11cc61e4642', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'49e99b46-e6b2-4642-a558-d26346d8a988', N'sofia@gmail.com', N'SOFIA@GMAIL.COM', N'sofia@gmail.com', N'SOFIA@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEOTqNO0uo7KPWLun+7I4b3zM/46NMZMoljPlNFQvmVocTaewFkYa27xPsJpbPaFO6A==', N'5W55CHOHWJP74OXT2F5BLNFSF4WTNBYJ', N'88ef1e3b-9796-43a6-8323-1032613a7c80', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'7c3be3d5-b45a-4b5f-af10-5a7faa992933', N'jala@gmail.com', N'JALA@GMAIL.COM', N'jala@gmail.com', N'JALA@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEBPdMXyoDzmWzRbC6Ahs38XahVdNlu4qtF+H9hpf7M6ILocEkDFKCYvO3nQvT4LThw==', N'SLQKPJ4QGIYSV7MQYHPYXJET7HXSEQKP', N'8318647b-6569-40cc-bdf5-ea80999f9716', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'be50c33d-c9c5-4fe4-b49d-69e703fe002b', N'olivos@mail.com', N'OLIVOS@MAIL.COM', N'olivos@mail.com', N'OLIVOS@MAIL.COM', 0, N'AQAAAAEAACcQAAAAELCMb2oP8uJnD8Gy8btS/uyVIaxPxM8fmp/tae+XBXwtg/GHjdtxRPgUIT42E+5Ehw==', N'XECM46ZEHI7BYRML7D4GTZBB5J5UKC2M', N'29de6c80-04da-49c2-a35f-5a31c150b0d1', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'f0af59f9-2879-43c5-84cb-d42e9c12c008', N'drmario@gmail.com', N'DRMARIO@GMAIL.COM', N'drmario@gmail.com', N'DRMARIO@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEAXj/rfrwCV2Y1o7uAdksSDegkFX7tN8ha8P0ZuzBRy0Nyd/UW3CxatvYR2J4+IHbw==', N'Z2WV3ZDS35CVUVFSCI4NITSTPF6A3DLD', N'9dd744e7-2171-4496-94a7-cf71bac0b564', NULL, 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Companies] ON 

INSERT [dbo].[Companies] ([Id], [IdUser], [Name], [Description], [Entry], [Address], [Phone], [Email], [Url], [Image]) VALUES (1, N'7c3be3d5-b45a-4b5f-af10-5a7faa992933', N'JalaSoft', N'Desarrolladora de software mas grande en Bolivia', N'Social', N'Melchor Perez', 78945612, N'JalaSoft@hotmail.com', N'www.JalaSoft.com', N'C:\fakepath\acspike-male-user-icon.png')
INSERT [dbo].[Companies] ([Id], [IdUser], [Name], [Description], [Entry], [Address], [Phone], [Email], [Url], [Image]) VALUES (2, N'be50c33d-c9c5-4fe4-b49d-69e703fe002b', N'Los Olivos', N'Hospital privado Boliviano de alta categoria y prestigio internacional', N'Limpieza', N'Melchor Perez', 78945123, N'LosOlivos@gmail.com', N'www.LosOlivos.com', N'C:\fakepath\acspike-male-user-icon.png')
SET IDENTITY_INSERT [dbo].[Companies] OFF

SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [IdUser], [Name], [LastName], [Birthdate], [Gender], [CivilStatus], [Phone], [City], [Direction], [Email], [Image]) VALUES (1, N'3c2b6cad-b737-4071-9a77-e7c5f8af44fa', N'Pedro', N'Mendez', CAST(N'1992-01-01T04:00:00.0000000' AS DateTime2), N'Masculino', N'married', 78945612, N'La Paz', N'Chimba', N'Pedro@gmail.com', N'C:\fakepath\acspike-male-user-icon.png')
INSERT [dbo].[Employees] ([Id], [IdUser], [Name], [LastName], [Birthdate], [Gender], [CivilStatus], [Phone], [City], [Direction], [Email], [Image]) VALUES (2, N'49e99b46-e6b2-4642-a558-d26346d8a988', N'Sofia', N'Guzman', CAST(N'1992-01-05T04:00:00.0000000' AS DateTime2), N'Masculino', N'single', 78945612, N'Sucre', N'av peru', N'Sofia@gmail.com', N'C:\fakepath\acspike-male-user-icon.png')
INSERT [dbo].[Employees] ([Id], [IdUser], [Name], [LastName], [Birthdate], [Gender], [CivilStatus], [Phone], [City], [Direction], [Email], [Image]) VALUES (3, N'f0af59f9-2879-43c5-84cb-d42e9c12c008', N'Mario', N'Bros', CAST(N'2000-12-01T04:00:00.0000000' AS DateTime2), N'Masculino', N'single', 78945612, N'Londres', N'sucre', N'mario@nientiendo.com', N'C:\fakepath\acspike-male-user-icon.png')
SET IDENTITY_INSERT [dbo].[Employees] OFF
SET IDENTITY_INSERT [dbo].[Offers] ON 

INSERT [dbo].[Offers] ([Id], [CompanyId], [Profession], [Description], [MinExperience], [City], [StartTime], [EndTime], [Deadline]) VALUES (1, 1, N'Designer', N'se solicita un experto en el manejo de Power Designer', 3, N'Cochabamba', CAST(N'2018-12-19T00:59:00.0000000' AS DateTime2), CAST(N'2018-12-19T12:59:00.0000000' AS DateTime2), CAST(N'2018-12-21T04:00:00.0000000' AS DateTime2))
INSERT [dbo].[Offers] ([Id], [CompanyId], [Profession], [Description], [MinExperience], [City], [StartTime], [EndTime], [Deadline]) VALUES (2, 1, N'Programer', N'Se solicita un experto en el manejo de c++', 3, N'Cochabamba', CAST(N'2018-12-20T12:59:00.0000000' AS DateTime2), CAST(N'2018-12-20T12:59:00.0000000' AS DateTime2), CAST(N'2018-12-31T04:00:00.0000000' AS DateTime2))
INSERT [dbo].[Offers] ([Id], [CompanyId], [Profession], [Description], [MinExperience], [City], [StartTime], [EndTime], [Deadline]) VALUES (3, 2, N'Neurologo', N'Se solicita un neurologo', 3, N'Cochambamba', CAST(N'2018-12-20T12:59:00.0000000' AS DateTime2), CAST(N'2018-12-20T23:58:00.0000000' AS DateTime2), CAST(N'2018-12-30T04:00:00.0000000' AS DateTime2))
INSERT [dbo].[Offers] ([Id], [CompanyId], [Profession], [Description], [MinExperience], [City], [StartTime], [EndTime], [Deadline]) VALUES (4, 1, N'Diseñador Web', N'Se solicita un diseñador en angular', 8, N'Cochabamba', CAST(N'2018-12-20T09:57:00.0000000' AS DateTime2), CAST(N'2018-12-20T07:55:00.0000000' AS DateTime2), CAST(N'2018-12-29T04:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Offers] OFF
INSERT [dbo].[UserRoles] ([UserId], [RoleId], [UserId1]) VALUES (N'3c2b6cad-b737-4071-9a77-e7c5f8af44fa', N'1', NULL)
INSERT [dbo].[UserRoles] ([UserId], [RoleId], [UserId1]) VALUES (N'49e99b46-e6b2-4642-a558-d26346d8a988', N'1', NULL)
INSERT [dbo].[UserRoles] ([UserId], [RoleId], [UserId1]) VALUES (N'7c3be3d5-b45a-4b5f-af10-5a7faa992933', N'2', NULL)
INSERT [dbo].[UserRoles] ([UserId], [RoleId], [UserId1]) VALUES (N'be50c33d-c9c5-4fe4-b49d-69e703fe002b', N'2', NULL)
INSERT [dbo].[UserRoles] ([UserId], [RoleId], [UserId1]) VALUES (N'f0af59f9-2879-43c5-84cb-d42e9c12c008', N'1', NULL)

SET IDENTITY_INSERT [dbo].[Degrees] ON 

INSERT [dbo].[Degrees] ([Id], [Degree], [Description], [EmployeeId]) VALUES (1, N'Doctorado', N'fontanero', 3)
SET IDENTITY_INSERT [dbo].[Degrees] OFF
SET IDENTITY_INSERT [dbo].[EmployeeOccupations] ON 

INSERT [dbo].[EmployeeOccupations] ([Id], [Occupation], [EmployeeId]) VALUES (1, N'Diseñador', 1)
INSERT [dbo].[EmployeeOccupations] ([Id], [Occupation], [EmployeeId]) VALUES (2, N'programador', 2)
INSERT [dbo].[EmployeeOccupations] ([Id], [Occupation], [EmployeeId]) VALUES (3, N'Medico Cirujano', 3)
SET IDENTITY_INSERT [dbo].[EmployeeOccupations] OFF
SET IDENTITY_INSERT [dbo].[EmployeeSkills] ON 

INSERT [dbo].[EmployeeSkills] ([Id], [Skill], [EmployeeId]) VALUES (1, N'Angular', 1)
INSERT [dbo].[EmployeeSkills] ([Id], [Skill], [EmployeeId]) VALUES (2, N'JavaScript', 2)
INSERT [dbo].[EmployeeSkills] ([Id], [Skill], [EmployeeId]) VALUES (3, N'Neurologo', 3)
SET IDENTITY_INSERT [dbo].[EmployeeSkills] OFF
SET IDENTITY_INSERT [dbo].[Experiences] ON 

INSERT [dbo].[Experiences] ([Id], [Place], [Position], [Inicio], [Fin], [EmployeeId]) VALUES (1, N'Microsoft', N'Programer', CAST(N'2018-12-01T04:00:00.0000000' AS DateTime2), CAST(N'2018-12-18T04:00:00.0000000' AS DateTime2), 3)
SET IDENTITY_INSERT [dbo].[Experiences] OFF
SET IDENTITY_INSERT [dbo].[Languages] ON 

INSERT [dbo].[Languages] ([Id], [Language], [EmployeeId]) VALUES (1, N'ruso', 1)
INSERT [dbo].[Languages] ([Id], [Language], [EmployeeId]) VALUES (2, N'ruso', 2)
INSERT [dbo].[Languages] ([Id], [Language], [EmployeeId]) VALUES (3, N'ruso', 3)
SET IDENTITY_INSERT [dbo].[Languages] OFF
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181219201632_Empleate', N'2.1.4-rtm-31024')
SET IDENTITY_INSERT [dbo].[RequiredLanguages] ON 

INSERT [dbo].[RequiredLanguages] ([Id], [Language], [OfferId]) VALUES (1, N'español', 1)
INSERT [dbo].[RequiredLanguages] ([Id], [Language], [OfferId]) VALUES (2, N'ingles', 1)
INSERT [dbo].[RequiredLanguages] ([Id], [Language], [OfferId]) VALUES (3, N'ingles', 2)
INSERT [dbo].[RequiredLanguages] ([Id], [Language], [OfferId]) VALUES (4, N'español', 3)
INSERT [dbo].[RequiredLanguages] ([Id], [Language], [OfferId]) VALUES (5, N'ingles', 3)
INSERT [dbo].[RequiredLanguages] ([Id], [Language], [OfferId]) VALUES (6, N'español', 4)
INSERT [dbo].[RequiredLanguages] ([Id], [Language], [OfferId]) VALUES (7, N'ingles', 4)
SET IDENTITY_INSERT [dbo].[RequiredLanguages] OFF
SET IDENTITY_INSERT [dbo].[RequiredSkills] ON 

INSERT [dbo].[RequiredSkills] ([Id], [Skill], [OfferId]) VALUES (1, N'liderazgo', 1)
INSERT [dbo].[RequiredSkills] ([Id], [Skill], [OfferId]) VALUES (2, N'liderazgo', 2)
INSERT [dbo].[RequiredSkills] ([Id], [Skill], [OfferId]) VALUES (3, N'java', 2)
INSERT [dbo].[RequiredSkills] ([Id], [Skill], [OfferId]) VALUES (4, N'Tester', 3)
INSERT [dbo].[RequiredSkills] ([Id], [Skill], [OfferId]) VALUES (5, N'Designer', 3)
INSERT [dbo].[RequiredSkills] ([Id], [Skill], [OfferId]) VALUES (6, N'C++ Programer', 4)
INSERT [dbo].[RequiredSkills] ([Id], [Skill], [OfferId]) VALUES (7, N'Angular Programer', 4)
INSERT [dbo].[RequiredSkills] ([Id], [Skill], [OfferId]) VALUES (8, N'java Programer', 4)
SET IDENTITY_INSERT [dbo].[RequiredSkills] OFF

SET IDENTITY_INSERT [dbo].[Postulations] ON 

INSERT [dbo].[Postulations] ([Id], [OfferId], [EmployeeId]) VALUES (1, 1, 1)
INSERT [dbo].[Postulations] ([Id], [OfferId], [EmployeeId]) VALUES (2, 1, 2)
INSERT [dbo].[Postulations] ([Id], [OfferId], [EmployeeId]) VALUES (3, 1, 3)
INSERT [dbo].[Postulations] ([Id], [OfferId], [EmployeeId]) VALUES (4, 2, 3)
INSERT [dbo].[Postulations] ([Id], [OfferId], [EmployeeId]) VALUES (5, 1, 1)
INSERT [dbo].[Postulations] ([Id], [OfferId], [EmployeeId]) VALUES (6, 1, 1)
INSERT [dbo].[Postulations] ([Id], [OfferId], [EmployeeId]) VALUES (1005, 4, 1)
INSERT [dbo].[Postulations] ([Id], [OfferId], [EmployeeId]) VALUES (1006, 3, 1)
SET IDENTITY_INSERT [dbo].[Postulations] OFF