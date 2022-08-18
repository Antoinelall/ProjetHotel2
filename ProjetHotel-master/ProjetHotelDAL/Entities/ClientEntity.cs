using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetHotelDAL.Entities
{
    public class ClientEntity
    {
        public int IdClient { get; set; }
        public string? Pseudo { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string? Email { get; set; }
        public string? MDPHash { get; set; }
    }
}
