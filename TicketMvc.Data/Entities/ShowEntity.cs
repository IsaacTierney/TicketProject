using System.ComponentModel.DataAnnotations;

namespace TicketMvc.Data.Entities;

public class ShowEntity
{
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    public DateTime DateOfEvent { get; set; }

}