using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace mobile.al.ViewModels
{
    public class EditProfileViewModel
    {
        public string? FullName { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\+355\s[0-9]{2}\s[0-9]{3}\s[0-9]{4}$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNumber { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public IFormFile? Image { get; set; }
    }
}
