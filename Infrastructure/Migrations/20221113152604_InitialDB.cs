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
                name: "affiliate_parties",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    code = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_affiliate_parties", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    content = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.id);
                });

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
                name: "pricings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<Guid>(type: "uuid", nullable: false),
                    lower_bound = table.Column<int>(type: "integer", nullable: true),
                    upper_bound = table.Column<int>(type: "integer", nullable: true),
                    discount = table.Column<double>(type: "double precision", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pricings", x => x.id);
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("a579fbae-a8d9-45b4-a45f-298c47df1ed9")),
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
                name: "settings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    key = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settings", x => x.id);
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
                    status = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
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
                    title = table.Column<string>(type: "text", nullable: false),
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
                    fcm_token = table.Column<string>(type: "text", nullable: true),
                    rating = table.Column<double>(type: "double precision", nullable: true),
                    cancelled_trip_rate = table.Column<double>(type: "double precision", nullable: false),
                    suddenly_cancelled_trips = table.Column<int>(type: "integer", nullable: false),
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
                name: "notifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    data = table.Column<object>(type: "jsonb", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    event_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.id);
                    table.ForeignKey(
                        name: "FK_notifications_events_event_id",
                        column: x => x.event_id,
                        principalTable: "events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_notifications_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 380, DateTimeKind.Unspecified).AddTicks(1025), new TimeSpan(0, 7, 0, 0, 0))),
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
                name: "wallets",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    balance = table.Column<double>(type: "double precision", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wallets", x => x.id);
                    table.ForeignKey(
                        name: "FK_wallets_users_user_id",
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("8d7f8628-14b1-404b-bb77-f1f2b5cb399e")),
                    time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    total_price = table.Column<double>(type: "double precision", nullable: false),
                    discount_price = table.Column<double>(type: "double precision", nullable: false),
                    payment_method = table.Column<int>(type: "integer", nullable: false),
                    option = table.Column<int>(type: "integer", nullable: false),
                    day_of_weeks = table.Column<int[]>(type: "integer[]", nullable: false),
                    is_shared = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    start_route_station_id = table.Column<int>(type: "integer", nullable: false),
                    end_route_station_id = table.Column<int>(type: "integer", nullable: false),
                    duration = table.Column<double>(type: "double precision", nullable: false),
                    distance = table.Column<double>(type: "double precision", nullable: false),
                    start_at = table.Column<DateOnly>(type: "date", nullable: false),
                    end_at = table.Column<DateOnly>(type: "date", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    promotion_id = table.Column<int>(type: "integer", nullable: true),
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
                        name: "FK_bookings_route_stations_end_route_station_id",
                        column: x => x.end_route_station_id,
                        principalTable: "route_stations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookings_route_stations_start_route_station_id",
                        column: x => x.start_route_station_id,
                        principalTable: "route_stations",
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
                name: "fare_timelines",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    start_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    end_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    fare_id = table.Column<int>(type: "integer", nullable: false),
                    extra_fee_per_km = table.Column<double>(type: "double precision", nullable: false),
                    ceiling_extra_price = table.Column<double>(type: "double precision", nullable: false),
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
                name: "affiliate_accounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    token = table.Column<string>(type: "text", nullable: false),
                    extra_data = table.Column<object>(type: "jsonb", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    wallet_id = table.Column<int>(type: "integer", nullable: false),
                    affiliate_party_type_id = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_affiliate_accounts_affiliate_parties_affiliate_party_type_id",
                        column: x => x.affiliate_party_type_id,
                        principalTable: "affiliate_parties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_affiliate_accounts_wallets_wallet_id",
                        column: x => x.wallet_id,
                        principalTable: "wallets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "booking_details",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<Guid>(type: "uuid", nullable: false),
                    rating = table.Column<double>(type: "double precision", nullable: true),
                    feedback = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    discount_price = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0),
                    status = table.Column<int>(type: "integer", nullable: false),
                    booking_id = table.Column<int>(type: "integer", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "wallet_transactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    txn_id = table.Column<string>(type: "text", nullable: false),
                    booking_id = table.Column<int>(type: "integer", nullable: true),
                    type = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    wallet_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wallet_transactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_wallet_transactions_bookings_booking_id",
                        column: x => x.booking_id,
                        principalTable: "bookings",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_wallet_transactions_wallets_wallet_id",
                        column: x => x.wallet_id,
                        principalTable: "wallets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "booking_detail_drivers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<Guid>(type: "uuid", nullable: false),
                    start_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    end_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    cancelled_reason = table.Column<string>(type: "text", nullable: false),
                    trip_status = table.Column<int>(type: "integer", nullable: false),
                    booking_detail_id = table.Column<int>(type: "integer", nullable: false),
                    route_routine_id = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_booking_detail_drivers_route_routines_route_routine_id",
                        column: x => x.route_routine_id,
                        principalTable: "route_routines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "affiliate_parties",
                columns: new[] { "id", "code", "CreatedAt", "CreatedBy", "DeletedAt", "name", "status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new Guid("9aa073b5-33ab-426e-9e1d-9114743d2186"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7499), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7500), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("522c9663-f087-41e5-84c4-1f350d05a103"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7513), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7514), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("0757daec-97ac-406b-a39c-9c5b41e7c38c"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7511), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "events",
                columns: new[] { "id", "content", "status", "title", "type" },
                values: new object[,]
                {
                    { 1, "Your booking has mapped completely.", 1, "Finding driver done.", 0 },
                    { 2, "Now you just wait for finding driver. Don't worry, if not found any driver for you, we will refund.", 1, "Your booking was paid successfully.", 0 },
                    { 3, "Not found any driver for you, so we will refund money for you.", 1, "We don't find any driver for you.", 0 },
                    { 4, "The next trip was cancelled by driver, we tried to find a new one but do not find anyone. Sorry for this. The fee will refund for you.", 1, "Suddenly refund", 0 },
                    { 5, "This is the voucher of November.", 1, "You have a voucher!!.", 0 },
                    { 6, "Your driver is coming to pick you up, get ready please.", 1, "The driver is coming.", 0 },
                    { 7, "Have a nice trip.", 1, "Your trip start.", 0 },
                    { 8, "You have arrived, see you again in a next trip.", 1, "Complete trip", 0 },
                    { 9, "You have new rating and feedback", 1, "New Rating And Feedback", 0 },
                    { 10, "Today, you have a trip to complete. Good luck.", 1, "You have a trip today.", 0 },
                    { 11, "We have refunded for you successfully. Sorry for not serving you in the best way.", 1, "Complete Refund", 0 },
                    { 12, "You have been mapped with new booker at this time.", 1, "You have a new trip.", 0 }
                });

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "path", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("4ce8e94d-d200-4423-88c3-a6080e9d9ce4"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4699), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4729), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("edc664c7-015c-4330-9ec0-53008179961c"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4749), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4750), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("63e65a8d-00cb-471d-9dfb-10f3cdfc030a"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4765), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4765), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("56fac22a-ea96-478c-b9d7-7d345489cbd8"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4776), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4777), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("68bc1f7d-c772-4314-bcf7-cdf484ea2748"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4787), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4788), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("b187e8ea-f5e0-4cc0-9370-0037c1e2eea8"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4802), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4802), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("452c5b52-79fa-4647-b5ac-8c2d459f50d5"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4813), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4814), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("477938a6-55fb-4cf3-8ce4-9072ff2a2a96"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4894), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4896), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("98dd47f7-5807-4414-871e-285799bc4e7e"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4913), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4913), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("3e01b95b-b486-4fb9-afa5-3551db67d62d"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4926), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4927), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("2225943f-8366-40a7-8be5-ea906176e516"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4938), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4938), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("e23072a3-6241-4776-8fb4-9f61339976e7"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4949), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4949), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("134189d1-e5a0-45da-8ae3-8a42c24f7b53"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4970), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(4970), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "pricings",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "discount", "lower_bound", "updated_at", "updated_by", "upper_bound" },
                values: new object[,]
                {
                    { 1, new Guid("0b41df74-ed57-4e38-bad5-61f9e34ba852"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7669), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.0, null, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7671), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 2, new Guid("4025693b-d33e-4c80-97c5-14c1c3c77fc0"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7678), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.029999999999999999, 8, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7679), new TimeSpan(0, 7, 0, 0, 0)), 0, 30 },
                    { 3, new Guid("c35e55b0-14f3-4770-a0a5-423bdb922ae6"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7682), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.050000000000000003, 31, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7683), new TimeSpan(0, 7, 0, 0, 0)), 0, 90 },
                    { 4, new Guid("bc070c14-657c-42aa-8dd9-88a20f6106dc"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.070000000000000007, 91, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7689), new TimeSpan(0, 7, 0, 0, 0)), 0, null }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5063), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5063), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5073), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5074), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5084), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5084), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                table: "settings",
                columns: new[] { "id", "key", "value" },
                values: new object[,]
                {
                    { 1, "AllowedMappingTimeRange", "3" },
                    { 2, "AllowedCancelTripPercent", "0.1" },
                    { 3, "TimeBeforePickingUp", "10" },
                    { 4, "TimeAfterComplete", "3" },
                    { 5, "TradeDiscount", "0.2" },
                    { 6, "DefaultPageSize", "5" },
                    { 7, "TimeRatingAfterComplete", "24" },
                    { 8, "CheckingMappingStatusTime", "8:00 PM" },
                    { 9, "NotifyTripInDayTime", "6:00 AM" },
                    { 10, "AllowedDriverCancelTripTime", "7:45 PM" },
                    { 11, "DiscountPerEachSharingCase", "0.1" }
                });

            migrationBuilder.InsertData(
                table: "stations",
                columns: new[] { "id", "address", "code", "created_at", "created_by", "deleted_at", "latitude", "longitude", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("241b25fb-6957-4914-8edd-c31f2aee7a24"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5665), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5667), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6b318475-9068-4054-a20c-37dd07404802"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5681), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8a88a596-05b2-4951-aa98-ee4786493bda"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5689), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9ebf654c-c2c6-4b8d-8731-695a6477765a"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5691), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5692), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("733be0fc-5802-443e-9694-c0e38c80cae1"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5694), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5695), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b4d30ae8-8d41-47c0-929a-84495d10a65a"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5699), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5700), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("aeae1c3e-977b-4fc1-a78f-503bb7b58434"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5702), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5703), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("14cb8660-4f85-48cd-aada-4ff15001222b"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5705), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5706), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("cb84b328-9cb9-489e-b4a5-12be05c182d7"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5709), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5709), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("74d4f4ac-1183-4787-b4b0-599784186a0d"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5712), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5713), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7e8e7c77-d415-4236-994f-d48afae4b174"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5719), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5719), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("58270a22-f8c9-4fd1-ae5f-80861815ce91"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5722), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5722), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5034f59d-b033-4345-9dfc-7cbec1db7e86"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5726), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5726), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("d37d764f-34a9-47cd-834d-2a292dbbaf77"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5729), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5730), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5904dd9d-a3f9-4ae9-b871-c6ede6b4ca8e"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5732), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5733), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e499ca94-940a-40c4-910c-2e1eb67344b1"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5736), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5737), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("40d2d3f3-e53d-42c9-a993-08cef264a027"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5740), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5740), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e77312a6-8886-4abe-a386-d2b966537328"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5743), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5744), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1b4c6fcb-bac9-4c78-b499-2e4ab889d137"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5749), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5749), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("483066db-8552-4d1b-937f-1f78208e8f5d"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5753), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5753), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("eeaf50a9-5592-464a-999d-925888613082"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5756), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5756), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4bac758c-b0b5-4aa9-8ddf-639cff3e69a3"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5759), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5759), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a040c05a-603e-4173-b773-4f1b5268b2f9"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5766), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5767), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("07804902-0db5-4da5-bfaf-0d35f50db40a"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5770), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ad033f29-d5e8-48c2-8782-bb5b6d9eb17d"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5772), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5772), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b3103ae0-3977-4763-b9b0-ab53bcabe7e8"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5777), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5778), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d130a0b6-43d4-4f0a-a749-cdf6ea0bea51"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5780), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5781), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("75c92538-c736-4dfe-aafa-f3a298f05710"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5783), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5784), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("93515225-5568-424e-abaa-2f0f3bdc938f"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5786), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5787), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("37176974-a254-4d9b-98d9-cff3c0b300dd"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5789), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5790), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b44a70f9-f960-4412-a694-5145ab0cbd15"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5850), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5851), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9c866a49-0533-4406-ad55-39bf33e9fd2c"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5854), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5855), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("13490dde-c5fe-4439-8c6b-0225d5e247ef"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5859), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5859), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9dc488cb-0da7-4aea-8ad2-0e6f30cdb973"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5865), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5866), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bb0201d9-ffca-4a47-8c48-f99c74d68840"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5868), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5869), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("717f2800-deca-4c45-b5aa-6946655f0df6"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5872), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("66b7fc44-baae-461a-8dbb-f74aa1a028a1"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5874), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5875), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f73de69b-b833-4403-a58b-6597558225ab"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5878), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5878), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4435743d-c2a5-49c2-8249-d27b6949679c"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5881), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5881), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("69a0d07a-753e-45a2-b2c9-c31a884365cd"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5884), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5884), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("01ef163a-c553-4c8a-9ab6-0cc099af7608"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5888), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5888), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("261a0455-a0a1-43f3-9083-2f91ee942635"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5893), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5894), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("2ece55e8-a58f-4739-96bb-4d45668a0ea1"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5896), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5897), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("35a6da4b-1c1e-44ee-a5ad-85e39d5f1aab"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5899), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5900), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("72873db7-3e72-473c-82bd-c3c36925aa8d"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5902), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5903), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("071bf173-9613-4919-a5e5-2c83a5d155b3"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5906), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cf154a7e-50fa-4d3d-b099-cbe9e82519cf"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5909), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5910), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ad43834a-3a56-40a1-b487-0c4b74784770"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5912), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5913), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5899b4c0-b518-47ca-90c4-fab1b7f0274e"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5915), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5916), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("aacc1dba-ab42-4c68-b64b-c8976291bf7d"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5921), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5922), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("749deef3-10b9-4a51-8751-72005eae2ec4"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5924), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5925), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c76cc71a-e8af-44dd-a079-a60517f42296"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5927), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5928), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e5a83052-eb40-41d0-8d65-0af7beb4e5e5"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5930), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5930), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9e3e1769-e004-41d1-850b-539f7703230b"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5933), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5933), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c33e46be-b8b1-4c75-91b2-05e888ebcae0"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5936), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5936), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b7580571-eb24-452b-b12c-a15ee9746900"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5939), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5939), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("93713e2e-f40a-4ba8-a11f-fef9093df177"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5942), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0ea68187-53c8-41fb-b9b6-8d9fdcc7935f"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5947), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5948), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("415efb3e-9076-4d8f-854e-feaa4d324d0d"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5950), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5951), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("76629626-2f0f-43ca-822d-2b6ef511ec27"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5954), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("666466ff-f868-40b1-91bc-ccb9be3cf9db"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5956), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5957), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4cffdac8-b851-45ad-a8d2-b9dd1f41d82b"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5960), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("beb3f044-1ced-48c8-bddb-2ac0b782bb46"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5963), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("df1af9d1-f068-4bc3-98fe-c37ad38b2d73"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5965), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5966), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d4467d9e-850a-41f2-b805-16b4a38a266f"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5969), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5969), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cf33e891-2e24-4f9f-97d4-476eb4e82eb9"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5975), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("93da47bd-38dc-4c83-8404-b06203dda5c7"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6023), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6023), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("62389be6-7bf6-432b-b9c2-0f176e914a93"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6026), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6027), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a913ef2e-e4e0-42d7-acbf-b4e66a33d668"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6030), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6030), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("089c75fc-34c6-461f-8468-48d865f2a13a"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6032), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6033), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("62b52f25-eafa-4e15-8778-147ae1bc336e"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6035), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6036), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("13a2f64c-fa6f-4eb3-9cd7-eb871e072b05"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6038), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6039), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("35e2f7c3-79f3-48f3-8a4b-c5780f76a9b1"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6041), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6042), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a694fa30-3386-4dec-a042-9a93857185d7"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6047), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6047), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4ff30ac2-a161-435d-a232-507fe871c450"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6050), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6050), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("31b4380b-58bf-4841-9dc7-939bacc9f14c"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6053), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6053), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("443a9918-a804-4a50-b134-2dd031d88044"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6056), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6056), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("64f47bb1-52c4-4830-b99f-5d80aa649cc5"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6059), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6060), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e6afe54b-898a-4aa3-ba91-581a860b30ec"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6062), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6063), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("40928226-05f1-4ff6-a92c-1e5a514d18b3"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6065), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6066), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("4b2ffcd5-5855-4321-b212-36c24c4cb509"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6068), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6069), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("e5a969f5-1f2e-4a5f-939f-5e9155750d75"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6073), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6074), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("403ea94b-6e0d-4ac0-9921-ec70991f5122"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6076), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6077), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("4a7fa532-66f0-4a2a-9818-59832b24fa9d"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6079), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6080), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2875a26c-0229-4967-8ec0-eaf8c3f6ac1b"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5763), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô E2a-10 Đường, D2b Đ. D1, TP. Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam", new Guid("4e4be76b-088e-4ad5-865d-d82e89e4ce1f"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6082), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6083), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trip_rate", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "rating", "status", "suddenly_cancelled_trips", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 10, 0.0, new Guid("5351d7dc-5aca-4ee6-b034-a88c245e3cc6"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5350), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Than Thanh Duy", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5351), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 0.0, new Guid("025f7926-0aed-4130-afb2-bdfe03ab2a43"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5372), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Nguyen Dang Khoa", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5372), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 0.0, new Guid("9157c63c-5542-465e-aaa3-28e3f14282c1"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5386), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Do Trong Dat", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5386), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 100, 0.0, new Guid("0fc809c7-d761-42b0-8fd9-743f1d87f8f3"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5400), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 100", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5401), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 101, 0.0, new Guid("1d302fa7-4b3f-4ea2-81a3-01bc6a19646e"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5455), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 101", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5456), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 102, 0.0, new Guid("cfffb63a-e37a-4ba8-af28-008d542e730b"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5488), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 102", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5489), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 103, 0.0, new Guid("e40156ea-1cc1-42d8-b48b-b45b63fe19da"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5503), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 103", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5504), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 104, 0.0, new Guid("003714a6-0e09-4536-8058-f62898d93e7b"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 104", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5518), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 105, 0.0, new Guid("34022e49-01c9-42a2-97f2-799ee785a5f7"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5536), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 105", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5536), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 106, 0.0, new Guid("5778cb01-6cee-4e4c-9422-6a42746fb12e"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5552), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 106", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5553), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 107, 0.0, new Guid("b5c9ffc6-71eb-4efa-b955-8af4c337c814"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5567), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 107", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5568), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 108, 0.0, new Guid("79e2f96f-e9b4-46cb-823d-871c3df1aab9"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5582), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 108", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5582), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 109, 0.0, new Guid("7a0c233e-b9ea-4f4d-9482-90d4145df18f"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5653), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 109", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5654), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 110, 0.0, new Guid("aa3f12e9-22e5-47df-b074-2ef7a6a87f3c"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5670), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 110", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5671), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 111, 0.0, new Guid("08005510-ad01-4a03-9425-c8e42f9e213a"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5685), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 111", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5686), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 112, 0.0, new Guid("64176f17-a68a-49b4-861d-3fe72dc0688e"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5699), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 112", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5699), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 113, 0.0, new Guid("23309cc6-e957-4aae-a1c3-332c40f1de70"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5716), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 113", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5716), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 114, 0.0, new Guid("805fa79c-a941-4d86-bf7f-9756a23a7912"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5730), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 114", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5730), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 115, 0.0, new Guid("edbffd26-a12b-4715-8b86-bc3015f98787"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5744), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 115", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5744), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 116, 0.0, new Guid("6ceeead4-c291-4c00-95cb-cd2c6655a7c7"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5757), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 116", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5758), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 117, 0.0, new Guid("9dda3a69-577f-4149-af4e-59dcdfb71777"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5774), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 117", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5775), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 118, 0.0, new Guid("3c01c2a1-2a4a-4702-a54e-a1c8286b0abf"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5788), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 118", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5789), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 119, 0.0, new Guid("e8664f3a-58af-4fa2-9a36-edc8b81ccb10"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5802), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 119", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5803), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 120, 0.0, new Guid("c52fa4e9-848b-4546-8d6b-a80123afde90"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5816), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 120", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5817), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 121, 0.0, new Guid("8681fa57-c977-4b88-a206-35d43c043c5c"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5885), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 121", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5886), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 122, 0.0, new Guid("a8a361de-352f-49ae-962e-047f92a29ede"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5901), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 122", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5901), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 123, 0.0, new Guid("9dd35ec7-6931-4ba3-9e4a-9d19d2d24d92"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5915), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 123", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5915), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 124, 0.0, new Guid("09fc2627-0e05-48cd-8b49-5747710d6540"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5929), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 124", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5929), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 125, 0.0, new Guid("55a12e25-6d15-4ff3-a421-a6a2be0b956b"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5945), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 125", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5946), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 126, 0.0, new Guid("d9cc8488-e0fc-4357-ba30-7e62eec24583"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5960), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 126", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5960), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 127, 0.0, new Guid("ac29ac5e-c888-4da4-98a8-95f5bcd49fc5"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 127", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5974), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 128, 0.0, new Guid("c1e698a9-c3a9-489d-8713-071fc6252c12"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5988), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 128", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5988), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 129, 0.0, new Guid("a1d409c6-18ba-415d-9227-6aa61406745f"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6005), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 129", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6006), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 130, 0.0, new Guid("639fe7c8-22d7-4d79-8f0d-1cf8c1a0b99e"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6029), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 130", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6030), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 131, 0.0, new Guid("3d0b7617-c459-4937-b714-4970c90853b2"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6044), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 131", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6044), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 132, 0.0, new Guid("213b205e-cbd2-45c8-8dd0-27bfc111c100"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6108), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 132", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6109), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 133, 0.0, new Guid("c7017791-54a8-498f-bd55-68bfa12824f8"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6130), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 133", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6131), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 134, 0.0, new Guid("88bfac4c-ecfb-47f7-8dc5-3707be9ee1db"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 134", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6145), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 135, 0.0, new Guid("4f0f3baf-4cde-4dc0-bb5f-b47bce4f25c5"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6158), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 135", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6159), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 136, 0.0, new Guid("3f9360db-eba7-400e-bb25-dcea02d91b7a"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6172), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 136", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6173), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 137, 0.0, new Guid("96b94102-2402-4612-9fb8-6fb711e95eac"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6189), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 137", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6190), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 138, 0.0, new Guid("8648e5ae-6bb8-4d9d-8d4f-eba9b79b9549"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6204), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 138", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6205), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 139, 0.0, new Guid("0a7c00e2-7594-401a-aaed-19845ebfb9bf"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 139", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6218), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 140, 0.0, new Guid("113b4329-18df-4749-a2b5-847689fafd10"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6232), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 140", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6233), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 141, 0.0, new Guid("bc13af2a-ddaa-4df4-aa13-970477d0e1f8"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6248), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 141", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6249), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 142, 0.0, new Guid("effb54b1-1890-4f00-b10f-78357bf53347"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6263), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 142", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6264), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 143, 0.0, new Guid("54bf8d13-9214-4d6a-90df-a7ed85c736ba"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6277), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 143", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6278), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 144, 0.0, new Guid("b1f219d4-df35-494f-a7e8-5161569f5304"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6338), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 144", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6339), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 145, 0.0, new Guid("51768159-dd4c-4f4e-8d63-799ea84aeb39"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6360), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 145", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6361), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 146, 0.0, new Guid("277d177a-b41e-4bcf-a776-72d395ee7e40"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6375), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 146", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6376), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 147, 0.0, new Guid("b2b95057-2b94-4107-b867-ef8c62b6b32f"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6390), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 147", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6391), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 148, 0.0, new Guid("e01de6c3-7681-4a6d-b851-b9a631a26983"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 148", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6405), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 149, 0.0, new Guid("de2198fc-7ba2-4fb4-ba18-dbf556e6dd5b"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6421), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 149", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6422), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 150, 0.0, new Guid("db4cc275-5cae-4149-ada1-1cd477416f84"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6435), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 150", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6436), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 151, 0.0, new Guid("076f815b-9966-4c18-be97-8f99a58ec507"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6449), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 151", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6450), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 152, 0.0, new Guid("4764debb-8719-423c-8015-187e408da31b"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6464), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 152", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6464), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 153, 0.0, new Guid("bb48bbb0-894a-4cf8-b3a5-a255430d190c"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6482), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 153", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6483), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 154, 0.0, new Guid("23c1c352-d97e-4676-9754-821e4e25eebe"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6544), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 154", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6544), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 155, 0.0, new Guid("351644c9-e4cf-4f2f-86c2-0c27c527a9f6"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6562), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 155", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6563), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 156, 0.0, new Guid("6b118bdc-422a-4c86-8ec9-733b4bae7fbb"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6577), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 156", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6577), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 157, 0.0, new Guid("b1b69f50-f173-4b67-a1aa-8a6a1027ebab"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6594), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 157", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6595), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 158, 0.0, new Guid("f575b62b-1bec-41db-9eff-aff7816413cc"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6609), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 158", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6610), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 159, 0.0, new Guid("896de28c-5f90-4a78-90a9-90630e069091"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6623), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 159", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6624), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 160, 0.0, new Guid("f2551c30-4e90-43bf-a63b-6f41d0d82269"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6637), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 160", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6638), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 161, 0.0, new Guid("5eadd2cc-c92c-4524-a563-8ed98574b83a"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6654), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 161", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6655), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 162, 0.0, new Guid("77aabb03-b0bf-4267-95dd-58ca13fd98e9"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6668), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 162", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6669), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 163, 0.0, new Guid("4a6712f9-5990-4123-9d99-d24992a824f3"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6682), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 163", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6683), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 164, 0.0, new Guid("7853e878-c388-4c19-b579-82b9af369b44"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6696), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 164", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6697), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 165, 0.0, new Guid("1422aece-aebc-47eb-895a-eb44bbb0184e"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6713), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 165", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6713), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 166, 0.0, new Guid("6ea933db-aa88-44f5-a7e0-5078fd72801f"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6773), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 166", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6774), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 167, 0.0, new Guid("1f64c092-3f32-4262-bdb7-80f19971ea7e"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6792), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 167", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6792), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 168, 0.0, new Guid("98856636-d9fe-4785-b2e3-93fb971b8e2a"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6807), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 168", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6808), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 169, 0.0, new Guid("1978de77-044b-43a8-9b30-ee5be3b8183e"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6824), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 169", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6824), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 170, 0.0, new Guid("854be048-3143-4f69-98d8-b24aa8354feb"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6839), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 170", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6840), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 171, 0.0, new Guid("52eabdca-f877-42db-8e56-890d0723ab68"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6853), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 171", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6854), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 172, 0.0, new Guid("14f6dd75-a08c-4d20-a08f-25a8e8185216"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6867), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 172", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6868), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 173, 0.0, new Guid("4b03ba9e-9353-4099-8300-34b7c35b3ca6"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6884), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 173", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6885), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 174, 0.0, new Guid("465e92c5-8df4-48b3-aa5d-bf3a2243f056"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6899), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 174", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6900), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 175, 0.0, new Guid("6693ef30-5292-4dfe-8769-20dd848131b3"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6914), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 175", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6915), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 176, 0.0, new Guid("e23b8216-79c5-44ce-acc2-98aeb264e15c"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6928), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 176", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6929), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 177, 0.0, new Guid("eb6dd213-9991-473f-a154-1636d10abb57"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6945), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 177", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(6945), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 178, 0.0, new Guid("805a8bf9-b4b3-4270-9c4b-115f1892cb3e"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7006), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 178", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7007), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 179, 0.0, new Guid("cc16217b-fc3b-4a16-85e3-2995689075d9"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7024), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 179", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7024), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 180, 0.0, new Guid("8fd07d60-d38e-408b-b784-8136db49bb27"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7038), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 180", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7039), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 181, 0.0, new Guid("4d4523a0-fe04-405c-83ac-1b0e1491004d"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7055), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 181", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7056), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 182, 0.0, new Guid("4688a89d-4bd1-4134-81e6-9ff612f9c4ac"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7070), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 182", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7071), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 183, 0.0, new Guid("18126607-0a38-43ca-96f0-be0920f90f16"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7084), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 183", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7085), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 184, 0.0, new Guid("f7d43ed2-afa1-4475-8b96-4aab24410225"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7098), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 184", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7099), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 185, 0.0, new Guid("18744cb0-8ff3-4e52-aeeb-e4d87262c4ef"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7116), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 185", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7116), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 186, 0.0, new Guid("a6e49a48-4df9-4eee-821f-40d6c0e80a12"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7130), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 186", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7130), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 187, 0.0, new Guid("05232e75-18a8-4061-9cf8-fb3ed4c07649"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 187", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7144), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 188, 0.0, new Guid("e1bfbbaf-e364-4c06-82fc-466e6e68502c"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 188", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7158), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 189, 0.0, new Guid("0eafee62-0af0-41cd-8df8-f51054f753fb"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7175), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 189", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7175), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 190, 0.0, new Guid("f3f0ac04-587c-4390-9aff-ecbf1abbdd81"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7252), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 190", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7253), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 191, 0.0, new Guid("a88dba41-c023-4462-ba14-cba8ad82648f"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 191", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7274), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 192, 0.0, new Guid("6a9768af-73e6-4320-b581-67e5b0d9b6bd"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7287), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 192", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7288), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 193, 0.0, new Guid("732dfe53-91ee-46f6-bc10-c801df19830d"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7305), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 193", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7305), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 194, 0.0, new Guid("b50e29a7-758a-4f4b-a4fa-92e519780ef3"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7319), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 194", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7320), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 195, 0.0, new Guid("5f092e1e-9caf-4f49-b6ed-cdde3957cc61"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7333), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 195", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7334), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 196, 0.0, new Guid("fb60498e-c70a-4d71-b36c-1bed2507b15d"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7347), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 196", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7348), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 197, 0.0, new Guid("b9882762-7dc7-4438-8127-9243dfde6e82"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7365), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 197", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7365), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 198, 0.0, new Guid("dc7f2d40-b766-477f-9c9b-82be1e54eb59"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7379), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 198", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7380), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 199, 0.0, new Guid("a7cb8c5b-f612-4cd5-9772-a950dbbebacf"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7394), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 199", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7394), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 400, 0.0, new Guid("80638959-bc86-447a-8221-cccc0c628288"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7409), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 400", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7410), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 401, 0.0, new Guid("9dee27d3-7f4d-4108-9577-6c3291dcae41"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7428), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 401", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7429), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 402, 0.0, new Guid("256609e0-9d07-40cb-8f19-66fa2d630208"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7490), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 402", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7491), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 403, 0.0, new Guid("e9489679-ba15-4c0c-b8d9-327882e8655e"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 403", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7511), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 404, 0.0, new Guid("94fbcff4-334c-4904-82d7-6b996c1a9550"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7526), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 404", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7527), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 405, 0.0, new Guid("019990a2-3011-4d48-8d56-6ccede5fa174"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7543), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 405", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7544), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 406, 0.0, new Guid("cf561efb-d441-40b5-b069-ea01ebb33c55"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7558), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 406", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7559), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 407, 0.0, new Guid("baf127ab-8530-4253-b361-16be121dc877"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 407", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7573), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 408, 0.0, new Guid("75e5aad6-e9ad-483a-ac2e-46ff3097076f"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7586), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 408", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7587), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 409, 0.0, new Guid("ec49ad03-0775-4707-ae2d-082a37140ae7"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7603), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 409", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7604), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 410, 0.0, new Guid("f989dc85-22ea-4851-a491-33da33875094"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7617), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 410", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7618), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 411, 0.0, new Guid("5bbf07ef-0e5a-451b-b8fd-53a6a310cdb6"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7632), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 411", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7633), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 412, 0.0, new Guid("3a77e615-f1a7-4d85-8b30-34e99cbebace"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7646), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 412", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7647), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 413, 0.0, new Guid("55b9dd39-4a86-4284-8b7c-fe5e8b15b9b1"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7663), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 413", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7664), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 414, 0.0, new Guid("edfec660-ad5d-4496-9803-b46fb320763b"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7724), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 414", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7725), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 415, 0.0, new Guid("6298d2b1-9ab7-4ef0-961f-6ef6e27dc86a"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7743), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 415", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7744), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 416, 0.0, new Guid("5f897696-5acc-4b59-90d7-5ebac98eb388"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7758), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 416", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7759), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 417, 0.0, new Guid("0296260e-6560-4e93-9346-77c96fe83512"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7778), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 417", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7779), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 418, 0.0, new Guid("ddc74a4c-0149-4db8-97fc-4c02bd5884af"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7793), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 418", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7794), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 419, 0.0, new Guid("19e43808-5530-47a1-891f-a6081d2f251e"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7808), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 419", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7808), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 420, 0.0, new Guid("bed18755-3c82-47bd-9701-c91ba9d49c8f"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7822), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 420", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7822), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 421, 0.0, new Guid("1b4b1fd7-3342-4333-a107-c82c5c9a9b99"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7839), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 421", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7840), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 422, 0.0, new Guid("a1e3bd01-f09f-4202-83ab-80d7982dda81"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7854), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 422", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7855), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 423, 0.0, new Guid("ec0b0f20-fcfa-4705-b08f-adfae26adbc1"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7917), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 423", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7918), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 424, 0.0, new Guid("011e9f46-454d-4b83-b73d-ff5361db47f6"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7935), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 424", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7935), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 425, 0.0, new Guid("69e5faad-c2c1-4965-9c2d-361949f62f39"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7952), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 425", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7953), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 426, 0.0, new Guid("f807be58-f13c-4a0e-8dbc-c4723e8465f1"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7966), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 426", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7967), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 427, 0.0, new Guid("2848a3f4-291d-4fe8-931b-fd773e7dc12b"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7980), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 427", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7981), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 428, 0.0, new Guid("f581aa65-55fd-49e6-9b65-8cbf252e45b6"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7994), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 428", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(7995), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 429, 0.0, new Guid("89444aac-44af-4624-91cd-8f069aa9c297"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8011), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 429", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8012), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 430, 0.0, new Guid("78685a4c-2ffe-4789-ae06-1e0a80d5d053"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 430", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8026), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 431, 0.0, new Guid("1753f6af-8275-4d83-a45f-892b54749a3c"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8039), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 431", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8040), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 432, 0.0, new Guid("19e6adee-eca4-4eea-bec6-5c3001667ec8"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8053), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 432", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8054), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 433, 0.0, new Guid("a5d97678-f6ab-453b-ab04-55664ce1f779"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8070), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 433", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8071), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 434, 0.0, new Guid("9eb56dc6-c859-455a-89f0-bddd42067f05"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8085), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 434", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8086), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 435, 0.0, new Guid("7e3704b4-b01f-430e-9c60-bdeab7bd47b8"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8146), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 435", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8146), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 436, 0.0, new Guid("b32f9904-24d1-4ede-bc1f-ad9286c919a6"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8165), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 436", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8166), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 437, 0.0, new Guid("5743f474-3f3b-46f3-9352-37640a66ff8a"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8183), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 437", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8184), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 438, 0.0, new Guid("570a31d7-25de-403f-8dd8-b7eaeae9f8e4"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8197), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 438", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8198), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 439, 0.0, new Guid("a00ba44c-2d6a-4336-ae7a-a32348f80369"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 439", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8213), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 440, 0.0, new Guid("c051e737-c2b6-4161-aeb1-7232a111ed2b"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 440", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8227), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 441, 0.0, new Guid("cb3bee89-c446-48c7-a77f-eb3d756e56d8"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8243), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 441", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8244), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 442, 0.0, new Guid("80951c03-2277-4a44-adf1-06690771ace7"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8259), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 442", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8259), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 443, 0.0, new Guid("2a1f2e91-5f4c-4365-ba05-70e43c7a3006"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 443", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8273), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 444, 0.0, new Guid("7319ee79-499f-4007-808f-d7644f914687"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8286), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 444", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8287), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 445, 0.0, new Guid("30d91c47-71c5-404e-837e-595d7434039c"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 445", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8304), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 446, 0.0, new Guid("dc2aad24-106d-4a1b-a65a-9dabf0badadb"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8318), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 446", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8318), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 447, 0.0, new Guid("fa815185-0902-4828-93bd-2901782d134d"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8445), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 447", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8446), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 448, 0.0, new Guid("106c9f96-270a-4d3f-b919-79e712cf48d5"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8466), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 448", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8467), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 449, 0.0, new Guid("11851155-dd25-403f-b996-8b5a1938976b"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8484), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 449", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8485), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 450, 0.0, new Guid("761135d2-affc-4e0d-9964-7131f869074e"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8499), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 450", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8499), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 451, 0.0, new Guid("e106c3f1-632b-4df7-9cfa-254f5c957531"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8513), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 451", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8514), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 452, 0.0, new Guid("31efb66a-8002-4a55-9e0a-b3dee1895682"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8527), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 452", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8528), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 453, 0.0, new Guid("eac1a0f6-87bb-4043-a462-59be3b1084f4"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8544), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 453", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8545), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 454, 0.0, new Guid("7cf10c12-7cf5-486b-97af-5b7802dd480b"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8559), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 454", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8559), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 455, 0.0, new Guid("91f964e3-4672-477a-8be3-64ef2a2a8523"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8573), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 455", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8573), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 456, 0.0, new Guid("2cad9a47-98b0-418f-b79c-bd3971eca8d1"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 456", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8588), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 457, 0.0, new Guid("8a1de65e-9bb2-43f8-8189-a909b8870d1b"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8604), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 457", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8605), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 458, 0.0, new Guid("fd362fea-5e04-4577-b2d1-7d13e0d57b7b"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8618), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 458", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8619), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 459, 0.0, new Guid("f3104974-58d2-4837-8247-869fdb266859"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8679), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 459", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8680), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 460, 0.0, new Guid("dea961f0-7690-4107-88ea-68e7bbe2755a"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8699), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 460", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8699), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 461, 0.0, new Guid("6b11d0ab-86bb-467d-b36f-15c1571cb501"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8716), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 461", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8717), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 462, 0.0, new Guid("9818d606-cecd-4aed-bd7d-16924f67f10a"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8731), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 462", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8731), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 463, 0.0, new Guid("1bd5b49b-5474-430e-abcb-5162452a7f14"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8745), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 463", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8746), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 464, 0.0, new Guid("ee4f130d-9b7d-445e-a687-ec175eed8b7a"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8759), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 464", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8760), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 465, 0.0, new Guid("6225258b-d5ac-4507-853c-a5d50d7b8849"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8776), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 465", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8777), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 466, 0.0, new Guid("c9f8c608-5c29-4e04-adbf-3d45d6175d21"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8792), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 466", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8792), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 467, 0.0, new Guid("1aed640f-fb01-4a3e-b8b7-11c8c2ad6cfc"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8806), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 467", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8807), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 468, 0.0, new Guid("0be69040-2711-4f64-8e07-2a07d1e91df1"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8820), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 468", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8821), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 469, 0.0, new Guid("0aca08ca-914a-400e-82c6-5ad182c9e199"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8837), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 469", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8838), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 470, 0.0, new Guid("7dd2805c-7264-4cb0-bd01-eae55d6c2caf"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8852), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 470", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8853), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 471, 0.0, new Guid("86be556d-2b15-41d5-a438-d764008b5d9e"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8912), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 471", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8913), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 472, 0.0, new Guid("3aa513ab-dd6c-40b3-a735-a6ab885ac266"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8930), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 472", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8931), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 473, 0.0, new Guid("186896d6-c2d9-4a99-b30a-22799678470a"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8948), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 473", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8949), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 474, 0.0, new Guid("f0be0a3d-effd-4c28-a6b6-646be95d6288"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8963), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 474", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8964), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 475, 0.0, new Guid("8f419a30-7609-462a-ac9a-283a048ac99d"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8978), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 475", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8979), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 476, 0.0, new Guid("03c0268e-fac3-48cb-bfad-df71bf45ebab"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8992), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 476", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(8993), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 477, 0.0, new Guid("2ba7fe47-dfa0-4891-8fc2-17169211e82a"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9009), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 477", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9010), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 478, 0.0, new Guid("d8d3309c-bb78-4717-ac6c-a3d005dffdec"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 478", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9025), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 479, 0.0, new Guid("7feb29cf-05c5-4f01-86a2-da22b8048668"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9039), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 479", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9040), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 480, 0.0, new Guid("30ad523b-d59d-4f1d-b9b5-4723469b3d88"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9053), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 480", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9054), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 481, 0.0, new Guid("99266905-f208-47e7-b5bf-d5372635e014"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9070), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 481", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9071), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 482, 0.0, new Guid("bd93013b-ff48-4175-97ca-14423cc77459"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9085), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 482", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9086), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 483, 0.0, new Guid("6c7b14b1-04d0-48b2-9246-077fe5cdee85"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9147), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 483", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9147), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 484, 0.0, new Guid("c3c6d817-f4f8-4482-a8a5-d0bee73686b6"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9166), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 484", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9167), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 485, 0.0, new Guid("0426c9cc-ce20-4649-93dc-9692d63a1ae6"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9183), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 485", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9184), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 486, 0.0, new Guid("f50588d8-4cca-434c-9449-2d00d771eaba"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9198), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 486", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9199), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 487, 0.0, new Guid("e507808e-e658-4cdc-b7c1-c79c8e00e655"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9213), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 487", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9214), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 488, 0.0, new Guid("fd60b24d-eea9-4d6c-8f20-05bf2f7e1b3d"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9227), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 488", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9228), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 489, 0.0, new Guid("3395baa1-80fe-4fa1-b1f2-c3a47ab0207c"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9244), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 489", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9245), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 490, 0.0, new Guid("207c6b99-cc43-418b-802e-ab948799bfea"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9259), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 490", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9260), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 491, 0.0, new Guid("1c40ed71-7358-4d23-9456-778c4dedd1c1"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 491", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9274), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 492, 0.0, new Guid("74c95843-4dc2-4533-ad57-8e8d8fd7f78b"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9287), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 492", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9288), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 493, 0.0, new Guid("365e619a-16ba-4521-8425-05c558c50db2"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9304), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 493", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9305), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 494, 0.0, new Guid("94161a50-02f4-4913-b859-7d3950c637d8"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9319), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 494", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9320), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 495, 0.0, new Guid("97fadd03-fee0-4d4e-81b7-54e405fc095d"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9333), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 495", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9334), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 496, 0.0, new Guid("81baa0c4-bac7-4b9e-bcc6-44cfeb4e57ba"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9418), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 496", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9419), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 497, 0.0, new Guid("0ab7f14e-752d-42ed-96a6-6c32708833fe"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9437), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 497", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9438), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 498, 0.0, new Guid("e0d223cf-298c-42a8-a323-be855e4ca83f"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9452), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 498", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9453), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 499, 0.0, new Guid("32ebef57-63bc-4016-bbf7-8518e13791a9"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9466), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 499", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9467), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "name", "slot", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("50f40402-b479-4108-8e5a-cf1eba2e3cf2"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6231), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViRide", 2, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6232), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("ea248310-e415-432e-89b5-7efc8fa32309"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6252), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-4", 4, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6252), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("29b2b433-ef3c-401e-9e9e-a0ba708ec5d6"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6270), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-7", 7, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6271), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9738), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9739), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9748), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9749), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9758), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9759), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9770), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9780), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9780), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9790), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9790), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 100, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9801), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+100", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9801), new TimeSpan(0, 7, 0, 0, 0)), 0, 100, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 101, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9815), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@100", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9816), new TimeSpan(0, 7, 0, 0, 0)), 0, 100 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 102, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9830), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+101", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9831), new TimeSpan(0, 7, 0, 0, 0)), 0, 101, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 103, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9842), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@101", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9842), new TimeSpan(0, 7, 0, 0, 0)), 0, 101 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 104, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9852), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+102", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9853), new TimeSpan(0, 7, 0, 0, 0)), 0, 102, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 105, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9863), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@102", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9864), new TimeSpan(0, 7, 0, 0, 0)), 0, 102 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 106, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9882), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+103", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9883), new TimeSpan(0, 7, 0, 0, 0)), 0, 103, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 107, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9893), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@103", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9893), new TimeSpan(0, 7, 0, 0, 0)), 0, 103 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 108, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9904), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+104", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9904), new TimeSpan(0, 7, 0, 0, 0)), 0, 104, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 109, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9916), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@104", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9917), new TimeSpan(0, 7, 0, 0, 0)), 0, 104 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 110, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9927), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+105", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9928), new TimeSpan(0, 7, 0, 0, 0)), 0, 105, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 111, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9984), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@105", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9985), new TimeSpan(0, 7, 0, 0, 0)), 0, 105 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 112, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+106", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), 0, 106, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 113, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(10), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@106", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(11), new TimeSpan(0, 7, 0, 0, 0)), 0, 106 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 114, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(21), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+107", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(22), new TimeSpan(0, 7, 0, 0, 0)), 0, 107, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 115, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(32), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@107", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(32), new TimeSpan(0, 7, 0, 0, 0)), 0, 107 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 116, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(42), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+108", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(43), new TimeSpan(0, 7, 0, 0, 0)), 0, 108, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 117, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(95), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@108", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(96), new TimeSpan(0, 7, 0, 0, 0)), 0, 108 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 118, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(109), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+109", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(110), new TimeSpan(0, 7, 0, 0, 0)), 0, 109, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 119, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(120), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@109", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(121), new TimeSpan(0, 7, 0, 0, 0)), 0, 109 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 120, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(130), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+110", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(131), new TimeSpan(0, 7, 0, 0, 0)), 0, 110, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 121, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@110", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(141), new TimeSpan(0, 7, 0, 0, 0)), 0, 110 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 122, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(151), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+111", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(151), new TimeSpan(0, 7, 0, 0, 0)), 0, 111, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 123, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(161), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@111", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(162), new TimeSpan(0, 7, 0, 0, 0)), 0, 111 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 124, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(171), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+112", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(172), new TimeSpan(0, 7, 0, 0, 0)), 0, 112, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 125, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(181), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@112", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(182), new TimeSpan(0, 7, 0, 0, 0)), 0, 112 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 126, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(191), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+113", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(192), new TimeSpan(0, 7, 0, 0, 0)), 0, 113, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 127, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(202), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@113", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(203), new TimeSpan(0, 7, 0, 0, 0)), 0, 113 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 128, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+114", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(213), new TimeSpan(0, 7, 0, 0, 0)), 0, 114, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 129, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(223), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@114", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(224), new TimeSpan(0, 7, 0, 0, 0)), 0, 114 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 130, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(233), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+115", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(233), new TimeSpan(0, 7, 0, 0, 0)), 0, 115, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 131, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(243), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@115", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(244), new TimeSpan(0, 7, 0, 0, 0)), 0, 115 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 132, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(253), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+116", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(254), new TimeSpan(0, 7, 0, 0, 0)), 0, 116, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 133, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(263), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@116", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(264), new TimeSpan(0, 7, 0, 0, 0)), 0, 116 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 134, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(326), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+117", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(326), new TimeSpan(0, 7, 0, 0, 0)), 0, 117, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 135, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(337), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@117", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(337), new TimeSpan(0, 7, 0, 0, 0)), 0, 117 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 136, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(346), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+118", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(347), new TimeSpan(0, 7, 0, 0, 0)), 0, 118, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 137, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(357), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@118", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(357), new TimeSpan(0, 7, 0, 0, 0)), 0, 118 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 138, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(367), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+119", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(367), new TimeSpan(0, 7, 0, 0, 0)), 0, 119, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 139, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(377), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@119", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(378), new TimeSpan(0, 7, 0, 0, 0)), 0, 119 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 140, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(387), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+120", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(388), new TimeSpan(0, 7, 0, 0, 0)), 0, 120, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 141, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(399), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@120", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(400), new TimeSpan(0, 7, 0, 0, 0)), 0, 120 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 142, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(410), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+121", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(410), new TimeSpan(0, 7, 0, 0, 0)), 0, 121, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 143, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(420), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@121", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(421), new TimeSpan(0, 7, 0, 0, 0)), 0, 121 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 144, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(430), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+122", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(430), new TimeSpan(0, 7, 0, 0, 0)), 0, 122, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 145, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(440), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@122", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(441), new TimeSpan(0, 7, 0, 0, 0)), 0, 122 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 146, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(450), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+123", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(451), new TimeSpan(0, 7, 0, 0, 0)), 0, 123, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 147, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(461), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@123", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(461), new TimeSpan(0, 7, 0, 0, 0)), 0, 123 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 148, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(471), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+124", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(471), new TimeSpan(0, 7, 0, 0, 0)), 0, 124, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 149, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@124", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(482), new TimeSpan(0, 7, 0, 0, 0)), 0, 124 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 150, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(491), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+125", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(492), new TimeSpan(0, 7, 0, 0, 0)), 0, 125, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 151, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(501), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@125", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(502), new TimeSpan(0, 7, 0, 0, 0)), 0, 125 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 152, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(512), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+126", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(512), new TimeSpan(0, 7, 0, 0, 0)), 0, 126, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 153, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@126", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(573), new TimeSpan(0, 7, 0, 0, 0)), 0, 126 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 154, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(585), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+127", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(585), new TimeSpan(0, 7, 0, 0, 0)), 0, 127, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 155, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(595), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@127", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(596), new TimeSpan(0, 7, 0, 0, 0)), 0, 127 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 156, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(606), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+128", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(606), new TimeSpan(0, 7, 0, 0, 0)), 0, 128, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 157, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(616), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@128", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(617), new TimeSpan(0, 7, 0, 0, 0)), 0, 128 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 158, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(627), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+129", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(628), new TimeSpan(0, 7, 0, 0, 0)), 0, 129, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 159, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(638), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@129", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(639), new TimeSpan(0, 7, 0, 0, 0)), 0, 129 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 160, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(648), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+130", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(649), new TimeSpan(0, 7, 0, 0, 0)), 0, 130, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 161, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(659), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@130", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(660), new TimeSpan(0, 7, 0, 0, 0)), 0, 130 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 162, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(669), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+131", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(670), new TimeSpan(0, 7, 0, 0, 0)), 0, 131, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 163, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@131", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(681), new TimeSpan(0, 7, 0, 0, 0)), 0, 131 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 164, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(690), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+132", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(691), new TimeSpan(0, 7, 0, 0, 0)), 0, 132, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 165, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(701), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@132", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(702), new TimeSpan(0, 7, 0, 0, 0)), 0, 132 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 166, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(711), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+133", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(712), new TimeSpan(0, 7, 0, 0, 0)), 0, 133, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 167, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(721), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@133", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(722), new TimeSpan(0, 7, 0, 0, 0)), 0, 133 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 168, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(732), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+134", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(732), new TimeSpan(0, 7, 0, 0, 0)), 0, 134, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 169, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(742), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@134", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(743), new TimeSpan(0, 7, 0, 0, 0)), 0, 134 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 170, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(752), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+135", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(753), new TimeSpan(0, 7, 0, 0, 0)), 0, 135, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 171, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(763), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@135", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(764), new TimeSpan(0, 7, 0, 0, 0)), 0, 135 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 172, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(773), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+136", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(774), new TimeSpan(0, 7, 0, 0, 0)), 0, 136, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 173, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(783), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@136", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(784), new TimeSpan(0, 7, 0, 0, 0)), 0, 136 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 174, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(794), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+137", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(794), new TimeSpan(0, 7, 0, 0, 0)), 0, 137, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 175, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(849), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@137", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(850), new TimeSpan(0, 7, 0, 0, 0)), 0, 137 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 176, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(864), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+138", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(864), new TimeSpan(0, 7, 0, 0, 0)), 0, 138, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 177, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(874), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@138", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(875), new TimeSpan(0, 7, 0, 0, 0)), 0, 138 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 178, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(885), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+139", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(885), new TimeSpan(0, 7, 0, 0, 0)), 0, 139, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 179, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@139", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(896), new TimeSpan(0, 7, 0, 0, 0)), 0, 139 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 180, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+140", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(906), new TimeSpan(0, 7, 0, 0, 0)), 0, 140, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 181, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(915), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@140", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(916), new TimeSpan(0, 7, 0, 0, 0)), 0, 140 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 182, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(926), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+141", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(926), new TimeSpan(0, 7, 0, 0, 0)), 0, 141, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 183, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(936), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@141", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(937), new TimeSpan(0, 7, 0, 0, 0)), 0, 141 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 184, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(946), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+142", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(947), new TimeSpan(0, 7, 0, 0, 0)), 0, 142, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 185, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(957), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@142", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(958), new TimeSpan(0, 7, 0, 0, 0)), 0, 142 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 186, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+143", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(969), new TimeSpan(0, 7, 0, 0, 0)), 0, 143, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 187, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(979), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@143", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(979), new TimeSpan(0, 7, 0, 0, 0)), 0, 143 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 188, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(989), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+144", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(990), new TimeSpan(0, 7, 0, 0, 0)), 0, 144, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 189, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(999), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@144", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1000), new TimeSpan(0, 7, 0, 0, 0)), 0, 144 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 190, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1009), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+145", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1010), new TimeSpan(0, 7, 0, 0, 0)), 0, 145, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 191, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1020), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@145", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1021), new TimeSpan(0, 7, 0, 0, 0)), 0, 145 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 192, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1030), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+146", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1031), new TimeSpan(0, 7, 0, 0, 0)), 0, 146, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 193, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1040), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@146", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1041), new TimeSpan(0, 7, 0, 0, 0)), 0, 146 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 194, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1050), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+147", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1051), new TimeSpan(0, 7, 0, 0, 0)), 0, 147, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 195, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1061), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@147", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1061), new TimeSpan(0, 7, 0, 0, 0)), 0, 147 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 196, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1071), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+148", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1071), new TimeSpan(0, 7, 0, 0, 0)), 0, 148, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 197, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1127), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@148", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1128), new TimeSpan(0, 7, 0, 0, 0)), 0, 148 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 198, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+149", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1142), new TimeSpan(0, 7, 0, 0, 0)), 0, 149, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 199, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1152), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@149", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1152), new TimeSpan(0, 7, 0, 0, 0)), 0, 149 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 200, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1161), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+150", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1162), new TimeSpan(0, 7, 0, 0, 0)), 0, 150, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 201, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1172), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@150", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1173), new TimeSpan(0, 7, 0, 0, 0)), 0, 150 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 202, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1182), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+151", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1183), new TimeSpan(0, 7, 0, 0, 0)), 0, 151, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 203, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1192), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@151", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1193), new TimeSpan(0, 7, 0, 0, 0)), 0, 151 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 204, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1202), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+152", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1203), new TimeSpan(0, 7, 0, 0, 0)), 0, 152, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 205, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1214), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@152", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1215), new TimeSpan(0, 7, 0, 0, 0)), 0, 152 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 206, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1224), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+153", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1225), new TimeSpan(0, 7, 0, 0, 0)), 0, 153, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 207, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1234), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@153", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1235), new TimeSpan(0, 7, 0, 0, 0)), 0, 153 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 208, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1244), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+154", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1245), new TimeSpan(0, 7, 0, 0, 0)), 0, 154, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 209, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1255), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@154", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1255), new TimeSpan(0, 7, 0, 0, 0)), 0, 154 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 210, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1265), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+155", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1266), new TimeSpan(0, 7, 0, 0, 0)), 0, 155, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 211, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1275), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@155", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1276), new TimeSpan(0, 7, 0, 0, 0)), 0, 155 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 212, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1286), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+156", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1287), new TimeSpan(0, 7, 0, 0, 0)), 0, 156, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 213, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1297), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@156", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1297), new TimeSpan(0, 7, 0, 0, 0)), 0, 156 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 214, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1355), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+157", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1356), new TimeSpan(0, 7, 0, 0, 0)), 0, 157, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 215, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@157", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1368), new TimeSpan(0, 7, 0, 0, 0)), 0, 157 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 216, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+158", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1379), new TimeSpan(0, 7, 0, 0, 0)), 0, 158, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 217, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1389), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@158", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1390), new TimeSpan(0, 7, 0, 0, 0)), 0, 158 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 218, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1399), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+159", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1400), new TimeSpan(0, 7, 0, 0, 0)), 0, 159, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 219, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1410), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@159", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1411), new TimeSpan(0, 7, 0, 0, 0)), 0, 159 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 220, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1421), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+160", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1421), new TimeSpan(0, 7, 0, 0, 0)), 0, 160, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 221, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1431), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@160", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1432), new TimeSpan(0, 7, 0, 0, 0)), 0, 160 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 222, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1442), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+161", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1442), new TimeSpan(0, 7, 0, 0, 0)), 0, 161, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 223, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1452), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@161", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1453), new TimeSpan(0, 7, 0, 0, 0)), 0, 161 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 224, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1462), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+162", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1463), new TimeSpan(0, 7, 0, 0, 0)), 0, 162, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 225, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1473), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@162", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1474), new TimeSpan(0, 7, 0, 0, 0)), 0, 162 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 226, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1483), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+163", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1484), new TimeSpan(0, 7, 0, 0, 0)), 0, 163, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 227, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1494), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@163", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1494), new TimeSpan(0, 7, 0, 0, 0)), 0, 163 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 228, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1504), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+164", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1504), new TimeSpan(0, 7, 0, 0, 0)), 0, 164, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 229, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1514), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@164", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1515), new TimeSpan(0, 7, 0, 0, 0)), 0, 164 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 230, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1524), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+165", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1525), new TimeSpan(0, 7, 0, 0, 0)), 0, 165, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 231, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1535), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@165", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1536), new TimeSpan(0, 7, 0, 0, 0)), 0, 165 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 232, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1546), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+166", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1546), new TimeSpan(0, 7, 0, 0, 0)), 0, 166, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 233, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1556), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@166", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1557), new TimeSpan(0, 7, 0, 0, 0)), 0, 166 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 234, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1566), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+167", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1567), new TimeSpan(0, 7, 0, 0, 0)), 0, 167, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 235, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1576), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@167", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1577), new TimeSpan(0, 7, 0, 0, 0)), 0, 167 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 236, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1649), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+168", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1650), new TimeSpan(0, 7, 0, 0, 0)), 0, 168, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 237, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@168", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1665), new TimeSpan(0, 7, 0, 0, 0)), 0, 168 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 238, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1675), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+169", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1675), new TimeSpan(0, 7, 0, 0, 0)), 0, 169, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 239, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1685), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@169", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1686), new TimeSpan(0, 7, 0, 0, 0)), 0, 169 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 240, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1695), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+170", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1696), new TimeSpan(0, 7, 0, 0, 0)), 0, 170, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 241, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1706), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@170", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1706), new TimeSpan(0, 7, 0, 0, 0)), 0, 170 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 242, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1716), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+171", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1716), new TimeSpan(0, 7, 0, 0, 0)), 0, 171, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 243, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1726), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@171", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1727), new TimeSpan(0, 7, 0, 0, 0)), 0, 171 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 244, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1736), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+172", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1737), new TimeSpan(0, 7, 0, 0, 0)), 0, 172, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 245, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1747), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@172", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1748), new TimeSpan(0, 7, 0, 0, 0)), 0, 172 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 246, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1757), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+173", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1758), new TimeSpan(0, 7, 0, 0, 0)), 0, 173, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 247, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1768), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@173", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1768), new TimeSpan(0, 7, 0, 0, 0)), 0, 173 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 248, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1778), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+174", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1779), new TimeSpan(0, 7, 0, 0, 0)), 0, 174, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 249, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1788), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@174", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1789), new TimeSpan(0, 7, 0, 0, 0)), 0, 174 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 250, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1798), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+175", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1799), new TimeSpan(0, 7, 0, 0, 0)), 0, 175, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 251, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1809), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@175", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1810), new TimeSpan(0, 7, 0, 0, 0)), 0, 175 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 252, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1819), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+176", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1820), new TimeSpan(0, 7, 0, 0, 0)), 0, 176, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 253, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1830), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@176", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1831), new TimeSpan(0, 7, 0, 0, 0)), 0, 176 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 254, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1840), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+177", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1841), new TimeSpan(0, 7, 0, 0, 0)), 0, 177, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 255, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1851), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@177", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1851), new TimeSpan(0, 7, 0, 0, 0)), 0, 177 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 256, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1861), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+178", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1862), new TimeSpan(0, 7, 0, 0, 0)), 0, 178, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 257, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@178", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1872), new TimeSpan(0, 7, 0, 0, 0)), 0, 178 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 258, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1928), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+179", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1928), new TimeSpan(0, 7, 0, 0, 0)), 0, 179, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 259, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1941), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@179", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1942), new TimeSpan(0, 7, 0, 0, 0)), 0, 179 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 260, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1951), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+180", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1952), new TimeSpan(0, 7, 0, 0, 0)), 0, 180, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 261, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@180", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1963), new TimeSpan(0, 7, 0, 0, 0)), 0, 180 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 262, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+181", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1973), new TimeSpan(0, 7, 0, 0, 0)), 0, 181, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 263, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1983), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@181", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1984), new TimeSpan(0, 7, 0, 0, 0)), 0, 181 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 264, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1993), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+182", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(1994), new TimeSpan(0, 7, 0, 0, 0)), 0, 182, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 265, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2004), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@182", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2004), new TimeSpan(0, 7, 0, 0, 0)), 0, 182 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 266, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2014), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+183", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2015), new TimeSpan(0, 7, 0, 0, 0)), 0, 183, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 267, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@183", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2026), new TimeSpan(0, 7, 0, 0, 0)), 0, 183 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 268, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2035), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+184", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2036), new TimeSpan(0, 7, 0, 0, 0)), 0, 184, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 269, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2046), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@184", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2046), new TimeSpan(0, 7, 0, 0, 0)), 0, 184 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 270, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2056), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+185", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2056), new TimeSpan(0, 7, 0, 0, 0)), 0, 185, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 271, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2066), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@185", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2067), new TimeSpan(0, 7, 0, 0, 0)), 0, 185 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 272, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2076), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+186", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2077), new TimeSpan(0, 7, 0, 0, 0)), 0, 186, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 273, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2087), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@186", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2087), new TimeSpan(0, 7, 0, 0, 0)), 0, 186 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 274, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2097), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+187", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2097), new TimeSpan(0, 7, 0, 0, 0)), 0, 187, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 275, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2107), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@187", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2108), new TimeSpan(0, 7, 0, 0, 0)), 0, 187 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 276, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2117), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+188", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2118), new TimeSpan(0, 7, 0, 0, 0)), 0, 188, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 277, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2128), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@188", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2129), new TimeSpan(0, 7, 0, 0, 0)), 0, 188 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 278, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2138), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+189", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2139), new TimeSpan(0, 7, 0, 0, 0)), 0, 189, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 279, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2149), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@189", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2149), new TimeSpan(0, 7, 0, 0, 0)), 0, 189 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 280, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2204), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+190", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2205), new TimeSpan(0, 7, 0, 0, 0)), 0, 190, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 281, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@190", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2219), new TimeSpan(0, 7, 0, 0, 0)), 0, 190 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 282, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+191", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2229), new TimeSpan(0, 7, 0, 0, 0)), 0, 191, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 283, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2239), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@191", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2239), new TimeSpan(0, 7, 0, 0, 0)), 0, 191 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 284, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2249), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+192", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2250), new TimeSpan(0, 7, 0, 0, 0)), 0, 192, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 285, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2259), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@192", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2260), new TimeSpan(0, 7, 0, 0, 0)), 0, 192 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 286, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2269), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+193", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2270), new TimeSpan(0, 7, 0, 0, 0)), 0, 193, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 287, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2280), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@193", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2280), new TimeSpan(0, 7, 0, 0, 0)), 0, 193 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 288, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+194", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2290), new TimeSpan(0, 7, 0, 0, 0)), 0, 194, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 289, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2300), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@194", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2301), new TimeSpan(0, 7, 0, 0, 0)), 0, 194 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 290, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+195", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2310), new TimeSpan(0, 7, 0, 0, 0)), 0, 195, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 291, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2320), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@195", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2321), new TimeSpan(0, 7, 0, 0, 0)), 0, 195 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 292, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2330), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+196", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2331), new TimeSpan(0, 7, 0, 0, 0)), 0, 196, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 293, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2341), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@196", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2341), new TimeSpan(0, 7, 0, 0, 0)), 0, 196 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 294, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2351), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+197", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2351), new TimeSpan(0, 7, 0, 0, 0)), 0, 197, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 295, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@197", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2362), new TimeSpan(0, 7, 0, 0, 0)), 0, 197 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 296, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2372), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+198", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2372), new TimeSpan(0, 7, 0, 0, 0)), 0, 198, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 297, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2382), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@198", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2383), new TimeSpan(0, 7, 0, 0, 0)), 0, 198 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 298, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2392), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+199", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2393), new TimeSpan(0, 7, 0, 0, 0)), 0, 199, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 299, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2403), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@199", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2403), new TimeSpan(0, 7, 0, 0, 0)), 0, 199 },
                    { 400, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2413), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+400", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2414), new TimeSpan(0, 7, 0, 0, 0)), 0, 400 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 401, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2425), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@400", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2426), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 402, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2437), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+401", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2438), new TimeSpan(0, 7, 0, 0, 0)), 0, 401 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 403, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2502), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@401", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2503), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 404, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2515), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+402", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2516), new TimeSpan(0, 7, 0, 0, 0)), 0, 402 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 405, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2525), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@402", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2526), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 406, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2535), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+403", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2536), new TimeSpan(0, 7, 0, 0, 0)), 0, 403 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 407, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2546), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@403", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2547), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 408, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2556), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+404", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2557), new TimeSpan(0, 7, 0, 0, 0)), 0, 404 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 409, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2567), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@404", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2567), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 410, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2577), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+405", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2578), new TimeSpan(0, 7, 0, 0, 0)), 0, 405 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 411, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2588), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@405", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2589), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 412, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2598), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+406", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2599), new TimeSpan(0, 7, 0, 0, 0)), 0, 406 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 413, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2608), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@406", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2609), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 414, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2619), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+407", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2620), new TimeSpan(0, 7, 0, 0, 0)), 0, 407 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 415, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2629), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@407", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2630), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 416, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2639), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+408", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2640), new TimeSpan(0, 7, 0, 0, 0)), 0, 408 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 417, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2650), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@408", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2650), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 418, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2661), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+409", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2661), new TimeSpan(0, 7, 0, 0, 0)), 0, 409 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 419, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2672), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@409", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2672), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 420, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2682), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+410", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2683), new TimeSpan(0, 7, 0, 0, 0)), 0, 410 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 421, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2692), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@410", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2693), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 422, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2703), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+411", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2703), new TimeSpan(0, 7, 0, 0, 0)), 0, 411 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 423, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2713), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@411", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2713), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 424, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2723), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+412", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2724), new TimeSpan(0, 7, 0, 0, 0)), 0, 412 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 425, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2785), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@412", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2786), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 426, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2797), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+413", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2798), new TimeSpan(0, 7, 0, 0, 0)), 0, 413 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 427, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2808), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@413", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2809), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 428, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+414", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2819), new TimeSpan(0, 7, 0, 0, 0)), 0, 414 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 429, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2829), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@414", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2829), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 430, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2839), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+415", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2840), new TimeSpan(0, 7, 0, 0, 0)), 0, 415 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 431, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2850), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@415", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2850), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 432, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2861), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+416", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2861), new TimeSpan(0, 7, 0, 0, 0)), 0, 416 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 433, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2875), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@416", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2876), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 434, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2886), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+417", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2887), new TimeSpan(0, 7, 0, 0, 0)), 0, 417 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 435, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2897), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@417", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2897), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 436, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+418", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2956), new TimeSpan(0, 7, 0, 0, 0)), 0, 418 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 437, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2967), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@418", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2968), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 438, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2978), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+419", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2979), new TimeSpan(0, 7, 0, 0, 0)), 0, 419 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 439, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2989), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@419", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2989), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 440, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(2999), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+420", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3000), new TimeSpan(0, 7, 0, 0, 0)), 0, 420 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 441, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3009), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@420", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3010), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 442, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3020), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+421", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3021), new TimeSpan(0, 7, 0, 0, 0)), 0, 421 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 443, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3030), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@421", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3031), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 444, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3041), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+422", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3042), new TimeSpan(0, 7, 0, 0, 0)), 0, 422 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 445, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3051), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@422", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3052), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 446, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3062), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+423", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3062), new TimeSpan(0, 7, 0, 0, 0)), 0, 423 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 447, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3072), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@423", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3073), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 448, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3083), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+424", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3083), new TimeSpan(0, 7, 0, 0, 0)), 0, 424 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 449, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3093), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@424", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3094), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 450, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3104), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+425", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3105), new TimeSpan(0, 7, 0, 0, 0)), 0, 425 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 451, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3114), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@425", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3115), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 452, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3125), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+426", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3125), new TimeSpan(0, 7, 0, 0, 0)), 0, 426 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 453, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3135), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@426", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3136), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 454, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3146), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+427", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3147), new TimeSpan(0, 7, 0, 0, 0)), 0, 427 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 455, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3156), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@427", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3157), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 456, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+428", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3167), new TimeSpan(0, 7, 0, 0, 0)), 0, 428 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 457, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3177), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@428", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3178), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 458, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3236), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+429", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3237), new TimeSpan(0, 7, 0, 0, 0)), 0, 429 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 459, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3250), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@429", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3251), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 460, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3261), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+430", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3261), new TimeSpan(0, 7, 0, 0, 0)), 0, 430 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 461, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3271), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@430", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3272), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 462, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3281), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+431", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3282), new TimeSpan(0, 7, 0, 0, 0)), 0, 431 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 463, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3291), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@431", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3292), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 464, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+432", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3302), new TimeSpan(0, 7, 0, 0, 0)), 0, 432 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 465, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3312), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@432", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3313), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 466, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3323), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+433", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3323), new TimeSpan(0, 7, 0, 0, 0)), 0, 433 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 467, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3333), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@433", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3334), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 468, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3343), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+434", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3344), new TimeSpan(0, 7, 0, 0, 0)), 0, 434 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 469, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@434", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3355), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 470, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3364), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+435", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3365), new TimeSpan(0, 7, 0, 0, 0)), 0, 435 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 471, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3374), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@435", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3375), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 472, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3385), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+436", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3385), new TimeSpan(0, 7, 0, 0, 0)), 0, 436 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 473, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3395), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@436", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3396), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 474, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3405), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+437", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3406), new TimeSpan(0, 7, 0, 0, 0)), 0, 437 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 475, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3415), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@437", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3416), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 476, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3425), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+438", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3426), new TimeSpan(0, 7, 0, 0, 0)), 0, 438 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 477, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3435), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@438", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3436), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 478, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3445), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+439", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3446), new TimeSpan(0, 7, 0, 0, 0)), 0, 439 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 479, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3455), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@439", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3456), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 480, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3512), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+440", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3513), new TimeSpan(0, 7, 0, 0, 0)), 0, 440 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 481, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3527), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@440", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3528), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 482, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3537), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+441", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3538), new TimeSpan(0, 7, 0, 0, 0)), 0, 441 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 483, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@441", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3549), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 484, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3558), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+442", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3559), new TimeSpan(0, 7, 0, 0, 0)), 0, 442 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 485, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3568), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@442", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3569), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 486, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3579), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+443", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3580), new TimeSpan(0, 7, 0, 0, 0)), 0, 443 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 487, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3589), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@443", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3590), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 488, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3599), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+444", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3600), new TimeSpan(0, 7, 0, 0, 0)), 0, 444 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 489, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3609), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@444", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3610), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 490, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3619), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+445", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3620), new TimeSpan(0, 7, 0, 0, 0)), 0, 445 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 491, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3630), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@445", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3631), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 492, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3640), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+446", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3641), new TimeSpan(0, 7, 0, 0, 0)), 0, 446 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 493, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3650), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@446", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3651), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 494, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3661), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+447", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3662), new TimeSpan(0, 7, 0, 0, 0)), 0, 447 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 495, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3671), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@447", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3672), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 496, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3682), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+448", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3682), new TimeSpan(0, 7, 0, 0, 0)), 0, 448 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 497, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3692), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@448", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3693), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 498, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3703), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+449", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3703), new TimeSpan(0, 7, 0, 0, 0)), 0, 449 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 499, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3713), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@449", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3713), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 500, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3723), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+450", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3724), new TimeSpan(0, 7, 0, 0, 0)), 0, 450 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 501, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3733), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@450", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3734), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 502, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3805), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+451", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3806), new TimeSpan(0, 7, 0, 0, 0)), 0, 451 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 503, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3821), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@451", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3821), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 504, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3831), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+452", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3832), new TimeSpan(0, 7, 0, 0, 0)), 0, 452 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 505, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3842), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@452", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3843), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 506, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3852), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+453", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3853), new TimeSpan(0, 7, 0, 0, 0)), 0, 453 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 507, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3863), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@453", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3863), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 508, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3873), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+454", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3874), new TimeSpan(0, 7, 0, 0, 0)), 0, 454 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 509, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3884), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@454", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3884), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 510, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3894), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+455", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3894), new TimeSpan(0, 7, 0, 0, 0)), 0, 455 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 511, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3904), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@455", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3904), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 512, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3914), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+456", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3915), new TimeSpan(0, 7, 0, 0, 0)), 0, 456 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 513, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3924), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@456", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3925), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 514, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3934), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+457", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3935), new TimeSpan(0, 7, 0, 0, 0)), 0, 457 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 515, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3944), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@457", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3945), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 516, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+458", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3955), new TimeSpan(0, 7, 0, 0, 0)), 0, 458 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 517, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3965), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@458", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3965), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 518, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3975), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+459", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3976), new TimeSpan(0, 7, 0, 0, 0)), 0, 459 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 519, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3985), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@459", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3986), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 520, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3995), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+460", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(3996), new TimeSpan(0, 7, 0, 0, 0)), 0, 460 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 521, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4005), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@460", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4006), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 522, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4016), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+461", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4016), new TimeSpan(0, 7, 0, 0, 0)), 0, 461 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 523, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4026), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@461", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4027), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 524, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4036), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+462", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4037), new TimeSpan(0, 7, 0, 0, 0)), 0, 462 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 525, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4096), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@462", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4097), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 526, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4108), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+463", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4109), new TimeSpan(0, 7, 0, 0, 0)), 0, 463 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 527, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4118), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@463", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4119), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 528, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+464", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4129), new TimeSpan(0, 7, 0, 0, 0)), 0, 464 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 529, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4139), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@464", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4140), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 530, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4149), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+465", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4150), new TimeSpan(0, 7, 0, 0, 0)), 0, 465 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 531, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4160), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@465", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4160), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 532, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+466", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4171), new TimeSpan(0, 7, 0, 0, 0)), 0, 466 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 533, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4180), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@466", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4181), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 534, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4191), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+467", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4191), new TimeSpan(0, 7, 0, 0, 0)), 0, 467 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 535, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4200), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@467", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4201), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 536, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4211), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+468", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4212), new TimeSpan(0, 7, 0, 0, 0)), 0, 468 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 537, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4221), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@468", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4222), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 538, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4232), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+469", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4232), new TimeSpan(0, 7, 0, 0, 0)), 0, 469 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 539, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4241), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@469", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4243), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 540, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4252), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+470", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4253), new TimeSpan(0, 7, 0, 0, 0)), 0, 470 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 541, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4262), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@470", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4263), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 542, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+471", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4274), new TimeSpan(0, 7, 0, 0, 0)), 0, 471 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 543, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4283), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@471", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4284), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 544, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4293), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+472", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4294), new TimeSpan(0, 7, 0, 0, 0)), 0, 472 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 545, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@472", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4304), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 546, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4314), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+473", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4315), new TimeSpan(0, 7, 0, 0, 0)), 0, 473 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 547, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4372), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@473", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4372), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 548, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4384), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+474", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4384), new TimeSpan(0, 7, 0, 0, 0)), 0, 474 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 549, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4394), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@474", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4395), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 550, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+475", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4405), new TimeSpan(0, 7, 0, 0, 0)), 0, 475 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 551, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4414), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@475", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4415), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 552, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4425), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+476", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4425), new TimeSpan(0, 7, 0, 0, 0)), 0, 476 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 553, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4435), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@476", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4436), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 554, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4445), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+477", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4446), new TimeSpan(0, 7, 0, 0, 0)), 0, 477 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 555, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4455), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@477", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4456), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 556, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4465), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+478", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4466), new TimeSpan(0, 7, 0, 0, 0)), 0, 478 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 557, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4476), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@478", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4476), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 558, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4486), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+479", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4487), new TimeSpan(0, 7, 0, 0, 0)), 0, 479 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 559, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4496), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@479", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4497), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 560, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4507), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+480", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4507), new TimeSpan(0, 7, 0, 0, 0)), 0, 480 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 561, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@480", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4518), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 562, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4527), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+481", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4528), new TimeSpan(0, 7, 0, 0, 0)), 0, 481 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 563, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4537), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@481", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4538), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 564, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+482", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4549), new TimeSpan(0, 7, 0, 0, 0)), 0, 482 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 565, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4558), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@482", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4559), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 566, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4569), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+483", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4570), new TimeSpan(0, 7, 0, 0, 0)), 0, 483 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 567, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4579), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@483", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4580), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 568, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4590), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+484", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4590), new TimeSpan(0, 7, 0, 0, 0)), 0, 484 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 569, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4646), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@484", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4647), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 570, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4660), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+485", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4660), new TimeSpan(0, 7, 0, 0, 0)), 0, 485 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 571, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4670), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@485", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4671), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 572, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+486", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4681), new TimeSpan(0, 7, 0, 0, 0)), 0, 486 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 573, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4690), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@486", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4691), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 574, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4701), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+487", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4702), new TimeSpan(0, 7, 0, 0, 0)), 0, 487 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 575, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4711), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@487", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4712), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 576, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4722), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+488", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4723), new TimeSpan(0, 7, 0, 0, 0)), 0, 488 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 577, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4732), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@488", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4733), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 578, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4743), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+489", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4744), new TimeSpan(0, 7, 0, 0, 0)), 0, 489 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 579, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4753), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@489", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4754), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 580, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4763), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+490", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4764), new TimeSpan(0, 7, 0, 0, 0)), 0, 490 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 581, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4773), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@490", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4774), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 582, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4784), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+491", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4785), new TimeSpan(0, 7, 0, 0, 0)), 0, 491 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 583, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4794), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@491", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4795), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 584, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4804), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+492", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4805), new TimeSpan(0, 7, 0, 0, 0)), 0, 492 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 585, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4815), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@492", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4816), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 586, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4825), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+493", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4826), new TimeSpan(0, 7, 0, 0, 0)), 0, 493 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 587, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4835), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@493", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4836), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 588, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4846), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+494", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4847), new TimeSpan(0, 7, 0, 0, 0)), 0, 494 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 589, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4856), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@494", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4857), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 590, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4867), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+495", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4868), new TimeSpan(0, 7, 0, 0, 0)), 0, 495 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 591, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4922), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@495", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4923), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 592, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4936), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+496", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4937), new TimeSpan(0, 7, 0, 0, 0)), 0, 496 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 593, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4947), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@496", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4948), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 594, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4957), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+497", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4958), new TimeSpan(0, 7, 0, 0, 0)), 0, 497 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 595, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4967), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@497", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4969), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 596, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4978), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+498", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4979), new TimeSpan(0, 7, 0, 0, 0)), 0, 498 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 597, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4988), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@498", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4989), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 598, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(4999), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+499", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5000), new TimeSpan(0, 7, 0, 0, 0)), 0, 499 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 599, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5009), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@499", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5010), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, true });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "title", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, "What is Lorem Ipsum?", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6142), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6154), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, "Why do we use it?", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6154), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6156), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, "Where does it come from?", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6157), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6158), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, "Where can I get some?", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6159), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6304), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6383), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6384), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6386), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6387), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5311), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5347), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5348), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5381), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5033), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5034), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5051), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5052), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5095), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5096), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trip_rate", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "rating", "status", "suddenly_cancelled_trips", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 0.0, new Guid("dc192330-83de-4cfa-8f2c-0770c1ee271b"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5060), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, 1, "Quach Dai Loi", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5062), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 0.0, new Guid("a111cc4b-0364-43e2-b3dd-9fc42b365d61"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5094), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, 1, "Do Trong Dat", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5132), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 0.0, new Guid("c2d80e48-7a5c-4dce-a6fd-9068ce4c2741"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5149), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 3, 1, "Nguyen Dang Khoa", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5150), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 0.0, new Guid("505a51f0-7ec3-432c-bf32-b3b5961a6218"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5165), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 4, 1, "Than Thanh Duy", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5165), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 0.0, new Guid("d4d5c72b-42d0-4b0c-be0f-c1102c8259ce"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5179), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 5, 1, "Loi Quach", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5180), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 0.0, new Guid("b0990329-c64f-410e-94ea-1a9b1413366d"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5197), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 6, 1, "Dat Do", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5198), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 0.0, new Guid("7bed5b2f-5969-4896-a9c0-50efd3d75160"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 7, 1, "Khoa Nguyen", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5213), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 0.0, new Guid("5b5df5d3-f714-447f-a4bb-80c889b05ebb"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5230), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 8, 1, "Thanh Duy", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5231), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 0.0, new Guid("7ae0de34-bd87-4759-8978-6c4b2b033540"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5245), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 13, 1, "Admin Quach Dai Loi", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(5246), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 400, new Guid("e63377df-b871-41e2-9780-4c85833517a4"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6787), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.400", "Vehicle 400", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6788), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, 3 },
                    { 401, new Guid("b2149e66-cf2e-4889-92b8-6b65cb981df0"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6800), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.401", "Vehicle 401", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6801), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, 3 },
                    { 402, new Guid("57366c3b-f863-4ea6-ac14-84ca988119c0"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6808), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.402", "Vehicle 402", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6808), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, 3 },
                    { 403, new Guid("03e08118-1f79-43d5-9142-891dab4a80e1"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6812), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.403", "Vehicle 403", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6812), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, 3 },
                    { 404, new Guid("c98e4937-d253-4958-83da-371dd48f1b42"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6816), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.404", "Vehicle 404", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6817), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, 3 },
                    { 405, new Guid("f96009be-1efa-4d8a-8261-0f00c7c3a259"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6820), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.405", "Vehicle 405", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6821), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, 3 },
                    { 406, new Guid("c25a23f8-3a4f-43fa-a509-6209b1632358"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6824), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.406", "Vehicle 406", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6825), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, 3 },
                    { 407, new Guid("1818ea70-8b19-40a5-95a5-b3b74ab508fc"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6828), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.407", "Vehicle 407", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6829), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, 3 },
                    { 408, new Guid("1510965d-8a83-47a2-9415-959ac0af5f90"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6832), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.408", "Vehicle 408", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6833), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, 3 },
                    { 409, new Guid("7805ef54-6cdc-4e96-8846-0c542a45f7b5"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6836), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.409", "Vehicle 409", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6837), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, 3 },
                    { 410, new Guid("6c699d71-6e96-44b6-9bcf-e96140e71daa"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6843), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.410", "Vehicle 410", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6843), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, 3 },
                    { 411, new Guid("5b80e54d-6eac-423f-a2f9-3840bf31384f"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.411", "Vehicle 411", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6847), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, 3 },
                    { 412, new Guid("34911e2e-d304-48a2-aee5-1b9c99d54c87"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6850), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.412", "Vehicle 412", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6851), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, 3 },
                    { 413, new Guid("35410b88-4af0-4556-a6cd-4501040218d6"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6855), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.413", "Vehicle 413", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6855), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, 3 },
                    { 414, new Guid("6e37bd40-2cb1-4ced-aa6a-7a4d338c6c4d"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6858), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.414", "Vehicle 414", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6859), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, 3 },
                    { 415, new Guid("092a3333-e069-4843-8aa0-c4310cb3a8d9"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6862), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.415", "Vehicle 415", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6863), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, 3 },
                    { 416, new Guid("783b046c-53f6-429b-b556-8a6962ebd484"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6916), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.416", "Vehicle 416", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6917), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, 3 },
                    { 417, new Guid("f8a9f382-2bd2-497f-aa1d-9076a6c129d8"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6920), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.417", "Vehicle 417", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6921), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, 3 },
                    { 418, new Guid("4712dfb4-da1a-4ca4-89da-cbe3e53d24df"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6927), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.418", "Vehicle 418", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6927), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, 3 },
                    { 419, new Guid("b4c05df2-cbe2-455b-91fe-660ffcac4d58"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6930), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.419", "Vehicle 419", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6931), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, 3 },
                    { 420, new Guid("313af243-d51d-4600-8183-c0090b147d95"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6934), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.420", "Vehicle 420", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6935), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, 3 },
                    { 421, new Guid("b9b293ff-cea7-4353-9e45-57065fde8e6e"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6938), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.421", "Vehicle 421", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6939), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, 3 },
                    { 422, new Guid("d89efe74-5129-41d9-83f3-5c6243c42829"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.422", "Vehicle 422", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6942), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, 3 },
                    { 423, new Guid("a987416c-8778-46f0-8e17-6c05055c46e0"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6945), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.423", "Vehicle 423", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6946), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, 3 },
                    { 424, new Guid("57245574-2af9-4f22-b47e-136077c137c4"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6949), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.424", "Vehicle 424", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6950), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, 3 },
                    { 425, new Guid("0c8964af-72e8-430e-b56a-0d626228d5c8"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.425", "Vehicle 425", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6954), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, 3 },
                    { 426, new Guid("55ea9660-d37f-4e7f-9213-1c6588a6e893"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6960), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.426", "Vehicle 426", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6961), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, 3 },
                    { 427, new Guid("88bec065-0b3f-413a-94f3-31eaf926aa9d"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6964), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.427", "Vehicle 427", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6965), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, 3 },
                    { 428, new Guid("4f01c735-6d31-49e9-98f6-d379f0cb29c2"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.428", "Vehicle 428", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6968), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, 3 },
                    { 429, new Guid("2d687cfa-f716-40c7-8322-ddcdb4236165"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.429", "Vehicle 429", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6973), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, 3 },
                    { 430, new Guid("c2738f79-1a57-4787-9a54-029ee3f3c0f4"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.430", "Vehicle 430", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6977), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, 3 },
                    { 431, new Guid("eb0e104a-579a-4395-8692-da8d101e0c1f"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6980), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.431", "Vehicle 431", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6981), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, 3 },
                    { 432, new Guid("2cb5563f-9dbc-423b-a9c4-0da54d46348a"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6984), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.432", "Vehicle 432", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6985), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, 3 },
                    { 433, new Guid("509e5f5a-370f-44bf-af18-9f5e5e09826b"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6988), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.433", "Vehicle 433", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6989), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, 3 },
                    { 434, new Guid("a9af3125-2697-4795-9a4f-3c1bf0bb249f"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6995), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.434", "Vehicle 434", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6995), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, 3 },
                    { 435, new Guid("fff24215-8b9b-4da0-9a98-6f0cf84cf261"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.435", "Vehicle 435", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6999), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, 3 },
                    { 436, new Guid("23babc8b-1362-4e0b-8d13-8306f907ad14"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7002), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.436", "Vehicle 436", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7003), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, 3 },
                    { 437, new Guid("c519f5af-0917-46e2-bcf3-2b7680ccdf78"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7006), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.437", "Vehicle 437", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7006), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, 3 },
                    { 438, new Guid("c1547d58-0ea9-43b4-b541-4a36903d7ae2"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7010), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.438", "Vehicle 438", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7010), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, 3 },
                    { 439, new Guid("88641eef-de10-41c9-866d-c48010e5310f"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7013), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.439", "Vehicle 439", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7014), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, 3 },
                    { 440, new Guid("a191b16a-9058-4036-bbfc-2c741d14c064"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7018), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.440", "Vehicle 440", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7018), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, 3 },
                    { 441, new Guid("156d2258-c813-48ba-a7de-8ea6b2bd7f04"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7021), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.441", "Vehicle 441", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7022), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, 3 },
                    { 442, new Guid("f14c3729-2346-482c-a161-0c145b52f20f"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7028), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.442", "Vehicle 442", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7028), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, 3 },
                    { 443, new Guid("c106462d-2bb0-4a9b-ac41-fc691a1890d2"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7032), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.443", "Vehicle 443", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7032), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, 3 },
                    { 444, new Guid("d3de4b40-f0d2-4b23-be77-b9aa0e087b94"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7035), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.444", "Vehicle 444", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7036), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, 3 },
                    { 445, new Guid("03a67405-7b20-49e0-9f1a-38c864177778"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7039), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.445", "Vehicle 445", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7040), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, 3 },
                    { 446, new Guid("6b3bb523-6bee-428c-bacb-2b853f1e338e"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7043), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.446", "Vehicle 446", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7044), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, 3 },
                    { 447, new Guid("768fcc94-7e1c-41f9-b1ba-162cc8382b5f"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7091), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.447", "Vehicle 447", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7092), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, 3 },
                    { 448, new Guid("3cb70f65-8ade-4a65-842d-69af9bfe3195"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7095), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.448", "Vehicle 448", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7096), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, 3 },
                    { 449, new Guid("deeee48a-a1f6-4fdc-9a9f-8bf6fce87134"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7099), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.449", "Vehicle 449", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7100), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, 3 },
                    { 450, new Guid("cc2c5085-abd6-4d4d-8946-a2369aa160c2"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7105), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.450", "Vehicle 450", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7106), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, 3 },
                    { 451, new Guid("a944b838-3a92-4a39-a695-a4b35d9420a8"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7109), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.451", "Vehicle 451", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7110), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, 3 },
                    { 452, new Guid("c0a6591c-1794-48bf-b38b-ed1ed69c9804"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7113), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.452", "Vehicle 452", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7114), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, 3 },
                    { 453, new Guid("94e05346-851b-454a-be5b-639f528d06d8"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7117), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.453", "Vehicle 453", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7117), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, 3 },
                    { 454, new Guid("bd64d821-55cc-446a-92fb-350427707751"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7120), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.454", "Vehicle 454", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7121), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, 3 },
                    { 455, new Guid("df4a8905-6e8a-4e55-aa1e-35d91dd266ee"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7124), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.455", "Vehicle 455", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7125), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, 3 },
                    { 456, new Guid("fb98e352-ec29-46c9-b25d-a2202ab99d6c"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7128), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.456", "Vehicle 456", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7129), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, 3 },
                    { 457, new Guid("49074c33-70d3-40db-8c2f-79ad5cfcb4c4"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7132), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.457", "Vehicle 457", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7133), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, 3 },
                    { 458, new Guid("0c8684db-c8c0-4129-8117-73848a769087"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7138), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.458", "Vehicle 458", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7139), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, 3 },
                    { 459, new Guid("7f616200-49e7-49b3-84b7-a1f059d795d7"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7142), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.459", "Vehicle 459", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7143), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, 3 },
                    { 460, new Guid("c5ad0ce2-3f7b-4c50-b877-106c3ace57e0"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7146), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.460", "Vehicle 460", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7147), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, 3 },
                    { 461, new Guid("fe3c1d9f-2586-4448-a8e2-14355f5e0147"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7151), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.461", "Vehicle 461", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7151), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, 3 },
                    { 462, new Guid("8e3cb747-00e6-424b-bc3c-92b05dacb90f"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7155), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.462", "Vehicle 462", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7155), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, 3 },
                    { 463, new Guid("c849525b-d364-47c1-9155-0a8967ffae55"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7158), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.463", "Vehicle 463", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7159), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, 3 },
                    { 464, new Guid("308a0513-eba0-4124-86b7-0b794f38be97"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7162), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.464", "Vehicle 464", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7163), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, 3 },
                    { 465, new Guid("0d22f50b-5885-453e-b0d2-4700a7e95b5d"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7166), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.465", "Vehicle 465", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7167), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, 3 },
                    { 466, new Guid("e1831a65-cede-4c15-948d-b5ee0220a37f"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7172), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.466", "Vehicle 466", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7173), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, 3 },
                    { 467, new Guid("e6a52053-399b-4d13-aebb-4b88771cfabe"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7176), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.467", "Vehicle 467", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7177), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, 3 },
                    { 468, new Guid("c446b8cd-e4b8-41ea-9b8b-aff51c99f0f3"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7180), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.468", "Vehicle 468", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7180), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, 3 },
                    { 469, new Guid("24b4a3d5-33a7-421f-91fd-a696be348646"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7184), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.469", "Vehicle 469", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7185), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, 3 },
                    { 470, new Guid("e5833a7a-548b-4647-9a43-de31e54628ce"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7188), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.470", "Vehicle 470", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7189), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, 3 },
                    { 471, new Guid("2926414c-3489-4c68-8f03-726251fafef0"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7192), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.471", "Vehicle 471", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7192), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, 3 },
                    { 472, new Guid("21fbd82c-0448-483f-8b5a-c5208657e82d"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7195), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.472", "Vehicle 472", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7196), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, 3 },
                    { 473, new Guid("d0b5c231-8972-4118-a856-c8f4348440e5"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7199), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.473", "Vehicle 473", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7200), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, 3 },
                    { 474, new Guid("797b5d20-bbea-47cc-a80b-2f1a4145079f"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7205), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.474", "Vehicle 474", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7206), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, 3 },
                    { 475, new Guid("0d51073d-ab6a-4b6a-ace2-5daf6e554d86"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7209), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.475", "Vehicle 475", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7210), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, 3 },
                    { 476, new Guid("999fda46-7fb4-4cd5-af24-275cbb973ecc"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7213), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.476", "Vehicle 476", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7214), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, 3 },
                    { 477, new Guid("6447d11d-b5f6-480a-9acd-00d183fd453a"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7264), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.477", "Vehicle 477", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7265), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, 3 },
                    { 478, new Guid("01b76c56-8546-4e11-87a2-932d329d4030"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7268), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.478", "Vehicle 478", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7269), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, 3 },
                    { 479, new Guid("6304da78-be91-4121-b4cc-27e3a1d1400b"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7272), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.479", "Vehicle 479", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7273), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, 3 },
                    { 480, new Guid("5c958f6c-1d84-47ef-8105-149213735c08"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7276), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.480", "Vehicle 480", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7277), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, 3 },
                    { 481, new Guid("2baacc79-4c34-4bb8-95ff-a6979eebbdf0"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7280), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.481", "Vehicle 481", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7280), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, 3 },
                    { 482, new Guid("e7045739-f26d-47e1-9bc7-f661f3200d54"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7286), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.482", "Vehicle 482", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7287), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, 3 },
                    { 483, new Guid("ec55e6ef-e617-40ae-9006-45eda10987dc"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7290), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.483", "Vehicle 483", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7291), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, 3 },
                    { 484, new Guid("f46c920b-d079-4cf6-9ba3-31a865f519bf"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7294), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.484", "Vehicle 484", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7295), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, 3 },
                    { 485, new Guid("0416c732-73a2-4a3d-8201-fe6bdd9aa031"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7298), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.485", "Vehicle 485", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7299), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, 3 },
                    { 486, new Guid("26d49100-3f61-4897-9f04-745f85350d38"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.486", "Vehicle 486", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7303), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, 3 },
                    { 487, new Guid("cf830d6f-36e0-4cae-83a2-86128594c4c7"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7306), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.487", "Vehicle 487", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7307), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, 3 },
                    { 488, new Guid("82ed23f0-5393-403f-815e-7ea1636a29de"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.488", "Vehicle 488", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7311), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, 3 },
                    { 489, new Guid("a200deef-49fd-4acb-909f-aa58a3dfb180"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7314), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.489", "Vehicle 489", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7315), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, 3 },
                    { 490, new Guid("7feb71ae-53d6-4e4e-9ce7-fbc70a7592dd"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7320), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.490", "Vehicle 490", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7321), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, 3 },
                    { 491, new Guid("afee7b93-552f-402e-bd11-6381b684224c"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7324), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.491", "Vehicle 491", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7325), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, 3 },
                    { 492, new Guid("cb2c9d8d-5984-4689-bf74-c17dca5c8160"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7328), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.492", "Vehicle 492", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7328), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, 3 },
                    { 493, new Guid("1136631d-eeed-449b-86d9-bc66264cdc4a"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7332), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.493", "Vehicle 493", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7332), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, 3 },
                    { 494, new Guid("e4849e2b-136e-43c5-8cf1-68e272dc2312"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7336), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.494", "Vehicle 494", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7336), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, 3 },
                    { 495, new Guid("92baaa24-38a5-4f0b-b66c-dab959aa9a9f"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7340), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.495", "Vehicle 495", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7340), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, 3 },
                    { 496, new Guid("aa24ea77-d3e4-43a9-87f5-759dda7840ba"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7344), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.496", "Vehicle 496", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7344), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, 3 },
                    { 497, new Guid("9d2be63a-c0b1-475d-8a08-fc351ea33e9b"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7347), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.497", "Vehicle 497", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7348), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, 3 },
                    { 498, new Guid("59e4d0fc-442b-491f-b81a-edfd3a9b78c1"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.498", "Vehicle 498", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7354), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, 3 },
                    { 499, new Guid("c8f02323-469f-4e00-8d3c-ab4acc4297bd"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7358), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.499", "Vehicle 499", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7358), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, 3 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9494), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9495), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9507), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9508), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9519), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9520), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9529), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9530), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9541), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9551), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9552), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9561), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9562), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9572), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9580), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9581), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9591), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9592), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9601), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9602), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9611), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9611), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9621), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9621), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9631), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9631), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9642), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9642), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9705), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9716), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9717), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9727), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 392, DateTimeKind.Unspecified).AddTicks(9728), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "ceiling_extra_price", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6422), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6422), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6576), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6577), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6588), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6597), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6597), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6606), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6606), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6615), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6616), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6624), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6625), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6633), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6634), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6684), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6685), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6695), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6696), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6705), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6706), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6714), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6715), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6724), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6725), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "notifications",
                columns: new[] { "id", "code", "created_at", "created_by", "data", "deleted_at", "description", "event_id", "status", "type", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, new Guid("68cbbbc1-00a1-421c-a777-b77a37110e6e"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7707), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 2, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7708), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 2, new Guid("bf72674e-7b1e-49db-9dc9-8527446a1300"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7754), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 4, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7755), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 3, new Guid("38bbdae4-fff1-49aa-90c5-93a1dd6dca11"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 7, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7763), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 4, new Guid("18f6db81-b38c-40e7-a7f3-885371e52564"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7766), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 7, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7767), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 5, new Guid("8ee97fdb-363e-4aa7-b872-5c187a303c90"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7773), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 4, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7773), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 6, new Guid("8a5a3de0-a25e-4e15-bfc7-71e0b89cde95"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7778), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 8, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7778), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 7, new Guid("987901d8-e6a8-4515-8e77-d57bf46d067c"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7784), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 7, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7784), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, new Guid("391982f0-6b55-46ce-b106-1c2e16be0c0e"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7788), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 4, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7788), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 9, new Guid("bb06c08c-3c30-4608-a9ae-4ffb91a64a1d"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7794), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 8, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7795), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 10, new Guid("2cb126bd-5e3a-4db2-bd60-9a907cae6d2a"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7798), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 8, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7799), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5122), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5123), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5278), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5279), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5460), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5535), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5536), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5561), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5562), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5583), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5584), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5604), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(5605), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, new Guid("4bf57fd1-1e81-4358-b5db-11fa62434150"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6770), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6771), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("95248e6b-369e-4ac7-947f-c29a3f9cb6f7"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6779), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6779), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("9eb9e796-df9a-4de5-9fe7-abc8719374ba"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6782), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6782), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("63f9404a-c43b-4989-a630-0b32f93987a1"), new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6784), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(6785), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7563), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7565), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7573), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7575), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7575), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7577), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7578), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7579), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7580), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7582), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7583), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7585), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7585), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 22, 26, 3, 393, DateTimeKind.Unspecified).AddTicks(7588), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
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
                name: "IX_affiliate_accounts_affiliate_party_type_id",
                table: "affiliate_accounts",
                column: "affiliate_party_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_accounts_wallet_id_affiliate_party_type_id",
                table: "affiliate_accounts",
                columns: new[] { "wallet_id", "affiliate_party_type_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_parties_code",
                table: "affiliate_parties",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_parties_id",
                table: "affiliate_parties",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_parties_name",
                table: "affiliate_parties",
                column: "name",
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
                name: "IX_booking_detail_drivers_route_routine_id_booking_detail_id",
                table: "booking_detail_drivers",
                columns: new[] { "route_routine_id", "booking_detail_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_booking_details_booking_id",
                table: "booking_details",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "IX_booking_details_message_room_id",
                table: "booking_details",
                column: "message_room_id");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_code",
                table: "bookings",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_bookings_end_route_station_id",
                table: "bookings",
                column: "end_route_station_id");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_promotion_id",
                table: "bookings",
                column: "promotion_id");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_start_route_station_id",
                table: "bookings",
                column: "start_route_station_id");

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
                name: "IX_notifications_code",
                table: "notifications",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_notifications_event_id",
                table: "notifications",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_user_id",
                table: "notifications",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_pricings_code",
                table: "pricings",
                column: "code",
                unique: true);

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
                name: "IX_route_stations_route_id_station_id_index",
                table: "route_stations",
                columns: new[] { "route_id", "station_id", "index" },
                unique: true,
                filter: "deleted_at = null");

            migrationBuilder.CreateIndex(
                name: "IX_route_stations_station_id",
                table: "route_stations",
                column: "station_id");

            migrationBuilder.CreateIndex(
                name: "IX_settings_key",
                table: "settings",
                column: "key",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_wallet_transactions_booking_id",
                table: "wallet_transactions",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "IX_wallet_transactions_code",
                table: "wallet_transactions",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_wallet_transactions_wallet_id",
                table: "wallet_transactions",
                column: "wallet_id");

            migrationBuilder.CreateIndex(
                name: "IX_wallets_user_id",
                table: "wallets",
                column: "user_id",
                unique: true);
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
                name: "notifications");

            migrationBuilder.DropTable(
                name: "pricings");

            migrationBuilder.DropTable(
                name: "promotion_users");

            migrationBuilder.DropTable(
                name: "settings");

            migrationBuilder.DropTable(
                name: "user_rooms");

            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "verified_codes");

            migrationBuilder.DropTable(
                name: "wallet_transactions");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "affiliate_parties");

            migrationBuilder.DropTable(
                name: "booking_details");

            migrationBuilder.DropTable(
                name: "route_routines");

            migrationBuilder.DropTable(
                name: "fares");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "promotion_conditions");

            migrationBuilder.DropTable(
                name: "wallets");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "promotions");

            migrationBuilder.DropTable(
                name: "route_stations");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "vehicle_types");

            migrationBuilder.DropTable(
                name: "routes");

            migrationBuilder.DropTable(
                name: "stations");

            migrationBuilder.DropTable(
                name: "files");
        }
    }
}
