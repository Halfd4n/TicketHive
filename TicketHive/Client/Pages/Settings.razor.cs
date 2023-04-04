using Microsoft.AspNetCore.Components;
using TicketHive.Shared.Models;

namespace TicketHive.Client.Pages;

public partial class Settings
{
    [Parameter]
    public int Id { get; set; }

    protected async override Task OnInitializedAsync()
    {
        UserModel? user = await _service.GetUserByIdAsync(Id);
    }
}
