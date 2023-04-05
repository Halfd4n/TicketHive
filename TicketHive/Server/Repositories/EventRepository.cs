using TicketHive.Server.Data;

namespace TicketHive.Server.Repositories;

public class EventRepository : IEventRepository
{
	private readonly MainDbContext _context;

	public EventRepository(MainDbContext context)
	{
		_context = context;
	}

	//public async Task<EventModel> GetEventByIdAsync(int id)
	//{

	//}
}
