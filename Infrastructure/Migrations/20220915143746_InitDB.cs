using System;
using System.Collections.Generic;
using Domain.Shares.Classes;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitDB : Migration
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("6c86d336-0bc7-4ee7-aba6-b86e6ae520a9")),
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
                    start_point = table.Column<Location>(type: "jsonb", nullable: false),
                    end_point = table.Column<Location>(type: "jsonb", nullable: false),
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
                    payment_methods = table.Column<int>(type: "integer", nullable: true),
                    vehicle_types = table.Column<int>(type: "integer", nullable: true),
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("1e033f49-a9ca-45a1-a2f4-2f8e6b88e470")),
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 800, DateTimeKind.Unspecified).AddTicks(286), new TimeSpan(0, 7, 0, 0, 0))),
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
                    { 1, new Guid("34faf0c0-5120-4d0e-b576-e4db0b4e42e9"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5070), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5085), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("72927dc3-74b7-41c0-8cb9-34fba8a7d4ef"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5097), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5098), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("3f82b159-ecef-4f39-a6e3-86f0223e10d5"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5107), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5107), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("17dd272e-0e34-4939-801d-3b7906fece98"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5115), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5115), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("efc5b4e3-cbb4-473c-bf51-055bb6cd7a9c"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5123), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5123), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("ad7deb3f-da8e-4a3c-83c7-969e41d6fa9a"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5133), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5133), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("02ad1f3c-18f7-4071-b6c7-e1592c3543f0"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5148), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5149), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("707be13c-a9be-4aa7-966f-61babc3f24a0"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5157), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("00383109-1a9e-4b67-a7cc-29174862f89d"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5165), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5165), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("5df829b4-3de5-4b02-ae56-17890c8158ab"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5175), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("80a2e49b-5c78-4435-9247-10a4cdecd6f3"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5182), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5182), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5511), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5511), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5518), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5519), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5526), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5527), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                table: "stations",
                columns: new[] { "id", "address", "code", "created_at", "created_by", "deleted_at", "latitude", "longitude", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("4d33612e-042b-481e-bd56-884a2af08757"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5819), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("95ecc812-b90e-40af-9a64-a4d942cfd922"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5824), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5825), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1bb07eb8-57f6-489a-8bf2-ab19695ff00c"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5827), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5828), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3cc94b8d-9580-43cb-96b7-209154bc888d"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5832), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5833), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2176d7ad-d817-45d7-b3d0-4b29999ed118"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5834), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5835), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("56a46aa5-0c0d-4b0c-8187-108840b7a30a"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5838), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5839), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c52e3879-fa8f-40bf-abf5-13f000d03816"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5841), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5841), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bf6e0f13-2f8b-4797-ab6f-460885a150c2"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5843), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5844), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("1a9e62cf-cbc8-472d-b37d-37efd114c540"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5845), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5846), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("dee3f743-01c0-4317-b50f-6711f727ce0a"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5878), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5878), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("40d5c769-061d-49e6-bd6f-f972892d3abe"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5880), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5881), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("970d62e1-b6d3-4a43-bca7-49ea621af181"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5884), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5885), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6f31d81c-e310-46f4-8e95-5d1b9003b5c7"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5886), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5887), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("80b7ff70-0480-4fa6-8c5b-b50269e83c5d"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5888), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5889), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f94a8646-61c5-4dd7-afc9-d3864a9b4f7e"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5890), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5891), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bcf4a4b6-837f-40d5-95f6-dcf818305193"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5893), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5893), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b5cc0851-50e2-420e-b45d-4a6f8c86c72d"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5896), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ff7f972e-4031-49f8-bb10-bbebd1944b46"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5898), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5899), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f6ac4e31-103a-439d-b40d-792697c52c4d"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5900), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5901), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ce41705e-d75c-4ae2-bcaf-b4d18d607fbc"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5904), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5905), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d300c75f-b6c5-4621-94ce-88b905828425"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5906), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5907), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3d605184-ad94-4b41-9141-fa7d6f0b22fa"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5908), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5909), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8ef1be98-065a-471b-8e57-17d7dcb3163b"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5913), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5913), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("08fe0312-8654-4eb3-b0ef-dfeb3385d69c"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5915), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5915), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b9687c00-3491-431d-b31e-129cafe6d6cb"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5917), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5918), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("691d6e30-4d0a-4244-ba2f-701cbb0447f7"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5919), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5920), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("602cc9a5-d632-4dee-8213-0196c858d387"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5923), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5923), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("602e66d9-4ec5-4ccb-8b05-e9fa01665dd0"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5925), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5926), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4383327e-7a5b-4afb-8313-bd8cb9e3b203"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5928), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5928), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("20dd1fc6-ca3b-4f00-997e-e8cf7390c697"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5931), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5931), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e489d1a7-fbf3-4588-8ff8-132bdf6e6eab"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5933), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ee0a3c3f-bb37-493c-8ae1-afc7b8ee9463"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5935), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5936), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e4f34340-76bc-4e70-96e4-3385dc51eaf4"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5938), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5939), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fac01d1e-3edf-4337-b2a9-7fe8f979fcf6"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5940), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5941), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("926ca4ea-65c5-4f53-ad61-fcb5f730d015"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5944), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5945), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("de687cce-3cee-4546-9b38-6aee8123dddd"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5946), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5947), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("330d77b7-d44d-4e8c-a612-fdece7b5146f"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5949), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5949), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("688ffe1a-22c7-4506-940f-440da52b20da"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5951), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5951), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4a7b1d64-734c-4b39-861c-91feb31ca06b"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5954), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("05fb27fe-5239-4c42-b7df-161c062dbf3e"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5955), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5956), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b37236ad-eecf-4fb4-ba03-90e7e640ca05"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5957), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5958), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e4508cfe-85c6-4cda-bc08-bfa48d9db0a5"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5960), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("bb677fd9-b360-4e2c-a92c-db4b8d5fda64"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5963), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5964), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("6a8b761a-a3b8-4bd9-8a37-c5267f275994"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5965), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5966), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0223787d-f5da-464a-b2fd-61d7280f9780"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5968), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1207794f-ed9a-4baa-9360-726a8f71185f"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5970), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5970), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7e9a8e24-d3e3-46a1-9584-c768b537f38e"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5972), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("206522c2-e835-4355-9740-7c21f30dcd4f"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5974), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d2b413e6-f122-472f-92f3-1bd67806c5b1"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6002), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6003), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5ab025fc-8a9f-49f9-8f79-e0dedd5e2f20"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6005), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6005), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b26d368b-6e02-4d78-a2c9-db37554bf9b3"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6008), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6009), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a9ebf909-3540-4750-b972-1e085015858a"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6011), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6011), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8d5d276d-19e6-4785-88b6-755db128aaed"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6014), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6014), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ef6ea691-54a3-4a3a-8f8b-c83517fb6758"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6016), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6016), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("81aaf55e-57fe-4c89-9595-5adafc81f9a3"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6018), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6019), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a4b9f601-66e6-4a22-b3ce-b79b7769f6c5"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6020), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6021), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f76d7d2f-4d7a-44ba-ac03-99c8adad667f"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6022), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6023), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("38a68390-f589-40cb-8862-fb0a3fc43c0c"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6025), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5ce97e05-6a13-4312-9517-1cc09bcfb099"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6028), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6029), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("135d1b5f-141a-4ea4-8f71-a12950201ee3"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6031), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6031), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("715a6ac9-c51c-4c1a-8fd7-e6538aa3fe83"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6033), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6034), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2010b362-a832-47bc-95be-f66d59f3f538"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6035), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6036), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("12077f70-5706-4b4e-acdf-be7241d5a67c"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6037), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6038), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("947b13e9-4d40-4ebe-b0a8-e64d21772f38"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6040), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6040), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a63c84f4-5a4f-4a6e-ab10-24374cca1ebf"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6043), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6043), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e74eaad5-12ff-4105-a8b7-4bdd01b9d367"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6045), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6046), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7c2cbb99-4029-4c53-8a24-0cfbff6f42c4"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6049), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6049), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("08621b96-60c5-4b6a-8fa0-1efbcb54a886"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6051), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6052), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("62b0e8d7-809c-45de-afe2-4652d1197234"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6053), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6054), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d6681bca-8f95-4656-9552-56d50e69754b"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6056), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6056), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("f51b4457-2f3e-4060-b0ee-7d9e8bab1c51"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6058), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6058), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("03cb594e-ddf8-4533-8535-5dc2bffe8307"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6060), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6060), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3e62f9ac-f216-42e1-9a03-7be1f2425424"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6062), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6062), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3aefbfcd-eb7b-41ab-a465-ce6dd8af7d32"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6064), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6065), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3822a171-ffe5-4544-ba08-fd3620960ff2"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6069), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6069), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a392732f-5233-4e09-8f41-3575ab022b27"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6071), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6071), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3b9d1402-2d70-4012-8c32-1e85c66f6780"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6073), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6074), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d2e36cb6-24ba-48ca-a0ce-9f1667cd52b4"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6075), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6076), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3808120d-2d36-4695-8f7c-bdd0e637aefd"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6077), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6078), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("61502ae4-513f-4c3d-8b15-68c03770fe1c"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6079), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6080), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("de5aedb5-f983-42c9-a733-5b9f442cabcd"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6082), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6082), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("929f512a-5c66-4947-bf56-cf4ef247ae40"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6084), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6084), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("8e8e6b5b-0056-4673-96b4-9d0b61fd5d55"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6087), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6088), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("18873a6b-2dbc-4481-b6a0-0776ae243b3f"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6090), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(6090), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("13f81a01-75f3-4bbb-9d93-084c60539c3b"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5910), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5911), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5660), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5660), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5677), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5692), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5692), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5462), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5463), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5500), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5501), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5535), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5535), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("4396add1-b6df-4698-ac9a-d2199624f585"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5196), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1, 1, "Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5197), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("e5154a8b-844c-4538-b799-cc758b3e9f1a"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5210), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 2, 1, "Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5211), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("8717f6d6-1f8e-4e54-9d15-acec57b501db"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5223), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5224), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("b92160d2-5f23-49a7-b72a-2c3b30f4ac2e"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5232), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 4, 1, "Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5233), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("cde07ad6-04aa-4098-8504-d4233ce67201"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5287), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 5, 1, "Loi Quach", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5288), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("7f08f226-3581-4a4c-95d9-6f1f2d59b844"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 6, 1, "Dat Do", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5303), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("3c162402-acdc-4954-b725-28e5eaf05350"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5315), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 7, 1, "Khoa Nguyen", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5316), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("e9b6676c-a3f8-42f0-938e-4e6f998a6844"), new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5326), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 8, 1, "Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5327), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5342), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5343), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5352), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5353), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5360), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5361), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5367), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5368), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5374), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5374), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5381), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5382), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5388), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5389), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5395), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5395), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5401), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5402), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5409), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5410), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5416), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5417), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5423), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5429), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5430), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5437), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5443), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5443), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 16, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5449), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5450), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5548), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5641), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5641), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5710), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5711), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5730), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5731), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5746), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5747), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5790), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5791), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5803), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 9, 15, 21, 37, 45, 804, DateTimeKind.Unspecified).AddTicks(5803), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

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
                column: "room_id");

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
