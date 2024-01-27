using mobile.al.Data.Enum;
using mobile.al.Models;

namespace mobile.al.ViewModels
{
    public class EditCarViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
		public long Mileage { get; set; }
		public IFormFile Image { get; set; }
        //public DateTime DateProduced { get; set; }
        //public DateTime DateAdded { get; set; }
        public bool? Accidented { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public GearBoxCategory GearBoxCategory { get; set; }
        public FuelTypeCategory FuelTypeCategory { get; set; }
        public string Color { get; set; }
        public string Extras { get; set; }
        public string Title { get; set; }
        public string? URL { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public CarCategory CarCategory { get; set; }
    }
}
