using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketHive.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialMainDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    NumberOfTickets = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Host = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventModelUserModel",
                columns: table => new
                {
                    BookingsId = table.Column<int>(type: "int", nullable: false),
                    VisitorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventModelUserModel", x => new { x.BookingsId, x.VisitorsId });
                    table.ForeignKey(
                        name: "FK_EventModelUserModel_Events_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventModelUserModel_Users_VisitorsId",
                        column: x => x.VisitorsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EventType", "Host", "ImageUrl", "Name", "NumberOfTickets", "Price" },
                values: new object[,]
                {
                    { 1, "A concert featuring various artists in the local park", 0, "The local community council", "~/images/event images/image 1.avif", "Concert in the park", 1000, 350m },
                    { 2, "A new exhibit featuring local artists", 1, "The local art museum", "~/images/event images/image 2.avif", "Art exhibit opening", 500, 100m },
                    { 3, "A wine tasting featuring local wineries", 2, "The Wine Association", "~/images/event images/image 3.avif", "Wine tasting", 300, 200m },
                    { 4, "A charity run to raise funds for local causes", 3, "The local sports association", "~/images/event images/image 4.avif", "Charity run", 2000, 800m },
                    { 5, "A comedy show featuring local comedians", 4, "The Comedy Club", "~/images/event images/image 5.avif", "Comedy show", 500, 100m },
                    { 6, "A film festival showcasing international films", 5, "The Film Society", "~/images/event images/image 6.avif", "Film festival", 120, 300m },
                    { 7, "A music festival featuring international musicians", 6, "Music Association", "~/images/event images/image 7.avif", "Local music festival", 5000, 1500m },
                    { 8, "A fair featuring local artisans selling their crafts", 7, "Local artisans association", "~/images/event images/image 8.avif", "Artisan fair", 1000, 50m },
                    { 9, "A one day class on theater production of a classic play", 10, "Educate Theater Association", "~/images/event images/image 9.avif", "Theater production", 100, 1200m },
                    { 10, "A day of family fun featuring various activities for kids and adults", 8, "The local community center", "~/images/event images/image 10.avif", "Family fun day", 350, 80m },
                    { 11, "A science fair featuring local scientists and their research", 9, "The local science museum", "~/images/event images/image 11.avif", "Science fair", 1000, 50m },
                    { 12, "A fashion show featuring various international designers", 4, "The Fashion association", "~/images/event images/image 12.avif", "Fashion show", 300, 450m },
                    { 13, "A formal gala dinner featuring gourmet cuisine and live entertainment", 2, "Food&Wine Inc", "~/images/event images/image 13.avif", "Gala dinner", 300, 1500m },
                    { 14, "A lecture series featuring renowned speakers on various topics", 1, "The local university", "~/images/event images/image 14.avif", "Lecture series", 500, 90m },
                    { 15, "A tech meetup featuring local tech entrepreneurs and their startups", 11, "Local startup incubator", "~/images/event images/image 15.avif", "Tech meetup", 50, 900m },
                    { 16, "A trivia night featuring various categories and fine prizes", 12, "The local pub", "~/images/event images/image 16.avif", "Trivia night", 70, 150m },
                    { 17, "A party featuring international DJ:s and live entertainment", 13, "The local nightclub", "~/images/event images/image 17.avif", "DJ party", 400, 250m },
                    { 18, "An art workshop featuring a local artist teaching a new technique", 14, "The local art school", "~/images/event images/image 18.avif", "Art workshop", 50, 100m },
                    { 19, "A screening of a new surprise movie with Q&A session with the director", 5, "The local movie theatre", "~/images/event images/image 19.avif", "Movie screening", 70, 200m },
                    { 20, "A charity walk to raise funds for a local charity", 3, "Local community organizatio", "~/images/event images/image 20.avif", "Charity walk", 1500, 0m },
                    { 21, "A night of stand-up comedy featuring local comedians", 4, "The local comedy club", "~/images/event images/image 21.avif", "Comedy night", 200, 250m },
                    { 22, "A wine tasting event featuring local wineries", 2, "The local wine association", "~/images/event images/image 22.avif", "Wine tasting", 100, 300m },
                    { 23, "A fitness class featuring a local instructor", 15, "The local gym", "~/images/event images/image 23.avif", "Fitness class", 80, 100m },
                    { 24, "A tech workshop were you get to build your own miniature robot", 14, "International Robot Inc", "~/images/event images/image 24.avif", "Build your own robot", 1000, 1500m },
                    { 25, "An unplugged concert featuring various artists in the local park", 0, "The local community council", "~/images/event images/image 25.avif", "Unplugged concert", 1000, 350m },
                    { 26, "A new exhibit featuring local artists", 1, "The local art museum", "~/images/event images/image 26.avif", "Art exhibit opening", 500, 100m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventModelUserModel_VisitorsId",
                table: "EventModelUserModel",
                column: "VisitorsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventModelUserModel");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
