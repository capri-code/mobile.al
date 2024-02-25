using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace mobile.al.Data.Enum
{
    public enum Seller
    {
        [Display(Name = "Company Vehicles")]
        Company_Vehicles,
        Dealer,
        [Display(Name = "Private Seller")]
        Private_Seller
    }
}
