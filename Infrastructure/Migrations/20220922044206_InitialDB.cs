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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("4dd533b4-dd98-4dc8-9ba3-d95dfaa6ebfc")),
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
                name: "banners",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    file_id = table.Column<int>(type: "integer", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banners", x => x.id);
                    table.ForeignKey(
                        name: "FK_banners_files_file_id",
                        column: x => x.file_id,
                        principalTable: "files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    distance_from_first_station_in_route = table.Column<double>(type: "double precision", nullable: false),
                    duration_from_first_station_in_route = table.Column<double>(type: "double precision", nullable: false),
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("19f8b4de-42bd-4de4-b84f-fed7bf07129f")),
                    time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    total_price = table.Column<double>(type: "double precision", nullable: false),
                    discount_price = table.Column<double>(type: "double precision", nullable: false),
                    vehicle_type = table.Column<int>(type: "integer", nullable: false),
                    payment_method = table.Column<int>(type: "integer", nullable: false),
                    option = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    is_shared = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    start_station_code = table.Column<Guid>(type: "uuid", nullable: false),
                    end_station_code = table.Column<Guid>(type: "uuid", nullable: false),
                    duration = table.Column<double>(type: "double precision", nullable: false),
                    distance = table.Column<double>(type: "double precision", nullable: false),
                    start_at = table.Column<DateOnly>(type: "date", nullable: false),
                    end_at = table.Column<DateOnly>(type: "date", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    promotion_id = table.Column<int>(type: "integer", nullable: false),
                    route_id = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_bookings_routes_route_id",
                        column: x => x.route_id,
                        principalTable: "routes",
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 965, DateTimeKind.Unspecified).AddTicks(4616), new TimeSpan(0, 7, 0, 0, 0))),
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
                    { 1, new Guid("b992e912-038d-4159-8646-7f748f7ec02e"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(7921), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(7934), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("ab5d7e56-09c9-4c9e-96dd-8284df9abf29"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(7958), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(7959), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("2169ada1-373e-4730-8045-49b8842393f2"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(7969), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(7970), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("e9bec528-10ba-4258-a70a-4bf6e7de3c67"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(7980), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(7980), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("b3f584b5-d817-41bd-95fa-a708d5fdec00"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(7990), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(7990), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("0d52a1e6-6bbc-43f1-8f98-0ef24888ac3a"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8002), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8003), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("b9d8f685-4dfe-4e43-b96b-3e4576d827c8"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8012), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8013), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("25678ebd-f151-476d-8c60-cc2d32eaa75b"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8022), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8023), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("01fef892-3d8d-4a31-a495-da57f3ef3b94"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8032), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8033), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("958b5b78-5023-4e4d-8e83-5c5dc8f2076d"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8046), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8047), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("3685ed4a-4694-4817-9a84-2774e7dcac0f"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8057), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8057), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("1be69938-39a0-4318-a20f-834b2737ad50"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8067), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8067), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8397), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8411), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8420), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8421), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("72a56f39-249e-48c1-8f11-434232218ec2"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8774), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8775), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d8785402-6ebe-40de-8738-00bc6b2a35bf"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8780), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8780), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("51ea1a9e-cae0-4069-9d42-070782aecf7e"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8784), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8785), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("aacf18ed-b952-48c6-86bd-cc29168c76c7"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8787), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8787), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3c2fb3eb-892d-4ed8-a07e-da9dc5f73110"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8790), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8790), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3d035f15-2119-42e1-b5a8-05d21b55ed24"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8798), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8799), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("748d72d8-95e4-4967-b708-6e5f0c5daa7f"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8801), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8801), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a750dfd6-f025-4ee0-b724-6c5d26dc9d35"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8804), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8804), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("c2d2688d-222e-47f9-b38b-863d2532bc3d"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8806), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8807), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("65ef3c77-3512-49ab-b568-5260aa8c051a"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8811), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8811), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("45ea8df1-a0fa-4ee0-af8d-2bcc42e42cac"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8813), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8814), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e811a4c1-5561-4629-94a0-d74df795e927"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8816), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8817), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c5fc145e-7d14-4054-acaa-ff4934fd1337"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8819), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8820), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("95a2195a-57b7-43b2-ac59-514467dc0eb8"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8829), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8829), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3c8262e3-bf37-4f6f-b907-91d7c644baa4"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8832), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8832), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5f8b7d3d-2f43-4809-823d-7334f73d4917"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8834), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8835), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e01c5fdc-f3fd-4d3c-b7b5-ae20c1c077b3"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8837), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8838), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c70132ef-f9e0-433e-b2ca-b5b52032b712"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8841), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8842), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7219d8b0-3933-45b2-93e5-fe22d060c215"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8844), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8844), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bfd32017-403a-4a5c-80e6-67a68096c738"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8847), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3b46de79-ce5c-4655-8fbc-adb6bcfb3387"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8849), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8850), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bb500c5c-8769-4a66-961f-a0e9b02d38a8"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8855), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8855), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("19b97a87-4c2b-4702-b454-f97cfd150e1f"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8860), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8861), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d321afab-d5e9-417e-bcf2-18ee4192d9ad"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8863), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8864), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("889884e2-c92a-44fc-936a-dad681552e43"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8866), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8866), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8579b09e-639b-4a18-bc8e-6ebbb810967d"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8868), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8869), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9982cde1-c754-4c59-b24b-fecaefdcba58"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8872), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8873), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("14938ea5-236a-44a7-9f1a-7970e178e19a"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8875), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8876), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3c0e2698-a111-4709-b434-e9e98cd9dcbd"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8880), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8881), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5735ba58-acb5-4109-95c0-1c5e6c572660"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8883), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8884), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4e08180d-182e-4444-8a11-1c38e58992ad"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8886), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8887), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b06fe1bc-6982-474a-a65d-5fc9f80ae781"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8889), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8889), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e9a4b333-a9a6-4092-8579-9bdc452bf9c3"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8893), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8893), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c2782068-ae81-4f06-b7c0-6637b56d1d0c"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8896), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("eb7ba6f7-60fd-4d14-a28d-749260c7a8f7"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8898), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8899), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ad2a7635-112f-4683-8ea3-78d8e605745e"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8901), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8902), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("60975b02-abcc-4595-b6b4-f6aa0778178d"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8906), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8907), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5a4bbb3f-f228-4ed9-a796-8f3ad54dd9a1"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8909), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8910), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ba03da0b-e690-4573-b9ed-b9208bced450"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8912), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8912), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("adc2bf64-82b5-4ae7-b35b-e17d186b18dc"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8914), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8915), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("229345f8-98a9-4367-9b0c-7f64888c721d"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8917), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8918), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5bbfa6db-40d5-4888-9d05-023d74fb98ef"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8920), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8920), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("ec52cda7-e9cd-4d00-b92c-fdd0abed42c7"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8923), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8923), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("22d60db5-7be7-4bd9-b02f-028ce818d8c3"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8925), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8926), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ca98e050-2a9a-4bb2-969b-a2542066ec9b"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8931), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8931), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0c7d8ac7-aaf3-4a7d-844e-5ef4123e13b9"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8933), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8934), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7d9b08f4-4d59-4dc4-a641-1e55ef8be29d"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8936), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8937), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("31c98e64-b0ba-4d60-b656-c076ea032115"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8939), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8940), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c32b83bf-3da9-49e0-be36-a8c087b90725"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8942), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a91f1dab-0314-4a16-a2e4-3c7d871a5b5d"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8945), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8946), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9b20162f-39f4-45cc-b3f4-550e4bb64d48"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8948), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8949), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cec74d9a-91b3-4c40-858d-5d474aa38940"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8951), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8951), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b00b0257-d29e-4d95-922f-649b25a3f5c6"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8960), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8960), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("21af6feb-beda-4015-9679-8bfbde37c7db"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8963), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4da6acc6-daf0-4849-8c91-e1418e9af3a9"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8965), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8966), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("92f62c3d-69e3-4b45-bc1e-1ee00e5cfcda"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8969), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("70d4ef97-92da-441b-8709-d545866da187"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8971), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8971), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3338f4b7-bb70-47b3-a398-b0c8d8e20129"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8973), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8974), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("80cc30cd-e0a9-4ad2-9351-0f2ddb675c09"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8977), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5be2596c-a768-466f-8c8c-fbf28684106d"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8979), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8979), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2c5374e7-3afc-42cd-9e8a-03627147a89c"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8984), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8985), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f2cbbcc4-126d-4382-8f42-d079238bad07"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8987), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8988), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5a00fc3d-3a0d-4819-bd4d-8f2ce87f8c1e"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8990), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8990), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e8833e97-8eb4-413e-bc7a-16ff7b612a84"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8993), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8993), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("814204a3-709a-414a-822d-52596bfeaf0a"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8997), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8997), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("19457f16-62ea-4a00-80c1-c4dd9019bacc"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8999), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9000), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3c41136b-fb44-475d-9a10-d1b278635a6b"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9002), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9003), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("29ab958a-8085-4ec2-831b-47688be384d3"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9005), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9006), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4c8e8ac4-fc14-4a24-9b9c-38062bd28a84"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9010), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9011), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0e909829-a706-48ef-9ab8-0fb5635b83e4"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9013), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9014), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("1fcab9cd-c3ea-4189-8ca8-a70be5f0e1a7"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9016), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9017), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("736da929-fb6c-4465-8940-cd7fac6502d6"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9019), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9019), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7cd2f7da-86ed-45b7-a818-9633aa40ce16"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9022), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9023), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("914eb9fe-6545-4016-aad4-237f2cf82902"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9025), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ce8811d8-7499-4467-bd7f-bbaf9455e134"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9028), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9028), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ccc60108-fae1-4baf-8904-77f27ccee1ef"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9030), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9031), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1cbe7a6d-4c43-4ab1-b6f9-90096b5267f0"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9036), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9036), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6d3f2890-5777-455d-a5bf-f0e32ee74a36"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9038), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9039), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f709d4f9-703d-4f43-966e-20a298febe64"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9041), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9042), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("3248a5e0-a315-4928-a1e1-02985225974c"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9044), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9045), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("decd8e68-36f4-4686-b627-362e06c3d1e8"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9047), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9047), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("b3a9df23-3a58-448c-a177-e26598fb2800"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9049), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9050), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("5fc64049-b40c-42c1-9326-75241eccedf6"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9052), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9053), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("a7a7e930-cc17-49d9-ab66-0d52e79cb700"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9056), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9056), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f58a9aaf-1aba-4d39-be27-403215a84b3a"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8857), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8858), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Banner 1", new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9163), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9164), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "Banner 2", new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9168), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9168), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "Banner 3", new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9171), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "Banner 4", new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9172), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(9172), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8590), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8591), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8611), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8612), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8632), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8633), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8370), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8371), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8386), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8387), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8431), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8432), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("c8e21006-87d9-44f1-beb3-11c906c98377"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8094), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1, 1, "Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8094), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("53834680-2d84-4323-8ef9-6c5f131bf1e9"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8110), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 2, 1, "Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8110), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("84d379b8-5787-4764-905b-a019586eed8a"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8124), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8125), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("9cd0f2c4-dc11-4fde-8517-19f5aeae3474"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8139), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 4, 1, "Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8140), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("0eb7db4f-9413-441a-bb34-53a0842b552b"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8153), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 5, 1, "Loi Quach", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8154), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("6d0010df-b688-45ba-8512-d84c189991ef"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8166), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 6, 1, "Dat Do", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8167), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("d1d10323-0035-43bf-82fa-f9bc2b35717b"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8184), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 7, 1, "Khoa Nguyen", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8184), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("4ea10066-2476-48ce-891a-f92221bdea41"), new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8199), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 8, 1, "Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8199), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8215), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8215), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8227), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8228), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8237), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8238), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8247), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8248), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8257), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8267), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8276), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8276), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8284), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8285), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8293), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8294), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8304), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8312), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8312), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8321), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8330), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8330), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8338), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8339), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8347), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8348), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 16, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8356), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8357), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8445), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8446), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8565), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8566), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8678), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8679), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8705), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8724), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8725), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8740), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8741), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8757), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 9, 22, 11, 42, 5, 969, DateTimeKind.Unspecified).AddTicks(8757), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

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
                name: "IX_banners_file_id",
                table: "banners",
                column: "file_id",
                unique: true);

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
                name: "IX_bookings_route_id",
                table: "bookings",
                column: "route_id");

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
                name: "IX_route_stations_route_id",
                table: "route_stations",
                column: "route_id");

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
                name: "banners");

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
                name: "stations");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "routes");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "promotions");

            migrationBuilder.DropTable(
                name: "files");
        }
    }
}
