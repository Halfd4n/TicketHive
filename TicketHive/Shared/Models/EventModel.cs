using TicketHive.Shared.Enums;

namespace TicketHive.Shared.Models;
public class EventModel
{
	public int Id { get; set; }
	public string Name { get; set; } = null!;
	public EventType EventType { get; set; }
	public int NumberOfTickets { get; set; }
	public string Description { get; set; } = null!;
	public decimal Price { get; set; }
	public DateTime StartTime { get; set; }
	public DateTime EndTime { get; set; }
	public string Location { get; set; } = null!;
	public string Host { get; set; } = null!;
	public string ImageUrl { get; set; } = null!;
	public List<UserModel> Visitors { get; set; } = new();
}
