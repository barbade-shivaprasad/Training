using parking_lot_simulaton.Interfaces;

namespace parking_lot_simulaton.Models
{
    internal class Slot : ISlot
    {
        public int SlotNumber { get; set; }

        public int? VehicleNumber { get; set; }

        public VehicleType Type { get; set; }

        public SlotStatus status { get; set; }

        public Slot(int slotNumber, VehicleType type, SlotStatus status)
        {
            SlotNumber = slotNumber;
            Type = type;
            this.status = status;
        }
    }
}
