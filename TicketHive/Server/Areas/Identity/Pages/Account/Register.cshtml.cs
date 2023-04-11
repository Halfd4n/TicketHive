using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TicketHive.Server.Enums;
using TicketHive.Server.Models;
using TicketHive.Server.Repositories;
using TicketHive.Server.Repository;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace TicketHive.Server.Areas.Identity.Pages.Account
{

	[BindProperties]
	public class RegisterModel : PageModel
	{
		private readonly IUserRepository _userRepository;
		private readonly IEventRepository _eventRepository;

		[Required(ErrorMessage = "Please choose a username")]
		[MinLength(5, ErrorMessage = "A username must be at least 5 characters")]
		[MaxLength(12, ErrorMessage = "A username can't be more than 12 characters")]
		public string? Username { get; set; }

		[Required(ErrorMessage = "Please choose a password")]
		public string? Password { get; set; }

		[Required(ErrorMessage = "Please repeat your password")]
		[Compare(nameof(Password), ErrorMessage = "The passwords do not match")]
		public string? RepeatPassword { get; set; }

		[Required(ErrorMessage = "Please choose your country of origin")]
		public Country Country { get; set; }


		public RegisterModel(IUserRepository userRepository, IEventRepository eventRepository)
		{
			_userRepository = userRepository;
			_eventRepository = eventRepository;
		}

		public void OnGet()
		{
		}

		public async Task<IActionResult> OnPost()
		{
			if (ModelState.IsValid)
			{
				IdentityResult result = await _userRepository.RegisterUserAsync(Username!, Password!, Country);

				if (result.Succeeded)
				{
					SignInResult signInResult = await _userRepository.SignInUserAsync(Username!, Password!);

					ApplicationUser? signedInUser = await _userRepository.GetSignedInUser(Username!);

					if (signedInUser != null)
					{
						await _eventRepository.AddUserToEventDb(signedInUser);
					}

					if (signInResult.Succeeded)
					{
						RedirectToPage("~/index");
					}
				}
			}

			return Page();
		}
	}
}