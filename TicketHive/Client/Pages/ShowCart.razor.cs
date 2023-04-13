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
using TicketHive.Shared.Models;
using Newtonsoft.Json;
using System.ComponentModel;

namespace TicketHive.Client.Pages
{
    public partial class ShowCart
    {
        public decimal TotalPrice { get; set; }
        public List<EventModel>? ShoppingCart { get; set; } = new();
        public List<EventModel>? AllEvents { get; set; } = new();

        protected async override Task OnInitializedAsync()
        {
            AllEvents = await _service.GetEventsAsync();

            if(AllEvents != null)
            {
                await CheckShoppingCartContent();
            }
        }

        private async Task CheckShoppingCartContent()
        {
            ShoppingCart.Clear();

            foreach (EventModel eventModel in AllEvents)
            {
                string jsonCart = await localStorage.GetItemAsStringAsync(eventModel.Id.ToString());

                if (!String.IsNullOrWhiteSpace(jsonCart))
                {
                    EventModel eventFromLocal = JsonConvert.DeserializeObject<EventModel>(jsonCart);

                    ShoppingCart.Add(eventFromLocal);
                }
            }
        }

        private bool AreThereAvailableTickets(EventModel eventModel)
        {
            EventModel? eventToCheck = AllEvents.Find(e => e.Id.Equals(eventModel.Id));

            if ((eventToCheck.NumberOfTickets - eventModel.NumberOfTickets) == 0)
            {
                return true;
            }

            return false;
        }


        private async void IncrementTickets(EventModel eventModel)
        {
            eventModel.NumberOfTickets++;

            string jsonEvent = JsonConvert.SerializeObject(eventModel);

            await localStorage.SetItemAsStringAsync(eventModel.Id.ToString(), jsonEvent);

            await CheckShoppingCartContent();

            StateHasChanged();
        }

        private async Task DecrementTickets(EventModel eventModel)
        {
            eventModel.NumberOfTickets--;

            if(eventModel.NumberOfTickets >= 1)
            {
                string jsonEvent = JsonConvert.SerializeObject(eventModel);

                await localStorage.SetItemAsStringAsync(eventModel.Id.ToString(), jsonEvent);

                await CheckShoppingCartContent();

                StateHasChanged();
            }
            else
            {
                RemoveEvent(eventModel);
            }
        }

        private async void RemoveEvent(EventModel eventToRemove)
        {
            if(eventToRemove != null)
            {
                await localStorage.RemoveItemAsync(eventToRemove.Id.ToString());
            }

            await CheckShoppingCartContent();

            StateHasChanged();
        }
    }
}