using switch_board_simulation.Interfaces;

namespace switch_board_simulation.Models
{
    public class Switch : ISwitch
    {
        public int Id { get; set; }
        public int ApplianceId { get; set; }
        public SwitchState State { get; set; }

        public Switch(int id, int applianceId)
        {
            Id = id;
            ApplianceId = applianceId;
            State = SwitchState.Off;
        }
    }
}
