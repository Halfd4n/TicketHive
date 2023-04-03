﻿namespace TicketHive.Shared.Models;
public class UserModel
{
	public int Id { get; set; }
	public string Username { get; set; } = null!;
	public List<EventModel> Bookings { get; set; } = new();
}
