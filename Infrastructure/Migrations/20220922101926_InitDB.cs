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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("4c0af43c-9329-426e-bfb4-8dcff484378e")),
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("22beb803-da45-4241-a4fe-ae38f8a5e59f")),
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 543, DateTimeKind.Unspecified).AddTicks(1373), new TimeSpan(0, 7, 0, 0, 0))),
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
                    { 1, new Guid("6e9fd9db-9da8-43bb-94a1-36fbb75ab2c3"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2214), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2226), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("bfb85c74-62d9-4400-80a5-59aaaa546bb7"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2240), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2240), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("02b0d527-ca9e-42f3-a44e-82599bd1e81f"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2249), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2249), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("6b3c492a-82ac-4c84-919e-7aa725f8178e"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2257), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("708f7987-b65e-4bfa-b0f8-32e0200a8f67"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2265), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2265), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("ecf60e04-00eb-462b-ac40-d81806df5e66"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2275), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2276), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("29f7a983-d6bb-4b45-989a-fd93e5880bcc"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2283), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2284), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("a670cd13-fa58-4d3f-913a-fdc1907c25d2"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2291), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2292), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("bca2803c-4009-490a-b0cc-b1cab0eda434"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2302), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("b845b129-8333-40f1-a51d-8f894e8a09b9"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2311), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2311), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("1772881d-1184-4b32-ad78-15936edd858f"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2319), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2319), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("e5fdb635-4aa9-431b-8d2c-89260f9241f5"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2327), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2327), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("6c152841-6c44-40a6-900a-49b01f821ecf"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2364), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2365), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2840), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2841), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2848), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2849), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2856), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2856), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Role for booker", "BOOKER" },
                    { 2, "Role for driver", "DRIVER" },
                    { 3, "Role for admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "stations",
                columns: new[] { "id", "address", "code", "created_at", "created_by", "deleted_at", "latitude", "longitude", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("dd103431-fe13-4743-88ff-3289a15c31a9"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3120), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3121), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("83baf361-5eec-46a6-88d8-1ed4d4a2aacb"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3125), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3126), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4cc79732-cb4f-4086-8574-fd0387eca935"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3128), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3129), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a77b07b6-344f-43b8-bf1d-7138b079e627"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3133), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3134), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1b460755-c23e-45c8-8c00-a2a6c06a9d59"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3136), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3136), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0bafa1b6-39a4-49f4-8e86-2143703e8091"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3139), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3140), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c5941908-e219-4430-8380-bf761e84a72c"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3142), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bdd4bfd7-317c-4961-91d9-d8a17fd5efba"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3144), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("a61c4457-34bf-45b4-bd3f-97773bee6c95"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3170), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("a0e4ed4c-c2e6-4aab-9820-c35231261b88"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3174), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f95be267-73c4-40d8-bfa0-623d99d0b712"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3175), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3176), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7e2eb244-d0fc-45cb-8147-705aec1eb582"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3179), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3180), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1ecff454-40f5-4677-b407-20134c232759"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3181), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3182), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("17cfa414-60bb-43aa-a661-9ef4021f4df8"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3183), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3184), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("943d443a-fc87-43fc-8449-83ff1892a044"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3186), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3186), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("585d64ff-986b-48bc-bddd-3a159483a656"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3189), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3189), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("92e6fa7b-7631-4fa8-ad30-c85dcd6d69d6"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3191), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3191), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("03568355-90b7-4a20-a61c-ca4218706827"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3194), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3194), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2e803d04-a29a-4edb-a013-0cf6150c7283"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3196), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3196), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("20ad6ee0-8f10-4106-9a30-d40fca7f5cc1"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3200), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3200), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("10718f25-5b64-45cf-a92c-edc55a1daca1"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3202), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3202), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f2b10b5a-2301-4133-8f80-7fad84575cec"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3204), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3204), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("14e9b788-65ea-492e-8ae1-4fde1fdff5a6"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3208), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3209), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7ecb1745-7c69-4d85-804c-0db667d1e13f"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3211), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3211), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("df6be1aa-bbe2-4d5a-a649-6d4dc7eff5ee"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3213), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3213), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("981138bf-c952-4094-8a28-d88e8acc55bb"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3215), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3215), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7269804b-a4f9-450f-b0e7-bc77ccbbaa17"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3219), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3219), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7b2645e2-b774-4843-93c7-2283d6430749"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3221), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3222), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("170d7a75-b4fd-4b98-b2d6-3c76cd33a11d"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3224), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3224), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("931cec3b-f9cb-4c45-a386-ab2995feec13"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3226), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("98c0f1cf-fb3c-4f42-8191-59870ece1326"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3228), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d10a734a-66c5-493b-9309-bbc8fbd87374"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3230), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3230), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("90f7f4c6-7de7-41e8-956e-cf038d53a38f"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3233), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3233), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("29c53a8d-6d46-4cd4-afa2-b04df925c95d"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3235), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3236), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("399777e6-f930-4517-a227-9529f501e15b"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3239), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3239), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3a07a30f-450d-4c72-af06-efbc3708da4b"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3241), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3241), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("68d340b3-ee17-4256-9745-86c053342f00"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3243), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3244), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8a2595f9-d64c-4c6b-b40e-18d7f608321f"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3245), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3246), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("04ed5046-e4d1-42ab-92dd-93e96d4fe6fe"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3253), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3253), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("67d4867a-b245-4a38-9d9e-522512c8f338"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3255), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3255), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4360e2a9-ff80-4068-993d-61b7aca4c622"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3258), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5e680217-6eeb-49d9-9fa9-ab6584c7a098"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3259), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3260), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("4b95a7de-73a5-40ca-856f-220736e13de5"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3263), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3263), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("3f1bd826-0a98-4eb7-963d-9360c9426bb9"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3265), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3265), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("152093b8-bb2b-4fc3-aa98-6172e2b7d917"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3268), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("67f8cb30-7af7-4391-8afa-bf8d876b7887"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3269), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3270), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ad4dee2f-6bc7-4a99-b26d-0d5b8556bb8c"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3294), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3294), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d4de62f0-6013-4fd7-98e1-c2f2c69f339e"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3296), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3297), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b7b15a7e-00f0-4e3b-83f1-10e922991230"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3298), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3299), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f5caddd4-8191-4391-baa4-cf78a5cabb6a"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3301), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3301), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("55797df8-1893-4fc2-8d1a-b22c603b4dc1"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3304), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3305), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2c58cd73-8d02-4e40-8954-7feece9cb202"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3306), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3307), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cdbdda53-c185-4dd2-9c09-dbaceb7269d8"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3308), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3309), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8f84ecc6-cc43-4762-9f7a-089766fa1a6e"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3311), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3311), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("52519bd9-67ac-4493-86f1-f3a2bac1eccc"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3313), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3313), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4474c779-2215-4e8f-baf9-eb507dcef262"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3315), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3316), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f3619a7d-d717-4bb5-9938-9db03dd2d11a"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3318), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2055b6e6-e02f-41a4-b897-781df35674f6"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3319), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3320), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cbce9d6c-b0e0-42fa-afcc-c5c062dcc740"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3323), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3324), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e8288a4f-6178-464f-889f-6d18bf249940"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3325), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3326), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2e117d31-a602-4b28-a059-766382c32fce"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3330), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3330), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("15f73052-f305-4009-8e50-61f5bd28a56f"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3332), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3332), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a36ec643-a16a-4518-9e4c-901a9f95fdc8"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3334), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3334), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9273cfef-91c1-4347-885d-f4303cf96f7f"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3336), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3337), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cf48802b-8c30-448b-8fb4-892ce019becd"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3339), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3339), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5d0c54fa-69c5-429f-81d8-9e7b078f4d3d"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3341), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3342), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5512f5a1-745b-4b7b-a8c3-ef0131943272"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3346), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0ab80609-5915-49bf-8d8c-8e15694049b1"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3348), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3348), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("795e615b-51f5-4e11-b946-788a3343b0d8"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3350), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3350), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5deeb559-e18a-4007-b5b5-2b422872625b"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3352), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3353), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("214a831d-3f60-4de2-8603-8429aa40ecc9"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3355), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("28dcd46f-9b88-437b-95d0-b0e8675f71c2"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3356), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3357), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("266cf08a-8bc5-4b31-9dbf-7cfe9de4733b"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3358), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3359), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("27637c7b-ad7b-455a-bb7b-1dbeb61f687c"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3361), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a6bffda9-7a2e-411d-bf91-a8710557d72d"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3365), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3365), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2e4f8bad-1120-482c-93dc-6fe74bc19b9b"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3367), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3367), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("786a3a9d-2d9e-45a2-b4f3-70b73e964ca6"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3369), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3369), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3d33b2bf-4b44-45f8-a378-6cf338d1ad64"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3371), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3371), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f3bda342-92be-4d93-bb2d-7677d71e8147"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3373), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3373), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("40cd6597-fe8d-4860-84a1-ec14f5bcc501"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3375), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3376), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("cbc80983-fd6d-412b-9707-634923428fff"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3377), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3378), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("6aab99e4-64d0-4198-afb4-fe6137052049"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3379), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3380), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("68f31acd-fbe7-457c-8f0c-57a7d617635d"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3383), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3383), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("8f3feaa7-ad0a-41c0-80ef-e4eb84533881"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3385), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3385), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("23c7d816-0349-4877-ad97-a942dba64553"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3206), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3207), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 10, new Guid("f19dbe2f-77ec-4209-8db9-5eb454c8898b"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2488), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2489), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("20e508e5-947b-48eb-9b51-c0cfe289b540"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2500), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2500), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("c0b85a65-4e5f-4296-893d-4cbee06480a0"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2509), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2509), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2719), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2720), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2727), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2727), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2734), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2734), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2741), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2742), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2748), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2749), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Banner 1", new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3512), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3513), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "Banner 2", new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3518), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "Banner 3", new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3519), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3519), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "Banner 4", new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3521), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3521), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2992), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2993), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3009), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3009), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3026), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2819), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2820), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2832), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2833), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2864), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2865), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("5b832d8a-8a55-4b75-89f1-827c0854507c"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2385), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1, 1, "Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2386), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("e50f9a18-df13-4919-9fc6-642460841209"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2403), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 2, 1, "Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2404), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("0fea699e-f5bc-4146-85a2-ddede96e7361"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2416), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2416), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("0fb07cf7-bac5-402e-a1f2-a28dda742852"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2426), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 4, 1, "Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2427), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("77a01308-fcec-4ba4-ab40-1326f0798dbf"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 5, 1, "Loi Quach", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2437), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("8f96cdce-a683-46fb-b92d-159dd73ac616"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2447), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 6, 1, "Dat Do", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2447), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("3a8e4410-f860-425c-a433-318d34e2d210"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 7, 1, "Khoa Nguyen", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2459), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("13cbc2cd-0940-4bd4-a987-d3426edbd415"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 8, 1, "Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2468), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("9928f7ae-03f9-43f1-8e47-c025a255e80e"), new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2477), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 13, 1, "Admin Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2478), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2521), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2522), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2531), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2532), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2579), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2580), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2588), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2594), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2595), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2603), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2604), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2610), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2611), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2618), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2619), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2627), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2627), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2651), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2652), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2659), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2660), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2666), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2667), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2674), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2675), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2681), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2682), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2689), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2689), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2696), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2697), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2703), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2704), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2712), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2713), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2877), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2877), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2971), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(2972), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3043), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3044), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3063), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3064), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3079), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3080), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3092), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3093), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3104), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 9, 22, 17, 19, 26, 546, DateTimeKind.Unspecified).AddTicks(3105), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

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
