using Microsoft.AspNetCore.Http.HttpResults;
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

	public async Task<bool> DeleteEventAsync(int eventId)
	{
		var eventToDelete = await GetEventAsync(eventId);

		if (eventToDelete != null)
		{
			_mainDbContext.Events.Remove(eventToDelete);

			await _mainDbContext.SaveChangesAsync();

			return true;
		}

		return false;
	}

	public async Task<EventModel?> GetEventAsync(int eventId)
	{
		EventModel? eventModel = await _mainDbContext.Events.Include(e => e.Bookings).FirstOrDefaultAsync(e => e.Id == eventId);

		if (eventModel != null)
		{
			return eventModel;
		}

		return null;
	}

	public Task<List<EventModel>?> GetEventsAsync()
	{
		return _mainDbContext.Events?.Include(e => e.Bookings).ToListAsync();
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

	public async Task BookEventAsync(string userId, int eventId, int quantity)
	{
		BookingModel bookingModel = new()
		{
			UserId = userId,
			EventId = eventId,
			Quantity = quantity
		};

		EventModel? eventModel = await GetEventAsync(eventId);
		UserModel? userModel = await _mainDbContext.Users.Include(u => u.Bookings).FirstOrDefaultAsync(u => u.Id == userId);

		if (eventModel != null && userModel != null && eventModel.NumberOfTickets >= quantity)
		{
			eventModel.Bookings.Add(bookingModel);
			eventModel.NumberOfTickets -= quantity;
			_mainDbContext.Events.Update(eventModel);

			userModel.Bookings.Add(bookingModel);
			_mainDbContext.Users.Update(userModel);

			await _mainDbContext.SaveChangesAsync();
		}
	}
}
