using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage2.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Display(Name = "Fordonstyp")]
        [Required]
        public VehicleTypes Type { get; set; }

        [Display(Name = "Registreringsnummer")]
        [RegularExpression(@"^[A-Z]{3}(\d{3})$")]
        [Required]
        [StringLength(6)]
        public string RegNum { get; set; }

        [Display(Name = "Märke")]
        [StringLength(40)]
        public string Make { get; set; }

        [Display(Name = "Modell")]
        [StringLength(40)]
        public string Model { get; set; }

        [Display(Name = "Färg")]
        [StringLength(40)]
        public string Color { get; set; }

        [Display(Name = "Antal hjul")]
        [Required]
        public int WheelCount { get; set; }

        [Display(Name = "Ankomsttid")]
        public DateTime ArrivalTime { get; set; }
    }
}