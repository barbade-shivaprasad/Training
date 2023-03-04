using switch_board_simulation.Interfaces;

namespace switch_board_simulation.Models
{
    public class SwitchBoard : ISwitchboard
    {
        public List<Switch> Switches { get; set; }

        public SwitchBoard()
        {
            Switches = new List<Switch>();
        }
    }
}
