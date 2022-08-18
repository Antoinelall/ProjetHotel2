using ProjetHotelDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetHotelDAL.Interfaces
{
    public interface IClientRepository : IRepository<int, ClientEntity>
    {
        bool CheckMemberExists(string pseudo, string email);
        string GetPasswordHash(string pseudo);
        ClientEntity GetByPseudo(string pseudo);
    }
}
