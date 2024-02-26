using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;
using mobile.al.Data.Enum;

namespace mobile.al.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Duhet vendosur cmimi")]
        [Range(0, double.MaxValue, ErrorMessage = "Cmimi duhet te jete nje vlere pozitive ose 0")]
        public double Price { get; set; }
        public long Mileage { get; set; }
        public Category Category { get; set; }
        public Emission Emission { get; set; }
        public Extras Extras { get; set; }
        public Interior Interior { get; set; }
        public Seller Seller { get; set; }
        public List<CarPhoto> Photos { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? FirstRegistration { get; set; }
        public Accidented? Accidented { get; set; }
        [Required]
        public string? Model { get; set; }
        public int HorsePower { get; set; }
        public GearBox GearBoxCategory { get; set; }
        public FuelType FuelTypeCategory { get; set; }
        public string Color { get; set; }
        public Make Make { get; set; }
        public short NrOfOwners { get; set; }
        public string? PhoneNumber { get; set; }
        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
