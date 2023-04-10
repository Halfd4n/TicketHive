using Newtonsoft.Json;
using System.Net.Http.Json;
using TicketHive.Shared.Models;

namespace TicketHive.Client.Services;

public class EventService : IEventService
{
    private readonly HttpClient _client;

    List<EventModel> _events = new List<EventModel>();

    public EventService(HttpClient client)
    {
        _client = client;
    }

    public async Task AddEventAsync(EventModel eventModel)
    {
        await _client.PostAsJsonAsync("api/Event", eventModel);
    }

    public async Task BookEventAsync(int eventId, UserModel user)
    {
        // --- Osäker på vilka datatyper och objekt samt hur dessa ska passas vidare till APIt. I detta fall skickas event
        // id med genom URL'en och UserModel som genomför bokning skickas med genom body'n. Vet ej vad som är best practice.

        await _client.PostAsJsonAsync($"api/Event/{eventId}", user);
    }


    public async Task DeleteEventAsync(int id)
    {
        await _client.DeleteAsync($"api/event/{id}");
    }

    public async Task<List<EventModel>?> GetAllEventsAsync()
    {
        var response = await _client.GetFromJsonAsync<List<EventModel>>("api/Event");

        if (response != null)
        {
            _events = response.ToList();
            return _events;
        }
        else
        {
           
         return null;
        }

    }

    public async Task<EventModel?> GetOneEventAsync(int id)
    {
        var response = await _client.GetFromJsonAsync<EventModel>($"api/Event/{id}");


        if(response!= null)
        {
            return response;
        }
        else
        {
            return null;
        }

    }
}
