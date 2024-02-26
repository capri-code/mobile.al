using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Xml.Linq;

namespace mobile.al.Data.Enum
{
    public enum Make
    {
        [Display(Name = "Alfa Romeo")]
        AlfaRomeo,
        [Display(Name = "Aston Martin")]
        AstonMartin,
        Audi,
        Bentley,
        BMW,
        Bugatti,
        Cadillac,
        Chevrolet,
        Citroën,
        Dacia,
        Ferrari,
        Fiat,
        Ford,
        Genesis,
        GMC,
        Honda,
        Hummer,
        Hyundai,
        Isuzu,
        Iveco,
        Jaguar,
        Jeep,
        Kia,
        Lamborghini,
        LandRover,
        Lexus,
        Lincoln,
        Maserati,
        Mazda,
        McLaren,
        [Display(Name = "Mercedes-Benz")]
        MercedesBenz,
        MINI,
        Mitsubishi,
        Nissan,
        Opel,
        Pagani,
        Peugeot,
        Porsche,
        Renault,
        [Display(Name = "Rolls-Royce")]
        RollsRoyce,
        Seat,
        Skoda,
        Smart,
        Suzuki,
        Tesla,
        Toyota,
        Volkswagen,
        Volvo
    }
}
