using System.ComponentModel.DataAnnotations;

namespace TicketMvc.Models.Show;

public class Show
{
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [StringLength(100)]
    public string Venue { get; set; } = string.Empty;
}