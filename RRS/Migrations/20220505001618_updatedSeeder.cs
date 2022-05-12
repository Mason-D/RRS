using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RRS.Migrations
{
    public partial class updatedSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ReservationOrigins",
                columns: new[] { "Id", "Description" },
                values: new object[] { 4, "Online" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReservationOrigins",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
