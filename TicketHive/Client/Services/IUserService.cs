using TicketHive.Server.Enums;
using TicketHive.Shared.Models;

namespace TicketHive.Client.Services;

public interface IUserService
{
	Task<UserModel?> GetUserAsync(string userId);
	Task<bool> UpdateUserCountryAsync(string userId, Country country);
	Task<bool> UpdateUserPasswordAsync(string userId, string currentPassword, string newPassword);
	Task<bool> DeleteUserAsync(string userId);
}
