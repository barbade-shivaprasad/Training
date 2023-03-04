using switch_board_simulation.DB;
using switch_board_simulation.Models;

namespace switch_board_simulation.Services
{
    public class ApplianceService
    {
        public static Appliance GetAppliance(int applianceId)
        {
            var result = Appliances.ApplianceList.Find(a => a.Id == applianceId);

            if (result == null)
            {
                throw new Exception("Appliance Not found");
            }

            return result;
        }

        public static void AddAppliance(Appliance appliance)
        {
            Appliances.ApplianceList.Add(appliance);
        }
    }
}
