using System.ComponentModel.DataAnnotations;

namespace Uppgift12_Garage20.Models
{
    /* Metadata class: Provides a way to attach the attributes (like Display) to properties
     * in only one place and then reuse them using ModelMetadataType.
     */
    public abstract class VehicleModelMetaData
    {
        [Display(Name = "Type of Vehicle", ShortName = "Type")]
        public VehicleType VehicleType { get; }

        [Display(Name = "Registration Number", ShortName = "Reg. No.")]
        public string RegistrationNumber { get; } = string.Empty;

        [Display(Name = "Number of Wheels", ShortName = "Wheels")]
        public int NumberOfWheels { get; }

        [Display(Name = "Arrival Time", ShortName = "Arrived")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime ArrivalTime { get; }

        [Display(Name = "Departure Time", ShortName = "Departed")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime DepartureTime { get; }

        [Display(Name = "Total Time Parked")]
        public TimeSpan TotalParkingTime { get; }

        [Display(Name = "Total Cost")]
        [DisplayFormat(DataFormatString = "{0:N0}:-")]
        public decimal TotalCost { get; }
    }
}