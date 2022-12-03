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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("1d146607-7c86-45b4-9f3c-05d499ab0e33")),
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 796, DateTimeKind.Unspecified).AddTicks(1993), new TimeSpan(0, 7, 0, 0, 0))),
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("cb86188b-c16a-4b43-80eb-4c00cbcf7d41")),
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
                    { 1, new Guid("756966c9-e671-4726-a1d7-5c095746d27b"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6511), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6512), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("e75bfe30-3a19-4dae-84ed-dd404deb5f38"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6518), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6518), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("71ef0ba0-5df3-4a18-b692-e1d047771836"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6515), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6516), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 17, "Booker canceled your trips, don't worry we will find new trip for you.", 1, "BOOKER CANCEL YOUR TRIP", 0 },
                    { 18, "Hi {0}, We received your driver registration and we will reponse to you the result as soon as posible.", 1, "VIGO: Submit Registration Successfully.", 0 },
                    { 19, "Hi {0}, All your information was approved. Now verify your email to login into our system by click this link: {1}", 1, "VIGO: Final Step To Become Our Driver.", 0 },
                    { 20, "Hi {0}, In order to verify your mail, please click to this link: {1}", 1, "VIGO: Verify Your Email.", 0 },
                    { 21, "Hi {0}, some information of your driver registration was not correct so it was rejected. Please go to our office to support.", 1, "VIGO: Your Driver Registration Was Rejected.", 0 },
                    { 22, "Hi {0}, In order to verify your mail, please click to this link: {1}", 1, "VIGO: Verify Your Phone Number.", 0 }
                });

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "path", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("8cd2607b-9191-4c32-8b7d-8359299aec07"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7780), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7796), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("644dbda8-5614-4994-957f-eb1fe0975ae8"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7813), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7814), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("a4ddb06b-c846-4106-9642-9e711106a5d4"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7822), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7823), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("20bdfe84-7a49-4ea2-ab56-ff5bbdb4a31e"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7863), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7863), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("c54cdbbe-df3c-4c7c-9436-ef8a45fb1da8"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7872), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7873), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("54fa3e2b-6c9b-4c1f-8aca-df5ad4d5273a"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7896), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7897), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("0fcca338-f80d-4801-8906-4f3e26c6e3cd"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7906), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("2a546789-a6f7-4887-8356-da83e4e3c0e5"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7913), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7914), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("62fbbc6f-9bf8-4706-84c0-2bf9bf2bf0fe"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7922), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7922), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("d31737ca-a18e-41fe-82d8-3fbdfd7b1825"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7931), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7932), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("be4414a8-f505-46aa-877e-56b12304f99c"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7939), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7940), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("c1a1a296-8b2e-48f8-a085-e3cc7af90dbd"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7948), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7948), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("8ba21b8b-e24f-42d5-9ade-b5e1d72855e1"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7956), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7957), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, new Guid("dfa60a7a-b831-456c-8106-581d74f7a1f0"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7967), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 4, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7968), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, new Guid("c1f2a554-a786-4e81-b3cd-c10c311a8a04"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 5, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7976), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, new Guid("f71dfb38-f843-4085-a019-05b333f5c833"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7984), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 6, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7984), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, new Guid("37da2a7f-cba5-48ab-9d2a-87ad07aa06f4"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7992), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 7, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(7993), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, new Guid("94f36fc3-8a40-4b23-9a25-62ff508d0b7c"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8002), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 8, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8003), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, new Guid("0e1c8ff9-9766-40fd-9611-ecb629d3a7b7"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8010), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 9, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8011), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "license_types",
                columns: new[] { "id", "code", "name" },
                values: new object[,]
                {
                    { 1, new Guid("eccdf102-c337-4145-bc6e-b95fb613dc0f"), "Identification" },
                    { 2, new Guid("183f8d0e-e6b9-4c34-9977-63d625f865bc"), "Driver License" },
                    { 3, new Guid("e5d9cdb3-1846-45d6-8ec3-8d6287302c91"), "Vehicle Registration Certificate" }
                });

            migrationBuilder.InsertData(
                table: "pricings",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "discount", "lower_bound", "updated_at", "updated_by", "upper_bound" },
                values: new object[,]
                {
                    { 1, new Guid("bc331d3b-4a85-4e57-9ecd-2fffccae7ae4"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.0, null, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6665), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 2, new Guid("01864cf5-f182-45ed-92f6-026c6b2d3bd1"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6668), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.029999999999999999, 8, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6669), new TimeSpan(0, 7, 0, 0, 0)), 0, 30 },
                    { 3, new Guid("0c80b5a0-b373-480c-af92-550aa256f820"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6671), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.050000000000000003, 31, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6672), new TimeSpan(0, 7, 0, 0, 0)), 0, 90 },
                    { 4, new Guid("3751a7f4-d853-4792-93bf-bae7940e290b"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.070000000000000007, 91, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6676), new TimeSpan(0, 7, 0, 0, 0)), 0, null }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5073), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5074), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5081), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5082), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5089), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5090), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("9a233a8e-ee22-49f0-a64c-6efc93acf429"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5386), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5386), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("335a6f8e-b58d-42ad-8944-d793d33c59e1"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5391), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5392), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("133c7068-adcd-42a3-8bf6-87b0e51d8188"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5420), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5421), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b76edc4e-95b9-4e8d-b10a-aa84ab175296"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5424), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f99c4e69-c03d-4bd6-926b-2049217e25e2"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5426), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5426), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("52c0a5bd-a9f1-44eb-ab44-fb03852aee77"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5429), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5430), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("885479f6-5bf6-46cd-8b74-bb69a842a734"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5432), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5432), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8c9685af-3819-47b7-9d1e-a2db4c1d5513"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5434), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5434), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("ec7f70d8-2645-4526-96c0-047f55480743"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5437), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("dafdf59b-61ea-4cfd-af43-789530697d71"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5439), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5440), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b5609be8-e987-4d02-be27-d3d1fa2aa48d"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5443), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5444), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b9e810c2-24a9-48f1-8ce9-afbb99f7eeb7"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5445), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5446), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2d7a3e01-27df-4f5b-87eb-fadbddf3c6e5"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5448), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5448), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("da4d412e-7bef-4417-94d9-c59eb66b3303"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5450), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5451), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8768381e-e1ae-4d54-85de-96176e2f625d"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5453), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5453), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4aa2a400-41b3-4170-b5d8-936dabbccdab"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5455), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5455), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a0078331-9b6a-477e-952f-051957120449"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5457), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5458), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("08bb7388-7a0d-425e-9a21-4cd061c3f41c"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5460), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5461), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1c9281db-5fe8-4b37-a4ef-c19ce887c261"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5464), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5465), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1b415dcc-0b88-4b99-9bb4-8d6c0ea47a0c"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5467), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5467), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dcec4af6-b23b-4ba2-805e-9888ca71bf28"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5469), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5469), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5b506a09-bafc-411d-ad38-67a15a316c9a"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5471), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5472), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6d757ff4-e049-4441-a390-2c1c7c20988a"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5477), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5477), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3124cc4a-a875-49ca-be35-b0f13efc747b"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5479), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5480), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6365a611-ef23-4ecd-9ebb-2410a8512fe8"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5482), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e8d58c22-d4b1-4f96-9bdf-bf889aa7db92"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5485), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5485), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d05a4f13-1557-4a45-ba65-da44cf837272"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5487), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5488), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3b26c5be-3f8b-41fb-96fd-b7758928af65"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5489), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5490), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("55c92046-5d33-4385-aba3-db67d8e71f16"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5492), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5492), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("174b37c7-2b19-4ed7-b8bc-4e40ebcacafd"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5494), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5495), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("612e7863-4c75-46af-9b77-d59fc47993b1"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5496), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5497), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("afd01a98-c535-47b2-834f-39f8867e573b"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5499), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5499), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("aead5abc-1af7-4816-9ccf-e70ef424924c"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5502), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5502), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d189c7b8-9cb9-4bab-8a50-73672dd35c77"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5506), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5506), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("16061f6a-ea43-4c0b-8269-642a31d049e7"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5508), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5509), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3e9fcc46-c56f-4fa9-ac58-e4ebff98583b"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5511), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hòa, Dĩ An, Bình Dương", new Guid("a16aec80-3db3-449d-9557-533bcfc46334"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5513), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5514), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3e8f615c-323b-43bd-bbc0-66aea4828507"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5515), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5516), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3fd79ad0-2217-462e-a332-243868d73640"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5518), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2becf193-5e2d-42e5-8147-0a5ed9aa9246"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5542), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5543), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1a763b87-e879-4b6d-af30-de80db737f4e"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5545), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5546), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("43a35e01-92ea-42f4-94c7-ec58d142c04f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5549), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5550), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("1c43abf3-62e5-4d2e-b056-129a06c32971"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5552), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5552), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("ae382499-cdb8-4b00-a6c5-3fbe4aa2ed6a"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5554), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5554), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("64053074-0294-481d-a3a9-7d1be7cfb611"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5557), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5557), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e291b0c8-f365-46c8-a51d-ac493b4acbc9"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5559), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5560), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("eee00c9b-eb3c-4e2b-9a0e-975b28ae3d91"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5561), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5562), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a6c9fb3a-c6d4-49ff-ae47-7c7e97701634"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5564), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5564), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("12a87138-65c2-493d-a48c-dbf54e864ec5"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5566), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5566), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("722459f8-ec86-4581-bf80-245467503857"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5570), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5570), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("191694aa-cb08-48f2-9472-f46ad1694240"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5572), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0200adce-e942-4e1e-a630-8c143e0f089f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5574), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5575), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6bfeb8d0-a4a4-486b-8187-e103271a747a"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5576), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5577), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b2887dff-9efd-4e1d-aa70-2e80d8e75d9a"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5579), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5579), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b1d56b22-4477-4baf-8b67-441845400294"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5581), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5581), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("af649d89-8f9b-458d-94e3-cff12b0fe490"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5583), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5583), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("801bdd5e-70a6-4f90-8ada-0f5c74a70365"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5585), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5586), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f6e2bf30-ef6a-45ba-a5ef-e4339eef9d05"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5589), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5589), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0c779214-ce92-4d75-92c6-3b1c190e1c57"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5591), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5592), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("14ddbfe5-eaa1-4184-ab57-5e22e923813f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5593), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5594), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7facdc0b-e08e-46ca-9935-9bd5a0b37993"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5596), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5596), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1cb3b1c7-08b4-491a-9eab-c360add30222"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5598), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5598), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("edd219eb-ff64-40af-8f88-6d73ee4d94ca"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5600), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5601), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a073624f-c275-487d-90da-b5a62d2fa731"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5602), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5603), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("45a2a365-2b6d-4f3c-86a2-f3ce69834b5f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5606), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5606), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4c721bce-e1bb-46ab-add2-3fae3ff1e8d1"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5610), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5610), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("595bf9c2-4085-49f2-a1a4-c093cdbf63af"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5612), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5612), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a1f5db19-c2fc-4f69-a7c4-7f751e72287e"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5615), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5616), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a18cd249-c666-4ea3-b254-790bea26f0cb"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5617), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5618), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("94c5b44b-c79c-43b6-973d-e290e897ce6e"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5620), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5620), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5918a1f7-cfce-48b3-a0d5-ee0e1691062d"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5622), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5622), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cf8b7723-c25a-47ef-9898-a9ad2052e388"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5624), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5625), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("51059305-5a39-400b-a288-19b2197d5110"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5626), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5627), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("79bfea29-f224-4b6e-8d58-89f91c529357"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5630), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5631), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d6967839-daf3-4796-9350-db2758e579c5"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5632), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5633), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("484eb6b0-fefd-4df4-9682-e55fdf081cec"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5635), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5e9c404e-a418-46ff-b86e-86f87f065c37"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5637), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5638), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a190c8e7-85fe-4218-90aa-cdc65b95053b"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5639), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5640), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7858e38c-5586-426c-8957-e6b170a8aeb3"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5663), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5664), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("99a9f45c-96a7-4b6e-a87f-607d9520cfaa"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5666), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5666), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("65ddb096-c5ca-461d-8a37-946a4f031768"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5668), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5669), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("894960eb-24f7-4162-af36-6f4e84902fed"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5672), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5673), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("401e24e9-981f-4e9e-8d7a-b9fb837de3da"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5674), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5675), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("879cb2e8-a5a3-407c-a86a-0e99ab4f8684"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5677), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5677), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f3859ec5-fc17-4db1-aa61-90482dbd9240"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5474), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5475), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô K1-G3 Đường D1, Phường Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0a0eaeaf-18bb-4db1-92ab-f2f8e850ec42"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5679), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5679), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trip_rate", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "rating", "status", "suddenly_cancelled_trips", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 10, 0.0, new Guid("04d2423a-2c01-4e84-9c00-24171fae4f65"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8211), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8213), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Admin Than Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8212), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 0.0, new Guid("1cb71487-cce8-43e8-980a-de2dbc85a7c5"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8223), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8225), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Admin Nguyen Dang Khoa", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8224), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 0.0, new Guid("50d384ee-8a98-4e8d-900c-e512f8869423"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8235), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8237), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Admin Do Trong Dat", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8236), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 100, 0.0, new Guid("40df7893-25d4-4358-abd7-14e3db88cf11"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8273), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8286), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 100", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8273), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 101, 0.0, new Guid("7b9a27ef-b286-4a37-ba95-4c1694dc2664"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8301), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8304), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 101", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8301), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 102, 0.0, new Guid("c9a95db3-e4fd-4109-a576-36b873ac0699"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8314), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8317), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 102", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8315), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 103, 0.0, new Guid("e3f77e42-e086-44d5-81a9-14fe9ba1e9d0"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8328), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8330), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 103", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8328), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 104, 0.0, new Guid("38175593-d354-4642-8363-63b0f75fdd29"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8341), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8343), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 104", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8341), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 105, 0.0, new Guid("1d18590c-542d-419d-951f-e04404b771c5"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8357), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8360), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 105", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8358), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 106, 0.0, new Guid("2ef38f2d-635f-4959-bed2-f73c758b5a07"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8371), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8374), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 106", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8371), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 107, 0.0, new Guid("1b3e8c49-fd0c-4ba3-b8fd-5f4af5cb2a8f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8383), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8386), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 107", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8384), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 108, 0.0, new Guid("69bcdea0-18ee-4aa8-b7d6-c492c2dddfd3"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8396), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8399), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 108", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8396), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 109, 0.0, new Guid("44274b96-eff7-4f14-95d6-30b6d3a91d19"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8410), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8413), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 109", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8411), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 110, 0.0, new Guid("2070fbfe-8106-43d0-bcc2-900e62b62c4b"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8446), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8449), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 110", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8447), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 111, 0.0, new Guid("9e80c564-2ce2-4fad-a21c-b3a102916944"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8461), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8464), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 111", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8462), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 112, 0.0, new Guid("f366046e-0953-4362-9a71-6fc855e97fcf"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8474), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8477), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 112", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8474), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 113, 0.0, new Guid("91497075-4dbe-492b-845a-c47ea0f803af"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8488), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8491), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 113", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8489), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 114, 0.0, new Guid("2047bce0-0258-4578-8f2f-534548a970e3"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8501), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8504), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 114", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8502), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 115, 0.0, new Guid("b50ddd4f-e5e4-423f-baa8-26b4bc0024bf"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8514), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8517), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 115", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8514), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 116, 0.0, new Guid("0aa00af2-17f3-4e21-bc9d-cfc50388ce3c"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8526), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8530), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 116", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8527), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 117, 0.0, new Guid("60d38171-e514-437c-ac35-86d66134bca6"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8541), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8544), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 117", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8542), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 118, 0.0, new Guid("a5da0dde-ef06-4825-9c40-d98f50fadc05"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8554), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8557), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 118", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8555), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 119, 0.0, new Guid("b36be64e-1082-4223-b64d-340a067fe6b3"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8567), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8570), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 119", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8568), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 120, 0.0, new Guid("12353587-96dc-4c68-99a6-39bfa2e78b4e"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8580), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8583), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 120", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8580), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 121, 0.0, new Guid("4c961acb-b87d-4e3f-ad37-2afb3adfeb34"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8621), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8624), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 121", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8621), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 122, 0.0, new Guid("37e53b29-ec34-4024-9d01-f16c01e05531"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8635), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8638), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 122", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8635), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 123, 0.0, new Guid("43a01560-660e-48bb-96d9-4469cc00bd15"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8647), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8650), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 123", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8648), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 124, 0.0, new Guid("25f88177-7653-4a3a-bf1c-8a1c9783036e"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8660), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8663), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 124", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8661), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 125, 0.0, new Guid("367d94e2-0c98-4119-9867-406456844bb5"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8674), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8677), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 125", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8675), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 126, 0.0, new Guid("5a9fc981-f643-4904-bf31-2c80162ad612"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8687), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8690), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 126", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8688), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 127, 0.0, new Guid("c70900c7-37ea-46c7-89de-1738284a441e"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8700), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8703), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 127", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8700), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 128, 0.0, new Guid("8d3d6d2f-3780-4e5f-bfc0-806c0dbb7e6f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8712), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8715), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 128", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8713), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 129, 0.0, new Guid("379068c7-3752-40ab-86de-3e85b31be01f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8727), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8729), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 129", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8727), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 130, 0.0, new Guid("d81b1d1a-d666-49a5-bbcb-630ef6772061"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8739), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8742), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 130", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8740), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 131, 0.0, new Guid("a6e3141f-0018-4a0e-ac53-ca5659aedf7a"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8774), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8777), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 131", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8775), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 132, 0.0, new Guid("0016dc52-8df7-4b10-bae7-91c4dffd1d6f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8788), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8791), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 132", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8789), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 133, 0.0, new Guid("3ddc7a2b-dee4-4445-921a-d020442ab35f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8803), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8806), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 133", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8803), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 134, 0.0, new Guid("a3d7f5db-e5b4-4afc-9622-b1e013ef5396"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8816), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8819), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 134", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8816), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 135, 0.0, new Guid("b6239b71-6bb4-4a64-b302-9ee3f2a530ba"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8829), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8831), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 135", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8829), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 136, 0.0, new Guid("5f8e2012-404d-4aa5-947f-e461e77dc377"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8841), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8844), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 136", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8842), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 137, 0.0, new Guid("de6991c9-50b5-4be7-b421-ec88fd0b4b86"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8855), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8858), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 137", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8856), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 138, 0.0, new Guid("c025b3fb-1651-4ca2-86a3-8ed2b2a153f7"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8868), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8871), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 138", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8869), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 139, 0.0, new Guid("eeaf5dc2-1990-4543-85c4-0d79c546858f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8881), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8884), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 139", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8882), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 140, 0.0, new Guid("05206b74-73d8-44dc-9d13-ca605ae4931c"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8894), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8897), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 140", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8894), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 141, 0.0, new Guid("f44c4b21-41e4-43df-b68d-39d101b7cce2"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8908), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8911), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 141", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8909), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 142, 0.0, new Guid("bf68e077-97d1-44be-ba0f-e9eace108d4f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8948), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8951), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 142", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8949), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 143, 0.0, new Guid("5f3ec149-7d8a-4e83-b579-3199fd80a06c"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8962), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8965), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 143", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8962), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 144, 0.0, new Guid("f0d91e02-8151-4803-aaa7-831a01c1ec1f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8975), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8978), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 144", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8976), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 145, 0.0, new Guid("71de6c53-9793-4c27-910f-1f08303dbba2"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8990), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8993), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 145", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8990), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 146, 0.0, new Guid("5dc61021-1f67-4ca7-92a6-78e269fe9cca"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9003), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9006), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 146", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9003), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 147, 0.0, new Guid("ff80809b-f73f-469a-8d95-604d78628292"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9016), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9019), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 147", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9016), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 148, 0.0, new Guid("3e7e925f-3fa7-4e17-af34-3f43765d68b6"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9029), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9032), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 148", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9029), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 149, 0.0, new Guid("ced33d3b-0969-4256-bd02-6cc91db2d29b"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9043), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9046), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 149", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9044), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 150, 0.0, new Guid("cb51cb73-d8b1-4660-acb3-a334c8d30bff"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9056), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9059), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 150", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9057), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 151, 0.0, new Guid("9c5494b6-af30-493c-bfd4-75b8120ff2dd"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9069), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9072), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 151", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9070), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 152, 0.0, new Guid("1da941af-8849-479b-88ee-748bacc8740c"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9104), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9107), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 152", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9104), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 153, 0.0, new Guid("aaef7165-ca63-45c1-b391-928ac2ad17f8"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9123), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9126), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 153", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9123), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 154, 0.0, new Guid("72923ca3-24d5-4a21-bbe2-e51a9756560f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9136), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9139), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 154", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9136), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 155, 0.0, new Guid("e9b21a16-251c-4bc4-adfd-26fca263cc1f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9148), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9151), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 155", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9149), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 156, 0.0, new Guid("da2a9da1-a4b0-4721-8650-55324dae7ffd"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9161), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9164), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 156", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9162), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 157, 0.0, new Guid("e02a8fba-d82d-4b76-a365-c53a83c91afc"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9176), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9179), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 157", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9176), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 158, 0.0, new Guid("ff2d8014-6d37-4734-b421-68fad344d69d"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9188), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9191), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 158", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9189), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 159, 0.0, new Guid("511fc068-1d83-4223-9a18-708c78e458cf"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9201), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9204), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 159", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9202), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 160, 0.0, new Guid("a9c7cdf6-b3d4-49fa-977e-bc0b47caf336"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9213), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9216), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 160", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9214), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 161, 0.0, new Guid("ea0dadb6-5a20-4784-b3a0-fea263b7fe78"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9228), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9231), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 161", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9228), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 162, 0.0, new Guid("ff6a09e4-3008-4848-98a5-d81662c35c44"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9264), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9267), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 162", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9264), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 163, 0.0, new Guid("17db6bab-5a80-44fe-98bb-23b5ace26b27"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9278), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9281), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 163", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9279), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 164, 0.0, new Guid("77ce71a2-0b61-40f3-be75-32ba5e4d2fc5"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9291), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9294), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 164", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9292), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 165, 0.0, new Guid("c9df692e-f805-4186-91bd-781bee9bf5e9"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9306), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9309), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 165", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9306), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 166, 0.0, new Guid("04dd08e9-9656-46c9-b842-84bb05d4b941"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9319), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9322), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 166", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9319), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 167, 0.0, new Guid("ce280fb6-8aea-4c1b-aff6-d11d0f673bc6"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9331), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9334), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 167", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9332), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 168, 0.0, new Guid("adca0e4c-a6fe-42f8-a439-6ce65347d329"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9344), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9347), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 168", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9345), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 169, 0.0, new Guid("881b3320-b25f-4aeb-be5a-dfeeeada58d9"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9359), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9361), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 169", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9359), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 170, 0.0, new Guid("ebabf646-e6dc-4825-b226-489db1d802e7"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9371), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9374), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 170", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9372), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 171, 0.0, new Guid("c4f8ef0e-75ea-4ad0-bacd-6904712fcdd3"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9384), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9387), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 171", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9385), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 172, 0.0, new Guid("35e64ffe-0535-4742-9237-bfab18c2a4f2"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9397), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9399), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 172", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9397), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 173, 0.0, new Guid("421837e3-217c-4b54-9bfb-9532db963f61"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9450), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9454), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 173", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9451), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 174, 0.0, new Guid("bf094550-0bc1-431e-bb36-0aab0e798f98"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9465), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9468), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 174", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9465), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 175, 0.0, new Guid("8794b137-bb63-45db-9482-03d0e36feb34"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9477), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9480), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 175", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9478), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 176, 0.0, new Guid("889a1035-689c-4ca1-bda1-6e736e20307a"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9490), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9493), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 176", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9491), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 177, 0.0, new Guid("ed729bbb-0f93-4c51-8cc0-7d4a16bded3b"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9504), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9507), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 177", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9505), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 178, 0.0, new Guid("d1867ee0-689a-424b-a0d2-dd1e29a01cea"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9517), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9520), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 178", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9518), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 179, 0.0, new Guid("afb1a8fa-5dbd-49c2-887f-fdaad10193d7"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9530), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9532), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 179", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9530), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 180, 0.0, new Guid("f95dfcec-8637-4adb-a3c0-789736b4e762"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9542), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9545), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 180", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9543), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 181, 0.0, new Guid("315f0fa1-5a31-4c07-a38c-6efe01ab23e4"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9556), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9559), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 181", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9557), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 182, 0.0, new Guid("c663a906-1277-4d90-b1e9-548669fe179e"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9569), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9572), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 182", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9570), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 183, 0.0, new Guid("e015107c-276b-47aa-b1da-cabeb89fe023"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9606), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9609), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 183", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9606), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 184, 0.0, new Guid("60857ab8-a084-45ff-838b-9074328e2673"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9621), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9623), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 184", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9621), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 185, 0.0, new Guid("8f486c50-a284-4039-85de-d67410624e71"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9635), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9638), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 185", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9635), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 186, 0.0, new Guid("440b2d27-928a-4529-8eae-42147b0fef68"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9648), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 186", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9648), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 187, 0.0, new Guid("0f48a834-1bce-4e73-999b-df1918aa91a6"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9660), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9663), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 187", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9661), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 188, 0.0, new Guid("ab13a612-9a24-4a45-8281-96b7b01711f7"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9673), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9676), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 188", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9673), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 189, 0.0, new Guid("592e4a21-f7e3-4f03-b216-9006f9df65bd"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9687), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9690), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 189", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9688), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 190, 0.0, new Guid("c2fc13fb-3a08-4429-b191-d26b112aa6ec"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9700), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9703), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 190", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9701), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 191, 0.0, new Guid("29742c44-a8ba-4a7e-8557-49490e285ab1"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9712), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9715), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 191", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9713), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 192, 0.0, new Guid("d4bd4216-07f7-4041-9c9e-b3a4a056d4c2"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9725), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9728), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 192", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9726), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 193, 0.0, new Guid("78ec2a8a-28a9-4cba-9a92-f30aa8299ff1"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9739), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9742), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 193", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9740), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 194, 0.0, new Guid("99e7f1ca-af26-4182-952e-d68e32adf74f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9776), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9779), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 194", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9776), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 195, 0.0, new Guid("823086c5-6857-427c-8e3f-dad7cdf519bc"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9790), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9793), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 195", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9791), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 196, 0.0, new Guid("b146426c-a656-439d-a524-9ae6e255bd1a"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9803), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9805), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 196", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9803), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 197, 0.0, new Guid("a52f4b86-5824-4ec2-9e6d-5c6cd2dd3f8e"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9817), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9820), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 197", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9817), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 198, 0.0, new Guid("472b71ab-ec13-49fe-beff-52f1a021f850"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9829), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9832), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 198", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9830), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 199, 0.0, new Guid("593cd984-279d-414c-b794-96d573b6b558"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9842), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9845), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 199", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9843), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 400, 0.0, new Guid("038c8222-49e3-40cd-9276-f44b13d1ee17"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9856), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 400", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9856), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 401, 0.0, new Guid("a0606f57-9715-424a-b7be-6a87202c4276"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9869), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 401", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9870), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 402, 0.0, new Guid("cd909635-cd17-4620-9039-83e2cedccd4e"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9880), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 402", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9881), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 403, 0.0, new Guid("d6abf710-1443-4bb8-a46f-f1a9b850e008"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9891), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 403", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9891), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 404, 0.0, new Guid("93618dc2-3a1e-4524-8015-5a99a5e60e15"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9902), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 404", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9902), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 405, 0.0, new Guid("2091c402-8e20-4ae9-a12a-f8e3a317ea88"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9938), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 405", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9939), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 406, 0.0, new Guid("00b74a99-6799-47cb-9c39-7e583a24a4fa"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9950), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 406", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9951), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 407, 0.0, new Guid("aead915c-54cc-4475-87e0-6c8ef138a7cd"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9961), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 407", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9962), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 408, 0.0, new Guid("6b5a9da8-50b4-47c7-88d9-f67516caf834"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 408", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9973), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 409, 0.0, new Guid("669affc2-5af5-4711-a87f-d89b704101b2"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9985), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 409", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9985), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 410, 0.0, new Guid("bfabe930-dedb-44db-883c-c02f3db8af43"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9996), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 410", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(9996), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 411, 0.0, new Guid("f1ca0462-ee75-4dd4-8c76-100af8387bb9"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(7), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 411", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(7), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 412, 0.0, new Guid("c161dc24-c3e3-46fa-8b81-644331b95f66"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(17), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 412", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(18), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 413, 0.0, new Guid("9382557d-59a7-435c-9242-a99853f73b51"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(30), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 413", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(30), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 414, 0.0, new Guid("d2e1f395-f63a-4805-8d57-54347a57eceb"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(41), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 414", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(41), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 415, 0.0, new Guid("8d8ad212-e540-4431-a8b5-a47372a811e3"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(51), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 415", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(52), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 416, 0.0, new Guid("0a7044b6-f46e-4602-b183-50eccef3f01e"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(91), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 416", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(91), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 417, 0.0, new Guid("d4a8fa4e-6145-4136-a730-f52aaa475d18"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(106), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 417", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(107), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 418, 0.0, new Guid("b6244e88-391a-4e13-be18-8f96f5cb9861"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(117), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 418", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(118), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 419, 0.0, new Guid("e4d4972d-a14d-49a0-8de4-2968ed3e29dd"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(128), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 419", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(129), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 420, 0.0, new Guid("a9895bf2-c71e-4668-8f68-2bfc9671aca9"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(139), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 420", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(139), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 421, 0.0, new Guid("c53d0664-016b-4e41-a04f-0b74bbd4b214"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(151), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 421", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(152), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 422, 0.0, new Guid("1d9b4483-c117-406d-87a9-c6b4e636413e"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(162), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 422", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(163), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 423, 0.0, new Guid("176e8e32-ceaf-4805-80f6-b615544fbd77"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 423", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(173), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 424, 0.0, new Guid("e9e205ef-e41c-4ce7-8884-52b499fb0326"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(208), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 424", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(208), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 425, 0.0, new Guid("901a0dbc-0b39-479a-b903-13a0ed299d59"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(221), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 425", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(221), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 426, 0.0, new Guid("831558e4-4450-4a2c-ae84-40b0f4697cfe"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(232), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 426", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(232), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 427, 0.0, new Guid("a96d0457-4ca4-43a0-b7b9-f07da135bc2b"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(243), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 427", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(243), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 428, 0.0, new Guid("aad1a212-8c62-4860-97ce-080985d76a71"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(253), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 428", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(254), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 429, 0.0, new Guid("2434c256-5a0e-41d4-8ddf-2c96967b7ab5"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 429", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(267), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 430, 0.0, new Guid("8dbcd12e-bbb4-4418-a6fb-7c6b6fac9563"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(277), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 430", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(278), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 431, 0.0, new Guid("d4cb3573-aecc-4299-b6eb-9c344c474eb7"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(287), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 431", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(288), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 432, 0.0, new Guid("da347e93-3385-45d2-8e90-06d3072fffe1"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(299), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 432", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(299), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 433, 0.0, new Guid("0a183c74-936d-4e16-9adf-6ed24e5137b1"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(311), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 433", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(312), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 434, 0.0, new Guid("4c097a30-063e-4abd-b662-2f5e3fe71de3"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(344), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 434", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(345), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 435, 0.0, new Guid("2b67bcd9-0180-495c-96ec-1840d514a78c"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(357), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 435", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(358), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 436, 0.0, new Guid("cf6856c4-b192-4ccf-8dfb-adb374c0a3f8"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 436", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(369), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 437, 0.0, new Guid("993b6983-fdbd-44f0-a31f-ddc57f949d00"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 437", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(381), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 438, 0.0, new Guid("0eb18dc3-2517-4cd9-b35e-295fc731ad85"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(391), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 438", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(392), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 439, 0.0, new Guid("9821cc04-aa19-4cbf-bc42-4838c227105b"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(402), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 439", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(402), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 440, 0.0, new Guid("ad1a9430-1dd6-402b-a4d9-2cecdd94b75a"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(413), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 440", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(413), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 441, 0.0, new Guid("73d3306b-5d33-4f12-b20c-4d16ef33da7c"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(425), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 441", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(426), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 442, 0.0, new Guid("de8e8d2f-cbf4-4a96-80a7-87f333f75a3a"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 442", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(437), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 443, 0.0, new Guid("79325488-8484-45a9-9f8d-bb16c81b8f38"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(447), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 443", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(447), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 444, 0.0, new Guid("b2d0d0fa-4a43-4ff2-9743-8e3d9c42e652"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(457), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 444", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(458), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 445, 0.0, new Guid("326718c8-9eed-47c6-8991-f0a7e72af894"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(492), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 445", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(493), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 446, 0.0, new Guid("5fab6ab5-f064-4ed6-91af-f60fa422ec99"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(505), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 446", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(505), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 447, 0.0, new Guid("6ae84276-e839-491e-8a69-cc31a7eae83c"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(531), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 447", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(532), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 448, 0.0, new Guid("0b295275-dd6a-44d1-8328-66aac2973c1b"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(542), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 448", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(543), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 449, 0.0, new Guid("a9ff5cb2-a621-4292-aee8-5b75e3c028d1"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(555), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 449", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(555), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 450, 0.0, new Guid("60247631-7082-4083-bae3-3dbbfe887c67"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(566), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 450", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(566), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 451, 0.0, new Guid("76d3a389-e8f5-4140-b0b5-2ef01eb04655"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(576), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 451", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(577), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 452, 0.0, new Guid("2d3410ed-7b3e-49b1-af1b-6cc434f366ff"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 452", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(588), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 453, 0.0, new Guid("ae3b5047-aa18-402c-bfe5-5015a5957fb8"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(600), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 453", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(600), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 454, 0.0, new Guid("9dacf75f-27e0-45f4-ae3e-ec7aca355950"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(611), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 454", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(611), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 455, 0.0, new Guid("ac94f3cf-b561-4780-bb92-0ba708c4d0b7"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(621), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 455", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(622), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 456, 0.0, new Guid("d80aadac-50bd-41f4-990b-5ebf589c8f28"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(665), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 456", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(666), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 457, 0.0, new Guid("ca2839fe-cb8f-425c-b08a-76fb14c74fb8"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 457", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(681), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 458, 0.0, new Guid("a0709f99-abe7-43e7-81f3-433d8fad715e"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(692), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 458", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(693), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 459, 0.0, new Guid("b81e9e1d-7c43-4a8e-bd58-a02f89d36e1e"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(702), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 459", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(703), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 460, 0.0, new Guid("ac67ffc1-f266-4fe2-b237-63503389f1f7"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(713), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 460", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(714), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 461, 0.0, new Guid("7dfe8d8e-37cf-4c9e-a7c4-4b742ec67595"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(725), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 461", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(726), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 462, 0.0, new Guid("c0a051fd-0fae-4f17-af5a-ce14a397c382"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(736), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 462", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(737), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 463, 0.0, new Guid("0ffcd137-e6fa-43ff-9298-359b39aa4135"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(747), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 463", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(747), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 464, 0.0, new Guid("f656cc32-0f0e-4be7-96f6-22135c4b4b14"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(757), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 464", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(758), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 465, 0.0, new Guid("bbe4add6-2518-4095-8762-9bab0f187cb3"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(770), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 465", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(770), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 466, 0.0, new Guid("f86578dc-91af-46db-8df4-c6f3b9c0876d"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 466", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(781), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 467, 0.0, new Guid("1de3346b-09f2-4643-8070-1281261dcbea"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(815), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 467", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(815), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 468, 0.0, new Guid("f98d3a23-2343-484e-8b1e-b738750dd1b0"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(826), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 468", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(827), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 469, 0.0, new Guid("6eefc70c-e8d6-48d8-b1c7-655d80a00068"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(839), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 469", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(839), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 470, 0.0, new Guid("48cf7080-0769-469e-9bf2-d1b0a1ddd5de"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(849), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 470", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(850), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 471, 0.0, new Guid("a24c94f9-01c4-4b69-8c8e-e5ef4a7afafe"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(860), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 471", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(860), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 472, 0.0, new Guid("2216d1b9-24ee-4c23-8608-481194c20a15"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(870), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 472", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(871), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 473, 0.0, new Guid("9d312cea-6627-43bc-b6e7-67eac2c4b991"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(883), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 473", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(883), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 474, 0.0, new Guid("b220a790-c31c-4b18-a43a-ee31c43d5b14"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(893), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 474", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(894), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 475, 0.0, new Guid("474674f5-c5f8-49ca-96d0-b3f97c09885f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(904), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 475", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(905), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 476, 0.0, new Guid("db6b3182-2e40-4217-b989-d7274343bfe8"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(915), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 476", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(916), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 477, 0.0, new Guid("30ef6788-3504-4715-a472-b7fbec47d313"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(950), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 477", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(950), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 478, 0.0, new Guid("bc18dfed-ff39-4a48-b354-03e6d25442f5"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 478", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(963), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 479, 0.0, new Guid("b6aa561b-ac91-4254-a76b-eaae32069739"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(973), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 479", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(974), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 480, 0.0, new Guid("217d7610-dba1-40ac-9c63-bedb1483b947"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(983), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 480", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(984), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 481, 0.0, new Guid("84ad6c7a-2ec9-4e05-8aaf-53c8d1b4e941"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(996), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 481", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(997), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 482, 0.0, new Guid("fd865f51-d60b-4501-96ad-a375b65ee73a"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1007), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 482", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1008), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 483, 0.0, new Guid("cff37a98-4341-44ff-a639-2ec8a6e32537"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1018), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 483", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1018), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 484, 0.0, new Guid("9f1ce47b-7c86-4a9a-8751-199133b83ec8"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1029), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 484", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1029), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 485, 0.0, new Guid("30485635-ecd9-4fbf-8e0b-4829d6193382"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1041), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 485", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1042), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 486, 0.0, new Guid("dbb3c52e-71ec-4a21-920d-197174ec4478"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1052), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 486", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1053), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 487, 0.0, new Guid("05f57496-d51a-4c8e-97c3-acbc42cd0b27"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1063), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 487", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1063), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 488, 0.0, new Guid("1d56a671-bbee-44f3-8917-98f56c57330d"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1098), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 488", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1099), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 489, 0.0, new Guid("31af92aa-7390-487b-9312-5fa68dcf1175"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1113), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 489", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1113), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 490, 0.0, new Guid("3abcf4f3-c832-4b49-b728-6774f0e6b73a"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1123), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 490", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1124), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 491, 0.0, new Guid("1e4ff3f6-8a7b-4f31-b576-e686066f0e14"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1134), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 491", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1135), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 492, 0.0, new Guid("51f31e15-618d-46db-a858-f32f3d9453ad"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1145), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 492", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1145), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 493, 0.0, new Guid("d1161974-0af9-445a-852d-78728eb422cf"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 493", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1158), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 494, 0.0, new Guid("c5922e3b-d8bf-48e9-85fd-c49777ba05d7"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1168), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 494", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1169), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 495, 0.0, new Guid("7ced479b-d497-4c69-8a78-1df147cc4769"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1179), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 495", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1179), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 496, 0.0, new Guid("709eb529-530b-469b-b5d5-49ab62a31b53"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1190), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 496", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1190), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 497, 0.0, new Guid("612c0172-af23-4da9-af74-b5907ca1defc"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1202), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 497", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1202), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 498, 0.0, new Guid("3ce72b3c-c834-47b2-904f-63e1bcb92e31"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1213), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 498", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1213), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 499, 0.0, new Guid("99bbfa82-03ce-45ba-b0d2-8a1d4252e821"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1246), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 499", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1247), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "name", "slot", "status", "type" },
                values: new object[,]
                {
                    { 1, new Guid("f6fbbafc-79e7-4a4a-8813-5822f21cf7ac"), "ViRide", 2, 1, 0 },
                    { 2, new Guid("bce1fc8d-7bc8-4099-8c65-0c663790b7d9"), "ViCar-4", 4, 1, 1 },
                    { 3, new Guid("e0c94d82-2d4f-4604-811a-325e0b7df2d5"), "ViCar-7", 7, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "type", "updated_at", "updated_by", "user_id" },
                values: new object[] { 9, 0.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6593), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6594), new TimeSpan(0, 7, 0, 0, 0)), 0, null });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1409), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1409), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1416), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1416), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1447), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1447), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1456), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1456), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1463), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1464), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1470), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1471), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 100, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1478), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+100", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1479), new TimeSpan(0, 7, 0, 0, 0)), 0, 100, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 101, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1489), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@100", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1489), new TimeSpan(0, 7, 0, 0, 0)), 0, 100 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 102, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1499), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+101", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1500), new TimeSpan(0, 7, 0, 0, 0)), 0, 101, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 103, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1507), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@101", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1508), new TimeSpan(0, 7, 0, 0, 0)), 0, 101 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 104, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1515), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+102", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1516), new TimeSpan(0, 7, 0, 0, 0)), 0, 102, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 105, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1523), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@102", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1524), new TimeSpan(0, 7, 0, 0, 0)), 0, 102 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 106, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1531), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+103", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1531), new TimeSpan(0, 7, 0, 0, 0)), 0, 103, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 107, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1538), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@103", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1539), new TimeSpan(0, 7, 0, 0, 0)), 0, 103 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 108, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1546), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+104", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1547), new TimeSpan(0, 7, 0, 0, 0)), 0, 104, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 109, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1555), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@104", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1556), new TimeSpan(0, 7, 0, 0, 0)), 0, 104 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 110, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1563), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+105", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1564), new TimeSpan(0, 7, 0, 0, 0)), 0, 105, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 111, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@105", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1571), new TimeSpan(0, 7, 0, 0, 0)), 0, 105 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 112, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1579), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+106", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1579), new TimeSpan(0, 7, 0, 0, 0)), 0, 106, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 113, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1586), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@106", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1587), new TimeSpan(0, 7, 0, 0, 0)), 0, 106 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 114, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1594), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+107", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1594), new TimeSpan(0, 7, 0, 0, 0)), 0, 107, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 115, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1601), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@107", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1602), new TimeSpan(0, 7, 0, 0, 0)), 0, 107 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 116, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1609), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+108", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1610), new TimeSpan(0, 7, 0, 0, 0)), 0, 108, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 117, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1640), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@108", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1641), new TimeSpan(0, 7, 0, 0, 0)), 0, 108 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 118, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1650), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+109", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1650), new TimeSpan(0, 7, 0, 0, 0)), 0, 109, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 119, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1657), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@109", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1658), new TimeSpan(0, 7, 0, 0, 0)), 0, 109 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 120, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1665), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+110", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1666), new TimeSpan(0, 7, 0, 0, 0)), 0, 110, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 121, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1673), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@110", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1673), new TimeSpan(0, 7, 0, 0, 0)), 0, 110 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 122, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+111", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1681), new TimeSpan(0, 7, 0, 0, 0)), 0, 111, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 123, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@111", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1689), new TimeSpan(0, 7, 0, 0, 0)), 0, 111 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 124, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1696), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+112", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1696), new TimeSpan(0, 7, 0, 0, 0)), 0, 112, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 125, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1703), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@112", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1704), new TimeSpan(0, 7, 0, 0, 0)), 0, 112 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 126, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1711), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+113", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1712), new TimeSpan(0, 7, 0, 0, 0)), 0, 113, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 127, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1718), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@113", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1719), new TimeSpan(0, 7, 0, 0, 0)), 0, 113 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 128, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1726), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+114", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1726), new TimeSpan(0, 7, 0, 0, 0)), 0, 114, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 129, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1733), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@114", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1734), new TimeSpan(0, 7, 0, 0, 0)), 0, 114 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 130, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1741), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+115", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1742), new TimeSpan(0, 7, 0, 0, 0)), 0, 115, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 131, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1748), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@115", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1749), new TimeSpan(0, 7, 0, 0, 0)), 0, 115 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 132, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1756), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+116", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1757), new TimeSpan(0, 7, 0, 0, 0)), 0, 116, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 133, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1764), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@116", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1764), new TimeSpan(0, 7, 0, 0, 0)), 0, 116 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 134, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1772), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+117", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1772), new TimeSpan(0, 7, 0, 0, 0)), 0, 117, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 135, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1779), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@117", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1780), new TimeSpan(0, 7, 0, 0, 0)), 0, 117 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 136, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1787), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+118", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1787), new TimeSpan(0, 7, 0, 0, 0)), 0, 118, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 137, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1794), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@118", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1795), new TimeSpan(0, 7, 0, 0, 0)), 0, 118 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 138, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1802), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+119", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1802), new TimeSpan(0, 7, 0, 0, 0)), 0, 119, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 139, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1809), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@119", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1810), new TimeSpan(0, 7, 0, 0, 0)), 0, 119 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 140, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1842), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+120", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1843), new TimeSpan(0, 7, 0, 0, 0)), 0, 120, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 141, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1852), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@120", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1852), new TimeSpan(0, 7, 0, 0, 0)), 0, 120 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 142, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1860), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+121", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1860), new TimeSpan(0, 7, 0, 0, 0)), 0, 121, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 143, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1867), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@121", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1868), new TimeSpan(0, 7, 0, 0, 0)), 0, 121 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 144, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1875), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+122", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1876), new TimeSpan(0, 7, 0, 0, 0)), 0, 122, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 145, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1883), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@122", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1883), new TimeSpan(0, 7, 0, 0, 0)), 0, 122 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 146, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1891), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+123", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1891), new TimeSpan(0, 7, 0, 0, 0)), 0, 123, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 147, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1898), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@123", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1899), new TimeSpan(0, 7, 0, 0, 0)), 0, 123 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 148, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1906), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+124", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1906), new TimeSpan(0, 7, 0, 0, 0)), 0, 124, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 149, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1913), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@124", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1914), new TimeSpan(0, 7, 0, 0, 0)), 0, 124 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 150, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1921), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+125", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1922), new TimeSpan(0, 7, 0, 0, 0)), 0, 125, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 151, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1929), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@125", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1929), new TimeSpan(0, 7, 0, 0, 0)), 0, 125 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 152, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1936), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+126", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1937), new TimeSpan(0, 7, 0, 0, 0)), 0, 126, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 153, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1944), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@126", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1945), new TimeSpan(0, 7, 0, 0, 0)), 0, 126 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 154, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1952), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+127", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1953), new TimeSpan(0, 7, 0, 0, 0)), 0, 127, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 155, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@127", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1960), new TimeSpan(0, 7, 0, 0, 0)), 0, 127 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 156, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1967), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+128", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1968), new TimeSpan(0, 7, 0, 0, 0)), 0, 128, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 157, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1975), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@128", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1975), new TimeSpan(0, 7, 0, 0, 0)), 0, 128 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 158, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1983), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+129", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1983), new TimeSpan(0, 7, 0, 0, 0)), 0, 129, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 159, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2024), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@129", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2025), new TimeSpan(0, 7, 0, 0, 0)), 0, 129 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 160, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2034), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+130", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2034), new TimeSpan(0, 7, 0, 0, 0)), 0, 130, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 161, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2042), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@130", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2042), new TimeSpan(0, 7, 0, 0, 0)), 0, 130 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 162, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2050), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+131", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2050), new TimeSpan(0, 7, 0, 0, 0)), 0, 131, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 163, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2057), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@131", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2058), new TimeSpan(0, 7, 0, 0, 0)), 0, 131 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 164, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2065), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+132", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2066), new TimeSpan(0, 7, 0, 0, 0)), 0, 132, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 165, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2073), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@132", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2073), new TimeSpan(0, 7, 0, 0, 0)), 0, 132 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 166, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2080), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+133", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2081), new TimeSpan(0, 7, 0, 0, 0)), 0, 133, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 167, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2088), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@133", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2089), new TimeSpan(0, 7, 0, 0, 0)), 0, 133 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 168, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2096), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+134", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2097), new TimeSpan(0, 7, 0, 0, 0)), 0, 134, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 169, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2104), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@134", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2104), new TimeSpan(0, 7, 0, 0, 0)), 0, 134 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 170, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2111), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+135", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2112), new TimeSpan(0, 7, 0, 0, 0)), 0, 135, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 171, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2119), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@135", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2120), new TimeSpan(0, 7, 0, 0, 0)), 0, 135 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 172, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2127), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+136", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2128), new TimeSpan(0, 7, 0, 0, 0)), 0, 136, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 173, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2134), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@136", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2135), new TimeSpan(0, 7, 0, 0, 0)), 0, 136 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 174, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2142), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+137", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2143), new TimeSpan(0, 7, 0, 0, 0)), 0, 137, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 175, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2150), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@137", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2150), new TimeSpan(0, 7, 0, 0, 0)), 0, 137 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 176, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2158), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+138", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2158), new TimeSpan(0, 7, 0, 0, 0)), 0, 138, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 177, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2165), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@138", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2166), new TimeSpan(0, 7, 0, 0, 0)), 0, 138 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 178, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+139", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2174), new TimeSpan(0, 7, 0, 0, 0)), 0, 139, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 179, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2180), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@139", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), 0, 139 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 180, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2188), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+140", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2189), new TimeSpan(0, 7, 0, 0, 0)), 0, 140, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 181, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@140", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2219), new TimeSpan(0, 7, 0, 0, 0)), 0, 140 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 182, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+141", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2228), new TimeSpan(0, 7, 0, 0, 0)), 0, 141, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 183, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2235), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@141", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2236), new TimeSpan(0, 7, 0, 0, 0)), 0, 141 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 184, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2243), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+142", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2244), new TimeSpan(0, 7, 0, 0, 0)), 0, 142, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 185, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2250), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@142", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2251), new TimeSpan(0, 7, 0, 0, 0)), 0, 142 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 186, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2258), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+143", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2259), new TimeSpan(0, 7, 0, 0, 0)), 0, 143, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 187, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@143", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2266), new TimeSpan(0, 7, 0, 0, 0)), 0, 143 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 188, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+144", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2274), new TimeSpan(0, 7, 0, 0, 0)), 0, 144, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 189, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@144", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 7, 0, 0, 0)), 0, 144 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 190, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2288), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+145", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2289), new TimeSpan(0, 7, 0, 0, 0)), 0, 145, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 191, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2295), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@145", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2296), new TimeSpan(0, 7, 0, 0, 0)), 0, 145 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 192, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+146", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2303), new TimeSpan(0, 7, 0, 0, 0)), 0, 146, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 193, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@146", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2311), new TimeSpan(0, 7, 0, 0, 0)), 0, 146 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 194, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2318), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+147", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2318), new TimeSpan(0, 7, 0, 0, 0)), 0, 147, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 195, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2325), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@147", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2326), new TimeSpan(0, 7, 0, 0, 0)), 0, 147 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 196, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2333), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+148", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2334), new TimeSpan(0, 7, 0, 0, 0)), 0, 148, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 197, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2340), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@148", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2341), new TimeSpan(0, 7, 0, 0, 0)), 0, 148 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 198, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2348), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+149", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2348), new TimeSpan(0, 7, 0, 0, 0)), 0, 149, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 199, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2355), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@149", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2356), new TimeSpan(0, 7, 0, 0, 0)), 0, 149 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 200, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2363), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+150", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2363), new TimeSpan(0, 7, 0, 0, 0)), 0, 150, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 201, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2370), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@150", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2371), new TimeSpan(0, 7, 0, 0, 0)), 0, 150 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 202, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+151", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2379), new TimeSpan(0, 7, 0, 0, 0)), 0, 151, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 203, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2410), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@151", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2411), new TimeSpan(0, 7, 0, 0, 0)), 0, 151 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 204, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2421), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+152", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2422), new TimeSpan(0, 7, 0, 0, 0)), 0, 152, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 205, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2431), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@152", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2432), new TimeSpan(0, 7, 0, 0, 0)), 0, 152 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 206, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2439), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+153", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2440), new TimeSpan(0, 7, 0, 0, 0)), 0, 153, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 207, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2447), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@153", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2447), new TimeSpan(0, 7, 0, 0, 0)), 0, 153 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 208, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2454), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+154", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2455), new TimeSpan(0, 7, 0, 0, 0)), 0, 154, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 209, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2462), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@154", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2463), new TimeSpan(0, 7, 0, 0, 0)), 0, 154 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 210, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2470), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+155", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2470), new TimeSpan(0, 7, 0, 0, 0)), 0, 155, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 211, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2478), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@155", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2478), new TimeSpan(0, 7, 0, 0, 0)), 0, 155 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 212, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2485), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+156", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2486), new TimeSpan(0, 7, 0, 0, 0)), 0, 156, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 213, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2493), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@156", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2493), new TimeSpan(0, 7, 0, 0, 0)), 0, 156 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 214, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2501), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+157", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2501), new TimeSpan(0, 7, 0, 0, 0)), 0, 157, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 215, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2508), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@157", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2509), new TimeSpan(0, 7, 0, 0, 0)), 0, 157 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 216, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2516), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+158", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2517), new TimeSpan(0, 7, 0, 0, 0)), 0, 158, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 217, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2524), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@158", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2524), new TimeSpan(0, 7, 0, 0, 0)), 0, 158 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 218, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2531), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+159", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2532), new TimeSpan(0, 7, 0, 0, 0)), 0, 159, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 219, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2539), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@159", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2540), new TimeSpan(0, 7, 0, 0, 0)), 0, 159 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 220, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+160", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2571), new TimeSpan(0, 7, 0, 0, 0)), 0, 160, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 221, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2579), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@160", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2580), new TimeSpan(0, 7, 0, 0, 0)), 0, 160 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 222, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+161", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2588), new TimeSpan(0, 7, 0, 0, 0)), 0, 161, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 223, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2595), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@161", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2595), new TimeSpan(0, 7, 0, 0, 0)), 0, 161 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 224, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2603), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+162", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2603), new TimeSpan(0, 7, 0, 0, 0)), 0, 162, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 225, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2610), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@162", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2611), new TimeSpan(0, 7, 0, 0, 0)), 0, 162 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 226, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2618), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+163", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2618), new TimeSpan(0, 7, 0, 0, 0)), 0, 163, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 227, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2625), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@163", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2626), new TimeSpan(0, 7, 0, 0, 0)), 0, 163 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 228, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2633), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+164", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2633), new TimeSpan(0, 7, 0, 0, 0)), 0, 164, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 229, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2640), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@164", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2641), new TimeSpan(0, 7, 0, 0, 0)), 0, 164 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 230, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2648), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+165", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2648), new TimeSpan(0, 7, 0, 0, 0)), 0, 165, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 231, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2655), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@165", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2656), new TimeSpan(0, 7, 0, 0, 0)), 0, 165 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 232, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2663), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+166", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2664), new TimeSpan(0, 7, 0, 0, 0)), 0, 166, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 233, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2671), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@166", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2672), new TimeSpan(0, 7, 0, 0, 0)), 0, 166 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 234, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2679), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+167", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2679), new TimeSpan(0, 7, 0, 0, 0)), 0, 167, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 235, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2686), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@167", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2687), new TimeSpan(0, 7, 0, 0, 0)), 0, 167 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 236, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2694), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+168", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2694), new TimeSpan(0, 7, 0, 0, 0)), 0, 168, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 237, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2701), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@168", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2702), new TimeSpan(0, 7, 0, 0, 0)), 0, 168 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 238, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2709), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+169", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2710), new TimeSpan(0, 7, 0, 0, 0)), 0, 169, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 239, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2716), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@169", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2717), new TimeSpan(0, 7, 0, 0, 0)), 0, 169 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 240, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2724), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+170", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2725), new TimeSpan(0, 7, 0, 0, 0)), 0, 170, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 241, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2731), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@170", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2732), new TimeSpan(0, 7, 0, 0, 0)), 0, 170 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 242, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2761), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+171", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2762), new TimeSpan(0, 7, 0, 0, 0)), 0, 171, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 243, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2770), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@171", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2771), new TimeSpan(0, 7, 0, 0, 0)), 0, 171 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 244, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2778), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+172", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2779), new TimeSpan(0, 7, 0, 0, 0)), 0, 172, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 245, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2786), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@172", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2786), new TimeSpan(0, 7, 0, 0, 0)), 0, 172 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 246, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2793), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+173", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2794), new TimeSpan(0, 7, 0, 0, 0)), 0, 173, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 247, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2800), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@173", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2801), new TimeSpan(0, 7, 0, 0, 0)), 0, 173 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 248, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2808), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+174", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2809), new TimeSpan(0, 7, 0, 0, 0)), 0, 174, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 249, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2816), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@174", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2816), new TimeSpan(0, 7, 0, 0, 0)), 0, 174 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 250, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2823), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+175", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2824), new TimeSpan(0, 7, 0, 0, 0)), 0, 175, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 251, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2830), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@175", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2831), new TimeSpan(0, 7, 0, 0, 0)), 0, 175 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 252, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2838), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+176", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2838), new TimeSpan(0, 7, 0, 0, 0)), 0, 176, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 253, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2845), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@176", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2846), new TimeSpan(0, 7, 0, 0, 0)), 0, 176 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 254, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2853), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+177", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2854), new TimeSpan(0, 7, 0, 0, 0)), 0, 177, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 255, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2861), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@177", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2862), new TimeSpan(0, 7, 0, 0, 0)), 0, 177 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 256, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2869), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+178", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2869), new TimeSpan(0, 7, 0, 0, 0)), 0, 178, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 257, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2876), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@178", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2876), new TimeSpan(0, 7, 0, 0, 0)), 0, 178 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 258, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2883), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+179", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2884), new TimeSpan(0, 7, 0, 0, 0)), 0, 179, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 259, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2891), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@179", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2891), new TimeSpan(0, 7, 0, 0, 0)), 0, 179 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 260, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2899), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+180", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2899), new TimeSpan(0, 7, 0, 0, 0)), 0, 180, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 261, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2906), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@180", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2907), new TimeSpan(0, 7, 0, 0, 0)), 0, 180 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 262, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2914), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+181", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2914), new TimeSpan(0, 7, 0, 0, 0)), 0, 181, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 263, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2921), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@181", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2922), new TimeSpan(0, 7, 0, 0, 0)), 0, 181 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 264, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2951), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+182", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2951), new TimeSpan(0, 7, 0, 0, 0)), 0, 182, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 265, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2960), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@182", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2961), new TimeSpan(0, 7, 0, 0, 0)), 0, 182 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 266, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+183", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2969), new TimeSpan(0, 7, 0, 0, 0)), 0, 183, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 267, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@183", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2976), new TimeSpan(0, 7, 0, 0, 0)), 0, 183 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 268, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2984), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+184", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2984), new TimeSpan(0, 7, 0, 0, 0)), 0, 184, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 269, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2991), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@184", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2992), new TimeSpan(0, 7, 0, 0, 0)), 0, 184 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 270, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(2999), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+185", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3000), new TimeSpan(0, 7, 0, 0, 0)), 0, 185, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 271, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3007), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@185", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3007), new TimeSpan(0, 7, 0, 0, 0)), 0, 185 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 272, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3014), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+186", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3015), new TimeSpan(0, 7, 0, 0, 0)), 0, 186, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 273, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3022), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@186", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3022), new TimeSpan(0, 7, 0, 0, 0)), 0, 186 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 274, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3029), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+187", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3030), new TimeSpan(0, 7, 0, 0, 0)), 0, 187, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 275, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3037), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@187", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3037), new TimeSpan(0, 7, 0, 0, 0)), 0, 187 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 276, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3044), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+188", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3045), new TimeSpan(0, 7, 0, 0, 0)), 0, 188, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 277, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3052), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@188", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3052), new TimeSpan(0, 7, 0, 0, 0)), 0, 188 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 278, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3059), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+189", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3060), new TimeSpan(0, 7, 0, 0, 0)), 0, 189, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 279, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3066), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@189", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3067), new TimeSpan(0, 7, 0, 0, 0)), 0, 189 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 280, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3074), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+190", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3075), new TimeSpan(0, 7, 0, 0, 0)), 0, 190, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 281, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3081), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@190", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3082), new TimeSpan(0, 7, 0, 0, 0)), 0, 190 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 282, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3089), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+191", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3089), new TimeSpan(0, 7, 0, 0, 0)), 0, 191, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 283, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3096), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@191", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3097), new TimeSpan(0, 7, 0, 0, 0)), 0, 191 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 284, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3104), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+192", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3104), new TimeSpan(0, 7, 0, 0, 0)), 0, 192, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 285, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3111), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@192", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3111), new TimeSpan(0, 7, 0, 0, 0)), 0, 192 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 286, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3140), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+193", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3140), new TimeSpan(0, 7, 0, 0, 0)), 0, 193, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 287, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3150), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@193", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3151), new TimeSpan(0, 7, 0, 0, 0)), 0, 193 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 288, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3158), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+194", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3158), new TimeSpan(0, 7, 0, 0, 0)), 0, 194, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 289, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3165), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@194", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3166), new TimeSpan(0, 7, 0, 0, 0)), 0, 194 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 290, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+195", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3173), new TimeSpan(0, 7, 0, 0, 0)), 0, 195, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 291, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3180), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@195", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3181), new TimeSpan(0, 7, 0, 0, 0)), 0, 195 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 292, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3188), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+196", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3188), new TimeSpan(0, 7, 0, 0, 0)), 0, 196, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 293, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3195), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@196", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3196), new TimeSpan(0, 7, 0, 0, 0)), 0, 196 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 294, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3204), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+197", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3204), new TimeSpan(0, 7, 0, 0, 0)), 0, 197, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 295, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3211), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@197", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3212), new TimeSpan(0, 7, 0, 0, 0)), 0, 197 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 296, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+198", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3219), new TimeSpan(0, 7, 0, 0, 0)), 0, 198, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 297, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@198", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3227), new TimeSpan(0, 7, 0, 0, 0)), 0, 198 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 298, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3234), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+199", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3234), new TimeSpan(0, 7, 0, 0, 0)), 0, 199, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 299, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3242), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@199", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3242), new TimeSpan(0, 7, 0, 0, 0)), 0, 199 },
                    { 400, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3250), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+400", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3250), new TimeSpan(0, 7, 0, 0, 0)), 0, 400 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 401, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3258), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@400", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3258), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 402, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+401", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3267), new TimeSpan(0, 7, 0, 0, 0)), 0, 401 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 403, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3274), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@401", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3275), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 404, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3282), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+402", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3283), new TimeSpan(0, 7, 0, 0, 0)), 0, 402 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 405, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3290), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@402", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3290), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 406, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3297), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+403", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3298), new TimeSpan(0, 7, 0, 0, 0)), 0, 403 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 407, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3305), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@403", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3305), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 408, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3312), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+404", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3313), new TimeSpan(0, 7, 0, 0, 0)), 0, 404 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 409, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@404", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3345), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 410, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3353), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+405", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3353), new TimeSpan(0, 7, 0, 0, 0)), 0, 405 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 411, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3360), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@405", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3361), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 412, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+406", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3368), new TimeSpan(0, 7, 0, 0, 0)), 0, 406 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 413, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3375), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@406", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3376), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 414, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3383), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+407", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3384), new TimeSpan(0, 7, 0, 0, 0)), 0, 407 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 415, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3391), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@407", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3391), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 416, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3398), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+408", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3399), new TimeSpan(0, 7, 0, 0, 0)), 0, 408 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 417, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3406), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@408", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3407), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 418, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3414), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+409", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3414), new TimeSpan(0, 7, 0, 0, 0)), 0, 409 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 419, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3421), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@409", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3422), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 420, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3429), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+410", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3429), new TimeSpan(0, 7, 0, 0, 0)), 0, 410 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 421, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@410", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3437), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 422, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3444), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+411", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3445), new TimeSpan(0, 7, 0, 0, 0)), 0, 411 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 423, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3452), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@411", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3452), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 424, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3459), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+412", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3460), new TimeSpan(0, 7, 0, 0, 0)), 0, 412 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 425, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3467), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@412", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3467), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 426, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3475), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+413", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3475), new TimeSpan(0, 7, 0, 0, 0)), 0, 413 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 427, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3482), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@413", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3483), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 428, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3490), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+414", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3491), new TimeSpan(0, 7, 0, 0, 0)), 0, 414 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 429, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3497), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@414", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3498), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 430, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3505), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+415", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3505), new TimeSpan(0, 7, 0, 0, 0)), 0, 415 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 431, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3545), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@415", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3545), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 432, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3553), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+416", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3554), new TimeSpan(0, 7, 0, 0, 0)), 0, 416 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 433, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3564), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@416", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3565), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 434, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+417", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3572), new TimeSpan(0, 7, 0, 0, 0)), 0, 417 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 435, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3579), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@417", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3580), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 436, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+418", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3587), new TimeSpan(0, 7, 0, 0, 0)), 0, 418 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 437, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3594), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@418", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3595), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 438, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3602), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+419", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3603), new TimeSpan(0, 7, 0, 0, 0)), 0, 419 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 439, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3609), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@419", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3610), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 440, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3617), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+420", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3617), new TimeSpan(0, 7, 0, 0, 0)), 0, 420 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 441, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3624), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@420", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3625), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 442, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3656), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+421", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3657), new TimeSpan(0, 7, 0, 0, 0)), 0, 421 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 443, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3665), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@421", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3665), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 444, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3673), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+422", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3673), new TimeSpan(0, 7, 0, 0, 0)), 0, 422 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 445, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@422", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3681), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 446, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+423", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3689), new TimeSpan(0, 7, 0, 0, 0)), 0, 423 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 447, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3696), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@423", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3696), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 448, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3703), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+424", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3704), new TimeSpan(0, 7, 0, 0, 0)), 0, 424 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 449, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3711), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@424", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3712), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 450, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3719), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+425", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3720), new TimeSpan(0, 7, 0, 0, 0)), 0, 425 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 451, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3727), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@425", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3727), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 452, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3734), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+426", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3735), new TimeSpan(0, 7, 0, 0, 0)), 0, 426 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 453, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3742), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@426", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3743), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 454, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3750), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+427", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3751), new TimeSpan(0, 7, 0, 0, 0)), 0, 427 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 455, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3758), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@427", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3758), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 456, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3765), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+428", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3766), new TimeSpan(0, 7, 0, 0, 0)), 0, 428 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 457, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3772), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@428", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3773), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 458, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3780), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+429", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3781), new TimeSpan(0, 7, 0, 0, 0)), 0, 429 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 459, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3788), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@429", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3788), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 460, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3795), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+430", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3796), new TimeSpan(0, 7, 0, 0, 0)), 0, 430 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 461, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3803), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@430", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3803), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 462, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3810), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+431", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3811), new TimeSpan(0, 7, 0, 0, 0)), 0, 431 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 463, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@431", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3818), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 464, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3848), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+432", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3848), new TimeSpan(0, 7, 0, 0, 0)), 0, 432 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 465, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3857), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@432", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3857), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 466, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3864), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+433", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3865), new TimeSpan(0, 7, 0, 0, 0)), 0, 433 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 467, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3872), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@433", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3873), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 468, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+434", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3880), new TimeSpan(0, 7, 0, 0, 0)), 0, 434 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 469, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3887), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@434", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3887), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 470, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+435", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3895), new TimeSpan(0, 7, 0, 0, 0)), 0, 435 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 471, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3902), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@435", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3903), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 472, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3910), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+436", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3910), new TimeSpan(0, 7, 0, 0, 0)), 0, 436 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 473, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3917), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@436", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3918), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 474, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3925), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+437", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3926), new TimeSpan(0, 7, 0, 0, 0)), 0, 437 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 475, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3933), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@437", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3933), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 476, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3940), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+438", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3941), new TimeSpan(0, 7, 0, 0, 0)), 0, 438 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 477, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3948), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@438", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3949), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 478, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3955), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+439", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3956), new TimeSpan(0, 7, 0, 0, 0)), 0, 439 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 479, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3963), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@439", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3964), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 480, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3971), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+440", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3971), new TimeSpan(0, 7, 0, 0, 0)), 0, 440 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 481, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3978), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@440", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3979), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 482, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3986), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+441", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3986), new TimeSpan(0, 7, 0, 0, 0)), 0, 441 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 483, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3993), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@441", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(3994), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 484, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4001), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+442", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4001), new TimeSpan(0, 7, 0, 0, 0)), 0, 442 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 485, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4008), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@442", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4009), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 486, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4038), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+443", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4038), new TimeSpan(0, 7, 0, 0, 0)), 0, 443 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 487, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4047), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@443", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4048), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 488, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4055), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+444", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4055), new TimeSpan(0, 7, 0, 0, 0)), 0, 444 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 489, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4062), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@444", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4063), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 490, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4070), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+445", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4070), new TimeSpan(0, 7, 0, 0, 0)), 0, 445 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 491, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4077), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@445", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4077), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 492, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4084), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+446", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4085), new TimeSpan(0, 7, 0, 0, 0)), 0, 446 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 493, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4092), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@446", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4092), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 494, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4099), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+447", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4100), new TimeSpan(0, 7, 0, 0, 0)), 0, 447 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 495, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4107), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@447", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4107), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 496, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4114), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+448", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4114), new TimeSpan(0, 7, 0, 0, 0)), 0, 448 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 497, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4122), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@448", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4122), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 498, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+449", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4130), new TimeSpan(0, 7, 0, 0, 0)), 0, 449 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 499, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4137), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@449", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4137), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 500, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+450", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4145), new TimeSpan(0, 7, 0, 0, 0)), 0, 450 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 501, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4152), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@450", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4152), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 502, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4159), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+451", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4160), new TimeSpan(0, 7, 0, 0, 0)), 0, 451 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 503, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@451", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4168), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 504, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+452", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4175), new TimeSpan(0, 7, 0, 0, 0)), 0, 452 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 505, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4182), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@452", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4182), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 506, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4189), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+453", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4190), new TimeSpan(0, 7, 0, 0, 0)), 0, 453 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 507, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4196), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@453", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4197), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 508, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+454", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4227), new TimeSpan(0, 7, 0, 0, 0)), 0, 454 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 509, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4235), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@454", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4236), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 510, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4243), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+455", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4244), new TimeSpan(0, 7, 0, 0, 0)), 0, 455 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 511, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4251), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@455", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4251), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 512, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4258), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+456", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4259), new TimeSpan(0, 7, 0, 0, 0)), 0, 456 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 513, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@456", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4266), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 514, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+457", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4274), new TimeSpan(0, 7, 0, 0, 0)), 0, 457 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 515, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4281), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@457", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4282), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 516, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+458", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4289), new TimeSpan(0, 7, 0, 0, 0)), 0, 458 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 517, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4296), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@458", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4297), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 518, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4304), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+459", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4305), new TimeSpan(0, 7, 0, 0, 0)), 0, 459 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 519, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4312), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@459", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4313), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 520, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4320), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+460", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4321), new TimeSpan(0, 7, 0, 0, 0)), 0, 460 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 521, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4328), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@460", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4328), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 522, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4336), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+461", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4336), new TimeSpan(0, 7, 0, 0, 0)), 0, 461 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 523, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4343), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@461", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4344), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 524, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4351), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+462", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4352), new TimeSpan(0, 7, 0, 0, 0)), 0, 462 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 525, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4359), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@462", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4360), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 526, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4367), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+463", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4367), new TimeSpan(0, 7, 0, 0, 0)), 0, 463 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 527, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4375), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@463", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4375), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 528, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4382), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+464", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4383), new TimeSpan(0, 7, 0, 0, 0)), 0, 464 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 529, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4390), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@464", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4391), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 530, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4398), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+465", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4398), new TimeSpan(0, 7, 0, 0, 0)), 0, 465 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 531, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4431), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@465", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4431), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 532, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4439), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+466", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4439), new TimeSpan(0, 7, 0, 0, 0)), 0, 466 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 533, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4446), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@466", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4447), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 534, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4454), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+467", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4455), new TimeSpan(0, 7, 0, 0, 0)), 0, 467 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 535, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4462), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@467", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4462), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 536, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4469), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+468", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4470), new TimeSpan(0, 7, 0, 0, 0)), 0, 468 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 537, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4477), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@468", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4478), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 538, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4485), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+469", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4486), new TimeSpan(0, 7, 0, 0, 0)), 0, 469 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 539, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4493), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@469", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4493), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 540, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4500), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+470", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4501), new TimeSpan(0, 7, 0, 0, 0)), 0, 470 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 541, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4508), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@470", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4508), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 542, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4516), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+471", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4516), new TimeSpan(0, 7, 0, 0, 0)), 0, 471 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 543, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4523), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@471", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4524), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 544, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4531), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+472", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4532), new TimeSpan(0, 7, 0, 0, 0)), 0, 472 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 545, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4539), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@472", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4539), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 546, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4546), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+473", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4547), new TimeSpan(0, 7, 0, 0, 0)), 0, 473 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 547, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4554), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@473", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4554), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 548, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4562), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+474", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4562), new TimeSpan(0, 7, 0, 0, 0)), 0, 474 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 549, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4569), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@474", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4570), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 550, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4577), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+475", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4578), new TimeSpan(0, 7, 0, 0, 0)), 0, 475 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 551, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4585), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@475", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4585), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 552, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4592), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+476", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4593), new TimeSpan(0, 7, 0, 0, 0)), 0, 476 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 553, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4624), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@476", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4625), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 554, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4633), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+477", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4633), new TimeSpan(0, 7, 0, 0, 0)), 0, 477 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 555, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4640), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@477", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4641), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 556, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4648), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+478", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4648), new TimeSpan(0, 7, 0, 0, 0)), 0, 478 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 557, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4655), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@478", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4656), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 558, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4663), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+479", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4663), new TimeSpan(0, 7, 0, 0, 0)), 0, 479 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 559, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4671), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@479", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4671), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 560, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4679), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+480", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4679), new TimeSpan(0, 7, 0, 0, 0)), 0, 480 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 561, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4686), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@480", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4687), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 562, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4694), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+481", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4695), new TimeSpan(0, 7, 0, 0, 0)), 0, 481 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 563, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4702), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@481", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4702), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 564, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4709), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+482", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4710), new TimeSpan(0, 7, 0, 0, 0)), 0, 482 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 565, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4717), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@482", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4718), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 566, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4724), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+483", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4725), new TimeSpan(0, 7, 0, 0, 0)), 0, 483 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 567, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4732), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@483", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4732), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 568, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4739), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+484", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4740), new TimeSpan(0, 7, 0, 0, 0)), 0, 484 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 569, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4747), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@484", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4748), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 570, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+485", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4755), new TimeSpan(0, 7, 0, 0, 0)), 0, 485 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 571, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@485", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4763), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 572, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+486", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 7, 0, 0, 0)), 0, 486 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 573, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4777), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@486", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4778), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 574, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4785), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+487", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4785), new TimeSpan(0, 7, 0, 0, 0)), 0, 487 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 575, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4814), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@487", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4814), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 576, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4823), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+488", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4823), new TimeSpan(0, 7, 0, 0, 0)), 0, 488 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 577, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4831), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@488", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4831), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 578, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4839), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+489", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4839), new TimeSpan(0, 7, 0, 0, 0)), 0, 489 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 579, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4846), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@489", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4846), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 580, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4854), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+490", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4854), new TimeSpan(0, 7, 0, 0, 0)), 0, 490 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 581, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4861), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@490", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4862), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 582, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4869), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+491", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4869), new TimeSpan(0, 7, 0, 0, 0)), 0, 491 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 583, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4876), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@491", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4877), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 584, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4883), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+492", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4884), new TimeSpan(0, 7, 0, 0, 0)), 0, 492 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 585, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4891), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@492", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4892), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 586, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4899), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+493", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4899), new TimeSpan(0, 7, 0, 0, 0)), 0, 493 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 587, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4907), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@493", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4907), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 588, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4914), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+494", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4915), new TimeSpan(0, 7, 0, 0, 0)), 0, 494 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 589, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4922), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@494", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4923), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 590, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4930), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+495", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4931), new TimeSpan(0, 7, 0, 0, 0)), 0, 495 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 591, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4938), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@495", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4938), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 592, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4945), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+496", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4946), new TimeSpan(0, 7, 0, 0, 0)), 0, 496 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 593, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@496", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4954), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 594, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4961), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+497", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4961), new TimeSpan(0, 7, 0, 0, 0)), 0, 497 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 595, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@497", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4969), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 596, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+498", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(4976), new TimeSpan(0, 7, 0, 0, 0)), 0, 498 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 597, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5015), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@498", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5016), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 598, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5026), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+499", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5027), new TimeSpan(0, 7, 0, 0, 0)), 0, 499 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 599, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5034), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@499", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5035), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, true });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "title", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5710), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, "What is Lorem Ipsum?", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5711), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5714), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, "Why do we use it?", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5715), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5716), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, "Where does it come from?", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5717), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5718), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, "Where can I get some?", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5718), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5790), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5791), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5794), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5794), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5796), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5796), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5230), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5230), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5247), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5248), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5265), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5266), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5053), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5053), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5065), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5065), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5098), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5099), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trip_rate", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "rating", "status", "suddenly_cancelled_trips", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 0.0, new Guid("7ae6d30d-ff70-4d17-9129-d214af096dac"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8038), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8041), new TimeSpan(0, 7, 0, 0, 0)), null, null, 1, 1, "Quach Dai Loi", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8039), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 0.0, new Guid("d2255648-6bee-4657-89f6-296ede49d62f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8103), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8105), new TimeSpan(0, 7, 0, 0, 0)), null, null, 2, 1, "Do Trong Dat", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8104), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 0.0, new Guid("12571d51-755d-4ae9-a055-33fb079cbe53"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8118), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8121), new TimeSpan(0, 7, 0, 0, 0)), null, null, 3, 1, "Nguyen Dang Khoa", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8119), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 0.0, new Guid("22087968-5aba-455f-a3e2-d332bc69d55e"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8131), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8133), new TimeSpan(0, 7, 0, 0, 0)), null, null, 4, 1, "Than Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8132), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 0.0, new Guid("9b555a92-e476-4d69-a99f-47b7b644fd6a"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8145), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8147), new TimeSpan(0, 7, 0, 0, 0)), null, null, 5, 1, "Loi Quach", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8145), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 0.0, new Guid("9cdbf3b2-fefe-4a00-9298-c4a9e4171e39"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8160), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8162), new TimeSpan(0, 7, 0, 0, 0)), null, null, 6, 1, "Dat Do", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8161), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 0.0, new Guid("ba6fad52-e62a-4b29-9727-11bb99cb7968"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8172), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8174), new TimeSpan(0, 7, 0, 0, 0)), null, null, 7, 1, "Khoa Nguyen", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8173), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 0.0, new Guid("f3a2cdd0-cff4-48dd-b268-f028b9b4863f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8185), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8187), new TimeSpan(0, 7, 0, 0, 0)), null, null, 8, 1, "Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8186), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 0.0, new Guid("f729e039-1131-4f6e-b9e5-4966d7e3b741"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8197), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8198), new TimeSpan(0, 7, 0, 0, 0)), null, null, 13, 1, "Admin Quach Dai Loi", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 811, DateTimeKind.Unspecified).AddTicks(8197), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 400, new Guid("bd536800-aa55-482e-8f3a-910623175f91"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6005), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.400", "Vehicle 400", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6005), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, 2 },
                    { 401, new Guid("c3a2ed83-0f9f-455c-9cc8-94d28b498fb3"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6014), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.401", "Vehicle 401", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, 2 },
                    { 402, new Guid("23c54613-288d-442d-b0b2-7a34d38ff40a"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6020), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.402", "Vehicle 402", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6021), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, 2 },
                    { 403, new Guid("9dac68d4-1454-4f9b-8030-2a4c9090dfd3"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6024), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.403", "Vehicle 403", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6025), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, 2 },
                    { 404, new Guid("bd85db9e-6713-4a48-8545-5c5d70512031"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6028), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.404", "Vehicle 404", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6028), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, 2 },
                    { 405, new Guid("109d2c5b-534b-4cf5-a710-8dd44b51dff9"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6032), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.405", "Vehicle 405", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6033), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, 2 },
                    { 406, new Guid("dfebe678-0f9c-4d0f-a9bb-a488eaceb096"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6036), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.406", "Vehicle 406", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6036), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, 2 },
                    { 407, new Guid("860317c4-4b13-4e12-92f6-17257b43864b"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6039), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.407", "Vehicle 407", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6040), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, 2 },
                    { 408, new Guid("2e0002fa-7c93-45a4-b4d6-a822f241709e"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6042), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.408", "Vehicle 408", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6043), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, 2 },
                    { 409, new Guid("e0b97e8f-63d9-4910-8c70-bb528cd96f64"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6046), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.409", "Vehicle 409", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6047), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, 2 },
                    { 410, new Guid("e77e19a4-258d-4e10-9d9e-262305f6fce1"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6051), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.410", "Vehicle 410", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6052), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, 2 },
                    { 411, new Guid("ad5d406b-dd7f-4cc2-afa3-b9a896cd60cb"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6054), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.411", "Vehicle 411", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6055), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, 2 },
                    { 412, new Guid("3ad94cbd-a299-4f27-9643-3dccefb56489"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6058), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.412", "Vehicle 412", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6059), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, 2 },
                    { 413, new Guid("2b66f4f9-a93b-408b-a92c-afdfc9a76864"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6062), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.413", "Vehicle 413", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6063), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, 2 },
                    { 414, new Guid("ee905f7f-0e26-446e-9347-390367b468b5"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6066), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.414", "Vehicle 414", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6067), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, 2 },
                    { 415, new Guid("ed897ca6-d32a-44d6-b88c-0466fa41dd90"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6069), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.415", "Vehicle 415", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6070), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, 2 },
                    { 416, new Guid("3e85a21a-3413-47e2-932a-68cdb348588f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6073), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.416", "Vehicle 416", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6073), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, 2 },
                    { 417, new Guid("48154a68-b90f-4c65-9352-35bcad2d795f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6076), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.417", "Vehicle 417", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6077), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, 2 },
                    { 418, new Guid("bfaac7c4-1f46-4a03-b4e0-2caaed37653d"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6081), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.418", "Vehicle 418", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6082), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, 2 },
                    { 419, new Guid("b722b001-b808-4f5c-8b78-31997a94c31a"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6085), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.419", "Vehicle 419", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6086), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, 2 },
                    { 420, new Guid("efde5c88-2ede-4c42-b8c5-5c8bb1bbe962"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6088), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.420", "Vehicle 420", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6089), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, 2 },
                    { 421, new Guid("7e27d300-f1cf-486c-af47-f8d36263c5e9"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6092), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.421", "Vehicle 421", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6092), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, 2 },
                    { 422, new Guid("2991459f-5c14-40f7-a062-9b48d7e134f7"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6095), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.422", "Vehicle 422", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6096), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, 2 },
                    { 423, new Guid("e74efb8b-b852-4a24-8d88-7355d944eceb"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6098), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.423", "Vehicle 423", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6099), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, 2 },
                    { 424, new Guid("e7272bbe-f1af-4530-89e7-c7ad6aec8320"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6102), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.424", "Vehicle 424", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6102), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, 2 },
                    { 425, new Guid("0e4513f0-1fa8-4bd9-9bd2-77da8c97cb4f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6105), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.425", "Vehicle 425", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6106), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, 2 },
                    { 426, new Guid("01f3faf3-fde6-460b-91ba-d8b0b4b3f030"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6136), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.426", "Vehicle 426", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6137), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, 2 },
                    { 427, new Guid("ef0301f4-ab4d-43f4-b8cb-db18aafabb70"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6140), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.427", "Vehicle 427", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6141), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, 2 },
                    { 428, new Guid("b7549822-7556-4cd1-8dc4-73d819a564ee"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6143), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.428", "Vehicle 428", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6144), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, 2 },
                    { 429, new Guid("437d3992-66f1-4206-bf62-cd8e97dfc700"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6148), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.429", "Vehicle 429", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6148), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, 2 },
                    { 430, new Guid("412733b3-ce7f-4443-8fcb-c5d2efbae10c"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6151), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.430", "Vehicle 430", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6152), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, 2 },
                    { 431, new Guid("e234dce8-4e5e-4c33-8dfc-936c94988f0d"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6155), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.431", "Vehicle 431", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6155), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, 2 },
                    { 432, new Guid("2e6877f7-2327-4bd4-b285-5f515e9a5825"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6158), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.432", "Vehicle 432", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6159), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, 2 },
                    { 433, new Guid("0adcc813-9616-4b57-8283-dad31652ffa7"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6162), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.433", "Vehicle 433", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6162), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, 2 },
                    { 434, new Guid("ee66d9aa-88f6-489f-b3e7-a8371e1e9fc3"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.434", "Vehicle 434", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6168), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, 2 },
                    { 435, new Guid("f35f1953-6398-4163-a208-6484192ed7d3"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.435", "Vehicle 435", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6171), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, 2 },
                    { 436, new Guid("10d30e6e-0242-45b5-8180-e246fcdbded3"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.436", "Vehicle 436", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6174), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, 2 },
                    { 437, new Guid("90837c3b-e77a-43e3-b40c-e3bf79f0f120"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6177), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.437", "Vehicle 437", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6178), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, 2 },
                    { 438, new Guid("8c28dbdd-2667-4601-81dd-33925618cfda"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6181), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.438", "Vehicle 438", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6181), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, 2 },
                    { 439, new Guid("97a719f4-4645-4f4b-b486-3015abab94db"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6184), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.439", "Vehicle 439", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6185), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, 2 },
                    { 440, new Guid("d2eaec52-f638-4bba-ae5a-0191bb172af7"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6187), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.440", "Vehicle 440", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6188), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, 2 },
                    { 441, new Guid("10182968-f7df-40ac-ba96-5e27905e0f7e"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6191), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.441", "Vehicle 441", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6192), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, 2 },
                    { 442, new Guid("90a8c85f-2e81-460b-8b0a-38278fa60fd6"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6196), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.442", "Vehicle 442", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6197), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, 2 },
                    { 443, new Guid("8b5485e8-7649-43e6-b8c6-c590baca9dba"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6200), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.443", "Vehicle 443", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6200), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, 2 },
                    { 444, new Guid("d37c911a-a2e5-42bf-b4be-8be4b9e01471"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6203), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.444", "Vehicle 444", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6204), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, 2 },
                    { 445, new Guid("e08254f5-afc6-49b1-a03a-78e2550b659f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6206), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.445", "Vehicle 445", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6207), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, 2 },
                    { 446, new Guid("cb423ce1-548d-494a-ac1e-4a37786f6e7d"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6210), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.446", "Vehicle 446", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6211), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, 2 },
                    { 447, new Guid("24fc130e-765f-41ac-b142-fac1da64e691"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6213), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.447", "Vehicle 447", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6214), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, 2 },
                    { 448, new Guid("252b4c6b-78d3-4439-b74a-0d53255d617f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6217), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.448", "Vehicle 448", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6217), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, 2 },
                    { 449, new Guid("237fb60e-6e41-4777-a718-19f2c0be969b"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6220), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.449", "Vehicle 449", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6221), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, 2 },
                    { 450, new Guid("d065711a-fa72-4f51-aa8d-cdcdf411756a"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.450", "Vehicle 450", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6226), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, 2 },
                    { 451, new Guid("768c97de-e051-4fd5-80ec-f299b6a306ca"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6229), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.451", "Vehicle 451", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6230), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, 2 },
                    { 452, new Guid("9fd3a373-c7f1-41b9-82d0-a545cf9afbb0"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6233), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.452", "Vehicle 452", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6233), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, 2 },
                    { 453, new Guid("f0ddf9b7-64b2-458e-b36c-1d1dfab26a3f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6236), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.453", "Vehicle 453", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6237), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, 2 },
                    { 454, new Guid("fc8a8422-d9c0-4fe2-ada3-27c21e6d2478"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6239), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.454", "Vehicle 454", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6240), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, 2 },
                    { 455, new Guid("d23bd005-1ff9-4355-825c-b5b4b58bff6b"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6243), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.455", "Vehicle 455", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6244), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, 2 },
                    { 456, new Guid("f6634a1e-2a2b-4b1d-90a6-15f54624f642"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6246), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.456", "Vehicle 456", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6247), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, 2 },
                    { 457, new Guid("c8ee6414-3e42-45bd-98d4-fc34abff1edb"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6272), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.457", "Vehicle 457", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6272), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, 2 },
                    { 458, new Guid("4c5c6375-2f4d-4ba9-b481-06ff1f38b205"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6277), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.458", "Vehicle 458", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6278), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, 2 },
                    { 459, new Guid("f03fd60a-df86-4661-9379-36f67b623939"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6281), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.459", "Vehicle 459", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6282), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, 2 },
                    { 460, new Guid("e97e7b1e-5253-4d60-9f84-30362e48aeed"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6284), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.460", "Vehicle 460", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6285), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, 2 },
                    { 461, new Guid("7526e538-a03a-4501-9215-5c2d79cfc7d0"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.461", "Vehicle 461", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6289), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, 2 },
                    { 462, new Guid("99c33c3a-b47e-493f-853a-8f63d0b88f82"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6292), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.462", "Vehicle 462", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6293), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, 2 },
                    { 463, new Guid("e55f0982-8ec3-4719-93b7-131eda57aaf4"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6295), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.463", "Vehicle 463", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6296), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, 2 },
                    { 464, new Guid("5a084171-4915-4a02-953c-d52153c6e0b4"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6299), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.464", "Vehicle 464", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6300), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, 2 },
                    { 465, new Guid("08183a53-1759-48e1-acfc-49bb5bbfa247"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.465", "Vehicle 465", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6303), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, 2 },
                    { 466, new Guid("84c6d35f-765b-4a13-ad5d-a9a3349cb459"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6307), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.466", "Vehicle 466", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6308), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, 2 },
                    { 467, new Guid("a8288fcb-4ca8-470b-a3d5-0734d5ff892d"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6311), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.467", "Vehicle 467", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6312), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, 2 },
                    { 468, new Guid("177f742c-4eb1-4c4d-9afc-9cc8aba5f6f6"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6314), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.468", "Vehicle 468", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6315), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, 2 },
                    { 469, new Guid("5da58ada-17a9-4504-ba61-91e46314912e"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6318), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.469", "Vehicle 469", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6318), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, 2 },
                    { 470, new Guid("5286b783-6a11-4da0-b9d2-c6fa99434cb8"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.470", "Vehicle 470", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6322), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, 2 },
                    { 471, new Guid("5bbb0128-3303-4d6c-8403-e19315bb0577"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6325), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.471", "Vehicle 471", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6325), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, 2 },
                    { 472, new Guid("c5155621-6787-46d7-8527-8818aefc2ca5"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6328), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.472", "Vehicle 472", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6329), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, 2 },
                    { 473, new Guid("ca8fd205-2cfc-48d8-9972-83b3d8e2f7bc"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6331), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.473", "Vehicle 473", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6332), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, 2 },
                    { 474, new Guid("a32350d5-f774-496e-9db8-b1082f0e8c95"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6337), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.474", "Vehicle 474", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6338), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, 2 },
                    { 475, new Guid("c55f8c4c-f268-43c5-89f2-feeae20630bd"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6340), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.475", "Vehicle 475", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6341), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, 2 },
                    { 476, new Guid("cc53256d-4d3f-4502-8770-71dc13eee144"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6344), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.476", "Vehicle 476", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6344), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, 2 },
                    { 477, new Guid("5403299c-2c70-4b47-ab2a-0d58e32c0b21"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6347), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.477", "Vehicle 477", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6348), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, 2 },
                    { 478, new Guid("d8e2f516-207a-447c-b660-b8992ef43941"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6350), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.478", "Vehicle 478", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6351), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, 2 },
                    { 479, new Guid("00ca1744-dd2a-48c1-9dc9-d23dfd496e87"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.479", "Vehicle 479", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6355), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, 2 },
                    { 480, new Guid("0456ba59-e12f-4fa8-95bb-160ea2bc3038"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6357), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.480", "Vehicle 480", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6358), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, 2 },
                    { 481, new Guid("e56998ea-7f7c-4019-b031-6f350d4772a0"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.481", "Vehicle 481", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6362), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, 2 },
                    { 482, new Guid("1189b3c7-5a97-4bd8-b0e9-d29b958f86da"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6366), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.482", "Vehicle 482", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6367), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, 2 },
                    { 483, new Guid("c9061bb6-33ad-4e4c-a675-a8330f6b9c06"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6369), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.483", "Vehicle 483", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6370), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, 2 },
                    { 484, new Guid("a5cf6570-6d8e-44ed-a4d8-e333b6da7fdc"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6373), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.484", "Vehicle 484", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6374), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, 2 },
                    { 485, new Guid("425b75d1-3864-4578-b4a7-aa3609a2e36c"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6376), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.485", "Vehicle 485", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6377), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, 2 },
                    { 486, new Guid("4d1d364b-65c9-447a-aa4f-e8b324288849"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.486", "Vehicle 486", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6380), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, 2 },
                    { 487, new Guid("d0116061-1c19-4c7c-b810-e73201fdc16d"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6407), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.487", "Vehicle 487", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6408), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, 2 },
                    { 488, new Guid("8f461819-5486-4e0a-9c62-c55fa272b945"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.488", "Vehicle 488", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6412), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, 2 },
                    { 489, new Guid("03cff73e-8d0b-4740-b20c-ba80ca066e0d"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6414), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.489", "Vehicle 489", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6415), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, 2 },
                    { 490, new Guid("1d430873-411d-4876-b426-669941d19212"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6419), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.490", "Vehicle 490", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6420), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, 2 },
                    { 491, new Guid("c0d89747-5aa0-4ad0-b44f-0322c86c8d3f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.491", "Vehicle 491", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6424), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, 2 },
                    { 492, new Guid("7c7a1b1f-1a3a-422e-b812-41fe1051d703"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6426), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.492", "Vehicle 492", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6427), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, 2 },
                    { 493, new Guid("4cc7c692-96d7-440e-8c4a-2a8a6d271681"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6430), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.493", "Vehicle 493", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6430), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, 2 },
                    { 494, new Guid("f1d550c1-8163-4d19-8ebc-88c22d3e446c"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6433), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.494", "Vehicle 494", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6434), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, 2 },
                    { 495, new Guid("cefae582-22f0-4bca-bd23-d2bb5c020990"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6437), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.495", "Vehicle 495", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6437), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, 2 },
                    { 496, new Guid("f1ec83c3-e937-4f5d-9bdd-99f1ea54c63b"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6440), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.496", "Vehicle 496", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6441), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, 2 },
                    { 497, new Guid("3fbd0caa-eb6a-4ad8-88e8-b1bde6163515"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6444), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.497", "Vehicle 497", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6444), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, 2 },
                    { 498, new Guid("949976f7-1fc6-4318-80e3-89b842e72a9d"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6449), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.498", "Vehicle 498", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6450), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, 2 },
                    { 499, new Guid("24dc18cb-38b6-4b9d-9b4e-2f9ea547fc49"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6452), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.499", "Vehicle 499", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6453), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, 2 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1267), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1278), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1279), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1286), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1286), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1294), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1295), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1301), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1302), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1310), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1318), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1325), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1325), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1332), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1332), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1340), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1341), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1348), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1348), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1355), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1355), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1362), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1363), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1369), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1370), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1377), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1377), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1385), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1386), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1392), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1393), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1401), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(1402), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "ceiling_extra_price", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5816), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5817), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5858), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5859), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5865), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5866), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5872), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5873), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5879), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5887), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5887), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5894), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5895), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5901), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5902), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5908), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5908), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5915), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5916), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5946), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5947), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5955), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5961), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5961), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5117), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5117), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5208), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5209), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5284), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5284), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5311), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5312), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5328), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5328), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5341), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5342), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5355), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5356), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

            migrationBuilder.InsertData(
                table: "user_licenses",
                columns: new[] { "id", "back_side_file_id", "code", "created_at", "created_by", "deleted_at", "front_side_file_id", "license_type_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 15, "8ed75cf7-691b-455a-bad7-06b0b3d8ce85", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(7034), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 14, 1, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(7035), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 17, "d1accc43-a799-45ef-b2d5-24d71dffbe34", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(7052), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 16, 2, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(7053), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, 19, "9de92282-6c75-466b-8c7f-cc0acfb9da4a", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(7065), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 18, 3, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(7065), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, new Guid("c211ae37-1cc7-4bd1-94de-ebc833c88a1f"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5993), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5994), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("e121e410-c769-4212-b168-0c80d0b874f4"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(5999), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("6852530b-86f0-40b0-a820-a34c596d8c6d"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6000), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6001), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("844c3937-b057-474d-afa3-37fa5aa8b8f1"), new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6003), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6003), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "type", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 0.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6539), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6539), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 0.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6543), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6544), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 0.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6545), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6546), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 0.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6547), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6548), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 0.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6549), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6549), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 0.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6551), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6552), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 0.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6553), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6553), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 0.0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6591), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 3, 3, 18, 28, 812, DateTimeKind.Unspecified).AddTicks(6592), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
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
