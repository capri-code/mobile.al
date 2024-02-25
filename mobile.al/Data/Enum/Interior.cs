using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace mobile.al.Data.Enum
{
    public enum Interior
    {
        Alcantara,
        Cloth,
        [Display(Name = "Full leather")]
        Full_Leather,
        Other,
        [Display(Name = "Part leather")]
        Part_Leather,
        Velour
    }
}
