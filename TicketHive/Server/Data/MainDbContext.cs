using Microsoft.EntityFrameworkCore;
using TicketHive.Shared.Enums;
using TicketHive.Shared.Models;

namespace TicketHive.Server.Data
{
	public class MainDbContext : DbContext
	{
		public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
		{

		}


		// Define tables in the database 
		public DbSet<UserModel> Users { get; set; }
		public DbSet<EventModel> Events { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//// Configure the EventType enum data to be stored as strings in the database 
			//modelBuilder.Entity<EventModel>()
			//	.Property(e => e.EventType)
			//	.HasConversion<string>();

			// Configure the Price decimal data to be stored as decimal(8, 2) in the database 
			modelBuilder.Entity<EventModel>()
				.Property(e => e.Price)
				.HasColumnType("decimal(8, 2)");

			modelBuilder.Entity<EventModel>().HasData(
				new EventModel()
				{
					Id = 1,
					Name = "Concert in the park",
					EventType = EventType.Concert,
					NumberOfTickets = 1000,
					Description = "A concert featuring various artists in the local park",
					Price = 350,
					Host = "The local community council",
					ImageUrl = "~/images/event images/image 1.avif"
				},
				new EventModel()
				{
					Id = 2,
					Name = "Art exhibit opening",
					EventType = EventType.Exhibition,
					NumberOfTickets = 500,
					Description = "A new exhibit featuring local artists",
					Price = 100,
					Host = "The local art museum",
					ImageUrl = "~/images/event images/image 2.avif"
				},
				new EventModel()
				{
					Id = 3,
					Name = "Wine tasting",
					EventType = EventType.Tasting,
					NumberOfTickets = 300,
					Description = "A wine tasting featuring local wineries",
					Price = 200,
					Host = "The Wine Association",
					ImageUrl = "~/images/event images/image 3.avif"
				},
				new EventModel()
				{
					Id = 4,
					Name = "Charity run",
					EventType = EventType.Fundraiser,
					NumberOfTickets = 2000,
					Description = "A charity run to raise funds for local causes",
					Price = 800,
					Host = "The local sports association",
					ImageUrl = "~/images/event images/image 4.avif"
				},
				new EventModel()
				{
					Id = 5,
					Name = "Comedy show",
					EventType = EventType.Show,
					NumberOfTickets = 500,
					Description = "A comedy show featuring local comedians",
					Price = 100,
					Host = "The Comedy Club",
					ImageUrl = "~/images/event images/image 5.avif"
				},
				new EventModel()
				{
					Id = 6,
					Name = "Film festival",
					EventType = EventType.Cinema,
					NumberOfTickets = 120,
					Description = "A film festival showcasing international films",
					Price = 300,
					Host = "The Film Society",
					ImageUrl = "~/images/event images/image 6.avif"
				},
				new EventModel()
				{
					Id = 7,
					Name = "Local music festival",
					EventType = EventType.Festival,
					NumberOfTickets = 5000,
					Description = "A music festival featuring international musicians",
					Price = 1500,
					Host = "Music Association",
					ImageUrl = "~/images/event images/image 7.avif"
				},
				new EventModel()
				{
					Id = 8,
					Name = "Artisan fair",
					EventType = EventType.Market,
					NumberOfTickets = 1000,
					Description = "A fair featuring local artisans selling their crafts",
					Price = 50,
					Host = "Local artisans association",
					ImageUrl = "~/images/event images/image 8.avif"
				},
				new EventModel()
				{
					Id = 9,
					Name = "Theater production",
					EventType = EventType.Lecture,
					NumberOfTickets = 100,
					Description = "A one day class on theater production of a classic play",
					Price = 1200,
					Host = "Educate Theater Association",
					ImageUrl = "~/images/event images/image 9.avif"
				},
				new EventModel()
				{
					Id = 10,
					Name = "Family fun day",
					EventType = EventType.Family,
					NumberOfTickets = 350,
					Description = "A day of family fun featuring various activities for kids and adults",
					Price = 80,
					Host = "The local community center",
					ImageUrl = "~/images/event images/image 10.avif"
				},
				new EventModel()
				{
					Id = 11,
					Name = "Science fair",
					EventType = EventType.Fair,
					NumberOfTickets = 1000,
					Description = "A science fair featuring local scientists and their research",
					Price = 50,
					Host = "The local science museum",
					ImageUrl = "~/images/event images/image 11.avif"
				},
				new EventModel()
				{
					Id = 12,
					Name = "Fashion show",
					EventType = EventType.Show,
					NumberOfTickets = 300,
					Description = "A fashion show featuring various international designers",
					Price = 450,
					Host = "The Fashion association",
					ImageUrl = "~/images/event images/image 12.avif"
				},
				new EventModel()
				{
					Id = 13,
					Name = "Gala dinner",
					EventType = EventType.Tasting,
					NumberOfTickets = 300,
					Description = "A formal gala dinner featuring gourmet cuisine and live entertainment",
					Price = 1500,
					Host = "Food&Wine Inc",
					ImageUrl = "~/images/event images/image 13.avif"
				},
				new EventModel()
				{
					Id = 14,
					Name = "Lecture series",
					EventType = EventType.Exhibition,
					NumberOfTickets = 500,
					Description = "A lecture series featuring renowned speakers on various topics",
					Price = 90,
					Host = "The local university",
					ImageUrl = "~/images/event images/image 14.avif"
				},
				new EventModel()
				{
					Id = 15,
					Name = "Tech meetup",
					EventType = EventType.MeetUp,
					NumberOfTickets = 50,
					Description = "A tech meetup featuring local tech entrepreneurs and their startups",
					Price = 900,
					Host = "Local startup incubator",
					ImageUrl = "~/images/event images/image 15.avif"
				},
				new EventModel()
				{
					Id = 16,
					Name = "Trivia night",
					EventType = EventType.Quiz,
					NumberOfTickets = 70,
					Description = "A trivia night featuring various categories and fine prizes",
					Price = 150,
					Host = "The local pub",
					ImageUrl = "~/images/event images/image 16.avif"
				},
				new EventModel()
				{
					Id = 17,
					Name = "DJ party",
					EventType = EventType.Party,
					NumberOfTickets = 400,
					Description = "A party featuring international DJ:s and live entertainment",
					Price = 250,
					Host = "The local nightclub",
					ImageUrl = "~/images/event images/image 17.avif"
				},
				new EventModel()
				{
					Id = 18,
					Name = "Art workshop",
					EventType = EventType.Workshop,
					NumberOfTickets = 50,
					Description = "An art workshop featuring a local artist teaching a new technique",
					Price = 100,
					Host = "The local art school",
					ImageUrl = "~/images/event images/image 18.avif"
				},
				new EventModel()
				{
					Id = 19,
					Name = "Movie screening",
					EventType = EventType.Cinema,
					NumberOfTickets = 70,
					Description = "A screening of a new surprise movie with Q&A session with the director",
					Price = 200,
					Host = "The local movie theatre",
					ImageUrl = "~/images/event images/image 19.avif"
				},
				new EventModel()
				{
					Id = 20,
					Name = "Charity walk",
					EventType = EventType.Fundraiser,
					NumberOfTickets = 1500,
					Description = "A charity walk to raise funds for a local charity",
					Price = 0,
					Host = "Local community organizatio",
					ImageUrl = "~/images/event images/image 20.avif"
				},
				new EventModel()
				{
					Id = 21,
					Name = "Comedy night",
					EventType = EventType.Show,
					NumberOfTickets = 200,
					Description = "A night of stand-up comedy featuring local comedians",
					Price = 250,
					Host = "The local comedy club",
					ImageUrl = "~/images/event images/image 21.avif"
				},
				new EventModel()
				{
					Id = 22,
					Name = "Wine tasting",
					EventType = EventType.Tasting,
					NumberOfTickets = 100,
					Description = "A wine tasting event featuring local wineries",
					Price = 300,
					Host = "The local wine association",
					ImageUrl = "~/images/event images/image 22.avif"
				},
				new EventModel()
				{
					Id = 23,
					Name = "Fitness class",
					EventType = EventType.Exercize,
					NumberOfTickets = 80,
					Description = "A fitness class featuring a local instructor",
					Price = 100,
					Host = "The local gym",
					ImageUrl = "~/images/event images/image 23.avif"
				},
				new EventModel()
				{
					Id = 24,
					Name = "Build your own robot",
					EventType = EventType.Workshop,
					NumberOfTickets = 1000,
					Description = "A tech workshop were you get to build your own miniature robot",
					Price = 1500,
					Host = "International Robot Inc",
					ImageUrl = "~/images/event images/image 24.avif"
				},
				new EventModel()
				{
					Id = 25,
					Name = "Unplugged concert",
					EventType = EventType.Concert,
					NumberOfTickets = 1000,
					Description = "An unplugged concert featuring various artists in the local park",
					Price = 350,
					Host = "The local community council",
					ImageUrl = "~/images/event images/image 25.avif"
				},
				new EventModel()
				{
					Id = 26,
					Name = "Contemporary Art Show",
					EventType = EventType.Exhibition,
					NumberOfTickets = 200,
					Description = "An art exhibition featuring international works of art",
					Price = 300,
					Host = "The local art museum",
					ImageUrl = "~/images/event images/image 26.avif"
				});
		}
	}
}
