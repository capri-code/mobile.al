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
        public string Description { get; set; }
        public float Price { get; set; }
        public long Mileage { get; set; }
        public string Title { get; set; } //Title
        public string Image { get; set; }
        //public DateOnly? DateProduced { get; set; }
        //public DateOnly? DateAdded { get; set; }
        public bool? Accidented { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public GearBoxCategory GearBoxCategory { get; set; }
        public FuelTypeCategory FuelTypeCategory { get; set; }
        public string Color { get; set; }
        public string Extras { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public CarCategory CarCategory { get; set; }
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? ApplicationUser { get; set; }
    }
}
