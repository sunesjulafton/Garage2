using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class SearchString
    {
        [Required]
        [RegularExpression (@"^[a-zA-Z]{3}(\d{3})$")]
        public string RegNum { get; set; }
    }
}