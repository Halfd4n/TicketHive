using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using TicketHive.Shared.Models;

namespace TicketHive.Client.Pages;

[BindProperties]
public partial class Settings
{
    [Parameter]
    public string Id { get; set; }

    public string? CountryOfOrigin { get; set; }
    public string? CurrentPassword { get; set; }
    public string? NewPassword { get; set; }

    protected async override Task OnInitializedAsync()
    {
        UserModel? user = await _service.GetUserByIdAsync(Id);
    }
}
