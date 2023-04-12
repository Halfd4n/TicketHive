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

	public Task<List<UserModel>> GetAllUsers()
	{
		throw new NotImplementedException();
	}

	public async Task<UserModel?> GetMainUserByIdAsync(string userId)
	{
		ApplicationUser? applicationUser = await _signInManager.UserManager.FindByIdAsync(userId);

		if (applicationUser != null)
		{
			UserModel? mainUser = await _mainDbcontext.Users.Include(b => b.Bookings).FirstOrDefaultAsync(u => u.Id == applicationUser.Id);

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

	public async Task<ApplicationUser?> GetApplicationUserByName(string userName)
	{
		return await _signInManager.UserManager.FindByNameAsync(userName);
	}

	public Task<List<UserModel>> GetUsersAsync()
	{
		throw new NotImplementedException();
	}

	public async Task ChangeCountryAsync(string userId, Country country)
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
		}
	}

	// Not functioning yet
	public async Task ChangePasswordAsync(string id, string currentPassword, string newPassword)
	{
		ApplicationUser? user = await _signInManager.UserManager.FindByIdAsync(id);

		if (user != null)
		{
			await _signInManager.UserManager.ChangePasswordAsync(user, currentPassword, newPassword);
			await _signInManager.UserManager.UpdateAsync(user);
		}
	}

	public async Task DeleteUserAsync(string id)
	{
		ApplicationUser? applicationUser = await _signInManager.UserManager.FindByIdAsync(id);
		UserModel? mainUser = await _mainDbcontext.Users.Include(b => b.Bookings).FirstOrDefaultAsync(u => u.Id == id);

		if (mainUser != null && applicationUser != null)
		{
			_mainDbcontext.Remove(mainUser);
			await _mainDbcontext.SaveChangesAsync();

			await _signInManager.UserManager.DeleteAsync(applicationUser);
		}
	}
}
