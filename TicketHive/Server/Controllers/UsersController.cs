using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

		// Not done yet!
		// GET: api/<UsersController>
		[HttpGet]
		public IEnumerable<string> GetAsync()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<UsersController>/5
		[HttpGet("{id}")]
		public async Task<UserModel?> GetAsync(string id)
		{
			return await userRepository.GetMainUserByIdAsync(id);
		}

		// Not done yet!
		// Update user password
		[HttpPut("{id}")]
		public async Task<bool> UpdateUserPasswordAsync(string id, string passwordsAsJson)
		{
			string[]? passwordStrings = JsonConvert.DeserializeObject<string[]>(passwordsAsJson);

			return await userRepository.ChangePasswordAsync(id, passwordStrings[1], passwordStrings[0]);
		}

		// Update user Country
		[HttpPut("{id}/{countryAsJson}")]
		public async Task<bool> UpdateUserCountryAsync(string id, string countryAsJson)
		{
			Country country = JsonConvert.DeserializeObject<Country>(countryAsJson);

			return await userRepository.ChangeCountryAsync(id, country);
		}

		// DELETE api/<UsersController>/5
		[HttpDelete("{id}")]
		public async Task DeleteUserAsync(string id)
		{
			await userRepository.DeleteUserAsync(id);
		}
	}
}
