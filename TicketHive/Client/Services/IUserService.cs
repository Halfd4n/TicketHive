using TicketHive.Shared.Models;

namespace TicketHive.Client.Services;

public interface IUserService
{
    Task UpdateUserPassword();

    Task UpdateUserCountry();

    Task<UserModel?> GetUserByIdAsync(string id);
}
