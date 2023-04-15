using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using TicketHive.Shared.Models;

namespace TicketHive.Client.Shared;

public partial class NavMenu
{

    private void BeginLogOut()
    {
        Navigation.NavigateToLogout("authentication/logout", "");
    }

    private async Task NavigateToSettings()
    {
        var authenticationState = await authenticationStateProvider.GetAuthenticationStateAsync();

        var userId = authenticationState.User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

        UserModel? user = await _service.GetUserByIdAsync(userId);


        if (user != null)
        {
            Navigation.NavigateTo($"/settings/{user.Id}");
        }
        else
        {
            // Display some error message...
        }

    }

    private void NavigateToHome()
    {
        Navigation.NavigateTo("");
    }
    private void NavigateToAllEvents()
    {
        Navigation.NavigateTo("/allevents");
    }

    private void NavigateToShoppingCart()
    {
        Navigation.NavigateTo("/cart");
    }
}
