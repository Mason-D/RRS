﻿using System;
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
                    GroupId = table.Column<int>(type: "int", nullable: true),
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
                    AreaId = table.Column<int>(type: "int", nullable: false)
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
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Cutoff", "Duration", "GroupId", "Interval", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[,]
                {
                    { 1, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 6, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 6, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 6, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 7, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 7, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 7, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 8, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 8, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 8, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 9, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 9, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 9, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 10, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 10, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 10, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 11, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 11, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 11, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 12, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 12, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 12, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 13, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 13, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 13, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 14, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 14, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 14, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 15, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 15, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 16, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 16, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 16, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 17, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 17, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 17, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 18, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 18, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 18, 18, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Cutoff", "Duration", "GroupId", "Interval", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[,]
                {
                    { 40, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 19, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 19, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 19, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 20, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 20, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 20, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 21, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 21, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 21, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 22, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 22, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 22, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 23, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 23, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 23, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 24, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 24, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 24, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 25, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 25, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 25, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 26, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 26, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 26, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 27, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 27, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 27, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 28, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 28, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 28, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 29, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 29, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 4, 30, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 4, 30, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 4, 30, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 5, 1, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 5, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 5, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 5, 2, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 5, 2, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 5, 2, 18, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Cutoff", "Duration", "GroupId", "Interval", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[] { 82, 40, 30, 240, null, 15, true, 1, 1, new DateTime(2022, 5, 3, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Cutoff", "Duration", "GroupId", "Interval", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[] { 83, 60, 30, 180, null, 15, true, 1, 2, new DateTime(2022, 5, 3, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Capacity", "Cutoff", "Duration", "GroupId", "Interval", "IsOpen", "RestaurantId", "SittingTypeId", "Start" },
                values: new object[] { 84, 80, 30, 300, null, 15, true, 1, 3, new DateTime(2022, 5, 3, 18, 0, 0, 0, DateTimeKind.Unspecified) });

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
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
