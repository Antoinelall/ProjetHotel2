CREATE TABLE [dbo].[StatutEtat]
(
	   IdChambre INT,
   IdEtat INT,
   DateDeChangement DATE,
   PRIMARY KEY(IdChambre, IdEtat),
   FOREIGN KEY(IdChambre) REFERENCES Chambre(IdChambre),
   FOREIGN KEY(IdEtat) REFERENCES Etat(IdEtat)

)
