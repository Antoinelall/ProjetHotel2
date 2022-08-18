using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetHotelDAL.Entities
{
    public class ChambreEntity
    {
        public int IdChambre { get; set; }
        public string Type { get; set; }
        public float Prix { get; set; }
        public int IdHotel { get; set; }

    }
}
