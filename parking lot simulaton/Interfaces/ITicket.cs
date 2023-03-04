using parking_lot_simulaton.Models;

namespace parking_lot_simulaton.Interfaces
{
    internal interface ITicket
    {
        int Id { get; set; }
        int VehicleNumber { get; set; }

        int SlotNumber { get; set; }

        int Duration { get; set; }

        DateTime InTime { get; set; }

        DateTime? OutTime { get; set; }

        double Fee { get; set; }

        double LateFee { get; set; }

        TicketStatus Status { get; set; }
    }
}
