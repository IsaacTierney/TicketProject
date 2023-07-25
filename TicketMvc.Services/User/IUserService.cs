using TicketMvc.Models.User;

namespace TicketMvc.Services.User;
public interface IUserService
{
Task<bool> RegisterUserAsync(UserRegister model);
Task<bool> LoginAsync(UserLogin model);
Task LogoutAsync();
}