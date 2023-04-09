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

	// Functioning, but will be changed to not having to provide user id 
	public async Task<UserModel?> GetSignedInUserAsync(string userId)
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
		// Get signed in users country
		var signedInUserBefore = await GetSignedInUserAsync(userId);
		Country countryBefore = signedInUserBefore.Country;

		var countryAsJson = JsonConvert.SerializeObject(country);

		var response = await _client.PutAsJsonAsync($"api/users/{userId}/{countryAsJson}", countryAsJson);

		var signedInUserAfter = await GetSignedInUserAsync(userId);
		Country countryAfter = signedInUserAfter.Country;

		if (countryBefore != countryAfter)
		{
			return true;
		}

		return false;
	}

	// Not done yet!
	public async Task<bool> UpdateUserPasswordAsync(string userId, string currentPassword, string newPassword)
	{
		string[] passwordStrings = new string[2] { currentPassword, newPassword };

		var passwordsAsJson = JsonConvert.SerializeObject(passwordStrings);

		var response = await _client.PutAsJsonAsync($"api/users/{userId}", passwordsAsJson);

		if (response.IsSuccessStatusCode)
		{
			return true;
		}

		return false;
	}

	// Not done yet!
	public async Task<bool> DeleteUserAsync(string userId)
	{
		var response = await _client.DeleteAsync($"api/users/{userId}");

		if (response.IsSuccessStatusCode)
		{
			return true;
		}

		return false;
	}
}
