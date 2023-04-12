using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using TicketHive.Server.Enums;
using TicketHive.Shared.Models;

namespace TicketHive.Client.Pages;

[BindProperties]
public partial class Settings
{
	[Parameter]
	public string Id { get; set; } = null!;


	public UserModel? SignedInUser { get; set; } = new();
	public Dictionary<string, string> ValidationErrors { get; private set; } = new();
	public Dictionary<string, string> SuccessMessage { get; private set; } = new();

    [Required]
	public Country Country { get; set; }

	[Required(ErrorMessage = "Please input your password")]
    public string? CurrentPassword { get; set; }

    [Required(ErrorMessage = "Please input new desired password")]
	public string? NewPassword { get; set; }


	protected async override Task OnInitializedAsync()
	{
		ValidationErrors.Clear();
        SuccessMessage.Clear();

        SignedInUser = await _service.GetUserByIdAsync(Id);

		if(SignedInUser != null)
		{
            Country = SignedInUser.Country;
        }
    }

	private async Task UpdateCountryOfOrigin()
	{
		ValidationErrors.Clear();
        SuccessMessage.Clear();

        if (Country.Equals(Country.Countries))
		{
            ValidationErrors["noSelection"] = "You haven't selected a country";
        }
        else if(SignedInUser.Country == Country)
		{
			ValidationErrors["sameSelection"] = "Your country of origin hasn't changed";
		}
		else
		{
            await _service.UpdateUserCountryAsync(SignedInUser.Id, Country);

			SuccessMessage["changedCountry"] = $"Your country of origin was set to {Country.ToString()}";
        }
	}
	    

	private async Task UpdatePassword()
	{
		ValidationErrors.Clear();
		SuccessMessage.Clear();

		if (string.IsNullOrWhiteSpace(CurrentPassword))
		{
			ValidationErrors["noInput"] = "Please input your password";
        }
		else if (string.IsNullOrWhiteSpace(NewPassword))
		{
			ValidationErrors["noInput"] = "Please input new desired password";
        }
		else
		{
			await _service.UpdateUserPasswordAsync(Id, CurrentPassword, NewPassword);

			SuccessMessage["changedPassword"] = "You successfully updated your password";
		}
	}

	private async Task BackToMain()
	{
		_navigation.NavigateTo("/");
	}
}
