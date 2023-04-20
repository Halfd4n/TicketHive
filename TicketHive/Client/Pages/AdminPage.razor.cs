using TicketHive.Shared.Models;

namespace TicketHive.Client.Pages
{
    public partial class AdminPage
    {

        private bool isEventAddedSuccessFully { get; set; }

        private string? ResponseMessage { get; set; }
        private EventModel newEvent = new()
        {

            NumberOfTickets = 1,
            StartTime = DateTime.Now,
            EndTime = DateTime.Now.AddDays(1)
        };

        public DateTime StartHoursAndMinutes { get; set; } = new();
        public DateTime EndHoursAndMinutes { get; set; } = new();

        private async Task AddEvent()
        {
            try
            {

                newEvent.ImageUrl = $"image {new Random().Next(1, 27)}.png";

                newEvent.StartTime = new DateTime(newEvent.StartTime.Year,
                                    newEvent.StartTime.Month,
                                    newEvent.StartTime.Day,
                                    StartHoursAndMinutes.Hour,
                                    StartHoursAndMinutes.Minute,
                                    newEvent.StartTime.Second);

                newEvent.EndTime = new DateTime(newEvent.EndTime.Year,
                                  newEvent.EndTime.Month,
                                  newEvent.EndTime.Day,
                                  EndHoursAndMinutes.Hour,
                                  EndHoursAndMinutes.Minute,
                                  newEvent.EndTime.Second);

                EventModel addedEventModel = await eventService.AddEventAsync(newEvent);

                addedEventModel = await eventService.AddEventAsync(newEvent);

                if (addedEventModel != null)
                {
                    ResponseMessage = "Event was successfully added to the application!";
                    StateHasChanged();

                }
                else
                {
                    ResponseMessage = "Something went wrong, please try again";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}