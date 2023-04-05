using TicketHive.Server.Models;
using TicketHive.Shared.Models;

namespace TicketHive.Server.Repositories;

public interface IEventRepository
{
    public EventModel? GetEventById(int id);

    public Task<List<EventModel>?> GetAllEventsAsync();

    public void AddEventAsync(EventModel eventModel);

    public void DeleteEventAsync(EventModel eventModel);

    public void BookEventAsync(EventModel eventModel, UserModel user);

    public void AddUserToEventDb(ApplicationUser user);
}
