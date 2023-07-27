using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TicketMvc.Data;
using TicketMvc.Data.Entities;
using TicketMvc.Models.User;

namespace TicketMvc.Services.User;

public class UserService : IUserService
{
    private readonly AppDbContext _ctx;
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;

    public UserService(
        AppDbContext ctx,
        UserManager<UserEntity> userManager,
        SignInManager<UserEntity> signInManager)
    {
        _ctx = ctx;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> RegisterUserAsync(UserRegister model)
    {
        var UserExists = await UserExistsAsync(model.Email, model.Username);
        Console.WriteLine(UserExists);
        if (UserExists)
            return false;
        Console.WriteLine(model.Username);
        UserEntity user = new()
        {
            UserName = model.Username,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = string.Empty,
        };

        var createResult = await _userManager.CreateAsync(user, model.Password);
        if (createResult.Succeeded == false)
        {
            foreach (var e in createResult.Errors)
                Console.WriteLine(e. Description);
        }
        return createResult.Succeeded;
    }

    public async Task<bool> LoginAsync(UserLogin model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);
        if (user is null)
            return false;

        var isValidPassword = await _userManager.CheckPasswordAsync(user, model.Password);
        if (isValidPassword == false)
            return false;
        
        await _signInManager.SignInAsync(user, true);
        return true;
    }

    public async Task LogoutAsync() => await _signInManager.SignOutAsync();

    private async Task<bool> UserExistsAsync(string email, string username)
    {
        var normalizedEmail = _userManager.NormalizeEmail(email);
        var normalizedUsername = _userManager.NormalizeName(username);

        return await _ctx.Users.AnyAsync(u =>
            u.NormalizedEmail == normalizedEmail ||
            u.NormalizedUserName == normalizedUsername
        );
    }
}