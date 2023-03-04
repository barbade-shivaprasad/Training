using parking_lot_simulaton.Models;

namespace parking_lot_simulaton.Interfaces
{
    internal interface ISlot
    {
        int SlotNumber { get; set; }

        int? VehicleNumber { get; set; }

        SlotStatus status { get; set; }

        VehicleType Type { get; set; }
    }
}