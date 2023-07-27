
using TicketMvc.Data.Entities;

namespace TicketMvc.Services
{
    public interface ITicketService
    {
        TicketEntity GetTicketById(int ticketId);
        IEnumerable<TicketEntity> GetAllTickets();
        void AddTicket(TicketEntity ticket);
        void UpdateTicket(TicketEntity ticket);
        void DeleteTicket(int ticketId);
    }
}