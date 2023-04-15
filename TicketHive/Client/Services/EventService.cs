using Microsoft.AspNetCore.Mvc;
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

	// Not done yet!
	public async Task<bool> BookEventAsync(int eventId, UserModel user)
	{
		var response = await _client.PostAsJsonAsync($"api/Events/{eventId}", user);
		
		if (response.IsSuccessStatusCode)
		{
			return true;
		}

		return false;
	}

	public async Task<bool> AddEventAsync(EventModel eventModel)
	{
		var response = await _client.PostAsJsonAsync("api/Events", eventModel);

		if (response.IsSuccessStatusCode)
		{
			return true ;
		}
		else
		{
			return false;
		}
	}

	public async Task<bool> DeleteEventAsync(int eventId)
	{
		await _client.DeleteAsync($"api/Events/{eventId}");

		int numberOfEventsAfter = (await GetEventsAsync()).Count;

		if (numberOfEventsBefore > numberOfEventsAfter)
		{
			return true;
		}

		return false;
	}
}
