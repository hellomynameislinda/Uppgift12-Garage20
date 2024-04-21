using Microsoft.AspNetCore.Mvc;
using Uppgift12_Garage20.Helpers;
using Uppgift12_Garage20.Models;

namespace Uppgift12_Garage20.ViewModels
{
    [ModelMetadataType(typeof(VehicleModelMetaData))]
    public class VehicleSummaryViewModel
    {
        public int ParkedVehicleId { get; init; }
        public string VehicleTypeName { get; init; } = string.Empty;
        public string RegistrationNumber { get; init; } = string.Empty;
        public DateTime ArrivalTime { get; init; }

        public TimeSpan TotalParkingTime =>
            HelperFunctions.ParkedTimeAmount(ArrivalTime);

        // Empty constructor if still needed somewhere in the future
        public VehicleSummaryViewModel() { }

        /// <summary>
        /// Create a view model directly from a ParkedVehicle instance.
        /// </summary>
        /// <param name="vehicle">The ParkedVehicle to view.</param>
        public VehicleSummaryViewModel(ParkedVehicle vehicle)
            {
            ParkedVehicleId = vehicle.ParkedVehicleId;
            VehicleTypeName = vehicle.VehicleType.ToString();
            RegistrationNumber = vehicle.RegistrationNumber;
            ArrivalTime = vehicle.ArrivalTime;
        }
    }
}
