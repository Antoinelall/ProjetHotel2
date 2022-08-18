using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetHotelBLL.DTO
{
    public class ChambreDTO
    {
        public int IdChambre { get; set; }
        public string Type { get; set; }
        public float Prix { get; set; }
        public int IdHotel { get; set; }
    }
}
