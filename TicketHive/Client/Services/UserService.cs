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

	public async Task<UserModel?> GetUserAsync(string userId)
	{
		var response = await _client.GetAsync($"api/users/{userId}");

		if (response.IsSuccessStatusCode)
		{
			var json = await response.Content.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<UserModel>(json);
		}

		return null;
	}

	public async Task<HttpResponseMessage> UpdateUserCountryAsync(string userId, Country country)
	{
		return await _client.PutAsJsonAsync($"api/users/{userId}", country);
	}

	public async Task<HttpResponseMessage> UpdateUserPasswordAsync(string userId, string currentPassword, string newPassword)
	{
		string[] passwordStrings = new string[2] { currentPassword, newPassword };

		var passwordsAsJson = JsonConvert.SerializeObject(passwordStrings);

		HttpResponseMessage response = await _client.PutAsJsonAsync($"api/users/{userId}", passwordsAsJson);

		return response;
	}

	public async Task<HttpResponseMessage> DeleteUserAsync(string userId)
	{
		return await _client.DeleteAsync($"api/users/{userId}");
	}
}
