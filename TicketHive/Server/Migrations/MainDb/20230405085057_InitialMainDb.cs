using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketHive.Server.Migrations.MainDb
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
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<int>(type: "int", nullable: false)
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
                    VisitorsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                columns: new[] { "Id", "Description", "EndTime", "EventType", "Host", "ImageUrl", "Location", "Name", "NumberOfTickets", "Price", "StartTime" },
                values: new object[,]
                {
                    { 1, "A concert featuring various artists in the local park", new DateTime(2023, 8, 1, 23, 0, 0, 0, DateTimeKind.Unspecified), 0, "The local community council", "~/images/event images/image 1.avif", "The local park", "Concert in the park", 1000, 350m, new DateTime(2023, 8, 1, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "A new exhibit featuring local artists", new DateTime(2023, 10, 14, 22, 0, 0, 0, DateTimeKind.Unspecified), 1, "The local art museum", "~/images/event images/image 2.avif", "Center Art Museum", "Art exhibit opening", 500, 100m, new DateTime(2023, 10, 14, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "A wine tasting featuring local wineries", new DateTime(2023, 8, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), 2, "The Wine Association", "~/images/event images/image 3.avif", "Hillside Wine Garden", "Wine tasting", 300, 200m, new DateTime(2023, 8, 20, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "A charity run to raise funds for local causes", new DateTime(2023, 12, 31, 22, 0, 0, 0, DateTimeKind.Unspecified), 3, "The local sports association", "~/images/event images/image 4.avif", "Downtown", "Charity run", 2000, 800m, new DateTime(2023, 12, 31, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "A comedy show featuring local comedians", new DateTime(2023, 11, 15, 21, 0, 0, 0, DateTimeKind.Unspecified), 4, "The Comedy Club", "~/images/event images/image 5.avif", "Central Comedy Club House", "Comedy show", 500, 100m, new DateTime(2023, 11, 15, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "A film festival showcasing international films", new DateTime(2023, 1, 5, 22, 0, 0, 0, DateTimeKind.Unspecified), 5, "The Film Society", "~/images/event images/image 6.avif", "Film Society Cinema", "Film festival", 120, 300m, new DateTime(2023, 1, 5, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "A music festival featuring international musicians", new DateTime(2023, 9, 11, 19, 0, 0, 0, DateTimeKind.Unspecified), 6, "Music Association", "~/images/event images/image 7.avif", "The local park", "Local music festival", 5000, 1500m, new DateTime(2023, 9, 11, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "A fair featuring local artisans selling their crafts", new DateTime(2023, 5, 21, 22, 0, 0, 0, DateTimeKind.Unspecified), 7, "Local artisans association", "~/images/event images/image 8.avif", "Downtown market place", "Artisan fair", 1000, 50m, new DateTime(2023, 5, 21, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "A one day class on theater production of a classic play", new DateTime(2023, 6, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), 10, "Educate Theater Association", "~/images/event images/image 9.avif", "Central library", "Theater production", 100, 1200m, new DateTime(2023, 6, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "A day of family fun featuring various activities for kids and adults", new DateTime(2023, 7, 30, 16, 0, 0, 0, DateTimeKind.Unspecified), 8, "The local community center", "~/images/event images/image 10.avif", "Community Hall", "Family fun day", 350, 80m, new DateTime(2023, 7, 30, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "A science fair featuring local scientists and their research", new DateTime(2023, 10, 18, 18, 0, 0, 0, DateTimeKind.Unspecified), 9, "The local science museum", "~/images/event images/image 11.avif", "The Central Museum", "Science fair", 1000, 50m, new DateTime(2023, 10, 18, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "A fashion show featuring various international designers", new DateTime(2023, 12, 15, 22, 0, 0, 0, DateTimeKind.Unspecified), 4, "The Fashion association", "~/images/event images/image 12.avif", "The Central Mall", "Fashion show", 300, 450m, new DateTime(2023, 12, 15, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "A formal gala dinner featuring gourmet cuisine and live entertainment", new DateTime(2023, 6, 30, 22, 0, 0, 0, DateTimeKind.Unspecified), 2, "Food&Wine Inc", "~/images/event images/image 13.avif", "Fine Food Restaurant", "Gala dinner", 300, 1500m, new DateTime(2023, 6, 30, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "A lecture series featuring renowned speakers on various topics", new DateTime(2023, 9, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), 1, "The local university", "~/images/event images/image 14.avif", "Central Library", "Lecture series", 500, 90m, new DateTime(2023, 9, 8, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "A tech meetup featuring local tech entrepreneurs and their startups", new DateTime(2023, 8, 17, 18, 0, 0, 0, DateTimeKind.Unspecified), 11, "Local startup incubator", "~/images/event images/image 15.avif", "The House of Incubator", "Tech meetup", 50, 900m, new DateTime(2023, 8, 17, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "A trivia night featuring various categories and fine prizes", new DateTime(2023, 10, 11, 23, 0, 0, 0, DateTimeKind.Unspecified), 12, "The DownTown Pub", "~/images/event images/image 16.avif", "The DownTown Pub", "Trivia night", 70, 150m, new DateTime(2023, 10, 11, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "A party featuring international DJ:s and live entertainment", new DateTime(2023, 11, 25, 23, 0, 0, 0, DateTimeKind.Unspecified), 13, "The local nightclub", "~/images/event images/image 17.avif", "The local nightclub", "DJ party", 400, 250m, new DateTime(2023, 11, 25, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "An art workshop featuring a local artist teaching a new technique", new DateTime(2023, 12, 9, 16, 0, 0, 0, DateTimeKind.Unspecified), 14, "The local art school", "~/images/event images/image 18.avif", "The Central School of Art", "Art workshop", 50, 100m, new DateTime(2023, 12, 9, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "A screening of a new surprise movie with Q&A session with the director", new DateTime(2023, 8, 5, 20, 0, 0, 0, DateTimeKind.Unspecified), 5, "The local movie theatre", "~/images/event images/image 19.avif", "The DownTown Movie Theater", "Movie screening", 70, 200m, new DateTime(2023, 8, 5, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "A charity walk to raise funds for a local charity", new DateTime(2023, 10, 20, 22, 0, 0, 0, DateTimeKind.Unspecified), 3, "Local community organizatio", "~/images/event images/image 20.avif", "Central town", "Charity walk", 1500, 0m, new DateTime(2023, 10, 20, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, "A night of stand-up comedy featuring local comedians", new DateTime(2023, 7, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), 4, "The HaveFun Comedy Club", "~/images/event images/image 21.avif", "The local comedy club", "Comedy night", 200, 250m, new DateTime(2023, 7, 28, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, "A wine tasting event featuring local wineries", new DateTime(2023, 5, 5, 22, 0, 0, 0, DateTimeKind.Unspecified), 2, "The local wine association", "~/images/event images/image 22.avif", "The local park", "Wine tasting", 100, 300m, new DateTime(2023, 5, 5, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, "A fitness class featuring a local instructor", new DateTime(2023, 10, 12, 20, 0, 0, 0, DateTimeKind.Unspecified), 15, "The local gym", "~/images/event images/image 23.avif", "The local park", "Fitness class", 80, 100m, new DateTime(2023, 10, 12, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, "A tech workshop were you get to build your own miniature robot", new DateTime(2023, 8, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), 14, "International Robot Inc", "~/images/event images/image 24.avif", "The local university", "Build your own robot", 1000, 1500m, new DateTime(2023, 8, 16, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, "An unplugged concert featuring various artists in the local park", new DateTime(2023, 11, 5, 22, 0, 0, 0, DateTimeKind.Unspecified), 0, "The local community council", "~/images/event images/image 25.avif", "The local park", "Unplugged concert", 1000, 350m, new DateTime(2023, 11, 5, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, "An art exhibition featuring international works of art", new DateTime(2023, 9, 17, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, "Fine Arts Association", "~/images/event images/image 26.avif", "The local arts gallery", "Contemporary Art Show", 200, 300m, new DateTime(2023, 9, 17, 17, 0, 0, 0, DateTimeKind.Unspecified) }
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
