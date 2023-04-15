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
using TicketHive.Client.Managers;

namespace TicketHive.Client.Pages
{
    [BindProperties]
    public partial class ShowEventsSingle
    {
        [Parameter]
        public int Id { get; set; }
        public int DesiredNoOfTickets { get; set; }
        public EventModel? EventToDisplay { get; set; } = new();
        public decimal Price { get; set; }
        public string? CurrencyCode { get; set; }

        protected override async Task OnInitializedAsync()
        {
            EventToDisplay = await eventService.GetEventAsync(Id);

            UserModel? user = await GetSignedInUser();

            if(user != null)
            {
                Price = CurrencyManager.GetConvertedTicketPrice(user.Country, EventToDisplay.Price);
                CurrencyCode = CurrencyManager.GetCurrencyAbbreviation(user.Country);
            }
        }

        private async Task<UserModel?> GetSignedInUser()
        {
            var authenticationState = await authentication.GetAuthenticationStateAsync();

            var userId = authenticationState.User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

            if(userId != null)
            {
                return await userService.GetUserByIdAsync(userId!);
            }

            return null;
        }

        public async Task AddToCart()
        {
            if(EventToDisplay != null)
            {
                EventToDisplay.NumberOfTickets = DesiredNoOfTickets;

                string jsonEvent = JsonConvert.SerializeObject(EventToDisplay);

                await localStorage.SetItemAsStringAsync(EventToDisplay.Id.ToString(), jsonEvent);                
            }
            //string script = "$(function() { $('#myModal').modal('show'); });";
            //Sh.ClientScript.RegisterStartupScript(this.GetType(), "ShowModalScript", script, true);
        }

        public async Task DeleteEvent()
        {

        }
    }
}