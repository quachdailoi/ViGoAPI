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
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("0cbdceba-0d64-417b-89f2-defd620f51ee")),
                    status = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    type = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                    steps = table.Column<List<Step>>(type: "jsonb[]", nullable: false),
                    distance = table.Column<double>(type: "double precision", nullable: false),
                    duration = table.Column<double>(type: "double precision", nullable: false),
                    bound = table.Column<Bound>(type: "jsonb", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                    code = table.Column<Guid>(type: "uuid", nullable: false),
                    longitude = table.Column<double>(type: "double precision", nullable: false),
                    latitude = table.Column<double>(type: "double precision", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    address = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                    expired_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    registration = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    registration_type = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_verified_codes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "promotions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    details = table.Column<string>(type: "text", nullable: false),
                    file_id = table.Column<int>(type: "integer", nullable: true),
                    discount_percentage = table.Column<double>(type: "double precision", nullable: false),
                    max_decrease = table.Column<double>(type: "double precision", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_promotions", x => x.id);
                    table.ForeignKey(
                        name: "FK_promotions_files_file_id",
                        column: x => x.file_id,
                        principalTable: "files",
                        principalColumn: "id");
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
                    date_of_birth = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    file_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                name: "promotion_conditions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    promotion_id = table.Column<int>(type: "integer", nullable: false),
                    total_usage = table.Column<int>(type: "integer", nullable: true),
                    usage_per_user = table.Column<int>(type: "integer", nullable: true),
                    valid_from = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    valid_until = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    min_total_price = table.Column<float>(type: "real", nullable: true),
                    min_tickets = table.Column<int>(type: "integer", nullable: true),
                    payment_method = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_promotion_conditions", x => x.id);
                    table.ForeignKey(
                        name: "FK_promotion_conditions_promotions_promotion_id",
                        column: x => x.promotion_id,
                        principalTable: "promotions",
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
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("098620ce-b641-4ea7-8e46-63b8beeb5087")),
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
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.id);
                    table.ForeignKey(
                        name: "FK_bookings_promotions_promotion_id",
                        column: x => x.promotion_id,
                        principalTable: "promotions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 708, DateTimeKind.Unspecified).AddTicks(9679), new TimeSpan(0, 7, 0, 0, 0))),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                name: "promotion_users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    promotion_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    used = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    expired_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PromotionConditionId = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_promotion_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_promotion_users_promotion_conditions_PromotionConditionId",
                        column: x => x.PromotionConditionId,
                        principalTable: "promotion_conditions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_promotion_users_promotions_promotion_id",
                        column: x => x.promotion_id,
                        principalTable: "promotions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_promotion_users_users_user_id",
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
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                    { 1, new Guid("7adbff17-7304-4d84-b315-9f3c0e1996c5"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2030), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2043), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("286e738a-2c22-4859-a507-adb45715d5b7"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2065), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2066), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("fc27b95b-65e5-4e67-964e-30d4ab8e1f14"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2085), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2086), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("142896e4-ae4a-476c-b8dd-0769858dad23"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2095), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2096), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("6ae20333-4c47-4154-b2c5-9804276286e5"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2105), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2106), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("04712013-8fd4-4ddc-bcb6-c8e3ae1dcb8c"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2117), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2118), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("82cefc1a-f419-4ded-903d-53518be5a529"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2128), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2128), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("2ee7bc18-6ec5-4f55-abe2-b93486e9babc"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2137), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2138), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("7db4a6a4-bc7c-4697-8caa-90919598ae70"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2147), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2147), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("6230cad2-88bb-4653-908e-d7a2ec914114"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2158), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("a310f439-a029-42c4-bc48-4408b83930e2"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2171), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[] { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2503), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2504), new TimeSpan(0, 7, 0, 0, 0)), 0 });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Role for booker", "BOOKER" },
                    { 2, "Role for driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "stations",
                columns: new[] { "id", "address", "code", "created_at", "created_by", "deleted_at", "latitude", "longitude", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("f7dd0a29-39bb-4c5c-a176-8702d7f66565"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2931), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2932), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b2e06bb5-0d07-4910-8a95-47ff651ef226"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2938), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2938), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("235ecc29-b4ff-4913-8d8a-bc0c9179b2e4"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2941), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2942), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fbcab5fa-e98f-4689-a257-cbb1e4ca799e"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2944), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2945), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("687be5fe-829c-457a-b076-ee35cac76359"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2947), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2948), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d0b2dc55-e735-4590-a92b-d4216ba764b4"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2953), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4cba91fa-10d4-4915-9683-338c3cfcba74"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2955), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2956), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("12eec862-1ffc-4a15-84d2-74c49ecd2fbc"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2963), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2964), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("9a72a30c-25d4-4fb9-b73a-bf965c2dd69d"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2973), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("9c071729-0b0b-481a-bd73-c6cd90671ebc"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2977), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("74454447-d208-4a37-9463-569ff1662cdc"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2979), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2979), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b7b23b4f-3161-49b4-a5f1-28366039ecf0"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2981), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2982), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5e774fe2-1849-49b3-9bf8-5006cc1f233d"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2984), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2985), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("dc6a8425-2776-42ba-af00-eee57aa2a4e9"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2987), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2987), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("79719d51-0ca6-4431-9ca9-fce27f8d5126"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2990), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2990), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("257ea2dc-1271-467e-a0a6-d0cd760b5c9c"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2995), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2996), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4b0f369b-4ae8-41d0-8253-f0cdf38c33df"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2998), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e462127c-e3cd-4740-9e0e-8816abd570d2"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3002), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3002), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("40ed131e-c6b5-4cb2-b82b-f220ed9678db"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3004), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3005), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("29a00d6c-8134-4bfb-9015-4e3dc56f7182"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3007), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3008), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("46ea2bd6-44a3-4128-9b43-d65a431ade5a"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3010), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3010), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("44234103-8ff6-4dbc-afcd-a772a4016ac9"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3013), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3013), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("402e84b7-3401-4011-b6b8-e1a93f8343b0"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3021), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3021), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9ae1c125-8797-48a9-8422-b4d6d8ec9ef3"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3023), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3024), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("54edea29-48af-4d32-8487-36ad146da653"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3026), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3027), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("29f4fb77-4fae-44df-8262-d5a2069ec03e"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3030), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3031), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fdcf3091-23ac-4230-bcd2-aff50342d442"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3033), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3034), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c8956e73-0b0a-42d6-96e8-a8509c6787e2"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3036), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3036), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("87503547-e048-4e9c-b773-d5a0966a2d4d"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3038), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3039), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("20b3d77c-08e2-47e7-8341-90d4ddb7c517"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3041), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3042), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("467879af-ca23-456f-a318-7ff64736da41"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3047), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3048), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e371a6d5-c521-4bf1-b126-6fccfd28937f"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3050), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3051), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dc551595-4234-4693-ae3d-26c74f7c5c26"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3054), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3055), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3ff9f5e1-3cbc-4968-b3bf-48aee006b282"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3057), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3057), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("04abf4a0-10e7-4441-912c-301060e68c62"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3060), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3060), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9d7b937f-ed96-47a8-9cfc-568855f1c089"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3062), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3063), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("55b6a81f-06f7-4c2b-b49c-5f80d11123f3"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3065), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3066), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("143d6192-25f5-46a0-b874-648662890e63"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3068), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3068), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7201bf7b-0f6e-4c2c-8ab3-ae868c7b111d"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3073), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3074), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("45262e20-92d1-43b6-9fac-0ba6cae7dcef"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3076), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3076), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e918bb51-42ae-4446-96b9-a19811766249"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3078), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3079), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3d49fedc-16fb-4ea9-b894-9ddd17a87669"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3081), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3082), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("bf415801-747e-4b77-8ee1-3615114e567c"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3084), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3084), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("353b0f9f-3955-4ade-a5e1-20dc1ee64e13"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3086), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3087), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2348b6db-74fc-4f74-a3d2-d2c710dbc511"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3089), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3090), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1d8c4bf3-e206-432c-bed8-284eacea8f0c"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3092), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3092), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e9710c7d-8ed8-44d8-8cc0-e7b8d37eed3e"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3102), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3103), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bbece48f-f394-4ff4-8cc2-43193297a03b"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3105), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3106), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5e9144a4-78ce-41e2-9ba5-662f9dea0207"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3108), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3108), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("59c5cb01-77eb-4aab-95fb-b838596f91c9"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3111), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3111), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("513d5894-ac99-41a7-9eb8-dd9a1924b435"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3113), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3114), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8e2256a8-6d5a-411f-9989-7a250f19bff0"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3116), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3117), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("443d3481-ee0b-405f-bf28-a718baf138af"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3119), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3119), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("72d5f63c-f587-4824-afdb-be1262c9d093"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3121), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3122), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("557432dd-c93d-4f14-a60d-54a7559787c5"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3127), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3128), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("848684ca-042c-4aca-8aa0-9827ff0f352b"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3130), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3131), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("70ef0bab-392c-4456-a611-8ec40bb7a1fd"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3133), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3134), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8754e5a4-0fe7-4ab6-9c6f-425b0e0153e3"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3136), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3136), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("571cc3fa-9287-4936-9974-1901560df8bb"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3138), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3139), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4938ea9f-e171-42e6-8a2b-2f706c8cb734"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3142), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3b3e9238-fadc-4f57-b6d1-c30b38f2eef8"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3145), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7fb9323e-8d60-4b45-b416-399ae81269b6"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3147), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3148), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ffba4501-3d8b-454a-b3bd-51adcf8e063d"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3152), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3153), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("15e1d4a9-0dae-4d5b-8d39-fa6d5f973ed1"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3155), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3156), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3f2cd5c6-edef-4ba3-a173-02200bea8150"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3160), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3161), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4879fbe4-35cb-4f15-b5e2-5ca1abc474c9"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3163), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3163), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c5677689-e8f7-42c0-8090-58cd842fb046"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3166), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3167), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("84c3a5e0-b867-47ff-becf-661c33b19623"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3169), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3170), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("68ebcbdd-5a1c-4702-979d-3b15bd9bc2fc"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3172), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3172), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("10d1f6d9-0e15-493a-9b9a-e196d143d25d"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3175), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3175), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("c02fcabb-ee66-4630-933d-99d0d9f8c8e7"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3180), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3180), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ad50681b-52e4-46a4-b02e-629bc288d09b"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3183), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3183), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6fdb5663-c7a9-4241-bb9e-7939c7e199b9"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3185), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3186), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("74f0fe80-e4ab-4e1f-b396-97ebe1db72b5"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3188), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3189), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a6df9da8-57ef-4b6f-b310-2a417c724201"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3191), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3191), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("737e34b6-4168-4132-b22c-4281303a2154"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3194), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3194), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("09f91742-e4e9-48da-aebe-bdd33b2d5629"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3196), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3197), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a19364e4-99d9-4d40-84f2-5a234d3ddf58"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3199), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3200), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("56d282ff-6168-4a24-8e18-ed096d5c26b5"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3204), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3205), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("6b8f2b25-eece-4489-92e8-56a7b99569ef"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3207), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3208), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("a0666cad-eae2-42b6-871b-5dbda90d5df8"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3210), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3211), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("a50a103f-753c-4d81-9eb4-1a1cbab099db"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3213), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3213), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("ffaf97ef-11d3-438f-a4c4-a7a44d84b084"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3216), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3216), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("6f45858a-3de1-4310-91fd-e34e7b98a857"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3219), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6f557dad-52f9-4b15-a812-dd292be9f042"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3015), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(3016), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_method", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2808), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2809), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2481), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2493), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2494), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2512), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, 11, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2513), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("0c269df3-cbde-4ab6-ae2f-711f94e00b45"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2195), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1, 1, "Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2196), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("3e08707d-4c3d-41bc-8356-0a244370c6d0"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 2, 1, "Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2219), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("62e9192a-e05e-4abd-b356-5b78e3df4971"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2231), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2231), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("83e7922d-5a5c-4ae1-9d4d-034551a23539"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2242), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 4, 1, "Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2243), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("2f3c279a-7cd8-48d1-99e7-fd7e8b07920a"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 5, 1, "Loi Quach", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2258), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("ecdd14bf-5a7f-4cc2-9b69-c4267c84e5ba"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2271), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 6, 1, "Dat Do", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2271), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("7610db1c-8d67-4c9f-ae06-21765e1b5f0b"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2282), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 7, 1, "Khoa Nguyen", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2283), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("8b062aee-c29a-4cec-8c6d-a96ee57b0b47"), new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2296), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 8, 1, "Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2296), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2315), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2316), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2327), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2328), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2336), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2337), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2348), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2349), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2358), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2359), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2369), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2377), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2378), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2387), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2388), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2397), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2407), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2408), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2416), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2417), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2430), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2431), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2440), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2440), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2448), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2449), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2457), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2457), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 16, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2465), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2466), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_method", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2525), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2526), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 2, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2779), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2780), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 4, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2829), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2830), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2856), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2857), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2880), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2896), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2897), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2912), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 9, 15, 17, 33, 10, 714, DateTimeKind.Unspecified).AddTicks(2913), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_registration_role_id",
                table: "accounts",
                columns: new[] { "registration", "role_id" },
                unique: true,
                filter: "verified = true and deleted_at = null");

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
                name: "IX_bookings_promotion_id",
                table: "bookings",
                column: "promotion_id");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_user_id",
                table: "bookings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_messages_room_id",
                table: "messages",
                column: "room_id")
                .Annotation("Npgsql:IndexMethod", "hash");

            migrationBuilder.CreateIndex(
                name: "IX_messages_user_id",
                table: "messages",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_promotion_conditions_promotion_id",
                table: "promotion_conditions",
                column: "promotion_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_promotion_users_promotion_id_user_id",
                table: "promotion_users",
                columns: new[] { "promotion_id", "user_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_promotion_users_PromotionConditionId",
                table: "promotion_users",
                column: "PromotionConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_promotion_users_user_id",
                table: "promotion_users",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_promotions_file_id",
                table: "promotions",
                column: "file_id",
                unique: true);

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
                name: "IX_stations_code",
                table: "stations",
                column: "code",
                unique: true);

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
                name: "promotion_users");

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
                name: "promotion_conditions");

            migrationBuilder.DropTable(
                name: "routes");

            migrationBuilder.DropTable(
                name: "stations");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "promotions");

            migrationBuilder.DropTable(
                name: "files");
        }
    }
}
