using Microsoft.EntityFrameworkCore;
using TicketHive.Server.Data;
using TicketHive.Server.Models;
using TicketHive.Shared.Models;

namespace TicketHive.Server.Repositories;

public class EventRepository : IEventRepository
{
	private readonly MainDbContext _mainDbContext;

	public EventRepository(MainDbContext mainDbContext)
	{
		_mainDbContext = mainDbContext;
	}

	public Task AddUserToEventDb(ApplicationUser user)
	{
		throw new NotImplementedException();
	}

	public async Task DeleteEventAsync(int eventId)
	{
		var eventToDelete = await GetEventAsync(eventId);

		if (eventToDelete != null)
		{
			_mainDbContext.Events.Remove(eventToDelete);

			await _mainDbContext.SaveChangesAsync();
		}
	}

	public async Task<EventModel?> GetEventAsync(int eventId)
	{
		EventModel? eventModel = await _mainDbContext.Events.FindAsync(eventId);

		if (eventModel != null)
		{
			return eventModel;
		}

		return null;
	}

	public async Task<List<EventModel>?> GetEventsAsync()
	{
		return await _mainDbContext.Events.ToListAsync();
	}
}
