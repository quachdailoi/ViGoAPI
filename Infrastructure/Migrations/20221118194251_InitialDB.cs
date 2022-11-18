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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("e6937ba0-aace-42a6-8de0-80af85350525")),
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
                    value = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: true)
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
                name: "reports",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    data = table.Column<object>(type: "jsonb", nullable: true),
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
                    table.PrimaryKey("PK_reports", x => x.id);
                    table.ForeignKey(
                        name: "FK_reports_users_user_id",
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 36, DateTimeKind.Unspecified).AddTicks(8822), new TimeSpan(0, 7, 0, 0, 0))),
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
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    type = table.Column<int>(type: "integer", nullable: false),
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
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("d34e77b7-fab1-444d-83de-157cbb93085d")),
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
                    complete_without_booker = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
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
                    { 1, new Guid("9a1f8e11-5568-4d2f-bca0-e3222626abaf"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4823), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4824), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("14b7f003-ca2d-4c08-a244-44bb72822608"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4835), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4835), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("e12a8827-bbd8-4604-96cb-6a7c0c16120b"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4829), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4829), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 12, "Be careful with the rate of cancelled trip, you reach 80% of permission of cancelled trip rate.", 1, "Be Cautions!!!", 0 },
                    { 13, "You reach the limit of permission of cannceled trip rate, you were banned now. Contact with our office for handling this problem.", 1, "You were banned!!!", 0 },
                    { 14, "You have new trip at this time, please check your schedule today.", 1, "New trip", 0 },
                    { 15, "You have received your earning for completing trip.", 1, "Trip income", 0 },
                    { 16, "You have received new report that need to processing.", 1, "New report", 0 }
                });

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "path", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("c53f05d7-5236-4960-8d5d-5a25154943ef"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(5932), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(5953), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("6bcbcc8d-2149-4a03-b63a-6627da40ca8a"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6026), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6027), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("0819e107-153e-4643-ac5d-ec72da3cd40e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6047), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6048), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("27a016d7-2b17-4976-8637-72506c802f84"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6104), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6105), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("6ee0b52a-8aa7-43cc-bd2a-39568349c93a"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6119), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6120), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("87a2dadd-8e45-44da-bf1f-17cf576ca51e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6136), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6136), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("2f51181b-8407-4ca3-81e3-c14973e82c94"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6149), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6150), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("f3e18a35-da44-4569-9272-508e1cd0cd19"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6162), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6163), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("618e538f-f8af-4580-95ef-2a1f560a2aa5"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6175), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6176), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("8f01d772-df31-480b-a022-95fedbcd934a"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6190), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6190), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("69f51160-be38-4f0c-a668-f29679849193"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6202), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6203), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("4d17c924-2d68-4d02-84a0-cceefe187140"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6219), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("2645b967-81f5-4a56-818a-3644ca7dce44"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6238), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6239), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "pricings",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "discount", "lower_bound", "updated_at", "updated_by", "upper_bound" },
                values: new object[,]
                {
                    { 1, new Guid("c845d76d-9168-45bd-a9e6-c839fb84dd66"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(5805), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.0, null, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(5809), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 2, new Guid("678037f0-0cc6-4fea-a74a-acd509f14c8f"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(5819), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.029999999999999999, 8, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(5820), new TimeSpan(0, 7, 0, 0, 0)), 0, 30 },
                    { 3, new Guid("e9dc781e-3925-4bea-833f-8be41888ef3c"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(5823), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.050000000000000003, 31, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(5823), new TimeSpan(0, 7, 0, 0, 0)), 0, 90 },
                    { 4, new Guid("42a1035e-7044-4808-ba77-e21746de710c"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(5825), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.070000000000000007, 91, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(5826), new TimeSpan(0, 7, 0, 0, 0)), 0, null }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1726), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1727), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1738), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1739), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1750), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1751), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                columns: new[] { "id", "key", "Type", "value" },
                values: new object[,]
                {
                    { 0, "AllowedMappingTimeRange", null, "3" },
                    { 1, "TimeBeforePickingUp", 1, "10" },
                    { 2, "TimeAfterComplete", 1, "3" },
                    { 3, "TradeDiscount", 4, "0.2" },
                    { 4, "DefaultPageSize", null, "5" },
                    { 5, "TimeRatingAfterComplete", 1, "24" },
                    { 6, "CheckingMappingStatusTime", 1, "20:00:00" },
                    { 7, "NotifyTripInDayTime", 1, "06:00:00" },
                    { 8, "AllowedDriverCancelTripTime", 1, "19:45:00" },
                    { 9, "TotalTripsCalculateRating", 1, "100" },
                    { 11, "MaxCancelledTripRate", 2, "0.1" },
                    { 12, "NotifiedCancelledTripRate", 2, "0.08" },
                    { 13, "TimeSpanRounded", null, "5" },
                    { 14, "TimeSpanBufferToCreateRoutine", null, "5" },
                    { 15, "TimeToCreateTomorrowRoutine", 3, "20:00:00" },
                    { 16, "RadiusNearbyStation", 1, "6000" },
                    { 17, "RadiusToComplete", 1, "100" },
                    { 18, "LastDayNumberForNextMonthRoutine", 3, "7" },
                    { 19, "DiscountPerEachSharingCase", 4, "0.1" },
                    { 20, "ThresholdDiscountPerEachSharingCase", 4, "0.5" },
                    { 21, "AllowedCancelAfterCreateBookingTime", 1, "30" },
                    { 22, "AllowedBookerCancelTripTime", 1, "19:45:00" },
                    { 23, "TradeDisountForBookerCancelTrip", 4, "0.1" }
                });

            migrationBuilder.InsertData(
                table: "stations",
                columns: new[] { "id", "address", "code", "created_at", "created_by", "deleted_at", "latitude", "longitude", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("d0a88a55-ca9e-4d3a-92fc-ee7f8d6f831d"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2308), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2309), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("59e4baa1-63d4-44c3-9189-da70aa12b076"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2315), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2316), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5d0ad9e2-d791-4581-bfee-e1eb41f13c98"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2319), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2319), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("21b8dd40-3741-4520-a01d-06fc6ff204f9"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2322), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2323), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("756dcbc3-57c9-4255-a03e-acbcf9629ac6"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2325), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2326), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("210003ac-c1a9-4010-a8b5-308ecb58834f"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2330), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2330), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9c087587-ce56-46b4-9727-cff51933b60e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2339), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2339), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("28c6d903-edb8-4acc-af09-466997059329"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2341), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2342), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("d2794473-c46b-4a65-be1d-eb9f6500aef3"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2344), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2345), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("a2bf4600-cd55-44ed-9718-d8a62b1d1207"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2349), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2349), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9bc7b392-cd98-46aa-a388-0c2597d6fd01"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2352), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2352), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f7e4cac2-53a8-4839-9d9f-d7954ab8e52a"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2355), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2356), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("892d3bbf-fcf9-4030-a083-579da031648b"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2358), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2359), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("29560a73-2da6-4236-8d2e-e828857c46a5"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2362), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("68fb69e8-9167-4edd-a501-051458a6feca"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2367), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2367), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a12517cf-8960-4892-87e0-d969cea009b4"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2370), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2371), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0dbd9943-e263-4af0-b255-99ab45e86fc0"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2373), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2374), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("add68b00-1ea6-4854-9b00-08b7c7d26543"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2377), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2378), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("38442a67-c193-422e-8f68-ab615f9dd688"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2421), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2422), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("773d71fd-de55-41dd-bad9-eaa792fe0332"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2424), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2425), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f516e425-559a-4e81-aebd-6526cc3194d1"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2427), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2428), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8e56ed36-bc27-4ff9-8bbf-04cc275e44dd"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2431), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2432), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6aadaf20-bbb8-4a5b-a5d4-1099d1d4ae14"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2440), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2440), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("57174fc9-2ca5-4ced-bd1a-215937c3d5d6"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2443), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2443), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9d8c1610-ccbc-4530-a4b8-85cf448be677"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2445), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2446), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("29c33e5b-efd6-4765-9d51-0205d4dfc625"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2448), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2449), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("da720c60-f888-4038-b4a7-72af9955739e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2451), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2452), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("883c9ca0-fd50-43ef-a606-1198b6539398"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2454), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2455), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cd88f527-76bb-4be1-81ce-382e027145ca"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2457), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2458), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("25719887-ae88-4c0b-b5d2-7c4e8041aed9"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2462), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2463), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6a5d4648-e25e-4022-b5fa-b44074f41b07"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2465), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2466), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8bcdf24b-a233-420c-acdb-14127854d7f6"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2469), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a5b98db4-14ae-4599-9534-4e3617e5ccaf"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2472), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2473), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9f0b9aa8-4301-43ac-99b9-d70bef7ae2fc"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2475), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2476), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("02cc0566-43e9-4af7-ae29-3afbf87061e0"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2478), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2479), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("60a1c236-a055-46ac-90cf-01030600dcc5"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2482), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("1eb34239-981b-4627-a1a5-cc208352967c"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2484), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2485), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9f8ad4e5-781c-45c3-b743-ae8bb4560815"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2491), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2491), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("12285b6c-399f-4c5d-bd5e-d3d833bce8ca"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2493), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2494), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("068fe942-deeb-45a3-b589-f32023ebe42a"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2497), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2497), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a652270e-07dd-4da0-bcaf-401e3b801149"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2500), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2500), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c39b5805-6b7f-4d78-bf08-e68dced6d3a5"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2502), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2503), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("b5ef9113-27fc-4c80-84fc-1d91fc6a776f"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2505), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2506), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("80cb0558-16d9-4b40-8c67-f5c6351d45d3"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2508), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2509), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("29d81e26-68ff-4cf5-afd4-0c929464e11f"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2511), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2512), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b1e10f64-33bc-478a-99ca-376851abf4bc"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2518), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("48375e0d-b016-4b24-8a48-dfbb4000d191"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2520), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2521), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1a6752ec-0c47-4658-9c31-145c7750ea4d"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2523), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2524), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a3c619c9-cc60-4059-8147-9c3e8bc182e3"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2527), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2527), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8fe63262-8c95-4d65-8497-9f6d2087387d"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2530), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2530), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("829522aa-2cc3-44ab-8479-7366b3701400"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2532), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2533), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("645a007f-9459-47c4-ae90-5eb14f1d4677"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2535), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2536), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3d5d3ad7-b554-4c42-bc38-210072fe729f"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2538), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2539), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b430c7e1-0c55-41aa-9484-e4b4843a87e7"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2544), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2545), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("215bb97d-687f-486b-99b9-78aa6868355f"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2547), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2547), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5d3f2822-51fa-487a-b595-e4dec8561ac7"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2550), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2550), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("008fc6ba-4ea9-4411-b57f-01c4862ccb9c"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2553), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2553), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ac4a51bb-ed5d-4201-8532-32dee70463a3"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2555), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2556), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("45f87ba5-22b0-4fee-bb01-d9a46e540ba5"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2601), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2602), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("60dc4e1a-459c-45a4-9cae-f3cd4e437823"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2604), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2605), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c9c766fc-0078-4673-ab63-46b755cb040e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2608), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2609), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("77814c30-deb6-410b-b192-95a5fdb81492"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2613), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2614), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("048ceed5-83b4-47f5-ab1f-35d97f47f8f5"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2616), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2617), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2f63c2ac-f150-4113-8c45-961b16169f2d"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2619), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2619), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("81925fbb-3695-44bb-8d33-e6e18dc8089a"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2623), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2624), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7ab4fbd7-51cc-4a43-9093-8a5f11377c44"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2626), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2627), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d6e9af08-6e66-442d-8fad-c954ffa4b20b"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2629), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2630), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8196c2d9-861b-4c31-b51a-527a5746a807"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2632), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2633), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("37823a22-f9d6-47f0-8bfc-5dfa46717ab0"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2635), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("204d7022-6f0b-468f-ac82-2dcab03c79a5"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2640), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2641), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("769ecfaf-33d0-4075-80f0-67ab679ff34f"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2643), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2644), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("57aa85db-dc68-4617-b058-06bbb248df0b"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2646), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2646), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("41ee8a7c-9713-4bc1-b9d6-95251ab821d8"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2648), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2649), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ede78fd2-20a3-4053-8bea-6f1f24cb07f4"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2651), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2652), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("930cc93b-f3e3-4f65-b2f5-9f3ebf87de25"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2654), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2655), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dd6faf22-4755-4a14-b6a5-d36b88b66ccc"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2657), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2658), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("61d6982e-4016-48d0-aa9a-b4197669a44d"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2661), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2661), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("41d615a1-0753-4cc5-9a26-acc576b055e4"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2666), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2666), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("432e058d-89b7-421f-8762-e3135db1ebe9"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2669), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2669), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("00c8400d-5650-439e-b869-6cc2fa487444"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2671), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2672), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("701a6f59-5140-426d-9799-68613d088c25"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2674), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2675), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("75b8e5b0-a606-451e-802f-f2079f2e33c5"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2677), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2678), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("d3a425cb-b2bb-4bab-8d9c-0ae65fd4946e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2680), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("ae5668ab-34e6-49c8-915c-36fb72368f0d"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2683), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2683), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("07eab8e2-4c56-41dd-b914-3d47d09e02dd"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2437), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2438), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô E2a-10 Đường, D2b Đ. D1, TP. Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam", new Guid("e4039c66-cfa2-4674-ba4b-287d6040f7db"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2685), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2686), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trip_rate", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "rating", "status", "suddenly_cancelled_trips", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 10, 0.0, new Guid("7deaa4c7-ebd3-44a4-811f-5a4ff2e14119"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6528), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Than Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6528), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 0.0, new Guid("8e100914-936c-42bf-9a83-6fc35b2e1c1e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6544), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Nguyen Dang Khoa", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6544), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 0.0, new Guid("8a40b6a1-745c-4655-adb2-ac3b9f225529"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6563), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Do Trong Dat", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6564), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 100, 0.0, new Guid("cbbf7f8d-8e0d-4811-bb3a-a7dcea5dd31b"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6579), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 100", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6580), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 101, 0.0, new Guid("b9220d44-dba0-4717-9db6-d10a4684c8e3"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6634), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 101", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6635), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 102, 0.0, new Guid("e078a751-68a6-4777-83a8-d620c596347a"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6667), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 102", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6668), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 103, 0.0, new Guid("31445bb2-ee25-4b5a-b062-f37793ff379f"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 103", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6689), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 104, 0.0, new Guid("72e0c7e7-fa7b-457f-891f-143a1986e020"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6706), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 104", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6708), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 105, 0.0, new Guid("01810dc1-bd13-4a17-8b0a-7568ffa9967b"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6775), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 105", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6776), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 106, 0.0, new Guid("18e018ee-b305-454d-a426-8cf912fb4837"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6793), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 106", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6794), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 107, 0.0, new Guid("4141db01-4696-498c-9994-716ff7a05ec7"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6813), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 107", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6814), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 108, 0.0, new Guid("0617e186-9811-4311-b73b-f7a00333be6a"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6831), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 108", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6832), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 109, 0.0, new Guid("8b67de9c-70be-4dd1-b7d8-52b959079aa5"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6848), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 109", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6849), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 110, 0.0, new Guid("c15d38ef-d190-463f-a126-ce2ef31b31af"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6864), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 110", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6866), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 111, 0.0, new Guid("0cae78f5-1e94-40fd-9c7d-286ce2c1ee4a"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6884), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 111", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6885), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 112, 0.0, new Guid("3c09fac0-bf43-433f-8d71-841631ad8724"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6901), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 112", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6902), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 113, 0.0, new Guid("ee1d2160-9b84-4b39-955d-9aa825e85527"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6918), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 113", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6919), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 114, 0.0, new Guid("96f24267-963a-47bc-9980-7fc96ba93b17"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6935), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 114", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6936), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 115, 0.0, new Guid("2f77e464-3e5b-4995-94b8-2ec166bb575d"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 115", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6955), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 116, 0.0, new Guid("ebf647f6-0e29-464f-8e37-fac2e3dbf0cf"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7012), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 116", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7013), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 117, 0.0, new Guid("05a84b21-35c6-439c-8ba7-03c191ab5bf7"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7040), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 117", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7042), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 118, 0.0, new Guid("92f178b5-4296-492f-9630-bbd103914ce0"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7059), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 118", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7060), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 119, 0.0, new Guid("fd91d308-00ea-42c7-b6e9-ae1a21e9b421"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7080), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 119", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7082), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 120, 0.0, new Guid("d590373a-22b8-4152-9ab0-589b5aba61c9"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7098), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 120", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7099), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 121, 0.0, new Guid("8c04db2d-eabf-4415-b496-6dfed286ccef"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7118), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 121", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7119), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 122, 0.0, new Guid("682d9e98-493b-47cd-b9ec-0d522d4fdb9f"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7135), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 122", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7137), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 123, 0.0, new Guid("6f940b0d-83ea-4fd3-ad32-4d66fda9f653"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7156), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 123", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7157), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 124, 0.0, new Guid("e89ea33c-cf49-44f3-918c-b11cadd93b44"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 124", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7175), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 125, 0.0, new Guid("c01b51c1-87a3-4756-9297-8ad7ffed3d16"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7191), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 125", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7192), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 126, 0.0, new Guid("6b4c3b4f-0398-498a-be98-77238be02ce8"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7255), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 126", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7256), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 127, 0.0, new Guid("1d070029-44be-44c0-b57b-21a6a42758d8"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7279), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 127", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7280), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 128, 0.0, new Guid("82fdcda2-969c-4fd8-a107-a21572b07a78"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7296), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 128", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7297), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 129, 0.0, new Guid("b647e9d4-1239-4a52-82a3-380830064548"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7314), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 129", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7315), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 130, 0.0, new Guid("561b065d-896e-4f52-8860-9f98e833cdb8"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7401), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 130", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7402), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 131, 0.0, new Guid("19f57a69-8eed-4fa3-af82-f268bf367081"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 131", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7424), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 132, 0.0, new Guid("7fd1cf16-55ab-438d-841f-d5fdac064755"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7441), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 132", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7442), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 133, 0.0, new Guid("75ba5902-2110-429f-afbe-017d7a2b4eb3"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 133", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7459), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 134, 0.0, new Guid("9022515e-71c8-40c9-89bd-7ad55000c03a"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7476), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 134", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7477), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 135, 0.0, new Guid("dbda9ae0-a1bc-46f5-adc9-27b52ee06cdf"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7496), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 135", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7497), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 136, 0.0, new Guid("3de13433-8fc3-4a96-ad08-301f1126f82a"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7514), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 136", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7515), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 137, 0.0, new Guid("be7d05d2-30ce-4ebc-b1e9-57bda39b0a66"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7531), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 137", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7532), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 138, 0.0, new Guid("f87132e5-a7dc-4d5f-9dbe-440021d0ac1e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7620), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 138", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7621), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 139, 0.0, new Guid("9c664c8c-03fd-49bc-88b8-fe9c21a4900f"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7646), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 139", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7647), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 140, 0.0, new Guid("007ca246-feef-4a21-92bf-6454fd20c2b7"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7665), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 140", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7666), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 141, 0.0, new Guid("49777a5d-5980-42f7-b938-63ac634fdc98"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7683), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 141", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7684), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 142, 0.0, new Guid("a03b214a-ec16-4278-b36d-54cba1f09dd4"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7701), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 142", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7702), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 143, 0.0, new Guid("eae80c47-afde-447c-bc23-728cf3d95ff9"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7722), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 143", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7723), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 144, 0.0, new Guid("570cf296-0fd6-46dd-b849-4c5f470618d9"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7740), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 144", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7741), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 145, 0.0, new Guid("1989ad34-dd02-4a2b-bc92-d50c16a802dc"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7758), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 145", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7759), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 146, 0.0, new Guid("524303be-69cd-44bb-b3da-d20584d3e1d0"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7776), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 146", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7777), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 147, 0.0, new Guid("7487057d-189c-499e-97da-3f7c27181d4e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7796), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 147", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7798), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 148, 0.0, new Guid("361093f5-ea13-4947-a844-afc79cbf68a9"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7815), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 148", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7816), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 149, 0.0, new Guid("0e2130ed-352d-47ef-90f3-007cbcf0a523"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7875), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 149", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7876), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 150, 0.0, new Guid("a4cc9f2c-6bb6-47cc-b071-21714019bf70"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7896), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 150", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7897), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 151, 0.0, new Guid("d916682f-dadf-4b42-b765-cf3b464d53d5"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7917), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 151", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7918), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 152, 0.0, new Guid("b8af8fab-c84c-4dd2-9fa5-03af929205fb"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7935), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 152", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7936), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 153, 0.0, new Guid("17b75c0a-a4e3-43ac-8200-75fbfc926cda"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7956), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 153", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7957), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 154, 0.0, new Guid("fc9823f3-e1cf-4a09-a950-bc8290d424e9"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 154", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7975), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 155, 0.0, new Guid("79458198-de8a-4cdc-ab85-53f88a5188e7"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7994), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 155", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(7995), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 156, 0.0, new Guid("a2e00a5e-833a-4f81-84f0-be68e326bece"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8012), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 156", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8013), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 157, 0.0, new Guid("8e48420e-18f7-4fe8-b3d9-fe860d8b8e40"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8030), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 157", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8031), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 158, 0.0, new Guid("f0d6ec92-8f63-40fd-9c75-497aa6dfc5a0"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8048), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 158", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8049), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 159, 0.0, new Guid("e8b68699-03fc-46dc-b873-9777d09718e5"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8113), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 159", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8115), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 160, 0.0, new Guid("806a13e3-4ea8-493c-9f94-3d2900b89ca2"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8134), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 160", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8135), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 161, 0.0, new Guid("2e6c4298-0a22-4935-a09e-7870709a0bed"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8152), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 161", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8153), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 162, 0.0, new Guid("c787a037-6900-41d1-91cb-2ec1670ca44a"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 162", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8171), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 163, 0.0, new Guid("e18ef58a-3a7b-4e7d-8232-df8f77883598"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8190), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 163", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8191), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 164, 0.0, new Guid("3f6c06e0-ef2f-448e-91e2-3dc8d311eccb"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8207), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 164", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8209), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 165, 0.0, new Guid("7054b3e4-0e20-4f53-87e9-1def994a0075"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8225), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 165", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8226), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 166, 0.0, new Guid("aa964d41-bfa2-4cf9-ae78-c12787237d17"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8242), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 166", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8244), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 167, 0.0, new Guid("d4e77822-ce2f-407a-9684-5c243f2b7022"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8263), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 167", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8264), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 168, 0.0, new Guid("1409917a-45c1-4d57-a47f-14a577d49f1c"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8282), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 168", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8283), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 169, 0.0, new Guid("0dcf0e82-05eb-46f6-94a6-becab183724d"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8299), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 169", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8300), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 170, 0.0, new Guid("050f49ae-83f7-43b8-bc22-30ca1cb1bb0e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8362), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 170", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8363), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 171, 0.0, new Guid("1f3e7be3-36e4-48ba-bdef-61633b74f05b"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8386), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 171", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8387), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 172, 0.0, new Guid("82cea769-813c-4c4e-b72e-062079c4f87a"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 172", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8405), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 173, 0.0, new Guid("11598a03-dd83-4251-8d86-8dda556a5948"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8422), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 173", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8423), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 174, 0.0, new Guid("469df37a-6078-4628-9be1-34f9f408fe9b"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8439), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 174", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8441), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 175, 0.0, new Guid("4f6f44d9-2254-4d37-b967-8225cc718d0f"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8460), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 175", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8461), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 176, 0.0, new Guid("7bb61ef7-4952-48e7-95e4-6fab789c7f69"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8478), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 176", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8479), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 177, 0.0, new Guid("604f7e14-1788-4086-8d7b-b8906ea1189a"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8495), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 177", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8496), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 178, 0.0, new Guid("fa202084-0b73-4dd3-9d5c-b85a21988b88"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8513), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 178", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8514), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 179, 0.0, new Guid("a9d6a410-ca05-444e-afd7-e2512f944f26"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 179", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8535), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 180, 0.0, new Guid("c789a34e-d739-4877-83a3-f5d128f1d597"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8551), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 180", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8552), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 181, 0.0, new Guid("2a8c6656-1e08-403a-ba7f-dce5de5cbb3e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8568), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 181", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(8570), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 182, 0.0, new Guid("5c1d52b7-3caa-4fd6-8019-3fbb0f1ab926"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9476), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 182", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9481), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 183, 0.0, new Guid("1b166260-4aa0-4394-82ae-c5d27b45314b"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9526), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 183", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9527), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 184, 0.0, new Guid("9b16b871-a51b-4847-b32a-89c063fa50bf"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9545), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 184", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9546), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 185, 0.0, new Guid("52121c51-96e8-476b-9f1e-863c124e23f5"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9562), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 185", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9563), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 186, 0.0, new Guid("f7ed3c0d-cf18-4743-b168-c05c1adda093"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9580), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 186", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9581), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 187, 0.0, new Guid("aab83c98-0dec-4d2f-97cd-d13bb000197e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9599), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 187", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9601), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 188, 0.0, new Guid("38a84f04-1bb9-4989-b631-92c6cd8381a1"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9617), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 188", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9619), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 189, 0.0, new Guid("19dc36f9-e399-4487-9416-591b6413864b"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9636), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 189", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9637), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 190, 0.0, new Guid("7b110e1c-95e4-444c-8a21-8973ac0c7951"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9653), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 190", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9655), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 191, 0.0, new Guid("13b54a02-638e-45ec-b0b1-116bb98a7549"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9674), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 191", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9675), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 192, 0.0, new Guid("7b445a8d-fddc-4814-9e0b-09cb79a3df8c"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9691), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 192", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9692), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 193, 0.0, new Guid("be022e7f-dfa1-4e32-b43f-388ff318d6a1"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9760), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 193", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9761), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 194, 0.0, new Guid("cd7d731b-6297-4d50-8165-062840cd4d0b"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 194", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9782), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 195, 0.0, new Guid("93f0c393-793f-47f3-a2d2-97e2ca565a4d"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9801), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 195", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9803), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 196, 0.0, new Guid("757e96ed-9149-4de3-ab05-7ed3148c80a2"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9819), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 196", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9820), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 197, 0.0, new Guid("0fb003ae-92b4-4c86-be29-12d6b9f6f1d8"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9837), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 197", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9838), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 198, 0.0, new Guid("5d34ce7b-e394-4593-943e-923187728846"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9854), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 198", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9856), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 199, 0.0, new Guid("2e689c7b-2abe-49bb-a03a-d9a715492883"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9875), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 199", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9876), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 400, 0.0, new Guid("30687c28-6c85-48d5-89f2-971e786759cb"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9894), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 400", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9895), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 401, 0.0, new Guid("bee15ce0-a237-4b6a-ab16-c4fd6d2ad5a9"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9914), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 401", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9915), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 402, 0.0, new Guid("9eddb35b-5608-406a-8ca3-d01a19af9a87"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9932), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 402", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9932), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 403, 0.0, new Guid("7ec7a046-d760-46fc-ab94-7d1ca1106e2c"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9952), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 403", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(9953), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 404, 0.0, new Guid("f36ef4ff-016b-4217-964f-69e9633ae41c"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 404", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 405, 0.0, new Guid("7c178746-148e-453c-9269-21db7ef79a4d"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(28), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 405", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(28), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 406, 0.0, new Guid("46567d9b-8861-40ab-aaee-0a55f3a80410"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(45), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 406", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(46), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 407, 0.0, new Guid("d17e340f-4f97-4950-9563-a5f1401f2d4f"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(64), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 407", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(65), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 408, 0.0, new Guid("86dbff6c-f60c-40a8-9df4-a9164b569545"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(82), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 408", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(83), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 409, 0.0, new Guid("d72a6e80-9c30-4963-89ad-ad037acf0910"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(98), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 409", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(99), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 410, 0.0, new Guid("d603b21e-3f5b-4f36-abd2-a790eaf05d72"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(115), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 410", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(116), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 411, 0.0, new Guid("7eb22a67-4493-4f1e-b485-47304f1e947d"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(134), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 411", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(135), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 412, 0.0, new Guid("1e1338df-f62e-42b1-865c-105562e8d404"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(152), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 412", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(153), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 413, 0.0, new Guid("66073e30-a919-4143-a7e6-9144f15ee94e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(169), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 413", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(170), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 414, 0.0, new Guid("f90b665d-b498-436e-9745-44cbe5866470"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(185), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 414", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(186), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 415, 0.0, new Guid("fbc055ea-046f-4dd1-b137-288a8f23a056"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(204), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 415", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(205), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 416, 0.0, new Guid("69ac87ba-e258-4b04-904b-4c9094e7d67e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 416", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(268), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 417, 0.0, new Guid("289f6c7d-b34d-4a8f-9c90-75b9aabeb0cf"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(291), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 417", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(292), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 418, 0.0, new Guid("7cce2fd6-9e5a-44e0-ab9b-2dd52e01e02e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(308), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 418", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(309), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 419, 0.0, new Guid("bf6452c2-de7c-4e00-b4b6-865dea9392ac"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(328), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 419", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(329), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 420, 0.0, new Guid("2fb1a344-b01d-4936-8248-7fe3e7284d2d"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 420", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(346), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 421, 0.0, new Guid("526ee16e-932b-48eb-91c3-06fb38606f42"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(362), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 421", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(363), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 422, 0.0, new Guid("78976f36-e547-4ecc-9be9-04450c50dd84"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(379), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 422", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(379), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 423, 0.0, new Guid("f3b83393-75ae-4363-ac6f-bb77e71d8a0c"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(398), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 423", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(399), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 424, 0.0, new Guid("b1a75572-4da6-47e5-a046-f74ed28997c4"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(478), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 424", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(479), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 425, 0.0, new Guid("2163065b-06dd-4008-b129-db52169d91c7"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(500), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 425", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(501), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 426, 0.0, new Guid("64e7cea3-c10a-41a4-9e98-cceca4db8495"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 426", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(518), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 427, 0.0, new Guid("3afd0ce9-1b22-48ed-a7cd-407c2f200365"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(537), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 427", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(538), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 428, 0.0, new Guid("cd8d1850-b9bc-4019-8cda-f8e662cbd7dc"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(554), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 428", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(555), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 429, 0.0, new Guid("62dd9d6b-2b91-4977-be19-d8f33b1a5e37"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 429", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(572), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 430, 0.0, new Guid("3e485ee2-d948-42c3-ad06-72fcf20077c8"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(588), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 430", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(589), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 431, 0.0, new Guid("c0232d15-ddd1-4553-b1a7-304cb0d3d05a"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(607), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 431", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(608), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 432, 0.0, new Guid("26954c9c-be93-4a55-bc88-c4f09ffa72e9"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(624), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 432", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(625), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 433, 0.0, new Guid("8cce8600-ac21-4714-a967-38ebaef7bd3e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(640), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 433", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(641), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 434, 0.0, new Guid("f0e83950-4782-4df9-8cd6-734589708818"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(657), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 434", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(658), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 435, 0.0, new Guid("22a6ad90-14fb-448f-9f04-c18f526c3f99"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 435", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(677), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 436, 0.0, new Guid("655b29ae-99cc-453d-93dd-3261e877b7f7"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(737), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 436", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(738), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 437, 0.0, new Guid("7767bb25-03e9-4564-be9d-1938b05b0987"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(753), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 437", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(754), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 438, 0.0, new Guid("7ffb2685-ff55-4caf-a5ce-8e2e3f4e8f35"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(770), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 438", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(771), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 439, 0.0, new Guid("32f75bcf-87cc-4272-ae9b-7435ad77b2d6"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(789), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 439", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(789), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 440, 0.0, new Guid("aa150b20-f642-4003-94dd-34871a1a97a4"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(805), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 440", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(806), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 441, 0.0, new Guid("5ab1baa9-4a9e-4307-bdf4-4c25109685d0"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(821), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 441", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(822), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 442, 0.0, new Guid("701b7d90-5294-4624-a171-eab5e46e6b3a"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(838), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 442", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(838), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 443, 0.0, new Guid("21651df6-a705-48a3-bc5c-6bb98819f021"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(856), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 443", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(857), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 444, 0.0, new Guid("161a5cc8-4f7a-4ff6-b0b6-49df6e706560"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(873), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 444", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(874), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 445, 0.0, new Guid("25a86f2a-162b-4b3f-beef-e9a041962d56"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(889), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 445", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(890), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 446, 0.0, new Guid("2014fff8-4aa3-474f-8bf0-2b106e2e944e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 446", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(906), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 447, 0.0, new Guid("2cd59658-4f4e-4254-96ba-c8f88471e1d7"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(961), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 447", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(963), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 448, 0.0, new Guid("617d78f9-fb9e-4e11-91e2-2c9907ac68cc"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(981), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 448", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(982), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 449, 0.0, new Guid("53786792-5e5a-4d37-b334-be5c3ea2ff7d"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(999), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 449", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1000), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 450, 0.0, new Guid("82bdf98b-cbf8-4196-bd87-5f0f47463922"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1016), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 450", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1017), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 451, 0.0, new Guid("f0b7703c-c5df-47f9-9cfb-ec2fc6f5013b"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1035), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 451", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1036), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 452, 0.0, new Guid("4becd0b2-64b9-4de4-a1cd-d7182441a670"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1052), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 452", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1053), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 453, 0.0, new Guid("5d23eb62-fd08-43dc-ab72-2c000b320872"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1069), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 453", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1070), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 454, 0.0, new Guid("0349c497-2828-4da4-b623-ce792310280c"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1086), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 454", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1087), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 455, 0.0, new Guid("60a2f1aa-0a9e-4e4c-8d13-b8a7be90c96d"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1105), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 455", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1106), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 456, 0.0, new Guid("d32594e6-9f08-48ba-99f3-e339988d96cb"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1178), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 456", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1179), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 457, 0.0, new Guid("c43e43df-5341-42f7-a52f-fa504773f924"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1210), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 457", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1212), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 458, 0.0, new Guid("a01e3b25-b6dc-4e4f-b18b-6f56c0e55c04"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1270), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 458", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1272), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 459, 0.0, new Guid("c18803e8-1d56-4bd4-bdd8-033554782d8e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1293), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 459", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1294), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 460, 0.0, new Guid("6243573c-8bff-47ce-9d8f-6ef123ac8810"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 460", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1311), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 461, 0.0, new Guid("30a38ddd-70e9-4c9c-9fff-7efc0f4da45d"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1327), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 461", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1328), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 462, 0.0, new Guid("44969060-8624-4a45-9701-f060c576a3ce"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1343), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 462", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1344), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 463, 0.0, new Guid("9d5d2013-b9ab-4fb5-a8ab-190977932cdf"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1363), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 463", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1364), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 464, 0.0, new Guid("4dd10dc8-a25a-4e92-a3d4-21f7f3a5b078"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 464", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1381), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 465, 0.0, new Guid("4cd5781c-0bce-4b7a-8d12-de48be74eead"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 465", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1397), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 466, 0.0, new Guid("0e7934c2-11fa-404c-a1c5-e1d989617af0"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1413), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 466", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1413), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 467, 0.0, new Guid("aed1cf5b-34b8-4796-b3c5-3c82111e1092"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1432), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 467", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1433), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 468, 0.0, new Guid("21e72a71-6a60-4127-9e6b-1abe72629edc"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1449), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 468", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1450), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 469, 0.0, new Guid("91774e64-7965-40b5-821a-ec765e4288b6"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1466), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 469", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1467), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 470, 0.0, new Guid("dc29a2e6-1d93-4c7b-a2ca-0227cd3c7a89"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 470", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1541), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 471, 0.0, new Guid("1fff141c-6151-4c5f-b247-1136e63ac3b2"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1560), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 471", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1561), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 472, 0.0, new Guid("87c01088-b4ae-4602-b05c-5ac9049c3862"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1578), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 472", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1579), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 473, 0.0, new Guid("94fa1477-6034-4a0c-867b-032473e9c168"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1596), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 473", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1596), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 474, 0.0, new Guid("3c08519e-2281-45d5-89a8-77e173cad01e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1613), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 474", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1614), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 475, 0.0, new Guid("2c984e45-caf7-484c-9ea1-76cd4d6c8b82"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1633), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 475", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1634), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 476, 0.0, new Guid("875d046b-e603-4a18-9f76-5861fa635d71"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1650), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 476", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1651), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 477, 0.0, new Guid("0a8f8a7d-c583-48a2-b60c-287fa5edb4c2"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1668), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 477", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1669), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 478, 0.0, new Guid("137a0ab5-8b36-49be-afa1-6e6a93158028"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1685), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 478", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1686), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 479, 0.0, new Guid("d565f6ae-5ae6-472c-b8f7-07dbc0db601a"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1706), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 479", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1706), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 480, 0.0, new Guid("b892aa91-7e64-4255-90a9-15e58ebda456"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1723), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 480", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1724), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 481, 0.0, new Guid("e7e662dc-75f5-452b-b3ee-250cb6471ef1"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1779), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 481", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1780), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 482, 0.0, new Guid("e8f020e9-5b97-4769-84bf-8059db7778de"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1798), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 482", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1799), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 483, 0.0, new Guid("9ae77e63-852f-453a-a8c2-863742af499d"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 483", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1819), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 484, 0.0, new Guid("30762823-da89-4848-a293-b2221331f3bb"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1836), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 484", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1837), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 485, 0.0, new Guid("4013bdfb-041f-4066-b6dc-8ce8d55d5022"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1853), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 485", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1854), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 486, 0.0, new Guid("2c75de84-13a7-48f3-86fb-b6467d160b2b"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 486", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1871), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 487, 0.0, new Guid("a6027c9b-ca10-497d-8970-9f61ab4b2ac9"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1891), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 487", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1892), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 488, 0.0, new Guid("1db9dc3d-d3fa-4e5c-8765-2c2260d15b39"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1908), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 488", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1909), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 489, 0.0, new Guid("dd0b0f88-5091-4199-9a22-5a6a811f1201"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1925), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 489", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1926), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 490, 0.0, new Guid("d61e551b-3ad2-4600-bfd4-023d05f4bb2e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1943), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 490", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1944), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 491, 0.0, new Guid("81b5ac32-986b-4014-a77b-01b74e01e26c"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1963), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 491", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(1964), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 492, 0.0, new Guid("6728bd2f-6e65-4e4d-bd41-bff1a46c3723"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(2815), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 492", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(2819), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 493, 0.0, new Guid("7c1ffbc9-c927-490f-b1f1-3842ed0d8790"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(2875), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 493", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(2876), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 494, 0.0, new Guid("526d6940-b480-479b-8fee-d840746e09b3"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(2894), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 494", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(2895), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 495, 0.0, new Guid("abd43578-ff09-49e7-b960-0076a3b55d96"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(2916), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 495", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(2917), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 496, 0.0, new Guid("f2c4ff14-09c8-4fec-b9f6-6292acff01c0"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(2934), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 496", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(2935), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 497, 0.0, new Guid("9bf0250f-e3ee-4e1a-8f35-801153213603"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(2951), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 497", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(2952), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 498, 0.0, new Guid("00c9ec79-e69e-48dd-9d7b-da9262d15155"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(2968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 498", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(2969), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 499, 0.0, new Guid("12152589-16dc-4474-aa93-1f534900d89e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(2988), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 499", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(2989), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "name", "slot", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("a9a8fd46-e6a3-486a-95ac-f44d49baa3d0"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2831), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViRide", 2, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2832), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("c5ae07e8-f2c5-4698-9d48-48beddc83e96"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2853), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-4", 4, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2854), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("0d305fd8-0021-4e3a-9fed-ad55c7878a68"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2868), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-7", 7, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2869), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "type", "updated_at", "updated_by", "user_id" },
                values: new object[] { 9, 0.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4889), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4890), new TimeSpan(0, 7, 0, 0, 0)), 0, null });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3281), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3282), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3292), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3293), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3303), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3313), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3314), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3324), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3325), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3335), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3336), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 100, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3346), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+100", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3347), new TimeSpan(0, 7, 0, 0, 0)), 0, 100, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 101, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3363), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@100", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3364), new TimeSpan(0, 7, 0, 0, 0)), 0, 100 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 102, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3379), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+101", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3380), new TimeSpan(0, 7, 0, 0, 0)), 0, 101, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 103, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3392), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@101", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3392), new TimeSpan(0, 7, 0, 0, 0)), 0, 101 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 104, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+102", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3405), new TimeSpan(0, 7, 0, 0, 0)), 0, 102, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 105, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3416), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@102", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3417), new TimeSpan(0, 7, 0, 0, 0)), 0, 102 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 106, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3503), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+103", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3504), new TimeSpan(0, 7, 0, 0, 0)), 0, 103, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 107, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3520), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@103", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3521), new TimeSpan(0, 7, 0, 0, 0)), 0, 103 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 108, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3534), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+104", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3534), new TimeSpan(0, 7, 0, 0, 0)), 0, 104, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 109, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@104", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3549), new TimeSpan(0, 7, 0, 0, 0)), 0, 104 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 110, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3561), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+105", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3562), new TimeSpan(0, 7, 0, 0, 0)), 0, 105, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 111, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3574), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@105", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3574), new TimeSpan(0, 7, 0, 0, 0)), 0, 105 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 112, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3586), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+106", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3587), new TimeSpan(0, 7, 0, 0, 0)), 0, 106, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 113, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3598), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@106", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3599), new TimeSpan(0, 7, 0, 0, 0)), 0, 106 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 114, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3611), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+107", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3612), new TimeSpan(0, 7, 0, 0, 0)), 0, 107, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 115, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3624), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@107", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3625), new TimeSpan(0, 7, 0, 0, 0)), 0, 107 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 116, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3637), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+108", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3638), new TimeSpan(0, 7, 0, 0, 0)), 0, 108, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 117, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3650), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@108", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3651), new TimeSpan(0, 7, 0, 0, 0)), 0, 108 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 118, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3662), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+109", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3663), new TimeSpan(0, 7, 0, 0, 0)), 0, 109, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 119, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3675), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@109", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3676), new TimeSpan(0, 7, 0, 0, 0)), 0, 109 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 120, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+110", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3688), new TimeSpan(0, 7, 0, 0, 0)), 0, 110, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 121, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3700), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@110", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3701), new TimeSpan(0, 7, 0, 0, 0)), 0, 110 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 122, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3713), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+111", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3714), new TimeSpan(0, 7, 0, 0, 0)), 0, 111, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 123, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3725), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@111", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3726), new TimeSpan(0, 7, 0, 0, 0)), 0, 111 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 124, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3738), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+112", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3739), new TimeSpan(0, 7, 0, 0, 0)), 0, 112, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 125, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3750), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@112", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3751), new TimeSpan(0, 7, 0, 0, 0)), 0, 112 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 126, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3763), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+113", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3764), new TimeSpan(0, 7, 0, 0, 0)), 0, 113, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 127, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3821), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@113", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3822), new TimeSpan(0, 7, 0, 0, 0)), 0, 113 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 128, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3835), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+114", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3835), new TimeSpan(0, 7, 0, 0, 0)), 0, 114, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 129, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@114", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3848), new TimeSpan(0, 7, 0, 0, 0)), 0, 114 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 130, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3860), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+115", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3861), new TimeSpan(0, 7, 0, 0, 0)), 0, 115, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 131, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3873), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@115", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3874), new TimeSpan(0, 7, 0, 0, 0)), 0, 115 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 132, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3885), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+116", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3886), new TimeSpan(0, 7, 0, 0, 0)), 0, 116, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 133, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3898), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@116", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3899), new TimeSpan(0, 7, 0, 0, 0)), 0, 116 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 134, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3910), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+117", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3911), new TimeSpan(0, 7, 0, 0, 0)), 0, 117, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 135, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3923), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@117", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3924), new TimeSpan(0, 7, 0, 0, 0)), 0, 117 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 136, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3935), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+118", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3936), new TimeSpan(0, 7, 0, 0, 0)), 0, 118, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 137, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3948), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@118", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3949), new TimeSpan(0, 7, 0, 0, 0)), 0, 118 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 138, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3961), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+119", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3962), new TimeSpan(0, 7, 0, 0, 0)), 0, 119, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 139, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3973), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@119", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3974), new TimeSpan(0, 7, 0, 0, 0)), 0, 119 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 140, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3986), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+120", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3987), new TimeSpan(0, 7, 0, 0, 0)), 0, 120, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 141, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4000), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@120", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4001), new TimeSpan(0, 7, 0, 0, 0)), 0, 120 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 142, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4013), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+121", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4014), new TimeSpan(0, 7, 0, 0, 0)), 0, 121, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 143, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4026), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@121", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4027), new TimeSpan(0, 7, 0, 0, 0)), 0, 121 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 144, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4038), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+122", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4039), new TimeSpan(0, 7, 0, 0, 0)), 0, 122, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 145, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4051), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@122", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4052), new TimeSpan(0, 7, 0, 0, 0)), 0, 122 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 146, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4106), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+123", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4107), new TimeSpan(0, 7, 0, 0, 0)), 0, 123, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 147, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4120), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@123", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4121), new TimeSpan(0, 7, 0, 0, 0)), 0, 123 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 148, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4133), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+124", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4134), new TimeSpan(0, 7, 0, 0, 0)), 0, 124, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 149, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4145), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@124", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4146), new TimeSpan(0, 7, 0, 0, 0)), 0, 124 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 150, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4158), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+125", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4159), new TimeSpan(0, 7, 0, 0, 0)), 0, 125, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 151, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4171), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@125", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4171), new TimeSpan(0, 7, 0, 0, 0)), 0, 125 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 152, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4183), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+126", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4184), new TimeSpan(0, 7, 0, 0, 0)), 0, 126, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 153, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4196), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@126", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4197), new TimeSpan(0, 7, 0, 0, 0)), 0, 126 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 154, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4209), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+127", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4210), new TimeSpan(0, 7, 0, 0, 0)), 0, 127, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 155, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4222), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@127", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4222), new TimeSpan(0, 7, 0, 0, 0)), 0, 127 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 156, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4234), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+128", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4235), new TimeSpan(0, 7, 0, 0, 0)), 0, 128, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 157, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4247), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@128", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4248), new TimeSpan(0, 7, 0, 0, 0)), 0, 128 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 158, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4260), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+129", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4261), new TimeSpan(0, 7, 0, 0, 0)), 0, 129, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 159, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@129", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4273), new TimeSpan(0, 7, 0, 0, 0)), 0, 129 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 160, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4285), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+130", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4286), new TimeSpan(0, 7, 0, 0, 0)), 0, 130, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 161, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4298), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@130", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4299), new TimeSpan(0, 7, 0, 0, 0)), 0, 130 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 162, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+131", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4311), new TimeSpan(0, 7, 0, 0, 0)), 0, 131, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 163, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4323), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@131", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4324), new TimeSpan(0, 7, 0, 0, 0)), 0, 131 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 164, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4335), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+132", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4336), new TimeSpan(0, 7, 0, 0, 0)), 0, 132, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 165, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4348), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@132", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4349), new TimeSpan(0, 7, 0, 0, 0)), 0, 132 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 166, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4360), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+133", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4361), new TimeSpan(0, 7, 0, 0, 0)), 0, 133, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 167, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4373), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@133", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4374), new TimeSpan(0, 7, 0, 0, 0)), 0, 133 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 168, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4455), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+134", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4456), new TimeSpan(0, 7, 0, 0, 0)), 0, 134, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 169, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4470), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@134", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4471), new TimeSpan(0, 7, 0, 0, 0)), 0, 134 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 170, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4483), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+135", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4484), new TimeSpan(0, 7, 0, 0, 0)), 0, 135, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 171, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4496), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@135", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4497), new TimeSpan(0, 7, 0, 0, 0)), 0, 135 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 172, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4509), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+136", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4510), new TimeSpan(0, 7, 0, 0, 0)), 0, 136, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 173, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4522), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@136", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4523), new TimeSpan(0, 7, 0, 0, 0)), 0, 136 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 174, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4535), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+137", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4535), new TimeSpan(0, 7, 0, 0, 0)), 0, 137, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 175, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4547), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@137", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4548), new TimeSpan(0, 7, 0, 0, 0)), 0, 137 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 176, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4560), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+138", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4561), new TimeSpan(0, 7, 0, 0, 0)), 0, 138, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 177, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@138", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4573), new TimeSpan(0, 7, 0, 0, 0)), 0, 138 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 178, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4585), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+139", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4586), new TimeSpan(0, 7, 0, 0, 0)), 0, 139, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 179, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4597), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@139", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4598), new TimeSpan(0, 7, 0, 0, 0)), 0, 139 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 180, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4610), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+140", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4611), new TimeSpan(0, 7, 0, 0, 0)), 0, 140, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 181, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4623), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@140", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4623), new TimeSpan(0, 7, 0, 0, 0)), 0, 140 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 182, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+141", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4636), new TimeSpan(0, 7, 0, 0, 0)), 0, 141, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 183, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4648), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@141", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4649), new TimeSpan(0, 7, 0, 0, 0)), 0, 141 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 184, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4661), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+142", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4661), new TimeSpan(0, 7, 0, 0, 0)), 0, 142, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 185, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4673), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@142", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4674), new TimeSpan(0, 7, 0, 0, 0)), 0, 142 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 186, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4686), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+143", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4687), new TimeSpan(0, 7, 0, 0, 0)), 0, 143, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 187, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4698), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@143", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4699), new TimeSpan(0, 7, 0, 0, 0)), 0, 143 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 188, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4710), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+144", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4711), new TimeSpan(0, 7, 0, 0, 0)), 0, 144, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 189, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4723), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@144", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4724), new TimeSpan(0, 7, 0, 0, 0)), 0, 144 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 190, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4735), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+145", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(4736), new TimeSpan(0, 7, 0, 0, 0)), 0, 145, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 191, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5619), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@145", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5622), new TimeSpan(0, 7, 0, 0, 0)), 0, 145 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 192, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5638), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+146", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5639), new TimeSpan(0, 7, 0, 0, 0)), 0, 146, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 193, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5651), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@146", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5652), new TimeSpan(0, 7, 0, 0, 0)), 0, 146 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 194, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5663), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+147", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5664), new TimeSpan(0, 7, 0, 0, 0)), 0, 147, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 195, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5675), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@147", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5676), new TimeSpan(0, 7, 0, 0, 0)), 0, 147 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 196, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5687), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+148", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5688), new TimeSpan(0, 7, 0, 0, 0)), 0, 148, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 197, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5699), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@148", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5700), new TimeSpan(0, 7, 0, 0, 0)), 0, 148 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 198, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5711), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+149", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5712), new TimeSpan(0, 7, 0, 0, 0)), 0, 149, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 199, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5723), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@149", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5724), new TimeSpan(0, 7, 0, 0, 0)), 0, 149 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 200, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5735), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+150", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5736), new TimeSpan(0, 7, 0, 0, 0)), 0, 150, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 201, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5747), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@150", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5748), new TimeSpan(0, 7, 0, 0, 0)), 0, 150 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 202, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5759), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+151", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5760), new TimeSpan(0, 7, 0, 0, 0)), 0, 151, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 203, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5771), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@151", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5772), new TimeSpan(0, 7, 0, 0, 0)), 0, 151 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 204, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5783), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+152", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5784), new TimeSpan(0, 7, 0, 0, 0)), 0, 152, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 205, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5799), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@152", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5800), new TimeSpan(0, 7, 0, 0, 0)), 0, 152 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 206, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5812), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+153", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5813), new TimeSpan(0, 7, 0, 0, 0)), 0, 153, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 207, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5872), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@153", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5873), new TimeSpan(0, 7, 0, 0, 0)), 0, 153 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 208, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5888), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+154", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5889), new TimeSpan(0, 7, 0, 0, 0)), 0, 154, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 209, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5901), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@154", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5902), new TimeSpan(0, 7, 0, 0, 0)), 0, 154 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 210, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5913), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+155", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5914), new TimeSpan(0, 7, 0, 0, 0)), 0, 155, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 211, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5925), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@155", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5926), new TimeSpan(0, 7, 0, 0, 0)), 0, 155 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 212, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5937), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+156", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5938), new TimeSpan(0, 7, 0, 0, 0)), 0, 156, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 213, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5949), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@156", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5950), new TimeSpan(0, 7, 0, 0, 0)), 0, 156 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 214, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5961), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+157", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5962), new TimeSpan(0, 7, 0, 0, 0)), 0, 157, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 215, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5973), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@157", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5974), new TimeSpan(0, 7, 0, 0, 0)), 0, 157 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 216, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5986), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+158", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5987), new TimeSpan(0, 7, 0, 0, 0)), 0, 158, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 217, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@158", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(5999), new TimeSpan(0, 7, 0, 0, 0)), 0, 158 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 218, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6010), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+159", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6011), new TimeSpan(0, 7, 0, 0, 0)), 0, 159, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 219, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6023), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@159", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6024), new TimeSpan(0, 7, 0, 0, 0)), 0, 159 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 220, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6035), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+160", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6036), new TimeSpan(0, 7, 0, 0, 0)), 0, 160, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 221, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6047), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@160", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6048), new TimeSpan(0, 7, 0, 0, 0)), 0, 160 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 222, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6059), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+161", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6060), new TimeSpan(0, 7, 0, 0, 0)), 0, 161, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 223, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6071), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@161", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6072), new TimeSpan(0, 7, 0, 0, 0)), 0, 161 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 224, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6084), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+162", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6084), new TimeSpan(0, 7, 0, 0, 0)), 0, 162, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 225, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6096), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@162", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6097), new TimeSpan(0, 7, 0, 0, 0)), 0, 162 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 226, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6108), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+163", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6109), new TimeSpan(0, 7, 0, 0, 0)), 0, 163, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 227, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6120), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@163", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6121), new TimeSpan(0, 7, 0, 0, 0)), 0, 163 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 228, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6132), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+164", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6133), new TimeSpan(0, 7, 0, 0, 0)), 0, 164, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 229, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@164", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(6977), new TimeSpan(0, 7, 0, 0, 0)), 0, 164 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 230, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7026), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+165", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7027), new TimeSpan(0, 7, 0, 0, 0)), 0, 165, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 231, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7040), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@165", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7041), new TimeSpan(0, 7, 0, 0, 0)), 0, 165 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 232, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7052), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+166", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7053), new TimeSpan(0, 7, 0, 0, 0)), 0, 166, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 233, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7064), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@166", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7065), new TimeSpan(0, 7, 0, 0, 0)), 0, 166 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 234, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7076), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+167", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7077), new TimeSpan(0, 7, 0, 0, 0)), 0, 167, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 235, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7088), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@167", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7089), new TimeSpan(0, 7, 0, 0, 0)), 0, 167 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 236, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7100), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+168", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7101), new TimeSpan(0, 7, 0, 0, 0)), 0, 168, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 237, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7112), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@168", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7113), new TimeSpan(0, 7, 0, 0, 0)), 0, 168 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 238, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7124), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+169", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7125), new TimeSpan(0, 7, 0, 0, 0)), 0, 169, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 239, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7136), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@169", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7137), new TimeSpan(0, 7, 0, 0, 0)), 0, 169 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 240, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7148), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+170", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7149), new TimeSpan(0, 7, 0, 0, 0)), 0, 170, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 241, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7160), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@170", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7161), new TimeSpan(0, 7, 0, 0, 0)), 0, 170 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 242, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7171), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+171", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7172), new TimeSpan(0, 7, 0, 0, 0)), 0, 171, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 243, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7183), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@171", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7184), new TimeSpan(0, 7, 0, 0, 0)), 0, 171 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 244, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7195), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+172", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7196), new TimeSpan(0, 7, 0, 0, 0)), 0, 172, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 245, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7207), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@172", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7208), new TimeSpan(0, 7, 0, 0, 0)), 0, 172 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 246, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7219), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+173", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7220), new TimeSpan(0, 7, 0, 0, 0)), 0, 173, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 247, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7231), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@173", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7232), new TimeSpan(0, 7, 0, 0, 0)), 0, 173 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 248, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7244), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+174", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7244), new TimeSpan(0, 7, 0, 0, 0)), 0, 174, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 249, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@174", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7256), new TimeSpan(0, 7, 0, 0, 0)), 0, 174 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 250, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7268), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+175", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7268), new TimeSpan(0, 7, 0, 0, 0)), 0, 175, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 251, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7329), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@175", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7330), new TimeSpan(0, 7, 0, 0, 0)), 0, 175 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 252, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7346), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+176", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7346), new TimeSpan(0, 7, 0, 0, 0)), 0, 176, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 253, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7358), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@176", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7359), new TimeSpan(0, 7, 0, 0, 0)), 0, 176 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 254, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7370), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+177", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7371), new TimeSpan(0, 7, 0, 0, 0)), 0, 177, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 255, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7382), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@177", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7383), new TimeSpan(0, 7, 0, 0, 0)), 0, 177 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 256, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7395), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+178", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7395), new TimeSpan(0, 7, 0, 0, 0)), 0, 178, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 257, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7407), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@178", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7408), new TimeSpan(0, 7, 0, 0, 0)), 0, 178 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 258, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7419), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+179", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7420), new TimeSpan(0, 7, 0, 0, 0)), 0, 179, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 259, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7431), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@179", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7432), new TimeSpan(0, 7, 0, 0, 0)), 0, 179 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 260, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7444), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+180", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7445), new TimeSpan(0, 7, 0, 0, 0)), 0, 180, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 261, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7456), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@180", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7457), new TimeSpan(0, 7, 0, 0, 0)), 0, 180 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 262, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+181", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7469), new TimeSpan(0, 7, 0, 0, 0)), 0, 181, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 263, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@181", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7482), new TimeSpan(0, 7, 0, 0, 0)), 0, 181 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 264, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7493), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+182", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7494), new TimeSpan(0, 7, 0, 0, 0)), 0, 182, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 265, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7506), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@182", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7507), new TimeSpan(0, 7, 0, 0, 0)), 0, 182 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 266, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7518), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+183", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7519), new TimeSpan(0, 7, 0, 0, 0)), 0, 183, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 267, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7530), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@183", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7531), new TimeSpan(0, 7, 0, 0, 0)), 0, 183 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 268, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7543), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+184", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7544), new TimeSpan(0, 7, 0, 0, 0)), 0, 184, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 269, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7555), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@184", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7556), new TimeSpan(0, 7, 0, 0, 0)), 0, 184 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 270, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7567), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+185", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7568), new TimeSpan(0, 7, 0, 0, 0)), 0, 185, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 271, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7579), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@185", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7580), new TimeSpan(0, 7, 0, 0, 0)), 0, 185 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 272, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7592), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+186", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7592), new TimeSpan(0, 7, 0, 0, 0)), 0, 186, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 273, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7604), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@186", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7605), new TimeSpan(0, 7, 0, 0, 0)), 0, 186 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 274, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7685), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+187", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7686), new TimeSpan(0, 7, 0, 0, 0)), 0, 187, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 275, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7700), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@187", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7701), new TimeSpan(0, 7, 0, 0, 0)), 0, 187 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 276, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7712), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+188", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7713), new TimeSpan(0, 7, 0, 0, 0)), 0, 188, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 277, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7724), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@188", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7725), new TimeSpan(0, 7, 0, 0, 0)), 0, 188 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 278, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7736), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+189", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7737), new TimeSpan(0, 7, 0, 0, 0)), 0, 189, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 279, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7748), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@189", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7749), new TimeSpan(0, 7, 0, 0, 0)), 0, 189 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 280, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7760), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+190", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7761), new TimeSpan(0, 7, 0, 0, 0)), 0, 190, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 281, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7773), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@190", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7774), new TimeSpan(0, 7, 0, 0, 0)), 0, 190 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 282, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7785), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+191", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7786), new TimeSpan(0, 7, 0, 0, 0)), 0, 191, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 283, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7798), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@191", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7799), new TimeSpan(0, 7, 0, 0, 0)), 0, 191 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 284, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7810), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+192", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7811), new TimeSpan(0, 7, 0, 0, 0)), 0, 192, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 285, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7823), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@192", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7824), new TimeSpan(0, 7, 0, 0, 0)), 0, 192 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 286, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7835), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+193", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7836), new TimeSpan(0, 7, 0, 0, 0)), 0, 193, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 287, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@193", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7848), new TimeSpan(0, 7, 0, 0, 0)), 0, 193 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 288, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7859), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+194", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7860), new TimeSpan(0, 7, 0, 0, 0)), 0, 194, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 289, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@194", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7872), new TimeSpan(0, 7, 0, 0, 0)), 0, 194 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 290, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7883), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+195", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7884), new TimeSpan(0, 7, 0, 0, 0)), 0, 195, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 291, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@195", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7896), new TimeSpan(0, 7, 0, 0, 0)), 0, 195 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 292, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7907), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+196", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7908), new TimeSpan(0, 7, 0, 0, 0)), 0, 196, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 293, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7920), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@196", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7920), new TimeSpan(0, 7, 0, 0, 0)), 0, 196 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 294, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7932), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+197", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7932), new TimeSpan(0, 7, 0, 0, 0)), 0, 197, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 295, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7943), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@197", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(7944), new TimeSpan(0, 7, 0, 0, 0)), 0, 197 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 296, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8001), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+198", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8002), new TimeSpan(0, 7, 0, 0, 0)), 0, 198, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 297, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8014), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@198", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8015), new TimeSpan(0, 7, 0, 0, 0)), 0, 198 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 298, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8026), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+199", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8027), new TimeSpan(0, 7, 0, 0, 0)), 0, 199, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 299, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8039), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@199", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8039), new TimeSpan(0, 7, 0, 0, 0)), 0, 199 },
                    { 400, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8051), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+400", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8052), new TimeSpan(0, 7, 0, 0, 0)), 0, 400 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 401, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8065), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@400", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8066), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 402, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8078), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+401", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8079), new TimeSpan(0, 7, 0, 0, 0)), 0, 401 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 403, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8090), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@401", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8091), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 404, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8103), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+402", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8104), new TimeSpan(0, 7, 0, 0, 0)), 0, 402 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 405, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8115), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@402", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8116), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 406, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8127), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+403", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8128), new TimeSpan(0, 7, 0, 0, 0)), 0, 403 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 407, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8139), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@403", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8140), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 408, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8151), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+404", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8152), new TimeSpan(0, 7, 0, 0, 0)), 0, 404 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 409, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8163), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@404", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8164), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 410, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8175), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+405", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8176), new TimeSpan(0, 7, 0, 0, 0)), 0, 405 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 411, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8187), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@405", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8188), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 412, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8199), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+406", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8200), new TimeSpan(0, 7, 0, 0, 0)), 0, 406 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 413, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8211), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@406", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8212), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 414, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8223), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+407", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8224), new TimeSpan(0, 7, 0, 0, 0)), 0, 407 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 415, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8235), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@407", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8236), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 416, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8247), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+408", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8248), new TimeSpan(0, 7, 0, 0, 0)), 0, 408 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 417, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8259), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@408", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8260), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 418, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8314), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+409", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8315), new TimeSpan(0, 7, 0, 0, 0)), 0, 409 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 419, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8329), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@409", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8330), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 420, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8341), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+410", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8342), new TimeSpan(0, 7, 0, 0, 0)), 0, 410 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 421, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8353), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@410", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8354), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 422, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8365), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+411", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8366), new TimeSpan(0, 7, 0, 0, 0)), 0, 411 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 423, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8377), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@411", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8378), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 424, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8389), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+412", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8390), new TimeSpan(0, 7, 0, 0, 0)), 0, 412 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 425, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8401), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@412", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8402), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 426, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8413), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+413", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8414), new TimeSpan(0, 7, 0, 0, 0)), 0, 413 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 427, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8426), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@413", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8426), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 428, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8438), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+414", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8438), new TimeSpan(0, 7, 0, 0, 0)), 0, 414 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 429, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8449), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@414", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8450), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 430, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8461), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+415", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8462), new TimeSpan(0, 7, 0, 0, 0)), 0, 415 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 431, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8473), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@415", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8474), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 432, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8485), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+416", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(8486), new TimeSpan(0, 7, 0, 0, 0)), 0, 416 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 433, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9248), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@416", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9252), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 434, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9275), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+417", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9276), new TimeSpan(0, 7, 0, 0, 0)), 0, 417 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 435, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9288), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@417", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9289), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 436, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9300), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+418", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9301), new TimeSpan(0, 7, 0, 0, 0)), 0, 418 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 437, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9312), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@418", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9313), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 438, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9324), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+419", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9325), new TimeSpan(0, 7, 0, 0, 0)), 0, 419 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 439, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9337), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@419", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9337), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 440, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9349), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+420", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9350), new TimeSpan(0, 7, 0, 0, 0)), 0, 420 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 441, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@420", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9362), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 442, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9373), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+421", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9374), new TimeSpan(0, 7, 0, 0, 0)), 0, 421 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 443, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9385), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@421", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9386), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 444, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+422", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9398), new TimeSpan(0, 7, 0, 0, 0)), 0, 422 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 445, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9409), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@422", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9410), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 446, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9421), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+423", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9422), new TimeSpan(0, 7, 0, 0, 0)), 0, 423 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 447, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9433), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@423", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9434), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 448, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9445), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+424", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9446), new TimeSpan(0, 7, 0, 0, 0)), 0, 424 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 449, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@424", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9458), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 450, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9469), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+425", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9470), new TimeSpan(0, 7, 0, 0, 0)), 0, 425 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 451, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9524), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@425", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9525), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 452, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9539), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+426", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9540), new TimeSpan(0, 7, 0, 0, 0)), 0, 426 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 453, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9552), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@426", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9552), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 454, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9564), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+427", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9565), new TimeSpan(0, 7, 0, 0, 0)), 0, 427 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 455, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9576), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@427", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9577), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 456, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9588), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+428", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9589), new TimeSpan(0, 7, 0, 0, 0)), 0, 428 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 457, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9601), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@428", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9602), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 458, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9613), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+429", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9614), new TimeSpan(0, 7, 0, 0, 0)), 0, 429 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 459, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9625), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@429", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9626), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 460, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9637), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+430", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9638), new TimeSpan(0, 7, 0, 0, 0)), 0, 430 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 461, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9649), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@430", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 462, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9661), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+431", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9662), new TimeSpan(0, 7, 0, 0, 0)), 0, 431 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 463, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9673), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@431", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9674), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 464, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9685), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+432", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9686), new TimeSpan(0, 7, 0, 0, 0)), 0, 432 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 465, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9697), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@432", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9698), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 466, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9710), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+433", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9711), new TimeSpan(0, 7, 0, 0, 0)), 0, 433 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 467, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9722), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@433", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9722), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 468, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9734), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+434", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9735), new TimeSpan(0, 7, 0, 0, 0)), 0, 434 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 469, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9746), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@434", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9747), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 470, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9758), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+435", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9759), new TimeSpan(0, 7, 0, 0, 0)), 0, 435 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 471, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9770), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@435", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9771), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 472, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9782), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+436", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9783), new TimeSpan(0, 7, 0, 0, 0)), 0, 436 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 473, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9838), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@436", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9839), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 474, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9853), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+437", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9854), new TimeSpan(0, 7, 0, 0, 0)), 0, 437 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 475, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9865), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@437", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9866), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 476, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9877), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+438", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9878), new TimeSpan(0, 7, 0, 0, 0)), 0, 438 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 477, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9889), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@438", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9889), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 478, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9900), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+439", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9901), new TimeSpan(0, 7, 0, 0, 0)), 0, 439 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 479, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9912), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@439", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9913), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 480, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9924), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+440", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9925), new TimeSpan(0, 7, 0, 0, 0)), 0, 440 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 481, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9936), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@440", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9937), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 482, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9948), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+441", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9949), new TimeSpan(0, 7, 0, 0, 0)), 0, 441 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 483, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9960), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@441", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9961), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 484, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+442", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9973), new TimeSpan(0, 7, 0, 0, 0)), 0, 442 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 485, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9985), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@442", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9986), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 486, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9997), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+443", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(9998), new TimeSpan(0, 7, 0, 0, 0)), 0, 443 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 487, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(9), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@443", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(9), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 488, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(20), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+444", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(21), new TimeSpan(0, 7, 0, 0, 0)), 0, 444 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 489, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(32), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@444", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(33), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 490, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(44), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+445", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(45), new TimeSpan(0, 7, 0, 0, 0)), 0, 445 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 491, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(56), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@445", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(57), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 492, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(68), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+446", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(69), new TimeSpan(0, 7, 0, 0, 0)), 0, 446 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 493, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(80), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@446", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(81), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 494, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(92), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+447", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(93), new TimeSpan(0, 7, 0, 0, 0)), 0, 447 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 495, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(104), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@447", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(104), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 496, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(160), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+448", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(161), new TimeSpan(0, 7, 0, 0, 0)), 0, 448 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 497, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@448", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(173), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 498, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(185), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+449", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(186), new TimeSpan(0, 7, 0, 0, 0)), 0, 449 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 499, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(196), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@449", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(197), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 500, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(209), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+450", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(209), new TimeSpan(0, 7, 0, 0, 0)), 0, 450 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 501, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(220), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@450", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(221), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 502, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(233), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+451", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(234), new TimeSpan(0, 7, 0, 0, 0)), 0, 451 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 503, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(245), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@451", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(245), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 504, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+452", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(257), new TimeSpan(0, 7, 0, 0, 0)), 0, 452 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 505, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(268), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@452", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(269), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 506, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(280), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+453", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(281), new TimeSpan(0, 7, 0, 0, 0)), 0, 453 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 507, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(292), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@453", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(293), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 508, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(304), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+454", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(305), new TimeSpan(0, 7, 0, 0, 0)), 0, 454 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 509, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(316), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@454", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(317), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 510, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(328), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+455", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(329), new TimeSpan(0, 7, 0, 0, 0)), 0, 455 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 511, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(340), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@455", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(341), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 512, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(352), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+456", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(352), new TimeSpan(0, 7, 0, 0, 0)), 0, 456 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 513, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(363), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@456", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(364), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 514, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(375), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+457", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(376), new TimeSpan(0, 7, 0, 0, 0)), 0, 457 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 515, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(387), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@457", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(388), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 516, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(400), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+458", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(400), new TimeSpan(0, 7, 0, 0, 0)), 0, 458 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 517, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@458", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(412), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 518, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+459", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(469), new TimeSpan(0, 7, 0, 0, 0)), 0, 459 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 519, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@459", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(482), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 520, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(493), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+460", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(494), new TimeSpan(0, 7, 0, 0, 0)), 0, 460 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 521, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(505), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@460", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(506), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 522, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+461", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(518), new TimeSpan(0, 7, 0, 0, 0)), 0, 461 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 523, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(529), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@461", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(530), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 524, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(541), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+462", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(542), new TimeSpan(0, 7, 0, 0, 0)), 0, 462 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 525, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(553), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@462", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(553), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 526, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(565), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+463", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(565), new TimeSpan(0, 7, 0, 0, 0)), 0, 463 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 527, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(577), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@463", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(578), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 528, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(589), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+464", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(590), new TimeSpan(0, 7, 0, 0, 0)), 0, 464 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 529, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(601), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@464", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(602), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 530, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(613), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+465", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(614), new TimeSpan(0, 7, 0, 0, 0)), 0, 465 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 531, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(625), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@465", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(626), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 532, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(638), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+466", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(639), new TimeSpan(0, 7, 0, 0, 0)), 0, 466 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 533, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(650), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@466", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(651), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 534, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(662), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+467", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(663), new TimeSpan(0, 7, 0, 0, 0)), 0, 467 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 535, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(674), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@467", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(675), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 536, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(686), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+468", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(687), new TimeSpan(0, 7, 0, 0, 0)), 0, 468 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 537, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(698), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@468", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(699), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 538, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(710), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+469", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(711), new TimeSpan(0, 7, 0, 0, 0)), 0, 469 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 539, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(722), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@469", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(723), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 540, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(807), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+470", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(809), new TimeSpan(0, 7, 0, 0, 0)), 0, 470 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 541, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(826), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@470", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(826), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 542, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(838), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+471", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(839), new TimeSpan(0, 7, 0, 0, 0)), 0, 471 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 543, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(850), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@471", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(851), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 544, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(862), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+472", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(863), new TimeSpan(0, 7, 0, 0, 0)), 0, 472 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 545, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(874), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@472", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(875), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 546, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(886), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+473", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(887), new TimeSpan(0, 7, 0, 0, 0)), 0, 473 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 547, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(898), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@473", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(899), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 548, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(910), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+474", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(911), new TimeSpan(0, 7, 0, 0, 0)), 0, 474 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 549, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(922), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@474", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(923), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 550, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(934), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+475", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(935), new TimeSpan(0, 7, 0, 0, 0)), 0, 475 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 551, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(947), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@475", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(948), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 552, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+476", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(960), new TimeSpan(0, 7, 0, 0, 0)), 0, 476 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 553, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(971), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@476", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(972), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 554, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(983), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+477", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(984), new TimeSpan(0, 7, 0, 0, 0)), 0, 477 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 555, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(995), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@477", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(996), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 556, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1007), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+478", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1008), new TimeSpan(0, 7, 0, 0, 0)), 0, 478 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 557, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1019), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@478", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1020), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 558, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1031), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+479", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1032), new TimeSpan(0, 7, 0, 0, 0)), 0, 479 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 559, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1043), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@479", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1044), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 560, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1055), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+480", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1056), new TimeSpan(0, 7, 0, 0, 0)), 0, 480 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 561, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1067), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@480", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1068), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 562, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1160), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+481", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1162), new TimeSpan(0, 7, 0, 0, 0)), 0, 481 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 563, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1189), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@481", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1191), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 564, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1210), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+482", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1211), new TimeSpan(0, 7, 0, 0, 0)), 0, 482 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 565, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1223), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@482", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1223), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 566, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1234), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+483", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1235), new TimeSpan(0, 7, 0, 0, 0)), 0, 483 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 567, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1246), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@483", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1247), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 568, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1258), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+484", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1259), new TimeSpan(0, 7, 0, 0, 0)), 0, 484 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 569, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1270), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@484", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1270), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 570, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1281), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+485", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1282), new TimeSpan(0, 7, 0, 0, 0)), 0, 485 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 571, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1293), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@485", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1294), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 572, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1305), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+486", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1306), new TimeSpan(0, 7, 0, 0, 0)), 0, 486 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 573, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1316), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@486", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1317), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 574, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1328), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+487", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1329), new TimeSpan(0, 7, 0, 0, 0)), 0, 487 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 575, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1340), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@487", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1340), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 576, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1351), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+488", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1352), new TimeSpan(0, 7, 0, 0, 0)), 0, 488 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 577, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1363), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@488", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1364), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 578, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1375), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+489", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1376), new TimeSpan(0, 7, 0, 0, 0)), 0, 489 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 579, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1387), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@489", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1388), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 580, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1399), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+490", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1400), new TimeSpan(0, 7, 0, 0, 0)), 0, 490 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 581, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1410), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@490", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1411), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 582, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1422), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+491", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1423), new TimeSpan(0, 7, 0, 0, 0)), 0, 491 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 583, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1433), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@491", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1434), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 584, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1485), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+492", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1486), new TimeSpan(0, 7, 0, 0, 0)), 0, 492 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 585, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1500), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@492", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1501), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 586, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1512), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+493", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1513), new TimeSpan(0, 7, 0, 0, 0)), 0, 493 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 587, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1523), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@493", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1524), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 588, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1535), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+494", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1536), new TimeSpan(0, 7, 0, 0, 0)), 0, 494 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 589, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1547), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@494", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1548), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 590, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1559), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+495", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1560), new TimeSpan(0, 7, 0, 0, 0)), 0, 495 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 591, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@495", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1572), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 592, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1583), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+496", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1583), new TimeSpan(0, 7, 0, 0, 0)), 0, 496 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 593, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1594), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@496", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1595), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 594, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1606), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+497", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1607), new TimeSpan(0, 7, 0, 0, 0)), 0, 497 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 595, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1618), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@497", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1619), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 596, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1630), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+498", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1631), new TimeSpan(0, 7, 0, 0, 0)), 0, 498 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 597, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1642), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@498", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1643), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 598, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1654), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+499", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1655), new TimeSpan(0, 7, 0, 0, 0)), 0, 499 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 599, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1665), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@499", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1666), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, true });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "title", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2764), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, "What is Lorem Ipsum?", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2765), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2771), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, "Why do we use it?", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2771), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2773), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, "Where does it come from?", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2774), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2775), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, "Where can I get some?", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2776), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2878), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2879), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2883), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2884), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2886), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2887), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2040), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2041), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2074), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2075), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2107), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2108), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1692), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1693), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1714), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1715), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1764), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1765), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trip_rate", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "rating", "status", "suddenly_cancelled_trips", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 0.0, new Guid("80a490ad-5e37-404b-9645-7a102a0d2624"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6272), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, 1, "Quach Dai Loi", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6273), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 0.0, new Guid("8fdeb78a-87b1-4e23-861a-ac189b61cd2d"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6294), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, 1, "Do Trong Dat", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6304), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 0.0, new Guid("6225fca4-dfd1-4d48-9d1c-4514f633d1f5"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6349), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 3, 1, "Nguyen Dang Khoa", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6351), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 0.0, new Guid("95c134c5-ddd5-431b-bc56-732a18f77b95"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6370), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 4, 1, "Than Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6371), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 0.0, new Guid("c6c424c4-2971-4df3-bae8-83abc5c62523"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6387), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 5, 1, "Loi Quach", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6387), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 0.0, new Guid("6b156b7c-9c3b-4c55-bdd8-f27582378ddb"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6449), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 6, 1, "Dat Do", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6451), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 0.0, new Guid("4766ced3-2b72-4651-a649-40678efa8f5d"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6470), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 7, 1, "Khoa Nguyen", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6471), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 0.0, new Guid("5d10c512-9db8-43db-a637-49af71d6a854"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6490), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 8, 1, "Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6491), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 0.0, new Guid("f68c6c3b-3bef-479e-8134-b084679d09f8"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6509), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 13, 1, "Admin Quach Dai Loi", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 64, DateTimeKind.Unspecified).AddTicks(6510), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 400, new Guid("89c0d534-35c4-4bff-97e0-cd844ba8a67d"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3177), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.400", "Vehicle 400", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3178), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, 3 },
                    { 401, new Guid("d478e1ed-b1c2-4e47-b4aa-c64538f016ed"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3191), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.401", "Vehicle 401", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3192), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, 3 },
                    { 402, new Guid("892757b1-a5a9-447c-8e41-0cbe488f6177"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3196), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.402", "Vehicle 402", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3197), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, 3 },
                    { 403, new Guid("09fd7d22-7487-4454-93a5-ec5ea476e3c8"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3201), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.403", "Vehicle 403", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3202), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, 3 },
                    { 404, new Guid("31ca9710-5371-48ab-93a1-be9d0e093147"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3206), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.404", "Vehicle 404", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3206), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, 3 },
                    { 405, new Guid("13bd487d-8fbf-4368-9030-59f1824b5cdf"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.405", "Vehicle 405", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3212), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, 3 },
                    { 406, new Guid("80147d6d-b963-4b6d-88bb-85019559dd14"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3262), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.406", "Vehicle 406", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3263), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, 3 },
                    { 407, new Guid("8b3e350a-28e7-425b-9ee4-e85e4565ae6d"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3268), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.407", "Vehicle 407", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3269), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, 3 },
                    { 408, new Guid("59dc8085-4ce0-4b79-ab26-36b5ff08ddde"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.408", "Vehicle 408", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3273), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, 3 },
                    { 409, new Guid("67a6369d-1b57-4443-a452-cb0592842e93"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3277), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.409", "Vehicle 409", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3278), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, 3 },
                    { 410, new Guid("dd38df94-df1d-40cd-b574-8bb0768cffc8"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3282), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.410", "Vehicle 410", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3282), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, 3 },
                    { 411, new Guid("cc95c663-c997-4b0e-9b05-22cf37f5d5bd"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3286), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.411", "Vehicle 411", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3287), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, 3 },
                    { 412, new Guid("81457fa1-ba55-4a36-abdf-c6bd62783fcf"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3290), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.412", "Vehicle 412", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3291), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, 3 },
                    { 413, new Guid("4a145ffd-63b2-4c3c-aeab-6f685833ecf4"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3296), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.413", "Vehicle 413", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3297), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, 3 },
                    { 414, new Guid("1a3d72ba-71ac-4900-87da-6bca00d51d38"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.414", "Vehicle 414", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3303), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, 3 },
                    { 415, new Guid("bba252d4-e8c1-43f4-bb40-af35b5c70641"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3307), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.415", "Vehicle 415", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3308), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, 3 },
                    { 416, new Guid("76c5b9e2-0510-4e8a-9af9-36fd5bc11b5b"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3312), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.416", "Vehicle 416", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3312), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, 3 },
                    { 417, new Guid("28d37962-b64a-4b0b-b689-97304b2e1cfd"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3316), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.417", "Vehicle 417", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3317), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, 3 },
                    { 418, new Guid("a8fbcd4d-62e5-48e5-b0a2-501975dad8dd"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3320), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.418", "Vehicle 418", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3321), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, 3 },
                    { 419, new Guid("61d40d9e-e577-46ca-bacb-10c1801962a0"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3325), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.419", "Vehicle 419", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3326), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, 3 },
                    { 420, new Guid("b5c3f65d-9a63-4c5e-8959-87fc149d4c1d"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3329), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.420", "Vehicle 420", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3330), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, 3 },
                    { 421, new Guid("60185a4f-5442-4843-be0c-c703de65ab75"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3333), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.421", "Vehicle 421", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3334), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, 3 },
                    { 422, new Guid("8ce21bb1-98f2-4e3f-acc9-d7855abb92f4"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3340), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.422", "Vehicle 422", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3341), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, 3 },
                    { 423, new Guid("d8d090a9-669b-4327-bbfd-031ac087f6a7"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.423", "Vehicle 423", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3346), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, 3 },
                    { 424, new Guid("a4fe878b-fed7-46cb-b1ee-5660082409f1"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3349), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.424", "Vehicle 424", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3350), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, 3 },
                    { 425, new Guid("7a3f9aa8-4ed4-4152-b19d-b731236e3f3f"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.425", "Vehicle 425", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3354), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, 3 },
                    { 426, new Guid("b81523ca-4866-4914-b015-55adc283ee65"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3358), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.426", "Vehicle 426", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3359), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, 3 },
                    { 427, new Guid("71d253d1-2cb2-49fc-a5fb-04f0dd8b69f3"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3362), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.427", "Vehicle 427", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3363), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, 3 },
                    { 428, new Guid("871ddce8-c894-4bbb-b9f8-6dd4236f82ca"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3367), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.428", "Vehicle 428", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3367), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, 3 },
                    { 429, new Guid("eff2b0aa-e2fe-49ea-92dd-94bc1ebe5aa9"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3372), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.429", "Vehicle 429", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3373), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, 3 },
                    { 430, new Guid("5e49e5e8-d225-4d87-bebb-9ead7f875367"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3379), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.430", "Vehicle 430", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3380), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, 3 },
                    { 431, new Guid("701bf3a1-52b8-4583-acbc-eb846a9551e3"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3384), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.431", "Vehicle 431", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3385), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, 3 },
                    { 432, new Guid("8d43f904-501e-45af-ba81-d7a9b645e4c5"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3388), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.432", "Vehicle 432", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3389), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, 3 },
                    { 433, new Guid("70606e03-a8f9-4aa4-9df1-582e5157e83d"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3393), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.433", "Vehicle 433", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3393), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, 3 },
                    { 434, new Guid("7ec2eec7-87f3-4f90-a86a-467f9fa0fde6"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.434", "Vehicle 434", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3398), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, 3 },
                    { 435, new Guid("e0fc418e-7b4c-42df-902f-6ede59098cd8"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3401), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.435", "Vehicle 435", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3402), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, 3 },
                    { 436, new Guid("6dc5b53d-f101-4f64-9c32-28f292d15872"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3406), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.436", "Vehicle 436", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3406), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, 3 },
                    { 437, new Guid("0b0a25ba-9a2b-41f6-93ef-f576fdbb6ec7"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3470), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.437", "Vehicle 437", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3471), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, 3 },
                    { 438, new Guid("2616d39f-a98d-4d7e-b7cc-0071353e0e93"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3477), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.438", "Vehicle 438", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3478), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, 3 },
                    { 439, new Guid("f071538b-7b6e-449d-8a38-49431b943e82"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.439", "Vehicle 439", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3482), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, 3 },
                    { 440, new Guid("15bff57d-885c-43b4-bd40-33c7e1b4bf8b"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3486), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.440", "Vehicle 440", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3487), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, 3 },
                    { 441, new Guid("8aed2456-831d-4e6a-8254-4b6facaaaeb3"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3490), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.441", "Vehicle 441", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3491), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, 3 },
                    { 442, new Guid("0511cb11-4fa0-4390-ad41-da2bb811bc8b"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3494), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.442", "Vehicle 442", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3495), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, 3 },
                    { 443, new Guid("d3b69b1c-8f89-4b3c-951e-0e361da6c6e7"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3499), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.443", "Vehicle 443", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3499), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, 3 },
                    { 444, new Guid("a02362b0-d11e-48ff-a759-b6dcf583af5a"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3503), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.444", "Vehicle 444", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3504), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, 3 },
                    { 445, new Guid("6ca2eff5-4fe3-4884-b4d7-303e2ad06e9c"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3508), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.445", "Vehicle 445", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3508), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, 3 },
                    { 446, new Guid("9352ca50-eb3c-4525-92e9-5511238ac82f"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3515), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.446", "Vehicle 446", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3515), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, 3 },
                    { 447, new Guid("8c2b3fa2-8f26-42d8-8218-a7ba16bd2687"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3519), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.447", "Vehicle 447", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3520), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, 3 },
                    { 448, new Guid("57a1f2d0-a1d6-437b-9ddd-459752994b8e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3523), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.448", "Vehicle 448", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3524), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, 3 },
                    { 449, new Guid("08028db8-be89-46d3-9f49-1ad167d333dc"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3528), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.449", "Vehicle 449", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3528), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, 3 },
                    { 450, new Guid("124e8f7a-1c0d-4c7a-944b-445fbeaceef8"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3532), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.450", "Vehicle 450", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3533), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, 3 },
                    { 451, new Guid("ba38bb93-9fc6-485b-b81a-15f027fde6bc"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3536), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.451", "Vehicle 451", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3537), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, 3 },
                    { 452, new Guid("1fcda2c0-372c-4a44-b4e9-06302ebd6c7c"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3541), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.452", "Vehicle 452", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3541), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, 3 },
                    { 453, new Guid("b9e6817f-d10f-48e1-b283-c7bf9bc21c92"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3545), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.453", "Vehicle 453", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3546), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, 3 },
                    { 454, new Guid("255f377a-ae75-4cae-adee-e0cf6486a991"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3552), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.454", "Vehicle 454", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3553), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, 3 },
                    { 455, new Guid("cfbe830b-8a65-406b-b30e-960b7057bcf3"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3556), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.455", "Vehicle 455", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3557), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, 3 },
                    { 456, new Guid("42c267ce-39d9-4cd6-96a9-eb61b672fcea"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3561), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.456", "Vehicle 456", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3561), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, 3 },
                    { 457, new Guid("a8effcee-bdd5-4c7d-93e0-ad9fef4a4218"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3565), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.457", "Vehicle 457", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3566), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, 3 },
                    { 458, new Guid("2e94f1ad-1da3-4b7d-bfe0-58d6c34718f1"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3569), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.458", "Vehicle 458", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3570), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, 3 },
                    { 459, new Guid("5f914cc5-faa8-4125-9f91-93a2d5839ae3"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3573), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.459", "Vehicle 459", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3574), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, 3 },
                    { 460, new Guid("2568467c-5c50-4188-a214-dc0cfa05e098"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3578), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.460", "Vehicle 460", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3579), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, 3 },
                    { 461, new Guid("10d2b8bc-9ac4-4f1c-9e38-8683c59ef132"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3584), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.461", "Vehicle 461", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3585), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, 3 },
                    { 462, new Guid("d3e1a805-2e2d-424d-93c2-190e6d8fd023"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3591), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.462", "Vehicle 462", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3591), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, 3 },
                    { 463, new Guid("b9000391-f546-48a3-b58c-914987245ac3"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3595), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.463", "Vehicle 463", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3596), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, 3 },
                    { 464, new Guid("9bd38ef8-393d-4d91-8066-d560d30a10ca"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3599), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.464", "Vehicle 464", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3600), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, 3 },
                    { 465, new Guid("73f9a3cd-9c43-430d-9161-2602cc3875d6"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3604), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.465", "Vehicle 465", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3604), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, 3 },
                    { 466, new Guid("cc526b27-494b-46e7-86b9-2a75d66ef1e8"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3608), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.466", "Vehicle 466", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3609), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, 3 },
                    { 467, new Guid("152b585c-777e-4bb7-9a07-a3b3ddbb56a3"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4512), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.467", "Vehicle 467", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4515), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, 3 },
                    { 468, new Guid("a93649ef-83e3-4ca3-bae0-2d74de0a4fd5"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4520), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.468", "Vehicle 468", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4520), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, 3 },
                    { 469, new Guid("f6f6f06c-0577-43b8-a6a2-246585af3fd9"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4524), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.469", "Vehicle 469", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4525), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, 3 },
                    { 470, new Guid("b5974bda-a50b-4583-a7c6-e46c07905597"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4532), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.470", "Vehicle 470", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4533), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, 3 },
                    { 471, new Guid("10482aac-1a62-43fc-9097-ab3a7f9a5923"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4536), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.471", "Vehicle 471", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4537), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, 3 },
                    { 472, new Guid("79c09f12-9671-4059-bd90-57a43eb96aef"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4541), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.472", "Vehicle 472", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4542), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, 3 },
                    { 473, new Guid("54ddf9af-d8e5-4e39-8544-4b001e2e1fe3"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4546), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.473", "Vehicle 473", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4546), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, 3 },
                    { 474, new Guid("b703e357-bd10-42b4-9209-91e5ca50c1f4"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4550), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.474", "Vehicle 474", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4551), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, 3 },
                    { 475, new Guid("1c9a4eca-dcf2-4b05-875d-ae83ae04e1ae"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4555), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.475", "Vehicle 475", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4555), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, 3 },
                    { 476, new Guid("b9b18fbf-f6a3-4383-8765-54b45733327b"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4559), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.476", "Vehicle 476", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4560), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, 3 },
                    { 477, new Guid("eedc74d1-41a8-49be-9e4e-5ef19ef79202"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4563), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.477", "Vehicle 477", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4564), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, 3 },
                    { 478, new Guid("1b03da82-edcd-4a93-9fd0-0d7abc40daf4"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4570), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.478", "Vehicle 478", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4571), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, 3 },
                    { 479, new Guid("b06c7720-5bc9-4a78-8789-4001c588bb76"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4575), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.479", "Vehicle 479", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4576), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, 3 },
                    { 480, new Guid("36065153-2aa8-4d0d-ae7f-167a618f2849"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4580), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.480", "Vehicle 480", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4581), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, 3 },
                    { 481, new Guid("c42dc361-ed49-4aac-b3be-9f46d38701c1"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4584), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.481", "Vehicle 481", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4585), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, 3 },
                    { 482, new Guid("c7351923-c7aa-460b-99c2-55e3efe4f04c"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4589), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.482", "Vehicle 482", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4590), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, 3 },
                    { 483, new Guid("cf103ef6-f664-4f93-aa03-2b233cad3d02"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4593), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.483", "Vehicle 483", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4594), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, 3 },
                    { 484, new Guid("f48f56dd-f92f-462f-a005-8ef1431b8668"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4598), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.484", "Vehicle 484", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4598), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, 3 },
                    { 485, new Guid("04cc0cc3-934b-4c7f-9c54-e4890fbff12c"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4602), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.485", "Vehicle 485", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4603), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, 3 },
                    { 486, new Guid("ccfe60b7-b4e6-4068-9aaa-57c86223cbd4"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4609), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.486", "Vehicle 486", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4610), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, 3 },
                    { 487, new Guid("8d8e630f-ab17-4c77-88f9-89a1627e00d4"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4614), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.487", "Vehicle 487", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4614), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, 3 },
                    { 488, new Guid("0b9adfae-13ca-47c8-8771-295e0681ab46"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4618), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.488", "Vehicle 488", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4619), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, 3 },
                    { 489, new Guid("8b0fa3bd-65d9-4cf3-9d83-8a92d2daa43e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4622), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.489", "Vehicle 489", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4623), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, 3 },
                    { 490, new Guid("b5c6c764-cb08-4c6b-ae4d-44c93d33c85f"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4627), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.490", "Vehicle 490", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4628), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, 3 },
                    { 491, new Guid("fc06f3f6-a035-475c-9456-1452a0f65fa4"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4632), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.491", "Vehicle 491", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4632), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, 3 },
                    { 492, new Guid("c47d1cd6-e749-4d01-badd-0cdef9ecc64f"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4636), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.492", "Vehicle 492", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4637), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, 3 },
                    { 493, new Guid("53053d6e-e387-4a8d-809a-3144ddc40aca"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4640), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.493", "Vehicle 493", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4641), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, 3 },
                    { 494, new Guid("1af6b439-9414-4813-90f0-cb27a93dcf00"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4648), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.494", "Vehicle 494", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4648), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, 3 },
                    { 495, new Guid("02377324-14a7-4d9a-901f-41f1d28472fb"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4652), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.495", "Vehicle 495", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4653), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, 3 },
                    { 496, new Guid("b6e14eb0-ed22-472a-9e4a-516507239049"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4656), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.496", "Vehicle 496", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4657), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, 3 },
                    { 497, new Guid("0795c18f-9643-437e-9995-857b37485943"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4661), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.497", "Vehicle 497", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4661), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, 3 },
                    { 498, new Guid("71556439-1821-4db2-a2e2-b236572ce54a"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4665), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.498", "Vehicle 498", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4666), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, 3 },
                    { 499, new Guid("27277a53-c261-4f70-9abf-ddcd697ed94c"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4670), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.499", "Vehicle 499", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4670), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, 3 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3015), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3016), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3033), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3034), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3045), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3046), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3058), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3059), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3070), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3070), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3083), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3084), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3095), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3096), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3106), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3107), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3168), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3181), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3182), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3192), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3192), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3202), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3203), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3213), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3214), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3224), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3225), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3235), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3236), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3246), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3247), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3258), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3259), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3270), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 65, DateTimeKind.Unspecified).AddTicks(3271), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "ceiling_extra_price", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2911), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2912), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2975), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2985), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2986), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2995), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2996), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3005), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3006), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3016), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3017), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3026), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3027), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3036), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3037), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3074), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3074), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3086), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3087), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3096), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3096), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3105), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3106), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3115), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3116), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1870), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(1871), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2007), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2008), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2138), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2139), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2204), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2205), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2229), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2230), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2251), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2252), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2272), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(2273), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, new Guid("96ce5d3e-d948-4aaf-af52-7c4f65dad81e"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3158), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3159), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("21291aeb-5ff4-485c-b63e-ca12ac85e342"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3165), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3165), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("45e3c282-8063-44e0-b954-c4984c3c7128"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3171), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3172), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("209ba8a9-2aa9-4973-9f24-fccd28cd5d2d"), new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(3174), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "type", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 0.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4866), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4867), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 0.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4872), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4873), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 0.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4875), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4875), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 0.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4877), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4877), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 0.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4880), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 0.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4882), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4883), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 0.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4885), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4885), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 0.0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4887), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 19, 2, 42, 50, 66, DateTimeKind.Unspecified).AddTicks(4888), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
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
                name: "IX_reports_code",
                table: "reports",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_reports_user_id",
                table: "reports",
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
                name: "reports");

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
