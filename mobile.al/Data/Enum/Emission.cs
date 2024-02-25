using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace mobile.al.Data.Enum
{
    public enum Emission
    {
        [Display(Name = "Euro 1")]
        Euro1,
        [Display(Name = "Euro 2")]
        Euro2,
        [Display(Name = "Euro 3")]
        Euro3,
        [Display(Name = "Euro 4")]
        Euro4,
        [Display(Name = "Euro 5")]
        Euro5,
        [Display(Name = "Euro 6")]
        Euro6,
        [Display(Name = "Euro 6c")]
        Euro6c,
        [Display(Name = "Euro 6d")]
        Euro6d,
        [Display(Name = "Euro 6d-TEMP")]
        Euro6d_temp
    }
}
