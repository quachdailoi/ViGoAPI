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
                name: "license_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_license_types", x => x.id);
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("dc068c8e-1642-45cf-8800-223ce0e4a192")),
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
                    name = table.Column<string>(type: "text", nullable: false),
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
                    id = table.Column<int>(type: "integer", nullable: false),
                    code = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    slot = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false, defaultValue: 1)
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
                    expired_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
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
                name: "user_licenses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    front_side_file_id = table.Column<int>(type: "integer", nullable: false),
                    back_side_file_id = table.Column<int>(type: "integer", nullable: false),
                    license_type_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_licenses", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_licenses_files_back_side_file_id",
                        column: x => x.back_side_file_id,
                        principalTable: "files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_licenses_files_front_side_file_id",
                        column: x => x.front_side_file_id,
                        principalTable: "files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_licenses_license_types_license_type_id",
                        column: x => x.license_type_id,
                        principalTable: "license_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_licenses_users_user_id",
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 597, DateTimeKind.Unspecified).AddTicks(7545), new TimeSpan(0, 7, 0, 0, 0))),
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("06fb83b2-9736-4d0d-96dd-4de5845a2480")),
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
                    { 1, new Guid("e0c2c083-d7f4-4cd9-8a54-c7e4929e1307"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3350), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3351), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("96169ede-2ef4-4060-ba38-f2eb5d62e936"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3357), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3357), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("f2e54ab2-73b8-4a35-ae15-3c0ebfb26170"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3355), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "events",
                columns: new[] { "id", "content", "status", "title", "type" },
                values: new object[,]
                {
                    { 1, "The process of finding drivers for your booking is done. Don't worry if there is not any trips without driver, we continue to find driver for you. A trip without driver will be refunded on 20:00 of the day before the trip occurs.", 1, "FINDING DRIVER IS DONE", 0 },
                    { 2, "Thanks for using our service, your booking is in the process of finding drivers.", 1, "BOOKING WAS PAID SUCCESSFULLY", 0 },
                    { 3, "There's not any suitable drivers for your next trip, sorry for this omission. We will refund for it.", 1, "NOT FOUND ANY DRIVERS FOR YOUR NEXT TRIP", 0 },
                    { 4, "Your driver has problem and he/she cannot come to pick you up, sorry for this omission. We will refund for it.", 1, "YOUR DRIVER HAS PROBLEM", 0 },
                    { 5, "Hot voucher is waiting for you. Use now lest miss it.", 1, "YOU HAVE A VOUCHER", 0 },
                    { 6, "Your driver is on the way to pick you up, get ready please.", 1, "DRIVER IS COMING", 0 },
                    { 7, "Have a nice trip. Wish you have a good experience in your trip.", 1, "TRIP BEGINS", 0 },
                    { 8, "You have arrived, see you again in a next trip. Thanks for using our service.", 1, "TRIP COMPLETED", 0 },
                    { 9, "You receive a new rating and feedback. Click for details.", 1, "NEW RATING AND FEEDBACK", 0 },
                    { 10, "Today, you have trip(s) to complete. Good luck.", 1, "DON'T FORGET TODAY TRIP", 0 },
                    { 11, "We have refunded for you successfully.", 1, "REFUND COMPLETE", 0 },
                    { 12, "Be careful with the rate of cancelled trip, you reach 80% of permission of cancelled trip rate.", 1, "BE CAUTIONS!!!", 0 },
                    { 13, "You reach the limit of permission of cannceled trip rate, you were banned now. Contact with our office for handling this problem.", 1, "YOU WERE BANNED!!!", 0 },
                    { 14, "You have new trip at this time, please check your schedule today.", 1, "NEW TRIP", 0 },
                    { 15, "You have received your earning for completed trip.", 1, "TRIP INCOME", 0 },
                    { 16, "You have received new report that need to processing.", 1, "NEW REPORT", 0 },
                    { 17, "Booker canceled your trips, don't worry we will find new trip for you.", 1, "BOOKER CANCEL YOUR TRIP", 0 }
                });

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "path", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("2897d0a9-cb68-4bb5-a14c-a4bdf2da015a"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(3943), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(3964), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("fe778fde-83f9-441e-85df-a76472e40efb"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(3976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(3977), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("8d0f7517-27ea-4d7e-8374-48d43d8eb2dc"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(3986), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(3986), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("4d500bb5-73e0-4e2d-9df0-7212a0325eed"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(3994), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(3995), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("598763d7-05b5-4e98-8a19-1537100bf552"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4003), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4003), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("52cfc459-367a-4177-a52e-ba0f3b2fd3e6"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4013), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4014), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("0db0ff80-33ff-4924-b0be-48542f8af397"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4035), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4036), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("d6e7fb19-1826-4294-ab72-250019de91d5"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4043), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4044), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("c316ce84-ac37-4297-962c-2b3d2c3f1d96"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4053), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4053), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("cd1c1ce9-66b0-4177-86e7-af9e94bfcc70"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4064), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4064), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("eef7ad69-c16b-4157-a734-19ea7153e10e"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4072), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4072), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("2a74c153-3965-41dc-89fe-68d583244541"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4080), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4080), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("6cae3ff9-fd69-4930-a5ba-54df0d35d34a"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4088), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4088), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, new Guid("6b96141e-8eac-4ea2-bb53-6b4b79b7a6ea"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4096), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 4, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4096), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, new Guid("94e912c8-9713-4ac3-9419-74df59e7e120"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4106), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 5, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4107), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, new Guid("7f71016a-d8e2-4fbd-abff-a95467a12ce3"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4114), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 6, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4114), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, new Guid("3b01e9b1-65f2-4887-a63a-857f7e53b754"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4122), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 7, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4123), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, new Guid("5edf5f6e-47fc-43c5-93f9-7c5895d3258c"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4161), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 8, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4162), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, new Guid("6398224e-177e-4b3a-a847-56285dd4bd2c"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 9, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4171), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "license_types",
                columns: new[] { "id", "code", "name" },
                values: new object[,]
                {
                    { 1, new Guid("84b3028b-3498-4377-8410-722db5002d62"), "Identification" },
                    { 2, new Guid("073e809d-34d6-4954-82e6-f7e392d3d858"), "Driver License" },
                    { 3, new Guid("3ecc2a7a-32ff-4f2c-b3a7-f0425b46d96a"), "Vehicle Registration Certificate" }
                });

            migrationBuilder.InsertData(
                table: "pricings",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "discount", "lower_bound", "updated_at", "updated_by", "upper_bound" },
                values: new object[,]
                {
                    { 1, new Guid("fc33d17c-298e-4cdd-ba56-369626d6b590"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3479), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.0, null, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3480), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 2, new Guid("c2ae50f3-b706-4248-9140-234a3bff8b91"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3488), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.029999999999999999, 8, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3489), new TimeSpan(0, 7, 0, 0, 0)), 0, 30 },
                    { 3, new Guid("cff2caf9-0f95-4686-8384-8fcc040384e6"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3490), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.050000000000000003, 31, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3491), new TimeSpan(0, 7, 0, 0, 0)), 0, 90 },
                    { 4, new Guid("5b5863d1-d833-40e9-879a-2c5bdc18bad2"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3492), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.070000000000000007, 91, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3493), new TimeSpan(0, 7, 0, 0, 0)), 0, null }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1920), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1921), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1928), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1929), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1936), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1936), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 23, "TradeDisountForBookerCancelTrip", 4, "0.1" },
                    { 24, "DriverRegistrationFileSizeLimit", null, "20" },
                    { 25, "BannerFileSizeLimit", null, "20" },
                    { 26, "PromotionFileSizeLimit", null, "20" }
                });

            migrationBuilder.InsertData(
                table: "stations",
                columns: new[] { "id", "address", "code", "created_at", "created_by", "deleted_at", "latitude", "longitude", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("52ca1cf2-3fcc-44ba-bfb4-1351fa4a9571"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2261), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2262), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f54719ac-c2a1-4a18-b07d-3eae5f22d831"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2267), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fb116a43-5b39-4535-a7d4-802a4fd8d9e6"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2269), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2269), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8b1b9afd-57c1-4c06-9a0e-dcab224026be"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2274), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2275), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e78ec477-f752-424c-8493-9896b95db425"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2277), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2277), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("454a1195-cdf4-44a9-bfd4-c8c0803e843d"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2280), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("14cb1af7-a9b7-4cca-b8ac-a38865ceae03"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2282), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2283), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("501d16f7-0fe5-49b2-b036-11853d065796"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2285), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2285), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("21cb8473-1dfa-4101-ab0f-de7d4f5f1889"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2287), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2287), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("31b57515-0e00-4de6-84fd-62d61aeac7ba"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2290), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ca528f78-7bc9-49aa-a500-c6c5d01b31eb"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2292), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2292), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1591a2a1-fc41-4909-9af6-4e22badfeb54"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2295), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2296), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2c835c50-dcab-4a17-8123-874d5f05e7b7"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2298), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2298), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("1788f913-039a-4875-80d4-9725f36f315a"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2300), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2301), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4c01e188-13b4-4628-9305-22d1b3b956cf"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2303), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c19e9aa7-0d57-4d98-843f-f8be79a1987a"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2304), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2305), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("22b7b00b-e13d-4ac2-848e-54a9ef2b45f1"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2306), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2307), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4019f4c9-148a-4b96-b522-39f1969fd426"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2309), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2310), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("35c6df4e-571e-4e4d-99f6-1cae30305383"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2311), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2312), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("17eae9ad-dbca-4bb7-8552-66c2563adf4c"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2315), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2315), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("11f24b68-e742-4ce2-bd23-4a7d2fe56d16"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2318), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f136c7c7-6a09-411b-b481-00c246815f2c"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2319), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2320), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("43a5289f-10b5-41ff-9abb-0b76e6ca223d"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2324), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2325), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d3c95bce-c536-4c2b-bedc-77cee9c5fec3"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2327), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2327), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f42267d1-b229-4347-b3fe-63962ec4c438"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2329), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2329), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5ac926e1-6cd3-4e49-9ac6-fc3d34767b18"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2331), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2331), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b2a22c31-dcd2-4df4-af08-f61b99769dab"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2334), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2335), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bb920871-a5d0-4fb1-9d4b-f8c65a9b873a"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2337), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2337), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5c6564d6-053c-454b-83a4-e3d0e46b8716"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2339), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2339), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f7f8c961-b85e-46c9-aa24-3981f9fcff69"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2341), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2341), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c67e7fd3-62ee-4e84-936a-cd970667d9b6"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2343), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2343), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c8037f3c-aba4-4a37-b0d9-e2a5653a9260"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2345), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d6ba2bb2-4679-44ac-b04e-fa6ffabfd20c"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2370), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2371), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a71898b1-acd6-43b1-be07-25dd90d2636b"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2372), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2373), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3e7daf27-43fd-49fd-abd5-11c55bc551b6"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2376), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2377), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a1799d9d-ae9a-4716-8ce7-c69b16e95864"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2379), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("496ce18a-e2f2-4515-adda-535dedddca2a"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2381), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("16298a8e-d6d5-47c3-b771-1e4e5dbacaae"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2382), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2383), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("eb4854ab-5fbd-4eff-b7ba-ffefdfe6ae85"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2384), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2385), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("64520065-dfea-4a11-9874-19d49816d14a"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2386), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2387), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9c2c2690-cb29-4e1a-8912-b3abc854f143"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2388), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2389), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("231b94b2-e68c-4b57-86ad-09855dab5e26"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2391), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2391), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("4e3c174f-319c-4367-b258-c49131dd5d47"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2395), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2395), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("06ce19f2-fb77-4ec5-98d5-ee266819b71a"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2397), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5903a88c-841b-48ce-acb9-947f16dff3c2"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2400), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2400), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("07b26cbe-3c9e-4fc4-a703-d50faa448ce2"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2402), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2402), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f82d902c-0cd9-4382-af45-386ca59de62a"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2404), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dd3650d3-793d-4566-9acc-113f334f19e8"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2406), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2406), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3521bea3-988f-497f-b8f4-ddbc31a29bb0"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2409), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2410), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0aa412bb-4694-4f60-91a4-968209e60ad2"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2412), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a8e8b0e5-e908-4987-a5cd-4e58eac58835"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2415), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2416), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b125baa9-09db-4fc4-bc98-8a39c46c4838"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2417), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2418), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bff0866e-d028-412d-8cd9-d00b489f953e"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2420), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2420), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4cd9da8d-139a-4854-bc7a-e4ea0b23f9bc"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2422), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2422), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bfa2aed0-ef6a-4c53-b936-e29baebabe53"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2425), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2425), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9a90c520-3ca5-41f5-a420-d9b8dea86748"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2427), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2427), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0af10e9d-cbdc-4170-a59f-4c14f708d509"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2429), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2430), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e7621ca4-7dfd-48b8-8ef0-57585306214a"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2431), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2432), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("58138080-9a65-4839-9b25-e02cc162fc06"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2435), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2435), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d95fbdba-bb43-45dc-aef1-09c2e0ebb691"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2437), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2437), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cb9cf738-806a-4391-a176-db346ddcc16e"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2439), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2439), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("33f34637-e0bf-4e0a-b02d-47a7c1d47f95"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2441), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2442), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("befad4b7-a402-45f6-a5cb-767ddb27be4d"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2443), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2444), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("25b81fbc-5c2b-4561-b4ef-da8d13c21c5e"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2445), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2446), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bff327f2-6601-4def-9a66-17c292e3d46f"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2448), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2449), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("58e98181-9f30-4736-b6b1-5174df719ebe"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2451), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2451), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("80ddfc3e-fa83-4966-b85c-1f42a62c0d07"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2454), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2455), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b534704f-b497-4de0-a5fc-1d3345eff6c5"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2457), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2457), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b04bfab7-a672-4823-8714-2299d77654fa"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2483), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2484), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3e81feb7-2743-46b2-8dae-426dfec78bb5"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2485), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2486), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("ceead459-b1f0-43ce-8e2b-e8ed0be0e322"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2488), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2488), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0891d6e4-efab-4d71-b95e-39e97dc8fac0"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2490), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2490), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1685b4e6-a47c-46fe-b118-e4b0c1a7bd95"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2492), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2492), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b1d439f0-5bf5-4797-bec5-66f2fdf02d3c"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2494), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2494), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cc5e866a-390f-4d0f-87f8-a813ca6f4986"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2498), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2498), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5b17f06c-24ea-4a3d-a5e7-839eed42ef26"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2500), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2501), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e8764b52-a519-49da-947c-fc9adb0c2d8a"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2502), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2503), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9061f8a6-4fed-4042-b2ac-a55dabf0a58d"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2504), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2505), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a0aa5a13-7d8e-4425-aa88-c86da4ca5e7c"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2506), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2507), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("5e4a75f9-6d32-44f0-a3de-7e313366a7cf"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2508), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2509), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("f904d84d-9273-486b-9011-ad17202214d4"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2511), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("9f91df2d-17b1-493a-84d7-727afb40a634"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2512), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2513), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("da95e8d1-fc8b-4fee-b1e4-df1fcd283ce9"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2516), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2517), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("f5827c4b-367c-4573-8dc2-b63465a4b2a6"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2518), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2519), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e11efcd4-f2cd-44cf-a9dd-ef9a32f450f0"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2322), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2323), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô E2a-10 Đường, D2b Đ. D1, TP. Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam", new Guid("6522460c-f756-42a1-9c83-d1b26619d374"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2520), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2521), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trip_rate", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "rating", "status", "suddenly_cancelled_trips", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 10, 0.0, new Guid("62a3eab5-04ba-43a0-a6d1-c687847d09b0"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4346), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4350), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Admin Than Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4347), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 0.0, new Guid("801b1b28-6602-4730-9ee0-81a4a3e2bc44"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4362), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4364), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Admin Nguyen Dang Khoa", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4363), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 0.0, new Guid("dfd77e37-d59f-496a-9803-28ef9b6f24c9"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4374), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4376), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Admin Do Trong Dat", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4374), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 100, 0.0, new Guid("ddbbd469-ca20-4753-8f9c-e82fecace7bc"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4386), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4400), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 100", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4387), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 101, 0.0, new Guid("a19adf81-1922-41b3-b4f5-4007261cc070"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4411), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4416), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 101", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4412), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 102, 0.0, new Guid("a0178376-b80c-4230-a681-8b20e1e4a41a"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4426), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4428), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 102", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4426), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 103, 0.0, new Guid("883ddc61-5e34-42e1-9de4-9f88b660f275"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4438), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4441), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 103", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4439), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 104, 0.0, new Guid("6505b5d7-1ea6-41ef-b3d7-4d9064c809f5"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4451), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4453), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 104", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4451), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 105, 0.0, new Guid("5878dd8f-d052-495f-926e-b84bb5a6d6f1"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4464), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4469), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 105", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4465), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 106, 0.0, new Guid("6bf48c93-9c80-4424-ae9e-d8f77c25abdf"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4482), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4485), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 106", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4483), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 107, 0.0, new Guid("dac28799-48cf-4cf6-a046-2e9400a9a7af"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4494), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4497), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 107", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4495), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 108, 0.0, new Guid("7a3d3efb-3808-4547-a800-45b0181ac119"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4532), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4535), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 108", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4532), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 109, 0.0, new Guid("80278b48-ab58-4d9a-bfa3-d2f3cf1d0892"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4545), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4549), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 109", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4546), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 110, 0.0, new Guid("b9edb322-c1a2-49ce-b967-b6fe5f0ab66d"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4559), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4562), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 110", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4560), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 111, 0.0, new Guid("5f0d2f92-0682-44be-be5d-db710fa83535"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4571), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4574), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 111", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4572), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 112, 0.0, new Guid("980f7e22-602f-45e6-af99-483c9bbd9734"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4583), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4586), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 112", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4584), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 113, 0.0, new Guid("a9d16b7c-c800-4d5e-ae39-18741cb99601"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4595), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4599), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 113", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4595), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 114, 0.0, new Guid("d37634c1-4a40-4bc0-9ec3-5a8bfa1f98ec"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4608), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4611), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 114", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4609), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 115, 0.0, new Guid("a425e1fe-b7ed-4ec0-b369-b7ca6e19720b"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4620), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4623), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 115", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4621), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 116, 0.0, new Guid("e0886f52-88ad-48fc-a7fc-5ebfa5f47e6d"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4633), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4635), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 116", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4633), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 117, 0.0, new Guid("3349adc0-8c36-49ff-b0ec-892ebbe3a1f9"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4645), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4852), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 117", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4645), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 118, 0.0, new Guid("4f53c55b-1d87-481f-907d-5def5b1b3ab3"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4887), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4891), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 118", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4888), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 119, 0.0, new Guid("75175fd7-61a7-4e6e-9a4e-4bf9844bad8a"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4902), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4905), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 119", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4903), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 120, 0.0, new Guid("1d9303ba-3e3a-4d2c-ad98-e102d2d23472"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4915), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4918), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 120", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4916), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 121, 0.0, new Guid("a0556096-a739-4e56-8b34-6e0eacaa5776"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4949), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4957), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 121", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4950), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 122, 0.0, new Guid("ce8e2d67-4acb-4c14-a5b5-3cfe7722e64e"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4974), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4980), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 122", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4976), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 123, 0.0, new Guid("b0834710-8779-4779-a23b-ff0eb3930b10"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4997), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5003), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 123", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4998), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 124, 0.0, new Guid("966213f5-b0f2-4391-8dab-3c0e9753dde4"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5015), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5017), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 124", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5016), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 125, 0.0, new Guid("2ab202f9-1f02-475a-bcc5-0e93f4ff0f9e"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5027), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5032), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 125", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5028), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 126, 0.0, new Guid("93c41c2e-c581-41e9-89fe-c37a37d27df5"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5041), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5044), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 126", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5042), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 127, 0.0, new Guid("1201a659-44ae-4dca-96d4-cfd860138587"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5054), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5056), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 127", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5054), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 128, 0.0, new Guid("44e67f64-78a7-4bbb-b911-e8d35515e30c"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5066), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5134), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 128", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5066), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 129, 0.0, new Guid("a0d75888-438a-4ebf-bcec-e8ca893ca5e3"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5148), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5154), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 129", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5149), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 130, 0.0, new Guid("7de21fbd-ab79-4f58-87ea-14b050ff2533"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5165), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5316), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 130", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5165), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 131, 0.0, new Guid("1b091297-7b9a-41bf-890e-97123ba0c9f0"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5328), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5330), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 131", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5328), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 132, 0.0, new Guid("09a86185-a7e7-4b66-9c6c-ea6afec1b788"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5340), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5343), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 132", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5341), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 133, 0.0, new Guid("1b2f2759-9828-444f-97b5-be3753bb7d29"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5352), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5356), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 133", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5353), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 134, 0.0, new Guid("21c674ed-8c8c-4d4f-a734-d4f8a217916e"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5366), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5369), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 134", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5367), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 135, 0.0, new Guid("3b68acc6-a060-4ce8-8502-23252b477191"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5378), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5380), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 135", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5378), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 136, 0.0, new Guid("87dd7b59-bfaa-41f5-acb5-eee15b3d19ae"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5389), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5392), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 136", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5390), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 137, 0.0, new Guid("517ca448-8e1d-4e1d-86f8-609b1377b21f"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5401), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5405), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 137", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5402), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 138, 0.0, new Guid("abd0356a-fef6-428d-8b02-ec23d2e03184"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5415), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5418), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 138", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5416), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 139, 0.0, new Guid("51f53dba-2469-407b-bcbd-fcc895df6c4b"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5451), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5454), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 139", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5452), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 140, 0.0, new Guid("57003d41-904a-4e2d-a9d0-f634bce1c3c3"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5465), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5468), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 140", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5466), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 141, 0.0, new Guid("55234263-aa04-4b22-9069-45d1a6a51106"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5477), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5482), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 141", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5478), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 142, 0.0, new Guid("5c4361b7-8fa2-4fd7-840b-dded59ded38f"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5491), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5494), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 142", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5492), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 143, 0.0, new Guid("39fc4cd2-ee71-43f8-a976-63e5ff3a6df2"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5503), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5506), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 143", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5504), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 144, 0.0, new Guid("18eff629-0517-4e9f-a089-685f43dc81fd"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5515), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5518), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 144", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5516), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 145, 0.0, new Guid("c9d9b866-83ce-45c9-89b4-7efc33c48af5"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5527), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5532), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 145", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5528), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 146, 0.0, new Guid("e2d66cc3-125b-43de-a655-a876cb12d28b"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5541), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5544), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 146", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5542), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 147, 0.0, new Guid("0323b503-3746-4f8d-bc5d-a24f6bfd61ff"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5553), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5556), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 147", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5554), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 148, 0.0, new Guid("7c69f79b-3297-4d6c-948c-07f5f2835910"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5565), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5568), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 148", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5566), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 149, 0.0, new Guid("2f3ff2ad-3fd6-46b6-bfd7-31fe743d775d"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5577), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5581), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 149", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5578), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 150, 0.0, new Guid("4c913f06-d25d-47b4-bc42-060d7628caa8"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5613), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5616), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 150", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5614), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 151, 0.0, new Guid("a7483a3d-10b5-4af7-8954-07b3329a24db"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5627), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5630), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 151", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5628), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 152, 0.0, new Guid("4a2d6739-7004-4075-87f4-a66fa928b0be"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5639), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5642), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 152", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5640), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 153, 0.0, new Guid("78576cc9-7d00-4e58-aa31-5332a19abf56"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5654), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5659), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 153", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5655), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 154, 0.0, new Guid("de499a72-469c-4127-a48f-d4ca2ebf0af8"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5669), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5671), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 154", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5669), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 155, 0.0, new Guid("f39075a3-98f0-4a81-b4a3-7f887ec54942"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5681), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5684), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 155", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5682), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 156, 0.0, new Guid("da04f01c-5a93-4621-b975-549813b85f6b"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5693), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5696), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 156", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5694), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 157, 0.0, new Guid("257170a9-4f88-4b11-a710-5315b9fc8b19"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5705), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5709), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 157", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5706), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 158, 0.0, new Guid("a12e95e3-02fd-4e88-8a7b-914cd1bd59a1"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5718), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5721), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 158", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5719), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 159, 0.0, new Guid("bd2a2494-fdcb-4318-bd41-6fc0fbad1d1f"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5752), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5756), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 159", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5753), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 160, 0.0, new Guid("1e4f7836-6ef2-454a-82a5-832e1959b036"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5766), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5769), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 160", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5767), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 161, 0.0, new Guid("be32b560-8ebf-4b62-8dd8-173b516f138d"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5779), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5783), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 161", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5780), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 162, 0.0, new Guid("bfee7e7f-005f-4ada-bfc6-bb026a921b97"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5793), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5796), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 162", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5794), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 163, 0.0, new Guid("e37879ea-3c29-42a2-a429-e7dffd3b4a93"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5805), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 163", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5806), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 164, 0.0, new Guid("a4d7ba09-2b89-406c-87eb-45a0ec806844"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5817), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5820), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 164", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5817), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 165, 0.0, new Guid("110d1cd0-0469-4374-aaa5-1e4548f29449"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5829), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5833), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 165", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5829), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 166, 0.0, new Guid("dc356597-3538-48c4-b90e-0315b735ce35"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5842), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5845), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 166", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5843), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 167, 0.0, new Guid("e5bf14d1-af45-4618-a9ef-e54d186a58a6"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5854), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5857), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 167", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5855), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 168, 0.0, new Guid("98488df9-f2d0-4ace-a9d2-1305c6284824"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5866), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5869), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 168", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5867), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 169, 0.0, new Guid("196718c8-db7a-49d0-948a-c1e6c5ed43f8"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5878), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5883), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 169", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5879), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 170, 0.0, new Guid("6b97df13-f20d-4295-8e6a-c41294101c5d"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5916), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5919), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 170", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5917), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 171, 0.0, new Guid("2da56b38-ea73-4495-8786-b61f148627f6"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5929), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5932), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 171", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5930), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 172, 0.0, new Guid("b0355b08-0c89-4bd7-b9cd-f067095ccb37"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5941), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5944), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 172", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5942), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 173, 0.0, new Guid("d0a7cf3a-42ab-4a80-b18a-72867f8ba861"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5954), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5958), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 173", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5954), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 174, 0.0, new Guid("f44d0042-74ea-42d9-a35d-32c51a7e5878"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5968), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5970), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 174", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5968), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 175, 0.0, new Guid("80b29164-9c31-4413-bb8e-6cc4766d6008"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5980), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5982), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 175", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5980), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 176, 0.0, new Guid("007557bb-79f4-4645-aa8e-4b3b818f907d"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5992), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5994), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 176", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(5992), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 177, 0.0, new Guid("7fd6dfeb-aa73-48e7-96bb-48188f56bc9e"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6003), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6008), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 177", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6004), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 178, 0.0, new Guid("382ec42d-c538-44a3-a21f-e902e310dbcc"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6017), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6020), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 178", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6018), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 179, 0.0, new Guid("c7504724-71b7-451a-b28d-37515e117313"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6029), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6032), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 179", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6030), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 180, 0.0, new Guid("5b151389-9e5a-400d-95e4-59b885c6047d"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6041), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6044), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 180", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6042), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 181, 0.0, new Guid("f53aa8a0-3975-485a-ae5b-f5895cd99e48"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6077), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6082), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 181", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6078), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 182, 0.0, new Guid("a9219d50-8a29-4e06-a618-0d33cbe0bc94"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6092), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6095), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 182", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6093), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 183, 0.0, new Guid("06cbd3b0-3db1-4ba2-9dbc-bc36bdda8745"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6105), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6107), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 183", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6105), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 184, 0.0, new Guid("8747b708-8024-4cc1-be95-a13e870f76a1"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6117), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6120), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 184", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6118), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 185, 0.0, new Guid("05875561-1df4-40c0-81a6-74e40c607339"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6129), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6133), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 185", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6129), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 186, 0.0, new Guid("9f666362-ad66-43a5-bff8-eb37c0b90553"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6143), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6145), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 186", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6143), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 187, 0.0, new Guid("4840cc71-aabf-4ca8-9384-e55a9c9e56bf"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6155), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6157), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 187", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6155), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 188, 0.0, new Guid("aae79538-6cde-43b9-9ccf-2792f456f6c5"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6166), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6169), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 188", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6167), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 189, 0.0, new Guid("b99b0c93-d749-4ca0-b782-84f9e127abcf"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6179), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6183), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 189", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6179), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 190, 0.0, new Guid("fe79d66a-3188-4496-b277-d71130632166"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6192), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6195), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 190", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6193), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 191, 0.0, new Guid("fdcbab8b-4c71-4967-879b-8c93f0794528"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6204), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6207), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 191", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6205), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 192, 0.0, new Guid("77034257-a54b-4eae-ac78-951f925322bc"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6240), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6243), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 192", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6240), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 193, 0.0, new Guid("5f523e20-54e2-4545-af84-5579940302b3"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6252), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6257), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 193", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6253), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 194, 0.0, new Guid("682bd485-e63c-44a4-afbf-cae23945ac85"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6266), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6269), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 194", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6267), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 195, 0.0, new Guid("e341840e-ea09-4e87-bc73-90e25ce3810d"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6279), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6282), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 195", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6279), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 196, 0.0, new Guid("e9ab4a1a-c71c-4cd8-8a7f-156def8086a5"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6291), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6293), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 196", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6291), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 197, 0.0, new Guid("78007d27-dd8c-400a-930b-6190cea73056"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6302), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6307), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 197", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6303), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 198, 0.0, new Guid("6107bff1-7562-40be-a8d8-bc0f331157f5"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6316), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6319), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 198", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6316), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 199, 0.0, new Guid("bd79748c-0102-48f0-982e-f8af3166c958"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6328), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6330), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 199", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6328), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 400, 0.0, new Guid("9b5a55a5-1baa-454a-a2ed-2d5edb4bc623"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6340), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 400", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6341), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 401, 0.0, new Guid("e5be0e7a-9f98-4c02-a061-015d9d088870"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6353), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 401", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6354), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 402, 0.0, new Guid("94780da5-0c69-47e0-a68d-628c4aafa01b"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6389), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 402", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6390), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 403, 0.0, new Guid("f316ca54-3648-4899-8005-202279afff93"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6402), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 403", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6403), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 404, 0.0, new Guid("b96d4149-db8c-4087-97de-7b96cd5018a7"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6413), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 404", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6414), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 405, 0.0, new Guid("1dd07688-8b73-4b2b-8f32-3b63b5de985a"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6425), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 405", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6425), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 406, 0.0, new Guid("55780bfc-a585-4506-a74c-f4d80918b1ff"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6437), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 406", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6438), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 407, 0.0, new Guid("13031fe4-d39c-4456-85e1-0d6f63ff0f56"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6449), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 407", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6450), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 408, 0.0, new Guid("c25214aa-dc3e-4878-8800-45dba99ae6f0"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6460), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 408", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6461), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 409, 0.0, new Guid("f74043f5-bb09-4354-9e22-077ad1ffcf89"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6471), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 409", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6472), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 410, 0.0, new Guid("f2fe84e1-f920-4be7-adcc-a409573baded"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6484), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 410", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6484), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 411, 0.0, new Guid("ae817ec9-b08b-498d-87f3-80e44e83ee83"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6495), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 411", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6495), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 412, 0.0, new Guid("c6e34510-3919-40aa-9efa-522e195e92c0"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6505), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 412", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6506), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 413, 0.0, new Guid("359cef30-1a0d-459e-afac-c5ea615e6a22"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 413", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6549), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 414, 0.0, new Guid("b7516579-df01-467d-889f-ac8df2883006"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6562), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 414", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6563), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 415, 0.0, new Guid("803c3b79-6bfc-4f47-92c1-9747bcdf9f77"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6573), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 415", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6574), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 416, 0.0, new Guid("142b8798-af21-44c7-a997-f805e17ac898"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6584), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 416", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6585), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 417, 0.0, new Guid("a45dbc80-0077-4671-8867-afbb3c839db8"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6598), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 417", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6599), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 418, 0.0, new Guid("cd424982-60e4-4efc-bb62-30f3eda204d4"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6611), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 418", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6612), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 419, 0.0, new Guid("f45cf22f-5807-4863-9dd9-d9bdd803c30a"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6623), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 419", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6624), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 420, 0.0, new Guid("55d4af63-2b6c-4703-b7a1-a9bce39bf503"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6633), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 420", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6634), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 421, 0.0, new Guid("4706f185-558a-4bb7-ba43-de02e1958a05"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6668), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 421", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6669), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 422, 0.0, new Guid("f2c99239-4a2e-4792-b47e-a8ad7c661790"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6683), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 422", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6684), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 423, 0.0, new Guid("b97f86fb-0ba4-408f-b648-c861d2d3e934"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6695), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 423", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6695), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 424, 0.0, new Guid("1962458e-1d7b-4ee1-8e84-0285278da3fb"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6706), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 424", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6707), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 425, 0.0, new Guid("5b27ba2c-4d54-4d44-8cfd-8a3edef97e45"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6717), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 425", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6718), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 426, 0.0, new Guid("32d07795-84c4-400c-91cc-05b49ce01613"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6730), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 426", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6731), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 427, 0.0, new Guid("d2080a16-6984-4211-9001-6479465bc666"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6742), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 427", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6743), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 428, 0.0, new Guid("84350e95-8a7b-4cb2-ab8a-9a843dcdf02c"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6753), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 428", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6754), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 429, 0.0, new Guid("ec83157a-ad93-47c4-ab1e-64dba7713f4d"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6764), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 429", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6765), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 430, 0.0, new Guid("41d07d77-b243-451d-a693-235a17d87384"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6776), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 430", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6777), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 431, 0.0, new Guid("0137aa4a-a069-4b2d-bc5d-0ea2f92b6a75"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6788), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 431", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6789), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 432, 0.0, new Guid("067bdccb-4f14-4289-9d0e-8544bc406780"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6821), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 432", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6822), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 433, 0.0, new Guid("0e5aa5b5-f0f2-4a9c-88d9-11c98fec772f"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6834), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 433", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6835), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 434, 0.0, new Guid("ca81e3d6-8996-4527-abc2-fbd3b7262244"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 434", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6848), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 435, 0.0, new Guid("ab4e8013-851e-4664-813c-79f3f783fa11"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6859), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 435", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6860), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 436, 0.0, new Guid("0048516a-26e9-4f5f-acd0-63e8520cb7e9"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6870), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 436", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6871), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 437, 0.0, new Guid("db4b5b5d-48b8-4363-9ed5-f59af26090fe"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6881), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 437", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6882), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 438, 0.0, new Guid("7ef19ff0-1244-4eca-8788-17b5d9cb452d"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6894), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 438", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6895), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 439, 0.0, new Guid("474b19e1-5d50-40e2-aba6-e8e6d5dc9ddd"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 439", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6905), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 440, 0.0, new Guid("1398565e-2319-496f-877d-9fd69b9d7023"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6916), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 440", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6916), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 441, 0.0, new Guid("d7d400c8-a67d-4764-bd04-522caa342105"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6926), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 441", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6927), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 442, 0.0, new Guid("8fda40f4-ae9c-4854-a5fb-ebe73ceed88c"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6939), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 442", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6940), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 443, 0.0, new Guid("653cab57-aca0-4b8b-a5e1-5f99fb99bdca"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 443", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6975), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 444, 0.0, new Guid("4b53fd81-7d1b-4f12-bc9a-854460f5e6bc"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6985), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 444", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6986), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 445, 0.0, new Guid("45ae1a52-c817-4f5c-852e-519e2148842c"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6996), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 445", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(6997), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 446, 0.0, new Guid("5a5a8a56-ad09-4397-8f90-2cd50e0bf783"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7009), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 446", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7010), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 447, 0.0, new Guid("54ca466b-7ba8-4cb6-8e7d-628606f52725"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7020), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 447", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7021), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 448, 0.0, new Guid("ebae810f-cc46-41b9-8313-00c85f91d2c7"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7031), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 448", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7032), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 449, 0.0, new Guid("5c22787d-2260-42ee-92ee-4e84866229ca"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7042), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 449", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7043), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 450, 0.0, new Guid("313e6272-03ec-4244-b1e5-2f062b38a6d0"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7055), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 450", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7056), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 451, 0.0, new Guid("9dc2d3cd-12e5-4111-8dc4-378a424bd784"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7066), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 451", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7067), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 452, 0.0, new Guid("60483f48-1fb2-4722-862a-c7508f742ccc"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7077), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 452", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7078), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 453, 0.0, new Guid("ad49fcec-619a-4ca6-adcb-559111b6f06a"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7111), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 453", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7112), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 454, 0.0, new Guid("fc6292ca-2fa8-4877-a4a3-2244bb56360f"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7125), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 454", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7126), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 455, 0.0, new Guid("93253269-77f1-41e1-8100-f49885d578ee"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7137), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 455", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7137), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 456, 0.0, new Guid("6118f733-ebba-47b6-955a-39e901e2dafd"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7149), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 456", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7150), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 457, 0.0, new Guid("33c3585c-e850-484f-aba3-05b41ae1cf8a"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7161), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 457", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7161), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 458, 0.0, new Guid("b5a13943-3829-40cf-8b61-70fe2c0de58b"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 458", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7174), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 459, 0.0, new Guid("e88a6e82-f662-49af-a418-1ac5494b4a18"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7185), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 459", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7186), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 460, 0.0, new Guid("11476ae0-0332-4bfc-a8f7-acd4e86c959e"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7196), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 460", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7197), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 461, 0.0, new Guid("63307dc9-c04f-40a3-b1f3-b2f4d918b56b"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7207), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 461", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7208), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 462, 0.0, new Guid("7334bcff-49d6-4fce-b0e1-a1694decacd9"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7220), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 462", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7221), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 463, 0.0, new Guid("e68c65d3-3356-4824-9e11-89bb69d41889"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7231), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 463", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7232), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 464, 0.0, new Guid("27383d7d-67ba-4532-99f3-6aa74504f637"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7264), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 464", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7265), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 465, 0.0, new Guid("e8c33cb9-9f04-4776-85f2-0eebc76ecdb3"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7276), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 465", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7277), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 466, 0.0, new Guid("58a84a9e-c67f-43e7-9301-e8a884eb08a2"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 466", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7290), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 467, 0.0, new Guid("96e1cb82-0726-40f0-b1de-6aa4179ee4ab"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7300), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 467", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7301), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 468, 0.0, new Guid("14a080c5-3b69-4fc1-a66c-c0b423c76ca3"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7311), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 468", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7312), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 469, 0.0, new Guid("4e171c04-ed7b-4864-b269-73637945e6e2"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7322), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 469", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7323), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 470, 0.0, new Guid("20020521-8896-4add-9d14-3a2686112ca9"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7335), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 470", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7336), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 471, 0.0, new Guid("d43351a3-2715-4718-9983-12afa4953f78"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 471", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7346), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 472, 0.0, new Guid("806239d3-bd4c-4214-a500-79a93bf3bc5d"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7356), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 472", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7357), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 473, 0.0, new Guid("b96460b0-d130-418a-8ff5-9261f3231eac"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7367), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 473", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7368), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 474, 0.0, new Guid("f977d798-5f4c-49d3-a4e4-be9e9b9c6128"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 474", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7381), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 475, 0.0, new Guid("4c2c832a-9cf6-4425-b6ae-11edd1b8328d"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7413), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 475", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7414), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 476, 0.0, new Guid("a4bda7d3-40e8-4684-9fce-6c109330ca5d"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7425), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 476", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7426), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 477, 0.0, new Guid("8e24cb80-ddd4-469f-abb8-8883547ce456"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 477", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7437), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 478, 0.0, new Guid("8b6c8d22-3e37-486f-b42b-b0cfce5393d0"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7449), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 478", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7450), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 479, 0.0, new Guid("e0bc3812-1ab4-4df4-ac72-98a744dfe0c3"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7460), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 479", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7461), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 480, 0.0, new Guid("5db322be-62d1-4872-99b4-b6a716930569"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7471), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 480", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7472), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 481, 0.0, new Guid("d7b3aaf0-3962-4304-be6f-5ed1a88d4409"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7482), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 481", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7483), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 482, 0.0, new Guid("96af0bb0-020b-4026-89de-7cf6689733c2"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7494), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 482", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7495), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 483, 0.0, new Guid("47975cca-193f-4e7a-806a-f962c62e1d2d"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7506), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 483", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7507), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 484, 0.0, new Guid("c5d9f22d-5371-4ee0-9a00-3410ad887c2a"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 484", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7518), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 485, 0.0, new Guid("3520e474-47f0-4cd1-9d0c-96f2a793a462"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7528), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 485", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7529), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 486, 0.0, new Guid("8fbf0a3b-b48d-49ca-a7a2-115e3cc28648"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7564), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 486", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7565), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 487, 0.0, new Guid("f7344c6e-f83f-4293-92de-3b9c56fc6407"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7576), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 487", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7577), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 488, 0.0, new Guid("2f38598d-5591-4541-bc18-076490d65024"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 488", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7588), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 489, 0.0, new Guid("c3f0a172-a39a-4b6a-aff0-4cddfb0c96f4"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7599), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 489", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7599), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 490, 0.0, new Guid("4b1bad1c-103a-4a51-96eb-7e43e394c52a"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7612), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 490", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7613), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 491, 0.0, new Guid("cafcf134-5f77-43cc-82b7-397d6d7163f6"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7623), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 491", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7624), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 492, 0.0, new Guid("12f5566c-b690-4518-83b3-2c1ff3cbff48"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7634), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 492", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7635), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 493, 0.0, new Guid("61b38f50-34d5-42c2-af13-86d46275af90"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7645), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 493", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7646), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 494, 0.0, new Guid("eec63e2a-3b25-48ed-8123-4a6815de11c9"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7657), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 494", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7658), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 495, 0.0, new Guid("800c4c5d-b303-4690-9e19-ff4400ec5e4e"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7668), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 495", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7669), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 496, 0.0, new Guid("31ea7cd5-d50c-4b8c-a5a1-239014d3283c"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7714), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 496", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7714), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 497, 0.0, new Guid("8ae15e6c-d1db-4dfd-b58e-c999c4deb144"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7726), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 497", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7727), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 498, 0.0, new Guid("66cf4e67-3173-42b1-8f24-66dcb47abbad"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7740), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 498", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7741), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 499, 0.0, new Guid("e247a932-e928-4395-ad1b-31399f29c750"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7751), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 499", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7752), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "name", "slot", "status", "type" },
                values: new object[,]
                {
                    { 1, new Guid("e5d259cf-c3d8-4889-80a7-4b490abffc64"), "ViRide", 2, 1, 0 },
                    { 2, new Guid("eca87c4a-50c2-4b42-9bf2-c565e95df41b"), "ViCar-4", 4, 1, 1 },
                    { 3, new Guid("25c43443-69d0-46c5-82b5-03bfc1221190"), "ViCar-7", 7, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "type", "updated_at", "updated_by", "user_id" },
                values: new object[] { 9, 0.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3421), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3422), new TimeSpan(0, 7, 0, 0, 0)), 0, null });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7935), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7935), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7943), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7949), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7950), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7957), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7957), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7964), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7965), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7971), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7972), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 100, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7979), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+100", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7980), new TimeSpan(0, 7, 0, 0, 0)), 0, 100, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 101, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7990), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@100", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7991), new TimeSpan(0, 7, 0, 0, 0)), 0, 100 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 102, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8001), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+101", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8002), new TimeSpan(0, 7, 0, 0, 0)), 0, 101, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 103, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8010), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@101", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8010), new TimeSpan(0, 7, 0, 0, 0)), 0, 101 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 104, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8018), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+102", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8018), new TimeSpan(0, 7, 0, 0, 0)), 0, 102, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 105, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@102", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8026), new TimeSpan(0, 7, 0, 0, 0)), 0, 102 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 106, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8033), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+103", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8034), new TimeSpan(0, 7, 0, 0, 0)), 0, 103, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 107, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8041), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@103", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8041), new TimeSpan(0, 7, 0, 0, 0)), 0, 103 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 108, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8049), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+104", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8049), new TimeSpan(0, 7, 0, 0, 0)), 0, 104, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 109, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8057), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@104", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8058), new TimeSpan(0, 7, 0, 0, 0)), 0, 104 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 110, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8065), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+105", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8065), new TimeSpan(0, 7, 0, 0, 0)), 0, 105, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 111, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8072), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@105", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8073), new TimeSpan(0, 7, 0, 0, 0)), 0, 105 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 112, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8305), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+106", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8306), new TimeSpan(0, 7, 0, 0, 0)), 0, 106, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 113, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@106", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8318), new TimeSpan(0, 7, 0, 0, 0)), 0, 106 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 114, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8325), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+107", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8326), new TimeSpan(0, 7, 0, 0, 0)), 0, 107, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 115, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8333), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@107", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8334), new TimeSpan(0, 7, 0, 0, 0)), 0, 107 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 116, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8341), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+108", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8342), new TimeSpan(0, 7, 0, 0, 0)), 0, 108, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 117, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8348), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@108", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8349), new TimeSpan(0, 7, 0, 0, 0)), 0, 108 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 118, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8357), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+109", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8357), new TimeSpan(0, 7, 0, 0, 0)), 0, 109, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 119, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8365), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@109", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8365), new TimeSpan(0, 7, 0, 0, 0)), 0, 109 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 120, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8372), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+110", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8373), new TimeSpan(0, 7, 0, 0, 0)), 0, 110, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 121, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@110", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8381), new TimeSpan(0, 7, 0, 0, 0)), 0, 110 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 122, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8388), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+111", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8389), new TimeSpan(0, 7, 0, 0, 0)), 0, 111, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 123, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@111", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8397), new TimeSpan(0, 7, 0, 0, 0)), 0, 111 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 124, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+112", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8405), new TimeSpan(0, 7, 0, 0, 0)), 0, 112, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 125, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8412), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@112", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8412), new TimeSpan(0, 7, 0, 0, 0)), 0, 112 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 126, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8420), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+113", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8421), new TimeSpan(0, 7, 0, 0, 0)), 0, 113, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 127, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8428), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@113", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8429), new TimeSpan(0, 7, 0, 0, 0)), 0, 113 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 128, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+114", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8437), new TimeSpan(0, 7, 0, 0, 0)), 0, 114, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 129, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8443), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@114", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8444), new TimeSpan(0, 7, 0, 0, 0)), 0, 114 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 130, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8451), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+115", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8452), new TimeSpan(0, 7, 0, 0, 0)), 0, 115, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 131, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8459), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@115", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8460), new TimeSpan(0, 7, 0, 0, 0)), 0, 115 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 132, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8467), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+116", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8468), new TimeSpan(0, 7, 0, 0, 0)), 0, 116, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 133, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8475), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@116", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8475), new TimeSpan(0, 7, 0, 0, 0)), 0, 116 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 134, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8482), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+117", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8483), new TimeSpan(0, 7, 0, 0, 0)), 0, 117, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 135, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8514), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@117", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8515), new TimeSpan(0, 7, 0, 0, 0)), 0, 117 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 136, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8522), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+118", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8523), new TimeSpan(0, 7, 0, 0, 0)), 0, 118, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 137, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8530), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@118", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8531), new TimeSpan(0, 7, 0, 0, 0)), 0, 118 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 138, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8538), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+119", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8539), new TimeSpan(0, 7, 0, 0, 0)), 0, 119, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 139, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8546), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@119", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8546), new TimeSpan(0, 7, 0, 0, 0)), 0, 119 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 140, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8554), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+120", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8554), new TimeSpan(0, 7, 0, 0, 0)), 0, 120, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 141, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8563), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@120", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8564), new TimeSpan(0, 7, 0, 0, 0)), 0, 120 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 142, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+121", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8571), new TimeSpan(0, 7, 0, 0, 0)), 0, 121, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 143, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8578), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@121", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8579), new TimeSpan(0, 7, 0, 0, 0)), 0, 121 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 144, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8586), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+122", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8587), new TimeSpan(0, 7, 0, 0, 0)), 0, 122, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 145, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8593), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@122", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8594), new TimeSpan(0, 7, 0, 0, 0)), 0, 122 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 146, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8601), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+123", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8602), new TimeSpan(0, 7, 0, 0, 0)), 0, 123, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 147, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8609), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@123", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8610), new TimeSpan(0, 7, 0, 0, 0)), 0, 123 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 148, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8617), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+124", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8617), new TimeSpan(0, 7, 0, 0, 0)), 0, 124, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 149, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8624), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@124", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8625), new TimeSpan(0, 7, 0, 0, 0)), 0, 124 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 150, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8632), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+125", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8633), new TimeSpan(0, 7, 0, 0, 0)), 0, 125, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 151, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8640), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@125", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8641), new TimeSpan(0, 7, 0, 0, 0)), 0, 125 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 152, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8648), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+126", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8649), new TimeSpan(0, 7, 0, 0, 0)), 0, 126, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 153, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8655), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@126", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8656), new TimeSpan(0, 7, 0, 0, 0)), 0, 126 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 154, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8687), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+127", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8687), new TimeSpan(0, 7, 0, 0, 0)), 0, 127, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 155, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8695), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@127", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8696), new TimeSpan(0, 7, 0, 0, 0)), 0, 127 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 156, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8703), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+128", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8704), new TimeSpan(0, 7, 0, 0, 0)), 0, 128, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 157, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8711), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@128", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8712), new TimeSpan(0, 7, 0, 0, 0)), 0, 128 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 158, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8719), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+129", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8720), new TimeSpan(0, 7, 0, 0, 0)), 0, 129, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 159, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8726), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@129", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8727), new TimeSpan(0, 7, 0, 0, 0)), 0, 129 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 160, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8735), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+130", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8735), new TimeSpan(0, 7, 0, 0, 0)), 0, 130, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 161, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8742), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@130", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8743), new TimeSpan(0, 7, 0, 0, 0)), 0, 130 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 162, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8750), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+131", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8751), new TimeSpan(0, 7, 0, 0, 0)), 0, 131, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 163, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8758), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@131", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8759), new TimeSpan(0, 7, 0, 0, 0)), 0, 131 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 164, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8766), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+132", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8767), new TimeSpan(0, 7, 0, 0, 0)), 0, 132, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 165, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8773), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@132", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8774), new TimeSpan(0, 7, 0, 0, 0)), 0, 132 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 166, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+133", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8782), new TimeSpan(0, 7, 0, 0, 0)), 0, 133, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 167, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8789), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@133", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8790), new TimeSpan(0, 7, 0, 0, 0)), 0, 133 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 168, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8797), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+134", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8798), new TimeSpan(0, 7, 0, 0, 0)), 0, 134, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 169, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8805), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@134", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8806), new TimeSpan(0, 7, 0, 0, 0)), 0, 134 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 170, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8813), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+135", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8814), new TimeSpan(0, 7, 0, 0, 0)), 0, 135, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 171, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8821), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@135", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8822), new TimeSpan(0, 7, 0, 0, 0)), 0, 135 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 172, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8829), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+136", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8829), new TimeSpan(0, 7, 0, 0, 0)), 0, 136, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 173, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8836), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@136", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8837), new TimeSpan(0, 7, 0, 0, 0)), 0, 136 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 174, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8845), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+137", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8845), new TimeSpan(0, 7, 0, 0, 0)), 0, 137, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 175, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8852), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@137", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8853), new TimeSpan(0, 7, 0, 0, 0)), 0, 137 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 176, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8883), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+138", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8884), new TimeSpan(0, 7, 0, 0, 0)), 0, 138, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 177, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8892), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@138", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8893), new TimeSpan(0, 7, 0, 0, 0)), 0, 138 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 178, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8900), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+139", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8901), new TimeSpan(0, 7, 0, 0, 0)), 0, 139, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 179, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8908), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@139", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8909), new TimeSpan(0, 7, 0, 0, 0)), 0, 139 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 180, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8916), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+140", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8917), new TimeSpan(0, 7, 0, 0, 0)), 0, 140, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 181, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8923), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@140", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8924), new TimeSpan(0, 7, 0, 0, 0)), 0, 140 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 182, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8931), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+141", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8932), new TimeSpan(0, 7, 0, 0, 0)), 0, 141, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 183, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8939), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@141", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8940), new TimeSpan(0, 7, 0, 0, 0)), 0, 141 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 184, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8947), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+142", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8948), new TimeSpan(0, 7, 0, 0, 0)), 0, 142, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 185, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8955), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@142", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8955), new TimeSpan(0, 7, 0, 0, 0)), 0, 142 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 186, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8963), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+143", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8963), new TimeSpan(0, 7, 0, 0, 0)), 0, 143, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 187, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8971), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@143", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8972), new TimeSpan(0, 7, 0, 0, 0)), 0, 143 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 188, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8979), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+144", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8979), new TimeSpan(0, 7, 0, 0, 0)), 0, 144, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 189, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8986), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@144", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8987), new TimeSpan(0, 7, 0, 0, 0)), 0, 144 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 190, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8994), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+145", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(8995), new TimeSpan(0, 7, 0, 0, 0)), 0, 145, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 191, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9002), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@145", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9003), new TimeSpan(0, 7, 0, 0, 0)), 0, 145 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 192, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9010), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+146", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9011), new TimeSpan(0, 7, 0, 0, 0)), 0, 146, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 193, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9017), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@146", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9018), new TimeSpan(0, 7, 0, 0, 0)), 0, 146 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 194, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+147", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9026), new TimeSpan(0, 7, 0, 0, 0)), 0, 147, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 195, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9033), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@147", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9034), new TimeSpan(0, 7, 0, 0, 0)), 0, 147 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 196, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9041), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+148", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9042), new TimeSpan(0, 7, 0, 0, 0)), 0, 148, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 197, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9049), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@148", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9049), new TimeSpan(0, 7, 0, 0, 0)), 0, 148 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 198, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9079), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+149", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9080), new TimeSpan(0, 7, 0, 0, 0)), 0, 149, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 199, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9088), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@149", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9089), new TimeSpan(0, 7, 0, 0, 0)), 0, 149 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 200, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9096), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+150", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9097), new TimeSpan(0, 7, 0, 0, 0)), 0, 150, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 201, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9104), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@150", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9105), new TimeSpan(0, 7, 0, 0, 0)), 0, 150 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 202, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9112), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+151", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9112), new TimeSpan(0, 7, 0, 0, 0)), 0, 151, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 203, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9119), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@151", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9120), new TimeSpan(0, 7, 0, 0, 0)), 0, 151 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 204, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9128), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+152", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9128), new TimeSpan(0, 7, 0, 0, 0)), 0, 152, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 205, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9137), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@152", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9138), new TimeSpan(0, 7, 0, 0, 0)), 0, 152 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 206, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9146), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+153", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9146), new TimeSpan(0, 7, 0, 0, 0)), 0, 153, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 207, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9153), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@153", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9154), new TimeSpan(0, 7, 0, 0, 0)), 0, 153 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 208, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9161), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+154", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9162), new TimeSpan(0, 7, 0, 0, 0)), 0, 154, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 209, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9169), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@154", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9170), new TimeSpan(0, 7, 0, 0, 0)), 0, 154 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 210, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9177), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+155", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9178), new TimeSpan(0, 7, 0, 0, 0)), 0, 155, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 211, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9335), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@155", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9335), new TimeSpan(0, 7, 0, 0, 0)), 0, 155 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 212, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9343), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+156", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9344), new TimeSpan(0, 7, 0, 0, 0)), 0, 156, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 213, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9351), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@156", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9352), new TimeSpan(0, 7, 0, 0, 0)), 0, 156 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 214, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9358), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+157", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9359), new TimeSpan(0, 7, 0, 0, 0)), 0, 157, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 215, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9405), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@157", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9406), new TimeSpan(0, 7, 0, 0, 0)), 0, 157 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 216, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9414), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+158", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9414), new TimeSpan(0, 7, 0, 0, 0)), 0, 158, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 217, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9421), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@158", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9422), new TimeSpan(0, 7, 0, 0, 0)), 0, 158 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 218, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9429), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+159", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9429), new TimeSpan(0, 7, 0, 0, 0)), 0, 159, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 219, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@159", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9436), new TimeSpan(0, 7, 0, 0, 0)), 0, 159 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 220, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9443), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+160", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9444), new TimeSpan(0, 7, 0, 0, 0)), 0, 160, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 221, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9451), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@160", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9451), new TimeSpan(0, 7, 0, 0, 0)), 0, 160 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 222, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+161", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9459), new TimeSpan(0, 7, 0, 0, 0)), 0, 161, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 223, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9465), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@161", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9466), new TimeSpan(0, 7, 0, 0, 0)), 0, 161 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 224, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9473), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+162", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9474), new TimeSpan(0, 7, 0, 0, 0)), 0, 162, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 225, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9480), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@162", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9481), new TimeSpan(0, 7, 0, 0, 0)), 0, 162 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 226, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9488), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+163", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9488), new TimeSpan(0, 7, 0, 0, 0)), 0, 163, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 227, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9495), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@163", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9496), new TimeSpan(0, 7, 0, 0, 0)), 0, 163 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 228, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9503), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+164", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9504), new TimeSpan(0, 7, 0, 0, 0)), 0, 164, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 229, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9511), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@164", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9511), new TimeSpan(0, 7, 0, 0, 0)), 0, 164 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 230, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9518), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+165", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9519), new TimeSpan(0, 7, 0, 0, 0)), 0, 165, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 231, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9525), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@165", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9526), new TimeSpan(0, 7, 0, 0, 0)), 0, 165 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 232, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+166", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9534), new TimeSpan(0, 7, 0, 0, 0)), 0, 166, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 233, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@166", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9541), new TimeSpan(0, 7, 0, 0, 0)), 0, 166 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 234, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+167", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9549), new TimeSpan(0, 7, 0, 0, 0)), 0, 167, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 235, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9556), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@167", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9556), new TimeSpan(0, 7, 0, 0, 0)), 0, 167 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 236, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9563), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+168", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9564), new TimeSpan(0, 7, 0, 0, 0)), 0, 168, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 237, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9603), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@168", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9604), new TimeSpan(0, 7, 0, 0, 0)), 0, 168 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 238, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9612), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+169", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9613), new TimeSpan(0, 7, 0, 0, 0)), 0, 169, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 239, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9620), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@169", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9621), new TimeSpan(0, 7, 0, 0, 0)), 0, 169 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 240, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9628), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+170", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9628), new TimeSpan(0, 7, 0, 0, 0)), 0, 170, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 241, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@170", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9636), new TimeSpan(0, 7, 0, 0, 0)), 0, 170 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 242, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9643), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+171", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9644), new TimeSpan(0, 7, 0, 0, 0)), 0, 171, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 243, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9651), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@171", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9651), new TimeSpan(0, 7, 0, 0, 0)), 0, 171 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 244, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9658), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+172", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9659), new TimeSpan(0, 7, 0, 0, 0)), 0, 172, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 245, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9666), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@172", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9666), new TimeSpan(0, 7, 0, 0, 0)), 0, 172 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 246, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9673), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+173", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9674), new TimeSpan(0, 7, 0, 0, 0)), 0, 173, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 247, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9681), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@173", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9682), new TimeSpan(0, 7, 0, 0, 0)), 0, 173 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 248, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+174", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9689), new TimeSpan(0, 7, 0, 0, 0)), 0, 174, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 249, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9696), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@174", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9697), new TimeSpan(0, 7, 0, 0, 0)), 0, 174 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 250, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+175", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9704), new TimeSpan(0, 7, 0, 0, 0)), 0, 175, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 251, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9711), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@175", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9712), new TimeSpan(0, 7, 0, 0, 0)), 0, 175 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 252, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9719), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+176", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9720), new TimeSpan(0, 7, 0, 0, 0)), 0, 176, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 253, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9726), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@176", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9727), new TimeSpan(0, 7, 0, 0, 0)), 0, 176 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 254, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9734), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+177", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9735), new TimeSpan(0, 7, 0, 0, 0)), 0, 177, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 255, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9742), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@177", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9742), new TimeSpan(0, 7, 0, 0, 0)), 0, 177 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 256, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9749), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+178", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9750), new TimeSpan(0, 7, 0, 0, 0)), 0, 178, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 257, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9756), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@178", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9757), new TimeSpan(0, 7, 0, 0, 0)), 0, 178 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 258, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9764), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+179", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9765), new TimeSpan(0, 7, 0, 0, 0)), 0, 179, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 259, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9793), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@179", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9794), new TimeSpan(0, 7, 0, 0, 0)), 0, 179 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 260, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9802), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+180", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9803), new TimeSpan(0, 7, 0, 0, 0)), 0, 180, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 261, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9810), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@180", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9811), new TimeSpan(0, 7, 0, 0, 0)), 0, 180 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 262, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+181", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9818), new TimeSpan(0, 7, 0, 0, 0)), 0, 181, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 263, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9825), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@181", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9826), new TimeSpan(0, 7, 0, 0, 0)), 0, 181 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 264, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9833), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+182", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9833), new TimeSpan(0, 7, 0, 0, 0)), 0, 182, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 265, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9840), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@182", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9841), new TimeSpan(0, 7, 0, 0, 0)), 0, 182 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 266, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9848), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+183", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9848), new TimeSpan(0, 7, 0, 0, 0)), 0, 183, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 267, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9855), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@183", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9856), new TimeSpan(0, 7, 0, 0, 0)), 0, 183 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 268, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9863), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+184", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9864), new TimeSpan(0, 7, 0, 0, 0)), 0, 184, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 269, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9870), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@184", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9871), new TimeSpan(0, 7, 0, 0, 0)), 0, 184 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 270, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9878), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+185", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9879), new TimeSpan(0, 7, 0, 0, 0)), 0, 185, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 271, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9885), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@185", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9886), new TimeSpan(0, 7, 0, 0, 0)), 0, 185 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 272, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9893), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+186", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9894), new TimeSpan(0, 7, 0, 0, 0)), 0, 186, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 273, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9901), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@186", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9901), new TimeSpan(0, 7, 0, 0, 0)), 0, 186 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 274, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9908), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+187", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9909), new TimeSpan(0, 7, 0, 0, 0)), 0, 187, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 275, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9916), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@187", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9917), new TimeSpan(0, 7, 0, 0, 0)), 0, 187 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 276, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9924), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+188", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9924), new TimeSpan(0, 7, 0, 0, 0)), 0, 188, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 277, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9931), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@188", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9932), new TimeSpan(0, 7, 0, 0, 0)), 0, 188 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 278, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9939), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+189", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9940), new TimeSpan(0, 7, 0, 0, 0)), 0, 189, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 279, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9946), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@189", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9947), new TimeSpan(0, 7, 0, 0, 0)), 0, 189 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 280, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+190", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9955), new TimeSpan(0, 7, 0, 0, 0)), 0, 190, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 281, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9984), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@190", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9984), new TimeSpan(0, 7, 0, 0, 0)), 0, 190 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 282, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9993), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+191", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(9994), new TimeSpan(0, 7, 0, 0, 0)), 0, 191, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 283, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@191", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2), new TimeSpan(0, 7, 0, 0, 0)), 0, 191 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 284, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(9), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+192", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(9), new TimeSpan(0, 7, 0, 0, 0)), 0, 192, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 285, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(16), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@192", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(17), new TimeSpan(0, 7, 0, 0, 0)), 0, 192 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 286, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(24), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+193", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(25), new TimeSpan(0, 7, 0, 0, 0)), 0, 193, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 287, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(31), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@193", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(32), new TimeSpan(0, 7, 0, 0, 0)), 0, 193 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 288, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(39), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+194", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(40), new TimeSpan(0, 7, 0, 0, 0)), 0, 194, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 289, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(46), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@194", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(47), new TimeSpan(0, 7, 0, 0, 0)), 0, 194 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 290, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(54), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+195", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(55), new TimeSpan(0, 7, 0, 0, 0)), 0, 195, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 291, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(62), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@195", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(62), new TimeSpan(0, 7, 0, 0, 0)), 0, 195 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 292, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(70), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+196", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(70), new TimeSpan(0, 7, 0, 0, 0)), 0, 196, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 293, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(77), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@196", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(78), new TimeSpan(0, 7, 0, 0, 0)), 0, 196 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 294, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(85), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+197", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(85), new TimeSpan(0, 7, 0, 0, 0)), 0, 197, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 295, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(92), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@197", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(93), new TimeSpan(0, 7, 0, 0, 0)), 0, 197 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 296, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(100), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+198", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(100), new TimeSpan(0, 7, 0, 0, 0)), 0, 198, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 297, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(107), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@198", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(108), new TimeSpan(0, 7, 0, 0, 0)), 0, 198 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 298, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(115), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+199", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(115), new TimeSpan(0, 7, 0, 0, 0)), 0, 199, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 299, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(122), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@199", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(123), new TimeSpan(0, 7, 0, 0, 0)), 0, 199 },
                    { 400, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(130), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+400", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(131), new TimeSpan(0, 7, 0, 0, 0)), 0, 400 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 401, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(139), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@400", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(140), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 402, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(148), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+401", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(148), new TimeSpan(0, 7, 0, 0, 0)), 0, 401 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 403, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(155), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@401", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(156), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 404, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(186), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+402", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(187), new TimeSpan(0, 7, 0, 0, 0)), 0, 402 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 405, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(194), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@402", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(195), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 406, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(202), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+403", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(202), new TimeSpan(0, 7, 0, 0, 0)), 0, 403 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 407, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(209), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@403", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(210), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 408, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(217), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+404", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(217), new TimeSpan(0, 7, 0, 0, 0)), 0, 404 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 409, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(224), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@404", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(225), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 410, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(232), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+405", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(232), new TimeSpan(0, 7, 0, 0, 0)), 0, 405 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 411, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(239), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@405", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(240), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 412, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(247), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+406", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(247), new TimeSpan(0, 7, 0, 0, 0)), 0, 406 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 413, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(254), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@406", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(255), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 414, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(261), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+407", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(262), new TimeSpan(0, 7, 0, 0, 0)), 0, 407 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 415, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(269), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@407", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(269), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 416, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(276), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+408", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(277), new TimeSpan(0, 7, 0, 0, 0)), 0, 408 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 417, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(283), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@408", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(284), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 418, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(291), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+409", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(292), new TimeSpan(0, 7, 0, 0, 0)), 0, 409 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 419, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(299), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@409", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(299), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 420, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(306), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+410", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(307), new TimeSpan(0, 7, 0, 0, 0)), 0, 410 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 421, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(314), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@410", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(314), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 422, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+411", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(322), new TimeSpan(0, 7, 0, 0, 0)), 0, 411 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 423, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(328), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@411", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(329), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 424, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(336), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+412", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(337), new TimeSpan(0, 7, 0, 0, 0)), 0, 412 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 425, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(344), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@412", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(344), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 426, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(377), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+413", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(378), new TimeSpan(0, 7, 0, 0, 0)), 0, 413 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 427, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(385), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@413", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(385), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 428, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(392), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+414", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(393), new TimeSpan(0, 7, 0, 0, 0)), 0, 414 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 429, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(400), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@414", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(400), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 430, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(407), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+415", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(408), new TimeSpan(0, 7, 0, 0, 0)), 0, 415 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 431, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(415), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@415", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(416), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 432, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(422), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+416", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(423), new TimeSpan(0, 7, 0, 0, 0)), 0, 416 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 433, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(432), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@416", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(433), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 434, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(440), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+417", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(441), new TimeSpan(0, 7, 0, 0, 0)), 0, 417 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 435, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(447), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@417", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(448), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 436, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(455), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+418", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(455), new TimeSpan(0, 7, 0, 0, 0)), 0, 418 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 437, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(485), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@418", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(486), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 438, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(493), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+419", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(494), new TimeSpan(0, 7, 0, 0, 0)), 0, 419 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 439, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(501), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@419", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(501), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 440, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(508), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+420", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(509), new TimeSpan(0, 7, 0, 0, 0)), 0, 420 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 441, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(516), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@420", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(516), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 442, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(523), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+421", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(524), new TimeSpan(0, 7, 0, 0, 0)), 0, 421 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 443, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(531), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@421", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(531), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 444, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(538), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+422", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(539), new TimeSpan(0, 7, 0, 0, 0)), 0, 422 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 445, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(545), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@422", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(546), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 446, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(553), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+423", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(554), new TimeSpan(0, 7, 0, 0, 0)), 0, 423 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 447, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(560), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@423", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(561), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 448, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(568), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+424", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(568), new TimeSpan(0, 7, 0, 0, 0)), 0, 424 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 449, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(575), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@424", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(576), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 450, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(583), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+425", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(583), new TimeSpan(0, 7, 0, 0, 0)), 0, 425 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 451, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(590), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@425", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(591), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 452, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(598), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+426", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(599), new TimeSpan(0, 7, 0, 0, 0)), 0, 426 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 453, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(605), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@426", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(606), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 454, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(613), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+427", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(614), new TimeSpan(0, 7, 0, 0, 0)), 0, 427 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 455, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(621), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@427", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(621), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 456, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(628), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+428", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(629), new TimeSpan(0, 7, 0, 0, 0)), 0, 428 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 457, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@428", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(636), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 458, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(643), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+429", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(644), new TimeSpan(0, 7, 0, 0, 0)), 0, 429 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 459, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(673), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@429", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(674), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 460, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(682), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+430", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(682), new TimeSpan(0, 7, 0, 0, 0)), 0, 430 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 461, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(690), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@430", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(690), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 462, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(697), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+431", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(698), new TimeSpan(0, 7, 0, 0, 0)), 0, 431 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 463, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@431", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(705), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 464, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(712), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+432", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(713), new TimeSpan(0, 7, 0, 0, 0)), 0, 432 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 465, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(720), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@432", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(720), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 466, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(727), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+433", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(728), new TimeSpan(0, 7, 0, 0, 0)), 0, 433 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 467, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(735), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@433", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(735), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 468, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(742), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+434", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(743), new TimeSpan(0, 7, 0, 0, 0)), 0, 434 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 469, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(750), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@434", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(750), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 470, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(757), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+435", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(758), new TimeSpan(0, 7, 0, 0, 0)), 0, 435 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 471, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(765), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@435", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(765), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 472, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(772), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+436", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(773), new TimeSpan(0, 7, 0, 0, 0)), 0, 436 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 473, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(780), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@436", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(781), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 474, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(788), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+437", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(788), new TimeSpan(0, 7, 0, 0, 0)), 0, 437 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 475, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(795), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@437", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(796), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 476, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(803), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+438", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(803), new TimeSpan(0, 7, 0, 0, 0)), 0, 438 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 477, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(810), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@438", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(811), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 478, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+439", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(818), new TimeSpan(0, 7, 0, 0, 0)), 0, 439 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 479, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(825), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@439", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(826), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 480, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(832), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+440", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(833), new TimeSpan(0, 7, 0, 0, 0)), 0, 440 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 481, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(861), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@440", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(862), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 482, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(870), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+441", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(871), new TimeSpan(0, 7, 0, 0, 0)), 0, 441 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 483, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(878), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@441", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(878), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 484, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(885), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+442", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(886), new TimeSpan(0, 7, 0, 0, 0)), 0, 442 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 485, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(893), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@442", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(894), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 486, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(901), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+443", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(901), new TimeSpan(0, 7, 0, 0, 0)), 0, 443 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 487, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(908), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@443", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(909), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 488, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(916), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+444", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(917), new TimeSpan(0, 7, 0, 0, 0)), 0, 444 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 489, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(924), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@444", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(924), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 490, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(931), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+445", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(932), new TimeSpan(0, 7, 0, 0, 0)), 0, 445 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 491, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(939), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@445", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(939), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 492, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(946), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+446", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(947), new TimeSpan(0, 7, 0, 0, 0)), 0, 446 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 493, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@446", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(954), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 494, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(961), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+447", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(962), new TimeSpan(0, 7, 0, 0, 0)), 0, 447 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 495, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@447", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(969), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 496, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+448", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(977), new TimeSpan(0, 7, 0, 0, 0)), 0, 448 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 497, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(984), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@448", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(984), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 498, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(991), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+449", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(992), new TimeSpan(0, 7, 0, 0, 0)), 0, 449 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 499, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(999), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@449", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1000), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 500, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1006), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+450", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1007), new TimeSpan(0, 7, 0, 0, 0)), 0, 450 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 501, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1014), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@450", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1015), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 502, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1022), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+451", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1022), new TimeSpan(0, 7, 0, 0, 0)), 0, 451 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 503, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1058), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@451", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1059), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 504, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1068), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+452", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1069), new TimeSpan(0, 7, 0, 0, 0)), 0, 452 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 505, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1076), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@452", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1076), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 506, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1083), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+453", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1084), new TimeSpan(0, 7, 0, 0, 0)), 0, 453 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 507, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1091), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@453", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1091), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 508, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1098), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+454", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1099), new TimeSpan(0, 7, 0, 0, 0)), 0, 454 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 509, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1106), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@454", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1107), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 510, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1114), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+455", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1114), new TimeSpan(0, 7, 0, 0, 0)), 0, 455 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 511, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1121), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@455", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1122), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 512, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+456", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1129), new TimeSpan(0, 7, 0, 0, 0)), 0, 456 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 513, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1136), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@456", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1137), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 514, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+457", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1144), new TimeSpan(0, 7, 0, 0, 0)), 0, 457 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 515, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1152), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@457", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1152), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 516, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1159), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+458", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1160), new TimeSpan(0, 7, 0, 0, 0)), 0, 458 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 517, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@458", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1167), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 518, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+459", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1175), new TimeSpan(0, 7, 0, 0, 0)), 0, 459 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 519, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1182), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@459", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1182), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 520, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1189), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+460", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1190), new TimeSpan(0, 7, 0, 0, 0)), 0, 460 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 521, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1197), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@460", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1197), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 522, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1204), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+461", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1205), new TimeSpan(0, 7, 0, 0, 0)), 0, 461 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 523, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@461", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1213), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 524, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1219), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+462", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1220), new TimeSpan(0, 7, 0, 0, 0)), 0, 462 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 525, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1227), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@462", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1227), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 526, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1259), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+463", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1259), new TimeSpan(0, 7, 0, 0, 0)), 0, 463 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 527, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@463", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1267), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 528, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1274), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+464", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1275), new TimeSpan(0, 7, 0, 0, 0)), 0, 464 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 529, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1282), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@464", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1282), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 530, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+465", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1290), new TimeSpan(0, 7, 0, 0, 0)), 0, 465 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 531, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1297), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@465", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1298), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 532, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1304), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+466", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1305), new TimeSpan(0, 7, 0, 0, 0)), 0, 466 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 533, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1312), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@466", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1312), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 534, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1319), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+467", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1320), new TimeSpan(0, 7, 0, 0, 0)), 0, 467 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 535, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1327), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@467", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1327), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 536, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1334), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+468", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1335), new TimeSpan(0, 7, 0, 0, 0)), 0, 468 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 537, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1343), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@468", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1343), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 538, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1351), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+469", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1352), new TimeSpan(0, 7, 0, 0, 0)), 0, 469 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 539, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1358), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@469", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1359), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 540, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1366), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+470", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1366), new TimeSpan(0, 7, 0, 0, 0)), 0, 470 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 541, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1373), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@470", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1374), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 542, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1381), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+471", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1382), new TimeSpan(0, 7, 0, 0, 0)), 0, 471 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 543, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1389), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@471", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1389), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 544, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+472", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1397), new TimeSpan(0, 7, 0, 0, 0)), 0, 472 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 545, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@472", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1404), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 546, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+473", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1412), new TimeSpan(0, 7, 0, 0, 0)), 0, 473 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 547, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1419), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@473", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1419), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 548, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1449), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+474", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1449), new TimeSpan(0, 7, 0, 0, 0)), 0, 474 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 549, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1457), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@474", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1458), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 550, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1465), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+475", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1466), new TimeSpan(0, 7, 0, 0, 0)), 0, 475 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 551, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1473), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@475", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1473), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 552, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1480), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+476", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1481), new TimeSpan(0, 7, 0, 0, 0)), 0, 476 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 553, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1488), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@476", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1488), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 554, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1495), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+477", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1496), new TimeSpan(0, 7, 0, 0, 0)), 0, 477 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 555, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1503), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@477", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1503), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 556, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+478", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1511), new TimeSpan(0, 7, 0, 0, 0)), 0, 478 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 557, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1518), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@478", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1518), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 558, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1525), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+479", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1526), new TimeSpan(0, 7, 0, 0, 0)), 0, 479 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 559, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@479", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1534), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 560, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+480", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1541), new TimeSpan(0, 7, 0, 0, 0)), 0, 480 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 561, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@480", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1549), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 562, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1555), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+481", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1556), new TimeSpan(0, 7, 0, 0, 0)), 0, 481 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 563, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1563), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@481", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1564), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 564, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+482", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1571), new TimeSpan(0, 7, 0, 0, 0)), 0, 482 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 565, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1578), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@482", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1579), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 566, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1586), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+483", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1586), new TimeSpan(0, 7, 0, 0, 0)), 0, 483 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 567, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1593), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@483", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1594), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 568, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1600), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+484", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1601), new TimeSpan(0, 7, 0, 0, 0)), 0, 484 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 569, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1608), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@484", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1609), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 570, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1639), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+485", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1639), new TimeSpan(0, 7, 0, 0, 0)), 0, 485 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 571, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@485", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1647), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 572, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1654), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+486", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1655), new TimeSpan(0, 7, 0, 0, 0)), 0, 486 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 573, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1662), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@486", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1662), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 574, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1669), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+487", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1670), new TimeSpan(0, 7, 0, 0, 0)), 0, 487 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 575, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1677), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@487", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1677), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 576, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1684), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+488", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1685), new TimeSpan(0, 7, 0, 0, 0)), 0, 488 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 577, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1692), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@488", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1692), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 578, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1699), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+489", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1700), new TimeSpan(0, 7, 0, 0, 0)), 0, 489 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 579, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1706), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@489", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1707), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 580, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1714), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+490", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1715), new TimeSpan(0, 7, 0, 0, 0)), 0, 490 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 581, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1722), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@490", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1722), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 582, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1729), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+491", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1730), new TimeSpan(0, 7, 0, 0, 0)), 0, 491 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 583, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1736), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@491", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1737), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 584, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1744), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+492", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1744), new TimeSpan(0, 7, 0, 0, 0)), 0, 492 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 585, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1751), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@492", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1752), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 586, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1758), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+493", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1759), new TimeSpan(0, 7, 0, 0, 0)), 0, 493 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 587, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1766), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@493", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1767), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 588, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1773), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+494", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1774), new TimeSpan(0, 7, 0, 0, 0)), 0, 494 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 589, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@494", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1781), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 590, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1788), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+495", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1789), new TimeSpan(0, 7, 0, 0, 0)), 0, 495 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 591, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1796), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@495", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1796), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 592, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1825), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+496", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1826), new TimeSpan(0, 7, 0, 0, 0)), 0, 496 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 593, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1834), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@496", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1834), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 594, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1841), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+497", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1842), new TimeSpan(0, 7, 0, 0, 0)), 0, 497 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 595, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1849), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@497", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1850), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 596, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1856), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+498", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1857), new TimeSpan(0, 7, 0, 0, 0)), 0, 498 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 597, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1864), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@498", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1864), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 598, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+499", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1872), new TimeSpan(0, 7, 0, 0, 0)), 0, 499 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 599, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@499", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1880), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, true });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "title", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2552), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, "What is Lorem Ipsum?", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2553), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2556), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, "Why do we use it?", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2557), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2558), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, "Where does it come from?", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2558), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2559), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, "Where can I get some?", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2560), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2629), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2630), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2633), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2634), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2636), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2079), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2079), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2099), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2100), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2117), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2118), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1898), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1899), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1912), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1912), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1945), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1946), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trip_rate", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "rating", "status", "suddenly_cancelled_trips", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 0.0, new Guid("f342adcb-9a12-4371-9f24-26bca5d6112a"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4195), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4198), new TimeSpan(0, 7, 0, 0, 0)), null, null, 1, 1, "Quach Dai Loi", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4196), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 0.0, new Guid("52961fbd-4774-4bc6-a90c-6c3b78cd61cc"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4217), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4222), new TimeSpan(0, 7, 0, 0, 0)), null, null, 2, 1, "Do Trong Dat", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4218), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 0.0, new Guid("e2422381-552b-4246-9355-95529695edc1"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4233), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4235), new TimeSpan(0, 7, 0, 0, 0)), null, null, 3, 1, "Nguyen Dang Khoa", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4234), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 0.0, new Guid("1d8a5111-58d5-4d65-bbe9-5566769c092c"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4245), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4247), new TimeSpan(0, 7, 0, 0, 0)), null, null, 4, 1, "Than Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4246), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 0.0, new Guid("ef2b78cd-166f-43d4-9703-42ebafa74831"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4257), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4259), new TimeSpan(0, 7, 0, 0, 0)), null, null, 5, 1, "Loi Quach", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4257), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 0.0, new Guid("1663ba56-25fe-453f-93c7-8ddd155283dc"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4270), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4274), new TimeSpan(0, 7, 0, 0, 0)), null, null, 6, 1, "Dat Do", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4271), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 0.0, new Guid("208c974d-d5e0-40f9-9774-c965d7692c0b"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4284), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4286), new TimeSpan(0, 7, 0, 0, 0)), null, null, 7, 1, "Khoa Nguyen", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4285), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 0.0, new Guid("9562ee22-de8b-4a44-8c71-0881e651f43f"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4296), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4298), new TimeSpan(0, 7, 0, 0, 0)), null, null, 8, 1, "Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4296), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 0.0, new Guid("1866145a-e645-4959-b3a5-772bc3933e73"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4308), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4310), new TimeSpan(0, 7, 0, 0, 0)), null, null, 13, 1, "Admin Quach Dai Loi", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(4308), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 400, new Guid("f4b51d06-3eb5-44cd-a931-8503cb2a6f8c"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2856), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.400", "Vehicle 400", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2857), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, 2 },
                    { 401, new Guid("c38d5f10-3cb1-4782-b14e-8dde5e12c62b"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2867), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.401", "Vehicle 401", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2868), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, 2 },
                    { 402, new Guid("c708c33d-a861-4108-8f85-27eaa6c2aebb"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.402", "Vehicle 402", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2871), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, 2 },
                    { 403, new Guid("1fbbacec-2ea0-4174-92eb-a6527a20a007"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2876), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.403", "Vehicle 403", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2877), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, 2 },
                    { 404, new Guid("884dec9c-65d1-41e2-bc80-d2e7a1ca8310"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.404", "Vehicle 404", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2880), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, 2 },
                    { 405, new Guid("5bb6d32c-b8b7-42bc-ad2c-370f43b584d3"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2883), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.405", "Vehicle 405", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2884), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, 2 },
                    { 406, new Guid("21d6924f-4f86-4481-9640-feeb596ea100"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2886), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.406", "Vehicle 406", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2887), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, 2 },
                    { 407, new Guid("0a140b41-24df-4b75-a78e-996e0b119ccf"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2890), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.407", "Vehicle 407", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2891), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, 2 },
                    { 408, new Guid("5e6cf94c-797a-4459-9300-72827b4dc164"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2893), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.408", "Vehicle 408", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2894), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, 2 },
                    { 409, new Guid("27d0544f-c036-4d97-9436-369d3208da66"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2897), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.409", "Vehicle 409", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2897), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, 2 },
                    { 410, new Guid("d04b6c18-6ee6-4d2d-8d67-df06d503a931"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.410", "Vehicle 410", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2901), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, 2 },
                    { 411, new Guid("0845c237-ba5e-46fb-aedb-d65923f429e7"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.411", "Vehicle 411", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2906), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, 2 },
                    { 412, new Guid("e84540c1-b398-4b78-b585-1513b44d9bad"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2908), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.412", "Vehicle 412", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2909), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, 2 },
                    { 413, new Guid("cf7d6e16-0d95-4842-a366-19eb510bd545"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2913), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.413", "Vehicle 413", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2913), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, 2 },
                    { 414, new Guid("f2486f7c-e2af-498e-89a1-e3f2bf21dec9"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2916), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.414", "Vehicle 414", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2917), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, 2 },
                    { 415, new Guid("e3f59419-cda6-4788-8676-4c65dbe34da7"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2919), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.415", "Vehicle 415", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2920), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, 2 },
                    { 416, new Guid("0492af37-bb2d-46ab-8f5e-4941d72d91ab"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2923), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.416", "Vehicle 416", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2923), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, 2 },
                    { 417, new Guid("c5d3d9ba-3fcc-4b9a-95fc-ed69d6d2674c"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2926), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.417", "Vehicle 417", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2927), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, 2 },
                    { 418, new Guid("5dcfcaeb-f140-4a54-aac7-377fdf2c9380"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2956), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.418", "Vehicle 418", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2956), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, 2 },
                    { 419, new Guid("62eb47e6-bf33-4c6f-abba-720fc832b548"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2961), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.419", "Vehicle 419", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2962), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, 2 },
                    { 420, new Guid("541e0dfb-ea01-499b-a085-43e4de5f6e79"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2965), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.420", "Vehicle 420", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2965), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, 2 },
                    { 421, new Guid("c6927ce6-6d40-4516-97b9-1fc3fa8bdb0d"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.421", "Vehicle 421", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2969), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, 2 },
                    { 422, new Guid("c4435d84-77fd-400e-9b53-c7addc347054"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2971), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.422", "Vehicle 422", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2972), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, 2 },
                    { 423, new Guid("54bb81c7-beb4-4207-adab-c491bd940a97"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2975), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.423", "Vehicle 423", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2975), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, 2 },
                    { 424, new Guid("3c603a41-3123-4d5f-aa6b-8580b0d069c1"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2978), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.424", "Vehicle 424", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2979), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, 2 },
                    { 425, new Guid("28fabb6f-a27d-46ca-ab62-bebbe02c73d0"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2981), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.425", "Vehicle 425", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2982), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, 2 },
                    { 426, new Guid("c5deae9e-d75d-40c7-ac0e-adcaec1dd992"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2984), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.426", "Vehicle 426", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2985), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, 2 },
                    { 427, new Guid("4c9efd70-1177-4f6b-bac0-33e1561086d6"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2989), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.427", "Vehicle 427", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2990), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, 2 },
                    { 428, new Guid("6d6f5393-7e3d-451e-b201-f500e9ee464c"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2993), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.428", "Vehicle 428", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2994), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, 2 },
                    { 429, new Guid("60156356-4977-40a3-85ea-50c8f01f12ca"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2997), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.429", "Vehicle 429", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2998), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, 2 },
                    { 430, new Guid("a4059652-939f-487b-8bb2-b5062f86ab67"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3001), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.430", "Vehicle 430", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3001), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, 2 },
                    { 431, new Guid("c016ea49-33a6-4b57-8d3e-4e2fd597e543"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3004), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.431", "Vehicle 431", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3004), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, 2 },
                    { 432, new Guid("7b44232d-4e31-4c6d-ab91-9899e7efba9d"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3007), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.432", "Vehicle 432", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3008), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, 2 },
                    { 433, new Guid("908c4a07-09b3-429c-bd50-b1957ac501a4"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3011), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.433", "Vehicle 433", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3011), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, 2 },
                    { 434, new Guid("bf6b08a8-2702-4d17-889a-0463294cdb1f"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3014), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.434", "Vehicle 434", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3014), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, 2 },
                    { 435, new Guid("7c642bc5-8002-42e8-a368-50d6c13add77"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3019), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.435", "Vehicle 435", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3020), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, 2 },
                    { 436, new Guid("5aa77975-7308-491c-8c5e-132053f4064d"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3022), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.436", "Vehicle 436", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3023), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, 2 },
                    { 437, new Guid("ce4221d3-ac3b-40e6-93b3-fd8aa6311999"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3026), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.437", "Vehicle 437", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3026), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, 2 },
                    { 438, new Guid("19691d2a-bc2b-4f89-9623-9da7401644c1"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3029), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.438", "Vehicle 438", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3029), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, 2 },
                    { 439, new Guid("f039a8c1-46e2-4202-9ad2-6f5f79ad6ee5"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3032), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.439", "Vehicle 439", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3033), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, 2 },
                    { 440, new Guid("42e3ee39-26b0-41e5-8628-a74b53882c27"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3035), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.440", "Vehicle 440", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3036), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, 2 },
                    { 441, new Guid("0bcd2872-f32f-44d5-866d-5b0e128cc72b"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3039), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.441", "Vehicle 441", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3039), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, 2 },
                    { 442, new Guid("37a07710-a2ef-4b8f-951b-d105620f68ff"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3042), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.442", "Vehicle 442", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3043), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, 2 },
                    { 443, new Guid("5a93b6df-16c9-4096-826f-e8d43ce7c5d0"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3047), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.443", "Vehicle 443", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3048), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, 2 },
                    { 444, new Guid("cc6d7f6c-2847-487e-b28c-1e85bb4354f1"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3050), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.444", "Vehicle 444", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3051), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, 2 },
                    { 445, new Guid("08f679a9-9706-49fa-941c-d013ecf680db"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3054), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.445", "Vehicle 445", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3055), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, 2 },
                    { 446, new Guid("ac7280c7-e176-4e53-b97c-d692674645f5"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3057), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.446", "Vehicle 446", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3058), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, 2 },
                    { 447, new Guid("0f5dc906-52b1-48a2-b737-266efd67f13f"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3061), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.447", "Vehicle 447", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3061), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, 2 },
                    { 448, new Guid("a2787430-2985-4c30-a855-b2c3c17b72fd"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3064), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.448", "Vehicle 448", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3064), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, 2 },
                    { 449, new Guid("9aa7baec-0a37-4dd4-8c33-52ec079e3ab3"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3067), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.449", "Vehicle 449", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3068), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, 2 },
                    { 450, new Guid("52c9b552-38c1-4a48-86a2-77a593630a9f"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3092), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.450", "Vehicle 450", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3092), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, 2 },
                    { 451, new Guid("b7a3f8e5-6e25-453e-ba0c-eca0f5f614cf"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3097), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.451", "Vehicle 451", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3098), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, 2 },
                    { 452, new Guid("ba0e610f-e423-4007-905e-0b729349080c"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3100), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.452", "Vehicle 452", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3101), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, 2 },
                    { 453, new Guid("2ccef670-a2d0-4d3a-a2a3-a354b7e900ce"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3104), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.453", "Vehicle 453", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3104), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, 2 },
                    { 454, new Guid("c0d289dd-e1dd-4a26-9530-30be89f1fc09"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3107), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.454", "Vehicle 454", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3108), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, 2 },
                    { 455, new Guid("ced93e1e-a929-45db-9726-e2c5f845d97b"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3110), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.455", "Vehicle 455", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3111), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, 2 },
                    { 456, new Guid("a5b52da2-99b4-4320-b8cc-b8989c088ac8"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3113), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.456", "Vehicle 456", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3114), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, 2 },
                    { 457, new Guid("2fe2e2a5-09ab-4082-935b-74e4776eba4a"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3117), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.457", "Vehicle 457", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3118), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, 2 },
                    { 458, new Guid("54a4adac-0cef-432d-8edc-bf72e54115d8"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3120), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.458", "Vehicle 458", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3121), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, 2 },
                    { 459, new Guid("cd4c6cac-e37f-47a6-8c90-dc954e56ecd9"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3125), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.459", "Vehicle 459", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3126), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, 2 },
                    { 460, new Guid("48857a6e-8497-4c0b-9ac2-4fa1d24d8a3b"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.460", "Vehicle 460", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3130), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, 2 },
                    { 461, new Guid("fabcf063-3e89-417f-a175-8fa2b2406d6d"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3133), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.461", "Vehicle 461", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3134), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, 2 },
                    { 462, new Guid("f1de2b24-29d3-4663-a6e5-a93b0c5acdfc"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3136), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.462", "Vehicle 462", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3137), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, 2 },
                    { 463, new Guid("5d02e882-2645-4dea-808f-4872dbc3bd4b"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3140), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.463", "Vehicle 463", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3140), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, 2 },
                    { 464, new Guid("12d28d0b-a1da-4472-9a17-3b7fa1eecec7"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3143), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.464", "Vehicle 464", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3144), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, 2 },
                    { 465, new Guid("0d996d49-6593-4cac-bfce-b1d44c793f9f"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3146), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.465", "Vehicle 465", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3147), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, 2 },
                    { 466, new Guid("d452a7f7-69a8-4759-a7e0-bcfb053a07ba"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3150), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.466", "Vehicle 466", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3151), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, 2 },
                    { 467, new Guid("a8b66a52-a5ca-4067-8fc4-663e05b3e130"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3155), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.467", "Vehicle 467", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3156), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, 2 },
                    { 468, new Guid("1b5362ab-c1a3-4b4b-be0e-89193e4c1a72"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3158), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.468", "Vehicle 468", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3159), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, 2 },
                    { 469, new Guid("905d832d-690f-4e4e-9dbd-3ebb8635b4ab"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3162), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.469", "Vehicle 469", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3162), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, 2 },
                    { 470, new Guid("99792b51-4951-4ee3-84fc-b6069d5d5922"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3165), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.470", "Vehicle 470", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3166), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, 2 },
                    { 471, new Guid("a51d11c7-bb6e-4930-8122-de949945647b"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3168), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.471", "Vehicle 471", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3169), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, 2 },
                    { 472, new Guid("e715d35f-dfa1-4f72-9821-4ca21f13805c"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3172), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.472", "Vehicle 472", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3172), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, 2 },
                    { 473, new Guid("f07aecdc-1576-4620-9b98-f4f63a450ba7"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3175), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.473", "Vehicle 473", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3176), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, 2 },
                    { 474, new Guid("376fe400-10b4-4b29-ae4f-ae46018fc6f0"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3178), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.474", "Vehicle 474", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3179), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, 2 },
                    { 475, new Guid("85165226-154a-48ce-9fbb-07240342e300"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3183), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.475", "Vehicle 475", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3184), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, 2 },
                    { 476, new Guid("340b0174-66bb-4413-a657-80bc1d27fc55"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3187), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.476", "Vehicle 476", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3187), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, 2 },
                    { 477, new Guid("8438b2f7-cd80-4722-9dbe-113e478a2d5f"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3190), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.477", "Vehicle 477", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3191), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, 2 },
                    { 478, new Guid("4c7a115a-623d-432e-a823-1592ce3c0d6c"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3193), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.478", "Vehicle 478", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3194), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, 2 },
                    { 479, new Guid("f689761f-1d7a-4b8a-85cd-b5b88b7ca693"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.479", "Vehicle 479", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3218), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, 2 },
                    { 480, new Guid("273da399-70a8-48ef-8c6e-40f27cc1f762"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3221), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.480", "Vehicle 480", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3222), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, 2 },
                    { 481, new Guid("8cff38d6-f58e-49ca-90eb-39c43d905b94"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3225), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.481", "Vehicle 481", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3225), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, 2 },
                    { 482, new Guid("0ce622c5-974d-44cd-bc62-51b3cd50b69d"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.482", "Vehicle 482", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3229), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, 2 },
                    { 483, new Guid("d103d554-4433-49fa-97ba-a899259757cf"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3233), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.483", "Vehicle 483", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3234), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, 2 },
                    { 484, new Guid("c161151c-2546-47b2-8805-95be2536713e"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3236), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.484", "Vehicle 484", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3237), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, 2 },
                    { 485, new Guid("6bc808e7-1763-4386-a076-7412b0ace76a"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3240), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.485", "Vehicle 485", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3240), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, 2 },
                    { 486, new Guid("25dd3bfa-b9b0-4959-bc60-92dd7b1a84d0"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3243), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.486", "Vehicle 486", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3244), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, 2 },
                    { 487, new Guid("4c861a9e-0608-42f0-8d8f-c2c5c92bc893"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3246), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.487", "Vehicle 487", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3247), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, 2 },
                    { 488, new Guid("cf1bf6c7-7408-4448-8602-f0bca114f4d2"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3250), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.488", "Vehicle 488", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3250), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, 2 },
                    { 489, new Guid("5a175c0c-71f6-4aba-baab-3a5af637a5c1"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3253), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.489", "Vehicle 489", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3254), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, 2 },
                    { 490, new Guid("b9cdd71b-fa84-427a-8b9f-e6d5244cdf5e"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.490", "Vehicle 490", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3257), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, 2 },
                    { 491, new Guid("3e259312-fa66-4b47-9424-3f04ff441ef2"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3261), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.491", "Vehicle 491", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3262), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, 2 },
                    { 492, new Guid("be0b932b-f8c7-4ee8-8ae4-0171f7370100"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3264), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.492", "Vehicle 492", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3265), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, 2 },
                    { 493, new Guid("e564b0fa-af68-4d80-b85f-10bb933bbdbb"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3268), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.493", "Vehicle 493", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3269), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, 2 },
                    { 494, new Guid("cff8552e-6874-429a-9dab-3291d4dc8420"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3271), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.494", "Vehicle 494", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3272), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, 2 },
                    { 495, new Guid("4440ca16-d16f-4dff-9e8c-e63f96e50657"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3275), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.495", "Vehicle 495", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3275), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, 2 },
                    { 496, new Guid("a0b10c30-23d3-476a-9ead-a3efa393a6c5"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3278), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.496", "Vehicle 496", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3279), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, 2 },
                    { 497, new Guid("1eab5b4d-1634-4a57-8011-3179bedafaaa"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3281), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.497", "Vehicle 497", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3282), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, 2 },
                    { 498, new Guid("884a6b78-106d-4745-b709-80c5d9c4cf15"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3285), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.498", "Vehicle 498", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3285), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, 2 },
                    { 499, new Guid("21e19f6a-f4d1-4113-ad61-29e11df880d1"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3290), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.499", "Vehicle 499", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3290), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, 2 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7770), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7780), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7781), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7788), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7789), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7796), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7796), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7803), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7804), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7812), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7813), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7819), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7820), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7827), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7827), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7834), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7835), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7842), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7843), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7850), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7851), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7857), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7858), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7865), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7866), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7873), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7873), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7880), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7880), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7887), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7887), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7918), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7919), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7927), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 612, DateTimeKind.Unspecified).AddTicks(7928), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "ceiling_extra_price", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2692), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2693), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2736), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2737), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2743), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2744), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2750), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2750), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2757), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2764), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2764), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2771), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2771), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2777), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2778), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2784), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2784), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2791), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2792), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2798), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2798), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2804), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2805), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2811), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2811), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(1960), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2056), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2056), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2137), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2137), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2184), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2185), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2208), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2209), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2223), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2223), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2237), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2238), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

            migrationBuilder.InsertData(
                table: "user_licenses",
                columns: new[] { "id", "back_side_file_id", "code", "created_at", "created_by", "deleted_at", "front_side_file_id", "license_type_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 15, "a82e3554-78f9-4451-8a4b-de6b06e9a4b1", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 14, 1, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3849), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 17, "8ab42c2e-f7b2-45ec-acbf-6655819bb42a", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3893), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 16, 2, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3894), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, 19, "f5d81734-1621-46e9-a395-e6c4587fbba8", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3906), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 18, 3, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3907), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, new Guid("6b9b810d-9ef5-43ce-a12a-6b92ab74bc3a"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2845), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2846), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("3079908a-29d3-4809-b770-f0f66fdb51a8"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2850), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2850), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("922b9ef1-0a55-4084-bb1b-71ad904b4cad"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2852), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2852), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("b79ce072-9b04-4f39-b92d-2b6186006338"), new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2854), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(2854), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "type", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 0.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3402), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3403), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 0.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3410), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3410), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 0.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3412), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 0.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3413), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3413), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 0.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3414), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3415), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 0.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3417), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3417), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 0.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3418), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3419), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 0.0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3420), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 24, 19, 39, 9, 613, DateTimeKind.Unspecified).AddTicks(3420), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
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
                name: "IX_license_types_code",
                table: "license_types",
                column: "code",
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
                name: "IX_user_licenses_back_side_file_id",
                table: "user_licenses",
                column: "back_side_file_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_licenses_code",
                table: "user_licenses",
                column: "code",
                unique: true,
                filter: "license_type_id = 3");

            migrationBuilder.CreateIndex(
                name: "IX_user_licenses_front_side_file_id",
                table: "user_licenses",
                column: "front_side_file_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_licenses_license_type_id",
                table: "user_licenses",
                column: "license_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_licenses_user_id",
                table: "user_licenses",
                column: "user_id");

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
                name: "IX_vehicles_license_plate",
                table: "vehicles",
                column: "license_plate",
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
                name: "user_licenses");

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
                name: "license_types");

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
