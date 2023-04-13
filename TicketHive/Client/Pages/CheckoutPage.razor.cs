using TicketHive.Shared.Models;
using Newtonsoft.Json;

namespace TicketHive.Client.Pages;

public partial class CheckoutPage
{
    public List<EventModel> MyTickets { get; set; } = new();
    public List<EventModel>? AllEvents { get; set; } = new();
    public decimal TotalCost { get; set; }
    public UserModel? SignedInUser { get; set; } = new();
    
    protected async override Task OnInitializedAsync()
    {
        AllEvents = await _eventService.GetEventsAsync();

        if(AllEvents != null)
        {
            await CheckShoppingCartContent();
        }

        CalculateTotalCost();

        var authenticationState = await _authentication.GetAuthenticationStateAsync();

        var userId = authenticationState.User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

        SignedInUser = await _userService.GetUserByIdAsync(userId);

    }

    private async Task CheckShoppingCartContent()
    {
        foreach (EventModel eventModel in AllEvents!)
        {
            string jsonCart = await _storage.GetItemAsStringAsync(eventModel.Id.ToString());

            if (!String.IsNullOrWhiteSpace(jsonCart))
            {
                EventModel eventFromShoppingCart = JsonConvert.DeserializeObject<EventModel>(jsonCart);

                MyTickets.Add(eventFromShoppingCart);
            }
        }
    }

    private async Task ConfirmPurchase()
    {
        foreach(EventModel eventModel in MyTickets)
        {
            await _eventService.BookEventAsync(SignedInUser.Id, eventModel.Id, eventModel.NumberOfTickets);
        }

        await _storage.ClearAsync();

        _navigation.NavigateTo("/confirmed");
    }

    private void CalculateTotalCost()
    {
        foreach(EventModel eventModel in MyTickets)
        {
            TotalCost += (eventModel.Price * eventModel.NumberOfTickets);
        }
    }

    private void NavigateToEvents()
    {
        _navigation.NavigateTo("/allevents");
    }

    private void ReturnToShoppingCart()
    {
        _navigation.NavigateTo("/cart");
    }
}