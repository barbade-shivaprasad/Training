using parking_lot_simulaton.Models;

namespace parking_lot_simulaton.Interfaces
{
    internal interface IParkingLot
    {
        List<Slot> Slots { get; set; }

        List<Ticket> Tickets { get; set; }

        List<Vehicle> Vehicles { get; set; }

        int Charge { get; set; }

        int LateCharge { get; set; }
    }
}
