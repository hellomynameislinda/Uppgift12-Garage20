using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Uppgift12_Garage20.Helpers;
using Uppgift12_Garage20.Models;

namespace Uppgift12_Garage20.ViewModels
{
    [ModelMetadataType(typeof(VehicleModelMetaData))]
    public class ParkingEndedViewModel
    {
        public string RegistrationNumber { get; init; } = string.Empty;
        public string Color { get; init; } = string.Empty;
        public string Make { get; init; } = string.Empty;
        public string Model { get; init; } = string.Empty;
        public int NumberOfWheels { get; init; }
        public DateTime ArrivalTime { get; init; }
        public DateTime DepartureTime { get; init; }
        public TimeSpan TotalParkingTime { get; init; }
        public decimal TotalCost { get; init; }

        public ParkingEndedViewModel() { }  // Empty constructor required by MVC

        public ParkingEndedViewModel(ParkedVehicle vehicle, DateTime departureTime, decimal pricePerHour)
        {
            RegistrationNumber = vehicle.RegistrationNumber;
            Color = vehicle.Color;
            Make = vehicle.Make;
            Model = vehicle.Model;
            NumberOfWheels = vehicle.NumberOfWheels;
            ArrivalTime = vehicle.ArrivalTime;
            DepartureTime = departureTime;

            TotalParkingTime = HelperFunctions.ParkedTimeAmount(ArrivalTime, DepartureTime);
            TotalCost = HelperFunctions.CostCalculation(TotalParkingTime, pricePerHour);
        }

        public ParkingEndedViewModel(
            string registrationNumber,
            string color,
            string make,
            string model,
            int numberOfWheels,
            DateTime arrivalTime,
            DateTime departureTime,
            decimal pricePerHour)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            Make = make;
            Model = model;
            NumberOfWheels = numberOfWheels;
            ArrivalTime = arrivalTime;
            DepartureTime = departureTime;

            TotalParkingTime = HelperFunctions.ParkedTimeAmount(ArrivalTime);
            TotalCost = HelperFunctions.CostCalculation(TotalParkingTime, pricePerHour);
        }
    }
}
