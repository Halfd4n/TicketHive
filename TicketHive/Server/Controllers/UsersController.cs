using Microsoft.AspNetCore.Mvc;
using TicketHive.Server.Enums;
using TicketHive.Server.Repository;
using TicketHive.Shared.Models;

namespace TicketHive.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserRepository userRepository;

		public UsersController(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}


		// GET api/<UsersController>/5
		[HttpGet("{id}")]
		public async Task<UserModel?> GetAsync(string id)
		{
			return await userRepository.GetMainUserByIdAsync(id);
		}

		// Update user password
		[HttpPut("{id}")]
		public async Task UpdateUserPasswordAsync(string id, string[] passwordStrings)
		{
			await userRepository.ChangePasswordAsync(id, passwordStrings[0], passwordStrings[1]);
		}

		// Update user Country
		[HttpPut("{id}/{country}")]
		public async Task UpdateUserCountryAsync(string id, Country country)
		{
			await userRepository.ChangeCountryAsync(id, country);
		}

		// DELETE api/<UsersController>/5
		[HttpDelete("{id}")]
		public async Task DeleteUserAsync(string id)
		{
			await userRepository.DeleteUserAsync(id);
		}
	}
}
