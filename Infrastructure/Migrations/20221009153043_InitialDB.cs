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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("dec9c8da-a318-4e6f-aba8-c02f1aebe7bb")),
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
                name: "affiliate_accounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    token = table.Column<string>(type: "text", nullable: false),
                    extra_data = table.Column<object>(type: "jsonb", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_affiliate_accounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_affiliate_accounts_users_user_id",
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("dd5faa18-d95f-4c42-b237-c6254d413c6b")),
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 372, DateTimeKind.Unspecified).AddTicks(4943), new TimeSpan(0, 7, 0, 0, 0))),
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
                    Status = table.Column<int>(type: "integer", nullable: false),
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
                    { 1, new Guid("3d248592-fc0b-403f-933e-7d89dc84958c"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7846), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7866), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("617c0213-2e69-4569-8839-4c8d127b569a"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7885), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7886), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("eff2ca02-94e9-4bcd-86a3-84d336acafd7"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7896), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7897), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("122bf5af-4f2c-4f4a-9c6b-d9bbc6bbf34b"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7907), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7907), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("27af37ef-e865-4c0c-84a9-717954cb51f2"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7916), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7917), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("be10f296-aa91-4860-8fba-c5f672ad3170"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7927), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7928), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("c1af72bc-9b87-4ca6-80c6-92759e131645"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7937), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7938), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("f756dc1a-3ff3-4a07-b225-c0dda62fb3cf"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7947), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7948), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("8fcf55dd-366c-4007-9993-051e8ad312fb"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7961), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7962), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("58ca1204-120f-4dd0-9cd6-87789bfba37b"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7973), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("9855ab34-b952-4882-936a-b34ccf8321f0"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7983), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7984), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("666fcfa6-61bc-4668-b6f5-8c69abab2650"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7993), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(7994), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("9feb8ebf-d1d4-4345-a4b7-a222cc9ccebd"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8003), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8003), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8558), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8559), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8613), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8614), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8625), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8625), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("6796a2fd-a3a3-455e-8059-3c3cfdc79fd7"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8988), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8988), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5c1c3b0c-ae12-4e41-b1b8-f40673df2d74"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8994), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8994), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e91e73fb-87b3-4034-bab9-dffdbed3df97"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8998), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b3c9890a-bdf3-428d-b7e9-5e15ea285537"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9005), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9006), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d36e824d-a807-4c45-a8cf-00899c37f74e"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9009), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9010), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1d1e7af4-5e6f-406f-bac8-7b9409a0a89e"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9013), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9014), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b0fd8b2c-a19f-4a07-928c-47c3532bb8ab"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9017), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9017), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0c037620-0c63-48a6-9306-291c14683725"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9019), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9020), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("278ca157-45a8-495b-b178-c00748f37a57"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9023), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9023), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("4b9b7aa9-24b5-4f43-9d3e-ce038d55b85c"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9027), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9027), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("16a67746-0833-42b5-8e41-516982f3fab5"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9029), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9030), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a22891e5-4cd0-4850-89ce-485874b2edd7"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9035), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9036), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c91f5d68-6005-40df-a22f-e5e73457d9ae"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9038), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9038), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("613275d2-3b89-4d11-87c0-3fdfd9f6bf09"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9088), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9089), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3c2048fc-5667-4e40-bfd5-e7dae57825d7"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9092), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9092), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("01a4cb96-de2d-4b6b-a3c1-4c94a103f1ac"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9094), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9095), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a9453b5e-5b82-4b6a-b682-13d6d56bb864"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9097), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9098), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6b8617e8-910c-4bd1-aa45-bd79f558c2ef"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9101), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9102), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fc116aff-6ae7-4c34-9901-dda727cba9dc"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9104), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9105), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("99af0424-0399-4fe9-9e51-3f3c5a58781c"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9110), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9111), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8ebaafd5-b578-4c6d-bec6-025c46106356"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9113), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9114), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("10a19936-8698-41e9-bfed-8ca04cbdc773"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9116), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9116), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("545633f9-93ca-4ac9-ba61-599d46bafe40"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9121), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9122), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6ffaec8c-8391-44ec-a3b6-73d4664f7083"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9124), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9125), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fdebb9ed-6052-457c-a1e4-220072e148a6"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9127), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9127), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0ace071f-7e15-4032-b92a-fc8914606bc1"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9130), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a2124fbb-cf12-4a4c-8d21-7f3a5ab302f1"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9135), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9136), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b47756fc-574b-49d1-81eb-755f591cf4fc"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9138), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9138), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("32412227-a8aa-4c4d-b7f7-2cdcfeff994d"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9140), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9141), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("90e7a08a-db68-42a4-81e2-c4ada5df1a66"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9143), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9144), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6071e65b-61c9-43ce-bafb-d0fc47ad2f48"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9146), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9147), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("742294b8-41c4-442e-ac28-9f510d0e582f"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9149), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9149), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f211b1af-d96b-4ee4-ab37-c541dd3fa0f0"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9152), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9153), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5d4251e8-b5b9-4fec-a578-5a4d407424a2"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9155), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9156), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("47c38045-9da1-4ba5-a6e6-f4782a7bce80"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9161), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9161), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c919b632-5727-42ba-922d-157bff2c7a4f"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9163), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9164), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("81df6fac-326c-43de-9ea5-1d0b92549930"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9166), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9167), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a4f14cc2-d0ba-4653-afba-4077f263cbf5"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9169), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9170), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("52ed5d74-254f-474c-b008-e25705d7bd11"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9172), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9172), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3f102513-2812-4ea5-95cf-062e607960ee"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9175), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("79a780fd-1a0a-4775-bd6a-589e0c461b48"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9177), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9178), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("044868a5-4d20-4cc2-862c-f7536b4e1730"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9182), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9182), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("8e02c1ef-c1fd-4fed-a3f0-9a46473f933b"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9187), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9188), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("98247a86-75de-46d8-8566-9595edc7d81c"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9190), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9191), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("77a2cbcf-04e5-4992-bb77-e3f973a8403c"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9193), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9193), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("347bd4b6-dcf2-4f21-bb5f-661d2fc46784"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9195), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9196), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ae875bdf-3b6b-42b7-aee4-606fc1e60530"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9198), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9199), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ad0386d6-dee7-4ead-a171-c0e1f82117bd"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9201), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9201), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b19eac60-555b-49be-b9ff-7f3831e9666f"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9204), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9204), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("df31326a-c224-4c84-9d8a-3670f901d05f"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9206), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9207), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("02795a1e-bc8a-46e3-8175-0877806e2ddd"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9213), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("aa9d9339-63f5-41e0-8bc5-269997795169"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9215), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9215), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8d988de4-7167-4741-a09f-437fc8c98609"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9290), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f7183a30-df22-490d-80aa-5b9ca6eb8a37"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9293), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9294), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b6f6faa0-ff7c-4e07-ba37-0bc726e0ffbb"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9296), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9296), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("23ad01e6-172e-4f71-b2ea-f6792d39fef2"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9299), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9299), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ca5021d8-cb51-427e-bea3-5130772c1e55"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9301), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9302), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9a8b7718-fa24-4634-b03b-0c5045962a84"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9304), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9305), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d7cc60bd-0f00-4847-99c2-4217351bf602"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9310), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a98a705f-3a68-4a57-9831-969a1aaa7b12"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9313), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9313), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ff84bf13-ef8c-4e06-a1ec-8a8b795655b0"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9315), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9316), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c0cb29e3-8f38-41d7-bf00-6923ee2187eb"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9318), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9319), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("293793ef-79bf-46f0-b3ce-36b2c42702c3"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9321), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8bf27669-358b-4f0f-827c-0c4c75c73b24"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9323), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9324), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1e01bb2e-f61d-4e8b-89da-4bbf1dca51a3"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9327), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9327), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("74372581-b908-4dbe-97ef-8fe4c35f85c9"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9330), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9330), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3c7ef184-65bc-4f44-b2ea-2e313408207b"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9335), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9335), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4b0282c4-a3f1-4c28-ab2a-552ab598a1b7"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9338), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9338), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("051e7a72-fba5-4a19-bb78-1b091cc80568"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9342), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9342), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7b9ef752-7b60-47de-97a8-f45587cf6e22"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9344), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9345), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("8a9c664f-a1e4-4e8c-b648-911e66b2b56e"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9347), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9348), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d59df903-4f78-4a10-a72e-395b0c36743c"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9350), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9351), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c81ce76b-af82-4cc6-b5ba-4137af5b8e68"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9353), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9353), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6e7da293-c8c9-4171-8ab3-58a9c914ee41"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9357), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9358), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cb9964aa-c855-4b0c-9e2b-bbfaad55057d"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9362), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9445), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("84d68bbe-fa1f-41ac-b41e-cc2e5c7dc6df"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9450), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9451), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cfe9b5bb-2e42-41f8-bd37-ef1377f9b78d"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9453), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9454), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1b097c37-a3c6-4d1c-9464-6a2ef024f3d8"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9456), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9457), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("faa79b08-5456-4c30-bd14-37f5294c948d"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9460), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9461), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("0ba7bdea-d323-438c-81f7-e3e23610e4e8"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9463), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9463), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("4a98c82e-1f5b-43bd-a9a1-1e9c9195658d"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9466), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9466), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("12bcb050-55b4-485b-8689-e6dcb332b63e"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9469), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9470), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("d7ff6d2f-a552-43e0-b489-378ace159ade"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9476), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9477), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("0bb11531-6693-4107-9d67-254b3354fae0"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("775b3b1a-0e9e-48ae-aed1-1c77bb41cfd3"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9118), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9119), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 10, new Guid("1e776a16-49b9-43d7-a754-3f1132b52e9e"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8201), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8202), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("7f920781-4408-4334-ab7e-dcae77e40e34"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8217), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8217), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("85b60795-830a-490c-b19b-041e129e29ab"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8229), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8229), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "name", "slot", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("bf822f2c-7a0d-4ee9-96bf-942a0aa63785"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9623), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViRide", 2, 0, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9624), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("fc84c6da-8f47-47d7-a798-36e34c390f4f"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9639), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-4", 4, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9639), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("17d73b5c-a1a1-43a0-8279-8dd744a3804d"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-7", 7, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9651), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8473), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8473), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8482), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8489), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8490), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8497), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8498), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8505), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8506), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8514), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8515), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Banner 1", new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9568), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9569), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "Banner 2", new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9573), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9574), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "Banner 3", new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9575), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9576), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "Banner 4", new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9577), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9578), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9658), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9659), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9663), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9663), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9665), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9666), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8813), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8813), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8834), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8835), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8855), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8856), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8535), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8536), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8549), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8638), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8638), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("5fc76237-4b71-4944-b786-2755b3cf132a"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8026), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1, 1, "Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8026), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("d9afafa9-d4c0-4ff7-a238-aecc9a590919"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8042), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 2, 1, "Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8043), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("6fbdad33-0f0c-4c05-9e9e-44a966890e77"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8108), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8110), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("94b73cb8-2418-4292-b788-24a9f0b99382"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8124), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 4, 1, "Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8125), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("b509d1c7-39c5-4974-9a31-175aaa1f5e8d"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8137), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 5, 1, "Loi Quach", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8138), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("a053cd5c-e99b-47a0-bb30-c922234520f4"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8150), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 6, 1, "Dat Do", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8150), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("56de0ae8-51c9-4121-8d95-0064b8480ceb"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8165), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 7, 1, "Khoa Nguyen", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8166), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("aa87560a-4f35-4a98-8c2b-cdbdf2addbde"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8177), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 8, 1, "Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8178), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("c154cf68-f6b5-44dc-bda5-804b83efd865"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8188), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 13, 1, "Admin Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8189), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8245), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8246), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8256), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8265), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8266), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8294), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8294), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8303), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8360), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8361), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8370), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8371), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8379), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8386), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8387), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8396), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8404), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8412), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8413), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8420), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8421), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8429), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8430), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8438), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8439), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8446), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8447), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8454), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8455), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8464), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8464), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9687), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 0.12, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9688), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9743), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 0.10000000000000001, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9744), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9752), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 0.14999999999999999, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9753), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9760), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 0.10000000000000001, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9761), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 0.12, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9769), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9778), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 0.10000000000000001, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9779), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9787), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 0.14999999999999999, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9788), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9795), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 0.10000000000000001, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9795), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9802), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 0.12, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9803), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9811), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 0.10000000000000001, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9811), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9819), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 0.14999999999999999, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9819), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9826), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 0.10000000000000001, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9827), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8655), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8656), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8786), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8787), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8880), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8906), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8929), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8930), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8946), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8947), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(8963), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, new Guid("aa01c1c6-0e0b-4694-8c48-c32ef80be142"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9858), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9860), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("3a9cb008-2b81-4a7f-8274-2fada9c748e0"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9865), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9866), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("2f7dba00-5086-44ef-b91f-ad7db4dac24c"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9868), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9869), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("b5489e86-6c37-4f37-93e1-f759d0619bb5"), new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 10, 9, 22, 30, 43, 378, DateTimeKind.Unspecified).AddTicks(9871), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
                });

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
                name: "IX_affiliate_accounts_user_id_type",
                table: "affiliate_accounts",
                columns: new[] { "user_id", "type" },
                unique: true);

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
                name: "affiliate_accounts");

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
                name: "stations");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "promotions");

            migrationBuilder.DropTable(
                name: "routes");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "vehicle_types");

            migrationBuilder.DropTable(
                name: "files");
        }
    }
}
