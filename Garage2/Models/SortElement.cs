using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class SortElement
    {
        public VehicleAttributes Attributes { get; set; }
        public List<bool> Ascending { get; set; }
    }
}