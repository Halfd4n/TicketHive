using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using TicketHive.Client;
using TicketHive.Client.Shared;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authorization;
using TicketHive.Client.Services;
using TicketHive.Shared.Enums;
using TicketHive.Shared.Models;

namespace TicketHive.Client.Pages{
    public partial class AdminPage{

        private List<EventModel> allEvents;
        private string alertType;
        private bool isEventAddedSuccessFully { get; set; }
        private EventModel newEvent = new(){
            
            NumberOfTickets = 1,
            StartTime = DateTime.Now,
            EndTime = DateTime.Now.AddDays(1)
        };

        public DateTime StartHoursAndMinutes { get; set; } = new();
        public DateTime EndHoursAndMinutes { get; set; } = new();

        private async Task AddEvent(){
            try{
             
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

                bool isEventAddedSuccessFully = await eventService.AddEventAsync(newEvent);

                isEventAddedSuccessFully = await eventService.AddEventAsync(newEvent);

                if (isEventAddedSuccessFully)
                {
                    alertType = "Success!";
                    allEvents.Add(newEvent);
                    StateHasChanged();
                }
                else
                {
                    alertType = "Warning"; 
                }
            }
            catch (Exception ex)
            { 
                alertType = "Error";
            }
        }
    }
}