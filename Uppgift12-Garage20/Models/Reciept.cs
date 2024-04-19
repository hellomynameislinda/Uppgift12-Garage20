using Uppgift12_Garage20.Helpers;

namespace Uppgift12_Garage20.Models
{
    public class Reciept
    {
        public int ParkedVehicleId { get; set; }
        public string RegistrationNumber { get; set; } = string.Empty;
        public DateTime ArrivalTime { get; set; }

        public TimeSpan TotalParkingTime { get; private set; }
        public decimal TotalCost { get; private set; }

        public Reciept(int parkedVehicleId, string registrationNumber, DateTime arrivalTime)
        {
            ParkedVehicleId = parkedVehicleId;
            RegistrationNumber = registrationNumber;
            ArrivalTime = arrivalTime;

            // TODO: Price per hour should be a setting elsewhere, but with no obvious
            // "home" for it (like a an actual garage object), it will reside here for
            // now.
            decimal pricePerHour = 30.0m;

            TotalParkingTime = HelperFunctions.ParkedTimeAmount(ArrivalTime);
            TotalCost = HelperFunctions.CostCalculation(TotalParkingTime, pricePerHour);
        }
    }
}
