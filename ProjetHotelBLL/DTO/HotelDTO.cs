using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetHotelBLL.DTO
{
    public class HotelDTO
    {
        public int IdHotel { get; set; }
        public string Nom { get; set; }
        public int NBChambre { get; set; }
        public string Pays { get; set; }
        public string Ville { get; set; }
    }
}
