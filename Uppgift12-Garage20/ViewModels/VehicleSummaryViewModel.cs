using Uppgift12_Garage20.Helpers;
using Uppgift12_Garage20.Models;

namespace Uppgift12_Garage20.ViewModels
{
    public class VehicleSummaryViewModel
    {
        public int ParkedVehicleId { get; init; }
        /* Currently using the integer VehicleType.
         * This should be replaced with the string from the enum.
         */
        public int VehicleType { get; init; }
        //public string VehicleTypeName { get; init; } = string.Empty;
        public string RegistrationNumber { get; init; } = string.Empty;
        public DateTime ArrivalTime { get; init; }

        public TimeSpan ParkedTimeAmount =>
            HelperFunctions.ParkedTimeAmount(ArrivalTime);

        /// <summary>
        /// Create a view model directly from a ParkedVehicle instance.
        /// </summary>
        /// <param name="vehicle">The ParkedVehicle to view.</param>
        /// <returns>
        /// A VehicleSummaryViewModel of the vehicle. This exposes the
        /// VehicleType, RegistrationNumber, and ArrivalTime. It also exposes
        /// the ParkedTimeAmount as a property.
        /// </returns>
        public static VehicleSummaryViewModel FromParkedVehicle(ParkedVehicle vehicle)
            => new()
            {
                ParkedVehicleId = vehicle.ParkedVehicleId,
                VehicleType = vehicle.VehicleType,
                RegistrationNumber = vehicle.RegistrationNumber,
                ArrivalTime = vehicle.ArrivalTime
            };
    }
}
