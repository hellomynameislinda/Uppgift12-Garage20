using System.ComponentModel.DataAnnotations;

namespace Uppgift12_Garage20.Models
{
    /* Metadata class: Provides a way to attach the attributes (like Display) to properties
     * in only one place and then reuse them using ModelMetadataType.
     */
    public class VehicleModelMetaData
    {
        [Display(Name = "Type of Vehicle", ShortName = "Type")]
        public VehicleType VehicleType { get; set; }

        [Display(Name = "Registration Number", ShortName = "Reg. No.")]
        public string RegistrationNumber { get; init; } = string.Empty;

        [Display(Name = "Number of Wheels", ShortName = "Wheels")]
        public int NumberOfWheels { get; set; }

        [Display(Name = "Arrival Time", ShortName = "Arrived")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime ArrivalTime { get; init; } = DateTime.Now;

        [Display(Name = "Total Time Parked")]
        [DisplayFormat(DataFormatString = @"{0:%h} hours {0:%m} minutes")]
        public TimeSpan TotalParkingTime { get; private set; }

        [Display(Name = "Total Cost")]
        [DisplayFormat(DataFormatString = "{0:N0}:-")]
        public decimal TotalCost { get; private set; }
    }
}