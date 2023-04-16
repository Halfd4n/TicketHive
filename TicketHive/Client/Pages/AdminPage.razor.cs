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

        private EventModel newEvent = new(){
            NumberOfTickets = 1,
            StartTime = DateTime.Now,
            EndTime = DateTime.Now.AddDays(1)
        };

        //private EventType eventType { get; set; } = new();
        private bool showAlert = false;

        private string alertMessage;

        //private int selectedId;
        private string alertType;
        //protected override async Task OnInitializedAsync(){
        //    allEvents = await eventService.GetEventsAsync();
        //}


        private async Task AddEvent(){
            try{
                showAlert = true;
                // Add a random picture to the event
                newEvent.ImageUrl = $"image {new Random().Next(1, 27)}.png";

                bool isEventAddedSuccessFully = await eventService.AddEventAsync(newEvent);

                if (isEventAddedSuccessFully){
                    alertMessage = newEvent.Name + "The event has been added!";
                    alertType = "Success!";
                    allEvents.Add(newEvent);
                }
                else{
                    alertMessage = "Something went wrong, try again!";
                    alertType = "Warning";
                }
            }
            catch (Exception ex){
                // handle the exception and print out an error message
                alertMessage = "An error occurred while adding the event: " + ex.Message;
                alertType = "Error";
            }
        }
    }
}