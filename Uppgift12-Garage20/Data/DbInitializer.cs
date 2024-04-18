using Uppgift12_Garage20.Models;

namespace Uppgift12_Garage20.Data
{
    public static class DbInitializer
    {
        // Representative examples of vehicles that may be parked in the garage
        private static ParkedVehicle[] SeedVehicles => [
            new ParkedVehicle { VehicleType = VehicleType.Car, RegistrationNumber = "ABC123", Color = "Beige", Make = "Toyota"       , Model = "Corolla", NumberOfWheels =  4, ArrivalTime = new DateTime(2024, 04, 17, 08, 30, 00) },
            new ParkedVehicle { VehicleType = VehicleType.Car, RegistrationNumber = "DEF456", Color = "Gray" , Make = "Volvo"        , Model = "EC40"   , NumberOfWheels =  4, ArrivalTime = new DateTime(2024, 04, 17, 09, 15, 00) },
            new ParkedVehicle { VehicleType = VehicleType.Motorcycle, RegistrationNumber = "XYZ098", Color = "Blue" , Make = "Yamaha"       , Model = "R7"     , NumberOfWheels =  2, ArrivalTime = new DateTime(2024, 04, 17, 09, 30, 00) },
            new ParkedVehicle { VehicleType = VehicleType.Car, RegistrationNumber = "YYZ000", Color = "Red"  , Make = "Tesla"        , Model = "Model Y", NumberOfWheels =  4, ArrivalTime = new DateTime(2024, 04, 17, 09, 45, 00) },
            new ParkedVehicle { VehicleType = VehicleType.Truck, RegistrationNumber = "TUV765", Color = "White", Make = "Mercedes-Benz", Model = "Econic" , NumberOfWheels = 10, ArrivalTime = new DateTime(2024, 04, 17, 10, 00, 00) },
        ];

        // Based on the Pluralsight course (ASP.Net Core 6 Fundamentals)
        public static void Seed(IApplicationBuilder app)
        {
            GarageContext context = app.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<GarageContext>();

            // This will initialize the database only when empty
            // In the future we might want to include a more explicit reset mechanism
            if (!context.ParkedVehicle.Any())
            {
                context.AddRange(SeedVehicles);
            }
            context.SaveChanges();
        }

    }
}
