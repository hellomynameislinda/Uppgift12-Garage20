using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Uppgift12_Garage20.Helpers;

namespace Uppgift12_Garage20.Models
{
    [ModelMetadataType(typeof(VehicleModelMetaData))]
    public class Reciept
    {
        public int ParkedVehicleId { get; set; }
        public string RegistrationNumber { get; set; } = string.Empty;
        public DateTime ArrivalTime { get; set; }

        [Display(Name = "Total Time Parked")]
        public TimeSpan TotalParkingTime { get; private set; }

        [Display(Name = "Total Cost")]
        [DisplayFormat(DataFormatString = "{0:N0}:-")]
        public decimal TotalCost { get; private set; }

        public Reciept(int parkedVehicleId, string registrationNumber, DateTime arrivalTime, decimal pricePerHour)
        {
            ParkedVehicleId = parkedVehicleId;
            RegistrationNumber = registrationNumber;
            ArrivalTime = arrivalTime;

            TotalParkingTime = HelperFunctions.ParkedTimeAmount(ArrivalTime);
            TotalCost = HelperFunctions.CostCalculation(TotalParkingTime, pricePerHour);
        }
    }
}
