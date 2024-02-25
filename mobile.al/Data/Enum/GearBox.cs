using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace mobile.al.Data.Enum
{
    public enum GearBox
	{
        Automatic,
        Manual,
        [Display(Name = "Semi-Automatic")]
        SemiAutomatic
    }
}
