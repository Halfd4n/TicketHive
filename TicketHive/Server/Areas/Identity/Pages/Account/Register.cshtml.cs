using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TicketHive.Server.Repository;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace TicketHive.Server.Areas.Identity.Pages.Account
{

    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        [Required(ErrorMessage = "Please choose a username")]
        [MinLength(5, ErrorMessage = "A username must be at least 5 characters")]
        [MaxLength(12, ErrorMessage = "A username can't be more than 12 characters")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Please choose a password")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Please repeat your password")]
        [Compare(nameof(Password), ErrorMessage = "The passwords do not match")]
        public string? RepeatPassword { get; set; }
        public RegisterModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _userRepository.RegisterUserAsync(Username!, Password!);

                if (result.Succeeded)
                {
                    SignInResult signInResult = await _userRepository.SignInUserAsync(Username!, Password!);

                    if (signInResult.Succeeded)
                    {
                        RedirectToPage("~/");
                    }
                }
            }

            return Page();
        }
    }
}