using parking_lot_simulaton.Interfaces;
using parking_lot_simulaton.Models;
using parking_lot_simulaton.Services;
using SimpleInjector;

namespace parking_lot_simulaton
{
    internal static class ContainerConfiguration
    {
        public static Container GetContainer()
        {
            Container container = new Container();
            container.Register<IParkingLotService, ParkingLotService>(Lifestyle.Singleton);
            container.Register<IParkingLot, ParkingLot>(Lifestyle.Singleton);
            container.Register<ITicketService, TicketService>(Lifestyle.Singleton);
            container.Register<IDriverService, DriverService>(Lifestyle.Singleton);

            return container;
        }
    }
}