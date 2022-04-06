using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RRS.Migrations
{
    public partial class SeedResStatusResOrigin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ReservationOrigins",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "In-person" },
                    { 2, "Email" },
                    { 3, "Phone" }
                });

            migrationBuilder.InsertData(
                table: "ReservationStatuses",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Confirmed" },
                    { 3, "Cancelled" },
                    { 4, "Seated" },
                    { 5, "Completed" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReservationOrigins",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReservationOrigins",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReservationOrigins",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
