using Microsoft.EntityFrameworkCore;
using TicketHive.Server.Data;
using TicketHive.Server.Models;
using TicketHive.Shared.Models;

namespace TicketHive.Server.Repositories;

public class EventRepository : IEventRepository 
{
    private readonly MainDbContext _context;

    public EventRepository(MainDbContext context)
    {
        _context = context;
    }

    public EventModel? GetEventById(int id)
    {
        return _context.Events.FirstOrDefault(e => e.Id == id);
    }

    public async Task<List<EventModel>?> GetAllEventsAsync()
    {
        return await _context.Events.ToListAsync();
    }

    public async void AddEventAsync(EventModel eventModel)
    {
        _context.Add(eventModel);

        await _context.SaveChangesAsync();
    }

    public async void DeleteEventAsync(EventModel eventModel)
    {
        _context.Events.Remove(eventModel);

        await _context.SaveChangesAsync();
    }

    public void BookEventAsync(EventModel eventModel, UserModel user)
    {
        
    }

    public async void AddUserToEventDb(ApplicationUser user)
    {
        UserModel userModel = new()
        {
            Id = user.Id,
            Username = user.UserName!,
            Country = user.Country
        };

        await _context.Users.AddAsync(userModel);

        _context.SaveChanges();
    }
}
