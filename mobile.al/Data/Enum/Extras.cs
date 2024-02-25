using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace mobile.al.Data.Enum
{
    public enum Extras
    {
        [Display(Name = "Disabled Accesible")]
        Disabled_Accessible,
        [Display(Name = "Panoramic roof")]
        Panoramic_Roof,
        [Display(Name = "Roof rack")]
        Roof_Rack,
        Taxi
    }
}
