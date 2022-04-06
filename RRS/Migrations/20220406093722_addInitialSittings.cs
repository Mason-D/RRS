using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RRS.Migrations
{
    public partial class addInitialSittings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsClosed",
                table: "Sittings",
                newName: "IsOpen");

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Duration", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[] { 1, 40, 240, true, 1, 1, new DateTime(2022, 6, 4, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Duration", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[] { 2, 60, 180, true, 1, 2, new DateTime(2022, 6, 4, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Duration", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[] { 3, 80, 300, true, 1, 3, new DateTime(2022, 6, 4, 18, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "IsOpen",
                table: "Sittings",
                newName: "IsClosed");
        }
    }
}
