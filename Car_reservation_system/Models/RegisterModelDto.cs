using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Car_reservation_system.Models
{
    public class RegisterModelDto 
    {
        [Required(ErrorMessage = "Email jest wymagany")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Imię")]
        [Required(ErrorMessage = "Imię jest wymagane")]
        public string FirstName { get; set; }

        [DisplayName("Nazwisko")]
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [MinLength(6, ErrorMessage = "Hasło musi składać się z co najmniej 6 znaków")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Powtórz hasło")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Podane hasła nie są identyczne.")]
        public string ConfirmPassword { get; set; }

        public int RoleId { get; set; } = 1;
    }
}
