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
        public DateOnly? DateProduced { get; set; }
        public DateOnly? DateAdded { get; set; }
        public bool? Accidented { get; set; }
        public string Model { get; set; }
        public string HorsePower { get; set; }
		public GearBoxCategory GearBoxCategory { get; set; }
		public FuelTypeCategory FuelTypeCategory { get; set; }
        public string Color { get; set; }
        public string Extras { get; set; }
        public string Title { get; set; }
        public Address Address { get; set; }
        public CarCategory CarCategory { get; set; }
        public string AppUserId { get; set; }
    }
}
