using TicketHive.Server.Enums;
using TicketHive.Shared.Enums;
using TicketHive.Shared.Models;

namespace TicketHive.Client.Pages
{
    public partial class ShowEventsAll
    {
        private async Task NavigateToEvent(int eventId)
        {
            navigationManager.NavigateTo($"/allEvents/{eventId}");
        }

        private EventType eventType = EventType.EventType;
        private Country countries { get; set; }

        private List<EventModel> allEvents = new();
        private List<EventModel> filteredEvents = new();
        private void FilterList(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                filteredEvents = allEvents;
            }
            else
            {
                filteredEvents = allEvents.Where(e => e.Name.ToLower().Contains(searchTerm.ToLower()) || e.EventType.ToString().ToLower().Contains(searchTerm.ToLower()) || e.Location.ToLower().Contains(searchTerm.ToLower()) || e.Price.ToString().Contains(searchTerm.ToLower())).ToList();
            }
        }

        private void FilterOrderByPrice()
        {
            filteredEvents = allEvents.OrderByDescending(e => e.Price).ToList();
        }

        private void FilterOrderByDate()
        {
            filteredEvents = allEvents.OrderByDescending(e => e.StartTime).ToList();
        }

        protected override async Task OnInitializedAsync()
        {
            allEvents = await eventService.GetEventsAsync();
            filteredEvents = allEvents;
        }
    }
}