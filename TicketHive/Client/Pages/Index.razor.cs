﻿

using TicketHive.Client.Managers;
using TicketHive.Shared.Models;

namespace TicketHive.Client.Pages;

public partial class Index
{

    public string? UserName { get; set; }
    public string SignedInUsersId { get; set; }
    public List<BookingModel> SignedInUsersBookings { get; set; } = new();
    public List<EventModel> SignedInUsersBookedEvents { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        var authenticationState = await authentication.GetAuthenticationStateAsync();

        var user = authenticationState.User;

        if (user.Identity.IsAuthenticated)
        {
            UserName = user.Identity.Name;

            SignedInUsersId = authenticationState.User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

            UserModel? userModel = await userService.GetUserByIdAsync(SignedInUsersId);

            if (userModel != null)
            {
                SignedInUsersBookings = userModel.Bookings;

                foreach (BookingModel booking in SignedInUsersBookings)
                {
                    EventModel eventModel = new(); // !!!*******************************************************************

                    eventModel = await eventService.GetEventAsync(booking.EventId);

                    SignedInUsersBookedEvents.Add(eventModel);
                }
            }
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
