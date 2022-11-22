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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("a06a5cde-b967-4464-950e-0d56d483a854")),
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 474, DateTimeKind.Unspecified).AddTicks(389), new TimeSpan(0, 7, 0, 0, 0))),
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("15504334-2bbd-4cb6-8333-5688d97b842b")),
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
                    { 1, new Guid("8f4b6ab0-0a90-49be-84f8-a2d5b07a1b1a"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3661), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3662), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("8f3e5777-899b-4362-affc-949245e81b84"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3671), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3671), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("529b47db-6fb4-4c20-ae97-f8c3e4b5f608"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3668), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3669), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 11, "We have refunded for you successfully.", 1, "Complete Refund", 0 },
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
                    { 1, new Guid("1cd1f284-fd82-4725-94d5-6835fbcdf031"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5003), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5021), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("3f7234dc-5966-4cdd-b799-f1a5feeb3374"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5034), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5035), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("a91a2eb4-ebf2-4ad9-9f8c-ed0eb3048933"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5044), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5045), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("cf50fc63-08a3-44c2-bab3-36e535bb7ce0"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5053), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5053), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("5e175fb7-e28e-44be-9bd4-f2a9bed00822"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5062), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5063), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("ac45a489-ddc0-497c-9364-9a50998bb9cd"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5073), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5074), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("0f49713d-80f5-4e51-9bce-d59da53f7f46"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5082), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5082), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("87b940b0-ffbc-4999-90ae-001a8377c4a9"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5090), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5091), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("5916f476-cd27-4cf0-8c4c-4ee000815367"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5150), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5151), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("d21e23d3-646d-4b9c-9361-adb5680b9a38"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5162), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5163), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("5ea3b29a-8ade-46b3-8cd0-88507230fd48"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5171), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("ab747805-cf64-4ad1-b6f1-2cc95b679573"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5179), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5180), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("280c1f0d-98c3-44a9-928f-acb59b215941"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5188), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5188), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, new Guid("66c06d3e-c7a9-4576-b6e6-d8cd44cc764c"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5197), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 4, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5197), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, new Guid("426d379e-ae88-4a37-bd66-56412a4099d9"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5206), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 5, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5206), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, new Guid("63f32bc1-c111-468b-b6a3-987c65314264"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5215), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 6, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5216), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, new Guid("5c951412-c7b9-4171-8267-1e475288c0a8"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 7, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5227), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, new Guid("0345ec8f-d5ba-4769-aae7-9c876fcb35a5"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5236), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 8, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5237), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, new Guid("41c26958-cdce-4b9d-8abc-f2fe913c61b2"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5244), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 9, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5245), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "license_types",
                columns: new[] { "id", "code", "name" },
                values: new object[,]
                {
                    { 1, new Guid("6b191242-19cc-411c-9c77-e4217223273c"), "Identification" },
                    { 2, new Guid("486b444b-93b0-466f-8a19-e00b49001e72"), "Driver License" },
                    { 3, new Guid("a20d6ab4-412f-494c-a34f-6db8bf2cb86c"), "Vehicle Registration Certificate" }
                });

            migrationBuilder.InsertData(
                table: "pricings",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "discount", "lower_bound", "updated_at", "updated_by", "upper_bound" },
                values: new object[,]
                {
                    { 1, new Guid("7768c203-0043-4ee9-9831-0ae5bacf5492"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.0, null, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3782), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 2, new Guid("e0977660-b843-444d-8b23-1dab86f3b8d2"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3786), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.029999999999999999, 8, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3786), new TimeSpan(0, 7, 0, 0, 0)), 0, 30 },
                    { 3, new Guid("24b7825f-5b8b-4cfd-82a7-a707f7a1fdc5"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3788), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.050000000000000003, 31, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3788), new TimeSpan(0, 7, 0, 0, 0)), 0, 90 },
                    { 4, new Guid("b6d14541-ce38-44dd-b26e-2eb5693c10a4"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3790), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.070000000000000007, 91, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3790), new TimeSpan(0, 7, 0, 0, 0)), 0, null }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2220), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2220), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2249), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2250), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2259), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2259), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 25, "BannerFileSizeLimit", null, "20" }
                });

            migrationBuilder.InsertData(
                table: "stations",
                columns: new[] { "id", "address", "code", "created_at", "created_by", "deleted_at", "latitude", "longitude", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("4d27f1ea-0180-422a-a9b8-5a902a4505db"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2546), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2546), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1e33bca3-29ac-4b82-9e83-5185d3e28dbf"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2551), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2552), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("976c2bcc-233e-4ba6-bf38-d8a73bb8120e"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2554), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2554), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5ae90fa4-ca5a-493e-838d-ea23a9a308be"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2556), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2556), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f6e61ea6-737b-4a3e-b1ea-05bb3230793d"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2558), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2559), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1485c768-abeb-482f-b49b-ab195fa19161"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2565), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2565), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ec8a3c3b-1e41-4e26-8095-695a70f1da2c"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2568), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2568), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("60b117dc-f495-4fda-a567-2606b1fa0110"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2570), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2570), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("d3d52a5a-e5ca-44fb-871a-b873bec037a0"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2572), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("9f0ae8c7-5b29-44d8-85e0-a99b77b2a012"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2575), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2576), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7030d270-92fd-4ec9-a778-b65ef8c452b7"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2577), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2578), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("153ee42a-e1dc-4ec5-996d-392281e3d063"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2579), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2580), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("00c74500-2cd9-4226-94ea-fa3c34796327"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2581), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2582), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("661d9960-4d05-4737-8308-f6a7bf45e6de"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2636), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2636), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4636bcce-6e27-4b0c-a5dc-65355c98a0f3"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2639), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2639), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ff14363f-c638-4bb0-a519-587e32d26890"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2641), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2642), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a6574844-275c-4bbb-b12f-a0df089da6af"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2643), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2644), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("66a6af5b-a2db-4396-b90d-0444c2e16a7b"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2646), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2647), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a8ea0f7b-a8ff-42f8-b2b3-ac3ccf4e4748"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2649), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2649), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("77856368-e34d-4b0d-a7b4-52e17656be2d"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2651), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2651), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("47bc0b09-ca15-4699-a471-4915934370bd"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2653), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2653), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d7887893-2945-4cd0-86ad-f996a53ce436"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2657), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2657), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b9bafe1c-fceb-4dda-875f-5ebcc6e9ec31"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2662), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2663), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("68ef3531-33c0-431b-a538-8ef697c6d580"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2665), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("659fdd04-f695-4515-b509-a328b9936822"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2666), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2667), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e8987593-e65e-4256-acfb-44e1af8c8fb3"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2668), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2669), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1b8880ef-f59e-404a-bfd9-29fb3a567e06"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2670), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2671), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c4b95647-5b58-40a1-b67f-0c16fdf453a9"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2e6f120e-aff8-4e16-a7ec-1ac73a28af15"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2677), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("64a712bc-ce8c-4639-bd74-aba5e8eaa538"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2678), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2679), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("05d94f3c-5e41-49fe-95aa-c81222fd5b51"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2681), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2681), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6fc7b398-e67f-435c-b156-333a3a2459ac"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2683), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2683), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d3921f52-178c-469f-8299-f3243db8e89d"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2686), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2687), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("291caff6-fde4-4f29-bcd7-1f6e98a3d286"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2689), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b0d735ef-5c68-42eb-b2d2-20b9b40549a6"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2690), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2691), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0b4fdfdf-1fba-4144-99a6-f197169fd1a5"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2693), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2693), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("6e3a5a2f-cf6c-4fce-86ed-b9d3b5751543"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2696), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2697), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("96e36f3a-361d-455d-9fc3-49bdb91832fc"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2698), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2699), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0fda488b-87c0-4682-9bcf-0e5edb6e79b5"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2701), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2701), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0579cd49-785b-4bab-a29f-dea7e55f5d02"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2703), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2703), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("eb215a9e-cad9-4be9-80b0-4fd171bd050a"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2705), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2706), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e7d9c2d1-f321-4fa0-a3fc-4e5a1d024616"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2707), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2708), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("1e62ed95-d2d9-4259-b7bb-68a1f92a4a5c"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2709), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2710), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("22f77b36-ae4e-4f5b-98d6-e096dac8bf9c"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2711), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2712), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1da4875a-c23b-445b-ac1f-c7b5fccba494"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2715), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2716), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2749a388-6f03-4c50-a92f-652fe0a46d6d"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2718), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2719), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b94a9768-2c01-43cc-a9c3-8bacdd459526"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2721), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2721), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e8afb7a6-24c0-4155-85db-e9316e08263a"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2723), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2723), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5c386595-421e-4631-83a7-156b3e1ecc3b"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2725), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2725), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cb0ad844-70e7-4173-981f-bda4152547ef"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2727), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2727), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3c612860-5336-481e-840d-0f7957dc02ef"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2729), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2729), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("48e6772d-389a-419d-a0ef-25649cc498dd"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2731), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2731), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("257615be-f25b-4991-9b14-4c7290a60543"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2770), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7b46f387-94ad-4d97-a26b-6559e7ff59e2"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2772), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2773), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f49f3593-79b0-42e1-bd2d-bbe80abb28a0"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2775), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2775), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2b8d3948-a2ab-4455-be1f-0c9195ac007b"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2777), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2777), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1d4d3b78-d492-4753-9468-677a59e50bdf"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2779), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2780), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("de5ee867-2502-4922-acea-36b2a8823480"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2782), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a0445c12-d269-49c5-b000-2e36d405caec"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2783), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2784), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b9b342ff-8865-4355-9e6c-22ea8b99b5ad"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2785), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2786), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8b0d32ef-d365-4318-a964-6a9fd010f5a6"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2789), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2790), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("279d004b-a76b-4966-a195-4f3b27b139b1"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2791), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2792), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9c8acc1b-183f-4739-81ce-d69da159fa31"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2794), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2794), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fd6b2f11-bc10-4514-aaa7-025622a7f9cd"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2796), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2796), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c6b3e67e-480f-42cb-95c7-46b95db30310"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2800), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2800), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2bfa1b3e-bc81-483a-8cfa-c88c3542d113"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2802), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2802), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("722a1060-1bdc-4d7a-8ee0-40ea35c7a5b6"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2804), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2804), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("56bb11dd-75f7-485e-9378-5972aab5cd06"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2806), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2807), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0ee3e89c-d6c3-4e7b-bdc7-e6de840a4653"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2813), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2814), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4e7d537a-0fbe-4cc2-8e55-0b9ee06f44d9"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2815), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2816), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("a4094234-9ddc-4e66-97c1-a73464e7aab4"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2817), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2818), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c1e7cd74-35d5-427d-bcd8-de17d17db8ce"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2820), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2820), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c95078a0-7825-4cff-8189-ee2373fa6d86"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2822), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2822), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("992e991b-ea0b-49cf-89df-2000d24de949"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2824), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2824), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3e437909-5061-4b0a-865d-f591a3249e5e"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2826), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2826), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0cd8c4e4-94fe-40cf-9b3a-96b987363576"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2828), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2828), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f090aa51-1245-49d9-9468-97aa7dac3929"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2832), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2832), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("aba7fc2d-097f-4ece-a9cb-1243f1a69d0b"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2834), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2835), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7a8cb08f-502e-47d3-bdd8-dcdf736da7df"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2836), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2837), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("2834d242-78f9-4eee-bc87-e491487b0270"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2839), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2839), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("624d262b-3580-4be2-8365-48ad58856374"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2841), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2841), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("7f712efe-d573-498b-b11c-464880d21b9a"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2843), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2843), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("a0bf4ba7-cc70-45e8-a077-802502d45fa5"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2845), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2845), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("ee9fe75d-e95a-4ffc-b693-35fea3b3dd6f"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2848), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("83aec35a-0086-416f-ac6a-9e79a354da1d"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2659), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2659), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô E2a-10 Đường, D2b Đ. D1, TP. Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam", new Guid("c75c0d02-754b-42ee-a39b-21ded95778d1"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2851), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2851), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trip_rate", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "rating", "status", "suddenly_cancelled_trips", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 10, 0.0, new Guid("6a38afc1-5988-482a-b6fd-b4a56376923f"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5408), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Than Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5409), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 0.0, new Guid("c1b816ea-656c-4f3a-a7b7-19413bccf598"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5419), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Nguyen Dang Khoa", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5420), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 0.0, new Guid("4801b2b9-7ed6-44ef-a1af-9c298f1d60ca"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5432), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Do Trong Dat", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5433), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 100, 0.0, new Guid("078dc77c-1612-4cf9-9be0-6233f83f8067"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5445), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 100", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5445), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 101, 0.0, new Guid("7e7747be-ce47-4995-b85b-616e13b3125a"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5469), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 101", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5470), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 102, 0.0, new Guid("d076e295-8437-4145-a1b7-9176cb7921b6"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 102", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5481), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 103, 0.0, new Guid("cb614048-3eb9-4733-9873-4fc322709d71"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 103", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5534), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 104, 0.0, new Guid("8e2d39ca-01fa-4561-af14-7d266e70f3f9"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5547), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 104", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5548), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 105, 0.0, new Guid("1272a1a6-b24f-4b7d-bd91-6b3b63b5948a"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5559), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 105", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5560), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 106, 0.0, new Guid("9c87a0aa-e3be-4a4c-a6c0-7525d74e5604"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 106", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5571), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 107, 0.0, new Guid("32b5e64c-5184-457c-8841-0af371180b7a"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5584), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 107", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5584), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 108, 0.0, new Guid("f438af07-520c-4998-a8fb-6beb6984eaf4"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5595), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 108", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5595), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 109, 0.0, new Guid("4d32620e-9df9-4632-8bfa-2cf8f7389e31"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5606), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 109", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5607), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 110, 0.0, new Guid("05ee5bed-78b0-4571-b89f-84dba5c35b5a"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5616), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 110", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5617), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 111, 0.0, new Guid("b02b785f-cced-4b12-8cfa-8eeb0f02d4d8"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5629), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 111", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5630), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 112, 0.0, new Guid("260532e4-d0fe-456c-aa30-41c2ff36f4ed"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5640), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 112", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5641), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 113, 0.0, new Guid("5859c68e-f696-4174-b3d1-968fc46d2bf1"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5690), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 113", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5691), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 114, 0.0, new Guid("f6ad542e-2a0e-434f-b17b-494bb3dbc4c5"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5703), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 114", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5704), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 115, 0.0, new Guid("3db11606-c4a0-411f-b66e-f367f38c445d"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5716), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 115", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5717), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 116, 0.0, new Guid("3f7bc588-050f-4d26-91d0-cfe84d27d99e"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5727), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 116", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5728), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 117, 0.0, new Guid("b5cb8bde-9d13-4865-a2d8-90f2b8153911"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5738), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 117", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5739), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 118, 0.0, new Guid("3b845236-fb13-41a4-bb1d-2d5ccd37323a"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5749), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 118", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5750), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 119, 0.0, new Guid("35c40504-096b-414b-bc6e-cc8ecfe27c1d"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 119", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5763), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 120, 0.0, new Guid("f115d727-1ad6-4648-bdab-b59eaa1f9e04"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5773), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 120", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5774), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 121, 0.0, new Guid("5495cb09-e01e-4c6c-879a-5a83d92cc754"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5785), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 121", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5786), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 122, 0.0, new Guid("cabc1ad2-2dbd-4ad1-b04c-0e356b18cdbf"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5796), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 122", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5797), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 123, 0.0, new Guid("599de99b-fbd0-43ab-97b2-32db2389c551"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5831), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 123", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5832), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 124, 0.0, new Guid("b91fae7d-05aa-4a5f-a56e-cf856088d563"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5844), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 124", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5845), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 125, 0.0, new Guid("8f882a78-739f-4804-b4c3-9cdf354b792b"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5855), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 125", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5856), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 126, 0.0, new Guid("87084d99-07fd-4f86-b734-5cf9dbbd0481"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5866), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 126", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5867), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 127, 0.0, new Guid("e7bdcfdf-b4d0-44ee-b848-8dc8e97cf097"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 127", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5879), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 128, 0.0, new Guid("96bfcbbe-0b05-40c5-bc6d-b4dac39964db"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5889), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 128", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5890), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 129, 0.0, new Guid("edf3d5d0-7ae1-4fcc-8b96-90982a398800"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5900), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 129", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5901), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 130, 0.0, new Guid("03df5d1d-8a90-419e-881b-a9424d262d1e"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5911), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 130", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5911), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 131, 0.0, new Guid("532c139c-4f71-4188-8423-fb9b2c1b38c6"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5923), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 131", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5924), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 132, 0.0, new Guid("b7dc6c5a-3a1f-4f2b-b154-6ca4f94d6d1d"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 132", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5935), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 133, 0.0, new Guid("e7b79171-c522-496a-a6c7-8efbfba39fa2"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5945), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 133", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5946), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 134, 0.0, new Guid("acf925a1-b842-4944-9517-9b6414a38607"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5978), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 134", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5979), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 135, 0.0, new Guid("70bf4541-63f4-43cd-a3e3-06be8f0ffdfe"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5993), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 135", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5994), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 136, 0.0, new Guid("d20077ef-c7e9-4348-9245-5358bb20f47f"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6003), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 136", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6004), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 137, 0.0, new Guid("2686f50a-c489-46a9-ab42-484cb5b58069"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6014), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 137", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 138, 0.0, new Guid("ccc75cfc-c39e-409a-8712-c4bde1df70a8"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 138", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6026), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 139, 0.0, new Guid("4faa5e0b-87b7-4217-8169-aa95d077145e"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6038), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 139", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6038), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 140, 0.0, new Guid("c7143b09-6941-444c-af4e-75adc0b1fe82"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6049), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 140", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6049), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 141, 0.0, new Guid("da294ae1-bc9d-4cb5-bd80-fea5f305cec4"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6059), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 141", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6060), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 142, 0.0, new Guid("95b1442f-dcf6-40d6-bfdf-e96240850a0f"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6070), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 142", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6071), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 143, 0.0, new Guid("c94c2944-6f1d-49ce-a89e-a32ee75b4aa1"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6083), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 143", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6083), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 144, 0.0, new Guid("5842a1f9-d601-4077-b8ce-ba0d59087e6b"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6094), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 144", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6094), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 145, 0.0, new Guid("44d7b86e-ce34-4e7e-948f-99e0d0ce4314"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 145", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6142), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 146, 0.0, new Guid("a57816c4-19e4-4a20-b2ac-23452e55b39a"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6154), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 146", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6154), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 147, 0.0, new Guid("7bbaf2a8-5b02-4e70-9834-642ff0df2033"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6166), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 147", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6167), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 148, 0.0, new Guid("571b20f0-4287-4ff9-b684-ad31de19b4ab"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6178), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 148", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6178), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 149, 0.0, new Guid("5a6723ba-aa0b-42de-be33-54eff677ccd7"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6189), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 149", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6189), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 150, 0.0, new Guid("52c70020-625c-40fb-b847-3b36ec7560c6"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 150", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6229), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 151, 0.0, new Guid("2537e52e-eee9-4cba-8f6d-096fddacee26"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6250), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 151", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6252), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 152, 0.0, new Guid("4d34489a-e4b6-4eaf-8f25-e71354a191d1"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6270), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 152", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6271), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 153, 0.0, new Guid("9ab94803-1318-4088-97b0-938a8ab28673"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6287), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 153", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6288), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 154, 0.0, new Guid("3848339c-f6f1-407d-8cd9-232b5cde6172"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6323), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 154", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6324), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 155, 0.0, new Guid("3fffec68-6762-4959-9d48-777e4bb572e0"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6338), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 155", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6339), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 156, 0.0, new Guid("f29c5ee3-c88e-475a-8b84-636599da485c"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6349), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 156", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6350), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 157, 0.0, new Guid("2a7620bb-0dca-4081-abde-d1b93b7abb88"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6359), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 157", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6360), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 158, 0.0, new Guid("ef8f6523-8b9d-4f97-9c42-5a65d2009c88"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6370), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 158", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6370), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 159, 0.0, new Guid("00f1bbf9-abde-4a29-9a88-51f9d0f31c98"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6382), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 159", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6383), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 160, 0.0, new Guid("5366fffb-da91-44e8-ab90-0609e3974b6c"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6393), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 160", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6394), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 161, 0.0, new Guid("3cbebac0-077b-4ecd-90f6-4745e0f6bef0"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 161", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6404), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 162, 0.0, new Guid("ff8cb4c4-d536-4f8c-9fb6-d1eb0b36c03d"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6414), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 162", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6415), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 163, 0.0, new Guid("b746cef0-6b7b-4cce-8172-98ae9c3ca7af"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6427), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 163", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6428), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 164, 0.0, new Guid("c76a5d21-a431-4dda-b258-c5cb81a9d7e1"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6437), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 164", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6438), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 165, 0.0, new Guid("59b29950-8316-4059-84a9-a768b40010e4"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6494), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 165", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6495), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 166, 0.0, new Guid("a0303f4f-2e38-4674-a288-a70a30ce484b"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6508), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 166", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6508), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 167, 0.0, new Guid("7b406065-5c2a-43aa-88ae-524bbd01ae6d"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6521), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 167", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6521), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 168, 0.0, new Guid("38af4ef0-afe7-4a2c-8c5f-afd7e1b55b16"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6532), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 168", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6532), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 169, 0.0, new Guid("956e2437-2ed1-4c90-ae4f-03a5273d6ea2"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6542), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 169", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6543), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 170, 0.0, new Guid("41888732-13c5-4b09-bcbc-73913a5f633e"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6553), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 170", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6554), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 171, 0.0, new Guid("8942d6de-1ade-46cd-9949-963380294906"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6566), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 171", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6566), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 172, 0.0, new Guid("3657c123-5c4f-412a-b3e9-0a8b59bda8bf"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6576), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 172", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6577), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 173, 0.0, new Guid("c691eb77-bf1e-45d1-92c1-5e235efcfaef"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 173", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6587), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 174, 0.0, new Guid("0e20e359-b048-48b7-a5cf-e7627284b3b3"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6597), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 174", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6598), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 175, 0.0, new Guid("63c9083f-e727-4ec9-be12-611983b4e8c2"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6610), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 175", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6611), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 176, 0.0, new Guid("2feb7072-f94d-4201-9284-5af4f54919ce"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 176", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6648), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 177, 0.0, new Guid("cce9423e-5bef-46ec-9cae-e5dd74f7694d"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6660), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 177", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6660), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 178, 0.0, new Guid("e781045e-aa9c-4ae6-9eb1-cfaf5264f671"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6670), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 178", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6671), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 179, 0.0, new Guid("08b07302-e859-4724-bad6-5e1c824e21eb"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6683), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 179", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6683), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 180, 0.0, new Guid("2e8b58f9-061e-4a71-9745-144531b27fb6"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6693), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 180", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6693), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 181, 0.0, new Guid("293d89af-8a51-4c30-a8c1-8635b718a521"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 181", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6704), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 182, 0.0, new Guid("f2f22518-eb3c-4c70-9ebe-dcddb0152c97"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6714), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 182", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6715), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 183, 0.0, new Guid("e3550d8b-f310-4a44-bca6-df2c16ddeee8"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6727), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 183", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6727), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 184, 0.0, new Guid("a1982d3d-96e6-4e2b-a5e6-e91837bb8856"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6738), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 184", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6738), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 185, 0.0, new Guid("d75bf9aa-6472-4b31-8e58-0f84934469c3"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6748), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 185", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6749), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 186, 0.0, new Guid("d4e5aad7-998b-41b0-8ae1-eec28da8a412"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6780), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 186", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6780), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 187, 0.0, new Guid("f3ccbc38-0656-4b48-a414-75905c71e5a2"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6794), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 187", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6795), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 188, 0.0, new Guid("9d272f62-a56c-4379-ba68-6edfa08b6eb9"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6805), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 188", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6806), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 189, 0.0, new Guid("272a9077-e744-44ed-9025-23510e464162"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6816), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 189", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6816), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 190, 0.0, new Guid("10d75f4c-f1fc-4e42-947f-0ae3fda37ab3"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6826), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 190", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6827), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 191, 0.0, new Guid("a1965141-1880-4552-98a0-21d5327f7f56"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6839), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 191", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6839), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 192, 0.0, new Guid("e6b260b9-a9f8-44de-9f1e-2fa8e37eaf3f"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6850), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 192", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6850), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 193, 0.0, new Guid("a57a881a-fe36-4f49-acd9-20617807d410"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6860), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 193", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6861), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 194, 0.0, new Guid("47fa50cb-7a47-43ee-94ce-f3336694fcfa"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 194", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6872), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 195, 0.0, new Guid("56df1e94-f5c6-4ae2-a8fc-8ac5c3ecb126"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6884), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 195", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6884), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 196, 0.0, new Guid("67d61f8b-5cb3-4874-aef4-ecccf248dd48"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6894), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 196", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6895), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 197, 0.0, new Guid("be5fa5b7-d1fa-44e7-82fd-ce9c26a13713"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6969), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 197", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6970), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 198, 0.0, new Guid("efe81257-3269-4e38-aee1-72d0907b2b67"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6983), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 198", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6984), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 199, 0.0, new Guid("8717e6cb-6796-46bc-8dd6-9dcf6f6f93c9"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6996), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 199", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(6996), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 400, 0.0, new Guid("7a6aba4b-4db8-44ec-a2de-a73b38a2e3f1"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7007), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 400", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7007), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 401, 0.0, new Guid("cbb1e604-cadb-4914-a88d-c3cdc6c2dd30"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7018), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 401", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7019), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 402, 0.0, new Guid("df6e9a07-4fdf-4971-b79a-373f97455485"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7029), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 402", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7030), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 403, 0.0, new Guid("85174e62-bc5b-46cd-b133-d3b216f06401"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7042), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 403", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7042), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 404, 0.0, new Guid("00e7e671-093d-4bb4-b175-963bb3e348a7"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7053), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 404", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7054), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 405, 0.0, new Guid("17bedd04-5df9-40a7-ab46-c5546edb7aae"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7064), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 405", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7065), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 406, 0.0, new Guid("77a6a505-d2ca-428a-add0-0a69f520500d"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7075), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 406", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7075), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 407, 0.0, new Guid("27caf7e7-6d2f-41fc-bc67-291d856d8ca5"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7087), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 407", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7088), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 408, 0.0, new Guid("b6bab8c3-fb12-4b1b-8c11-2f83cbced1a3"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7134), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 408", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7135), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 409, 0.0, new Guid("c8937009-2d34-431a-a1e8-856da031bef4"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7147), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 409", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7147), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 410, 0.0, new Guid("7da0c342-c326-4023-a3c0-d88a8b3b172c"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 410", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7158), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 411, 0.0, new Guid("0a281906-5bf2-4b7b-ad1d-0b5560b9992c"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 411", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7171), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 412, 0.0, new Guid("f38dbf94-cc8e-44ae-abe1-ba2b27193e2a"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7181), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 412", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7181), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 413, 0.0, new Guid("6f72a2aa-9fdc-4668-b16f-eaa47804064b"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7192), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 413", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7192), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 414, 0.0, new Guid("9d7f095d-890b-41e2-a399-cfaccfc1b3e1"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7202), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 414", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7203), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 415, 0.0, new Guid("40ef8f04-55b9-40bd-b039-549b8da04c38"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7215), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 415", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7215), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 416, 0.0, new Guid("7f241e6b-1388-455c-9afc-815daba85a6b"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7225), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 416", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7226), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 417, 0.0, new Guid("d48f2bd7-dbef-40e6-a739-0558b859bcba"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7261), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 417", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7262), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 418, 0.0, new Guid("1b763bc0-01ef-4fd8-93c0-9bf02f46a140"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 418", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7273), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 419, 0.0, new Guid("01ab41a0-5771-4fb6-9f40-b47ac4eb7611"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7285), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 419", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7286), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 420, 0.0, new Guid("a3f6d66c-4551-4c83-ba5e-3fd858bf0c2f"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7296), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 420", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7296), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 421, 0.0, new Guid("aafdd102-f7e9-4585-ad52-c5e68b234c32"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7306), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 421", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7307), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 422, 0.0, new Guid("5cc60751-5974-4ffc-928f-2585cb6296c5"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 422", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7317), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 423, 0.0, new Guid("628b9574-fab0-4973-9829-ae5cedd5c29c"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7329), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 423", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7330), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 424, 0.0, new Guid("f52e9643-872a-47af-953b-9cd1f15285cc"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7341), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 424", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7341), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 425, 0.0, new Guid("cb70aecc-b201-4028-95c5-8af13994046c"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7351), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 425", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7352), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 426, 0.0, new Guid("fdc5b172-ef00-4ebc-bc02-c6a2b8a17a26"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 426", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7362), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 427, 0.0, new Guid("42ee0ec6-875a-4130-87f9-c3d416719dfd"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 427", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7398), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 428, 0.0, new Guid("15339a8e-56e8-41df-b556-de042ee42ee4"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7409), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 428", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7409), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 429, 0.0, new Guid("b955a774-3734-465e-969d-a865d0790159"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7419), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 429", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7420), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 430, 0.0, new Guid("9cc640df-89e6-45cb-91b1-a550959b3423"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7430), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 430", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7430), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 431, 0.0, new Guid("d46c303c-c546-4035-ba24-be95d912d241"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7443), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 431", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7443), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 432, 0.0, new Guid("a0fb968e-651b-4d3a-bb34-566f26c83b96"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7453), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 432", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7454), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 433, 0.0, new Guid("8221481d-acb9-452a-90ab-d886d036714f"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7463), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 433", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7464), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 434, 0.0, new Guid("72970311-1b13-4ccb-8222-020c2e4a54cc"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7474), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 434", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7474), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 435, 0.0, new Guid("712087fe-bc10-4d8f-b777-43b08480bfde"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7486), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 435", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7487), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 436, 0.0, new Guid("a19bf8ff-6daa-455a-bdad-5db3de760fef"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7496), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 436", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7497), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 437, 0.0, new Guid("06aa191a-e9f2-4ed4-a6f7-c07debeea77b"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7529), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 437", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7530), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 438, 0.0, new Guid("3ccac93a-5eaf-415d-92e1-41ce3457d5d8"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7542), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 438", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7543), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 439, 0.0, new Guid("23573847-dcd3-46b1-af2d-b3bda8e22f67"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7555), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 439", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7556), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 440, 0.0, new Guid("1cc20cd6-6fd7-4696-8d36-fb163d00d99b"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7566), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 440", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7566), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 441, 0.0, new Guid("58f7ef91-2114-4b38-9447-f22790d70af3"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7576), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 441", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7577), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 442, 0.0, new Guid("86639778-c18c-4d9f-b836-44b0c9eada2a"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 442", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7587), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 443, 0.0, new Guid("1888e0de-e0c0-4e7e-a216-8299a5aee22b"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7599), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 443", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7600), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 444, 0.0, new Guid("e75fb7f4-0a56-4910-bc1c-f27f70202578"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7610), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 444", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7611), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 445, 0.0, new Guid("8b43f1aa-d58a-4a9c-b91a-0dd57f37a81f"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7621), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 445", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7621), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 446, 0.0, new Guid("7f848f5c-8457-4d54-9c05-87c9c3d6696c"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7631), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 446", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7631), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 447, 0.0, new Guid("9ccf2263-3981-4939-bb36-ada820ff4282"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7643), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 447", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7644), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 448, 0.0, new Guid("2b4eebe5-a37a-498e-bc85-f0a48a45a089"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 448", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7677), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 449, 0.0, new Guid("9801edd0-69e1-486d-92ba-14f87790006e"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 449", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7689), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 450, 0.0, new Guid("ceb14015-5d43-4435-8c74-ee035ac628c8"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7699), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 450", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7700), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 451, 0.0, new Guid("2844c58e-6f34-4ff3-a512-3f1a00506fb9"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7712), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 451", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7712), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 452, 0.0, new Guid("288fee67-03a5-4358-8880-489b3e895cb1"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7722), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 452", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7723), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 453, 0.0, new Guid("b9e9b2d5-6bc7-4ad6-af0b-d7e72ed6df7f"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7733), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 453", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7733), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 454, 0.0, new Guid("e6791bc8-ef0e-43d9-8acd-3e4743b95606"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7744), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 454", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7744), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 455, 0.0, new Guid("0e62d176-73dd-4621-b05a-bac716fa6be3"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7756), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 455", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7757), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 456, 0.0, new Guid("57fec6e9-0f94-4794-a2c0-91593addf0aa"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7766), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 456", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7767), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 457, 0.0, new Guid("28bfc065-245a-4355-81b1-9b7ecb042cd4"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7777), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 457", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7777), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 458, 0.0, new Guid("6933bb12-bee4-4a85-b5fa-e9936142f810"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7787), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 458", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7788), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 459, 0.0, new Guid("5c597975-a641-43f3-96ba-24ca0100741b"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7825), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 459", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7826), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 460, 0.0, new Guid("f2668d7f-4f85-456b-97b5-1d92968346bf"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7837), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 460", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7838), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 461, 0.0, new Guid("9a6eb2e9-01e4-46b4-adde-e1739c137de4"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7848), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 461", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7849), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 462, 0.0, new Guid("59212ba1-2ae4-4e01-871f-18002fb66fe2"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7859), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 462", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7859), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 463, 0.0, new Guid("f9f85a2b-d710-4683-af46-5fda3dd5d4c7"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 463", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7872), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 464, 0.0, new Guid("1de3876f-53bc-4e9d-b014-93af1246e020"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7882), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 464", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7883), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 465, 0.0, new Guid("5ad9ba06-fdfd-4bfe-8a7f-4f13c7c51541"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7893), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 465", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7893), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 466, 0.0, new Guid("24770bae-871f-4432-bcaa-5ec0a122aa7d"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7904), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 466", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7904), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 467, 0.0, new Guid("a6094a21-e0d1-4615-9289-9f71b505da94"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7916), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 467", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7917), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 468, 0.0, new Guid("f61d4b9c-0708-4a06-8762-b4a9c5b383fb"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7927), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 468", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7927), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 469, 0.0, new Guid("d7bd5f73-40c2-4a94-b920-57d6366217a1"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7937), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 469", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7938), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 470, 0.0, new Guid("f22dfa71-bd84-4f76-95a2-d77b1d15c5aa"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 470", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7977), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 471, 0.0, new Guid("6f988cee-568c-47d0-8fdb-ef8a960fc6c5"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7990), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 471", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(7990), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 472, 0.0, new Guid("205a9a51-2d86-4192-b23b-c8fb9d48ae7d"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8000), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 472", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8001), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 473, 0.0, new Guid("6089f9b6-de8a-4f3d-b5af-2ee2bb18b1b7"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8010), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 473", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8011), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 474, 0.0, new Guid("f8478dbd-c76f-48a7-9f9f-18a4d2de70c1"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8021), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 474", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8021), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 475, 0.0, new Guid("a0c18e97-6ebc-4109-914d-669478afe1ae"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8033), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 475", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8034), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 476, 0.0, new Guid("5034f98d-2ddf-449b-9dba-e037ecfc863f"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8044), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 476", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8045), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 477, 0.0, new Guid("f8d3e798-27a5-459a-890e-3aeef7bb6e85"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8054), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 477", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8055), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 478, 0.0, new Guid("f9a3789e-84d3-4fbe-80d1-57d144e0cf4c"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8065), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 478", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8065), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 479, 0.0, new Guid("88f65c45-326f-4fa9-b776-e93fbe140ea4"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8077), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 479", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8078), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 480, 0.0, new Guid("673422f0-1b0b-42ae-83d7-6ea17cca033e"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8125), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 480", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8126), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 481, 0.0, new Guid("d095b231-4714-4f16-84a4-b0dae579831b"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8139), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 481", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8140), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 482, 0.0, new Guid("48ce775a-ce3d-4317-b026-5fe49fbf0ea5"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8150), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 482", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8151), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 483, 0.0, new Guid("d9f3fb1f-e4c1-463b-9107-e7f3cb57fb82"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8163), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 483", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8164), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 484, 0.0, new Guid("9582d0ff-2473-4384-af04-8ebd62210e0d"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 484", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8174), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 485, 0.0, new Guid("a4d2c44e-976a-4c16-addb-953f436f6961"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8184), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 485", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8185), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 486, 0.0, new Guid("c1b791fa-e0d7-4b72-b6c8-52dc39e58da2"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8195), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 486", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8195), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 487, 0.0, new Guid("8ae7e044-ab4e-4dbe-ad38-cdf50aae7212"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8207), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 487", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8208), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 488, 0.0, new Guid("f6dbee19-e368-4842-960f-ad8031526316"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8217), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 488", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8218), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 489, 0.0, new Guid("49b085da-4d01-4ee5-9a35-b5488f7ac23d"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 489", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8228), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 490, 0.0, new Guid("3492cf35-3b74-4c6d-9bff-9b49af92340f"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8238), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 490", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8238), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 491, 0.0, new Guid("e2c88779-67b8-4e4a-bf8c-2fddd56b27f9"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 491", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8290), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 492, 0.0, new Guid("c08c3e3d-fbef-477d-88d5-ae8a7e269171"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 492", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8303), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 493, 0.0, new Guid("9a727858-f472-45b3-b439-c2fb2ce37391"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8313), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 493", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8313), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 494, 0.0, new Guid("fed80966-f74d-454a-8a72-b37ae893fd20"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8323), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 494", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8324), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 495, 0.0, new Guid("b453a7fa-29c9-42fb-b920-7f991e5fe36d"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8336), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 495", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8336), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 496, 0.0, new Guid("f60c6e4c-8b00-441e-a8b4-4fb449c48634"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8346), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 496", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8347), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 497, 0.0, new Guid("e70519e7-0a15-4ea8-bef9-3d55e422af40"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8356), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 497", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8357), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 498, 0.0, new Guid("297cb48f-2d76-4602-a823-b7c4e677d189"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8367), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 498", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8368), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 499, 0.0, new Guid("09513119-7c23-40aa-8607-72b839ebe81e"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 499", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8381), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "name", "slot", "status", "type" },
                values: new object[,]
                {
                    { 1, new Guid("218679e5-58f8-427b-b1b1-b19fabebacac"), "ViRide", 2, 1, 0 },
                    { 2, new Guid("bf01039b-998e-467a-8d07-9ac732bad7e5"), "ViCar-4", 4, 1, 1 },
                    { 3, new Guid("7dac0906-3460-4ba8-ae84-8c98d7e540de"), "ViCar-7", 7, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "type", "updated_at", "updated_by", "user_id" },
                values: new object[] { 9, 0.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3708), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3708), new TimeSpan(0, 7, 0, 0, 0)), 0, null });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8576), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8577), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8584), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8584), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8591), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8591), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8598), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8598), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8605), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8606), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8612), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8613), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 100, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8620), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+100", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8621), new TimeSpan(0, 7, 0, 0, 0)), 0, 100, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 101, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8631), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@100", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8632), new TimeSpan(0, 7, 0, 0, 0)), 0, 100 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 102, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8641), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+101", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8642), new TimeSpan(0, 7, 0, 0, 0)), 0, 101, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 103, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8673), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@101", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8674), new TimeSpan(0, 7, 0, 0, 0)), 0, 101 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 104, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8682), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+102", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8683), new TimeSpan(0, 7, 0, 0, 0)), 0, 102, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 105, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8690), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@102", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8691), new TimeSpan(0, 7, 0, 0, 0)), 0, 102 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 106, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8697), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+103", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8698), new TimeSpan(0, 7, 0, 0, 0)), 0, 103, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 107, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8705), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@103", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8705), new TimeSpan(0, 7, 0, 0, 0)), 0, 103 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 108, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8712), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+104", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8713), new TimeSpan(0, 7, 0, 0, 0)), 0, 104, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 109, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8721), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@104", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8721), new TimeSpan(0, 7, 0, 0, 0)), 0, 104 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 110, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8728), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+105", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8729), new TimeSpan(0, 7, 0, 0, 0)), 0, 105, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 111, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8736), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@105", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8736), new TimeSpan(0, 7, 0, 0, 0)), 0, 105 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 112, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8743), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+106", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8743), new TimeSpan(0, 7, 0, 0, 0)), 0, 106, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 113, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8750), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@106", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8751), new TimeSpan(0, 7, 0, 0, 0)), 0, 106 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 114, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8757), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+107", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8758), new TimeSpan(0, 7, 0, 0, 0)), 0, 107, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 115, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8765), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@107", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8766), new TimeSpan(0, 7, 0, 0, 0)), 0, 107 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 116, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8772), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+108", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8773), new TimeSpan(0, 7, 0, 0, 0)), 0, 108, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 117, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8779), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@108", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8780), new TimeSpan(0, 7, 0, 0, 0)), 0, 108 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 118, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8786), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+109", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8787), new TimeSpan(0, 7, 0, 0, 0)), 0, 109, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 119, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8794), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@109", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8794), new TimeSpan(0, 7, 0, 0, 0)), 0, 109 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 120, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8801), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+110", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8802), new TimeSpan(0, 7, 0, 0, 0)), 0, 110, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 121, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8809), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@110", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8809), new TimeSpan(0, 7, 0, 0, 0)), 0, 110 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 122, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8816), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+111", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8816), new TimeSpan(0, 7, 0, 0, 0)), 0, 111, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 123, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8823), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@111", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8824), new TimeSpan(0, 7, 0, 0, 0)), 0, 111 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 124, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8852), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+112", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8853), new TimeSpan(0, 7, 0, 0, 0)), 0, 112, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 125, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8861), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@112", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8861), new TimeSpan(0, 7, 0, 0, 0)), 0, 112 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 126, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8868), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+113", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8868), new TimeSpan(0, 7, 0, 0, 0)), 0, 113, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 127, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8876), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@113", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8876), new TimeSpan(0, 7, 0, 0, 0)), 0, 113 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 128, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8883), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+114", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8883), new TimeSpan(0, 7, 0, 0, 0)), 0, 114, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 129, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8890), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@114", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8890), new TimeSpan(0, 7, 0, 0, 0)), 0, 114 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 130, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8897), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+115", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8898), new TimeSpan(0, 7, 0, 0, 0)), 0, 115, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 131, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8904), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@115", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8905), new TimeSpan(0, 7, 0, 0, 0)), 0, 115 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 132, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8911), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+116", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8912), new TimeSpan(0, 7, 0, 0, 0)), 0, 116, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 133, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8918), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@116", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8919), new TimeSpan(0, 7, 0, 0, 0)), 0, 116 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 134, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8925), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+117", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8926), new TimeSpan(0, 7, 0, 0, 0)), 0, 117, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 135, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8933), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@117", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8933), new TimeSpan(0, 7, 0, 0, 0)), 0, 117 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 136, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8940), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+118", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8940), new TimeSpan(0, 7, 0, 0, 0)), 0, 118, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 137, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8947), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@118", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8947), new TimeSpan(0, 7, 0, 0, 0)), 0, 118 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 138, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+119", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8955), new TimeSpan(0, 7, 0, 0, 0)), 0, 119, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 139, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8961), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@119", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8962), new TimeSpan(0, 7, 0, 0, 0)), 0, 119 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 140, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+120", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8969), new TimeSpan(0, 7, 0, 0, 0)), 0, 120, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 141, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8977), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@120", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8978), new TimeSpan(0, 7, 0, 0, 0)), 0, 120 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 142, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8984), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+121", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8985), new TimeSpan(0, 7, 0, 0, 0)), 0, 121, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 143, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9027), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@121", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9028), new TimeSpan(0, 7, 0, 0, 0)), 0, 121 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 144, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9037), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+122", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9038), new TimeSpan(0, 7, 0, 0, 0)), 0, 122, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 145, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9045), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@122", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9045), new TimeSpan(0, 7, 0, 0, 0)), 0, 122 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 146, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9052), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+123", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9053), new TimeSpan(0, 7, 0, 0, 0)), 0, 123, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 147, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9060), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@123", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9061), new TimeSpan(0, 7, 0, 0, 0)), 0, 123 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 148, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9068), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+124", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9068), new TimeSpan(0, 7, 0, 0, 0)), 0, 124, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 149, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9075), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@124", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9076), new TimeSpan(0, 7, 0, 0, 0)), 0, 124 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 150, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9082), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+125", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9083), new TimeSpan(0, 7, 0, 0, 0)), 0, 125, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 151, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9090), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@125", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9090), new TimeSpan(0, 7, 0, 0, 0)), 0, 125 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 152, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9097), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+126", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9097), new TimeSpan(0, 7, 0, 0, 0)), 0, 126, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 153, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9104), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@126", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9105), new TimeSpan(0, 7, 0, 0, 0)), 0, 126 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 154, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9111), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+127", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9112), new TimeSpan(0, 7, 0, 0, 0)), 0, 127, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 155, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9119), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@127", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9120), new TimeSpan(0, 7, 0, 0, 0)), 0, 127 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 156, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9126), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+128", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9127), new TimeSpan(0, 7, 0, 0, 0)), 0, 128, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 157, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9133), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@128", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9134), new TimeSpan(0, 7, 0, 0, 0)), 0, 128 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 158, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+129", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9141), new TimeSpan(0, 7, 0, 0, 0)), 0, 129, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 159, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9148), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@129", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9149), new TimeSpan(0, 7, 0, 0, 0)), 0, 129 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 160, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9156), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+130", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9157), new TimeSpan(0, 7, 0, 0, 0)), 0, 130, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 161, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9163), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@130", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9164), new TimeSpan(0, 7, 0, 0, 0)), 0, 130 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 162, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+131", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9171), new TimeSpan(0, 7, 0, 0, 0)), 0, 131, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 163, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9178), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@131", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9178), new TimeSpan(0, 7, 0, 0, 0)), 0, 131 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 164, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9185), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+132", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9186), new TimeSpan(0, 7, 0, 0, 0)), 0, 132, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 165, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9230), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@132", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9231), new TimeSpan(0, 7, 0, 0, 0)), 0, 132 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 166, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9240), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+133", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9241), new TimeSpan(0, 7, 0, 0, 0)), 0, 133, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 167, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9248), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@133", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9249), new TimeSpan(0, 7, 0, 0, 0)), 0, 133 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 168, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9255), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+134", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9256), new TimeSpan(0, 7, 0, 0, 0)), 0, 134, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 169, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9262), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@134", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9263), new TimeSpan(0, 7, 0, 0, 0)), 0, 134 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 170, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9270), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+135", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9271), new TimeSpan(0, 7, 0, 0, 0)), 0, 135, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 171, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9278), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@135", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9278), new TimeSpan(0, 7, 0, 0, 0)), 0, 135 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 172, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9285), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+136", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9285), new TimeSpan(0, 7, 0, 0, 0)), 0, 136, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 173, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9292), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@136", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9293), new TimeSpan(0, 7, 0, 0, 0)), 0, 136 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 174, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9299), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+137", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9300), new TimeSpan(0, 7, 0, 0, 0)), 0, 137, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 175, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9306), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@137", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9307), new TimeSpan(0, 7, 0, 0, 0)), 0, 137 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 176, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9313), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+138", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9314), new TimeSpan(0, 7, 0, 0, 0)), 0, 138, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 177, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@138", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9321), new TimeSpan(0, 7, 0, 0, 0)), 0, 138 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 178, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9328), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+139", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9328), new TimeSpan(0, 7, 0, 0, 0)), 0, 139, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 179, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9335), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@139", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9336), new TimeSpan(0, 7, 0, 0, 0)), 0, 139 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 180, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9343), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+140", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9343), new TimeSpan(0, 7, 0, 0, 0)), 0, 140, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 181, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9350), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@140", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9351), new TimeSpan(0, 7, 0, 0, 0)), 0, 140 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 182, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9357), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+141", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9358), new TimeSpan(0, 7, 0, 0, 0)), 0, 141, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 183, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9365), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@141", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9365), new TimeSpan(0, 7, 0, 0, 0)), 0, 141 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 184, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9372), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+142", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9373), new TimeSpan(0, 7, 0, 0, 0)), 0, 142, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 185, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@142", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9380), new TimeSpan(0, 7, 0, 0, 0)), 0, 142 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 186, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9387), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+143", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9388), new TimeSpan(0, 7, 0, 0, 0)), 0, 143, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 187, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9395), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@143", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9395), new TimeSpan(0, 7, 0, 0, 0)), 0, 143 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 188, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9454), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+144", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9455), new TimeSpan(0, 7, 0, 0, 0)), 0, 144, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 189, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9462), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@144", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9463), new TimeSpan(0, 7, 0, 0, 0)), 0, 144 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 190, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9469), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+145", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9470), new TimeSpan(0, 7, 0, 0, 0)), 0, 145, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 191, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9477), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@145", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9477), new TimeSpan(0, 7, 0, 0, 0)), 0, 145 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 192, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9484), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+146", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9485), new TimeSpan(0, 7, 0, 0, 0)), 0, 146, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 193, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9492), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@146", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9492), new TimeSpan(0, 7, 0, 0, 0)), 0, 146 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 194, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9499), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+147", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9500), new TimeSpan(0, 7, 0, 0, 0)), 0, 147, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 195, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9506), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@147", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9507), new TimeSpan(0, 7, 0, 0, 0)), 0, 147 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 196, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9514), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+148", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9514), new TimeSpan(0, 7, 0, 0, 0)), 0, 148, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 197, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9521), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@148", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9522), new TimeSpan(0, 7, 0, 0, 0)), 0, 148 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 198, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9528), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+149", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9529), new TimeSpan(0, 7, 0, 0, 0)), 0, 149, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 199, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9536), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@149", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9537), new TimeSpan(0, 7, 0, 0, 0)), 0, 149 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 200, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9544), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+150", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9544), new TimeSpan(0, 7, 0, 0, 0)), 0, 150, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 201, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9551), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@150", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9552), new TimeSpan(0, 7, 0, 0, 0)), 0, 150 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 202, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9559), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+151", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9559), new TimeSpan(0, 7, 0, 0, 0)), 0, 151, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 203, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9566), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@151", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9567), new TimeSpan(0, 7, 0, 0, 0)), 0, 151 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 204, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9573), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+152", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9574), new TimeSpan(0, 7, 0, 0, 0)), 0, 152, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 205, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9619), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@152", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9620), new TimeSpan(0, 7, 0, 0, 0)), 0, 152 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 206, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9627), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+153", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9628), new TimeSpan(0, 7, 0, 0, 0)), 0, 153, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 207, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@153", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9636), new TimeSpan(0, 7, 0, 0, 0)), 0, 153 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 208, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9643), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+154", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9643), new TimeSpan(0, 7, 0, 0, 0)), 0, 154, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 209, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@154", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9651), new TimeSpan(0, 7, 0, 0, 0)), 0, 154 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 210, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9658), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+155", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9658), new TimeSpan(0, 7, 0, 0, 0)), 0, 155, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 211, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9665), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@155", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9666), new TimeSpan(0, 7, 0, 0, 0)), 0, 155 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 212, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9673), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+156", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9674), new TimeSpan(0, 7, 0, 0, 0)), 0, 156, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 213, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@156", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9681), new TimeSpan(0, 7, 0, 0, 0)), 0, 156 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 214, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+157", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9688), new TimeSpan(0, 7, 0, 0, 0)), 0, 157, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 215, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9695), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@157", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9696), new TimeSpan(0, 7, 0, 0, 0)), 0, 157 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 216, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9703), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+158", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9703), new TimeSpan(0, 7, 0, 0, 0)), 0, 158, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 217, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9710), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@158", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9710), new TimeSpan(0, 7, 0, 0, 0)), 0, 158 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 218, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9717), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+159", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9718), new TimeSpan(0, 7, 0, 0, 0)), 0, 159, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 219, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9725), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@159", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9726), new TimeSpan(0, 7, 0, 0, 0)), 0, 159 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 220, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9733), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+160", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9733), new TimeSpan(0, 7, 0, 0, 0)), 0, 160, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 221, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9740), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@160", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9740), new TimeSpan(0, 7, 0, 0, 0)), 0, 160 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 222, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9747), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+161", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9748), new TimeSpan(0, 7, 0, 0, 0)), 0, 161, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 223, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9754), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@161", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9755), new TimeSpan(0, 7, 0, 0, 0)), 0, 161 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 224, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+162", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9762), new TimeSpan(0, 7, 0, 0, 0)), 0, 162, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 225, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@162", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9770), new TimeSpan(0, 7, 0, 0, 0)), 0, 162 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 226, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9799), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+163", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9799), new TimeSpan(0, 7, 0, 0, 0)), 0, 163, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 227, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9808), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@163", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9808), new TimeSpan(0, 7, 0, 0, 0)), 0, 163 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 228, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9815), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+164", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9816), new TimeSpan(0, 7, 0, 0, 0)), 0, 164, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 229, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9823), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@164", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9823), new TimeSpan(0, 7, 0, 0, 0)), 0, 164 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 230, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9830), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+165", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9831), new TimeSpan(0, 7, 0, 0, 0)), 0, 165, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 231, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9838), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@165", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9838), new TimeSpan(0, 7, 0, 0, 0)), 0, 165 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 232, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9846), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+166", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9846), new TimeSpan(0, 7, 0, 0, 0)), 0, 166, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 233, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9853), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@166", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9854), new TimeSpan(0, 7, 0, 0, 0)), 0, 166 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 234, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9861), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+167", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9861), new TimeSpan(0, 7, 0, 0, 0)), 0, 167, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 235, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9868), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@167", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9869), new TimeSpan(0, 7, 0, 0, 0)), 0, 167 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 236, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9875), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+168", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9876), new TimeSpan(0, 7, 0, 0, 0)), 0, 168, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 237, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9883), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@168", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9883), new TimeSpan(0, 7, 0, 0, 0)), 0, 168 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 238, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9890), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+169", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9891), new TimeSpan(0, 7, 0, 0, 0)), 0, 169, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 239, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9897), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@169", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9898), new TimeSpan(0, 7, 0, 0, 0)), 0, 169 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 240, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+170", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9906), new TimeSpan(0, 7, 0, 0, 0)), 0, 170, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 241, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9913), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@170", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9914), new TimeSpan(0, 7, 0, 0, 0)), 0, 170 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 242, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9920), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+171", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9921), new TimeSpan(0, 7, 0, 0, 0)), 0, 171, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 243, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9928), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@171", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9929), new TimeSpan(0, 7, 0, 0, 0)), 0, 171 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 244, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9935), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+172", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9936), new TimeSpan(0, 7, 0, 0, 0)), 0, 172, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 245, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9943), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@172", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9943), new TimeSpan(0, 7, 0, 0, 0)), 0, 172 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 246, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9950), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+173", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9951), new TimeSpan(0, 7, 0, 0, 0)), 0, 173, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 247, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9957), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@173", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9958), new TimeSpan(0, 7, 0, 0, 0)), 0, 173 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 248, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9964), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+174", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9965), new TimeSpan(0, 7, 0, 0, 0)), 0, 174, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 249, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9994), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@174", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(9995), new TimeSpan(0, 7, 0, 0, 0)), 0, 174 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 250, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+175", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2), new TimeSpan(0, 7, 0, 0, 0)), 0, 175, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 251, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(9), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@175", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(10), new TimeSpan(0, 7, 0, 0, 0)), 0, 175 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 252, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(17), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+176", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(17), new TimeSpan(0, 7, 0, 0, 0)), 0, 176, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 253, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(24), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@176", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(25), new TimeSpan(0, 7, 0, 0, 0)), 0, 176 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 254, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(32), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+177", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(32), new TimeSpan(0, 7, 0, 0, 0)), 0, 177, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 255, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(39), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@177", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(40), new TimeSpan(0, 7, 0, 0, 0)), 0, 177 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 256, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(46), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+178", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(47), new TimeSpan(0, 7, 0, 0, 0)), 0, 178, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 257, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(53), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@178", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(54), new TimeSpan(0, 7, 0, 0, 0)), 0, 178 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 258, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(61), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+179", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(62), new TimeSpan(0, 7, 0, 0, 0)), 0, 179, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 259, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(69), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@179", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(69), new TimeSpan(0, 7, 0, 0, 0)), 0, 179 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 260, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(76), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+180", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(77), new TimeSpan(0, 7, 0, 0, 0)), 0, 180, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 261, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(84), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@180", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(85), new TimeSpan(0, 7, 0, 0, 0)), 0, 180 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 262, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(91), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+181", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(92), new TimeSpan(0, 7, 0, 0, 0)), 0, 181, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 263, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(99), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@181", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(100), new TimeSpan(0, 7, 0, 0, 0)), 0, 181 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 264, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(107), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+182", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(107), new TimeSpan(0, 7, 0, 0, 0)), 0, 182, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 265, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(114), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@182", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(115), new TimeSpan(0, 7, 0, 0, 0)), 0, 182 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 266, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(122), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+183", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(123), new TimeSpan(0, 7, 0, 0, 0)), 0, 183, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 267, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@183", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(130), new TimeSpan(0, 7, 0, 0, 0)), 0, 183 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 268, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(137), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+184", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(137), new TimeSpan(0, 7, 0, 0, 0)), 0, 184, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 269, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@184", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(144), new TimeSpan(0, 7, 0, 0, 0)), 0, 184 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 270, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(151), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+185", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(152), new TimeSpan(0, 7, 0, 0, 0)), 0, 185, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 271, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(185), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@185", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(186), new TimeSpan(0, 7, 0, 0, 0)), 0, 185 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 272, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(194), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+186", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(194), new TimeSpan(0, 7, 0, 0, 0)), 0, 186, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 273, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(201), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@186", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(202), new TimeSpan(0, 7, 0, 0, 0)), 0, 186 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 274, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(208), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+187", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(209), new TimeSpan(0, 7, 0, 0, 0)), 0, 187, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 275, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(216), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@187", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(216), new TimeSpan(0, 7, 0, 0, 0)), 0, 187 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 276, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(224), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+188", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(224), new TimeSpan(0, 7, 0, 0, 0)), 0, 188, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 277, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(231), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@188", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(231), new TimeSpan(0, 7, 0, 0, 0)), 0, 188 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 278, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(238), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+189", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(239), new TimeSpan(0, 7, 0, 0, 0)), 0, 189, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 279, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(245), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@189", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(246), new TimeSpan(0, 7, 0, 0, 0)), 0, 189 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 280, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(253), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+190", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(253), new TimeSpan(0, 7, 0, 0, 0)), 0, 190, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 281, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(260), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@190", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(261), new TimeSpan(0, 7, 0, 0, 0)), 0, 190 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 282, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+191", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(268), new TimeSpan(0, 7, 0, 0, 0)), 0, 191, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 283, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(275), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@191", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(276), new TimeSpan(0, 7, 0, 0, 0)), 0, 191 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 284, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(282), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+192", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(283), new TimeSpan(0, 7, 0, 0, 0)), 0, 192, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 285, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(290), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@192", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(290), new TimeSpan(0, 7, 0, 0, 0)), 0, 192 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 286, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(297), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+193", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(298), new TimeSpan(0, 7, 0, 0, 0)), 0, 193, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 287, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(305), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@193", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(305), new TimeSpan(0, 7, 0, 0, 0)), 0, 193 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 288, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(312), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+194", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(313), new TimeSpan(0, 7, 0, 0, 0)), 0, 194, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 289, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(319), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@194", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(320), new TimeSpan(0, 7, 0, 0, 0)), 0, 194 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 290, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(327), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+195", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(327), new TimeSpan(0, 7, 0, 0, 0)), 0, 195, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 291, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(334), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@195", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(335), new TimeSpan(0, 7, 0, 0, 0)), 0, 195 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 292, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(342), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+196", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(342), new TimeSpan(0, 7, 0, 0, 0)), 0, 196, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 293, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(372), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@196", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(372), new TimeSpan(0, 7, 0, 0, 0)), 0, 196 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 294, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(381), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+197", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(381), new TimeSpan(0, 7, 0, 0, 0)), 0, 197, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 295, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(388), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@197", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(389), new TimeSpan(0, 7, 0, 0, 0)), 0, 197 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 296, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(395), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+198", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(396), new TimeSpan(0, 7, 0, 0, 0)), 0, 198, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 297, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(402), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@198", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(403), new TimeSpan(0, 7, 0, 0, 0)), 0, 198 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 298, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(410), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+199", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(411), new TimeSpan(0, 7, 0, 0, 0)), 0, 199, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 299, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(417), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@199", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(418), new TimeSpan(0, 7, 0, 0, 0)), 0, 199 },
                    { 400, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(425), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+400", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(426), new TimeSpan(0, 7, 0, 0, 0)), 0, 400 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 401, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(434), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@400", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(435), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 402, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(442), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+401", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(443), new TimeSpan(0, 7, 0, 0, 0)), 0, 401 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 403, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(450), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@401", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(450), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 404, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(457), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+402", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(458), new TimeSpan(0, 7, 0, 0, 0)), 0, 402 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 405, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(465), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@402", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(465), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 406, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(472), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+403", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(472), new TimeSpan(0, 7, 0, 0, 0)), 0, 403 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 407, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(479), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@403", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(480), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 408, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(486), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+404", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(487), new TimeSpan(0, 7, 0, 0, 0)), 0, 404 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 409, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(493), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@404", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(494), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 410, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(501), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+405", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(501), new TimeSpan(0, 7, 0, 0, 0)), 0, 405 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 411, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(508), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@405", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(508), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 412, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(515), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+406", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(516), new TimeSpan(0, 7, 0, 0, 0)), 0, 406 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 413, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(522), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@406", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(523), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 414, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(530), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+407", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(530), new TimeSpan(0, 7, 0, 0, 0)), 0, 407 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 415, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(562), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@407", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(563), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 416, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+408", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(573), new TimeSpan(0, 7, 0, 0, 0)), 0, 408 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 417, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(579), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@408", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(580), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 418, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+409", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(587), new TimeSpan(0, 7, 0, 0, 0)), 0, 409 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 419, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(594), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@409", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(595), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 420, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(601), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+410", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(602), new TimeSpan(0, 7, 0, 0, 0)), 0, 410 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 421, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(609), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@410", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(609), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 422, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(616), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+411", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(616), new TimeSpan(0, 7, 0, 0, 0)), 0, 411 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 423, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(624), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@411", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(624), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 424, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(631), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+412", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(632), new TimeSpan(0, 7, 0, 0, 0)), 0, 412 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 425, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(638), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@412", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(639), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 426, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(645), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+413", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(646), new TimeSpan(0, 7, 0, 0, 0)), 0, 413 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 427, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(653), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@413", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(653), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 428, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(660), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+414", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(661), new TimeSpan(0, 7, 0, 0, 0)), 0, 414 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 429, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(668), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@414", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(668), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 430, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(675), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+415", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(675), new TimeSpan(0, 7, 0, 0, 0)), 0, 415 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 431, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(682), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@415", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(683), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 432, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(689), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+416", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(690), new TimeSpan(0, 7, 0, 0, 0)), 0, 416 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 433, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(723), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@416", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(724), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 434, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(732), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+417", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(733), new TimeSpan(0, 7, 0, 0, 0)), 0, 417 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 435, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(739), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@417", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(740), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 436, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(747), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+418", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(748), new TimeSpan(0, 7, 0, 0, 0)), 0, 418 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 437, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(754), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@418", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(755), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 438, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+419", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(762), new TimeSpan(0, 7, 0, 0, 0)), 0, 419 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 439, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@419", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(770), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 440, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(776), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+420", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(777), new TimeSpan(0, 7, 0, 0, 0)), 0, 420 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 441, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(784), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@420", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(784), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 442, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(791), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+421", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(791), new TimeSpan(0, 7, 0, 0, 0)), 0, 421 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 443, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(798), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@421", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(799), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 444, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(806), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+422", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(806), new TimeSpan(0, 7, 0, 0, 0)), 0, 422 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 445, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(813), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@422", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(813), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 446, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(820), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+423", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(821), new TimeSpan(0, 7, 0, 0, 0)), 0, 423 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 447, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(827), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@423", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(828), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 448, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(872), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+424", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(872), new TimeSpan(0, 7, 0, 0, 0)), 0, 424 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 449, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(881), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@424", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(882), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 450, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(889), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+425", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(889), new TimeSpan(0, 7, 0, 0, 0)), 0, 425 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 451, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(896), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@425", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(896), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 452, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(903), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+426", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(904), new TimeSpan(0, 7, 0, 0, 0)), 0, 426 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 453, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(910), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@426", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(911), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 454, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(918), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+427", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(918), new TimeSpan(0, 7, 0, 0, 0)), 0, 427 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 455, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(925), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@427", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(926), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 456, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(933), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+428", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(933), new TimeSpan(0, 7, 0, 0, 0)), 0, 428 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 457, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(940), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@428", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(940), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 458, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(947), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+429", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(948), new TimeSpan(0, 7, 0, 0, 0)), 0, 429 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 459, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@429", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(955), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 460, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+430", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(962), new TimeSpan(0, 7, 0, 0, 0)), 0, 430 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 461, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(969), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@430", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(969), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 462, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+431", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(977), new TimeSpan(0, 7, 0, 0, 0)), 0, 431 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 463, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(983), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@431", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(984), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 464, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(990), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+432", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(991), new TimeSpan(0, 7, 0, 0, 0)), 0, 432 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 465, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@432", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(998), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 466, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1005), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+433", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1006), new TimeSpan(0, 7, 0, 0, 0)), 0, 433 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 467, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1012), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@433", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1013), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 468, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1019), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+434", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1020), new TimeSpan(0, 7, 0, 0, 0)), 0, 434 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 469, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1026), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@434", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1027), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 470, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1034), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+435", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1034), new TimeSpan(0, 7, 0, 0, 0)), 0, 435 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 471, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1073), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@435", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1074), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 472, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1081), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+436", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1082), new TimeSpan(0, 7, 0, 0, 0)), 0, 436 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 473, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1088), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@436", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1089), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 474, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1096), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+437", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1096), new TimeSpan(0, 7, 0, 0, 0)), 0, 437 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 475, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1103), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@437", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1103), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 476, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1110), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+438", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1111), new TimeSpan(0, 7, 0, 0, 0)), 0, 438 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 477, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1117), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@438", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1118), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 478, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1124), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+439", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1125), new TimeSpan(0, 7, 0, 0, 0)), 0, 439 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 479, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1132), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@439", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1132), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 480, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1139), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+440", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1140), new TimeSpan(0, 7, 0, 0, 0)), 0, 440 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 481, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1147), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@440", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1148), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 482, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1154), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+441", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1155), new TimeSpan(0, 7, 0, 0, 0)), 0, 441 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 483, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1162), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@441", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1162), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 484, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1169), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+442", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1170), new TimeSpan(0, 7, 0, 0, 0)), 0, 442 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 485, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1176), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@442", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1177), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 486, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1184), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+443", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1184), new TimeSpan(0, 7, 0, 0, 0)), 0, 443 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 487, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1191), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@443", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1192), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 488, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1199), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+444", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1200), new TimeSpan(0, 7, 0, 0, 0)), 0, 444 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 489, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1206), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@444", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1207), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 490, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1213), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+445", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1214), new TimeSpan(0, 7, 0, 0, 0)), 0, 445 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 491, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1221), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@445", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1221), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 492, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+446", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1229), new TimeSpan(0, 7, 0, 0, 0)), 0, 446 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 493, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@446", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1258), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 494, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+447", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1266), new TimeSpan(0, 7, 0, 0, 0)), 0, 447 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 495, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@447", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1274), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 496, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1280), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+448", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1281), new TimeSpan(0, 7, 0, 0, 0)), 0, 448 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 497, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1288), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@448", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1288), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 498, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1295), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+449", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1296), new TimeSpan(0, 7, 0, 0, 0)), 0, 449 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 499, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@449", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1303), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 500, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+450", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1310), new TimeSpan(0, 7, 0, 0, 0)), 0, 450 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 501, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@450", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1318), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 502, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1324), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+451", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1325), new TimeSpan(0, 7, 0, 0, 0)), 0, 451 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 503, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1332), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@451", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1332), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 504, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1339), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+452", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1340), new TimeSpan(0, 7, 0, 0, 0)), 0, 452 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 505, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1347), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@452", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1347), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 506, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+453", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1355), new TimeSpan(0, 7, 0, 0, 0)), 0, 453 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 507, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@453", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1362), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 508, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1369), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+454", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1369), new TimeSpan(0, 7, 0, 0, 0)), 0, 454 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 509, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1376), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@454", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1376), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 510, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1383), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+455", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1384), new TimeSpan(0, 7, 0, 0, 0)), 0, 455 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 511, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1391), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@455", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1392), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 512, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1398), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+456", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1399), new TimeSpan(0, 7, 0, 0, 0)), 0, 456 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 513, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1406), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@456", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1407), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 514, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1413), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+457", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1414), new TimeSpan(0, 7, 0, 0, 0)), 0, 457 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 515, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1443), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@457", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1444), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 516, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1452), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+458", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1452), new TimeSpan(0, 7, 0, 0, 0)), 0, 458 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 517, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1459), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@458", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1460), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 518, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1466), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+459", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1467), new TimeSpan(0, 7, 0, 0, 0)), 0, 459 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 519, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1474), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@459", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1474), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 520, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+460", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1482), new TimeSpan(0, 7, 0, 0, 0)), 0, 460 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 521, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1488), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@460", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1489), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 522, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1496), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+461", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1496), new TimeSpan(0, 7, 0, 0, 0)), 0, 461 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 523, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1503), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@461", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1503), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 524, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+462", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1511), new TimeSpan(0, 7, 0, 0, 0)), 0, 462 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 525, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@462", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1518), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 526, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1525), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+463", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1525), new TimeSpan(0, 7, 0, 0, 0)), 0, 463 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 527, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1532), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@463", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1532), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 528, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1539), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+464", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1540), new TimeSpan(0, 7, 0, 0, 0)), 0, 464 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 529, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1546), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@464", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1547), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 530, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1554), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+465", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1554), new TimeSpan(0, 7, 0, 0, 0)), 0, 465 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 531, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1561), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@465", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1561), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 532, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1568), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+466", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1569), new TimeSpan(0, 7, 0, 0, 0)), 0, 466 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 533, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1576), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@466", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1577), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 534, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1583), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+467", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1584), new TimeSpan(0, 7, 0, 0, 0)), 0, 467 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 535, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1590), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@467", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1591), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 536, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1598), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+468", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1598), new TimeSpan(0, 7, 0, 0, 0)), 0, 468 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 537, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1655), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@468", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1656), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 538, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1665), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+469", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1666), new TimeSpan(0, 7, 0, 0, 0)), 0, 469 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 539, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1673), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@469", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1674), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 540, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+470", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1681), new TimeSpan(0, 7, 0, 0, 0)), 0, 470 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 541, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@470", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1688), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 542, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1695), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+471", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1696), new TimeSpan(0, 7, 0, 0, 0)), 0, 471 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 543, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1703), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@471", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1703), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 544, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1710), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+472", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1711), new TimeSpan(0, 7, 0, 0, 0)), 0, 472 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 545, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1717), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@472", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1718), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 546, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1725), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+473", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1725), new TimeSpan(0, 7, 0, 0, 0)), 0, 473 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 547, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1732), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@473", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1732), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 548, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1739), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+474", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1740), new TimeSpan(0, 7, 0, 0, 0)), 0, 474 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 549, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1747), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@474", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1748), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 550, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1754), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+475", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1755), new TimeSpan(0, 7, 0, 0, 0)), 0, 475 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 551, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1761), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@475", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1762), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 552, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+476", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1770), new TimeSpan(0, 7, 0, 0, 0)), 0, 476 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 553, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1776), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@476", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1777), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 554, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1784), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+477", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1784), new TimeSpan(0, 7, 0, 0, 0)), 0, 477 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 555, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1791), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@477", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1792), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 556, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1798), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+478", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1799), new TimeSpan(0, 7, 0, 0, 0)), 0, 478 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 557, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1805), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@478", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1806), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 558, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1813), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+479", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1814), new TimeSpan(0, 7, 0, 0, 0)), 0, 479 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 559, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1854), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@479", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1855), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 560, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1864), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+480", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1864), new TimeSpan(0, 7, 0, 0, 0)), 0, 480 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 561, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@480", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1872), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 562, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+481", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1880), new TimeSpan(0, 7, 0, 0, 0)), 0, 481 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 563, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1887), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@481", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1887), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 564, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1894), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+482", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1895), new TimeSpan(0, 7, 0, 0, 0)), 0, 482 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 565, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1902), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@482", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1902), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 566, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1909), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+483", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1910), new TimeSpan(0, 7, 0, 0, 0)), 0, 483 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 567, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1917), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@483", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1917), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 568, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1924), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+484", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1925), new TimeSpan(0, 7, 0, 0, 0)), 0, 484 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 569, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1931), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@484", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1932), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 570, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1938), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+485", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1939), new TimeSpan(0, 7, 0, 0, 0)), 0, 485 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 571, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1946), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@485", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1947), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 572, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+486", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1954), new TimeSpan(0, 7, 0, 0, 0)), 0, 486 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 573, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1961), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@486", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1962), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 574, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+487", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1969), new TimeSpan(0, 7, 0, 0, 0)), 0, 487 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 575, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@487", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1976), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 576, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1983), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+488", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1984), new TimeSpan(0, 7, 0, 0, 0)), 0, 488 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 577, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1990), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@488", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1991), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 578, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+489", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(1998), new TimeSpan(0, 7, 0, 0, 0)), 0, 489 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 579, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2005), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@489", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2006), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 580, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2013), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+490", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2013), new TimeSpan(0, 7, 0, 0, 0)), 0, 490 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 581, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2044), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@490", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2044), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 582, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2053), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+491", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2053), new TimeSpan(0, 7, 0, 0, 0)), 0, 491 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 583, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2060), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@491", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2061), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 584, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2068), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+492", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2068), new TimeSpan(0, 7, 0, 0, 0)), 0, 492 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 585, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2075), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@492", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2076), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 586, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2083), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+493", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2083), new TimeSpan(0, 7, 0, 0, 0)), 0, 493 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 587, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2090), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@493", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2091), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 588, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2097), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+494", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2098), new TimeSpan(0, 7, 0, 0, 0)), 0, 494 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 589, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2105), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@494", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2105), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 590, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2112), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+495", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2113), new TimeSpan(0, 7, 0, 0, 0)), 0, 495 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 591, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2119), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@495", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2120), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 592, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2127), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+496", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2127), new TimeSpan(0, 7, 0, 0, 0)), 0, 496 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 593, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2134), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@496", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2135), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 594, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+497", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2142), new TimeSpan(0, 7, 0, 0, 0)), 0, 497 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 595, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2149), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@497", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2149), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 596, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2156), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+498", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2157), new TimeSpan(0, 7, 0, 0, 0)), 0, 498 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 597, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2163), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@498", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2164), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 598, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2171), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+499", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2171), new TimeSpan(0, 7, 0, 0, 0)), 0, 499 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 599, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2178), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@499", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2178), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, true });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "title", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2908), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, "What is Lorem Ipsum?", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2909), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2913), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, "Why do we use it?", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2913), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2914), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, "Where does it come from?", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2915), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2916), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, "Where can I get some?", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2917), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2981), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2982), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2987), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2987), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2989), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2989), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2399), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2400), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2417), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2417), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2434), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2435), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2200), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2201), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2212), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2268), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2268), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trip_rate", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "rating", "status", "suddenly_cancelled_trips", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 0.0, new Guid("babaa793-2548-4f7c-ada9-f185b3ca1034"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, 1, "Quach Dai Loi", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5267), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 0.0, new Guid("8aa50cb9-b4dd-47ec-8239-3e6e887ab250"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5282), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, 1, "Do Trong Dat", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5283), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 0.0, new Guid("9fa49c8e-8183-4d9a-97f1-7c6eae1d6b97"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5294), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 3, 1, "Nguyen Dang Khoa", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5294), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 0.0, new Guid("e44617a4-f4d3-4020-9690-62524d7f8a0e"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5307), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 4, 1, "Than Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5307), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 0.0, new Guid("84ca04af-fa9b-41cf-ba7f-e4443e440f64"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 5, 1, "Loi Quach", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5346), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 0.0, new Guid("296ea123-1252-4f7a-a0a3-b72836780684"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5360), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 6, 1, "Dat Do", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5361), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 0.0, new Guid("c7fc1da6-61d4-4a5f-bca3-a823a10fbdc2"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5372), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 7, 1, "Khoa Nguyen", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5373), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 0.0, new Guid("f4f24c63-0751-4bc0-bb23-ee241ee2ae80"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5386), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 8, 1, "Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5387), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 0.0, new Guid("49917f4e-a0cb-4ac2-a993-bb200bcdf0bb"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 13, 1, "Admin Quach Dai Loi", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(5398), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 400, new Guid("8ecb33cf-3c24-4afa-b434-8691028f170a"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3164), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.400", "Vehicle 400", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3164), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, 2 },
                    { 401, new Guid("e996e015-26cd-40b5-8338-eb6df4bbcc0a"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.401", "Vehicle 401", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3174), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, 2 },
                    { 402, new Guid("e773e494-f8c5-4659-a528-479f86f8ffe5"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3177), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.402", "Vehicle 402", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3177), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, 2 },
                    { 403, new Guid("27ad55e1-c368-4d73-9c97-ed90b9630f6b"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3208), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.403", "Vehicle 403", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3209), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, 2 },
                    { 404, new Guid("a4f039b8-5b7b-4886-848a-6243a4bef158"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.404", "Vehicle 404", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3213), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, 2 },
                    { 405, new Guid("c2af6692-4f72-40c9-a905-f2c1cb4b021e"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.405", "Vehicle 405", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3219), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, 2 },
                    { 406, new Guid("73e8cfbb-0a09-4857-a72a-371811424c5d"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3222), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.406", "Vehicle 406", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3222), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, 2 },
                    { 407, new Guid("9613fd1c-af10-40f7-9a4d-d59544068b53"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3225), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.407", "Vehicle 407", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3225), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, 2 },
                    { 408, new Guid("983b6510-236d-4ca8-88d9-04d0fb496ff7"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.408", "Vehicle 408", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3229), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, 2 },
                    { 409, new Guid("b6be5d72-02c7-4bb7-8437-2e176d112c80"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3231), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.409", "Vehicle 409", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3232), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, 2 },
                    { 410, new Guid("bebd450c-f5ec-45ff-87e1-bd4f96df0369"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3235), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.410", "Vehicle 410", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3235), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, 2 },
                    { 411, new Guid("6fd6e56d-3b1f-4288-be66-ab3966c70e43"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3238), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.411", "Vehicle 411", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3239), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, 2 },
                    { 412, new Guid("598518d5-b836-40db-8e27-fcd08041eb24"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3241), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.412", "Vehicle 412", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3242), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, 2 },
                    { 413, new Guid("38ab33c8-eadb-47e0-9bbb-85bab4b067cf"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3247), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.413", "Vehicle 413", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3247), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, 2 },
                    { 414, new Guid("e8bcd2e2-e22e-48e8-8821-2bce4651fd92"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3250), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.414", "Vehicle 414", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3251), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, 2 },
                    { 415, new Guid("3613edf9-e785-42b7-bd9f-a7b74459bd7b"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3253), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.415", "Vehicle 415", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3254), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, 2 },
                    { 416, new Guid("ce6cd94d-5e72-4721-9c28-0acf943e5c28"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.416", "Vehicle 416", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3257), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, 2 },
                    { 417, new Guid("e10e6fb7-7aaf-4fb2-9f3f-fc455c58ece7"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3260), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.417", "Vehicle 417", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3260), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, 2 },
                    { 418, new Guid("f909d391-c693-4a8e-9a6a-5cd8a0dec4b1"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3263), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.418", "Vehicle 418", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3264), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, 2 },
                    { 419, new Guid("3ab18b92-5020-404c-b53b-21a1fa7b6328"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.419", "Vehicle 419", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3267), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, 2 },
                    { 420, new Guid("21541907-1438-4f73-9c99-01349bf479a8"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3270), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.420", "Vehicle 420", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3271), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, 2 },
                    { 421, new Guid("a932db1d-65cf-4fd5-8312-c8cf96cee8cf"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3275), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.421", "Vehicle 421", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3275), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, 2 },
                    { 422, new Guid("a7c32051-9721-47f6-8783-69401fc25667"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3278), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.422", "Vehicle 422", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3279), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, 2 },
                    { 423, new Guid("9f19499f-4ec0-48a4-a8c2-307671a7f234"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3281), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.423", "Vehicle 423", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3282), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, 2 },
                    { 424, new Guid("5a18cf1d-20fc-4d22-abf9-df11c3150aa6"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3284), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.424", "Vehicle 424", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3285), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, 2 },
                    { 425, new Guid("6831e7b9-fef2-4e7b-a925-24a1f625c31e"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3288), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.425", "Vehicle 425", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3288), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, 2 },
                    { 426, new Guid("c81ca54b-7f3b-4c54-a4e9-e35b8e96482c"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3291), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.426", "Vehicle 426", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3292), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, 2 },
                    { 427, new Guid("0a1e31a1-9a0e-4ff9-abf7-81980958d8d7"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3294), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.427", "Vehicle 427", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3295), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, 2 },
                    { 428, new Guid("fd86a982-c146-42ba-a9b2-8ca09848d656"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3298), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.428", "Vehicle 428", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3298), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, 2 },
                    { 429, new Guid("6f6512f9-516c-4e7b-96e0-2b63160e3ae4"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.429", "Vehicle 429", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3304), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, 2 },
                    { 430, new Guid("1d452767-ed9e-4063-a705-f7a5d2db9958"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3306), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.430", "Vehicle 430", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3307), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, 2 },
                    { 431, new Guid("4fa838cd-f836-4562-8cce-81432ccaecc0"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.431", "Vehicle 431", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3310), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, 2 },
                    { 432, new Guid("15dd0997-22d8-4527-8de4-b55eabaa6bea"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3313), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.432", "Vehicle 432", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3314), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, 2 },
                    { 433, new Guid("b0891ace-a19a-48b5-a0de-ec0008493c1b"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3337), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.433", "Vehicle 433", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3338), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, 2 },
                    { 434, new Guid("ba2e4eb0-2067-4707-b118-2854f2eaf4fc"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3341), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.434", "Vehicle 434", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3342), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, 2 },
                    { 435, new Guid("cf27437b-3a65-4048-8ef2-e968f98cbc7e"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3344), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.435", "Vehicle 435", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3345), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, 2 },
                    { 436, new Guid("cb575a45-4e5b-4254-af27-544ff91fc258"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3347), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.436", "Vehicle 436", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3348), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, 2 },
                    { 437, new Guid("67d530e7-0f24-4202-b45e-02681ed59a91"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3352), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.437", "Vehicle 437", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3353), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, 2 },
                    { 438, new Guid("727524ce-5832-4e47-a935-70dc62837dcc"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3356), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.438", "Vehicle 438", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3356), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, 2 },
                    { 439, new Guid("cb67b624-83bc-4f3c-8e43-2cc8ac6f7640"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3359), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.439", "Vehicle 439", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3359), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, 2 },
                    { 440, new Guid("b7c09af6-e287-490f-be8c-eb484de834f8"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3362), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.440", "Vehicle 440", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3363), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, 2 },
                    { 441, new Guid("e322a0f7-b82a-4668-8c90-9c002d02e610"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3365), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.441", "Vehicle 441", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3366), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, 2 },
                    { 442, new Guid("68efc4d5-c273-4c77-adc8-fc2a23f4e2a2"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3369), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.442", "Vehicle 442", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3369), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, 2 },
                    { 443, new Guid("20931190-642e-4637-9be7-2e76bd4a1395"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3372), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.443", "Vehicle 443", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3372), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, 2 },
                    { 444, new Guid("127e1ee9-c548-41b8-ba74-f087916df8c1"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3375), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.444", "Vehicle 444", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3375), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, 2 },
                    { 445, new Guid("66bae518-b860-483b-94b7-13229ed7e82c"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.445", "Vehicle 445", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3380), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, 2 },
                    { 446, new Guid("655f482d-667b-42cf-ae36-e3d57e9a4c48"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3383), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.446", "Vehicle 446", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3384), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, 2 },
                    { 447, new Guid("c938b09b-714b-423c-8541-888ddc698c46"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3386), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.447", "Vehicle 447", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3387), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, 2 },
                    { 448, new Guid("bcd59a2d-0c20-470e-946e-301aeac54cb0"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3390), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.448", "Vehicle 448", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3390), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, 2 },
                    { 449, new Guid("c81ca52f-d768-4bfd-87bb-1327d330eef8"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3393), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.449", "Vehicle 449", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3393), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, 2 },
                    { 450, new Guid("bb76a50a-075a-42d9-93e0-14e7790f0a0e"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.450", "Vehicle 450", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3397), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, 2 },
                    { 451, new Guid("38d44aa3-c780-42e0-9915-4aa106cf4166"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3400), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.451", "Vehicle 451", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3400), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, 2 },
                    { 452, new Guid("92421658-657a-44c3-b09f-db9c837074bd"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3403), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.452", "Vehicle 452", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3403), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, 2 },
                    { 453, new Guid("1b901679-4889-4cd7-9f67-c66f62acaf57"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3408), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.453", "Vehicle 453", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3408), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, 2 },
                    { 454, new Guid("c7ee7a15-dcd3-4822-ad6e-499772fecf81"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.454", "Vehicle 454", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3411), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, 2 },
                    { 455, new Guid("d91a8bd2-f11d-4315-974d-11e3728f4a83"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3414), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.455", "Vehicle 455", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3414), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, 2 },
                    { 456, new Guid("2b03ec9f-7b5d-4338-a8f9-3479456e2f8c"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3417), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.456", "Vehicle 456", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3418), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, 2 },
                    { 457, new Guid("3f8b566c-afbd-4970-9ffe-bc2a9b78e9d2"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3420), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.457", "Vehicle 457", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3421), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, 2 },
                    { 458, new Guid("df614a20-f73e-46ec-ac56-3cfe3fed415a"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3424), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.458", "Vehicle 458", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3424), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, 2 },
                    { 459, new Guid("68ae5c72-3703-467b-9ca2-445c23eb8425"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3427), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.459", "Vehicle 459", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3428), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, 2 },
                    { 460, new Guid("af62bd34-612f-4045-9dd1-b3339b625176"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3430), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.460", "Vehicle 460", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3431), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, 2 },
                    { 461, new Guid("60748768-e668-4fe8-9861-ec78553989e9"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.461", "Vehicle 461", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3436), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, 2 },
                    { 462, new Guid("da734825-4010-40f4-a828-271548181cf7"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3439), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.462", "Vehicle 462", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3440), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, 2 },
                    { 463, new Guid("1701af57-6849-4c51-ab0a-eaaa9e84c66c"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3464), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.463", "Vehicle 463", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3464), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, 2 },
                    { 464, new Guid("caef510c-beea-4b20-9c1e-e66bec64b1dc"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3467), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.464", "Vehicle 464", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3467), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, 2 },
                    { 465, new Guid("e501167e-1f77-484a-8d23-e71fd20c9713"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3470), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.465", "Vehicle 465", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3471), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, 2 },
                    { 466, new Guid("805c0a02-fd10-45b8-937b-0c7a451d84b1"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3474), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.466", "Vehicle 466", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3474), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, 2 },
                    { 467, new Guid("a918ac9a-2c4c-45f9-be67-432dbbb9d84d"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3477), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.467", "Vehicle 467", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3477), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, 2 },
                    { 468, new Guid("8d6fb8cf-632e-442e-af6e-e29edb24ab77"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3480), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.468", "Vehicle 468", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3480), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, 2 },
                    { 469, new Guid("171ad386-dc6d-4235-8bf3-6ef554ac942f"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3485), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.469", "Vehicle 469", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3485), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, 2 },
                    { 470, new Guid("1775d4c0-de52-4a27-b16a-bc34286412a4"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3488), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.470", "Vehicle 470", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3489), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, 2 },
                    { 471, new Guid("3c6138c5-5eee-4d9a-9388-6ca636eb0463"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3491), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.471", "Vehicle 471", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3492), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, 2 },
                    { 472, new Guid("003a432d-4267-4e9e-8e55-6cb4e0125367"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3495), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.472", "Vehicle 472", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3495), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, 2 },
                    { 473, new Guid("59a4c641-c695-401e-ae97-fdb52c05717a"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3498), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.473", "Vehicle 473", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3498), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, 2 },
                    { 474, new Guid("924b5193-5bf8-480a-a833-e8a2511081ea"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3501), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.474", "Vehicle 474", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3502), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, 2 },
                    { 475, new Guid("0d0a1a47-f696-48f5-bed0-037b47c3ccfe"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3505), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.475", "Vehicle 475", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3505), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, 2 },
                    { 476, new Guid("4a2392d8-fbef-4968-821b-deaa92795d77"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3508), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.476", "Vehicle 476", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3508), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, 2 },
                    { 477, new Guid("9f2dc218-f6dd-4571-af14-af359e098964"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3513), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.477", "Vehicle 477", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3513), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, 2 },
                    { 478, new Guid("567c99da-bfc4-4aca-9fce-28cc75c4c3cc"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3516), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.478", "Vehicle 478", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3516), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, 2 },
                    { 479, new Guid("3b1654ae-1eab-4186-b96b-de392b568125"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3519), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.479", "Vehicle 479", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3520), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, 2 },
                    { 480, new Guid("adc0d139-88f3-42c6-803c-5e9540d13a8f"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3522), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.480", "Vehicle 480", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3523), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, 2 },
                    { 481, new Guid("e14dba45-7754-4006-a57c-aa5d2fe6c2e9"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3526), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.481", "Vehicle 481", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3526), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, 2 },
                    { 482, new Guid("65c8db1d-4fe0-4b01-a600-5204f96c1983"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3529), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.482", "Vehicle 482", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3529), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, 2 },
                    { 483, new Guid("6731b7e3-04b9-4f5d-b163-3a7ef35b25fb"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3532), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.483", "Vehicle 483", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3533), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, 2 },
                    { 484, new Guid("eaaeaf87-1e77-492c-be5d-ac23c10ad722"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3536), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.484", "Vehicle 484", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3536), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, 2 },
                    { 485, new Guid("4a425980-e374-4ed1-bcf3-ed09bd3062e1"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.485", "Vehicle 485", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3541), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, 2 },
                    { 486, new Guid("6adaea53-f2c3-457c-b823-a9dc77cc436d"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3544), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.486", "Vehicle 486", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3544), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, 2 },
                    { 487, new Guid("c7fa5992-dfa4-47f9-9172-7b16515fda88"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3547), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.487", "Vehicle 487", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3547), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, 2 },
                    { 488, new Guid("236b754a-dcd4-439f-a9ee-93cd63d375a9"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3550), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.488", "Vehicle 488", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3551), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, 2 },
                    { 489, new Guid("acd1968d-0e5e-4b54-b7eb-851afc68341d"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3554), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.489", "Vehicle 489", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3554), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, 2 },
                    { 490, new Guid("8743b8ac-20d0-41ff-99c2-099197bcb5ae"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3557), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.490", "Vehicle 490", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3557), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, 2 },
                    { 491, new Guid("c6edf229-ddbb-4d9b-9930-8bd8dd116fb4"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3560), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.491", "Vehicle 491", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3560), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, 2 },
                    { 492, new Guid("629f072e-38be-4feb-92df-71b075d5d898"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3563), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.492", "Vehicle 492", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3564), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, 2 },
                    { 493, new Guid("a222952f-b64b-4688-b4cf-57400049d046"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3568), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.493", "Vehicle 493", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3568), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, 2 },
                    { 494, new Guid("42e42260-98a3-49c0-a80d-470a81e68639"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.494", "Vehicle 494", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3572), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, 2 },
                    { 495, new Guid("4e9ba698-cc9e-495e-84bd-14b1dad0022f"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3574), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.495", "Vehicle 495", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3575), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, 2 },
                    { 496, new Guid("adc17ad0-7e06-4962-8d41-cae38b9cedd2"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3578), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.496", "Vehicle 496", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3578), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, 2 },
                    { 497, new Guid("331191d1-70d7-46e9-b232-052bc50e8f3a"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3604), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.497", "Vehicle 497", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3605), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, 2 },
                    { 498, new Guid("f35686f2-7f87-4085-807e-ddd1e94401e4"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3608), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.498", "Vehicle 498", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3608), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, 2 },
                    { 499, new Guid("ce6024f3-a8f5-4e80-894b-4e099f236076"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3611), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.499", "Vehicle 499", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3611), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, 2 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8400), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8401), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8412), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8413), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8419), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8420), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8427), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8428), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8435), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8435), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8480), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8481), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8488), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8489), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8495), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8496), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8502), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8502), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8511), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8511), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8518), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8518), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8524), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8525), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8533), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8540), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8547), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8547), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8554), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8554), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8561), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8561), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8569), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 488, DateTimeKind.Unspecified).AddTicks(8570), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "ceiling_extra_price", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3006), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3007), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3046), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3047), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3053), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3054), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3060), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3060), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3066), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3067), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3074), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3074), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3081), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3081), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3087), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3088), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3094), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3094), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3101), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3102), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3108), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3108), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3114), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3115), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3121), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3121), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2284), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2285), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2379), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2455), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2455), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2479), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2480), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2495), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2495), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2508), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2509), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2522), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(2523), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

            migrationBuilder.InsertData(
                table: "user_licenses",
                columns: new[] { "id", "back_side_file_id", "code", "created_at", "created_by", "deleted_at", "front_side_file_id", "license_type_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 15, "0c7a7fac-7b26-43ad-816b-79634c01efd0", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(4156), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 14, 1, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(4158), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 17, "d37eb0b2-af18-45b0-8ff2-36c162102d99", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(4173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 16, 2, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(4174), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, 19, "7d0b892c-ac9d-4426-a381-13b559727ded", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(4183), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 18, 3, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(4184), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, new Guid("a6cb3562-7c06-4d15-9251-01b49ad4684c"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3150), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3150), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("81fdf0ba-e276-41a2-b79c-e9b215d3a538"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3158), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("b4af5605-442d-408c-b9d3-9e5acdb46762"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3160), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3160), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("97af4c47-df4b-4226-a7d3-cc952d45b5d6"), new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3162), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3162), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "type", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 0.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3691), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3691), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 0.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3695), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3695), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 0.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3697), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3697), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 0.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3698), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3699), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 0.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3700), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3700), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 0.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3703), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3703), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 0.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3705), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3705), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 0.0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3706), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 22, 2, 4, 9, 489, DateTimeKind.Unspecified).AddTicks(3707), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
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
