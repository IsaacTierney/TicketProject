using TicketMvc.Data.Entities;

namespace TicketMvc.Services
{
    public class TicketService : ITicketService
    {
        private List<TicketEntity> tickets = new List<TicketEntity>();

        public TicketEntity GetTicketById(int ticketId)
        {
            return tickets.Find(ticket => ticket.Id == ticketId);
        }

        public IEnumerable<TicketEntity> GetAllTickets()
        {
            return tickets;
        }

        public void AddTicket(TicketEntity ticket)
        {
            // Assuming you have a way to generate unique ticket IDs, e.g., from a database
            ticket.Id = GenerateUniqueId();
            tickets.Add(ticket);
        }

        public void UpdateTicket(TicketEntity ticket)
        {
            int index = tickets.FindIndex(t => t.Id == ticket.Id);
            if (index >= 0)
            {
                tickets[index] = ticket;
            }
            else
            {
                throw new ArgumentException("Ticket not found.");
            }
        }

        public void DeleteTicket(int ticketId)
        {
            tickets.RemoveAll(ticket => ticket.Id == ticketId);
        }

        private int GenerateUniqueId()
        {
            return tickets.Count + 1;
        }
    }
}
