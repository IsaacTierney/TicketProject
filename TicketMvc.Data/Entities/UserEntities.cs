using Microsoft.AspNetCore.Identity;

namespace TicketMvc.Data.Entities;

public class UserEntity : IdentityUser<int>
{
    public string? Name { get; set; }
    public DateTime DateCreated { get; set; }
}