using TicketHive.Shared.Models;

namespace TicketHive.Client.Services;

public interface IEventService
{
	Task<EventModel?> GetEventAsync(int eventId);
	Task<List<EventModel>?> GetEventsAsync();
	Task<bool> BookEventAsync(int eventId, UserModel user);
	Task<bool> AddEventAsync(EventModel eventModel);
	Task<HttpResponseMessage> DeleteEventAsync(int eventId);
}
