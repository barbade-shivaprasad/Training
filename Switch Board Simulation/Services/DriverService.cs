using switch_board_simulation.DB;
using switch_board_simulation.Interfaces;
using switch_board_simulation.Models;

namespace switch_board_simulation.Services
{
    public class DriverService : IDriverService
    {
        private ISwitchBoardService _switchBoardService;
        private ISwitchService _switchService;
        public DriverService(ISwitchBoardService switchBoardService, ISwitchService switchService)
        {
            _switchBoardService = switchBoardService;
            _switchService = switchService;
        }

        private SwitchBoard switchBoard = SwitchBoardDB.GetSwitchBoard();
        public void Initialize()
        {
            int noOfFans = getIntegerInput("Enter no of Fans:");
            int noOfAcs = getIntegerInput("Enter no of Ac's:");
            int noOfBulbs = getIntegerInput("Enter no of Bulbs:");

            _switchBoardService.Initialize(noOfFans, noOfAcs, noOfBulbs);
        }
        public void HandleMenu()
        {
            int selectedOption;
            bool displayFlag = true;
            int exitOption = switchBoard.Switches.Count + 1;

            if (switchBoard.Switches.Count == 0)
            {
                Console.WriteLine("No Switches available..");
                return;
            }

            do
            {
                if (displayFlag)
                    _switchBoardService.DisplayMenu();

                selectedOption = getIntegerInput("Select an option:");

                if (selectedOption > 0 && selectedOption <= switchBoard.Switches.Count)
                {
                    Switch selectedSwitch = _switchBoardService.GetSwitch(selectedOption);
                    HandleSwitchMenu(selectedSwitch);

                    displayFlag = true;
                }
                else if (selectedOption == exitOption)
                    continue;
                else
                {
                    Console.WriteLine("Please Enter valid option..");
                    displayFlag = false;
                }
            }
            while (selectedOption != exitOption);
            Console.WriteLine("Exited..");
        }

        public void HandleSwitchMenu(Switch s)
        {
            _switchService.DisplaySwitch(s);

            int selectedOption;
            int backOption = 2;

            do
            {
                selectedOption = getIntegerInput("Select an option:");
                if (selectedOption == 1)
                {
                    _switchService.Toggle(s);
                    break;
                }
                else if (selectedOption == backOption)
                    continue;
                else
                    Console.WriteLine("Please Enter valid Option..");
            }
            while (selectedOption != backOption);
        }
        public int getIntegerInput(string message)
        {
            try
            {
                Console.Write(message);

                int input = Convert.ToInt32(Console.ReadLine());
                return input;
            }
            catch (FormatException)
            {
                Console.WriteLine("please Enter Numbers only..");
                return getIntegerInput(message);
            }
        }
    }
}
