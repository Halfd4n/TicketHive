using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TicketHive.Server.Data;
using TicketHive.Server.Enums;
using TicketHive.Server.Models;
using TicketHive.Server.Repository;
using TicketHive.Shared.Models;

namespace TicketHive.Server.Repositories;

public class UserRepository : IUserRepository
{
	private readonly SignInManager<ApplicationUser> _signInManager;
	private readonly MainDbContext _mainDbcontext;

	public UserRepository(SignInManager<ApplicationUser> signInManager, MainDbContext mainDbcontext)
	{
		_signInManager = signInManager;
		_mainDbcontext = mainDbcontext;
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

	// Functioning, but will be changed to get signed in ApplicationUser id instead of providing it manually
	public async Task<UserModel?> GetSignedInUserAsync(string userId)
	{
		// Will be changed to get user without having to provide user id
		ApplicationUser? applicationUser = await _signInManager.UserManager.FindByIdAsync(userId);

		// If applicationUser exists in IdentityDb... 
		if (applicationUser != null)
		{
			// ... check if applicationUser equivalent/mirrored user exists in MainDb 
			UserModel? mainUser = await _mainDbcontext.Users.Include(b => b.Bookings).FirstOrDefaultAsync(u => u.Id == applicationUser.Id);

			// If applicationUser equivalent/mirrored user doesn't exists in MainDb
			if (mainUser == null)
			{
				// Create newMainUser that mirrors applicationUser 
				UserModel newMainUser = new()
				{
					Id = applicationUser.Id,
					Username = applicationUser.UserName!,
					Country = applicationUser.Country!
				};

				// Save newMainUser to MainDb
				await _mainDbcontext.Users.AddAsync(newMainUser);
				await _mainDbcontext.SaveChangesAsync();

				return newMainUser;
			}

			return mainUser;
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

	public Task<List<UserModel>> GetUsersAsync()
	{
		throw new NotImplementedException();
	}

	public Task<IdentityResult> RegisterUserAsync(string username, string password)
	{
		throw new NotImplementedException();
	}

	// Not functioning yet!
	public async Task<bool> ChangeCountryAsync(string userId, Country country)
	{
		ApplicationUser? applicationUser = await _signInManager.UserManager.FindByIdAsync(userId);
		UserModel? mainUser = await _mainDbcontext.Users.Include(b => b.Bookings).FirstOrDefaultAsync(u => u.Id == userId);

		if (mainUser != null && applicationUser != null)
		{
			mainUser.Country = country;
			_mainDbcontext.Update(mainUser);
			await _mainDbcontext.SaveChangesAsync();

			applicationUser.Country = country;
			await _signInManager.UserManager.UpdateAsync(applicationUser);

			return true;
		}

		return false;
	}
}
