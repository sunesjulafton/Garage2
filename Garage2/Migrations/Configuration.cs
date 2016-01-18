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
            AutomaticMigrationsEnabled = true;
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
                new Vehicle { Type = VehicleTypes.Car, RegNum = "ABC123", Make = "Volvo", Model = "240", Color = "Röd", WheelCount = 4 },
                new Vehicle { Type = VehicleTypes.Aeroplane, RegNum = "FLY234", Make = "Cessna", Model = "172", Color = "Vit", WheelCount = 3 },
                new Vehicle { Type = VehicleTypes.Boat, RegNum = "BOT345", Make = "Scandica", Model = "410", Color = "Vit", WheelCount = 0 },
                new Vehicle { Type = VehicleTypes.Bus, RegNum = "BUS456", Make = "Scania", Model = "Irizar i6", Color = "Grön", WheelCount = 4 },
                new Vehicle { Type = VehicleTypes.Motorcycle, RegNum = "MOT567", Make = "Yamaha", Model = "DT125", Color = "Svart", WheelCount = 2 }
                );
        }
    }
}
