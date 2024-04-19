using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Uppgift12_Garage20.Models
{
    public class ParkedVehicle
    {
        public int ParkedVehicleId { get; set; }

        [DisplayName("Vehicle Type")]
        public VehicleType VehicleType { get; set; }

        [DisplayName("Registration Number")]
        public string RegistrationNumber { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;

        [DisplayName("Number Of Wheels")]
        public int NumberOfWheels { get; set; }

        [DisplayName("Arrival Time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime ArrivalTime { get; init; } = DateTime.Now;
    }
}