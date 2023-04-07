using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

		// Functioning, but will be changed to not having to provide user id 
		// GET api/<UsersController>/5
		[HttpGet("{id}")]
		public async Task<UserModel?> GetAsync(string id)
		{
			return await userRepository.GetUserAsync(id);
		}

		// POST api/<UsersController>
		[HttpPost]
		public void PostAsync([FromBody] string value)
		{
		}

		// Not done yet!
		// Update user password
		[HttpPut("{id}")]
		public async Task<bool> UpdateUserPasswordAsync(string id, string passwordsAsJson)
		{
			string[]? passwordStrings = JsonConvert.DeserializeObject<string[]>(passwordsAsJson);

			return await userRepository.ChangePasswordAsync(id, passwordStrings[1], passwordStrings[0], Enums.Country.Denmark);
		}

		// PUT api/<UsersController>/5
		[HttpPut("{id}")]
		public void PutAsync(int id, [FromBody] string value)
		{
		}

		// DELETE api/<UsersController>/5
		[HttpDelete("{id}")]
		public void DeleteAsync(int id)
		{
		}
	}
}
