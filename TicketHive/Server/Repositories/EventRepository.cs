namespace TicketHive.Server.Repositories;

public class EventRepository : IEventRepository
{
	private readonly MainDbContext _context;

	public EventRepository(MainDbContext context)
	{
		_context = context;
	}

	public async Task DeleteEventAsync(int eventId)
	{
		var eventToDelete = await GetEventAsync(eventId);

		if (eventToDelete != null)
		{
			_context.Events.Remove(eventToDelete);

			await _context.SaveChangesAsync();
		}
	}

	public async Task<EventModel?> GetEventAsync(int eventId)
	{
		EventModel? eventModel = await _context.Events.FindAsync(eventId);

		if (eventModel != null)
		{
			return eventModel;
		}

		return null;
	}

	public async Task<List<EventModel>?> GetEventsAsync()
	{
		return await _context.Events.ToListAsync();
	}
}
