CREATE TABLE [dbo].[Chambre]
(
	   IdChambre INT IDENTITY,
   Type NVARCHAR(50) NOT NULL,
   Prix DECIMAL(15,2) NOT NULL,
   IdHotel INT NOT NULL,
   PRIMARY KEY(IdChambre),
   FOREIGN KEY(IdHotel) REFERENCES Hotel(IdHotel)

)
