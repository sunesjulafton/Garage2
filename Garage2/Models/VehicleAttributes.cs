using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public enum VehicleAttributes
    {
        [Display(Name = "Registreringsnummer")]
        RegNum,
        [Display(Name ="Fordonstyp")]
        Type,
        [Display(Name ="Märke")]
        Make,
        [Display(Name = "Modell")]
        Model,
        [Display(Name = "Färg")]
        Color,
        [Display(Name = "Ankomsttid")]
        ArrivalTime
    }
}