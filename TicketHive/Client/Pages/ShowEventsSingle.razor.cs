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
using Newtonsoft.Json;
using TicketHive.Client.Services;
using TicketHive.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace TicketHive.Client.Pages
{
    [BindProperties]
    public partial class ShowEventsSingle
    {
        [Parameter]
        public int Id { get; set; }
        public int DesiredNoOfTickets { get; set; }
        public EventModel? EventToDisplay { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            EventToDisplay = await eventService.GetEventAsync(Id);
        }

        public async Task AddToCart()
        {


            if(EventToDisplay != null)
            {
                EventToDisplay.NumberOfTickets = DesiredNoOfTickets;

                string jsonEvent = JsonConvert.SerializeObject(EventToDisplay);

                await localStorage.SetItemAsStringAsync(EventToDisplay.Id.ToString(), jsonEvent);
            }
        }

        public async Task DeleteEvent()
        {

        }
    }
}