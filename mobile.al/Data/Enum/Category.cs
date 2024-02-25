using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace mobile.al.Data.Enum
{
    public enum Category
    {
        [Display(Name = "Cabriolet / Roadster")]
        Cabriolet,
        [Display(Name = "Estate Car")]
        Estate,
        Saloon,
        [Display(Name = "Small Car")]
        Small,
        [Display(Name = "Sports Car / Coupe")]
        Coupe,
        [Display(Name = "SUV / Off-Road Vehicle / Pickup Truck")]
        SUV,
        [Display(Name = "Van / Minibus")]
        Van,
        Other
    }
}
