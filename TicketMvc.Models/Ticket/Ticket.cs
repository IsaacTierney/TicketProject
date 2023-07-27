using System;

namespace TicketMvc.Data.Entities
{
    public class TicketMvc
    {
        public string ShowTitle { get; set; } = string.Empty;
        public string SeatAssignment { get; set; } = string.Empty;
        public DateTime ShowDate { get; set; }
        public decimal Price { get; set; }
    }
}