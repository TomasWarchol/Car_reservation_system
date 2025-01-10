using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Car_reservation_system.Models
{
    public class CarModelDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategoria jest wymagana")]
        [Display(Name = "Kategoria")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Marka jest wymagana")]
        [Display(Name = "Marka")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Model jest wymagany")]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Pojemność silnika jest wymagana")]
        [Display(Name = "Pojemność silnika")]
        public decimal? Engine { get; set; }

        [Required(ErrorMessage = "Konie mechaniczne są wymagane")]
        [Display(Name = "Konie mechaniczne")]
        public int? Horsepower { get; set; }

        [Required(ErrorMessage = "Rocznik jest wymagany")]
        [Display(Name = "Rocznik")]
        [Range(1886, 2025)]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Ilość siedzień jest wymagana")]
        [Display(Name = "Ilość siedzień")]
        public int? Seats { get; set; }

        [Required(ErrorMessage = "Ilość drzwi jest wymagana")]
        [Display(Name = "Ilość drzwi")]
        public int? Doors { get; set; }

        [Required(ErrorMessage = "Pojemność paliwa jest wymagana")]
        [Display(Name = "Paliwo")]
        public string? Fuel { get; set; }

        [Required(ErrorMessage = "Transmisja jest wymagana")]
        [Display(Name = "Skrzynia biegów")]
        public string? Transmission { get; set; }

        [DisplayName("Opis:")]
        public string? Description { get; set; }

        [Display(Name = "Dostępność")]
        public bool Available { get; set; }

        [Required(ErrorMessage = "Zdjęcie jest wymagane")]
        [DisplayName("Zdjęcie:")]
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}