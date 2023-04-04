using Newtonsoft.Json;
using System.Net.Http.Json;
using TicketHive.Shared.Models;

namespace TicketHive.Client.Services;

public class EventService : IEventService
{
    private readonly HttpClient _client;

    public EventService(HttpClient client)
    {
        _client = client;
    }

    public async Task AddEventAsync(EventModel eventModel)
    {
        await _client.PostAsJsonAsync("api/events", eventModel);
    }

    public async Task BookEventAsync(int eventId, UserModel user)
    {
        // --- Osäker på vilka datatyper och objekt samt hur dessa ska passas vidare till APIt. I detta fall skickas event
        // id med genom URL'en och UserModel som genomför bokning skickas med genom body'n. Vet ej vad som är best practice.

        await _client.PostAsJsonAsync($"api/events/{eventId}", user);
    }


    public async Task DeleteEventAsync(int id)
    {
        await _client.DeleteAsync($"api/events/{id}");
    }

    public async Task<List<EventModel>?> GetAllEventsAsync()
    {
        var response = await _client.GetAsync("api/events");

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

    public async Task<EventModel?> GetOneEventAsync(int id)
    {
        var response = await _client.GetAsync($"api/events/{id}");

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
}
