namespace parking_lot_simulaton.Interfaces
{
    internal interface IDriverService
    {
        void DisplayVehicleTypes();
        int getIntegerInput(string message);
        void HandleMenu();
        void HandleParkingMenu();
        void Initialize();
    }
}