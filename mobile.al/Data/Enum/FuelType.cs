using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace mobile.al.Data.Enum
{
    public enum FuelType
	{
        Diesel,
        Electric,
        [Display(Name = "Ethanol(FFV,E85,etc.)")]
        Ethanol,
        [Display(Name = "Hybrid(diesel / electric)")]
        HybridDiesel,
        [Display(Name = "Hybrid(petrol / electric)")]
        HybridPetrol,
        Hydrogen,
        LPG,
        [Display(Name = "Natural Gas")]
        NaturalGas,
        Petrol,
    }
}
