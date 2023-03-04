using switch_board_simulation.Models;

namespace switch_board_simulation.Interfaces
{
    public interface ISwitchBoardService
    {
        void Initialize(int noOfFans, int noOfAcs, int noOfBulbs);

        void ToggleSwitch(int id);

        Switch GetSwitch(int id);

        void DisplayMenu();
    }
}
