using mobile.al.Data.Enum;
using mobile.al.Models;

namespace mobile.al.ViewModels
{
    public class CreateCarViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public long Mileage { get; set; }
        public IFormFile Image { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime DateProduced { get; set; }
        //public DateTime DateAdded { get; set; }
        public bool? Accidented { get; set; }
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
        public Address Address { get; set; }
        public Make Make { get; set; }
        public string AppUserId { get; set; }
    }
}
