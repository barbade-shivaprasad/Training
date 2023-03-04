using parking_lot_simulaton.Interfaces;

namespace parking_lot_simulaton.Models
{
    internal class Ticket : ITicket
    {
        public int Id { get; set; }

        public int VehicleNumber { get; set; }

        public int SlotNumber { get; set; }

        public DateTime InTime { get; set; }

        public int Duration { get; set; }

        public DateTime? OutTime { get; set; }

        public double Fee { get; set; }

        public double LateFee { get; set; }

        public TicketStatus Status { get; set; }

        public Ticket(int id, int vehicleNumber, int slotNumbet, DateTime inTime, int duration,double fee)
        {
            Id = id;
            VehicleNumber = vehicleNumber;
            InTime = inTime;
            Duration= duration;
            SlotNumber = slotNumbet;
            Fee = fee;
            Status = TicketStatus.Parked;
        }
    }
}
