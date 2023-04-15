using TicketHive.Shared.Models;

namespace TicketHive.Client.Pages;

public partial class Index
{

    public string? UserName { get; set; }
    public string? SignedInUsersId { get; set; }
    public List<BookingModel>? SignedInUsersBookings { get; set; } = new();
    public List<EventModel>? AllEventsInDb { get; set; } = new();
    public List<EventModel> AllEventsButBooked { get; set; } = new();
    public List<int> uniqueNumbers { get; set; } = new();
    public List<EventModel> RandomEvents { get; set; } = new();

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

                AllEventsInDb = await eventService.GetEventsAsync();

                foreach (EventModel eventModel in AllEventsInDb)
                {
                    if (!SignedInUsersBookings.Any(b => b.EventId == eventModel.Id))
                    {
                        AllEventsButBooked.Add(eventModel);
                    }
                }

                Random random = new Random();

                while (uniqueNumbers.Count < 5)
                {
                    int randomIndex = random.Next(AllEventsButBooked.Count);

                    if (!uniqueNumbers.Contains(randomIndex))
                    {
                        uniqueNumbers.Add(randomIndex);
                    }
                }

                foreach (int number in uniqueNumbers)
                {
                    EventModel randomEvent = AllEventsButBooked[number];

                    RandomEvents.Add(randomEvent);
                }
            }
        }

        //CurrencyManager.CurrencyApiCall();
    }

    private void Login()
    {
        navigationManager.NavigateTo("authentication/login");
    }

    private void Register()
    {
        navigationManager.NavigateTo("authentication/register");
    }

    private void NavigateToEvent(int eventId)
    {
        navigationManager.NavigateTo($"/allEvents/{eventId}");
    }
}
