using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TicketMvc.Data.Entities;

public class UserEntity : IdentityUser<int>
{
    [Required]
    public string Username { get; set; } = string.Empty;
    public override string UserName => Username;

    [Required]
    public string Password { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? FirstName { get; set; }

    [MaxLength(100)]
    public string? LastName { get; set; }

    [Required]
    public DateTime DateCreated { get; set; }
}