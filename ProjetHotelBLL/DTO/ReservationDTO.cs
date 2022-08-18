using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetHotelBLL.DTO
{
    public class ReservationDTO
    {
        public int IdReservation { get; set; }
        public float Prix { get; set; }
        public int NBNuit { get; set; }
        public DateTime DateArrivee { get; set; }
        public DateTime DateDepart { get; set; }
        public int IdChambre { get; set; }
        public int IdHotel { get; set; }
        public int IdClient { get; set; }

    }
}
