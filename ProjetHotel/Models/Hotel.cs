using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetHotel.Models
{
    public class Hotel
    {
        [DisplayName("Hotel")]
        [Required]
        public int IdHotel { get; set; }
        [DisplayName("Nom de L'Hotel")]
        [Required]
        public string Nom { get; set; }
        [DisplayName("Nombre de Chambre")]
        [Required]
        public int NBChambre { get; set; }
        [DisplayName("Pays")]
        [Required]
        public string Pays { get; set; }
        [DisplayName("Ville")]
        [Required]
        public string Ville { get; set; }
    }
}
