using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketHive.Server.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDuplicateWineTastingEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Description", "EventType", "Host", "Location", "Name", "NumberOfTickets" },
                values: new object[] { "Learn the fundamentals of how pottery is made", 15, "The Pottery Arts Association", "The local pottery", "Pottery class", 50 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Description", "EventType", "Host", "Location", "Name", "NumberOfTickets" },
                values: new object[] { "A wine tasting event featuring local wineries", 3, "The local wine association", "The local park", "Wine tasting", 100 });
        }
    }
}
