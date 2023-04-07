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
		public async Task<List<EventModel>?> GetEventsAsync()
		{
			return await eventRepository.GetEventsAsync();
		}

		// GET api/<EventsController>/5
		[HttpGet("{id}")]
		public async Task<EventModel?> GetByIdAsync(int id)
		{
			return await eventRepository.GetEventAsync(id);
		}

		// Not done yet!
		// POST api/<EventsController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// Not done yet!
		// PUT api/<EventsController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<EventsController>/5
		[HttpDelete("{id}")]
		public async Task DeleteEventAsync(int id)
		{
			await eventRepository.DeleteEventAsync(id);
		}
	}
}
