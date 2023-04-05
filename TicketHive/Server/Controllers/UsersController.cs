using Microsoft.AspNetCore.Mvc;
using TicketHive.Server.Repository;
using TicketHive.Shared.Models;

namespace TicketHive.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly UserRepository userRepository;

		public UsersController(UserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		// GET: api/<UsersController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<UsersController>/5
		[HttpGet("{id}")]
		public async Task<UserModel?> GetAsync(string id)
		{
			return await userRepository.GetUserById(id);
		}

		// POST api/<UsersController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<UsersController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<UsersController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
