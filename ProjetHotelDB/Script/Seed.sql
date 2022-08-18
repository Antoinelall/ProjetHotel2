Use [ProjetHotel]
GO

--SET IDENTITY_INSERT [Client] ON;
--GO

--INSERT INTO [Client] ([Pseudo], [Nom], [Prenom], [Email], [MDPHash])
-- VALUES (N'Ant', N'Antoine', N'Lallemand', N'Antoine.lallemand@gmail.com', N'$argon2i$v=19$m=16,t=2,p=1$ZW5qd3U2b1Z2Ym5hM2dCSg$9t0ohGSemxFXIPZXMsGjnQ')
	


--SET IDENTITY_INSERT [Client] OFF;
--GO

SET IDENTITY_INSERT [Hotel] ON;
GO

INSERT INTO [Hotel] ([IdHotel], [Nom], [NBChambre], [Pays], [Ville])
 VALUES (1, N'Hotel Antoine', 6, N'Belgique', N'Bruxelles')
	


SET IDENTITY_INSERT [Hotel] OFF;
GO

SET IDENTITY_INSERT [Chambre] ON;
GO

INSERT INTO [Chambre] ([IdChambre], [Type], [Prix], [IdHotel])
 VALUES (1, N'Double', 50,1),
		(2, N'Double', 50,1),
		(3, N'Double', 50,1),
		(4, N'Quadruple', 80,1),
		(5, N'Quadruple', 80,1),
		(6, N'Quadruple', 80,1)
	
SET IDENTITY_INSERT [Chambre] OFF;
GO
