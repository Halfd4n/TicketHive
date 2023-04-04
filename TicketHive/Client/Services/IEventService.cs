using TicketHive.Shared.Models;

namespace TicketHive.Client.Services;

public interface IEventService
{
    Task<List<EventModel>?> GetAllEventsAsync();

    Task<EventModel?> GetOneEventAsync(int id);

    Task AddEventAsync(EventModel eventModel);

    Task BookEventAsync(int eventId, UserModel user);

    Task DeleteEventAsync(int id);
}
