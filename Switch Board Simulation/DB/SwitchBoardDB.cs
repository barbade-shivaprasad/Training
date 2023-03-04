using switch_board_simulation.Models;

namespace switch_board_simulation.DB
{
    public class SwitchBoardDB
    {
        public static SwitchBoard switchBoard = new SwitchBoard();
        public static SwitchBoard GetSwitchBoard()
        {
            return switchBoard;
        }
    }
}
