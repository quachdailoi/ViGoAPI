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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("4fead58a-20d9-4b97-9303-ed0e1f9d81d0")),
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
                    table.UniqueConstraint("AK_stations_code", x => x.code);
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("fc072d95-3b83-43fd-b534-3ae7aebf5e57")),
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
                        name: "FK_bookings_stations_end_station_code",
                        column: x => x.end_station_code,
                        principalTable: "stations",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookings_stations_start_station_code",
                        column: x => x.start_station_code,
                        principalTable: "stations",
                        principalColumn: "code",
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 32, DateTimeKind.Unspecified).AddTicks(6826), new TimeSpan(0, 7, 0, 0, 0))),
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
                    rating = table.Column<double>(type: "double precision", nullable: true),
                    feedback = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    discount_price = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0),
                    status = table.Column<int>(type: "integer", nullable: false),
                    booking_id = table.Column<int>(type: "integer", nullable: false),
                    message_room_id = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true),
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
                        name: "FK_booking_details_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "booking_detail_drivers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    start_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    end_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    booking_detail_id = table.Column<int>(type: "integer", nullable: false),
                    driver_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking_detail_drivers", x => x.id);
                    table.ForeignKey(
                        name: "FK_booking_detail_drivers_booking_details_booking_detail_id",
                        column: x => x.booking_detail_id,
                        principalTable: "booking_details",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_booking_detail_drivers_users_driver_id",
                        column: x => x.driver_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "path", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("917db335-877d-4210-a8d9-ce7a0c5db0a0"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(342), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(353), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("f0aa911d-2ab9-48ed-926a-34f1b519ee39"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(398), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("b35a9ab9-79a7-46a3-90e4-6981d6b9f227"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(407), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(408), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("91f10408-e8cf-47b7-8824-42ae8f6199ff"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(428), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(429), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("00e25b29-3259-4930-9226-bb0855c1cba2"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(438), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(439), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("78faedb9-200a-4c98-bc01-f7bb83b86152"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(449), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(449), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("74503ea5-a0b9-4343-84fb-faf0e2991bed"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(459), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("7f744cbd-b2ab-4e03-bf3c-a281ef4d4f49"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(467), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(467), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("3fe801e5-5c8b-4f71-a04b-fd11dc1bb6df"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(475), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(476), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("6ca513b2-35d1-4f6d-ba06-4d4fe873788b"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(485), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(485), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("81e15f71-5514-4712-8bbd-6f1a7f0361f2"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(493), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(494), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("b0442da4-4f6d-459b-9727-2d78990c9847"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(505), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(505), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("8a86f7a6-a3d2-427b-babd-5c55f395d94c"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(514), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(514), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(990), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(991), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(998), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1006), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1007), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("6bb6b872-f27b-4e2b-b9c2-921b4c2aafcf"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1326), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1327), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("900884e3-ac76-4e68-8159-0f6844e5c965"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1332), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1332), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("228949a1-4597-4f61-9c31-afc650e97bd4"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1335), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1336), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("edfc1c30-7f3c-4eae-94a6-4a43ab4757ed"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1338), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1338), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9f3a189f-f634-40ac-b132-3ab278e1d889"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1340), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1341), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("af8441a6-ee60-4a09-8253-0ea102e475bc"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1343), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1344), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("197a273a-951b-40db-a360-4fac7f8a198d"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1348), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1349), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3e30e4d1-e9cc-46bb-ab61-a9fed47bdf25"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1351), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1351), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("2405ead0-270c-4987-ab2f-1d6b2cc749c4"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1353), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1353), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("38737a44-c62b-4436-b840-5dd082629aad"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1356), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1357), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0fb83ad7-3ca1-4e9d-8cc8-674de666bdbd"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1359), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1359), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("80b65160-a753-447b-a2e8-574b8f493107"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1362), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cfccd81f-bf27-4096-b380-af41c67766b3"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1364), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1364), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("33ad8944-88b1-4e4f-9124-8f21e3e8e9e0"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1366), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1367), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9e3d57e5-6e27-4875-92f5-bcf51375eeb3"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1370), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1371), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ac0c2d31-916e-4af9-8e37-d98e7176d103"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1373), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1373), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8c7ae0e4-a67f-4024-a55f-002805b561df"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1376), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1376), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("52eef440-ef79-4d89-9d36-66b55ed9f319"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1405), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1406), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("18502b33-6612-4665-a497-96c68eb19a2b"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1408), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1408), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3279d4e3-d1df-4f67-b5b6-7e24411c7827"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1411), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a3d67cd9-0b0a-4cdf-bed1-dac64f168005"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1414), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1415), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3f576bef-1e33-47b0-b02e-c972aee51c5e"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1417), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1417), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("79ae07cc-463e-4ddd-85b1-47d9266e0117"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1423), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1fbb80ec-86ef-43d0-8021-24753e958818"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1425), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1426), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b12d2a72-6194-4e37-8be4-0094c8e5f888"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1428), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1428), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fb168286-ff7a-4e8f-baa8-5a6018c451c6"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1430), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1431), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("04caeca3-e1c9-4535-98ff-0be92b966920"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1432), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1433), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5de4945a-ef0f-458c-9dbb-1de1628b5e23"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1435), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1435), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ec5e41fc-51d7-4e2c-98bd-0d69a2f7398c"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1437), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1438), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5a2cb299-3de6-4dfb-bbc4-fdc903ed8dc0"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1441), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1441), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bf57d970-2daf-4d93-9c16-00380172e42a"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1443), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1444), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b333245d-0881-410d-8ce9-6ffc2bbf303b"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1446), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1446), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("09d5fd3e-5b44-4a44-94a1-4c3144eb3ab3"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1449), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1449), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ac7e51ec-19f2-4c9e-8411-2767462de136"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1451), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1452), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bb9a223c-1228-4929-9c82-92be4d13dc2f"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1453), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1454), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c7ba1240-c4f9-4a83-bfdb-efb4512a969f"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1456), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1456), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("c53db1e4-0da9-43ed-b561-3ec49a4870d2"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1459), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8b39469b-611c-4065-83ae-3c0a943d8e82"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1462), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1463), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("38483df2-2fea-4606-879c-9d3848715680"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1465), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1465), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("36dc2aa2-c3b6-4f48-b7a5-b24cef8e3015"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1469), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("913e08bc-ef94-4f61-a551-bdcee1f8c0e9"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1472), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1472), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("27fba782-4d14-463f-9193-6ccde18f81ca"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1474), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1474), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("13b0cfee-3ba1-4bf6-9dc0-0779916d638b"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1476), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1477), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("6145fab0-0c9b-456c-974c-6e6c1345d273"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1479), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1479), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ca5b10ff-500b-4685-a298-1c770f188fe0"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1504), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1504), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0e6e16ce-70de-4388-8d8b-6c8ba0cb7b06"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1508), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1509), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("64ab18e3-6c79-45b6-8dba-9ef972008c3a"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1511), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1511), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("832b12a7-5380-46db-909a-f5d2e4432148"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1513), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1514), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e64a8b6d-6152-4106-9edf-af55e6399516"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1516), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1516), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("080a31b0-a10f-411c-aad3-1437ca30a19a"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1518), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1519), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9a05413a-b9db-4ffb-affc-5d307d361584"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1520), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1521), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d269c320-c79c-48ea-a19d-710909594323"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1523), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1523), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("52091892-5e5a-48eb-81dd-47966cda838f"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1525), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1526), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7dd485f8-385e-4980-8e20-d7d0c70408ea"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1529), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1530), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f2ede798-593d-485f-9b24-62f511d0adfe"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1531), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1532), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4796fd92-9d3a-4981-85d7-354b0f95e3e1"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1534), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1534), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4918c634-5d49-4bea-b2be-a056dbe6fdbb"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1536), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1537), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1fe81331-67ca-4b32-9bb2-d53ab0a34995"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1539), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1539), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ad63fc8d-d7e7-4248-9b8e-34d9fa6d2e11"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1542), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1542), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("531039a7-d2c2-45e1-ad56-839b6d2c42ed"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1544), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1545), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e9be7f91-1c54-4f00-b07a-6e410c008ebe"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1547), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1547), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e05c4475-64d1-4b4c-becc-631c90cbe3af"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1551), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1551), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a025c271-5149-4d32-9227-93e85122a9ae"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1553), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1554), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("52a634ec-fa15-49cf-8455-097b25cec67e"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1555), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1556), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ebf1e17c-e711-4973-8be4-d712564dfc54"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1559), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1559), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1d7cc9ed-ea49-4a22-9b52-ed5fb0450e77"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1561), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1562), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("89f3d7ee-1584-4e2b-8957-33d49ebcde15"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1564), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1564), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7bff32c4-39d0-49aa-aafd-7b2c2bca8751"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1566), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1566), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a3710d85-4bb2-4343-bb7b-b71cf6e53f8b"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1568), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1569), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9cb50612-0c63-4fa2-b10d-cd41266e5aae"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1573), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("85db47da-2e99-4e15-8cf1-be9379e865fa"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1574), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1575), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("05411852-fdc2-4b61-b49d-f52dfd5a45ce"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1614), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1615), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bdfbe82f-a377-466f-baaf-780853219be8"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1617), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1618), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b60d421e-6cd3-4e9b-b1ff-0f47c326f7dd"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1619), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1620), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b5e0e3b6-7fb4-4cf0-9d63-20fc98d44878"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1622), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1622), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("85dcba05-dde4-4c2c-8117-c94e69a777d8"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1624), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1624), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3093ee53-384e-4753-9fd4-2049f6e83e47"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1626), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1627), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("acf4821c-b1ea-4287-9f2d-9f2184b78f23"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1630), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1631), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c9a6c438-38d7-4ff3-bd31-f33b522f7f7d"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1633), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1633), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("0a34f5f0-da09-4b94-9a2a-245ba3a91214"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1635), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("45c6d2e5-5b57-49ac-9194-717da625dffe"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1637), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1638), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("1ea2f5b0-3400-4f73-991a-c2822e9eb9ca"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1640), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1640), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("682eeaa9-734b-450f-8664-4b36f287c68d"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1642), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1643), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("1cde605a-f481-40bd-b25a-b301b4b0bd3d"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1644), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1645), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("df7a3541-21c9-4e0c-b77d-ead588f28766"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1421), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1421), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô E2a-10 Đường, D2b Đ. D1, TP. Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam", new Guid("c78809c3-e1fe-4fbf-8e47-0990a9086939"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1647), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 10, new Guid("d9f561fb-ace2-4dc3-aa9f-dd977904a8e8"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(672), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(672), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("0c7846de-0c57-4397-9b9e-3eeb701b1016"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(683), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(684), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("fd21c6f1-e4a8-4a71-9acf-a1d9967e4360"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(698), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(698), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "name", "slot", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("f97307ff-da63-4e6e-8807-41518e7cefc7"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1726), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViRide", 2, 0, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1727), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("3ccea288-f7a1-45af-b8ad-c742e6932a4d"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1741), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-4", 4, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1741), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("28bff78a-b30f-487b-ab92-784d6512dd73"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1751), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-7", 7, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1752), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(917), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(918), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(925), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(926), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(933), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(934), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(941), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(942), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(949), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(950), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(957), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(957), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Banner 1", new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1682), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1682), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "Banner 2", new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1687), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1687), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "Banner 3", new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1689), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "Banner 4", new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1690), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1690), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1783), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1784), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1791), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1792), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1793), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1794), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1175), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1194), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1194), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1211), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1212), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(970), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(971), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(981), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(982), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1015), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1016), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("f00bffbd-5a79-4327-8b63-c906633e0506"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(532), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1, 1, "Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(533), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("25a2c4ad-ab09-4755-838e-f8ebe006ee26"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(549), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 2, 1, "Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(550), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("2c0b3995-08ad-4f2b-8c86-3046113c478b"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(560), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(561), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("3e3535c3-b8aa-4d2a-a7a1-3baa6d970f8d"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 4, 1, "Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(573), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("92c96e1b-7248-4aaf-b3b3-462932029618"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(584), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 5, 1, "Loi Quach", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(585), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("41d15abf-028b-4be7-a9a4-058789438f48"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(622), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 6, 1, "Dat Do", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(623), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("b34f6df2-3ad8-4815-8cd4-7dbd38ba02e0"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 7, 1, "Khoa Nguyen", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(635), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("2664a9df-4cec-4519-9be6-d7357918580f"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 8, 1, "Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(648), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("d0ece8e7-6032-4a1d-a659-5078d15278e0"), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(659), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 13, 1, "Admin Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(659), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(714), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(714), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(725), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(726), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(734), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(735), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(742), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(743), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(771), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(772), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(781), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(789), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(789), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(797), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(797), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(805), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(805), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(815), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(816), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(823), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(824), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(857), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(858), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(866), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(867), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(874), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(875), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(882), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(883), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(891), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(892), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(899), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(900), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(909), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(910), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1808), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 0.12, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1809), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1848), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 0.10000000000000001, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1849), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1856), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 0.14999999999999999, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1857), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1863), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 0.10000000000000001, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1864), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1870), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 0.12, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1870), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1877), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 0.10000000000000001, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1878), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1884), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 0.14999999999999999, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1884), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1890), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 0.10000000000000001, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1890), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1897), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 0.12, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1897), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 0.10000000000000001, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1905), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1911), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 0.14999999999999999, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1912), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1917), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 0.10000000000000001, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1918), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1026), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1026), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1125), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1126), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1231), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1232), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1254), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1255), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1277), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1278), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1292), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1293), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1307), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 10, 13, 18, 18, 3, 41, DateTimeKind.Unspecified).AddTicks(1308), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

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
                name: "IX_booking_detail_drivers_booking_detail_id",
                table: "booking_detail_drivers",
                column: "booking_detail_id");

            migrationBuilder.CreateIndex(
                name: "IX_booking_detail_drivers_driver_id",
                table: "booking_detail_drivers",
                column: "driver_id");

            migrationBuilder.CreateIndex(
                name: "IX_booking_details_booking_id",
                table: "booking_details",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "IX_booking_details_message_room_id",
                table: "booking_details",
                column: "message_room_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_booking_details_UserId",
                table: "booking_details",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_code",
                table: "bookings",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_bookings_end_station_code",
                table: "bookings",
                column: "end_station_code");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_promotion_id",
                table: "bookings",
                column: "promotion_id");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_route_id",
                table: "bookings",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_start_station_code",
                table: "bookings",
                column: "start_station_code");

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
                name: "booking_detail_drivers");

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
                name: "booking_details");

            migrationBuilder.DropTable(
                name: "fares");

            migrationBuilder.DropTable(
                name: "promotion_conditions");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "promotions");

            migrationBuilder.DropTable(
                name: "routes");

            migrationBuilder.DropTable(
                name: "stations");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "vehicle_types");

            migrationBuilder.DropTable(
                name: "files");
        }
    }
}
