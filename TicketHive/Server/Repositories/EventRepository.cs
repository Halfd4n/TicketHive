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

	public async Task AddUserToEventDb(ApplicationUser user)
	{
		UserModel userModel = new()
		{
			Id = user.Id,
			Username = user.UserName!,
			Country = user.Country
		};

		await _mainDbContext.Users.AddAsync(userModel);

		_mainDbContext.SaveChanges();
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
		EventModel? eventModel = await _mainDbContext.Events.Include(e => e.Visitors).FirstOrDefaultAsync(e => e.Id == eventId);

		if (eventModel != null)
		{
			return eventModel;
		}

		return null;
	}

	public async Task<List<EventModel>?> GetEventsAsync()
	{
		return await _mainDbContext.Events.Include(e => e.Visitors).ToListAsync();
	}

	public async Task AddEventAsync(EventModel eventModel)
	{
		var eventModelNameExists = await _mainDbContext.Events.AnyAsync(e => e.Name == eventModel.Name);

		if (!eventModelNameExists)
		{
			_mainDbContext.Add(eventModel);

			await _mainDbContext.SaveChangesAsync();
		}
	}
}
