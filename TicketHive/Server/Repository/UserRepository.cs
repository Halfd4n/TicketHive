using Microsoft.AspNetCore.Identity;
using TicketHive.Server.Models;
using TicketHive.Shared.Models;

namespace TicketHive.Server.Repository;

public class UserRepository : IUserRepository
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public UserRepository(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public Task<List<UserModel>> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public Task<UserModel> GetUserById()
    {
        throw new NotImplementedException();
    }

    public async Task<IdentityResult> RegisterUserAsync(string username, string password)
    {
        ApplicationUser newUser = new()
        {
            UserName = username
        };

        return await _signInManager.UserManager.CreateAsync(newUser, password!);
    }

    public async Task<SignInResult> SignInUserAsync(string username, string password)
    {
        return await _signInManager.PasswordSignInAsync(username, password, false, false);
    }
}
