
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetHotel.Models
{
    public class Client
    {
        public int IdClient { get; set; }

        [DisplayName("Pseudo")]
        public string Pseudo { get; set; }

        [DisplayName("Nom")]
        public string? Nom { get; set; }

        [DisplayName("Prénom")]
        public string? Prenom { get; set; }

        [DisplayName("E-Mail")]
        public string Email { get; set; }

    }

    public class ClientRegister
    {
        [DisplayName("Pseudo")]
        [Required]
        public string Pseudo { get; set; }

        [DisplayName("E-Mail")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Mot de passe")]
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$")]
        // Regle de la regex => Le mot de passe doit faire 8 caracteres, une miniscule, une majuscule et un chiffre
        public string Password { get; set; }

        [DisplayName("Confirmation")]
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string PasswordConfirm { get; set; }
    }

    public class ClientLogin
    {
        [DisplayName("Pseudo")]
        [Required]
        public string Pseudo { get; set; }

        [DisplayName("Mot de passe")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
