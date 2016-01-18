using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage2.Controllers
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Display(Name = "Fordonstyp")]
        public VehicleTypes Type { get; set; }

        [Display(Name = "Registreringsnummer")]
        public string RegNum { get; set; }

        [Display(Name = "Märke")]
        public string Make { get; set; }

        [Display(Name = "Modell")]
        public string Model { get; set; }

        [Display(Name = "Antal hjul")]
        public int WheelCount { get; set; }
    }
}