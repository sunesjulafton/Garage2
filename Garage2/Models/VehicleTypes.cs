using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Controllers
{
    public enum VehicleTypes
    {
        [Display(Name = "Flygplan")]
        Aeroplane,

        [Display(Name = "Båt")]
        Boat,

        [Display(Name = "Buss")]
        Bus,

        [Display(Name = "Bil")]
        Car,

        [Display(Name = "Motorcyckel")]
        Motorcycle
    }
}