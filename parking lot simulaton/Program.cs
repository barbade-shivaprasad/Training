
using parking_lot_simulaton.Interfaces;
using SimpleInjector;

namespace parking_lot_simulaton
{
    class Program
    {
        public static void Main(string[] args)
        {
            Container container = ContainerConfiguration.GetContainer();
            IDriverService driver = container.GetInstance<IDriverService>();

            while (true)
            {
                driver.Initialize();
            }
        }
    }
}