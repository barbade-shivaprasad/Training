using switch_board_simulation.DB;
using switch_board_simulation.Interfaces;
using switch_board_simulation.Models;

namespace switch_board_simulation.Services
{
    public class SwitchBoardService : ISwitchBoardService
    {
        private ISwitchService _switchService;

        public SwitchBoardService(ISwitchService switchService)
        {
            _switchService = switchService;
        }

        private static SwitchBoard switchBoard = SwitchBoardDB.GetSwitchBoard();
        public void Initialize(int noOfFans, int noOfAcs, int noOfBulbs)
        {
            switchBoard.Switches.Clear();


            int id = 1;

            PopulateSwitches(noOfFans, ref id, ApplianceType.Fan);

            PopulateSwitches(noOfAcs, ref id, ApplianceType.Ac);

            PopulateSwitches(noOfBulbs, ref id, ApplianceType.Bulb);
        }

        public void ToggleSwitch(int id)
        {
            var s = switchBoard.Switches.Find(s => s.Id == id);

            if (s == null)
                throw new Exception("ID not found");
            else
                _switchService.Toggle(s);
        }

        public Switch GetSwitch(int id)
        {
            var s = switchBoard.Switches.Find(s => s.Id == id);

            if (s == null)
                throw new Exception("Switch not found");

            return s;
        }

        public void DisplayMenu()
        {
            Console.Clear();

            Console.WriteLine("MENU");
            foreach (Switch s in switchBoard.Switches)
            {
                Appliance appliance = ApplianceService.GetAppliance(s.ApplianceId);
                Console.WriteLine($"{s.Id}. {appliance.Name} is {s.State}");
            }
            Console.WriteLine($"{switchBoard.Switches.Count + 1}. Exit");
        }

        private void AddSwitch(Switch s)
        {
            switchBoard.Switches.Add(s);
        }

        private void PopulateSwitches(int count, ref int id, ApplianceType type)
        {
            int applianceId = id;
            for (int i = 0; i < count; i++)
            {
                string name = Convert.ToString(type) + $" {i + 1}";

                Appliance appliance = new Appliance(applianceId, name, type);
                ApplianceService.AddAppliance(appliance);

                Switch s = new Switch(id++, applianceId++);
                AddSwitch(s);
            }

        }
    }
}
