using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketHive.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventModelUserModel");

            migrationBuilder.CreateTable(
                name: "BookingModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventModelId = table.Column<int>(type: "int", nullable: true),
                    UserModelId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingModel_Events_EventModelId",
                        column: x => x.EventModelId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookingModel_Users_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 1, "image 1.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 2, "image 2.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 3, "image 3.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 4, "image 4.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 5, "image 5.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 6, "image 6.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 7, "image 7.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 8, "image 8.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 11, "image 9.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 9, "image 10.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 10, "image 11.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 5, "image 12.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 3, "image 13.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 2, "image 14.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 12, "image 15.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 13, "image 16.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 14, "image 17.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 15, "image 18.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 6, "image 19.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 4, "image 20.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 5, "image 21.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 3, "image 22.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 16, "image 23.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 15, "image 24.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 1, "image 25.png" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 2, "image 26.png" });

            migrationBuilder.CreateIndex(
                name: "IX_BookingModel_EventModelId",
                table: "BookingModel",
                column: "EventModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingModel_UserModelId",
                table: "BookingModel",
                column: "UserModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingModel");

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

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 0, "~/images/event images/image 1.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 1, "~/images/event images/image 2.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 2, "~/images/event images/image 3.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 3, "~/images/event images/image 4.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 4, "~/images/event images/image 5.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 5, "~/images/event images/image 6.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 6, "~/images/event images/image 7.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 7, "~/images/event images/image 8.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 10, "~/images/event images/image 9.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 8, "~/images/event images/image 10.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 9, "~/images/event images/image 11.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 4, "~/images/event images/image 12.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 2, "~/images/event images/image 13.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 1, "~/images/event images/image 14.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 11, "~/images/event images/image 15.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 12, "~/images/event images/image 16.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 13, "~/images/event images/image 17.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 14, "~/images/event images/image 18.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 5, "~/images/event images/image 19.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 3, "~/images/event images/image 20.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 4, "~/images/event images/image 21.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 2, "~/images/event images/image 22.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 15, "~/images/event images/image 23.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 14, "~/images/event images/image 24.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 0, "~/images/event images/image 25.avif" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "EventType", "ImageUrl" },
                values: new object[] { 1, "~/images/event images/image 26.avif" });

            migrationBuilder.CreateIndex(
                name: "IX_EventModelUserModel_VisitorsId",
                table: "EventModelUserModel",
                column: "VisitorsId");
        }
    }
}
