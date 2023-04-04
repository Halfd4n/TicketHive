using TicketHive.Shared.Models;

namespace TicketHive.Client.Services;

public interface IUserService
{
    Task UpdateUserPassword(int id, string currentPassword, string newPassword);

    Task UpdateUserCountry();

    Task<UserModel?> GetUserByIdAsync(int id);
}
