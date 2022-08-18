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
    public class HotelRepository : RepositoryBase<int, HotelEntity>, IHotelRepository
    {
        public HotelRepository(Connection connection)
    : base(connection, "Hotel", "IdHotel") { }


        protected override HotelEntity MapRecordToEntity(IDataRecord record)
        {
            return new HotelEntity()
            {
                IdHotel = (int)record["IdHotel"],
                Nom = (string)record["Nom"],
                NBChambre = (int)record["NBChambre"],
                Pays = (string)record["Pays"],
                Ville = (string)record["Ville"]
            };
        }

        public override int Insert(HotelEntity entity)
        {
            Command cmd = new Command("INSERT INTO Hotel (Nom, NBChambre, Pays, Ville)" +
                " OUTPUT inserted.IdHotel" +
                " VALUES (@Nom, @NBChambre, @Pays, @Ville)");
            cmd.AddParameter("Nom", entity.Nom);
            cmd.AddParameter("NBChambre", entity.NBChambre);
            cmd.AddParameter("Pays", entity.Pays);
            cmd.AddParameter("Ville", entity.Ville);

            return (int)_Connection.ExecuteScalar(cmd);
        }

        public override bool Update(int id, HotelEntity entity)
        {
            Command cmd = new Command($"UPDATE Hotel" +
                " SET Nom = @Nom," +
                "     NBChambre = @NBChambre," +
                "     Pays = @Pays," +
                "     Ville = @Ville," +
                $" WHERE IDHotel = @Id");

            cmd.AddParameter("Id", id);
            cmd.AddParameter("Nom", entity.Nom);
            cmd.AddParameter("NBChambre", entity.NBChambre);
            cmd.AddParameter("Pays", entity.Pays);
            cmd.AddParameter("Ville", entity.Ville);

            return _Connection.ExecuteNonQuery(cmd) == 1;
        }
    }
}
