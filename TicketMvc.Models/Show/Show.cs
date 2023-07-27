using System.ComponentModel.DataAnnotations;

namespace TicketMvc.Models.Show;

public class ShowCreate
{
    [Required]
    [MinLength(2, ErrorMessage = "{0} must be at least {1} characters long.")]
    [MaxLength(100, ErrorMessage = "{0} must be no more than {1} characters.")]
    public string ShowTitle { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(1000, ErrorMessage = "{0} must contain no more than {1} characters.")]
    public string Description { get; set; } = string.Empty;
    public int? Id { get; set;}
}