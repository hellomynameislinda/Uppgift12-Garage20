﻿using Uppgift12_Garage20.Helpers;

namespace Uppgift12_Garage20.Models
{
    public class Reciept
    {
        public int ParkedVehicleId { get; set; }
        public string RegistrationNumber { get; set; } = string.Empty;
        public DateTime ArrivalTime { get; set; }

        public TimeSpan TotalParkingTime { get; private set; }
        public decimal TotalCost { get; private set; }

        public Reciept()
        {
        }
    }
}
