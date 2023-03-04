namespace parking_lot_simulaton.Models
{

    public enum VehicleType
    {
        TwoWheeler = 1,
        FourWheeler,
        HeavyVehicle
    }

    public enum SlotStatus
    {
        Occupied = 1,
        Free
    }

    public enum TicketStatus
    {
        Parked = 1,
        Unparked
    }
}
