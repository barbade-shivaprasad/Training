using parking_lot_simulaton.Interfaces;
using parking_lot_simulaton.Models;


namespace parking_lot_simulaton.Services
{
    internal class ParkingLotService : IParkingLotService
    {
        private IParkingLot parkingLot;
        private ITicketService ticketService;

        public ParkingLotService(IParkingLot parkingLot, ITicketService ticketService)
        {
            this.parkingLot = parkingLot;
            this.ticketService = ticketService;
        }

        public void Initialize(int noOfTwoWheelerSlots, int noOfFourWheelerSlots, int noOfHeavySlots, int charge,int lateCharge)
        {
            int slotNumber = 1;

            parkingLot.Charge = charge;
            parkingLot.LateCharge = lateCharge;
            parkingLot.Slots.Clear();
            parkingLot.Tickets.Clear();


            PopulateSlots(noOfTwoWheelerSlots, VehicleType.TwoWheeler, ref slotNumber);

            PopulateSlots(noOfFourWheelerSlots, VehicleType.FourWheeler, ref slotNumber);

            PopulateSlots(noOfHeavySlots, VehicleType.HeavyVehicle, ref slotNumber);

        }
        public bool IsAvailable(VehicleType type)
        {
            return parkingLot.Slots.Where(item => item.status == SlotStatus.Free && item.Type == type).Any();
        }


        public void ParkVehicle(int vehicleNumber, VehicleType type,int duration)
        {
            try
            {
                Slot slot = this.GetFreeSlot(type);

                if (parkingLot.Tickets.Exists(item => item.VehicleNumber == vehicleNumber && item.Status==TicketStatus.Parked))
                    throw new Exception("Vehicle Already parked!..");

                slot.status = SlotStatus.Occupied;
                slot.VehicleNumber = vehicleNumber;

                ticketService.GenerateTicket(slot.SlotNumber, vehicleNumber, duration);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void UnParkVehicle(int vehicleNumber)
        {
            try
            {
                Ticket ticket = ticketService.GetTicket(vehicleNumber);

                if (ticket.Status == TicketStatus.Unparked)
                { 
                    Console.WriteLine("Vehicle already Unparked..");
                    return;
                }

                double overTime = (DateTime.Now - ticket.InTime).Hours - ticket.Duration;

                ticket.LateFee= ticketService.CalculateLateFee(overTime);
                ticket.OutTime = DateTime.Now;
                ticketService.DisplayTicket(ticket);

                ticketService.ChangeTicketStatus(vehicleNumber);

                Slot slot = GetSlot(vehicleNumber);
                slot.status = SlotStatus.Free;
                slot.VehicleNumber = null;

                Console.WriteLine("Success !");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Slot GetSlot(int vehicleNumber)
        {
            var result = parkingLot.Slots.Find(item => item.VehicleNumber == vehicleNumber);

            if (result == null)
                throw new Exception("No Slot is registered with this vehicle Number");

            return result;

        }

        public void DisplayLot()
        {
            Console.Clear();

            Console.WriteLine("Lot Details");
            foreach (Slot slot in parkingLot.Slots)
            {

                Console.WriteLine(
                    $"\nSlot Number  : {slot.SlotNumber} " +
                    $"\nParking Type : {slot.Type} " +
                    $"\nSlot Status  : {slot.status} \n" +
                    (slot.VehicleNumber != -1 ? $"Vehicle No : {slot.VehicleNumber}" : "")

                );

            }
        }

        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu \n1.Park Vehicle \n2.Unpark Vehicle \n3.Show Lot Details \n4.Exit");
        }

        private void AddSlot(Slot slot)
        {
            parkingLot.Slots.Add(slot);
        }

        private void PopulateSlots(int count, VehicleType type, ref int slotNumber)
        {
            for (int i = 0; i < count; i++)
            {
                AddSlot(new Slot(slotNumber++, type, SlotStatus.Free));
            }
        }

        private Slot GetFreeSlot(VehicleType type)
        {
            var result = parkingLot.Slots.Where(item => item.status == SlotStatus.Free && item.Type == type).FirstOrDefault();

            if (result == null)
                throw new Exception("Slots are FULL");

            return result;
        }

    }
}
