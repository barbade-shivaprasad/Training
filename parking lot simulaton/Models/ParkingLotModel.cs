using parking_lot_simulaton.Interfaces;

namespace parking_lot_simulaton.Models
{
    internal class ParkingLot : IParkingLot
    {
        public List<Slot> Slots { get; set; }

        public List<Ticket> Tickets { get; set; }

        public List<Vehicle> Vehicles { get; set; }

        public int Charge { get; set; }

        public int LateCharge { get; set; }

        public ParkingLot()
        {
            Slots = new List<Slot>();
            Tickets = new List<Ticket>();
            Vehicles = new List<Vehicle>();

        }
    }
}
