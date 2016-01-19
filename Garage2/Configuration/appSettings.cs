using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Configuration
{
    public class appSettings
    {
        public static int PricePerMinute()
        {
            string _price = System.Web.Configuration.WebConfigurationManager.AppSettings["pricePerMinute"];
            if (_price != null)
            {
                return Convert.ToInt32(_price);
            }
            //Default parking price per minute
            return 1;
        }
    }
}

