﻿namespace TicketHive.Server.Repositories;

public interface IEventRepository
{
	Task<EventModel?> GetEventAsync(int eventId);
	Task<List<EventModel>?> GetEventsAsync();
	Task DeleteEventAsync(int eventId);
}
