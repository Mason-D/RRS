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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1337x1", "1337x1", "God", "GOD" },
                    { "1337x2", "1337x2", "Manager", "MANAGER" },
                    { "1337x3", "1337x3", "Employee", "EMPLOYEE" },
                    { "1337x4", "1337x4", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1337x1", 0, "1337x1", "god@e.com", true, false, null, "GOD@E.COM", "GOD@E.COM", "AQAAAAEAACcQAAAAEJMPzA6i04imClZv43tcdwRSzaCbl4wUGMAXIxCQdgDA6L9OKrijc0vkITcE5+GHGQ==", null, false, "6a43831b-1092-45f2-ab76-46ce9be7e116", false, "god@e.com" },
                    { "1337x2", 0, "1337x2", "man@e.com", true, false, null, "MAN@E.COM", "MAN@E.COM", "AQAAAAEAACcQAAAAECychpK0xbRxtkvZen8jla7GRxCbZcqShmj3mfNIvLfcq+vE+5XTJyI6Din3K1zxGA==", null, false, "814c4c33-ae26-4d52-9a59-9775bfe4d1e1", false, "man@e.com" },
                    { "1337x3", 0, "1337x3", "emp@e.com", true, false, null, "EMP@E.COM", "EMP@E.COM", "AQAAAAEAACcQAAAAEDD1BckJV6utsqkSfdnVfhVAUT2KcOEdXlJ5rbwYPmF4l3fPRqg5l4Gq2Q/7xIpqpw==", null, false, "cc049377-304a-4415-a9f8-d45ac22385d9", false, "emp@e.com" },
                    { "1337x4", 0, "1337x4", "Seed@Person1.com", true, false, null, "SEED@PERSON1.COM", "SEED@PERSON1.COM", "AQAAAAEAACcQAAAAEMQ5u3Upwbq8sXbZAC7YeQsh9BjvJKmkYnR2M9CIYLMsIKzX3nRjGBZoEqFLojSEdw==", null, false, "1f670223-cd24-48cb-8a59-de7306715fe5", false, "Seed@Person1.com" }
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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1337x1", "1337x1" },
                    { "1337x2", "1337x2" },
                    { "1337x3", "1337x3" },
                    { "1337x4", "1337x4" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber", "RestaurantId", "UserId" },
                values: new object[,]
                {
                    { 1, "Seed@Person1.com", "SeedPersonFN1", "SeedPersonLN1", "04100100", 1, null },
                    { 2, "Seed@Person2.com", "SeedPersonFN2", "SeedPersonLN2", "04200200", 1, null },
                    { 3, "Seed@Person3.com", "SeedPersonFN3", "SeedPersonLN3", "04300300", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Cutoff", "Duration", "GroupId", "Interval", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[,]
                {
                    { 1, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 6, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 6, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 6, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 7, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 7, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 7, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 8, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 8, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 8, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 9, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 9, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 9, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 10, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 10, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 10, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 11, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 11, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 11, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 12, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 12, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 12, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 13, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 13, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 13, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 14, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 14, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 14, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 15, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 15, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 16, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 16, 13, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Cutoff", "Duration", "GroupId", "Interval", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[,]
                {
                    { 33, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 16, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 17, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 17, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 17, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 18, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 18, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 18, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 19, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 19, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 19, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 20, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 20, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 20, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 21, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 21, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 21, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 22, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 22, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 22, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 23, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 23, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 23, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 24, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 24, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 24, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 25, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 25, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 25, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 26, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 26, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 26, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 27, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 27, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 27, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 28, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 28, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 28, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 29, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 4, 30, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 4, 30, 13, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Cutoff", "Duration", "GroupId", "Interval", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[,]
                {
                    { 75, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 4, 30, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 1, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 5, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 5, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 2, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 5, 2, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 5, 2, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 82, 40, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 3, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 83, 60, 30, 180, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 2, new DateTime(2022, 5, 3, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 84, 80, 30, 300, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 3, new DateTime(2022, 5, 3, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 85, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 86, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 2, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 87, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 3, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 88, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 4, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 89, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 5, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 90, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 6, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 91, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 7, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 92, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 9, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 94, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 10, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 95, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 11, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 96, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 12, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 97, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 13, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 98, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 14, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 99, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 100, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 16, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 101, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 17, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 102, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 18, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 103, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 19, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 104, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 105, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 21, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 106, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 107, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 23, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 108, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 24, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 109, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 25, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 110, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 26, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 111, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 27, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 112, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 5, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 113, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 114, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 2, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 115, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 3, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 116, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 4, 9, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Cutoff", "Duration", "GroupId", "Interval", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[,]
                {
                    { 117, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 5, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 118, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 6, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 119, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 7, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 120, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 121, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 9, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 122, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 10, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 123, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 11, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 124, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 12, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 125, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 13, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 126, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 14, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 127, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 128, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 16, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 129, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 17, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 130, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 18, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 131, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 19, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 132, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 133, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 21, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 134, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 135, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 23, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 136, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 24, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 137, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 25, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 138, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 26, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 139, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 27, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 140, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 6, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 141, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 142, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 2, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 143, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 3, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 144, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 4, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 145, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 5, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 146, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 6, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 147, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 7, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 148, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 149, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 9, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 150, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 10, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 151, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 11, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 152, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 12, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 153, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 13, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 154, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 14, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 155, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 156, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 16, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 157, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 17, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 158, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 18, 9, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Cutoff", "Duration", "GroupId", "Interval", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[,]
                {
                    { 159, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 19, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 160, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 161, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 21, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 162, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 163, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 23, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 164, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 24, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 165, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 25, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 166, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 26, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 167, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 27, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 168, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 7, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 169, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 170, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 2, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 171, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 3, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 172, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 4, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 173, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 5, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 174, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 6, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 175, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 7, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 176, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 177, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 9, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 178, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 10, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 179, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 11, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 180, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 12, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 181, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 13, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 182, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 14, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 183, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 184, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 16, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 185, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 17, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 186, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 18, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 187, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 19, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 188, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 189, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 21, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 190, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 191, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 23, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 192, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 24, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 193, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 25, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 194, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 26, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 195, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 27, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 196, 20, 30, 240, new Guid("00000000-0000-0000-0000-000000000000"), 15, true, 1, 1, new DateTime(2022, 8, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) }
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
                    { 1, 1, "M1", 0 },
                    { 2, 1, "M2", 0 },
                    { 3, 1, "M3", 0 },
                    { 4, 1, "M4", 0 },
                    { 5, 1, "M5", 0 },
                    { 6, 1, "M6", 0 },
                    { 7, 1, "M7", 0 },
                    { 8, 1, "M8", 0 },
                    { 9, 1, "M9", 0 },
                    { 10, 1, "M10", 0 },
                    { 11, 2, "O1", 0 },
                    { 12, 2, "O2", 0 },
                    { 13, 2, "O3", 0 },
                    { 14, 2, "O4", 0 },
                    { 15, 2, "O5", 0 },
                    { 16, 2, "O6", 0 },
                    { 17, 2, "O7", 0 },
                    { 18, 2, "O8", 0 },
                    { 19, 2, "O9", 0 },
                    { 20, 2, "O10", 0 },
                    { 21, 3, "B1", 0 },
                    { 22, 3, "B2", 0 },
                    { 23, 3, "B3", 0 },
                    { 24, 3, "B4", 0 },
                    { 25, 3, "B5", 0 },
                    { 26, 3, "B6", 0 },
                    { 27, 3, "B7", 0 },
                    { 28, 3, "B8", 0 },
                    { 29, 3, "B9", 0 },
                    { 30, 3, "B10", 0 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "CustomerNotes", "NoOfGuests", "ReservationOriginId", "ReservationStatusId", "SittingId", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, null, 2, 4, 1, 102, new DateTime(2022, 5, 18, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, null, 4, 4, 1, 103, new DateTime(2022, 5, 19, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, null, 6, 4, 1, 104, new DateTime(2022, 5, 20, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, null, 8, 4, 1, 105, new DateTime(2022, 5, 21, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, null, 10, 4, 1, 106, new DateTime(2022, 5, 22, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, null, 12, 4, 1, 107, new DateTime(2022, 5, 23, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 1, null, 14, 4, 1, 108, new DateTime(2022, 5, 24, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 1, null, 16, 4, 1, 109, new DateTime(2022, 5, 25, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, null, 18, 4, 1, 110, new DateTime(2022, 5, 26, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 1, null, 20, 4, 1, 111, new DateTime(2022, 5, 27, 9, 30, 0, 0, DateTimeKind.Unspecified) }
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
