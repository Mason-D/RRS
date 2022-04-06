using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RRS.Migrations
{
    public partial class SeedOneMonthOfSittings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Start",
                value: new DateTime(2022, 4, 6, 7, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Start",
                value: new DateTime(2022, 4, 6, 13, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Start",
                value: new DateTime(2022, 4, 6, 18, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Duration", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[,]
                {
                    { 4, 40, 240, true, 1, 1, new DateTime(2022, 4, 7, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 60, 180, true, 1, 2, new DateTime(2022, 4, 7, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 80, 300, true, 1, 3, new DateTime(2022, 4, 7, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 40, 240, true, 1, 1, new DateTime(2022, 4, 8, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 60, 180, true, 1, 2, new DateTime(2022, 4, 8, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 80, 300, true, 1, 3, new DateTime(2022, 4, 8, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 40, 240, true, 1, 1, new DateTime(2022, 4, 9, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 60, 180, true, 1, 2, new DateTime(2022, 4, 9, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 80, 300, true, 1, 3, new DateTime(2022, 4, 9, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 40, 240, true, 1, 1, new DateTime(2022, 4, 10, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 60, 180, true, 1, 2, new DateTime(2022, 4, 10, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 80, 300, true, 1, 3, new DateTime(2022, 4, 10, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 40, 240, true, 1, 1, new DateTime(2022, 4, 11, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 60, 180, true, 1, 2, new DateTime(2022, 4, 11, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 80, 300, true, 1, 3, new DateTime(2022, 4, 11, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 40, 240, true, 1, 1, new DateTime(2022, 4, 12, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 60, 180, true, 1, 2, new DateTime(2022, 4, 12, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 80, 300, true, 1, 3, new DateTime(2022, 4, 12, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 40, 240, true, 1, 1, new DateTime(2022, 4, 13, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 60, 180, true, 1, 2, new DateTime(2022, 4, 13, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 80, 300, true, 1, 3, new DateTime(2022, 4, 13, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 40, 240, true, 1, 1, new DateTime(2022, 4, 14, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 60, 180, true, 1, 2, new DateTime(2022, 4, 14, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 80, 300, true, 1, 3, new DateTime(2022, 4, 14, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 40, 240, true, 1, 1, new DateTime(2022, 4, 15, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 60, 180, true, 1, 2, new DateTime(2022, 4, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 80, 300, true, 1, 3, new DateTime(2022, 4, 15, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 40, 240, true, 1, 1, new DateTime(2022, 4, 16, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 60, 180, true, 1, 2, new DateTime(2022, 4, 16, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 80, 300, true, 1, 3, new DateTime(2022, 4, 16, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 40, 240, true, 1, 1, new DateTime(2022, 4, 17, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 60, 180, true, 1, 2, new DateTime(2022, 4, 17, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 80, 300, true, 1, 3, new DateTime(2022, 4, 17, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 40, 240, true, 1, 1, new DateTime(2022, 4, 18, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 60, 180, true, 1, 2, new DateTime(2022, 4, 18, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 80, 300, true, 1, 3, new DateTime(2022, 4, 18, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 40, 240, true, 1, 1, new DateTime(2022, 4, 19, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 60, 180, true, 1, 2, new DateTime(2022, 4, 19, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 80, 300, true, 1, 3, new DateTime(2022, 4, 19, 18, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Duration", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[,]
                {
                    { 43, 40, 240, true, 1, 1, new DateTime(2022, 4, 20, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 60, 180, true, 1, 2, new DateTime(2022, 4, 20, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 80, 300, true, 1, 3, new DateTime(2022, 4, 20, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 40, 240, true, 1, 1, new DateTime(2022, 4, 21, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 60, 180, true, 1, 2, new DateTime(2022, 4, 21, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 80, 300, true, 1, 3, new DateTime(2022, 4, 21, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 40, 240, true, 1, 1, new DateTime(2022, 4, 22, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 60, 180, true, 1, 2, new DateTime(2022, 4, 22, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 80, 300, true, 1, 3, new DateTime(2022, 4, 22, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 40, 240, true, 1, 1, new DateTime(2022, 4, 23, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 60, 180, true, 1, 2, new DateTime(2022, 4, 23, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 80, 300, true, 1, 3, new DateTime(2022, 4, 23, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 40, 240, true, 1, 1, new DateTime(2022, 4, 24, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 60, 180, true, 1, 2, new DateTime(2022, 4, 24, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 80, 300, true, 1, 3, new DateTime(2022, 4, 24, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 40, 240, true, 1, 1, new DateTime(2022, 4, 25, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 60, 180, true, 1, 2, new DateTime(2022, 4, 25, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 80, 300, true, 1, 3, new DateTime(2022, 4, 25, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 40, 240, true, 1, 1, new DateTime(2022, 4, 26, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 60, 180, true, 1, 2, new DateTime(2022, 4, 26, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 80, 300, true, 1, 3, new DateTime(2022, 4, 26, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 40, 240, true, 1, 1, new DateTime(2022, 4, 27, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 60, 180, true, 1, 2, new DateTime(2022, 4, 27, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 80, 300, true, 1, 3, new DateTime(2022, 4, 27, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 40, 240, true, 1, 1, new DateTime(2022, 4, 28, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 60, 180, true, 1, 2, new DateTime(2022, 4, 28, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 80, 300, true, 1, 3, new DateTime(2022, 4, 28, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 40, 240, true, 1, 1, new DateTime(2022, 4, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 60, 180, true, 1, 2, new DateTime(2022, 4, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 80, 300, true, 1, 3, new DateTime(2022, 4, 29, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 40, 240, true, 1, 1, new DateTime(2022, 4, 30, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 60, 180, true, 1, 2, new DateTime(2022, 4, 30, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 80, 300, true, 1, 3, new DateTime(2022, 4, 30, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 40, 240, true, 1, 1, new DateTime(2022, 5, 1, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, 60, 180, true, 1, 2, new DateTime(2022, 5, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 80, 300, true, 1, 3, new DateTime(2022, 5, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, 40, 240, true, 1, 1, new DateTime(2022, 5, 2, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 60, 180, true, 1, 2, new DateTime(2022, 5, 2, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, 80, 300, true, 1, 3, new DateTime(2022, 5, 2, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 82, 40, 240, true, 1, 1, new DateTime(2022, 5, 3, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 83, 60, 180, true, 1, 2, new DateTime(2022, 5, 3, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 84, 80, 300, true, 1, 3, new DateTime(2022, 5, 3, 18, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.UpdateData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Start",
                value: new DateTime(2022, 6, 4, 7, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Start",
                value: new DateTime(2022, 6, 4, 13, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Start",
                value: new DateTime(2022, 6, 4, 18, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
