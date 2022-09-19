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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("f107b1a6-8b80-43af-95df-df4b5f5a42c2")),
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("17a00e11-8723-4593-a7c1-447ce0065a37")),
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 615, DateTimeKind.Unspecified).AddTicks(1439), new TimeSpan(0, 7, 0, 0, 0))),
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
                    { 1, new Guid("43ef9eef-fdf2-41fe-b6b3-bd83ca70686f"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5070), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5077), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("ab638817-f33f-4b4d-8f89-03f1097c831e"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5089), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5090), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("426ce19f-8933-440c-a1ca-07edd3e7d3ed"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5098), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5099), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("14cdf175-2509-4d3f-ab0a-f16d582da4c0"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5106), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5107), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("f991d168-e0b5-4981-96f9-2a76f4261e0c"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5114), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5114), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("1d02cdd2-2733-411b-a48a-7108c944ff80"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5123), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5124), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("670dc057-2872-4bbd-bccf-244a75fd5711"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5137), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5138), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("9debba30-3cda-47a9-b996-566b6e596036"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5145), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5146), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("5e86d64d-0e15-4723-9672-8cd772498bae"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5160), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5161), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("b9accf17-11fc-4bde-b8df-1c67960de08e"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5171), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("548f6a0f-76c1-467d-a611-009444abceb6"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5178), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5178), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("b6d14b37-ae92-4256-b0e2-a8878ef67647"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5185), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5186), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5442), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5443), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5450), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5450), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5458), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("9fb46e89-6fd9-4978-bc19-418830ead9d2"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5751), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5751), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e57c1e31-2c71-4d8d-ae63-dd1cebc42d88"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5756), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5756), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0b4b18ec-8dc4-4fd2-9243-1275f68bdb20"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5762), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ac1009be-d9e3-4aa5-81cd-fc29a7936726"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5764), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5765), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4cb6d227-bcb1-4234-a07e-ce16e3119d83"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5767), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5768), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a854efad-9d26-40db-ab3d-a82038cb15d9"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5770), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5771), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("892e236c-42bd-433d-a371-b3a0de965b5e"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5772), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5773), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("afeefada-de6f-42db-9083-1df363410769"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5775), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5776), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("5d16b5da-eabb-43a9-b5ac-14fb6be479ca"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5777), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5778), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("ec822af5-efd3-4b80-ab65-d031cf74715e"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5781), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ba679870-1994-41e2-9058-4014b24d32cb"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5785), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5785), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7b76ca34-31b5-4ab1-a03f-0f81f46c1f25"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5787), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5787), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("90cb0e87-2a3b-45ef-8d11-5b7959f263b4"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5789), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5790), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("b9e20ee9-c819-4172-97db-e5bd3c4b3d3f"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5791), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5792), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("68b9597c-3bdb-466a-8492-5965da1558bc"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5795), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5796), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("61f96429-4d38-46d5-8f92-29d3de766c4d"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5798), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5799), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3ec48409-0c6d-4bb9-99a3-0283587e25cc"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5800), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5801), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("31b5307e-3b37-481b-8e53-6a870733b220"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5803), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5804), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d3693563-0fc4-439c-a661-77b064b81ccd"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("08af5406-8ecf-4c24-ae0f-905d72134987"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5810), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5810), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4bfc8273-6bda-4334-a65b-179c8c5a9906"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5812), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5812), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1d6ac821-3e83-4e8a-acfb-095e3cdab3f3"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5814), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5815), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c7b4c4bf-081c-4a71-b4d2-7e420f075e26"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5819), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6b5a952e-4980-4104-b589-328c3c20ce59"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5821), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5822), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e9ee016c-29f7-4e01-a875-b0b35b964429"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5823), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5824), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("76dbdf6c-617f-491e-9e19-e292a1e75c08"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5827), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5828), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("13c389f8-d82f-40d6-8f41-a9d74c83db09"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5829), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5830), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("760ec3e9-9118-48c9-b2e9-eeb4d8d28084"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5837), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5838), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("08116f9a-d7c7-4938-af6b-b71664fef939"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5839), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5840), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("60529dc5-2184-4fcc-a638-009787eaad4e"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5842), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5842), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5a86a61d-8ff4-4ed7-a300-d4e0873c7f3b"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5845), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5845), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0eb11f24-1fc6-4609-8673-befa44b937d2"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5847), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9db6e2a9-2680-4a16-8a65-b645ff319aa5"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5850), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5850), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d7269e23-6d63-41eb-ab25-2d40f5bda835"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5853), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5854), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("20761df2-30f7-4d0d-8317-f86bbcede4f9"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5855), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5856), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d0653f73-db2c-478b-91b2-9be8ee16c344"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5858), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5858), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("4ec57728-9840-41ef-a8f1-39c687b3e804"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5860), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5860), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("73290d80-31c8-4069-9fc6-610400226549"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5862), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5862), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("05b1610e-752b-4d1e-ac3b-6ef68459efe9"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5864), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5864), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2e582dbf-afd2-4b61-83f4-270b9c9ed00e"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5866), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5866), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a26c6af2-0c89-441a-b82f-3214110204af"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5868), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5869), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3b25871e-c80c-4850-9163-ba18dad2ed68"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5872), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5872), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("aa80673d-15d4-44fd-a78c-c95166e9b4ae"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5874), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5874), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("74490d57-4023-467a-a062-efbc7124ba77"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5876), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5876), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6c566ce1-092b-432d-a32d-d6609688e441"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5878), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5878), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e85364d0-1991-4a3a-b8d3-3993a48a99a2"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5880), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5881), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("98c28a33-8523-47a7-bdb1-8e9eeeb8042e"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5882), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5883), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3bf96dea-bcd7-42bd-af55-ede90399b942"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5884), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5885), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("49c458ca-90a6-4192-afd4-0abb8d8845ab"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5887), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5887), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("02fafd8b-6146-478c-884a-7727d47ce0b3"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5891), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5892), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("55b027a2-7789-4cc3-b8c7-b87f06c02f37"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5893), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5894), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2dfe1de4-6e00-48e6-b05d-8828d6afbe6f"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5896), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("35a50419-c1c8-4277-bbab-62290b2ad7a5"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5897), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5898), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("11f80c39-f140-477b-b880-01b3d180551e"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5899), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5900), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bc64d43e-bba0-42de-be07-444008a0d3d8"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5901), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5902), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f3fd482b-d2d5-4298-a2a6-07ca04e6acc4"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5904), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5904), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9049cb79-5155-40da-b07c-e5fe71d8cf83"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5906), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5906), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e412dcbb-028a-408e-b3c1-6fecbfd70255"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5909), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5910), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8707923a-5e51-40e5-9b11-01b0a9eae6f1"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5912), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5912), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2873ae21-bfd5-4091-82c5-9b9cfbfdf2ce"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5914), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5914), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2535873e-6210-41ba-ad3f-a37310eef947"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5916), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5917), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0e7dc520-6a0d-4e66-ab9c-1167a7316432"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5919), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5919), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("633c9b19-cbd3-4b64-add8-86a14b49fc97"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5921), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5921), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4a2b1939-6121-4a15-ada4-5281918bbc1e"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5923), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5923), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("95db5af2-15eb-4b3d-bed9-42f9ae27df01"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5930), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5931), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9d092104-3d52-414a-81f4-8beaa4f6cf96"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5935), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("05731ee7-5d14-4374-9f48-6446b6c77a48"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5936), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5937), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0a94caab-4901-46bc-a327-14039bb1af8a"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5938), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5939), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dbc15f04-993a-4b41-af32-e915437d27bf"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5941), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5941), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("36c6d467-7386-4ebd-b5ea-f1324434dfb0"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5943), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("b5a139bc-fdc2-45a4-bc79-f1299de7650d"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5945), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5945), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a36b0498-6e56-4f1b-958a-a267138c6ff4"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5947), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5947), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("62f04ed0-10fd-4949-beac-1f2a654d7b14"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5949), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5949), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("93e772da-972c-4f78-ad07-a7e6cde5f1e7"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5953), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("acda72b1-6392-450b-9b32-1148f53151e6"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5955), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5955), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f86902b1-7e84-4740-bbde-f7ac3080746e"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5957), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5958), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7d20845d-23d5-4d4b-9b25-720971cae217"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5960), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5e3d227c-5035-4ca1-a299-148dd6a0f2ec"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5962), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8632051b-e59b-4cd4-8c66-3c00b6a0902f"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5964), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5964), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("60735987-de22-43d8-a92a-a28dddc16e25"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5966), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5966), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("d96f5a0f-c666-4f71-b0e7-01e23e4a5e37"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5968), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("1730d62e-d1b9-428d-92d0-78cf2aeaebe3"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5972), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("560e4829-1a02-4740-b060-b913872f0f20"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5975), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("f2d02b50-aad7-4626-9b82-db7acafe4b81"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5977), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("55f81e5b-4597-4cfb-9683-2b77bbc01af7"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5816), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5817), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Banner 1", new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(6074), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(6075), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "Banner 2", new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(6078), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(6079), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "Banner 3", new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(6080), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(6080), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "Banner 4", new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(6081), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(6082), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5588), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5606), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5606), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5628), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5629), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5424), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5434), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5434), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5466), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5467), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("5249f744-267b-43f0-92c9-48454be240c7"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5203), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1, 1, "Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5204), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("d16dfd31-ba99-4667-8b4a-3f429d5a84e8"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5219), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 2, 1, "Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5219), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("d0546040-700d-4812-9c7b-c5f842bed258"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5229), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5230), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("3ffb5e5e-932e-44ea-85aa-a6cdb042c31d"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5239), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 4, 1, "Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5240), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("11f68edc-ed96-4cf8-98b6-259001a10717"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5249), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 5, 1, "Loi Quach", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5249), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("c3147802-2f93-4c3e-9fd6-fbd51b3d19db"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5262), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 6, 1, "Dat Do", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5262), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("81b47b17-7ab6-4132-ad77-d569fa5ab663"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5271), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 7, 1, "Khoa Nguyen", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5272), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("60003deb-8afc-4852-8874-9f62b9cbe286"), new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5281), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 8, 1, "Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5281), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5295), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5296), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5304), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5305), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5312), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5313), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5320), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5321), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5327), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5327), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5339), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5340), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5347), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5347), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5354), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5361), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5369), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5369), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5376), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5376), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5383), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5383), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5390), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5390), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5398), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5405), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 16, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5412), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5478), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5479), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5565), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5566), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5670), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5671), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5692), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5692), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5708), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5709), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5721), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5722), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5734), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 9, 19, 16, 37, 11, 619, DateTimeKind.Unspecified).AddTicks(5735), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

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
