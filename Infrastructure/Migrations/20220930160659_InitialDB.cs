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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("9d045b92-a39b-4bc6-a084-f45e363f06ae")),
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
                    code = table.Column<Guid>(type: "uuid", nullable: false),
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
                name: "vehicle_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    slot = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_types", x => x.id);
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
                    next_route_station_id = table.Column<int>(type: "integer", nullable: true),
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
                        name: "FK_route_stations_route_stations_next_route_station_id",
                        column: x => x.next_route_station_id,
                        principalTable: "route_stations",
                        principalColumn: "id");
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
                name: "fares",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    base_price = table.Column<double>(type: "double precision", nullable: false),
                    price_per_km = table.Column<double>(type: "double precision", nullable: false),
                    base_distance = table.Column<int>(type: "integer", nullable: false),
                    vehicle_type_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fares", x => x.id);
                    table.ForeignKey(
                        name: "FK_fares_vehicle_types_vehicle_type_id",
                        column: x => x.vehicle_type_id,
                        principalTable: "vehicle_types",
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("2cd42cb9-b9f8-4895-8ec6-97c17a95e139")),
                    time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    total_price = table.Column<double>(type: "double precision", nullable: false),
                    discount_price = table.Column<double>(type: "double precision", nullable: false),
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
                    promotion_id = table.Column<int>(type: "integer", nullable: true),
                    route_id = table.Column<int>(type: "integer", nullable: false),
                    vehicle_type_id = table.Column<int>(type: "integer", nullable: false),
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
                        principalColumn: "id");
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
                    table.ForeignKey(
                        name: "FK_bookings_vehicle_types_vehicle_type_id",
                        column: x => x.vehicle_type_id,
                        principalTable: "vehicle_types",
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
                name: "route_routines",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    route_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    start_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    end_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    start_at = table.Column<DateOnly>(type: "date", nullable: false),
                    end_at = table.Column<DateOnly>(type: "date", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_route_routines", x => x.id);
                    table.ForeignKey(
                        name: "FK_route_routines_routes_route_id",
                        column: x => x.route_id,
                        principalTable: "routes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_route_routines_users_user_id",
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 475, DateTimeKind.Unspecified).AddTicks(9676), new TimeSpan(0, 7, 0, 0, 0))),
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
                name: "vehicles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    license_plate = table.Column<string>(type: "text", nullable: false),
                    vehicle_type_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.id);
                    table.ForeignKey(
                        name: "FK_vehicles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vehicles_vehicle_types_vehicle_type_id",
                        column: x => x.vehicle_type_id,
                        principalTable: "vehicle_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fare_timelines",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    start_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    end_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    fare_id = table.Column<int>(type: "integer", nullable: false),
                    extra_fee_per_km = table.Column<double>(type: "double precision", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fare_timelines", x => x.id);
                    table.ForeignKey(
                        name: "FK_fare_timelines_fares_fare_id",
                        column: x => x.fare_id,
                        principalTable: "fares",
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
                    { 1, new Guid("54562d15-f688-4b0f-94b0-8e51684b6379"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(566), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(575), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("90062b93-b85d-4341-81aa-645a3f9b9d10"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(642), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(643), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("e8f40e37-2c3a-4b92-891c-85e831cf78dc"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(655), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(656), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("0560d180-1a43-4004-89f0-0d93fbc74813"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(667), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(667), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("84049d5c-364d-4de0-b234-a6160c170299"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(691), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(692), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("a122d5be-6c09-4329-85db-a2d1e14a31cc"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(707), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(708), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("edff6ef3-938b-40b5-be9d-30c0e20db5b5"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(720), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(720), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("87db9377-d006-427c-a1d5-b1e350c88e6c"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(731), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(732), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("3a571a85-50ca-45be-95c0-e5806365f6c6"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(743), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(743), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("232f6366-57ac-420e-bd72-9030703cf37f"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(756), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("3063ef63-f775-4ce1-81a8-867e13b45aa1"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(767), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(768), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("c81d2c0c-8119-41c0-8af3-dfb5fb63fbcf"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(779), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(780), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("1e3c2b48-ffa5-489b-bc78-6f4ddc8659ba"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(793), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(794), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1424), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1434), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1435), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1444), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1445), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("6b8beb3e-63f8-426e-842f-6e02638bdc8b"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1851), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1852), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bdfbf13d-764f-4034-9151-7d58466e5ef2"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1858), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1859), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("aa4caf3d-106c-4712-a162-ffa7ffeb84f8"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1862), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1863), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("db5b0fc7-da76-4072-9aee-b5e40db3e3fa"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1865), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1866), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6660b73d-fa38-4dc1-90c3-8b73e04f54ab"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1868), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1869), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("40c715d0-be89-4b35-b4d6-e4dec1d692f8"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1873), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1873), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f15774d6-19b7-4db8-a785-3e200a38ea69"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1876), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1876), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d20741c5-59ac-4c7b-927d-0dd4bb89e0cd"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1883), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1883), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("4749ddde-dfc3-4004-a6c4-7233ba28283a"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1885), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1886), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("7054512f-53cb-4e09-bb9a-4a4e538724fd"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1890), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1890), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("215194a9-60aa-4611-a9ec-0c63a9865806"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1893), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1894), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8672969a-c202-4dff-ac6b-77d1b9da0c44"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1896), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1897), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fbe8f848-8efd-498a-8f64-4e2ff22c559b"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1899), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1900), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("cb883433-6f4c-4c6a-8662-1f892e0195bd"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1902), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1903), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cdbcb1ef-bf06-497e-a0f3-3149c65377ae"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1906), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c553eba5-59d7-462d-b948-935d0619428f"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1911), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1911), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cb29cf5b-3fa4-4e04-829e-339c7a795044"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1915), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1916), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a77a9d0d-bc93-40ea-b143-0548269a5b6a"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1919), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1920), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("38621e35-b8da-4bcf-b532-160cd3fb2318"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1922), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1923), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a29b875a-cd0a-45dc-bf95-46d3614e172b"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1925), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1926), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d6d4238a-d961-4de9-a2ea-01ee36ed1fe8"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1928), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1929), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0a0542c5-c010-42a2-8350-14d327f570c5"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1931), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1932), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e4c57abf-6d8c-460f-bf19-be90a749fa2f"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1940), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1941), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4cdfb927-7c9f-42c8-a150-70c919ff162d"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1943), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1944), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9c8f8c85-2230-49f2-bd7c-d6f20c2da779"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1946), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1947), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fcf72ac7-3926-445e-a13c-b28e060d6b6f"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1989), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1990), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("86f0503d-9604-4f24-a44d-a519074093a9"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1992), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1993), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("78dd6d5a-6c27-4a99-94a1-d9cd66a59c48"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1995), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1996), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("57c9fcb1-cff3-4a7b-aa2e-a1e2a6b3e1f4"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1999), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e0289360-5a0d-470f-90d9-be203f216f6a"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2001), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2001), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b0a6b8f4-ce97-48b5-88d6-2cb75fb0bb31"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2007), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2007), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("090f8697-8278-42d9-8abb-0bc71dea5d5b"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2010), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2010), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("68db96a8-1886-471d-be03-81959bcb0158"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2014), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2015), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f21c4921-fcff-4cac-9847-9b7fa26788df"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2018), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2019), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("31c8598d-2ebd-454e-81a7-6fd502d98e7b"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2022), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2023), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f2c9348a-20fc-40d2-8dfd-5e5ff7e8f0be"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2026), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("69dfb635-6445-40cf-a5e9-220f09d26ffb"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2030), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2031), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f958ff8d-44d8-431e-b55f-cde71866f6f5"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2033), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2034), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f0b0342f-a143-4deb-aa57-6191f910eba4"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2039), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2040), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("81227fbb-1378-485e-a6c3-0bb9ae2af3e5"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2043), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2044), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c3e788db-33f0-468a-9efe-a96c684210d1"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2047), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2048), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f56fb4eb-8141-4cfc-98dc-2d375db0539e"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2051), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2052), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("4e21870a-8c4c-479e-a5d0-d7aefb94514d"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2055), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2056), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("113c7e77-5ba5-4f98-94c2-e5ffe3463b41"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2058), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2059), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d0c19460-7839-479c-a0cc-1675a24d96bf"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2061), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2062), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("40b0559f-7785-4a6f-afd8-dd94b55a22b9"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2064), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2065), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("abe4661e-8c59-46d9-bb07-3f41945650bb"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2070), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2071), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("184fd30b-63d5-4337-994f-b20169c472c0"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2073), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2074), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0eed69cc-0f69-4629-b109-7cf801367b51"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2077), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2077), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ca89989c-326b-4ef1-8e1b-9134f713c1c7"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2080), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2081), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7181c5eb-abd6-4eae-90c7-5e60ce4eeaba"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2083), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2084), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f9770def-3651-4fe3-be46-48f2e50e2285"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2086), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2087), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("11e488a2-1871-45f4-96a2-1eb657a82f9e"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2089), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2090), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fe429ab2-810c-4a1b-a860-660cf8695ed7"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2092), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2093), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3c0d6f71-cd31-4db2-bec5-47e6de33dcde"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2098), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2098), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4a112655-cc24-4b7b-808d-26d53fe2f2fb"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2101), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2101), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6ec715a4-33ba-4302-b255-376166f5a1a7"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2104), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2105), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("547e4802-73ac-433e-b9c7-d92812656715"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2108), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2109), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8a68c223-c418-4935-98fa-2fb4b0a36ab4"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2111), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2112), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5f2e7203-0b56-436a-a69d-b91d7b31d22d"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2114), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2115), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("51ee484a-7fd6-4e0b-aa1d-99909e02f8d2"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2117), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2118), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2a8428eb-bdac-4e5c-9d31-dd6c1289f2a0"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2120), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2121), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2b0971d7-56e9-4851-9712-b84c6c674bd7"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2127), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2127), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c104c1ea-86dd-4569-80c6-9b5e71610848"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2130), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2131), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f00e8e75-d6e5-46ff-87fb-527a8376bb65"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2174), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c9ac36a1-aa00-4aa6-a63b-135b6be2b1d4"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2177), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2177), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c6589f6c-2f44-4b9c-87e0-318623badfaf"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2179), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2180), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f23d528f-35e9-474a-b796-d69f26946256"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2182), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2183), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6fc8a3b0-3faf-4d34-a0b1-641476bec1be"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2185), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2186), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("afd27765-3c66-4ac5-8f7d-4cebd9f652d2"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2188), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2189), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("4234b5ae-e96a-48a4-8532-a0e79f388b11"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2193), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2194), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("174ce9c5-586e-4d14-809a-f36143e5e8a7"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2196), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2197), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b9adb5a3-fbb8-428e-b266-76a90e7d26ab"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2200), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2200), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e8a95900-c805-4ea7-8591-195558033d16"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2204), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2204), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1075c7f4-5bde-4169-81ce-6b7940076ac1"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2206), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2207), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d09b954f-d71b-4053-9c66-38531413f974"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2209), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2210), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d085a35f-726f-425f-8301-7d0c4b137240"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2213), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("21d5cf85-be5e-44ce-8a88-6e8c310888e8"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2215), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2216), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("11f46ef0-588d-48d2-9168-7a2d09724729"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2221), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2222), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("e6fa9566-5b84-4b86-9fb5-a09d3d7c18ab"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2224), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2225), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("22b5830a-067a-4aae-b730-d3692ca65b41"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2227), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2228), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("a199c1c6-bd3c-442b-b7f5-c91e6f879bf5"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2230), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2230), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("6927e612-1a80-4493-ba4e-0908fe4be5ec"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2233), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2233), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("b33e7087-b091-4e51-a05a-476685421065"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2235), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2236), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("033eb54d-7d74-406b-b5ae-571b4ec85435"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1934), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1935), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 10, new Guid("ebca6a2f-347c-4f8a-8e9d-9ba94dc753b0"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1000), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1000), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("c63afb87-e7c7-4bc5-bfb8-458d90f9bc0b"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1014), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1014), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("0030730a-e820-4d28-a94d-92aa51afb091"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1027), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1028), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "name", "slot", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("28cd55cb-8bf3-4456-8e45-459ce3457f26"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2330), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViRide", 2, 0, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2331), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("74e68e88-15e3-48d7-b4d0-e58f348e7fb4"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2416), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-4", 4, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2417), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("841581d3-3cbe-4d13-ab99-c40f9b4913a3"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2434), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-7", 7, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2435), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1326), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1327), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1337), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1338), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1347), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1348), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1358), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1359), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1369), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1379), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Banner 1", new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2279), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2280), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "Banner 2", new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2285), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2285), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "Banner 3", new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2287), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2288), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "Banner 4", new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2289), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2444), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2444), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2450), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2450), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2452), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2453), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1622), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1624), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1686), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1687), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1711), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1712), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1397), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1412), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1413), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1455), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1456), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("7066ae0e-4b81-43c7-8b77-f7bfe3d934ab"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(817), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1, 1, "Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(818), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("8540b180-ff83-41b8-957b-3cd06b2d96af"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(836), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 2, 1, "Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(836), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("29c4b647-d735-49e6-8c19-4e079375f1df"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(850), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(851), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("5d600064-ed3f-4f3b-9d8e-049311ea6368"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(865), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 4, 1, "Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(866), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("73a0a9dd-110c-4e3a-8596-6d3c73199793"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(882), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 5, 1, "Loi Quach", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(883), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("59062f31-624d-4700-88d8-a7c4b394bd5c"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(897), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 6, 1, "Dat Do", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(898), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("e96795c7-b182-414b-a68a-ce6e01552440"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 7, 1, "Khoa Nguyen", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(953), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("d5f22992-8746-45fb-a985-25ea64778d93"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 8, 1, "Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(968), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("43e6c579-ffa4-4fd1-943f-6affa76bd871"), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(985), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 13, 1, "Admin Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(986), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1051), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1052), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1065), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1066), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1076), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1077), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1087), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1088), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1133), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1134), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1146), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1147), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1156), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1157), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1166), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1167), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1178), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1179), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1190), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1191), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1201), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1201), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1211), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1212), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1259), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1260), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1272), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1273), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1283), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1284), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1293), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1294), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1304), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1316), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1317), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2470), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 0.12, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2471), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2523), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 0.10000000000000001, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2524), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2532), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 0.14999999999999999, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2532), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 0.10000000000000001, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2541), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 0.12, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2549), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2558), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 0.10000000000000001, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2559), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2566), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 0.14999999999999999, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2567), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2574), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 0.10000000000000001, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2575), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2583), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 0.12, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2583), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2592), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 0.10000000000000001, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2592), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2600), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 0.14999999999999999, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2600), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2608), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 0.10000000000000001, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(2608), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1469), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1470), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1596), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1597), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1737), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1738), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1766), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1767), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1790), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1791), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1809), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1810), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1828), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 9, 30, 23, 6, 58, 482, DateTimeKind.Unspecified).AddTicks(1829), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

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
                name: "IX_bookings_vehicle_type_id",
                table: "bookings",
                column: "vehicle_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_fare_timelines_fare_id",
                table: "fare_timelines",
                column: "fare_id");

            migrationBuilder.CreateIndex(
                name: "IX_fares_vehicle_type_id",
                table: "fares",
                column: "vehicle_type_id",
                unique: true);

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
                name: "IX_route_routines_route_id",
                table: "route_routines",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "IX_route_routines_user_id",
                table: "route_routines",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_route_stations_next_route_station_id",
                table: "route_stations",
                column: "next_route_station_id",
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

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_types_code",
                table: "vehicle_types",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_code",
                table: "vehicles",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_user_id",
                table: "vehicles",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_vehicle_type_id",
                table: "vehicles",
                column: "vehicle_type_id");
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
                name: "fare_timelines");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "promotion_users");

            migrationBuilder.DropTable(
                name: "route_routines");

            migrationBuilder.DropTable(
                name: "route_stations");

            migrationBuilder.DropTable(
                name: "user_rooms");

            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "verified_codes");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "fares");

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
                name: "vehicle_types");

            migrationBuilder.DropTable(
                name: "promotions");

            migrationBuilder.DropTable(
                name: "files");
        }
    }
}
