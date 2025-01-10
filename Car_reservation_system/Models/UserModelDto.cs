using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Car_reservation_system.Models
{
    public class UserModelDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Email jest wymagany")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Nowe hasło")]
        [MinLength(6, ErrorMessage = "Hasło musi mieć minimalną długość 6 znaków")]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }

        [DisplayName("Potwierdź nowe hasło")]
        [Compare("NewPassword", ErrorMessage = "Hasło i potwierdzenie hasła muszą być takie same.")]
        [DataType(DataType.Password)]
        public string? ConfirmNewPassword { get; set; }

        [DisplayName("Imię")]
        [Required(ErrorMessage = "Pole Imię jest wymagane")]
        public string FirstName { get; set; }

        [DisplayName("Nazwisko")]
        [Required(ErrorMessage = "Pole Nazwisko jest wymagane")]
        public string LastName { get; set; }

        [DisplayName("Numer telefonu")]
        [Phone, MaxLength(9)]
        public string? ContactNumber { get; set; }

        [DisplayName("Miasto")]
        public string? City { get; set; }

        [DisplayName("Ulica")]
        public string? Street { get; set; }

        [DisplayName("Kod pocztowy")]
        public string? PostalCode { get; set; }

        public string Role { get; set; }

        [DisplayName("Wynajęte samochody")]
        public int NumberRentedCars { get; set; }

        public List<CarModelDto>? Cars { get; set; }
    }
}
