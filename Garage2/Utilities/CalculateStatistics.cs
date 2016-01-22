using Garage2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Utilities
{
    public class CalculateStatistics
    {
        public static IDictionary CountTypesInDb(ICollection col)
        {
            var model = col;
            Dictionary<VehicleTypes, int> types = new Dictionary<VehicleTypes, int>();

            foreach (Vehicle v in model)
            {
                if (types.ContainsKey(v.Type))
                {
                    types[v.Type] += 1;
                }
                else
                {
                    types.Add(v.Type, 1);
                }
            }
            GetTypesWithZeroValue(types);
            return types;
        }

        //Add vehicletypes that aint in the database and adds 0 as value
        public static void GetTypesWithZeroValue(Dictionary<VehicleTypes, int> types)
        {
            var values = GetValues<VehicleTypes>();
            foreach (VehicleTypes vt in values)
            {
                if (!types.ContainsKey(vt))
                {
                    types.Add(vt, 0);
                }
            }
        }

        //Helper-method to get enums
        public static IReadOnlyList<T> GetValues<T>()
        {
            return (T[])Enum.GetValues(typeof(T));
        }

        public static int CountTiresInDb(ICollection col)
        {
            var model = col;
            int tires = 0;
            foreach (Vehicle v in model)
            {
                tires += v.WheelCount;
            }

            return tires;
        }

        public static IDictionary CountColorOfTypesInDb(ICollection col)
        {
            var model = col;
            Dictionary<string, int> colors = new Dictionary<string, int>();

            foreach (Vehicle v in model)
            {
                if (colors.ContainsKey(v.Color))
                {
                    colors[v.Color] += 1;
                }
                else
                {
                    colors.Add(v.Color, 1);
                }
            }
            return colors;
        }

        public static IDictionary CountMakeInDb(ICollection col)
        {
            var model = col;
            Dictionary<string, int> makes = new Dictionary<string, int>();

            foreach (Vehicle v in model)
            {
                if (makes.ContainsKey(v.Make))
                {
                    makes[v.Make] += 1;
                }
                else
                {
                    makes.Add(v.Make, 1);
                }
            }
            return makes;
        }
    }
}