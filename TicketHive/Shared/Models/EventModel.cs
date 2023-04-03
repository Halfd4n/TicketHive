using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Shared.Enums;

namespace TicketHive.Shared.Models;
public class EventModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public EventType EventType { get; set; }
    public int NumberOfTickets { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Host { get; set; }
    public string ImageUrl { get; set; }
    public List<UserModel> Visitors { get; set; } = new();

}
