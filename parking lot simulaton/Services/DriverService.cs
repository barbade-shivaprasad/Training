using parking_lot_simulaton.Interfaces;
using parking_lot_simulaton.Models;


namespace parking_lot_simulaton.Services
{
    internal class DriverService : IDriverService
    {
        IParkingLotService parkingLotService;

        public DriverService(IParkingLotService parkingLotService)
        {
            this.parkingLotService = parkingLotService;
        }

        public void Initialize()
        {

            Console.Clear();
            int noOfTwoWheelers = getIntegerInput("No of Two Wheeler Slots:");
            int noOfFourWheelers = getIntegerInput("No of Four Wheeler Slots:");
            int noOfHeavyVehicles = getIntegerInput("No of Heavy Vehicle Slots:");
            int charge = getIntegerInput("Enter cost of parking:");
            int lateCharge = getIntegerInput("Enter cost for LateFee :");

            parkingLotService.Initialize(noOfTwoWheelers, noOfFourWheelers, noOfHeavyVehicles,charge,lateCharge);
            HandleMenu();
        }

        public void HandleMenu()
        {
            int selectedOption;
            bool displayFlag = true;
            int exitOption = 4;

            do
            {
                if (displayFlag)
                    parkingLotService.DisplayMenu();

                selectedOption = getIntegerInput("Select an option:");

                switch (selectedOption)
                {
                    case 1:
                        HandleParkingMenu();
                        break;

                    case 2:
                        Console.Clear();
                        int vehicleNumber = getIntegerInput("Enter Vehicle Number : ");
                        parkingLotService.UnParkVehicle(vehicleNumber);
                        GoBack();
                        break;

                    case 3:
                        parkingLotService.DisplayLot();
                        GoBack();
                        break;

                    case 4:
                        continue;

                    default:
                        displayFlag = false;
                        Console.WriteLine("Please Enter valid Option..");
                        break;
                }
            }
            while (selectedOption != exitOption);
            Console.WriteLine("Exited..");
        }

        public void HandleParkingMenu()
        {
            Console.Clear();

            DisplayVehicleTypes();

            VehicleType? type = getVehicleType();

            if (type == null)
                return;


            if (!parkingLotService.IsAvailable((VehicleType)type))
            {
                Console.WriteLine("Sorry! No slots Available to Park");
                GoBack();
                return;
            }


            int vehicleNumber = getIntegerInput("Enter Vehicle Number : ");
            int duration = getIntegerInput("Enter Duration : ");

            parkingLotService.ParkVehicle(vehicleNumber, (VehicleType)type,duration);
            GoBack();
        }

        private VehicleType? getVehicleType()
        {
            int selectedOption = getIntegerInput("Select an option : ");
            VehicleType type;
            switch (selectedOption)
            {
                case 1:
                    type = VehicleType.TwoWheeler;
                    return type;


                case 2:
                    type = VehicleType.FourWheeler;
                    return type;

                case 3:
                    type = VehicleType.HeavyVehicle;
                    return type;

                case 4:
                    return null;

                default:
                    Console.WriteLine("Please Enter valid Option");
                    return getVehicleType();
            }
        }

        public void DisplayVehicleTypes()
        {
            Console.WriteLine("Select Vehicle Type \n1.Two Wheeler \n2.Four Wheeler \n3.Heavy Vehicle \n4.Back");
        }

        public int getIntegerInput(string message)
        {
            try
            {
                Console.Write(message);

                int input = Convert.ToInt32(Console.ReadLine());

                if (input < 1)
                    throw new Exception("Please enter valid number..");
                return input;
            }
            catch (Exception)
            {
                Console.WriteLine("please Enter Numbers only..");
                return getIntegerInput(message);
            }
        }

        private void GoBack()
        {
            Console.WriteLine("Press Any key to Go back..");
            Console.ReadLine();
            int i = 0;
            while (i != 2*Console.WindowHeight)
            {
                Console.WriteLine();
                i++;
            }
        }

    }
}
