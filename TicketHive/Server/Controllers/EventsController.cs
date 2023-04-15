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

		[HttpPost]
		public async Task AddEventAsync([FromBody] EventModel eventModel)
		{
			await eventRepository.AddEventAsync(eventModel);
		}

		// PUT api/<EventsController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<string>> DeleteEventAsync(int id)
		{
			bool isSuccessfulDelete = await eventRepository.DeleteEventAsync(id);

			if (isSuccessfulDelete)
			{
				string successMessage = "Event was successfully removed from the database";
				return Ok(successMessage);
			}

			return BadRequest();
		}

		[HttpPost("{userId}/{parameters}")]
		public async Task BookEventAsync(string userId, string[] parameters)
		{
			int eventId = int.Parse(parameters[0]);
			int quantity = int.Parse(parameters[1]);

			await eventRepository.BookEventAsync(userId, eventId, quantity);
		}
	}
}
