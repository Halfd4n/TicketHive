using Microsoft.AspNetCore.Mvc;
using TicketHive.Server.Data;
using TicketHive.Shared.Models;

namespace TicketHive.Server.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        public EventController(MainDbContext context)
        {
            Context = context;
        }

        public MainDbContext Context { get; }

        [HttpGet]
        public async Task<ActionResult<List<EventModel>>> GetEvents()
        {
            return Context.Events.ToList();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EventModel>> GetSingleEvent(int id)
        {
           var singleEvent = Context.Events.FirstOrDefault(p => p.Id == id);

            if(singleEvent == null)
            {
                return NotFound("sorry bro, nothing here");
            }
            else
            {
                return Ok(singleEvent);
            }
        }
    }
}
