using SimpleInjector;
using switch_board_simulation.Interfaces;
using switch_board_simulation.Services;

namespace switch_board_simulation.Configurations
{
    internal static class ContainerConfiguration
    {
        public static Container getContainer()
        {
            Container container = new Container();
            container.Register<ISwitchBoardService, SwitchBoardService>();
            container.Register<ISwitchService, SwitchService>();

            return container;
        }
    }
}
