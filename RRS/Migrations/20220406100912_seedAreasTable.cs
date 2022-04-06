using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RRS.Migrations
{
    public partial class seedAreasTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "Description", "RestaurantId" },
                values: new object[] { 1, "Main", 1 });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "Description", "RestaurantId" },
                values: new object[] { 2, "Outside", 1 });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "Description", "RestaurantId" },
                values: new object[] { 3, "Balcony", 1 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "AreaId", "Description" },
                values: new object[,]
                {
                    { 1, 1, "M1" },
                    { 2, 1, "M2" },
                    { 3, 1, "M3" },
                    { 4, 1, "M4" },
                    { 5, 1, "M5" },
                    { 6, 1, "M6" },
                    { 7, 1, "M7" },
                    { 8, 1, "M8" },
                    { 9, 1, "M9" },
                    { 10, 1, "M10" },
                    { 11, 2, "O1" },
                    { 12, 2, "O2" },
                    { 13, 2, "O3" },
                    { 14, 2, "O4" },
                    { 15, 2, "O5" },
                    { 16, 2, "O6" },
                    { 17, 2, "O7" },
                    { 18, 2, "O8" },
                    { 19, 2, "O9" },
                    { 20, 2, "O10" },
                    { 21, 3, "B1" },
                    { 22, 3, "B2" },
                    { 23, 3, "B3" },
                    { 24, 3, "B4" },
                    { 25, 3, "B5" },
                    { 26, 3, "B6" },
                    { 27, 3, "B7" },
                    { 28, 3, "B8" },
                    { 29, 3, "B9" },
                    { 30, 3, "B10" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
