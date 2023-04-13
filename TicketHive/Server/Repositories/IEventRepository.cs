﻿using TicketHive.Server.Models;
using TicketHive.Shared.Models;

namespace TicketHive.Server.Repositories;

public interface IEventRepository
{
	Task<EventModel?> GetEventAsync(int eventId);
	Task<List<EventModel>?> GetEventsAsync();
	Task DeleteEventAsync(int eventId);
	Task AddUserToEventDb(ApplicationUser user);
	Task AddEventAsync(EventModel eventModel);
	Task BookEventAsync(string userId, int eventId, int quantity);
}
