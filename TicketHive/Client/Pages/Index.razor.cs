

namespace TicketHive.Client.Pages;

public partial class Index
{
    private void Login()
    {
        navigationManager.NavigateTo("authentication/login");
    }

    private void Register()
    {
        navigationManager.NavigateTo("authentication/register");
    }
}
