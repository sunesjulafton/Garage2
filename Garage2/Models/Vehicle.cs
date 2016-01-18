using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Controllers
{
    public class Vehicle
    {
        public int Id { get; set; }
        public VehicleTypes Type { get; set; }
        public string RegNum { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int WheelCount { get; set; }
    }
}