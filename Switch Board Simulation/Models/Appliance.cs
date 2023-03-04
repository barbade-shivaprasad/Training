namespace switch_board_simulation.Models
{

    public class Appliance
    {
        public int Id { get; }
        public string Name { get; set; }
        public ApplianceType Type { get; set; }
        public Appliance(int id, string name, ApplianceType type)
        {
            Id = id;
            Name = name;
            Type = type;
        }
    }
}
