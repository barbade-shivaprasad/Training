using parking_lot_simulaton.Models;

namespace parking_lot_simulaton.Interfaces
{
    internal interface ITicketService
    {
        void ChangeTicketStatus(int id);
        void GenerateTicket(int slotNumber, int vehicleNumber, int duration);
        Ticket GetTicket(int id);

        void DisplayTicket(Ticket ticket);
        double CalculateLateFee(double hours);
    }
}