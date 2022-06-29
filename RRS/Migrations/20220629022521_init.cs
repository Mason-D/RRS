using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RRS.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservationOrigins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationOrigins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservationStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SittingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SittingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sittings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Interval = table.Column<int>(type: "int", nullable: false),
                    Cutoff = table.Column<int>(type: "int", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    SittingTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sittings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sittings_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sittings_SittingTypes_SittingTypeId",
                        column: x => x.SittingTypeId,
                        principalTable: "SittingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tables_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsVIP = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_People_Id",
                        column: x => x.Id,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TaxFileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_People_Id",
                        column: x => x.Id,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoOfGuests = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SittingId = table.Column<int>(type: "int", nullable: false),
                    ReservationStatusId = table.Column<int>(type: "int", nullable: false),
                    ReservationOriginId = table.Column<int>(type: "int", nullable: false),
                    CustomerNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_ReservationOrigins_ReservationOriginId",
                        column: x => x.ReservationOriginId,
                        principalTable: "ReservationOrigins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_ReservationStatuses_ReservationStatusId",
                        column: x => x.ReservationStatusId,
                        principalTable: "ReservationStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Sittings_SittingId",
                        column: x => x.SittingId,
                        principalTable: "Sittings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservationTables",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationTables", x => x.id);
                    table.ForeignKey(
                        name: "FK_ReservationTables_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationTables_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ReservationOrigins",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "In-person" },
                    { 2, "Email" },
                    { 3, "Phone" },
                    { 4, "Online" }
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

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "Email", "Name", "PhoneNumber" },
                values: new object[] { 1, "123 Bean St, Sydney", "Bean@Scene.com", "Bean Scene", "123-456-789" });

            migrationBuilder.InsertData(
                table: "SittingTypes",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Breakfast" },
                    { 2, "Lunch" },
                    { 3, "Dinner" }
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "Description", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Main", 1 },
                    { 2, "Outside", 1 },
                    { 3, "Balcony", 1 }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber", "RestaurantId", "UserId" },
                values: new object[,]
                {
                    { 1, "Aaliyah.Phillips@gmail.com", "Aaliyah", "Phillips", "0425023402", 1, null },
                    { 2, "Rosemarie.Lam@gmail.com", "Rosemarie", "Lam", "0425123412", 1, null },
                    { 3, "Kush.Craig@gmail.com", "Kush", "Craig", "0425223422", 1, null },
                    { 4, "Hendrix.Vu@gmail.com", "Hendrix", "Vu", "0425323432", 1, null },
                    { 5, "Rose.Bates@gmail.com", "Rose", "Bates", "0425423442", 1, null },
                    { 6, "Christina.East@gmail.com", "Christina", "East", "0425523452", 1, null },
                    { 7, "Aiza.East@gmail.com", "Aiza", "East", "0425623462", 1, null },
                    { 8, "Neave.Hart@gmail.com", "Neave", "Hart", "0425723472", 1, null },
                    { 9, "Diesel.Jefferson@gmail.com", "Diesel", "Jefferson", "0425823482", 1, null },
                    { 10, "Eleanor.Farley@gmail.com", "Eleanor", "Farley", "0425923492", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Cutoff", "Duration", "GroupId", "Interval", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[,]
                {
                    { 1, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 30, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 6, 30, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 6, 30, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 1, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 2, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 2, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 2, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 3, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 3, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 3, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 4, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 4, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 4, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 5, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 5, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 5, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 6, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 6, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 6, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 7, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 7, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 7, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 8, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 8, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 8, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 9, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 9, 12, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Cutoff", "Duration", "GroupId", "Interval", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[,]
                {
                    { 30, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 9, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 10, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 10, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 10, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 11, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 11, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 11, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 12, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 12, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 12, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 13, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 13, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 13, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 14, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 14, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 14, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 15, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 15, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 16, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 16, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 16, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 17, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 17, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 17, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 18, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 18, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 18, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 19, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 19, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 19, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 20, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 20, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 21, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 21, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 21, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 22, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 22, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 22, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 23, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 23, 12, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Cutoff", "Duration", "GroupId", "Interval", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[,]
                {
                    { 72, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 23, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 24, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 24, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 24, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 25, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 25, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 25, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 26, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 26, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 26, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 82, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 27, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 83, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 27, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 84, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 27, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 85, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 28, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 86, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 28, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 87, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 28, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 88, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 89, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 90, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 29, 18, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "IsVIP" },
                values: new object[,]
                {
                    { 1, true },
                    { 2, true },
                    { 3, true },
                    { 4, true },
                    { 5, true },
                    { 6, true },
                    { 7, true },
                    { 8, true },
                    { 9, true },
                    { 10, true }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "AreaId", "Description", "Seats" },
                values: new object[,]
                {
                    { 1, 1, "M1", 4 },
                    { 2, 1, "M2", 8 },
                    { 3, 1, "M3", 3 },
                    { 4, 1, "M4", 4 },
                    { 5, 1, "M5", 6 },
                    { 6, 1, "M6", 4 },
                    { 7, 1, "M7", 9 },
                    { 8, 1, "M8", 3 },
                    { 9, 1, "M9", 4 },
                    { 10, 1, "M10", 7 },
                    { 11, 2, "O1", 5 },
                    { 12, 2, "O2", 2 },
                    { 13, 2, "O3", 5 },
                    { 14, 2, "O4", 8 },
                    { 15, 2, "O5", 9 },
                    { 16, 2, "O6", 3 },
                    { 17, 2, "O7", 6 },
                    { 18, 2, "O8", 2 },
                    { 19, 2, "O9", 2 },
                    { 20, 2, "O10", 9 },
                    { 21, 3, "B1", 5 },
                    { 22, 3, "B2", 7 },
                    { 23, 3, "B3", 9 },
                    { 24, 3, "B4", 9 },
                    { 25, 3, "B5", 4 },
                    { 26, 3, "B6", 6 },
                    { 27, 3, "B7", 2 },
                    { 28, 3, "B8", 5 },
                    { 29, 3, "B9", 2 },
                    { 30, 3, "B10", 8 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, null, 5, 3, 1, 1, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, null, 3, 1, 1, 1, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, null, 3, 1, 1, 1, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, null, 8, 3, 1, 1, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, null, 3, 3, 1, 1, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, null, 5, 3, 1, 1, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 7, null, 6, 1, 1, 1, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 8, null, 9, 3, 1, 1, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 9, null, 5, 2, 1, 1, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 10, null, 9, 1, 1, 1, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 1, null, 3, 2, 1, 2, new DateTime(2022, 6, 29, 12, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 2, null, 7, 1, 1, 2, new DateTime(2022, 6, 29, 15, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 3, null, 7, 2, 1, 2, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 4, null, 3, 3, 1, 2, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 5, null, 2, 1, 1, 2, new DateTime(2022, 6, 29, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 6, null, 3, 1, 1, 2, new DateTime(2022, 6, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 7, null, 9, 2, 1, 2, new DateTime(2022, 6, 29, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 8, null, 2, 3, 1, 2, new DateTime(2022, 6, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 9, null, 5, 1, 1, 2, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 10, null, 4, 2, 1, 2, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 1, null, 4, 1, 1, 3, new DateTime(2022, 6, 29, 20, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 2, null, 4, 2, 1, 3, new DateTime(2022, 6, 29, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 3, null, 9, 2, 1, 3, new DateTime(2022, 6, 29, 21, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 4, null, 9, 2, 1, 3, new DateTime(2022, 6, 29, 21, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 5, null, 2, 1, 1, 3, new DateTime(2022, 6, 29, 20, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 6, null, 5, 1, 1, 3, new DateTime(2022, 6, 29, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 7, null, 4, 3, 1, 3, new DateTime(2022, 6, 29, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 8, null, 2, 2, 1, 3, new DateTime(2022, 6, 29, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 9, null, 4, 3, 1, 3, new DateTime(2022, 6, 29, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 10, null, 4, 1, 1, 3, new DateTime(2022, 6, 29, 22, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 1, null, 4, 2, 1, 4, new DateTime(2022, 6, 29, 13, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 2, null, 6, 3, 1, 4, new DateTime(2022, 6, 29, 12, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 3, null, 7, 1, 1, 4, new DateTime(2022, 6, 29, 12, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 4, null, 4, 1, 1, 4, new DateTime(2022, 6, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 5, null, 7, 1, 1, 4, new DateTime(2022, 6, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 6, null, 6, 3, 1, 4, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 7, null, 6, 1, 1, 4, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 8, null, 2, 3, 1, 4, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 9, null, 6, 2, 1, 4, new DateTime(2022, 6, 29, 14, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 10, null, 2, 2, 1, 4, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 1, null, 2, 3, 1, 5, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 2, null, 7, 1, 1, 5, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[,]
                {
                    { 43, 3, null, 3, 2, 1, 5, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 4, null, 7, 2, 1, 5, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 5, null, 4, 2, 1, 5, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 6, null, 6, 3, 1, 5, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 7, null, 3, 2, 1, 5, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 8, null, 2, 2, 1, 5, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 9, null, 7, 2, 1, 5, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 10, null, 8, 2, 1, 5, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 1, null, 6, 1, 1, 6, new DateTime(2022, 6, 29, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 2, null, 8, 2, 1, 6, new DateTime(2022, 6, 29, 21, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 3, null, 2, 2, 1, 6, new DateTime(2022, 6, 29, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 4, null, 4, 2, 1, 6, new DateTime(2022, 6, 29, 19, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 5, null, 3, 3, 1, 6, new DateTime(2022, 6, 29, 19, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 6, null, 3, 3, 1, 6, new DateTime(2022, 6, 29, 20, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 7, null, 4, 3, 1, 6, new DateTime(2022, 6, 29, 21, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 8, null, 6, 2, 1, 6, new DateTime(2022, 6, 29, 22, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 9, null, 5, 1, 1, 6, new DateTime(2022, 6, 29, 21, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 10, null, 2, 2, 1, 6, new DateTime(2022, 6, 29, 19, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 1, null, 7, 3, 1, 7, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 2, null, 5, 2, 1, 7, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 3, null, 8, 2, 1, 7, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 4, null, 2, 2, 1, 7, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 5, null, 4, 3, 1, 7, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 6, null, 6, 3, 1, 7, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 7, null, 4, 2, 1, 7, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 8, null, 8, 3, 1, 7, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 9, null, 5, 2, 1, 7, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 10, null, 8, 3, 1, 7, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 1, null, 9, 1, 1, 8, new DateTime(2022, 6, 29, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 2, null, 6, 1, 1, 8, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 3, null, 6, 2, 1, 8, new DateTime(2022, 6, 29, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 4, null, 7, 1, 1, 8, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 5, null, 6, 3, 1, 8, new DateTime(2022, 6, 29, 13, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 6, null, 6, 2, 1, 8, new DateTime(2022, 6, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, 7, null, 2, 3, 1, 8, new DateTime(2022, 6, 29, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 8, null, 2, 3, 1, 8, new DateTime(2022, 6, 29, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 79, 9, null, 7, 2, 1, 8, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 10, null, 9, 1, 1, 8, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, 1, null, 4, 3, 1, 9, new DateTime(2022, 6, 29, 19, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 82, 2, null, 5, 3, 1, 9, new DateTime(2022, 6, 29, 19, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 83, 3, null, 2, 1, 1, 9, new DateTime(2022, 6, 29, 20, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 84, 4, null, 7, 1, 1, 9, new DateTime(2022, 6, 29, 22, 45, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[,]
                {
                    { 85, 5, null, 4, 1, 1, 9, new DateTime(2022, 6, 29, 22, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 86, 6, null, 7, 1, 1, 9, new DateTime(2022, 6, 29, 20, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 87, 7, null, 4, 3, 1, 9, new DateTime(2022, 6, 29, 21, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 88, 8, null, 5, 1, 1, 9, new DateTime(2022, 6, 29, 21, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 89, 9, null, 2, 2, 1, 9, new DateTime(2022, 6, 29, 20, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 90, 10, null, 2, 2, 1, 9, new DateTime(2022, 6, 29, 21, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 91, 1, null, 7, 3, 1, 10, new DateTime(2022, 6, 29, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 92, 2, null, 3, 1, 1, 10, new DateTime(2022, 6, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93, 3, null, 4, 2, 1, 10, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 94, 4, null, 6, 3, 1, 10, new DateTime(2022, 6, 29, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 95, 5, null, 5, 2, 1, 10, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 96, 6, null, 7, 1, 1, 10, new DateTime(2022, 6, 29, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 97, 7, null, 2, 3, 1, 10, new DateTime(2022, 6, 29, 14, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 98, 8, null, 3, 2, 1, 10, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 99, 9, null, 7, 3, 1, 10, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 100, 10, null, 9, 1, 1, 10, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 101, 1, null, 9, 3, 1, 11, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 102, 2, null, 8, 1, 1, 11, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 103, 3, null, 8, 1, 1, 11, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 104, 4, null, 6, 2, 1, 11, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 105, 5, null, 4, 2, 1, 11, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 106, 6, null, 7, 1, 1, 11, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 107, 7, null, 3, 2, 1, 11, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 108, 8, null, 9, 1, 1, 11, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 109, 9, null, 3, 1, 1, 11, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 110, 10, null, 7, 1, 1, 11, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 111, 1, null, 2, 3, 1, 12, new DateTime(2022, 6, 29, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 112, 2, null, 7, 3, 1, 12, new DateTime(2022, 6, 29, 21, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 113, 3, null, 2, 3, 1, 12, new DateTime(2022, 6, 29, 22, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 114, 4, null, 9, 2, 1, 12, new DateTime(2022, 6, 29, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 115, 5, null, 9, 3, 1, 12, new DateTime(2022, 6, 29, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 116, 6, null, 4, 2, 1, 12, new DateTime(2022, 6, 29, 19, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 117, 7, null, 8, 2, 1, 12, new DateTime(2022, 6, 29, 22, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 118, 8, null, 2, 3, 1, 12, new DateTime(2022, 6, 29, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 119, 9, null, 8, 3, 1, 12, new DateTime(2022, 6, 29, 22, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 120, 10, null, 9, 3, 1, 12, new DateTime(2022, 6, 29, 20, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 121, 1, null, 3, 1, 1, 13, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 122, 2, null, 7, 3, 1, 13, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 123, 3, null, 7, 3, 1, 13, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 124, 4, null, 5, 3, 1, 13, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 125, 5, null, 5, 1, 1, 13, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 126, 6, null, 8, 3, 1, 13, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[,]
                {
                    { 127, 7, null, 9, 2, 1, 13, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 128, 8, null, 8, 3, 1, 13, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 129, 9, null, 5, 2, 1, 13, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 130, 10, null, 8, 2, 1, 13, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 131, 1, null, 5, 2, 1, 14, new DateTime(2022, 6, 29, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 132, 2, null, 9, 3, 1, 14, new DateTime(2022, 6, 29, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 133, 3, null, 3, 1, 1, 14, new DateTime(2022, 6, 29, 15, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 134, 4, null, 9, 3, 1, 14, new DateTime(2022, 6, 29, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 135, 5, null, 5, 3, 1, 14, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 136, 6, null, 7, 3, 1, 14, new DateTime(2022, 6, 29, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 137, 7, null, 7, 2, 1, 14, new DateTime(2022, 6, 29, 15, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 138, 8, null, 7, 3, 1, 14, new DateTime(2022, 6, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 139, 9, null, 7, 1, 1, 14, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 140, 10, null, 7, 1, 1, 14, new DateTime(2022, 6, 29, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 141, 1, null, 9, 1, 1, 15, new DateTime(2022, 6, 29, 21, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 142, 2, null, 8, 3, 1, 15, new DateTime(2022, 6, 29, 19, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 143, 3, null, 6, 3, 1, 15, new DateTime(2022, 6, 29, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 144, 4, null, 6, 3, 1, 15, new DateTime(2022, 6, 29, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 145, 5, null, 8, 2, 1, 15, new DateTime(2022, 6, 29, 19, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 146, 6, null, 9, 1, 1, 15, new DateTime(2022, 6, 29, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 147, 7, null, 4, 3, 1, 15, new DateTime(2022, 6, 29, 22, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 148, 8, null, 5, 1, 1, 15, new DateTime(2022, 6, 29, 19, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 149, 9, null, 3, 3, 1, 15, new DateTime(2022, 6, 29, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 150, 10, null, 9, 2, 1, 15, new DateTime(2022, 6, 29, 20, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 151, 1, null, 9, 1, 1, 16, new DateTime(2022, 6, 29, 14, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 152, 2, null, 2, 3, 1, 16, new DateTime(2022, 6, 29, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 153, 3, null, 4, 2, 1, 16, new DateTime(2022, 6, 29, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 154, 4, null, 4, 2, 1, 16, new DateTime(2022, 6, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 155, 5, null, 5, 1, 1, 16, new DateTime(2022, 6, 29, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 156, 6, null, 3, 2, 1, 16, new DateTime(2022, 6, 29, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 157, 7, null, 5, 2, 1, 16, new DateTime(2022, 6, 29, 13, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 158, 8, null, 4, 3, 1, 16, new DateTime(2022, 6, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 159, 9, null, 5, 2, 1, 16, new DateTime(2022, 6, 29, 12, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 160, 10, null, 3, 1, 1, 16, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 161, 1, null, 4, 3, 1, 17, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 162, 2, null, 7, 2, 1, 17, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 163, 3, null, 6, 1, 1, 17, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 164, 4, null, 2, 3, 1, 17, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 165, 5, null, 4, 1, 1, 17, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 166, 6, null, 7, 3, 1, 17, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 167, 7, null, 5, 3, 1, 17, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 168, 8, null, 4, 3, 1, 17, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[,]
                {
                    { 169, 9, null, 7, 1, 1, 17, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 170, 10, null, 5, 1, 1, 17, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 171, 1, null, 9, 3, 1, 18, new DateTime(2022, 6, 29, 20, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 172, 2, null, 8, 1, 1, 18, new DateTime(2022, 6, 29, 21, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 173, 3, null, 6, 2, 1, 18, new DateTime(2022, 6, 29, 21, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 174, 4, null, 6, 2, 1, 18, new DateTime(2022, 6, 29, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 175, 5, null, 7, 2, 1, 18, new DateTime(2022, 6, 29, 21, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 176, 6, null, 5, 3, 1, 18, new DateTime(2022, 6, 29, 21, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 177, 7, null, 6, 3, 1, 18, new DateTime(2022, 6, 29, 22, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 178, 8, null, 9, 3, 1, 18, new DateTime(2022, 6, 29, 21, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 179, 9, null, 2, 1, 1, 18, new DateTime(2022, 6, 29, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 180, 10, null, 3, 3, 1, 18, new DateTime(2022, 6, 29, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 181, 1, null, 7, 1, 1, 19, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 182, 2, null, 8, 3, 1, 19, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 183, 3, null, 5, 1, 1, 19, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 184, 4, null, 2, 1, 1, 19, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 185, 5, null, 3, 3, 1, 19, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 186, 6, null, 7, 3, 1, 19, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 187, 7, null, 3, 2, 1, 19, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 188, 8, null, 4, 1, 1, 19, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 189, 9, null, 5, 2, 1, 19, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 190, 10, null, 8, 1, 1, 19, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 191, 1, null, 4, 3, 1, 20, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 192, 2, null, 3, 1, 1, 20, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 193, 3, null, 3, 2, 1, 20, new DateTime(2022, 6, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 194, 4, null, 9, 3, 1, 20, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 195, 5, null, 6, 3, 1, 20, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 196, 6, null, 4, 1, 1, 20, new DateTime(2022, 6, 29, 15, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 197, 7, null, 3, 1, 1, 20, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 198, 8, null, 5, 1, 1, 20, new DateTime(2022, 6, 29, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 199, 9, null, 9, 3, 1, 20, new DateTime(2022, 6, 29, 14, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 200, 10, null, 5, 2, 1, 20, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 201, 1, null, 3, 2, 1, 21, new DateTime(2022, 6, 29, 22, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 202, 2, null, 9, 1, 1, 21, new DateTime(2022, 6, 29, 22, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 203, 3, null, 9, 1, 1, 21, new DateTime(2022, 6, 29, 21, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 204, 4, null, 2, 1, 1, 21, new DateTime(2022, 6, 29, 21, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 205, 5, null, 9, 2, 1, 21, new DateTime(2022, 6, 29, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 206, 6, null, 9, 1, 1, 21, new DateTime(2022, 6, 29, 19, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 207, 7, null, 5, 1, 1, 21, new DateTime(2022, 6, 29, 18, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 208, 8, null, 6, 2, 1, 21, new DateTime(2022, 6, 29, 22, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 209, 9, null, 6, 3, 1, 21, new DateTime(2022, 6, 29, 18, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 210, 10, null, 8, 3, 1, 21, new DateTime(2022, 6, 29, 21, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[,]
                {
                    { 211, 1, null, 4, 2, 1, 22, new DateTime(2022, 6, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 212, 2, null, 3, 3, 1, 22, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 213, 3, null, 2, 2, 1, 22, new DateTime(2022, 6, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 214, 4, null, 9, 1, 1, 22, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 215, 5, null, 2, 3, 1, 22, new DateTime(2022, 6, 29, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 216, 6, null, 5, 3, 1, 22, new DateTime(2022, 6, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 217, 7, null, 6, 1, 1, 22, new DateTime(2022, 6, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 218, 8, null, 6, 2, 1, 22, new DateTime(2022, 6, 29, 14, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 219, 9, null, 8, 2, 1, 22, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 220, 10, null, 3, 2, 1, 22, new DateTime(2022, 6, 29, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 221, 1, null, 6, 2, 1, 23, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 222, 2, null, 6, 1, 1, 23, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 223, 3, null, 8, 2, 1, 23, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 224, 4, null, 3, 2, 1, 23, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 225, 5, null, 3, 1, 1, 23, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 226, 6, null, 3, 2, 1, 23, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 227, 7, null, 8, 3, 1, 23, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 228, 8, null, 8, 1, 1, 23, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 229, 9, null, 5, 3, 1, 23, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 230, 10, null, 3, 3, 1, 23, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 231, 1, null, 5, 2, 1, 24, new DateTime(2022, 6, 29, 19, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 232, 2, null, 3, 3, 1, 24, new DateTime(2022, 6, 29, 20, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 233, 3, null, 7, 3, 1, 24, new DateTime(2022, 6, 29, 20, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 234, 4, null, 9, 3, 1, 24, new DateTime(2022, 6, 29, 20, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 235, 5, null, 8, 2, 1, 24, new DateTime(2022, 6, 29, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 236, 6, null, 5, 3, 1, 24, new DateTime(2022, 6, 29, 22, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 237, 7, null, 8, 2, 1, 24, new DateTime(2022, 6, 29, 21, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 238, 8, null, 2, 1, 1, 24, new DateTime(2022, 6, 29, 20, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 239, 9, null, 2, 2, 1, 24, new DateTime(2022, 6, 29, 20, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 240, 10, null, 2, 1, 1, 24, new DateTime(2022, 6, 29, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 241, 1, null, 3, 1, 1, 25, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 242, 2, null, 8, 3, 1, 25, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 243, 3, null, 9, 1, 1, 25, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 244, 4, null, 7, 3, 1, 25, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 245, 5, null, 8, 1, 1, 25, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 246, 6, null, 6, 1, 1, 25, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 247, 7, null, 5, 2, 1, 25, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 248, 8, null, 3, 3, 1, 25, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 249, 9, null, 2, 1, 1, 25, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 250, 10, null, 2, 1, 1, 25, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 251, 1, null, 9, 3, 1, 26, new DateTime(2022, 6, 29, 13, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 252, 2, null, 9, 3, 1, 26, new DateTime(2022, 6, 29, 12, 15, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[,]
                {
                    { 253, 3, null, 6, 3, 1, 26, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 254, 4, null, 4, 1, 1, 26, new DateTime(2022, 6, 29, 13, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 255, 5, null, 3, 3, 1, 26, new DateTime(2022, 6, 29, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 256, 6, null, 9, 1, 1, 26, new DateTime(2022, 6, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 257, 7, null, 2, 2, 1, 26, new DateTime(2022, 6, 29, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 258, 8, null, 4, 3, 1, 26, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 259, 9, null, 8, 2, 1, 26, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 260, 10, null, 3, 3, 1, 26, new DateTime(2022, 6, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 261, 1, null, 7, 2, 1, 27, new DateTime(2022, 6, 29, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 262, 2, null, 2, 2, 1, 27, new DateTime(2022, 6, 29, 20, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 263, 3, null, 3, 3, 1, 27, new DateTime(2022, 6, 29, 22, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 264, 4, null, 3, 3, 1, 27, new DateTime(2022, 6, 29, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 265, 5, null, 8, 2, 1, 27, new DateTime(2022, 6, 29, 20, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 266, 6, null, 7, 1, 1, 27, new DateTime(2022, 6, 29, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 267, 7, null, 7, 2, 1, 27, new DateTime(2022, 6, 29, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 268, 8, null, 6, 2, 1, 27, new DateTime(2022, 6, 29, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 269, 9, null, 9, 1, 1, 27, new DateTime(2022, 6, 29, 22, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 270, 10, null, 7, 3, 1, 27, new DateTime(2022, 6, 29, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 271, 1, null, 5, 1, 1, 28, new DateTime(2022, 6, 29, 14, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 272, 2, null, 7, 3, 1, 28, new DateTime(2022, 6, 29, 15, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 273, 3, null, 5, 1, 1, 28, new DateTime(2022, 6, 29, 15, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 274, 4, null, 3, 3, 1, 28, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 275, 5, null, 8, 3, 1, 28, new DateTime(2022, 6, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 276, 6, null, 5, 2, 1, 28, new DateTime(2022, 6, 29, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 277, 7, null, 4, 2, 1, 28, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 278, 8, null, 5, 1, 1, 28, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 279, 9, null, 3, 3, 1, 28, new DateTime(2022, 6, 29, 13, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 280, 10, null, 4, 2, 1, 28, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 281, 1, null, 8, 3, 1, 29, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 282, 2, null, 5, 3, 1, 29, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 283, 3, null, 3, 1, 1, 29, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 284, 4, null, 6, 1, 1, 29, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 285, 5, null, 9, 1, 1, 29, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 286, 6, null, 4, 3, 1, 29, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 287, 7, null, 2, 1, 1, 29, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 288, 8, null, 8, 1, 1, 29, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 289, 9, null, 5, 2, 1, 29, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 290, 10, null, 9, 3, 1, 29, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 291, 1, null, 8, 3, 1, 30, new DateTime(2022, 6, 29, 20, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 292, 2, null, 5, 3, 1, 30, new DateTime(2022, 6, 29, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 293, 3, null, 2, 2, 1, 30, new DateTime(2022, 6, 29, 19, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 294, 4, null, 3, 3, 1, 30, new DateTime(2022, 6, 29, 22, 45, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[,]
                {
                    { 295, 5, null, 2, 3, 1, 30, new DateTime(2022, 6, 29, 22, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 296, 6, null, 8, 1, 1, 30, new DateTime(2022, 6, 29, 22, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 297, 7, null, 9, 3, 1, 30, new DateTime(2022, 6, 29, 22, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 298, 8, null, 2, 1, 1, 30, new DateTime(2022, 6, 29, 22, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 299, 9, null, 2, 2, 1, 30, new DateTime(2022, 6, 29, 21, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 300, 10, null, 9, 2, 1, 30, new DateTime(2022, 6, 29, 18, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 301, 1, null, 3, 1, 1, 31, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 302, 2, null, 9, 2, 1, 31, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 303, 3, null, 2, 3, 1, 31, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 304, 4, null, 9, 1, 1, 31, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 305, 5, null, 7, 1, 1, 31, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 306, 6, null, 5, 1, 1, 31, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 307, 7, null, 4, 2, 1, 31, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 308, 8, null, 8, 3, 1, 31, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 309, 9, null, 5, 3, 1, 31, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 310, 10, null, 2, 2, 1, 31, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 311, 1, null, 5, 1, 1, 32, new DateTime(2022, 6, 29, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 312, 2, null, 2, 2, 1, 32, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 313, 3, null, 8, 3, 1, 32, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 314, 4, null, 9, 2, 1, 32, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 315, 5, null, 5, 2, 1, 32, new DateTime(2022, 6, 29, 15, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 316, 6, null, 2, 1, 1, 32, new DateTime(2022, 6, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 317, 7, null, 6, 2, 1, 32, new DateTime(2022, 6, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 318, 8, null, 5, 2, 1, 32, new DateTime(2022, 6, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 319, 9, null, 6, 2, 1, 32, new DateTime(2022, 6, 29, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 320, 10, null, 6, 1, 1, 32, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 321, 1, null, 2, 2, 1, 33, new DateTime(2022, 6, 29, 20, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 322, 2, null, 8, 1, 1, 33, new DateTime(2022, 6, 29, 18, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 323, 3, null, 4, 1, 1, 33, new DateTime(2022, 6, 29, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 324, 4, null, 7, 1, 1, 33, new DateTime(2022, 6, 29, 18, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 325, 5, null, 8, 3, 1, 33, new DateTime(2022, 6, 29, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 326, 6, null, 5, 2, 1, 33, new DateTime(2022, 6, 29, 22, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 327, 7, null, 6, 3, 1, 33, new DateTime(2022, 6, 29, 22, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 328, 8, null, 5, 3, 1, 33, new DateTime(2022, 6, 29, 22, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 329, 9, null, 7, 2, 1, 33, new DateTime(2022, 6, 29, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 330, 10, null, 4, 1, 1, 33, new DateTime(2022, 6, 29, 22, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 331, 1, null, 3, 2, 1, 34, new DateTime(2022, 6, 29, 13, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 332, 2, null, 2, 1, 1, 34, new DateTime(2022, 6, 29, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 333, 3, null, 6, 2, 1, 34, new DateTime(2022, 6, 29, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 334, 4, null, 4, 2, 1, 34, new DateTime(2022, 6, 29, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 335, 5, null, 2, 1, 1, 34, new DateTime(2022, 6, 29, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 336, 6, null, 3, 2, 1, 34, new DateTime(2022, 6, 29, 12, 15, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[,]
                {
                    { 337, 7, null, 8, 3, 1, 34, new DateTime(2022, 6, 29, 15, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 338, 8, null, 9, 3, 1, 34, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 339, 9, null, 3, 3, 1, 34, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 340, 10, null, 5, 2, 1, 34, new DateTime(2022, 6, 29, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 341, 1, null, 7, 3, 1, 35, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 342, 2, null, 4, 2, 1, 35, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 343, 3, null, 2, 1, 1, 35, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 344, 4, null, 9, 1, 1, 35, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 345, 5, null, 6, 2, 1, 35, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 346, 6, null, 7, 2, 1, 35, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 347, 7, null, 2, 2, 1, 35, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 348, 8, null, 6, 2, 1, 35, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 349, 9, null, 7, 1, 1, 35, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 350, 10, null, 4, 3, 1, 35, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 351, 1, null, 6, 2, 1, 36, new DateTime(2022, 6, 29, 21, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 352, 2, null, 7, 1, 1, 36, new DateTime(2022, 6, 29, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 353, 3, null, 9, 3, 1, 36, new DateTime(2022, 6, 29, 21, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 354, 4, null, 7, 3, 1, 36, new DateTime(2022, 6, 29, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 355, 5, null, 2, 1, 1, 36, new DateTime(2022, 6, 29, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 356, 6, null, 9, 1, 1, 36, new DateTime(2022, 6, 29, 19, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 357, 7, null, 2, 1, 1, 36, new DateTime(2022, 6, 29, 20, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 358, 8, null, 7, 2, 1, 36, new DateTime(2022, 6, 29, 22, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 359, 9, null, 2, 2, 1, 36, new DateTime(2022, 6, 29, 18, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 360, 10, null, 4, 1, 1, 36, new DateTime(2022, 6, 29, 22, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 361, 1, null, 8, 2, 1, 37, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 362, 2, null, 2, 3, 1, 37, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 363, 3, null, 2, 3, 1, 37, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 364, 4, null, 9, 1, 1, 37, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 365, 5, null, 3, 1, 1, 37, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 366, 6, null, 3, 3, 1, 37, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 367, 7, null, 6, 2, 1, 37, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 368, 8, null, 7, 1, 1, 37, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 369, 9, null, 8, 3, 1, 37, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 370, 10, null, 7, 2, 1, 37, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 371, 1, null, 8, 2, 1, 38, new DateTime(2022, 6, 29, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 372, 2, null, 8, 1, 1, 38, new DateTime(2022, 6, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 373, 3, null, 4, 3, 1, 38, new DateTime(2022, 6, 29, 13, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 374, 4, null, 4, 1, 1, 38, new DateTime(2022, 6, 29, 15, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 375, 5, null, 9, 2, 1, 38, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 376, 6, null, 2, 2, 1, 38, new DateTime(2022, 6, 29, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 377, 7, null, 3, 2, 1, 38, new DateTime(2022, 6, 29, 12, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 378, 8, null, 6, 2, 1, 38, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[,]
                {
                    { 379, 9, null, 3, 3, 1, 38, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 380, 10, null, 8, 2, 1, 38, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 381, 1, null, 2, 1, 1, 39, new DateTime(2022, 6, 29, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 382, 2, null, 5, 3, 1, 39, new DateTime(2022, 6, 29, 20, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 383, 3, null, 7, 1, 1, 39, new DateTime(2022, 6, 29, 19, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 384, 4, null, 2, 2, 1, 39, new DateTime(2022, 6, 29, 22, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 385, 5, null, 8, 1, 1, 39, new DateTime(2022, 6, 29, 18, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 386, 6, null, 7, 2, 1, 39, new DateTime(2022, 6, 29, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 387, 7, null, 7, 1, 1, 39, new DateTime(2022, 6, 29, 20, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 388, 8, null, 3, 1, 1, 39, new DateTime(2022, 6, 29, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 389, 9, null, 5, 1, 1, 39, new DateTime(2022, 6, 29, 20, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 390, 10, null, 2, 1, 1, 39, new DateTime(2022, 6, 29, 21, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 391, 1, null, 2, 2, 1, 40, new DateTime(2022, 6, 29, 12, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 392, 2, null, 7, 2, 1, 40, new DateTime(2022, 6, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 393, 3, null, 9, 3, 1, 40, new DateTime(2022, 6, 29, 14, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 394, 4, null, 2, 1, 1, 40, new DateTime(2022, 6, 29, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 395, 5, null, 3, 3, 1, 40, new DateTime(2022, 6, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 396, 6, null, 4, 1, 1, 40, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 397, 7, null, 4, 2, 1, 40, new DateTime(2022, 6, 29, 12, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 398, 8, null, 7, 1, 1, 40, new DateTime(2022, 6, 29, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 399, 9, null, 9, 1, 1, 40, new DateTime(2022, 6, 29, 15, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 400, 10, null, 8, 1, 1, 40, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 401, 1, null, 6, 2, 1, 41, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 402, 2, null, 6, 1, 1, 41, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 403, 3, null, 7, 2, 1, 41, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 404, 4, null, 7, 2, 1, 41, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 405, 5, null, 6, 1, 1, 41, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 406, 6, null, 9, 3, 1, 41, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 407, 7, null, 6, 2, 1, 41, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 408, 8, null, 5, 1, 1, 41, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 409, 9, null, 5, 2, 1, 41, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 410, 10, null, 3, 3, 1, 41, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 411, 1, null, 7, 2, 1, 42, new DateTime(2022, 6, 29, 22, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 412, 2, null, 4, 3, 1, 42, new DateTime(2022, 6, 29, 19, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 413, 3, null, 3, 3, 1, 42, new DateTime(2022, 6, 29, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 414, 4, null, 2, 3, 1, 42, new DateTime(2022, 6, 29, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 415, 5, null, 3, 3, 1, 42, new DateTime(2022, 6, 29, 21, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 416, 6, null, 6, 2, 1, 42, new DateTime(2022, 6, 29, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 417, 7, null, 3, 3, 1, 42, new DateTime(2022, 6, 29, 20, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 418, 8, null, 7, 1, 1, 42, new DateTime(2022, 6, 29, 22, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 419, 9, null, 5, 1, 1, 42, new DateTime(2022, 6, 29, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 420, 10, null, 5, 2, 1, 42, new DateTime(2022, 6, 29, 19, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[,]
                {
                    { 421, 1, null, 7, 1, 1, 43, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 422, 2, null, 9, 2, 1, 43, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 423, 3, null, 6, 1, 1, 43, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 424, 4, null, 6, 3, 1, 43, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 425, 5, null, 8, 2, 1, 43, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 426, 6, null, 2, 2, 1, 43, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 427, 7, null, 8, 1, 1, 43, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 428, 8, null, 5, 1, 1, 43, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 429, 9, null, 4, 3, 1, 43, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 430, 10, null, 2, 2, 1, 43, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 431, 1, null, 7, 1, 1, 44, new DateTime(2022, 6, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 432, 2, null, 8, 3, 1, 44, new DateTime(2022, 6, 29, 14, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 433, 3, null, 9, 2, 1, 44, new DateTime(2022, 6, 29, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 434, 4, null, 3, 3, 1, 44, new DateTime(2022, 6, 29, 14, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 435, 5, null, 4, 2, 1, 44, new DateTime(2022, 6, 29, 15, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 436, 6, null, 3, 1, 1, 44, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 437, 7, null, 7, 2, 1, 44, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 438, 8, null, 6, 2, 1, 44, new DateTime(2022, 6, 29, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 439, 9, null, 5, 1, 1, 44, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 440, 10, null, 3, 2, 1, 44, new DateTime(2022, 6, 29, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 441, 1, null, 6, 3, 1, 45, new DateTime(2022, 6, 29, 20, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 442, 2, null, 3, 3, 1, 45, new DateTime(2022, 6, 29, 18, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 443, 3, null, 2, 3, 1, 45, new DateTime(2022, 6, 29, 19, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 444, 4, null, 9, 1, 1, 45, new DateTime(2022, 6, 29, 21, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 445, 5, null, 8, 1, 1, 45, new DateTime(2022, 6, 29, 18, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 446, 6, null, 8, 3, 1, 45, new DateTime(2022, 6, 29, 18, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 447, 7, null, 6, 1, 1, 45, new DateTime(2022, 6, 29, 20, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 448, 8, null, 5, 1, 1, 45, new DateTime(2022, 6, 29, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 449, 9, null, 9, 2, 1, 45, new DateTime(2022, 6, 29, 18, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 450, 10, null, 6, 1, 1, 45, new DateTime(2022, 6, 29, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 451, 1, null, 3, 1, 1, 46, new DateTime(2022, 6, 29, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 452, 2, null, 6, 1, 1, 46, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 453, 3, null, 7, 2, 1, 46, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 454, 4, null, 7, 1, 1, 46, new DateTime(2022, 6, 29, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 455, 5, null, 6, 2, 1, 46, new DateTime(2022, 6, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 456, 6, null, 8, 2, 1, 46, new DateTime(2022, 6, 29, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 457, 7, null, 8, 1, 1, 46, new DateTime(2022, 6, 29, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 458, 8, null, 3, 2, 1, 46, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 459, 9, null, 2, 3, 1, 46, new DateTime(2022, 6, 29, 13, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 460, 10, null, 6, 2, 1, 46, new DateTime(2022, 6, 29, 13, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 461, 1, null, 9, 1, 1, 47, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 462, 2, null, 4, 2, 1, 47, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[,]
                {
                    { 463, 3, null, 5, 3, 1, 47, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 464, 4, null, 8, 1, 1, 47, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 465, 5, null, 2, 2, 1, 47, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 466, 6, null, 9, 3, 1, 47, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 467, 7, null, 8, 1, 1, 47, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 468, 8, null, 2, 2, 1, 47, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 469, 9, null, 3, 1, 1, 47, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 470, 10, null, 7, 3, 1, 47, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 471, 1, null, 6, 3, 1, 48, new DateTime(2022, 6, 29, 22, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 472, 2, null, 8, 2, 1, 48, new DateTime(2022, 6, 29, 18, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 473, 3, null, 9, 3, 1, 48, new DateTime(2022, 6, 29, 19, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 474, 4, null, 3, 2, 1, 48, new DateTime(2022, 6, 29, 21, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 475, 5, null, 9, 2, 1, 48, new DateTime(2022, 6, 29, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 476, 6, null, 2, 3, 1, 48, new DateTime(2022, 6, 29, 20, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 477, 7, null, 8, 3, 1, 48, new DateTime(2022, 6, 29, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 478, 8, null, 2, 1, 1, 48, new DateTime(2022, 6, 29, 18, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 479, 9, null, 6, 1, 1, 48, new DateTime(2022, 6, 29, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 480, 10, null, 3, 1, 1, 48, new DateTime(2022, 6, 29, 19, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 481, 1, null, 8, 3, 1, 49, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 482, 2, null, 5, 2, 1, 49, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 483, 3, null, 9, 2, 1, 49, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 484, 4, null, 7, 1, 1, 49, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 485, 5, null, 7, 1, 1, 49, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 486, 6, null, 5, 1, 1, 49, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 487, 7, null, 8, 3, 1, 49, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 488, 8, null, 5, 1, 1, 49, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 489, 9, null, 2, 1, 1, 49, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 490, 10, null, 7, 3, 1, 49, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 491, 1, null, 7, 3, 1, 50, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 492, 2, null, 5, 2, 1, 50, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 493, 3, null, 9, 3, 1, 50, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 494, 4, null, 8, 1, 1, 50, new DateTime(2022, 6, 29, 14, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 495, 5, null, 7, 3, 1, 50, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 496, 6, null, 3, 1, 1, 50, new DateTime(2022, 6, 29, 12, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 497, 7, null, 5, 2, 1, 50, new DateTime(2022, 6, 29, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 498, 8, null, 5, 1, 1, 50, new DateTime(2022, 6, 29, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 499, 9, null, 2, 2, 1, 50, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 500, 10, null, 7, 2, 1, 50, new DateTime(2022, 6, 29, 15, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 501, 1, null, 5, 1, 1, 51, new DateTime(2022, 6, 29, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 502, 2, null, 8, 3, 1, 51, new DateTime(2022, 6, 29, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 503, 3, null, 2, 2, 1, 51, new DateTime(2022, 6, 29, 21, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 504, 4, null, 8, 3, 1, 51, new DateTime(2022, 6, 29, 22, 45, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[,]
                {
                    { 505, 5, null, 3, 2, 1, 51, new DateTime(2022, 6, 29, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 506, 6, null, 3, 1, 1, 51, new DateTime(2022, 6, 29, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 507, 7, null, 2, 1, 1, 51, new DateTime(2022, 6, 29, 20, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 508, 8, null, 9, 1, 1, 51, new DateTime(2022, 6, 29, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 509, 9, null, 6, 1, 1, 51, new DateTime(2022, 6, 29, 19, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 510, 10, null, 9, 3, 1, 51, new DateTime(2022, 6, 29, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 511, 1, null, 3, 2, 1, 52, new DateTime(2022, 6, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 512, 2, null, 3, 3, 1, 52, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 513, 3, null, 5, 2, 1, 52, new DateTime(2022, 6, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 514, 4, null, 2, 1, 1, 52, new DateTime(2022, 6, 29, 14, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 515, 5, null, 3, 1, 1, 52, new DateTime(2022, 6, 29, 14, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 516, 6, null, 6, 1, 1, 52, new DateTime(2022, 6, 29, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 517, 7, null, 4, 2, 1, 52, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 518, 8, null, 8, 2, 1, 52, new DateTime(2022, 6, 29, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 519, 9, null, 4, 1, 1, 52, new DateTime(2022, 6, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 520, 10, null, 3, 1, 1, 52, new DateTime(2022, 6, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 521, 1, null, 2, 1, 1, 53, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 522, 2, null, 2, 1, 1, 53, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 523, 3, null, 5, 3, 1, 53, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 524, 4, null, 8, 3, 1, 53, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 525, 5, null, 2, 1, 1, 53, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 526, 6, null, 7, 2, 1, 53, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 527, 7, null, 4, 2, 1, 53, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 528, 8, null, 8, 1, 1, 53, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 529, 9, null, 6, 3, 1, 53, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 530, 10, null, 6, 3, 1, 53, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 531, 1, null, 6, 3, 1, 54, new DateTime(2022, 6, 29, 20, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 532, 2, null, 7, 2, 1, 54, new DateTime(2022, 6, 29, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 533, 3, null, 4, 1, 1, 54, new DateTime(2022, 6, 29, 20, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 534, 4, null, 4, 2, 1, 54, new DateTime(2022, 6, 29, 19, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 535, 5, null, 6, 2, 1, 54, new DateTime(2022, 6, 29, 20, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 536, 6, null, 8, 3, 1, 54, new DateTime(2022, 6, 29, 18, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 537, 7, null, 4, 1, 1, 54, new DateTime(2022, 6, 29, 21, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 538, 8, null, 7, 2, 1, 54, new DateTime(2022, 6, 29, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 539, 9, null, 4, 3, 1, 54, new DateTime(2022, 6, 29, 22, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 540, 10, null, 5, 2, 1, 54, new DateTime(2022, 6, 29, 22, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 541, 1, null, 5, 2, 1, 55, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 542, 2, null, 9, 3, 1, 55, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 543, 3, null, 3, 2, 1, 55, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 544, 4, null, 3, 3, 1, 55, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 545, 5, null, 8, 1, 1, 55, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 546, 6, null, 3, 2, 1, 55, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[,]
                {
                    { 547, 7, null, 7, 1, 1, 55, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 548, 8, null, 3, 2, 1, 55, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 549, 9, null, 6, 3, 1, 55, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 550, 10, null, 3, 3, 1, 55, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 551, 1, null, 7, 2, 1, 56, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 552, 2, null, 3, 1, 1, 56, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 553, 3, null, 2, 1, 1, 56, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 554, 4, null, 7, 3, 1, 56, new DateTime(2022, 6, 29, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 555, 5, null, 4, 2, 1, 56, new DateTime(2022, 6, 29, 14, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 556, 6, null, 2, 3, 1, 56, new DateTime(2022, 6, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 557, 7, null, 9, 1, 1, 56, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 558, 8, null, 2, 2, 1, 56, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 559, 9, null, 6, 3, 1, 56, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 560, 10, null, 3, 3, 1, 56, new DateTime(2022, 6, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 561, 1, null, 4, 3, 1, 57, new DateTime(2022, 6, 29, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 562, 2, null, 4, 3, 1, 57, new DateTime(2022, 6, 29, 18, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 563, 3, null, 3, 1, 1, 57, new DateTime(2022, 6, 29, 22, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 564, 4, null, 5, 2, 1, 57, new DateTime(2022, 6, 29, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 565, 5, null, 6, 2, 1, 57, new DateTime(2022, 6, 29, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 566, 6, null, 2, 1, 1, 57, new DateTime(2022, 6, 29, 20, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 567, 7, null, 7, 1, 1, 57, new DateTime(2022, 6, 29, 21, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 568, 8, null, 2, 1, 1, 57, new DateTime(2022, 6, 29, 19, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 569, 9, null, 2, 2, 1, 57, new DateTime(2022, 6, 29, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 570, 10, null, 8, 1, 1, 57, new DateTime(2022, 6, 29, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 571, 1, null, 2, 3, 1, 58, new DateTime(2022, 6, 29, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 572, 2, null, 7, 3, 1, 58, new DateTime(2022, 6, 29, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 573, 3, null, 9, 3, 1, 58, new DateTime(2022, 6, 29, 13, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 574, 4, null, 8, 1, 1, 58, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 575, 5, null, 4, 3, 1, 58, new DateTime(2022, 6, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 576, 6, null, 4, 3, 1, 58, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 577, 7, null, 8, 1, 1, 58, new DateTime(2022, 6, 29, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 578, 8, null, 6, 1, 1, 58, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 579, 9, null, 3, 3, 1, 58, new DateTime(2022, 6, 29, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 580, 10, null, 9, 3, 1, 58, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 581, 1, null, 3, 2, 1, 59, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 582, 2, null, 8, 3, 1, 59, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 583, 3, null, 7, 1, 1, 59, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 584, 4, null, 3, 3, 1, 59, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 585, 5, null, 8, 1, 1, 59, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 586, 6, null, 2, 2, 1, 59, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 587, 7, null, 2, 2, 1, 59, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 588, 8, null, 3, 2, 1, 59, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[,]
                {
                    { 589, 9, null, 3, 3, 1, 59, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 590, 10, null, 7, 3, 1, 59, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 591, 1, null, 4, 3, 1, 60, new DateTime(2022, 6, 29, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 592, 2, null, 6, 2, 1, 60, new DateTime(2022, 6, 29, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 593, 3, null, 6, 3, 1, 60, new DateTime(2022, 6, 29, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 594, 4, null, 2, 2, 1, 60, new DateTime(2022, 6, 29, 20, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 595, 5, null, 2, 1, 1, 60, new DateTime(2022, 6, 29, 18, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 596, 6, null, 8, 3, 1, 60, new DateTime(2022, 6, 29, 22, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 597, 7, null, 2, 3, 1, 60, new DateTime(2022, 6, 29, 21, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 598, 8, null, 9, 3, 1, 60, new DateTime(2022, 6, 29, 20, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 599, 9, null, 3, 3, 1, 60, new DateTime(2022, 6, 29, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 600, 10, null, 5, 2, 1, 60, new DateTime(2022, 6, 29, 22, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 601, 1, null, 2, 3, 1, 61, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 602, 2, null, 4, 3, 1, 61, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 603, 3, null, 9, 3, 1, 61, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 604, 4, null, 4, 1, 1, 61, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 605, 5, null, 2, 1, 1, 61, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 606, 6, null, 6, 2, 1, 61, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 607, 7, null, 8, 1, 1, 61, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 608, 8, null, 4, 1, 1, 61, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 609, 9, null, 4, 3, 1, 61, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 610, 10, null, 8, 3, 1, 61, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 611, 1, null, 6, 3, 1, 62, new DateTime(2022, 6, 29, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 612, 2, null, 4, 3, 1, 62, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 613, 3, null, 2, 3, 1, 62, new DateTime(2022, 6, 29, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 614, 4, null, 6, 2, 1, 62, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 615, 5, null, 3, 1, 1, 62, new DateTime(2022, 6, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 616, 6, null, 6, 3, 1, 62, new DateTime(2022, 6, 29, 15, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 617, 7, null, 3, 3, 1, 62, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 618, 8, null, 9, 3, 1, 62, new DateTime(2022, 6, 29, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 619, 9, null, 9, 3, 1, 62, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 620, 10, null, 8, 1, 1, 62, new DateTime(2022, 6, 29, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 621, 1, null, 4, 1, 1, 63, new DateTime(2022, 6, 29, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 622, 2, null, 5, 1, 1, 63, new DateTime(2022, 6, 29, 20, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 623, 3, null, 8, 3, 1, 63, new DateTime(2022, 6, 29, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 624, 4, null, 2, 1, 1, 63, new DateTime(2022, 6, 29, 20, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 625, 5, null, 9, 1, 1, 63, new DateTime(2022, 6, 29, 18, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 626, 6, null, 9, 1, 1, 63, new DateTime(2022, 6, 29, 18, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 627, 7, null, 7, 2, 1, 63, new DateTime(2022, 6, 29, 19, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 628, 8, null, 9, 3, 1, 63, new DateTime(2022, 6, 29, 20, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 629, 9, null, 4, 2, 1, 63, new DateTime(2022, 6, 29, 20, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 630, 10, null, 2, 1, 1, 63, new DateTime(2022, 6, 29, 20, 45, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[,]
                {
                    { 631, 1, null, 6, 3, 1, 64, new DateTime(2022, 6, 29, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 632, 2, null, 5, 1, 1, 64, new DateTime(2022, 6, 29, 15, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 633, 3, null, 6, 2, 1, 64, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 634, 4, null, 2, 2, 1, 64, new DateTime(2022, 6, 29, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 635, 5, null, 6, 2, 1, 64, new DateTime(2022, 6, 29, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 636, 6, null, 9, 2, 1, 64, new DateTime(2022, 6, 29, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 637, 7, null, 6, 1, 1, 64, new DateTime(2022, 6, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 638, 8, null, 6, 1, 1, 64, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 639, 9, null, 2, 2, 1, 64, new DateTime(2022, 6, 29, 12, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 640, 10, null, 2, 3, 1, 64, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 641, 1, null, 3, 2, 1, 65, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 642, 2, null, 2, 3, 1, 65, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 643, 3, null, 6, 3, 1, 65, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 644, 4, null, 7, 3, 1, 65, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 645, 5, null, 4, 1, 1, 65, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 646, 6, null, 6, 3, 1, 65, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 647, 7, null, 6, 1, 1, 65, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 648, 8, null, 3, 1, 1, 65, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 649, 9, null, 2, 3, 1, 65, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 650, 10, null, 6, 2, 1, 65, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 651, 1, null, 2, 2, 1, 66, new DateTime(2022, 6, 29, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 652, 2, null, 7, 1, 1, 66, new DateTime(2022, 6, 29, 20, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 653, 3, null, 3, 3, 1, 66, new DateTime(2022, 6, 29, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 654, 4, null, 6, 2, 1, 66, new DateTime(2022, 6, 29, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 655, 5, null, 9, 2, 1, 66, new DateTime(2022, 6, 29, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 656, 6, null, 5, 1, 1, 66, new DateTime(2022, 6, 29, 21, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 657, 7, null, 4, 1, 1, 66, new DateTime(2022, 6, 29, 21, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 658, 8, null, 4, 2, 1, 66, new DateTime(2022, 6, 29, 21, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 659, 9, null, 6, 2, 1, 66, new DateTime(2022, 6, 29, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 660, 10, null, 5, 1, 1, 66, new DateTime(2022, 6, 29, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 661, 1, null, 2, 3, 1, 67, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 662, 2, null, 3, 2, 1, 67, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 663, 3, null, 7, 2, 1, 67, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 664, 4, null, 7, 1, 1, 67, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 665, 5, null, 8, 2, 1, 67, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 666, 6, null, 7, 2, 1, 67, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 667, 7, null, 5, 3, 1, 67, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 668, 8, null, 4, 2, 1, 67, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 669, 9, null, 7, 1, 1, 67, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 670, 10, null, 4, 1, 1, 67, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 671, 1, null, 9, 1, 1, 68, new DateTime(2022, 6, 29, 13, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 672, 2, null, 8, 3, 1, 68, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[,]
                {
                    { 673, 3, null, 3, 1, 1, 68, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 674, 4, null, 2, 1, 1, 68, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 675, 5, null, 8, 1, 1, 68, new DateTime(2022, 6, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 676, 6, null, 7, 1, 1, 68, new DateTime(2022, 6, 29, 12, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 677, 7, null, 9, 3, 1, 68, new DateTime(2022, 6, 29, 12, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 678, 8, null, 3, 1, 1, 68, new DateTime(2022, 6, 29, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 679, 9, null, 9, 3, 1, 68, new DateTime(2022, 6, 29, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 680, 10, null, 6, 3, 1, 68, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 681, 1, null, 3, 3, 1, 69, new DateTime(2022, 6, 29, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 682, 2, null, 6, 3, 1, 69, new DateTime(2022, 6, 29, 22, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 683, 3, null, 8, 2, 1, 69, new DateTime(2022, 6, 29, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 684, 4, null, 4, 2, 1, 69, new DateTime(2022, 6, 29, 20, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 685, 5, null, 4, 2, 1, 69, new DateTime(2022, 6, 29, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 686, 6, null, 9, 3, 1, 69, new DateTime(2022, 6, 29, 20, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 687, 7, null, 9, 3, 1, 69, new DateTime(2022, 6, 29, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 688, 8, null, 9, 2, 1, 69, new DateTime(2022, 6, 29, 22, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 689, 9, null, 4, 1, 1, 69, new DateTime(2022, 6, 29, 19, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 690, 10, null, 4, 3, 1, 69, new DateTime(2022, 6, 29, 20, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 691, 1, null, 3, 2, 1, 70, new DateTime(2022, 6, 29, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 692, 2, null, 7, 1, 1, 70, new DateTime(2022, 6, 29, 13, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 693, 3, null, 8, 3, 1, 70, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 694, 4, null, 7, 2, 1, 70, new DateTime(2022, 6, 29, 14, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 695, 5, null, 9, 2, 1, 70, new DateTime(2022, 6, 29, 12, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 696, 6, null, 9, 1, 1, 70, new DateTime(2022, 6, 29, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 697, 7, null, 2, 3, 1, 70, new DateTime(2022, 6, 29, 15, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 698, 8, null, 4, 3, 1, 70, new DateTime(2022, 6, 29, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 699, 9, null, 3, 3, 1, 70, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 700, 10, null, 9, 3, 1, 70, new DateTime(2022, 6, 29, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 701, 1, null, 2, 1, 1, 71, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 702, 2, null, 9, 2, 1, 71, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 703, 3, null, 2, 2, 1, 71, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 704, 4, null, 4, 2, 1, 71, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 705, 5, null, 7, 1, 1, 71, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 706, 6, null, 7, 2, 1, 71, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 707, 7, null, 7, 3, 1, 71, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 708, 8, null, 4, 1, 1, 71, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 709, 9, null, 3, 1, 1, 71, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 710, 10, null, 5, 3, 1, 71, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 711, 1, null, 5, 3, 1, 72, new DateTime(2022, 6, 29, 22, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 712, 2, null, 8, 2, 1, 72, new DateTime(2022, 6, 29, 21, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 713, 3, null, 8, 3, 1, 72, new DateTime(2022, 6, 29, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 714, 4, null, 5, 2, 1, 72, new DateTime(2022, 6, 29, 18, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[,]
                {
                    { 715, 5, null, 9, 1, 1, 72, new DateTime(2022, 6, 29, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 716, 6, null, 2, 1, 1, 72, new DateTime(2022, 6, 29, 22, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 717, 7, null, 5, 2, 1, 72, new DateTime(2022, 6, 29, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 718, 8, null, 4, 1, 1, 72, new DateTime(2022, 6, 29, 21, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 719, 9, null, 9, 3, 1, 72, new DateTime(2022, 6, 29, 19, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 720, 10, null, 8, 2, 1, 72, new DateTime(2022, 6, 29, 19, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 721, 1, null, 4, 3, 1, 73, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 722, 2, null, 7, 2, 1, 73, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 723, 3, null, 2, 2, 1, 73, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 724, 4, null, 6, 3, 1, 73, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 725, 5, null, 2, 2, 1, 73, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 726, 6, null, 8, 1, 1, 73, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 727, 7, null, 2, 3, 1, 73, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 728, 8, null, 8, 2, 1, 73, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 729, 9, null, 5, 3, 1, 73, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 730, 10, null, 2, 3, 1, 73, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 731, 1, null, 6, 2, 1, 74, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 732, 2, null, 4, 2, 1, 74, new DateTime(2022, 6, 29, 13, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 733, 3, null, 4, 1, 1, 74, new DateTime(2022, 6, 29, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 734, 4, null, 6, 3, 1, 74, new DateTime(2022, 6, 29, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 735, 5, null, 9, 2, 1, 74, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 736, 6, null, 9, 1, 1, 74, new DateTime(2022, 6, 29, 12, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 737, 7, null, 8, 2, 1, 74, new DateTime(2022, 6, 29, 14, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 738, 8, null, 4, 2, 1, 74, new DateTime(2022, 6, 29, 14, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 739, 9, null, 7, 2, 1, 74, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 740, 10, null, 4, 3, 1, 74, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 741, 1, null, 9, 1, 1, 75, new DateTime(2022, 6, 29, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 742, 2, null, 3, 1, 1, 75, new DateTime(2022, 6, 29, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 743, 3, null, 5, 1, 1, 75, new DateTime(2022, 6, 29, 20, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 744, 4, null, 3, 2, 1, 75, new DateTime(2022, 6, 29, 20, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 745, 5, null, 2, 2, 1, 75, new DateTime(2022, 6, 29, 19, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 746, 6, null, 8, 3, 1, 75, new DateTime(2022, 6, 29, 20, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 747, 7, null, 3, 1, 1, 75, new DateTime(2022, 6, 29, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 748, 8, null, 8, 2, 1, 75, new DateTime(2022, 6, 29, 22, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 749, 9, null, 8, 2, 1, 75, new DateTime(2022, 6, 29, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 750, 10, null, 7, 2, 1, 75, new DateTime(2022, 6, 29, 22, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 751, 1, null, 3, 1, 1, 76, new DateTime(2022, 6, 29, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 752, 2, null, 7, 1, 1, 76, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 753, 3, null, 4, 1, 1, 76, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 754, 4, null, 8, 2, 1, 76, new DateTime(2022, 6, 29, 12, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 755, 5, null, 3, 2, 1, 76, new DateTime(2022, 6, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 756, 6, null, 4, 1, 1, 76, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[,]
                {
                    { 757, 7, null, 2, 1, 1, 76, new DateTime(2022, 6, 29, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 758, 8, null, 5, 3, 1, 76, new DateTime(2022, 6, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 759, 9, null, 6, 2, 1, 76, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 760, 10, null, 2, 1, 1, 76, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 761, 1, null, 3, 1, 1, 77, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 762, 2, null, 5, 2, 1, 77, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 763, 3, null, 4, 1, 1, 77, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 764, 4, null, 6, 3, 1, 77, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 765, 5, null, 3, 1, 1, 77, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 766, 6, null, 3, 2, 1, 77, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 767, 7, null, 9, 3, 1, 77, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 768, 8, null, 2, 1, 1, 77, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 769, 9, null, 5, 2, 1, 77, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 770, 10, null, 5, 3, 1, 77, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 771, 1, null, 8, 1, 1, 78, new DateTime(2022, 6, 29, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 772, 2, null, 5, 1, 1, 78, new DateTime(2022, 6, 29, 20, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 773, 3, null, 4, 3, 1, 78, new DateTime(2022, 6, 29, 18, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 774, 4, null, 2, 1, 1, 78, new DateTime(2022, 6, 29, 18, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 775, 5, null, 8, 2, 1, 78, new DateTime(2022, 6, 29, 20, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 776, 6, null, 2, 1, 1, 78, new DateTime(2022, 6, 29, 21, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 777, 7, null, 8, 2, 1, 78, new DateTime(2022, 6, 29, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 778, 8, null, 3, 3, 1, 78, new DateTime(2022, 6, 29, 22, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 779, 9, null, 2, 3, 1, 78, new DateTime(2022, 6, 29, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 780, 10, null, 6, 1, 1, 78, new DateTime(2022, 6, 29, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 781, 1, null, 7, 1, 1, 79, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 782, 2, null, 5, 1, 1, 79, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 783, 3, null, 8, 1, 1, 79, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 784, 4, null, 9, 2, 1, 79, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 785, 5, null, 5, 1, 1, 79, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 786, 6, null, 5, 1, 1, 79, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 787, 7, null, 2, 1, 1, 79, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 788, 8, null, 7, 2, 1, 79, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 789, 9, null, 9, 1, 1, 79, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 790, 10, null, 3, 3, 1, 79, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 791, 1, null, 7, 1, 1, 80, new DateTime(2022, 6, 29, 14, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 792, 2, null, 7, 1, 1, 80, new DateTime(2022, 6, 29, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 793, 3, null, 8, 3, 1, 80, new DateTime(2022, 6, 29, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 794, 4, null, 4, 3, 1, 80, new DateTime(2022, 6, 29, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 795, 5, null, 6, 2, 1, 80, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 796, 6, null, 9, 3, 1, 80, new DateTime(2022, 6, 29, 13, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 797, 7, null, 5, 3, 1, 80, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 798, 8, null, 5, 2, 1, 80, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[,]
                {
                    { 799, 9, null, 9, 1, 1, 80, new DateTime(2022, 6, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 800, 10, null, 3, 3, 1, 80, new DateTime(2022, 6, 29, 12, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 801, 1, null, 3, 2, 1, 81, new DateTime(2022, 6, 29, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 802, 2, null, 4, 1, 1, 81, new DateTime(2022, 6, 29, 20, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 803, 3, null, 8, 2, 1, 81, new DateTime(2022, 6, 29, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 804, 4, null, 6, 3, 1, 81, new DateTime(2022, 6, 29, 18, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 805, 5, null, 7, 2, 1, 81, new DateTime(2022, 6, 29, 21, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 806, 6, null, 2, 3, 1, 81, new DateTime(2022, 6, 29, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 807, 7, null, 3, 2, 1, 81, new DateTime(2022, 6, 29, 22, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 808, 8, null, 3, 3, 1, 81, new DateTime(2022, 6, 29, 18, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 809, 9, null, 3, 1, 1, 81, new DateTime(2022, 6, 29, 21, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 810, 10, null, 5, 3, 1, 81, new DateTime(2022, 6, 29, 20, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 811, 1, null, 3, 1, 1, 82, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 812, 2, null, 4, 3, 1, 82, new DateTime(2022, 6, 29, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 813, 3, null, 8, 1, 1, 82, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 814, 4, null, 7, 1, 1, 82, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 815, 5, null, 9, 1, 1, 82, new DateTime(2022, 6, 29, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 816, 6, null, 3, 3, 1, 82, new DateTime(2022, 6, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 817, 7, null, 2, 2, 1, 82, new DateTime(2022, 6, 29, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 818, 8, null, 9, 3, 1, 82, new DateTime(2022, 6, 29, 12, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 819, 9, null, 3, 2, 1, 82, new DateTime(2022, 6, 29, 13, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 820, 10, null, 9, 3, 1, 82, new DateTime(2022, 6, 29, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 821, 1, null, 4, 2, 1, 83, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 822, 2, null, 3, 3, 1, 83, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 823, 3, null, 8, 2, 1, 83, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 824, 4, null, 2, 1, 1, 83, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 825, 5, null, 7, 1, 1, 83, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 826, 6, null, 6, 3, 1, 83, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 827, 7, null, 6, 1, 1, 83, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 828, 8, null, 8, 3, 1, 83, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 829, 9, null, 4, 1, 1, 83, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 830, 10, null, 4, 2, 1, 83, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 831, 1, null, 5, 1, 1, 84, new DateTime(2022, 6, 29, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 832, 2, null, 4, 2, 1, 84, new DateTime(2022, 6, 29, 18, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 833, 3, null, 8, 2, 1, 84, new DateTime(2022, 6, 29, 19, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 834, 4, null, 4, 3, 1, 84, new DateTime(2022, 6, 29, 22, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 835, 5, null, 8, 2, 1, 84, new DateTime(2022, 6, 29, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 836, 6, null, 2, 1, 1, 84, new DateTime(2022, 6, 29, 20, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 837, 7, null, 6, 3, 1, 84, new DateTime(2022, 6, 29, 22, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 838, 8, null, 4, 2, 1, 84, new DateTime(2022, 6, 29, 18, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 839, 9, null, 9, 2, 1, 84, new DateTime(2022, 6, 29, 21, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 840, 10, null, 6, 3, 1, 84, new DateTime(2022, 6, 29, 19, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[,]
                {
                    { 841, 1, null, 3, 2, 1, 85, new DateTime(2022, 6, 29, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 842, 2, null, 8, 2, 1, 85, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 843, 3, null, 9, 3, 1, 85, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 844, 4, null, 8, 3, 1, 85, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 845, 5, null, 7, 1, 1, 85, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 846, 6, null, 3, 2, 1, 85, new DateTime(2022, 6, 29, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 847, 7, null, 9, 2, 1, 85, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 848, 8, null, 7, 2, 1, 85, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 849, 9, null, 7, 2, 1, 85, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 850, 10, null, 3, 2, 1, 85, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 851, 1, null, 7, 2, 1, 86, new DateTime(2022, 6, 29, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 852, 2, null, 9, 3, 1, 86, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 853, 3, null, 7, 2, 1, 86, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 854, 4, null, 6, 1, 1, 86, new DateTime(2022, 6, 29, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 855, 5, null, 9, 1, 1, 86, new DateTime(2022, 6, 29, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 856, 6, null, 8, 2, 1, 86, new DateTime(2022, 6, 29, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 857, 7, null, 8, 1, 1, 86, new DateTime(2022, 6, 29, 14, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 858, 8, null, 8, 1, 1, 86, new DateTime(2022, 6, 29, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 859, 9, null, 2, 2, 1, 86, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 860, 10, null, 7, 2, 1, 86, new DateTime(2022, 6, 29, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 861, 1, null, 4, 1, 1, 87, new DateTime(2022, 6, 29, 22, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 862, 2, null, 2, 2, 1, 87, new DateTime(2022, 6, 29, 19, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 863, 3, null, 3, 1, 1, 87, new DateTime(2022, 6, 29, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 864, 4, null, 3, 1, 1, 87, new DateTime(2022, 6, 29, 19, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 865, 5, null, 7, 2, 1, 87, new DateTime(2022, 6, 29, 19, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 866, 6, null, 3, 1, 1, 87, new DateTime(2022, 6, 29, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 867, 7, null, 6, 3, 1, 87, new DateTime(2022, 6, 29, 19, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 868, 8, null, 5, 2, 1, 87, new DateTime(2022, 6, 29, 19, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 869, 9, null, 7, 3, 1, 87, new DateTime(2022, 6, 29, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 870, 10, null, 2, 1, 1, 87, new DateTime(2022, 6, 29, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 871, 1, null, 4, 1, 1, 88, new DateTime(2022, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 872, 2, null, 9, 1, 1, 88, new DateTime(2022, 6, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 873, 3, null, 4, 2, 1, 88, new DateTime(2022, 6, 29, 15, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 874, 4, null, 7, 3, 1, 88, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 875, 5, null, 2, 2, 1, 88, new DateTime(2022, 6, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 876, 6, null, 9, 3, 1, 88, new DateTime(2022, 6, 29, 15, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 877, 7, null, 5, 2, 1, 88, new DateTime(2022, 6, 29, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 878, 8, null, 7, 2, 1, 88, new DateTime(2022, 6, 29, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 879, 9, null, 4, 1, 1, 88, new DateTime(2022, 6, 29, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 880, 10, null, 9, 3, 1, 88, new DateTime(2022, 6, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 881, 1, null, 9, 1, 1, 89, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 882, 2, null, 8, 1, 1, 89, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[,]
                {
                    { 883, 3, null, 4, 3, 1, 89, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 884, 4, null, 9, 2, 1, 89, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 885, 5, null, 5, 3, 1, 89, new DateTime(2022, 6, 29, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 886, 6, null, 4, 3, 1, 89, new DateTime(2022, 6, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 887, 7, null, 5, 2, 1, 89, new DateTime(2022, 6, 29, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 888, 8, null, 7, 2, 1, 89, new DateTime(2022, 6, 29, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 889, 9, null, 3, 2, 1, 89, new DateTime(2022, 6, 29, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 890, 10, null, 3, 1, 1, 89, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 891, 1, null, 4, 3, 1, 90, new DateTime(2022, 6, 29, 21, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 892, 2, null, 3, 3, 1, 90, new DateTime(2022, 6, 29, 21, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 893, 3, null, 3, 2, 1, 90, new DateTime(2022, 6, 29, 19, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 894, 4, null, 5, 3, 1, 90, new DateTime(2022, 6, 29, 19, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 895, 5, null, 3, 3, 1, 90, new DateTime(2022, 6, 29, 20, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 896, 6, null, 3, 3, 1, 90, new DateTime(2022, 6, 29, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 897, 7, null, 3, 3, 1, 90, new DateTime(2022, 6, 29, 21, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 898, 8, null, 6, 3, 1, 90, new DateTime(2022, 6, 29, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 899, 9, null, 9, 3, 1, 90, new DateTime(2022, 6, 29, 20, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 900, 10, null, 4, 3, 1, 90, new DateTime(2022, 6, 29, 20, 15, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_RestaurantId",
                table: "Areas",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_People_RestaurantId",
                table: "People",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationOriginId",
                table: "Reservations",
                column: "ReservationOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationStatusId",
                table: "Reservations",
                column: "ReservationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SittingId",
                table: "Reservations",
                column: "SittingId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationTables_ReservationId",
                table: "ReservationTables",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationTables_TableId",
                table: "ReservationTables",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Sittings_RestaurantId",
                table: "Sittings",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Sittings_SittingTypeId",
                table: "Sittings",
                column: "SittingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_AreaId",
                table: "Tables",
                column: "AreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ReservationTables");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ReservationOrigins");

            migrationBuilder.DropTable(
                name: "ReservationStatuses");

            migrationBuilder.DropTable(
                name: "Sittings");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "SittingTypes");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
