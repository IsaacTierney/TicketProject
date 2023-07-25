
using System.ComponentModel.DataAnnotations;


namespace TicketMvc.Models.User
{
    public class UserLogin
    {
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;

    }
}