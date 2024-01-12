using System.ComponentModel.DataAnnotations;

namespace mobile.al.Models
{
    public class Country
    {
        [Key]
        [Required]
        public new int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public new string Name { get; set; }
    }
}
