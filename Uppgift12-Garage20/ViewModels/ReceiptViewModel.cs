using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Uppgift12_Garage20.Helpers;
using Uppgift12_Garage20.Models;

namespace Uppgift12_Garage20.ViewModels
{
    [ModelMetadataType(typeof(VehicleModelMetaData))]
    public class ReceiptViewModel
    {
        public int ParkedVehicleId { get; init; }
        public string RegistrationNumber { get; init; } = string.Empty;
        public DateTime ArrivalTime { get; init; }
        public DateTime DepartureTime { get; init; }
        public TimeSpan TotalParkingTime { get; init; }
        public decimal TotalCost { get; init; }

        public ReceiptViewModel() { }  // Empty constructor required by MVC

        public ReceiptViewModel(ParkedVehicle vehicle, DateTime departureTime, decimal pricePerHour)
        {
            ParkedVehicleId = vehicle.ParkedVehicleId;
            RegistrationNumber = vehicle.RegistrationNumber;
            ArrivalTime = vehicle.ArrivalTime;
            DepartureTime = departureTime;

            TotalParkingTime = HelperFunctions.ParkedTimeAmount(ArrivalTime, DepartureTime);
            TotalCost = HelperFunctions.CostCalculation(TotalParkingTime, pricePerHour);
        }

        public ReceiptViewModel(
            int parkedVehicleId,
            string registrationNumber,
            DateTime arrivalTime,
            DateTime departureTime,
            decimal pricePerHour)
        {
            ParkedVehicleId = parkedVehicleId;
            RegistrationNumber = registrationNumber;
            ArrivalTime = arrivalTime;
            DepartureTime = departureTime;

            TotalParkingTime = HelperFunctions.ParkedTimeAmount(ArrivalTime);
            TotalCost = HelperFunctions.CostCalculation(TotalParkingTime, pricePerHour);
        }
    }
}
