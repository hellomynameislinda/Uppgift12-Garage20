﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uppgift12_Garage20.Models
{
    [ModelMetadataType(typeof(VehicleModelMetaData))]
    public class ParkedVehicle
    {
        public int ParkedVehicleId { get; set; }
        public VehicleType VehicleType { get; set; }
        public string RegistrationNumber { get; init; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int NumberOfWheels { get; set; }
        public DateTime ArrivalTime { get; init; } = DateTime.Now;

        [NotMapped]
        public TimeSpan TotalParkingTime
        {
            get => Helpers.HelperFunctions.ParkedTimeAmount(ArrivalTime);
        }
    }
}