using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace mobile.al.Models
{
    public class AppUser : IdentityUser
    {
        [Display(Name = "Full name")]
        public string? FullName { get; set; }
		public string? ProfileImageUrl { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		[ForeignKey("Address")]
		public int? AddressId { get; set; }
		public Address? Address { get; set; }
		public ICollection<Car> Cars { get; set; }
	}
}
