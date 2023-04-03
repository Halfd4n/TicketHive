using Microsoft.AspNetCore.Identity;
using TicketHive.Shared.Models;

namespace TicketHive.Server.Repository;

public interface IUserRepository
{
    Task<List<UserModel>> GetAllUsers();

    Task<UserModel> GetUserById();

    Task<SignInResult> SignInUserAsync(string username, string password);

    Task<IdentityResult> RegisterUserAsync(string username, string password);

}
