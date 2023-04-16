using Newtonsoft.Json;
using System.Net.Http.Json;
using TicketHive.Server.Enums;
using TicketHive.Shared.Models;

namespace TicketHive.Client.Services;

public class EventService : IEventService
{
    private readonly HttpClient _client;

    public EventService(HttpClient client)
    {
        _client = client;
    }

    public async Task<EventModel?> GetEventAsync(int eventId)
    {
        var response = await _client.GetAsync($"api/Events/{eventId}");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<EventModel>(json);
        }
        else
        {
            Console.WriteLine(response.Content);
        }

        return null;
    }

    public async Task<List<EventModel>?> GetEventsAsync()
    {
        var response = await _client.GetAsync("api/Events");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<EventModel>>(json);
        }
        else
        {
            Console.WriteLine(response.Content);
        }

        return null;
    }

    public async Task<bool> AddEventAsync(EventModel eventModel)
    {
        var response = await _client.PostAsJsonAsync("api/Events", eventModel);

        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        return false;
    }

    public async Task<bool> DeleteEventAsync(int eventId)
    {
        var response = await _client.DeleteAsync($"api/Events/{eventId}");

        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        else
        {
            Console.WriteLine(response.Content);
            return false;
        }
    }

    public async Task<bool> BookEventAsync(string userId, int eventId, int quantity)
    {
        EventModel? eventBefore = await GetEventAsync(eventId);
        int numberOfBookingsBefore = eventBefore!.Bookings.Count;

        string[] parameters = new string[2] { eventId.ToString(), quantity.ToString() };

        await _client.PostAsJsonAsync($"api/Events/{userId}/{parameters}", parameters);

        EventModel? eventAfter = await GetEventAsync(eventId);
        int numberOfBookingsAfter = eventAfter!.Bookings.Count;

        if (numberOfBookingsAfter > numberOfBookingsBefore)
        {
            return true;
        }

        return false;
    }

}

