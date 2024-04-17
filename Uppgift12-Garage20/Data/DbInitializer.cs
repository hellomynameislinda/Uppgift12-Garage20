using Uppgift12_Garage20.Models;

namespace Uppgift12_Garage20.Data
{
    public static class DbInitializer
    {
        // This variable lays out the VehicleType names until the enum is created
        private static Dictionary<int, string> VehicleTypeNames => new()
        {
            { 0, "Car" },
            { 1, "Motorcycle" },
            { 2, "Truck" },
        };
        // Representative examples of vehicles that may be parked in the garage
        private static ParkedVehicle[] SeedVehicles => [
            new ParkedVehicle { VehicleType = 0, RegistrationNumber = "ABC123", Color = "Beige", Make = "Toyota"       , Model = "Corolla", NumberOfWheels =  4, ArrivalTime = new DateTime(2024, 04, 17, 08, 30, 00) },
            new ParkedVehicle { VehicleType = 0, RegistrationNumber = "DEF456", Color = "Gray" , Make = "Volvo"        , Model = "EC40"   , NumberOfWheels =  4, ArrivalTime = new DateTime(2024, 04, 17, 09, 15, 00) },
            new ParkedVehicle { VehicleType = 1, RegistrationNumber = "XYZ098", Color = "Blue" , Make = "Yamaha"       , Model = "R7"     , NumberOfWheels =  2, ArrivalTime = new DateTime(2024, 04, 17, 09, 30, 00) },
            new ParkedVehicle { VehicleType = 0, RegistrationNumber = "YYZ000", Color = "Red"  , Make = "Tesla"        , Model = "Model Y", NumberOfWheels =  4, ArrivalTime = new DateTime(2024, 04, 17, 09, 45, 00) },
            new ParkedVehicle { VehicleType = 2, RegistrationNumber = "TUV765", Color = "White", Make = "Mercedes-Benz", Model = "Econic" , NumberOfWheels = 10, ArrivalTime = new DateTime(2024, 04, 17, 10, 00, 00) },
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
