using parking_lot_simulaton.Interfaces;

namespace parking_lot_simulaton.Models
{
    internal class Vehicle : IVehicle
    {
        public int VehicleNumber { get; set; }

        public VehicleType Type { get; set; }
    }
}