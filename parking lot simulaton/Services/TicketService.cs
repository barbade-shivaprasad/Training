using parking_lot_simulaton.Interfaces;
using parking_lot_simulaton.Models;

namespace parking_lot_simulaton.Services
{
    internal class TicketService : ITicketService
    {
        IParkingLot parkingLot;
        static int id = 1;
        public TicketService(IParkingLot parkingLot)
        {
            this.parkingLot = parkingLot;
        }

        public void GenerateTicket(int slotNumber, int vehicleNumber, int duration)
        {
            DateTime inTime = DateTime.Now;

            double fee = CalculateFee(duration);

            Ticket ticket = new Ticket(id++, vehicleNumber, slotNumber, inTime, duration , fee);
            AddTicket(ticket);

            DisplayTicket(ticket);

        }

        public void DisplayTicket(Ticket ticket)
        {
            Console.WriteLine(
            "\n\n********** TICKET *********" +
            $"\nTicket Number : {ticket.Id}" +
            $"\nVehicle Number : {ticket.VehicleNumber}" +
            $"\nSlot Number : {ticket.SlotNumber}" +
            $"\nIn Time : {ticket.InTime}" +
            $"\nOut Time : {ticket.OutTime}" +
            $"\nFee : Rs. {ticket.Fee}" +
            $"\nLate Fee : Rs. {ticket.LateFee}"+
            $"\nTotal Amount : Rs {ticket.LateFee + ticket.Fee}"
            );
        }
        private void AddTicket(Ticket ticket)
        {
            parkingLot.Tickets.Add(ticket);
        }

        public Ticket GetTicket(int vehicleNumber)
        {
            var result = parkingLot.Tickets.Find(x => x.VehicleNumber == vehicleNumber);

            if (result == null)
            {
                throw new Exception("Ticket Not Found");
            }

            return (Ticket)result;
        }
        public void ChangeTicketStatus(int id)
        {
            Ticket ticket = GetTicket(id);
            ticket.Status= TicketStatus.Unparked;

        }

        private double CalculateFee(double hours)
        {
            double fee = parkingLot.Charge * hours;
            return Math.Round(fee, 2);
        }

        public double CalculateLateFee(double hours)
        {
            if(hours > 0)
            {
                double fee = (parkingLot.Charge+parkingLot.LateCharge) * hours;
                return Math.Round(fee, 2);
            }

            return 0;
        }
    }
}