

using TicketHive.Client.Managers;

namespace TicketHive.Client.Pages;

public partial class Index
{

    public string? UserName { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var authenticationState = await authentication.GetAuthenticationStateAsync();

        var user = authenticationState.User;

        if (user.Identity.IsAuthenticated)
        {
            UserName = user.Identity.Name;
        }

        CurrencyManager.CurrencyApiCall();
    }

    private void Login()
    {
        navigationManager.NavigateTo("authentication/login");
    }

    private void Register()
    {
        navigationManager.NavigateTo("authentication/register");
    }
}
