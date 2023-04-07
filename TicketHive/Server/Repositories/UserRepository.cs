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

	// Not done yet!
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

	// Not done yet!
	public Task<List<UserModel>> GetUsersAsync()
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
				Username = user.UserName!,
				Country = user.Country
			};

			return userModel;
		}

		return null;
	}

	// Not done yet!
	public async Task<IdentityResult> RegisterUserAsync(string username, string password)
	{
		ApplicationUser newUser = new()
		{
			UserName = username
		};

		return await _signInManager.UserManager.CreateAsync(newUser, password!);
	}

	// Not done yet!
	public async Task<SignInResult> SignInUserAsync(string username, string password)
	{
		return await _signInManager.PasswordSignInAsync(username, password, false, false);
	}
}
