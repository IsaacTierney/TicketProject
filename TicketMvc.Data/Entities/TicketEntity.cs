using System.ComponentModel.DataAnnotations;

namespace TicketMvc.Data.Entities;

public class TicketEntity
{
    public string ShowTitle { get; set; } = string.Empty;
    public string SeatAssignment { get; set; } = string.Empty;
    public DateTime ShowDate { get; set; }
    public decimal Price { get; set; }
}