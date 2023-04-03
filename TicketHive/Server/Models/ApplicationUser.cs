using Microsoft.AspNetCore.Identity;
using TicketHive.Server.Enums;

namespace TicketHive.Server.Models;
public class ApplicationUser : IdentityUser
{
	public Countries? Country { get; set; }
}
