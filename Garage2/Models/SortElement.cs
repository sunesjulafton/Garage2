using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class SortElement
    {
        public SortElement()
        {
            Attributes = VehicleAttributes.RegNum;
            Ascending = new List<bool>() { true, true, true, true, true, true };
        }

        public SortElement(VehicleAttributes attr, List<bool> values)
        {
            Attributes = attr;
            Ascending = values;
        }
        public VehicleAttributes Attributes { get; set; }
        public List<bool> Ascending { get; set; }
    }
}