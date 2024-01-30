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
        public float Price { get; set; }
        public long Mileage { get; set; }
        public Category Category { get; set; }
        public Emission Emission { get; set; }
        public Extras Extras { get; set; }
        public Interior Interior { get; set; }
        public Seller Seller { get; set; }
        public string Image { get; set; }
        //public bool IsAvailable { get; set; }
        //public bool IsDeleted { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime? UpdatedAt { get; set; }
        //public DateTime FirstRegistration { get; set; }
        public bool? Accidented { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public GearBox GearBoxCategory { get; set; }
        public FuelType FuelTypeCategory { get; set; }
        public string Color { get; set; }
        public Make Make { get; set; }
        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
