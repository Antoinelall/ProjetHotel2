using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetHotel.Models
{
    public class Reservation
    {
        [DisplayName("Numéro de réservation")]
        [Required]
        public int IdReservation { get; set; }
        [DisplayName("Prix")]
        [Required]
        public float Prix { get; set; }
        [DisplayName("Nombre de nuit")]
        [Required]
        public int NBNuit { get; set; }
        [DisplayName("Date d'arrivée")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateArrivee { get; set; }
        [DisplayName("Date de départ")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateDepart { get; set; }
        [DisplayName("Numéro de la chambre")]
        [Required]
        public int IdChambre { get; set; }
        [DisplayName("Hotel")]
        [Required]
        public int IdHotel { get; set; }
        [DisplayName("Client")]
        [Required]
        public int IdClient { get; set; }

    }

    public class ReservationForm
    {
        [DisplayName("Type de chambre")]
        [Required]
        public TypeCh Type { get; set; }


        [DisplayName("Date d'arrivée")]
        [Required]

        public DateTime DateArrivee { get; set; }
        [DisplayName("Date de départ")]
        [Required]

        public DateTime DateDepart { get; set; }
        public int IdHotel { get; set; }
        public int IdClient { get; set; }

    }
}
