using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetHotel.Models
{
    public enum TypeCh
    {
        [Display(Name = "2 Personnes")]
        Double, 
        [Display(Name = "4 Personnes")]
        Quadruple
    }
    public class Chambre
    {
        [DisplayName("Numéro de la chambreMail")]
        [Required]
        public int IdChambre { get; set; }
        [DisplayName("Type de chambre")]
        [Required]
        public TypeCh Type { get; set; }
        [DisplayName("Prix")]
        [Required]
        public float Prix { get; set; }
        public int IdHotel { get; set; }
    }

    //public class ChambreForm
    //{
    //    [DisplayName("Numéro de la chambre")]
    //    [Required]
    //    public int IdChambre { get; set; }
    //    [DisplayName("Type de chambre")]
    //    [Required]
    //    public string Type { get; set; }
    //    [DisplayName("Prix")]
    //    [Required]
    //    public float Prix { get; set; }
    //    public int IdHotel { get; set; }
    //}
}
