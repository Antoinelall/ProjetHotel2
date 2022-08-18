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
    public class ClientRepository : RepositoryBase<int, ClientEntity>, IClientRepository
    {
        public ClientRepository(Connection connection)
             : base(connection, "Client", "IdClient")
        { }

        protected override ClientEntity MapRecordToEntity(IDataRecord record)
        {
            return new ClientEntity()
            {
                IdClient = (int)record[TableId],
                Pseudo = (string)record["Pseudo"],
                Nom = record["Nom"] is DBNull ? null : record["Nom"].ToString(),
                Prenom = record["Prenom"] is DBNull ? null : record["Prenom"].ToString(),
                Email = (string)record["Email"],
                MDPHash = null,
            };
        }

        public override int Insert(ClientEntity entity)
        {
            Command cmd = new Command($"INSERT INTO {TableName} (Pseudo, Nom, Prenom, Email, MDPHash)" +
                $" OUTPUT inserted.{TableId}" +
                $" VALUES (@Pseudo, @Nom, @Prenom, @Email, @MDPHash)");

            cmd.AddParameter("Pseudo", entity.Pseudo);
            cmd.AddParameter("Nom", entity.Nom);
            cmd.AddParameter("Prenom", entity.Prenom);
            cmd.AddParameter("Email", entity.Email);
            cmd.AddParameter("MDPHash", entity.MDPHash);

            return (int)_Connection.ExecuteScalar(cmd);
        }

        public override bool Update(int id, ClientEntity entity)
        {
            // TODO Implementer la mise a jour du Client
            throw new NotImplementedException();            
        }

        public string? GetPasswordHash(string pseudo)
        {
            Command cmd = new Command($"SELECT MDPHash FROM {TableName} WHERE Pseudo = @Pseudo");
            cmd.AddParameter("Pseudo", pseudo);

            return _Connection.ExecuteScalar(cmd)?.ToString();
        }

        public bool CheckMemberExists(string pseudo, string email)
        {
            Command cmd = new Command($"SELECT COUNT(*) FROM {TableName} WHERE Pseudo = @Pseudo OR Email = @Email");
            cmd.AddParameter("Pseudo", pseudo);
            cmd.AddParameter("Email", email);

            return ((int)_Connection.ExecuteScalar(cmd)) == 1;
        }

        public virtual ClientEntity GetByPseudo(string pseudo)
        {
            Command cmd = new Command($"SELECT * FROM {TableName} WHERE Pseudo = @Pseudo");
            cmd.AddParameter("Pseudo", pseudo);

            return _Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();
        }
    }
}
