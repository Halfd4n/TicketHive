using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace TicketHive.Client.Shared;

public partial class NavMenu
{

    private void BeginLogOut()
    {
        Navigation.NavigateToLogout("authentication/logout");
    }
}
