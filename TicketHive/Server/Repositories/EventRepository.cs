using TicketHive.Server.Data;
using TicketHive.Shared.Models;

namespace TicketHive.Server.Repositories;

public class EventRepository : IEventRepository
{
	private readonly MainDbContext _context;

	public EventRepository(MainDbContext context)
	{
		_context = context;
	}

	public async Task<EventModel?> GetEventByIdAsync(int id)
	{
		EventModel? eventModel = await _context.Events.FindAsync(id);

		if (eventModel != null)
		{
			return eventModel;
		}

		return null;
	}
}
