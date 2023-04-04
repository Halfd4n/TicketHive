using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketHive.Server.Migrations
{
	/// <inheritdoc />
	public partial class AddPropertiesMainDb : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<DateTime>(
				name: "EndTime",
				table: "Events",
				type: "datetime2",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

			migrationBuilder.AddColumn<string>(
				name: "Location",
				table: "Events",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "");

			migrationBuilder.AddColumn<DateTime>(
				name: "StartTime",
				table: "Events",
				type: "datetime2",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 1,
				columns: new[] { "EndTime", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 8, 1, 23, 0, 0, 0, DateTimeKind.Utc), "The local park", new DateTime(2023, 8, 1, 20, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 2,
				columns: new[] { "EndTime", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 10, 14, 22, 0, 0, 0, DateTimeKind.Utc), "Center Art Museum", new DateTime(2023, 10, 14, 19, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 3,
				columns: new[] { "EndTime", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 8, 20, 21, 0, 0, 0, DateTimeKind.Utc), "Hillside Wine Garden", new DateTime(2023, 8, 20, 18, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 4,
				columns: new[] { "EndTime", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 12, 31, 22, 0, 0, 0, DateTimeKind.Utc), "Downtown", new DateTime(2023, 12, 31, 18, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 5,
				columns: new[] { "EndTime", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 11, 15, 21, 0, 0, 0, DateTimeKind.Utc), "Central Comedy Club House", new DateTime(2023, 11, 15, 20, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 6,
				columns: new[] { "EndTime", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 1, 5, 22, 0, 0, 0, DateTimeKind.Utc), "Film Society Cinema", new DateTime(2023, 1, 5, 17, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 7,
				columns: new[] { "EndTime", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 9, 11, 19, 0, 0, 0, DateTimeKind.Utc), "The local park", new DateTime(2023, 9, 11, 13, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 8,
				columns: new[] { "EndTime", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 5, 21, 22, 0, 0, 0, DateTimeKind.Utc), "Downtown market place", new DateTime(2023, 5, 21, 18, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 9,
				columns: new[] { "EndTime", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 6, 1, 13, 0, 0, 0, DateTimeKind.Utc), "Central library", new DateTime(2023, 6, 1, 11, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 10,
				columns: new[] { "EndTime", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 7, 30, 16, 0, 0, 0, DateTimeKind.Utc), "Community Hall", new DateTime(2023, 7, 30, 9, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 11,
				columns: new[] { "EndTime", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 10, 18, 18, 0, 0, 0, DateTimeKind.Utc), "The Central Museum", new DateTime(2023, 10, 18, 9, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 12,
				columns: new[] { "EndTime", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 12, 15, 22, 0, 0, 0, DateTimeKind.Utc), "The Central Mall", new DateTime(2023, 12, 15, 18, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 13,
				columns: new[] { "EndTime", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 6, 30, 22, 0, 0, 0, DateTimeKind.Utc), "Fine Food Restaurant", new DateTime(2023, 6, 30, 20, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 14,
				columns: new[] { "EndTime", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 9, 8, 18, 0, 0, 0, DateTimeKind.Utc), "Central Library", new DateTime(2023, 9, 8, 13, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 15,
				columns: new[] { "EndTime", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 8, 17, 18, 0, 0, 0, DateTimeKind.Utc), "The House of Incubator", new DateTime(2023, 8, 17, 13, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 16,
				columns: new[] { "EndTime", "Host", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 10, 11, 23, 0, 0, 0, DateTimeKind.Utc), "The DownTown Pub", "The DownTown Pub", new DateTime(2023, 10, 11, 19, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 17,
				columns: new[] { "EndTime", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 11, 25, 23, 0, 0, 0, DateTimeKind.Utc), "The local nightclub", new DateTime(2023, 11, 25, 21, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 18,
				columns: new[] { "EndTime", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 12, 9, 16, 0, 0, 0, DateTimeKind.Utc), "The Central School of Art", new DateTime(2023, 12, 9, 13, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 19,
				columns: new[] { "EndTime", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 8, 5, 20, 0, 0, 0, DateTimeKind.Utc), "The DownTown Movie Theater", new DateTime(2023, 8, 5, 17, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 20,
				columns: new[] { "EndTime", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 10, 20, 22, 0, 0, 0, DateTimeKind.Utc), "Central town", new DateTime(2023, 10, 20, 18, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 21,
				columns: new[] { "EndTime", "Host", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 7, 28, 22, 0, 0, 0, DateTimeKind.Utc), "The HaveFun Comedy Club", "The local comedy club", new DateTime(2023, 7, 28, 18, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 22,
				columns: new[] { "EndTime", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 5, 5, 22, 0, 0, 0, DateTimeKind.Utc), "The local park", new DateTime(2023, 5, 5, 18, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 23,
				columns: new[] { "EndTime", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 10, 12, 20, 0, 0, 0, DateTimeKind.Utc), "The local park", new DateTime(2023, 10, 12, 19, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 24,
				columns: new[] { "EndTime", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 8, 16, 17, 0, 0, 0, DateTimeKind.Utc), "The local university", new DateTime(2023, 8, 16, 13, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 25,
				columns: new[] { "EndTime", "Location", "StartTime" },
				values: new object[] { new DateTime(2023, 11, 5, 22, 0, 0, 0, DateTimeKind.Utc), "The local park", new DateTime(2023, 11, 5, 18, 0, 0, 0, DateTimeKind.Utc) });

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 26,
				columns: new[] { "Description", "EndTime", "Host", "Location", "Name", "NumberOfTickets", "Price", "StartTime" },
				values: new object[] { "An art exhibition featuring international works of art", new DateTime(2023, 9, 17, 21, 0, 0, 0, DateTimeKind.Utc), "Fine Arts Association", "The local arts gallery", "Contemporary Art Show", 200, 300m, new DateTime(2023, 9, 17, 17, 0, 0, 0, DateTimeKind.Utc) });
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "EndTime",
				table: "Events");

			migrationBuilder.DropColumn(
				name: "Location",
				table: "Events");

			migrationBuilder.DropColumn(
				name: "StartTime",
				table: "Events");

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 16,
				column: "Host",
				value: "The local pub");

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 21,
				column: "Host",
				value: "The local comedy club");

			migrationBuilder.UpdateData(
				table: "Events",
				keyColumn: "Id",
				keyValue: 26,
				columns: new[] { "Description", "Host", "Name", "NumberOfTickets", "Price" },
				values: new object[] { "A new exhibit featuring local artists", "The local art museum", "Art exhibit opening", 500, 100m });
		}
	}
}
