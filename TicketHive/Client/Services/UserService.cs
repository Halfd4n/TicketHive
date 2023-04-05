using Newtonsoft.Json;
using System.Net.Http.Json;
using TicketHive.Shared.Models;

namespace TicketHive.Client.Services;

public class UserService : IUserService
{
	private readonly HttpClient _client;

	public UserService(HttpClient client)
	{
		_client = client;
	}
	public Task UpdateUserCountry()
	{
		throw new NotImplementedException();
	}

	public async Task UpdateUserPassword(string id, string currentPassword, string newPassword)
	{
		string[] passwordStrings = new string[2] { currentPassword, newPassword };

		await _client.PutAsJsonAsync($"api/users/{id}", passwordStrings);


	}

	// TODO: fix false response.IsSuccessStatusCode 
	public async Task<UserModel?> GetUserByIdAsync(string id)
	{
		var response = await _client.GetAsync($"api/users/{id}");

		if (response.IsSuccessStatusCode)
		{
			var json = await response.Content.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<UserModel>(json);
		}

		return null;
	}
}
