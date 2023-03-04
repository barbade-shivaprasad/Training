using switch_board_simulation.Models;

namespace switch_board_simulation.Interfaces
{
    public interface IDriverService
    {
        void Initialize();

        void HandleMenu();

        void HandleSwitchMenu(Switch s);

        int getIntegerInput(string msg);

    }
}
