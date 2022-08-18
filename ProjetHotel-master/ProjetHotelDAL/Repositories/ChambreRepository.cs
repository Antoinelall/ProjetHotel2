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
    public class ChambreRepository: RepositoryBase<int, ChambreEntity>, IChambreRepository
    {
        public ChambreRepository(Connection connection)
            : base(connection, "Chambre", "IdChambre") 
        { }


        protected override ChambreEntity MapRecordToEntity(IDataRecord record)
        {
            return new ChambreEntity()
            {
                IdChambre = (int)record["IdChambre"],
                Type = (string)record["Type"],
                Prix = (int)record["Prix"],
                IdHotel = (int)record["IdHotel"]
            };
        }

        public override int Insert(ChambreEntity entity)
        {
            Command cmd = new Command("INSERT INTO Chambre (Type, Prix, IdHotel)" +
                " OUTPUT inserted.IdChambre" +
                " VALUES (@Type, @Prix, @IdHotel)");
            cmd.AddParameter("Type", entity.Type);
            cmd.AddParameter("Prix", entity.Prix);
            cmd.AddParameter("IdHotel", entity.IdHotel);

            return (int)_Connection.ExecuteScalar(cmd);
        }

        public override bool Update(int id, ChambreEntity entity)
        {
            Command cmd = new Command($"UPDATE Chambre" +
                " SET Type = @Type," +
                "     Prix = @Prix," +
                "     IdHotel = @IdHotel," +
                $" WHERE IdChambre = @Id");

            cmd.AddParameter("Id", id);
            cmd.AddParameter("Type", entity.Type);
            cmd.AddParameter("Prix", entity.Prix);
            cmd.AddParameter("IdHotel", entity.IdHotel);

            return _Connection.ExecuteNonQuery(cmd) == 1;
        }
    }
}
