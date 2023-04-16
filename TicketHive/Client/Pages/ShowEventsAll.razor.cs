using TicketHive.Server.Enums;
using TicketHive.Shared.Enums;
using TicketHive.Shared.Models;

namespace TicketHive.Client.Pages
{
    public partial class ShowEventsAll
    {
        //navigate to a site with current event id
        // see line 36 on frontend, where list > foreach > and then we send current Id to method
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
                // This will filter list if searchbar contains either name, location or price
                filteredEvents = allEvents.Where(e => e.Name.ToLower().Contains(searchTerm.ToLower())
                || e.EventType.ToString().ToLower().Contains(searchTerm.ToLower())
                || e.Location.ToLower().Contains(searchTerm.ToLower())
                || e.Price.ToString().Contains(searchTerm.ToLower())).ToList();
            }
        }

        private void FilterOrderByPrice()
        {
            // filter list by descending from highest price to lowest
            filteredEvents = allEvents.OrderByDescending(e => e.Price).ToList();
        }
        // filter list by start time of all events in list
        private void FilterOrderByDate()
        {
            filteredEvents = allEvents.OrderByDescending(e => e.StartTime).ToList();
        }

        // Get list 
        protected override async Task OnInitializedAsync()
        {
            allEvents = await eventService.GetEventsAsync();
            filteredEvents = allEvents;
        }
    }
}