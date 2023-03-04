using parking_lot_simulaton.Models;

namespace parking_lot_simulaton.Interfaces
{
    internal interface IVehicle
    {
        VehicleType Type { get; set; }
        int VehicleNumber { get; set; }
    }

}
