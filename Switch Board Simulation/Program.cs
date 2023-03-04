using SimpleInjector;
using switch_board_simulation.Configurations;
using switch_board_simulation.Interfaces;
using switch_board_simulation.Services;

namespace switch_board_simulation
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Container container = ContainerConfiguration.getContainer();
            ISwitchBoardService switchBoardService = container.GetInstance<ISwitchBoardService>();
            ISwitchService switchService = container.GetInstance<ISwitchService>();

            DriverService driver = new DriverService(switchBoardService, switchService);

            while (true)
            {
                Console.Clear();
                driver.Initialize();
                driver.HandleMenu();
            }
        }

    }
}