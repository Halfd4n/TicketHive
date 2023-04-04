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

    public async Task<bool> ChangePasswordAsync(int id, string currentPassword, string newPassword)
    {
        ApplicationUser? user = await _signInManager.UserManager.FindByIdAsync(id.ToString());

        if(user != null)
        {
            IdentityResult result = await _signInManager.UserManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (result.Succeeded)
            {
                return true;
            }
        }

        return false;
    }

    public Task<List<UserModel>> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public async Task<UserModel?> GetUserById(int id)
    {
        ApplicationUser? user = await _signInManager.UserManager.FindByIdAsync(id.ToString());
            

        if(user != null)
        {
            UserModel userModel = new()
            {
                Id = int.Parse(user.Id),
                Username = user.UserName!
            };

            return userModel;
        }

        return null;
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
