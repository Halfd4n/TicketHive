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

    public async Task UpdateUserPassword(int id, string currentPassword, string newPassword)
    {
        string[] passwordStrings = new string[2] { currentPassword, newPassword};

        await _client.PostAsJsonAsync($"api/users/{id}", passwordStrings);
    }

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
