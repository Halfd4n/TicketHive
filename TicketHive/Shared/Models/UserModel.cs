using System.ComponentModel.DataAnnotations;
using TicketHive.Server.Enums;

namespace TicketHive.Shared.Models;
public class UserModel
{
	[Key]
	public string Id { get; set; } = null!;
	public string Username { get; set; } = null!;
	public List<EventModel> Bookings { get; set; } = new();
    public Country Country { get; set; }
}
