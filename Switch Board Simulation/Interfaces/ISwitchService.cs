using switch_board_simulation.Models;

namespace switch_board_simulation.Interfaces
{
    public interface ISwitchService
    {
        void Toggle(Switch s);

        void DisplaySwitch(Switch s);
    }
}
