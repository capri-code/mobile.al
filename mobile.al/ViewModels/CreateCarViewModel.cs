using mobile.al.Data.Enum;
using mobile.al.Models;
using System.ComponentModel.DataAnnotations;

namespace mobile.al.ViewModels
{
    public class CreateCarViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required(ErrorMessage = "Duhet vendosur cmimi")]
        [Range(500, double.MaxValue, ErrorMessage = "Cmimi duhet te jete nje vlere pozitive mbi 500€")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Duhet vendosur kilometrazhi")]
        [Range(0, double.MaxValue, ErrorMessage = "Kilometrazhi duhet te jete nje vlere pozitive ose 0")]
        public long Mileage { get; set; }
        [Display(Name = "Photos")]
        [Required(ErrorMessage = "Please upload at least one photo")]
        public List<IFormFile> Images { get; set; }
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "First Registration")]
        [Required(ErrorMessage = "Please enter the first registration date")]
        [DateRange(1980, ErrorMessage = "First registration must be between 1980-01-01 and today's date")]
        public DateTime? FirstRegistration { get; set; }
        public bool? Accidented { get; set; }
        [Required]
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public GearBox GearBoxCategory { get; set; }
        public FuelType FuelTypeCategory { get; set; }
        public string Color { get; set; }
        public Category Category { get; set; }
        public Emission Emission { get; set; }
        public Extras Extras { get; set; }
        public Interior Interior { get; set; }
        public Seller Seller { get; set; }
        public short NrOfOwners { get; set; }
        public Address Address { get; set; }
        public Make Make { get; set; }
        public string AppUserId { get; set; }
    }
}
