namespace Garage2.Migrations
{
    using Garage2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage2.Models.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Garage2.Models.GarageContext";
        }

        protected override void Seed(Garage2.Models.GarageContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Vehicles.AddOrUpdate(
                v => v.RegNum,
                /* v => new { v.RegNum, v.Color, v.ArrivalTime }, */
                new Vehicle { Type = VehicleTypes.Car, RegNum = "ABC123", Make = "Volvo", Model = "240", Color = "Röd", WheelCount = 4, ArrivalTime = new DateTime(2016, 1, 19, 9, 38, 0) },
                new Vehicle { Type = VehicleTypes.Aeroplane, RegNum = "FLY234", Make = "Cessna", Model = "172", Color = "Vit", WheelCount = 3, ArrivalTime = new DateTime(2016, 1, 18, 17, 12, 0) },
                new Vehicle { Type = VehicleTypes.Boat, RegNum = "BOT345", Make = "Scandica", Model = "410", Color = "Vit", WheelCount = 0, ArrivalTime = new DateTime(2015, 9, 22, 12, 42, 0) },
                new Vehicle { Type = VehicleTypes.Bus, RegNum = "BUS456", Make = "Scania", Model = "Irizar i6", Color = "Grön", WheelCount = 4, ArrivalTime = new DateTime(2016, 1, 18, 22, 0, 0) },
                new Vehicle { Type = VehicleTypes.Motorcycle, RegNum = "MOT567", Make = "Yamaha", Model = "DT125", Color = "Svart", WheelCount = 2, ArrivalTime = new DateTime(2015, 8, 30, 19, 37, 0) },
                new Vehicle { Type = VehicleTypes.Car, RegNum = "BCD678", Make = "VW", Model = "Passat", Color = "Blå", WheelCount = 4, ArrivalTime = new DateTime(2016, 1, 18, 7, 30, 0) },
                new Vehicle { Type = VehicleTypes.Aeroplane, RegNum = "GMZ789", Make = "Boeing", Model = "747", Color = "Vit", WheelCount = 10, ArrivalTime = new DateTime(2016, 1, 7, 6, 54, 0) },
                new Vehicle { Type = VehicleTypes.Boat, RegNum = "CPU891", Make = "Nimbus", Model = "2700", Color = "Vit", WheelCount = 0, ArrivalTime = new DateTime(2015, 9, 19, 13, 31, 0) },
                new Vehicle { Type = VehicleTypes.Bus, RegNum = "CVT921", Make = "Neoplan", Model = "Jetliner", Color = "Grå", WheelCount = 6, ArrivalTime = new DateTime(2015, 12, 23, 17, 15, 0) },
                new Vehicle { Type = VehicleTypes.Motorcycle, RegNum = "NPU132", Make = "Suzuki", Model = "GSXR600", Color = "Silver", WheelCount = 2, ArrivalTime = new DateTime(2015, 8, 3, 8, 2, 0) },
                new Vehicle { Type = VehicleTypes.Car, RegNum = "CDE243", Make = "Audi", Model = "A8", Color = "Svart", WheelCount = 4, ArrivalTime = new DateTime(2016, 1, 18, 7, 30, 0) },
                new Vehicle { Type = VehicleTypes.Aeroplane, RegNum = "HNA354", Make = "Airbus", Model = "A380", Color = "Vit", WheelCount = 10, ArrivalTime = new DateTime(2016, 1, 7, 6, 54, 0) },
                new Vehicle { Type = VehicleTypes.Boat, RegNum = "DRV465", Make = "Olympic", Model = "450 CC", Color = "Vit", WheelCount = 0, ArrivalTime = new DateTime(2015, 9, 19, 13, 31, 0) },
                new Vehicle { Type = VehicleTypes.Bus, RegNum = "DXU576", Make = "Neoplan", Model = "Jetliner", Color = "Grå", WheelCount = 6, ArrivalTime = new DateTime(2015, 12, 23, 17, 15, 0) },
                new Vehicle { Type = VehicleTypes.Motorcycle, RegNum = "ORV687", Make = "Harley Davidson", Model = "Iron 883", Color = "Svart", WheelCount = 2, ArrivalTime = new DateTime(2015, 8, 3, 8, 2, 0) }
                );
        }
    }
}
