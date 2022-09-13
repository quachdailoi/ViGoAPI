using System;
using System.Collections.Generic;
using Domain.Shares.Classes;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "files",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<Guid>(type: "uuid", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_files", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("c873ccab-ee9a-412b-9e84-b689c20bad0e")),
                    status = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    type = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "routes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    start_point = table.Column<Location>(type: "jsonb", nullable: false),
                    end_point = table.Column<Location>(type: "jsonb", nullable: false),
                    steps = table.Column<List<Step>>(type: "jsonb[]", nullable: false),
                    distance = table.Column<double>(type: "double precision", nullable: false),
                    duration = table.Column<double>(type: "double precision", nullable: false),
                    bound = table.Column<Bound>(type: "jsonb", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_routes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "stations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    longitude = table.Column<double>(type: "double precision", nullable: false),
                    latitude = table.Column<double>(type: "double precision", nullable: false),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "verified_codes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    expired_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    registration = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    registration_type = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_verified_codes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    file_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_files_file_id",
                        column: x => x.file_id,
                        principalTable: "files",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "route_stations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    route_id = table.Column<int>(type: "integer", nullable: false),
                    station_id = table.Column<int>(type: "integer", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_route_stations", x => x.id);
                    table.ForeignKey(
                        name: "FK_route_stations_routes_route_id",
                        column: x => x.route_id,
                        principalTable: "routes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_route_stations_stations_station_id",
                        column: x => x.station_id,
                        principalTable: "stations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    registration = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    registration_type = table.Column<int>(type: "integer", nullable: false),
                    verified = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    role_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_accounts_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_accounts_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("a1d833f4-6d8d-43e4-816c-9495c2512158")),
                    time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    total_price = table.Column<double>(type: "double precision", nullable: false),
                    discount_price = table.Column<double>(type: "double precision", nullable: false),
                    option = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    days = table.Column<DaySchedule>(type: "jsonb", nullable: false),
                    is_shared = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    start_point = table.Column<Location>(type: "jsonb", nullable: false),
                    end_point = table.Column<Location>(type: "jsonb", nullable: false),
                    steps = table.Column<List<Step>>(type: "jsonb[]", nullable: false),
                    duration = table.Column<double>(type: "double precision", nullable: false),
                    distance = table.Column<double>(type: "double precision", nullable: false),
                    start_at = table.Column<DateOnly>(type: "date", nullable: false),
                    end_at = table.Column<DateOnly>(type: "date", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    promotion_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.id);
                    table.ForeignKey(
                        name: "FK_bookings_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    content = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    room_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.id);
                    table.ForeignKey(
                        name: "FK_messages_rooms_room_id",
                        column: x => x.room_id,
                        principalTable: "rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_messages_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_rooms",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    room_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    last_seen_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2022, 9, 11, 16, 0, 8, 412, DateTimeKind.Utc).AddTicks(7720)),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_rooms", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_rooms_rooms_room_id",
                        column: x => x.room_id,
                        principalTable: "rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_rooms_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "booking_details",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rating = table.Column<double>(type: "double precision", nullable: false),
                    feedback = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    discount_price = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0),
                    status = table.Column<int>(type: "integer", nullable: false),
                    booking_id = table.Column<int>(type: "integer", nullable: false),
                    driver_id = table.Column<int>(type: "integer", nullable: true),
                    message_room_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking_details", x => x.id);
                    table.ForeignKey(
                        name: "FK_booking_details_bookings_booking_id",
                        column: x => x.booking_id,
                        principalTable: "bookings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_booking_details_rooms_message_room_id",
                        column: x => x.message_room_id,
                        principalTable: "rooms",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_booking_details_users_driver_id",
                        column: x => x.driver_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "path", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("8f1b6323-4826-420d-95c8-5936d7042683"), new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(171), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(173), 0 },
                    { 2, new Guid("fa08dc2f-9901-49cd-a388-06b38ffb3ae7"), new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(206), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(206), 0 },
                    { 3, new Guid("743d2cae-5acd-45fc-a181-cae6384b97ea"), new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(243), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(244), 0 },
                    { 4, new Guid("62172369-d239-4a2e-8a3b-1c150ea14760"), new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(263), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(263), 0 },
                    { 5, new Guid("67bb6353-038f-44d3-9685-b73c8228deb0"), new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(281), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(282), 0 },
                    { 6, new Guid("843b0825-bb82-4893-b4f0-afc726bf8524"), new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(306), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(306), 0 },
                    { 7, new Guid("3406289d-cf08-4c16-a1e8-99e6c39f74f2"), new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(325), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(325), 0 },
                    { 8, new Guid("199f1dd0-83b5-49aa-a9fc-f534bc32f823"), new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(345), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(346), 0 }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Role for booker", "BOOKER" },
                    { 2, "Role for driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("0d25d396-1bf1-4fb0-a38e-db7d422a6258"), new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(193), 0, null, null, 1, 1, "Quach Dai Loi", 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(193), 0 },
                    { 2, new Guid("cf1c6850-ef84-4379-a7d8-6e61e42a3997"), new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(215), 0, null, null, 2, 1, "Do Trong Dat", 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(215), 0 },
                    { 3, new Guid("a358c096-a4ae-4b08-8cc1-50a3689a0386"), new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(253), 0, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(253), 0 },
                    { 4, new Guid("be792aff-3d52-4802-a298-cd45349bc2b3"), new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(272), 0, null, null, 4, 1, "Than Thanh Duy", 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(272), 0 },
                    { 5, new Guid("65524ddd-3da3-416d-8e6c-c7904dcf6c07"), new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(295), 0, null, null, 5, 1, "Loi Quach", 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(296), 0 },
                    { 6, new Guid("39abe422-52e2-4acd-a3f9-57c5a8216d23"), new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(315), 0, null, null, 6, 1, "Dat Do", 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(315), 0 },
                    { 7, new Guid("b5badab1-836b-447e-9907-3967f2036a0e"), new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(333), 0, null, null, 7, 1, "Khoa Nguyen", 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(334), 0 },
                    { 8, new Guid("a119a186-1ca8-4be8-99ca-0436e8d6b2c0"), new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(355), 0, null, null, 8, 1, "Thanh Duy", 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(355), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(367), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(367), 0, 2, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(376), 0, null, "+84837226239", 1, 2, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(376), 0, 2 },
                    { 3, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(384), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(384), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(392), 0, null, "+84837226239", 1, 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(393), 0, 5, true },
                    { 5, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(400), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(401), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(408), 0, null, "+84377322919", 1, 2, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(409), 0, 2 },
                    { 7, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(416), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(416), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(423), 0, null, "+84377322919", 1, 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(423), 0, 6, true },
                    { 9, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(430), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(431), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(444), 0, null, "+84914669962", 1, 2, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(444), 0, 3 },
                    { 11, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(451), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(452), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(459), 0, null, "+84914669962", 1, 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(459), 0, 7, true },
                    { 13, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(466), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(467), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(474), 0, null, "+84376826328", 1, 2, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(474), 0, 4 },
                    { 15, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(481), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(481), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 16, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(488), 0, null, "+84376826328", 1, 1, new DateTime(2022, 9, 11, 16, 0, 8, 417, DateTimeKind.Utc).AddTicks(489), 0, 8, true });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_registration_role_id",
                table: "accounts",
                columns: new[] { "registration", "role_id" },
                unique: true,
                filter: "verified = true");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_role_id",
                table: "accounts",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_user_id",
                table: "accounts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_booking_details_booking_id",
                table: "booking_details",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "IX_booking_details_driver_id",
                table: "booking_details",
                column: "driver_id");

            migrationBuilder.CreateIndex(
                name: "IX_booking_details_message_room_id",
                table: "booking_details",
                column: "message_room_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_bookings_code",
                table: "bookings",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_bookings_user_id",
                table: "bookings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_messages_room_id",
                table: "messages",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_messages_user_id",
                table: "messages",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_roles_name",
                table: "roles",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rooms_code",
                table: "rooms",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_route_stations_route_id_station_id",
                table: "route_stations",
                columns: new[] { "route_id", "station_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_route_stations_station_id",
                table: "route_stations",
                column: "station_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_rooms_room_id",
                table: "user_rooms",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_rooms_user_id",
                table: "user_rooms",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_code",
                table: "users",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_file_id",
                table: "users",
                column: "file_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "booking_details");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "route_stations");

            migrationBuilder.DropTable(
                name: "user_rooms");

            migrationBuilder.DropTable(
                name: "verified_codes");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "routes");

            migrationBuilder.DropTable(
                name: "stations");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "files");
        }
    }
}
