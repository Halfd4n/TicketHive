namespace TicketHive.Server.Repositories;

public class UserRepository : IUserRepository
{
	private readonly SignInManager<ApplicationUser> _signInManager;
	private readonly IHttpContextAccessor _context;

	public UserRepository(SignInManager<ApplicationUser> signInManager, IHttpContextAccessor context)
	{
		_signInManager = signInManager;
		_context = context;
	}

	public async Task<bool> ChangePasswordAsync(string id, string currentPassword, string newPassword)
	{
		ApplicationUser? user = await _signInManager.UserManager.FindByIdAsync(id);

		if (user != null)
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

	// Functioning, but will be changed to not having to provide user id 
	public async Task<UserModel?> GetUserAsync(string userId)
	{
		ApplicationUser? user = await _signInManager.UserManager.FindByIdAsync(userId);

		if (user != null)
		{
			UserModel userModel = new()
			{
				Id = user.Id,
				Username = user.UserName!
			};

			return userModel;
		}

		return null;
	}

	public async Task<IdentityResult> RegisterUserAsync(string username, string password, Country country)
	{
		ApplicationUser newUser = new()
		{
			UserName = username,
			Country = country
		};

		return await _signInManager.UserManager.CreateAsync(newUser, password!);
	}

	public async Task<SignInResult> SignInUserAsync(string username, string password)
	{
		return await _signInManager.PasswordSignInAsync(username, password, false, false);
	}

	public async Task<ApplicationUser?> GetSignedInUser(string userName)
	{
		return await _signInManager.UserManager.FindByNameAsync(userName);
	}
}
