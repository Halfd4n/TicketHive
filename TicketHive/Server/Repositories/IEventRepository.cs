using TicketHive.Shared.Models;

namespace TicketHive.Server.Repositories;

public interface IEventRepository
{
	Task<EventModel?> GetEventByIdAsync(int id);
}
