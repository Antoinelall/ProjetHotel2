﻿CREATE TABLE [dbo].[Hotel]
(
	IdHotel INT IDENTITY,
   Nom NVARCHAR(50) NOT NULL,
   NBChambre INT NOT NULL,
   [Pays] NVARCHAR(50) NOT NULL, 
    [Ville] NVARCHAR(50) NOT NULL, 
    PRIMARY KEY(IdHotel)

)
