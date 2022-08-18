CREATE TABLE [dbo].[Reservation]
(
	IdReservation INT IDENTITY,
   Prix DECIMAL(15,2) NULL,
   [NBNuit] INT NOT NULL,
   DateArrivee DATE NOT NULL,
   DateDepart DATE NOT NULL,
   IdChambre INT NULL,
   IdHotel INT NOT NULL,
   [IdClient] INT NOT NULL, 
    PRIMARY KEY(IdReservation),
   FOREIGN KEY(IdChambre) REFERENCES Chambre(IdChambre),
   FOREIGN KEY(IdHotel) REFERENCES Hotel(IdHotel),
   FOREIGN KEY(IdClient) REFERENCES Client(IdClient)

)
