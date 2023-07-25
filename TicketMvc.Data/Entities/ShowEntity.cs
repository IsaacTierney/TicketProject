using System.ComponentModel.DataAnnotations;

namespace TicketMvc.Data.Entities;

public class ShowEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DateOfEvent { get; set; }

}