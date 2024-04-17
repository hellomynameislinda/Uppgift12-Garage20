namespace Uppgift12_Garage20.Models
{
    public class ParkedVehicle
    {
        public int ParkedVehicleId { get; set; }
        public int VehicleType { get; set; }
        public string RegistrationNumber { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int NumberOfWheels { get; set; }
        public DateTime ArrivalTime { get; private set; }
    }
}
