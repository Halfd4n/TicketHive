using Microsoft.AspNetCore.Identity;
using TicketHive.Server.Enums;
using TicketHive.Server.Models;
using TicketHive.Shared.Models;

namespace TicketHive.Server.Repositories;

public interface IUserRepository
{
    Task<List<UserModel>> GetAllUsers();

    Task<UserModel?> GetUserById(string id);

    Task<SignInResult> SignInUserAsync(string username, string password);

    Task<IdentityResult> RegisterUserAsync(string username, string password, Country country);

    Task<bool> ChangePasswordAsync(string id, string currentPassword, string newPassword);

    Task<ApplicationUser?> GetSignedInUser(string username);

}
