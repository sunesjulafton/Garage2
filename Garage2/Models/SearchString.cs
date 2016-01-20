using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class SearchString
    {
        [Display(Name = "Registreringsnummer")]
        [Required (ErrorMessage = "Inmatning saknas")]
        [RegularExpression(@"^[a-zA-Z]{3}(\d{3})$", ErrorMessage = "Felaktigt format. Förväntade AAA999")]
        public string RegNum { get; set; }
    }
}