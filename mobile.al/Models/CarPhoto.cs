using System.ComponentModel.DataAnnotations.Schema;

namespace mobile.al.Models
{
    public class CarPhoto
    {
        public int Id { get; set; }
        [ForeignKey("Car")]// Foreign key to Car
        public int CarId { get; set; }
        public Car Car { get; set; }
        public string Url { get; internal set; }
    }
}
