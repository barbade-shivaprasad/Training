using parking_lot_simulaton.Models;

namespace parking_lot_simulaton.Interfaces
{
    internal interface IParkingLotService
    {
        void DisplayLot();
        Slot GetSlot(int vehicleNumber);
        void Initialize(int noOfTwoWheelerSlots, int noOfFourWheelerSlots, int noOfHeavySlots, int charge,int lateCharge);
        void ParkVehicle(int vehicleNumber, VehicleType type,int duration);

        bool IsAvailable(VehicleType vehicleType);
        void UnParkVehicle(int vehicleNumber);

        void DisplayMenu();
    }
}