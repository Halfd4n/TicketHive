using Newtonsoft.Json;
using System.Net.Http.Json;
using TicketHive.Server.Enums;
using TicketHive.Shared.Models;

namespace TicketHive.Client.Services;

public class UserService : IUserService
{
	private readonly HttpClient _client;

	public UserService(HttpClient client)
	{
		_client = client;
	}

	public async Task<UserModel?> GetUserByIdAsync(string userId)
	{
		var response = await _client.GetAsync($"api/users/{userId}");

		if (response.IsSuccessStatusCode)
		{
			var json = await response.Content.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<UserModel>(json);
		}

		return null;
	}

	public async Task<bool> UpdateUserCountryAsync(string userId, Country country)
	{
		var signedInUserBefore = await GetUserByIdAsync(userId);
		Country countryBefore = signedInUserBefore.Country;

		var countryAsJson = JsonConvert.SerializeObject(country);

		var response = await _client.PutAsJsonAsync($"api/users/{userId}/{countryAsJson}", countryAsJson);

		var signedInUserAfter = await GetUserByIdAsync(userId);
		Country countryAfter = signedInUserAfter.Country;

		if (countryBefore != countryAfter)
		{
			return true;
		}

		return false;
	}

	public async Task<HttpResponseMessage> UpdateUserPasswordAsync(string userId, string currentPassword, string newPassword)
	{
		string[] passwordStrings = new string[2] { currentPassword, newPassword };

		return await _client.PutAsJsonAsync($"api/users/{userId}", passwordStrings);
	}

	public async Task DeleteUserAsync(string userId)
	{
		var response = await _client.DeleteAsync($"api/users/{userId}");
	}
}
