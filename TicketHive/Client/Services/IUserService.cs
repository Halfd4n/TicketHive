using TicketHive.Server.Enums;
using TicketHive.Shared.Models;

namespace TicketHive.Client.Services;

public interface IUserService
{
	Task<UserModel?> GetUserAsync(string userId);
	Task<HttpResponseMessage> UpdateUserCountryAsync(string userId, Country country);
	Task<HttpResponseMessage> UpdateUserPasswordAsync(string userId, string currentPassword, string newPassword);
	Task<HttpResponseMessage> DeleteUserAsync(string userId);
}
