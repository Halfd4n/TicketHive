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
        private int DesiredNoOfTickets { get; set; }
        private EventModel? EventToDisplay { get; set; } = new();
        private decimal Price { get; set; }
        private string? CurrencyCode { get; set; }

        private bool IsShowingModal { get; set; }
        private bool SuccessfullDelete { get; set; }

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
        }

        public void ShowModal()
        {

            IsShowingModal = true;
            StateHasChanged();
        }

        public void CloseModal()
        {
            IsShowingModal = false;
            StateHasChanged();
        }

        public async Task DeleteEvent(EventModel eventModel)
        {
            SuccessfullDelete = await eventService.DeleteEventAsync(eventModel.Id);

            IsShowingModal = false;

            navigationManager.NavigateTo("/allevents");
        }
    }
}