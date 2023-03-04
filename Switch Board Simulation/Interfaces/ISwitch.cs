using switch_board_simulation.Models;

namespace switch_board_simulation.Interfaces
{
    public interface ISwitch
    {
        int Id { get; }

        int ApplianceId { get; }

        SwitchState State { get; set; }
    }
}
