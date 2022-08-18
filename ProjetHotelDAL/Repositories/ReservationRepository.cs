using ProjetHotelDAL.Entities;
using ProjetHotelDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Connections;

namespace ProjetHotelDAL.Repositories
{
    public class ReservationRepository : RepositoryBase<int, ReservationEntity>, IReservationRepository
    {
        public ReservationRepository(Connection connection)
   : base(connection, "Reservation", "IdReservation") { }


        protected override ReservationEntity MapRecordToEntity(IDataRecord record)
        {
            return new ReservationEntity()
            {
                IdReservation = (int)record["IdReservation"],
                Prix = record["Prix"] is DBNull ? 0 : (float)record["Prix"],
                NBNuit = (int)record["NBNuit"],
                DateArrivee = (DateTime)record["DateArrivee"],
                DateDepart = (DateTime)record["DateDepart"],
                IdChambre = record["IdChambre"] is DBNull ? 0 : (int)record["IdChambre"],
                IdHotel = (int)record["IdHotel"],
                IdClient = (int)record["IdClient"]

            };
        }

        public override int Insert(ReservationEntity entity)
        {
            Command cmd = new Command("INSERT INTO Reservation (Prix, NBNuit, DateArrivee, DateDepart, IdChambre, IdHotel, IdClient)" +
                " OUTPUT inserted.IdReservation" +
                " VALUES (NULL, @NBNuit, @DateArrivee, @DateDepart, NULL, @IdHotel, @IdClient);"
                );
            //cmd.AddParameter("Prix", entity.Prix);
            cmd.AddParameter("NBNuit", entity.NBNuit);
            cmd.AddParameter("DateArrivee", entity.DateArrivee);
            cmd.AddParameter("DateDepart", entity.DateDepart);
            //cmd.AddParameter("IdChambre", entity.IdChambre);
            cmd.AddParameter("IdHotel", entity.IdHotel);
            cmd.AddParameter("IdClient", entity.IdClient);

            return (int)_Connection.ExecuteScalar(cmd);
        }
        public override bool Update(int id, ReservationEntity entity)
        {
            Command cmd = new Command($"UPDATE {TableName} " +
                " SET Prix = @Prix," +
                "     NBNuit = @NBNuit," +
                "     DateArrivee = @DateArrivee" +
                "     DateDepart = @DateDepart" +
                "     IdChambre = @IdChambre" +
                "     IdHotel = @IdHotel" +
                "     IdClient=@IdClient" +
                $" WHERE {TableId} = @Id");

            cmd.AddParameter("IdReservation", id);
            cmd.AddParameter("Prix", entity.Prix);
            cmd.AddParameter("NBNuit", entity.NBNuit);
            cmd.AddParameter("DateArrivee", entity.DateArrivee);
            cmd.AddParameter("DateDepart", entity.DateDepart);
            cmd.AddParameter("IdChambre", entity.IdChambre);
            cmd.AddParameter("IdHotel", entity.IdHotel);
            cmd.AddParameter("IdClient", entity.IdClient);

            return _Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override bool Delete(int id)
        {
            Command cmd = new Command($"DELETE FROM Reservation WHERE IdReservation = @Id");
            cmd.AddParameter("Id", id);

            return _Connection.ExecuteNonQuery(cmd) == 1;
        }


    }
}
