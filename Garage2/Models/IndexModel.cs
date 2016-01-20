using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class IndexModel
    {
        public IndexModel(List<Vehicle> v, SortElement s)
        {
            List = v;
            Elements = s;
        }


        public List<Vehicle> List { get; set; }
        public SortElement Elements { get; set; }
    }
}