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
                    { 1, "Seed@Person1.com", "SeedPersonFN1", "SeedPersonLN1", "04100100", 1, "1337x4" },
                    { 2, "Seed@Person2.com", "SeedPersonFN2", "SeedPersonLN2", "04200200", 1, null },
                    { 3, "Seed@Person3.com", "SeedPersonFN3", "SeedPersonLN3", "04300300", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Cutoff", "Duration", "GroupId", "Interval", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[,]
                {
                    { 1, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 6, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 6, 29, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 30, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 6, 30, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 6, 30, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 1, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 2, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 2, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 2, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 3, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 3, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 3, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 4, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 4, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 4, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 5, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 5, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 5, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 6, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 6, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 6, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 7, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 7, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 7, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 8, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 8, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 8, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 9, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 9, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 9, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 10, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 10, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 10, 18, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Cutoff", "Duration", "GroupId", "Interval", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[,]
                {
                    { 37, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 11, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 11, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 11, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 12, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 12, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 12, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 13, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 13, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 13, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 14, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 14, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 14, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 15, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 15, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 16, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 16, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 16, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 17, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 17, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 17, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 18, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 18, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 18, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 19, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 19, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 19, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 20, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 20, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 21, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 21, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 21, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 22, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 22, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 22, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 23, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 23, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 23, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 24, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 24, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 24, 18, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Cutoff", "Duration", "GroupId", "Interval", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[,]
                {
                    { 79, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 25, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 25, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 25, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 82, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 26, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 83, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 26, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 84, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 26, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 85, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 27, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 86, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 27, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 87, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 27, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 88, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 28, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 89, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 28, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 90, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 28, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 91, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 92, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 29, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 94, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 30, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 95, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 30, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 96, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 30, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 97, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 31, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 98, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 7, 31, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 99, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 7, 31, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 100, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 1, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 101, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 102, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 103, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 2, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 104, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 2, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 105, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 2, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 106, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 3, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 107, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 3, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 108, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 3, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 109, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 4, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 110, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 4, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 111, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 4, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 112, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 5, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 113, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 5, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 114, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 5, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 115, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 6, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 116, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 6, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 117, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 6, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 118, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 7, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 119, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 7, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 120, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 7, 18, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Cutoff", "Duration", "GroupId", "Interval", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[,]
                {
                    { 121, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 8, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 122, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 8, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 123, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 8, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 124, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 9, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 125, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 9, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 126, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 9, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 127, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 10, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 128, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 10, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 129, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 10, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 130, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 11, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 131, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 11, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 132, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 11, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 133, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 12, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 134, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 12, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 135, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 12, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 136, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 13, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 137, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 13, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 138, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 13, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 139, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 14, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 140, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 14, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 141, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 14, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 142, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 15, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 143, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 144, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 15, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 145, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 16, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 146, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 16, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 147, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 16, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 148, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 17, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 149, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 17, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 150, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 17, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 151, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 18, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 152, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 18, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 153, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 18, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 154, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 19, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 155, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 156, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 19, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 157, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 20, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 158, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 159, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 20, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 160, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 21, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 161, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 21, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 162, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 21, 18, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Cutoff", "Duration", "GroupId", "Interval", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[,]
                {
                    { 163, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 22, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 164, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 22, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 165, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 22, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 166, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 23, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 167, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 23, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 168, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 23, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 169, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 24, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 170, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 24, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 171, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 24, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 172, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 25, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 173, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 25, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 174, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 25, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 175, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 26, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 176, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 26, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 177, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 26, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 178, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 27, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 179, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 27, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 180, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 27, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 181, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 28, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 182, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 28, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 183, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 28, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 184, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 185, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 186, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 29, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 187, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 30, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 188, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 30, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 189, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 30, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 190, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 31, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 191, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 8, 31, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 192, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 8, 31, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 193, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 1, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 194, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 195, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 196, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 2, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 197, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 2, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 198, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 2, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 199, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 3, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 200, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 3, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 201, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 3, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 202, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 4, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 203, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 4, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 204, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 4, 18, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Cutoff", "Duration", "GroupId", "Interval", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[,]
                {
                    { 205, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 5, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 206, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 5, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 207, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 5, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 208, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 6, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 209, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 6, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 210, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 6, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 211, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 7, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 212, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 7, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 213, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 7, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 214, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 8, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 215, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 8, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 216, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 8, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 217, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 9, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 218, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 9, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 219, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 9, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 220, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 10, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 221, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 10, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 222, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 10, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 223, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 11, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 224, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 11, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 225, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 11, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 226, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 12, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 227, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 12, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 228, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 12, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 229, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 13, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 230, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 13, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 231, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 13, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 232, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 14, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 233, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 14, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 234, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 14, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 235, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 15, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 236, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 237, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 15, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 238, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 16, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 239, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 16, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 240, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 16, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 241, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 17, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 242, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 17, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 243, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 17, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 244, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 18, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 245, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 18, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 246, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 18, 18, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Cutoff", "Duration", "GroupId", "Interval", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[,]
                {
                    { 247, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 19, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 248, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 19, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 249, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 19, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 250, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 20, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 251, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 252, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 20, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 253, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 21, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 254, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 21, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 255, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 21, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 256, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 22, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 257, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 22, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 258, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 22, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 259, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 23, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 260, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 23, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 261, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 23, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 262, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 24, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 263, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 24, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 264, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 24, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 265, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 25, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 266, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 25, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 267, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 25, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 268, 60, 30, 120, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 9, 26, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 269, 75, 30, 210, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 9, 26, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 270, 100, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 9, 26, 18, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "IsVIP" },
                values: new object[,]
                {
                    { 1, true },
                    { 2, true },
                    { 3, true }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "AreaId", "Description", "Seats" },
                values: new object[,]
                {
                    { 1, 1, "M1", 3 },
                    { 2, 1, "M2", 7 },
                    { 3, 1, "M3", 5 },
                    { 4, 1, "M4", 3 },
                    { 5, 1, "M5", 5 },
                    { 6, 1, "M6", 6 },
                    { 7, 1, "M7", 7 },
                    { 8, 1, "M8", 5 },
                    { 9, 1, "M9", 4 },
                    { 10, 1, "M10", 4 },
                    { 11, 2, "O1", 2 },
                    { 12, 2, "O2", 5 },
                    { 13, 2, "O3", 2 },
                    { 14, 2, "O4", 2 },
                    { 15, 2, "O5", 4 },
                    { 16, 2, "O6", 7 },
                    { 17, 2, "O7", 2 },
                    { 18, 2, "O8", 7 },
                    { 19, 2, "O9", 2 },
                    { 20, 2, "O10", 3 },
                    { 21, 3, "B1", 9 },
                    { 22, 3, "B2", 4 },
                    { 23, 3, "B3", 4 },
                    { 24, 3, "B4", 6 },
                    { 25, 3, "B5", 6 },
                    { 26, 3, "B6", 8 },
                    { 27, 3, "B7", 4 },
                    { 28, 3, "B8", 3 },
                    { 29, 3, "B9", 5 },
                    { 30, 3, "B10", 3 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[] { 10000, 1, null, 2, 4, 1, 1, new DateTime(2022, 6, 12, 9, 30, 0, 0, DateTimeKind.Unspecified) });

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
