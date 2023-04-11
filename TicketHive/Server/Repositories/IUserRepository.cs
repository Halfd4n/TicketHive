using Microsoft.AspNetCore.Identity;
using TicketHive.Server.Enums;
using TicketHive.Server.Models;
using TicketHive.Shared.Models;

namespace TicketHive.Server.Repository;

public interface IUserRepository
{
	Task<List<UserModel>> GetUsersAsync();
	Task<UserModel?> GetUserByIdAsync(string userId);
	Task<SignInResult> SignInUserAsync(string username, string password);
	Task<IdentityResult> RegisterUserAsync(string username, string password, Country country);
	Task<bool> ChangePasswordAsync(string id, string currentPassword, string newPassword);
	Task<bool> ChangeCountryAsync(string id, Country country);
	Task<ApplicationUser> GetSignedInUser(string userName);
}
