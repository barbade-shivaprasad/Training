using switch_board_simulation.Interfaces;
using switch_board_simulation.Models;

namespace switch_board_simulation.Services
{
    public class SwitchService : ISwitchService
    {
        public void Toggle(Switch s)
        {
            s.State = s.State == SwitchState.On ? SwitchState.Off : SwitchState.On;
        }

        public void DisplaySwitch(Switch s)
        {
            Console.Clear();

            Appliance appliance = ApplianceService.GetAppliance(s.ApplianceId);
            string toggleState = s.State == SwitchState.On ? "Off" : "On";
            Console.WriteLine($"1. Switch {appliance.Name} {toggleState} \n2. Back");
        }
    }
}
