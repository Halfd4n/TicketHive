using Microsoft.AspNetCore.Mvc;
using TicketHive.Server.Repositories;
using TicketHive.Shared.Models;

namespace TicketHive.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EventsController : ControllerBase
	{
		private readonly IEventRepository eventRepository;

		public EventsController(IEventRepository eventRepository)
		{
			this.eventRepository = eventRepository;
		}

		// GET: api/<EventsController>
		[HttpGet]
		public async Task<List<EventModel>?> GetAllAsync()
		{
			return await eventRepository.GetAllEventsAsync();
		}

		// GET api/<EventsController>/5
		[HttpGet("{id}")]
		public async Task<EventModel> GetByIdAsync(int id)
		{
			return await eventRepository.GetEventByIdAsync(id);
		}

		// POST api/<EventsController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<EventsController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<EventsController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
