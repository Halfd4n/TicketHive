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

	public async Task<EventModel?> GetEventAsync(int eventId)
	{
		var response = await _client.GetAsync($"api/events/{eventId}");

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

	// Not done yet!
	public async Task<bool> BookEventAsync(int eventId, UserModel user)
	{
		// --- Osäker på vilka datatyper och objekt samt hur dessa ska passas vidare till APIt. I detta fall skickas event
		// id med genom URL'en och UserModel som genomför bokning skickas med genom body'n. Vet ej vad som är best practice. /Benjamin 

		var response = await _client.PostAsJsonAsync($"api/events/{eventId}", user);

		if (response.IsSuccessStatusCode)
		{
			return true;
		}

		return false;
	}

	// Not done yet!
	public async Task<bool> AddEventAsync(EventModel eventModel)
	{
		var response = await _client.PostAsJsonAsync("api/events", eventModel);

		if (response.IsSuccessStatusCode)
		{
			return true;
		}

		return false;
	}

	public async Task<bool> DeleteEventAsync(int eventId)
	{
		int numberOfEventsBefore = (await GetEventsAsync()).Count;

		await _client.DeleteAsync($"api/events/{eventId}");

		int numberOfEventsAfter = (await GetEventsAsync()).Count;

		if (numberOfEventsBefore > numberOfEventsAfter)
		{
			return true;
		}

		return false;
	}
}
