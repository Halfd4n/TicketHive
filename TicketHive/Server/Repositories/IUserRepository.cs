namespace TicketHive.Server.Repository;

public interface IUserRepository
{
	Task<List<UserModel>> GetUsersAsync();

	Task<UserModel?> GetUserAsync(string userId);

	Task<SignInResult> SignInUserAsync(string username, string password);

	Task<IdentityResult> RegisterUserAsync(string username, string password);

	Task<bool> ChangePasswordAsync(string id, string currentPassword, string newPassword);
}
