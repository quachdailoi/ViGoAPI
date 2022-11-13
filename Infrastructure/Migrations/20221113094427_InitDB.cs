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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("48522ff7-06a7-42e7-a236-5aa278be169c")),
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 282, DateTimeKind.Unspecified).AddTicks(5742), new TimeSpan(0, 7, 0, 0, 0))),
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("e531ce27-8397-4d83-91b8-56d1cf374a38")),
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
                    CompleteWithoutBooker = table.Column<bool>(type: "boolean", nullable: false),
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
                    { 1, new Guid("89fee6ba-37af-47de-805e-888948cbf681"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6770), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6771), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("ad0d674c-fca5-4ab8-bc96-ce4729006e0f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6779), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6780), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("177df994-e866-4ece-bc9c-6fa277b97cf4"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6777), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6777), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 13, "You reach the limit of permission of cannceled trip rate, you were banned now. Contact with our office for handling this problem.", 1, "You were banned!!!", 0 }
                });

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "path", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("193b83c5-8f98-4b5e-abcf-809436fdcb17"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8527), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8547), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("ab66bb65-cc76-41d9-b2e7-f4570cb70980"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8560), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8561), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("f127b569-c711-4ad5-b727-edc9bc56cd23"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8579), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8579), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("8c7b4fa3-f135-4662-bcdc-14ffeaaad46d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8588), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("949c0804-f931-4e24-a92d-75e732a19ed5"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8595), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8595), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("d43ad25d-4da0-483e-ad5b-b4fdad2af066"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8604), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8605), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("265e0a7c-df34-4dd0-a5d6-86fa3f6c9e46"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8612), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8613), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("81b124b9-81e8-4667-94f9-3b84ebf08151"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8619), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8620), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("bb0e7f26-2d60-4398-8767-17cdeb7d1ea2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8627), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8628), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("ad250326-ef09-40e3-9c9d-6a2960f84500"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8636), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8636), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("77e464dc-4191-40e0-aaab-04bae4fb9310"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8648), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("ad437802-243d-4704-bd5b-9a0aa391aa99"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8655), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8656), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("0061f100-f593-4461-99a2-f5dd1bc302db"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8663), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8663), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "pricings",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "discount", "lower_bound", "updated_at", "updated_by", "upper_bound" },
                values: new object[,]
                {
                    { 1, new Guid("ae1eb4e0-18a0-4d60-8b21-b0dd7c28552b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6896), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.0, null, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6897), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 2, new Guid("11c309fc-8586-4596-90ff-67478701ade7"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6900), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.029999999999999999, 8, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6901), new TimeSpan(0, 7, 0, 0, 0)), 0, 30 },
                    { 3, new Guid("d15a94be-488f-4b45-b4c9-95ddae6f4c77"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6903), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.050000000000000003, 31, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6904), new TimeSpan(0, 7, 0, 0, 0)), 0, 90 },
                    { 4, new Guid("5bb993c6-6eb0-4f16-9941-31f17e2588db"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.070000000000000007, 91, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6906), new TimeSpan(0, 7, 0, 0, 0)), 0, null }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5220), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5220), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5227), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5228), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5235), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5235), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 0, "AllowedMappingTimeRange", "3" },
                    { 1, "AllowedCancelTripPercent", "0.1" },
                    { 2, "TimeBeforePickingUp", "10" },
                    { 3, "TimeAfterComplete", "3" },
                    { 4, "TradeDiscount", "0.2" },
                    { 5, "DefaultPageSize", "5" },
                    { 6, "TimeRatingAfterComplete", "24" },
                    { 7, "CheckingMappingStatusTime", "8:00 PM" },
                    { 8, "NotifyTripInDayTime", "6:00 AM" },
                    { 9, "AllowedDriverCancelTripTime", "7:45 PM" },
                    { 10, "TotalTripsCalculateRating", "100" },
                    { 12, "MaxCancelledTripRate", "0.1" },
                    { 13, "NotifiedCancelledTripRate", "0.08" },
                    { 14, "TimeSpanRounded", "5" },
                    { 15, "TimeSpanBufferToCreateRoutine", "5" },
                    { 16, "TimeToCreateTomorrowRoutine", "20:00:00" },
                    { 17, "RadiusNearbyStation", "6000" },
                    { 18, "RadiusToComplete", "100" },
                    { 19, "LastDayNumberForNextMonthRoutine", "7" }
                });

            migrationBuilder.InsertData(
                table: "stations",
                columns: new[] { "id", "address", "code", "created_at", "created_by", "deleted_at", "latitude", "longitude", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("68b4f108-0fbf-4414-9b55-c00366d3dab9"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5560), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5561), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("79dc61a0-0a5d-48e6-83f9-318ccaa0d666"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5566), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5566), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2b1d2105-8194-4c83-bdb7-d6ddbe0ea234"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5569), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5569), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("77c85664-bd35-4823-bf54-cbb28889c9f2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5573), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("15402d05-7c17-40a8-b1e5-0e3d35d788fc"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5574), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5575), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bb237d6e-f165-41bb-a956-1212e7f89632"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5611), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5612), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("75ae8fb8-4f8a-43fb-87d8-46309e21a7cb"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5614), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5615), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a0657dfd-dc7b-4c5e-9dda-34f09e01d8eb"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5617), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5617), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("fb19ba48-939a-4ff7-b71d-60bfa8be04b5"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5619), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5620), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("c3e0b443-92d1-4254-9e29-4c809a1d279a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5623), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5623), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("452fdc6d-e1b1-4e6b-8b6c-94aae19a93e1"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5625), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5626), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ecd21bc2-22e5-4005-bf91-58e89204c2d5"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5627), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5628), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("928c899c-5311-4c6e-9982-4a1bfe095c04"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5630), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5630), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("40440480-1916-469d-9a92-88bbb2753999"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5634), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5634), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8b20564f-f73c-4ec4-acb7-767973e2797f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5636), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5637), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("65ee8bef-514d-4e84-843c-8cef5d91e109"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5639), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5639), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c8178fce-b557-4a60-9314-7929b77f026a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5641), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5642), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2e0c6b0c-a52d-4e64-bd6c-5ec15ac8035b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5644), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5644), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("794a6f36-a0ce-472c-a3f9-e9d7d3a67256"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5646), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5647), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a760c3a8-bcb4-4129-8ab3-112153f422fb"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5649), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5649), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dcfd01f5-3234-4b8c-9c92-1257cdd15d07"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5651), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5651), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c6e71157-3d3f-441b-a6e7-e385db3e734b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5655), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5655), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("05e50086-8d99-4acb-9be3-263fbecc5aed"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5661), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5662), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("06da02b7-06f7-4de1-8ede-2ffca3f4d7f0"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5664), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3c8a7351-2497-46da-8291-f4c0a5c88ad3"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5666), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5667), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2367d551-86e0-4065-9751-f288a723d92a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5669), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5669), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("42bc71ff-0a7c-4205-b059-2c303f0ae0af"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5672), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5672), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8948b21e-2ec8-4603-badc-42b34dc08f0f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5674), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5675), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3a8bbc9f-ccb3-42dd-909f-22e05b6445ad"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5678), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5679), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d2a917f8-df12-4fef-a113-1f49c7739337"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5681), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ae97ba5a-6e46-418c-b6ce-6e4dbac84d2d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5683), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5683), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3c22fe78-9c65-4362-a88c-9d1376da8ac2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5685), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5685), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3120051e-cace-4543-b322-91ae814e96c6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5689), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f05dd5fb-7c48-45f7-9bd2-561f807c09cf"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5691), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5691), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("19304071-4c5f-48b3-9207-59835280fa8f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5693), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5693), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1c8da11a-c460-4ec0-9b14-278324350f1e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5695), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5695), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("cdcb19b3-07d8-40e0-a0f2-2dce3cbafeaf"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5699), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5700), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("01fc5e2e-4d89-4304-8f97-9a4e1742b4a6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5701), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5702), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8543766e-59d3-4a98-8366-6237416f8ae1"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5704), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3909b0d6-d279-47b2-b278-cc023a9a9ca2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5706), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5706), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6c42cfe2-fb4f-4ab3-9a3a-0fe64b452455"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5708), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5708), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("09cc723b-f13d-42aa-8fc7-8de86758ff9f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5710), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5711), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("43ea0876-932c-4853-81a7-b7dac829c8ce"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5739), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5740), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("3f5a873c-23b1-4464-9baf-e5757b984a4b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5742), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5743), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9c3f5ff3-c05a-454d-b0a9-03f2066340aa"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5746), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5747), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("78572bd1-5499-451c-b6be-286499ba53c3"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5748), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5749), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("eb9acbb5-3932-41a4-913a-b7a0fef80aaa"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5751), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5751), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("15d79ef1-2611-4851-b239-1ef58e889b85"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5753), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5753), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f8ef57d3-e597-4943-bf5c-d7c623ba0ec4"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5756), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0f9bdf42-6e39-4457-bccc-719e1a9c20a2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5757), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5758), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a6bcb2d4-4344-418f-b1b9-38a870595110"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5760), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5761), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("60c422b3-d6ea-49e9-8449-369b0272b6e6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5763), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5763), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7794dec6-7451-47bb-b41e-037c26ca62be"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5767), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5767), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("49bbf6bf-fcff-45c5-ad52-5c8fe87b92c4"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5769), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("46fa204e-1d8c-4deb-9253-15225a85478e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5771), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5772), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e21bd242-efeb-44d6-bc82-9a0942b0410e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5773), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5774), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3a7dd76e-fd5c-4f67-be9c-0599d42b9c70"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5776), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5776), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7e92c507-3b4b-4ac4-afae-61fb3ff300ba"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5778), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5778), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fb52eca6-6b69-453b-a37f-51a79e0ae732"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5780), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5781), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5ebc38ca-50bb-402f-9f01-8f3101cefc8f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5782), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5783), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bc2c95e2-613c-4a6d-90e2-7ca1390820cd"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5786), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5787), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("506d5b6e-0b3b-460d-a588-dac6af8cc461"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5788), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5789), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("998a0a1f-7c4e-460c-84a1-fc1db781f70c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5791), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5791), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("45f47e70-2158-4078-b98b-fbc9e8bd1175"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5793), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5793), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("eed9654a-0157-4df0-afe7-c54c61dcfb61"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5796), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5797), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9b4fd539-746e-4805-9260-300f660f3c45"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5799), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5799), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("67a121c6-9fcb-43b8-805f-745906383183"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5801), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5801), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dab1a3a4-8472-41aa-b87b-7e56e76191c9"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5803), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5804), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0998f22e-251c-4633-a004-34dfb458aa64"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5807), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("094c18f9-17c8-41c9-9738-36308b25c577"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5809), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5810), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("bcdfc7ae-346c-477a-b014-346b9ecb908b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5812), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5812), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fe002316-78cf-4295-ae77-07218817c7c0"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5814), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5814), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bbdc2790-26ae-4f3b-aaab-a6106dfc0277"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5816), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5816), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("13e482f3-534d-4b75-bd03-58869daabc19"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5819), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3f5ad636-6138-495e-bb93-0dfa6da0a9cb"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5820), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5821), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d85fbffa-b044-4278-9eb7-ebbde468c5f4"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5823), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5823), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b408fdf8-6fea-4d90-8ac6-874fa5984605"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5826), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5827), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3ccb367a-24b6-40df-ab29-4160a80431b4"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5829), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5829), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2604f399-d267-487a-8bb0-cf16c1bb32de"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5831), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5831), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("9acb288c-487c-48d2-9062-9577e66ec743"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5833), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5834), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("4e8a7682-e638-4659-8de7-c48f9f7a8064"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5835), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5836), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("9c02d4c3-4d15-4bf7-852a-c9b35b8bf90d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5865), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5865), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("2f94fd96-4859-4bbd-ae4a-e72ea9f1e29d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5867), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5868), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("da450470-1368-4f74-8ecb-a37667ff04a4"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5869), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5870), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9d7716ac-43c4-49fe-b2f4-6b42c645b755"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5659), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5660), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô E2a-10 Đường, D2b Đ. D1, TP. Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam", new Guid("a37e68ab-5f13-4da5-80de-cc01f08f5133"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5873), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5874), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trip_rate", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "rating", "status", "suddenly_cancelled_trips", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 10, 0.0, new Guid("5e31cfb2-858f-4b6c-b781-df47460128be"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8791), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Than Thanh Duy", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8792), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 0.0, new Guid("2d9d2d8b-c4d5-4548-b134-e1b39498a333"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8801), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Nguyen Dang Khoa", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8801), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 0.0, new Guid("b82ce7e4-2038-4053-b904-a4ba98e92b35"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8813), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Do Trong Dat", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8813), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 100, 0.0, new Guid("b4d45838-63a1-4d0f-bc0b-10892997379b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8822), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 100", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8823), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 101, 0.0, new Guid("bcfd0fbe-8666-47b0-96e3-9355f8ea981c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8869), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 101", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8870), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 102, 0.0, new Guid("c74ed24b-fb5b-4800-8d6d-da7e9129bc84"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8884), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 102", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8885), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 103, 0.0, new Guid("df2d6b70-54be-4961-8855-865d1de2470a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8897), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 103", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8898), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 104, 0.0, new Guid("9284602d-05bb-4d69-8ba4-cde36a6ed68e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8908), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 104", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8909), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 105, 0.0, new Guid("bdf65ab7-fee0-4d08-9d83-394a86b9cf5d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8920), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 105", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8921), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 106, 0.0, new Guid("39c1744f-e123-4bde-a27f-99b21a75034b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8930), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 106", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8931), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 107, 0.0, new Guid("01045ca7-1926-4aeb-afb1-6353f7c7278d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 107", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8943), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 108, 0.0, new Guid("8818f47d-ac9b-4e06-9d57-46293698b75d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 108", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8953), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 109, 0.0, new Guid("ad73fc18-d35e-4b0a-ad86-5079db276041"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 109", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8963), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 110, 0.0, new Guid("ee777291-c20c-49e2-8515-e2555dc73f46"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 110", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8973), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 111, 0.0, new Guid("a3538ce7-e378-429a-a3c6-c13da81887b6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8984), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 111", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8985), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 112, 0.0, new Guid("a496a40f-f595-43df-ae4b-4af55dcc480c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8994), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 112", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8995), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 113, 0.0, new Guid("1da4ea8b-34d6-4328-b031-b28a84ffcfd2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9004), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 113", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9004), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 114, 0.0, new Guid("723d8a0a-0721-4d0c-9e2e-e9d584fa10aa"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9018), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 114", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9019), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 115, 0.0, new Guid("9e74e9ad-1d05-42d5-a3c3-6d4b4bbfb050"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9031), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 115", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9032), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 116, 0.0, new Guid("e9c1f14e-ea27-4175-8e92-9d9138558647"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9041), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 116", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9042), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 117, 0.0, new Guid("86d855df-7dc3-4b14-afc2-7f41b4b2d592"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9052), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 117", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9052), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 118, 0.0, new Guid("f0952070-9f37-40bd-9c5b-1686f64f54b5"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9062), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 118", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9062), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 119, 0.0, new Guid("ed190c31-f0cd-4a26-a5dd-9d064624d086"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9094), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 119", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9095), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 120, 0.0, new Guid("736f5312-20a3-4a4a-9d47-4b8e8724732f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9112), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 120", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9113), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 121, 0.0, new Guid("461e2028-1924-4c48-9f9e-af5a43703141"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9132), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 121", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9134), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 122, 0.0, new Guid("83f008ac-9e13-4758-9eec-651ccbd65037"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9151), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 122", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9152), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 123, 0.0, new Guid("096738c8-459b-4341-a356-b5330302a624"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9169), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 123", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9169), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 124, 0.0, new Guid("2111fcd5-aceb-4e88-adf2-ae5a78866950"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9180), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 124", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9180), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 125, 0.0, new Guid("240cc4ec-67e9-4301-b7d4-732aa6c7cc2b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9194), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 125", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9195), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 126, 0.0, new Guid("d73b10a8-64ed-4bff-a438-baf2603daa52"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9205), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 126", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9206), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 127, 0.0, new Guid("b4bc1483-e26d-44c3-8644-512756015897"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9217), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 127", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9218), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 128, 0.0, new Guid("37f4405d-520b-4b3b-a7dc-11004d988141"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 128", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9228), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 129, 0.0, new Guid("0ab78cd6-97c2-4913-a8fa-d0f2d6300cf1"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9238), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 129", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9238), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 130, 0.0, new Guid("af6eb085-107c-4871-a29a-ec4a3a5d4745"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9248), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 130", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9248), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 131, 0.0, new Guid("85991db1-4a0e-402c-b1de-44f766ae7cde"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9260), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 131", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9260), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 132, 0.0, new Guid("d3bd03ab-fdd9-498d-a0b3-23fc5f3292dd"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9270), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 132", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9271), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 133, 0.0, new Guid("3949daab-02a4-40c3-a8c3-e9a72223f9e2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9280), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 133", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9281), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 134, 0.0, new Guid("3f9072f9-360e-4e59-83c5-e6dcb464f55c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9290), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 134", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9291), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 135, 0.0, new Guid("b0d2619c-b3bf-44fd-8784-8c80fa58f360"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 135", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9302), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 136, 0.0, new Guid("da696f7e-e075-40de-9942-c0345a94717e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9312), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 136", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9313), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 137, 0.0, new Guid("e7d9bfdc-a282-4a8c-abee-f1cfdd9666b5"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9327), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 137", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9328), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 138, 0.0, new Guid("12404a92-a58e-471d-922d-da852e218a94"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9338), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 138", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9339), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 139, 0.0, new Guid("0f6d1e00-3d2d-4251-9f30-4de27cbaab22"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9350), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 139", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9351), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 140, 0.0, new Guid("66f8bb2b-c284-428f-9b7f-a6e17845db00"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 140", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9361), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 141, 0.0, new Guid("bc57a1cf-6993-497c-9d09-30e3cd33c462"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9371), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 141", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9371), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 142, 0.0, new Guid("0eef089e-10f3-4f75-8037-1477345f4853"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9381), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 142", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9381), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 143, 0.0, new Guid("9d5b4b8d-8a45-4db1-b67c-4db292f2cb64"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9393), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 143", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9394), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 144, 0.0, new Guid("b82d2b9c-93ff-4346-99e2-2f1f8f39cac4"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9403), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 144", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9403), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 145, 0.0, new Guid("0998b140-2b27-440d-a681-c0e73118eff8"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9413), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 145", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9413), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 146, 0.0, new Guid("83c0e293-9216-4eb8-90cc-d2435ac03d88"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 146", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9424), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 147, 0.0, new Guid("0e58be60-4b27-407c-99bb-90f460b90d5c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9435), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 147", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9436), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 148, 0.0, new Guid("6e953f1f-a982-4605-a679-24f465264671"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9445), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 148", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9446), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 149, 0.0, new Guid("e0907f2f-d87a-42af-a8ab-10611d49e386"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9463), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 149", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9464), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 150, 0.0, new Guid("00785ed0-e5a5-4d8a-9487-d5d480ba568a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9474), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 150", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9474), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 151, 0.0, new Guid("8930f52d-c707-488c-9f97-abb9353a0edc"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 151", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9487), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 152, 0.0, new Guid("d5152d99-f17b-438c-bb74-e144e61c38d3"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9496), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 152", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9497), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 153, 0.0, new Guid("0eea7d47-a6bb-453c-af1b-86f22780e20a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9508), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 153", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9509), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 154, 0.0, new Guid("820b344f-9296-43c6-a9e7-1cac99b1fea6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9519), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 154", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9519), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 155, 0.0, new Guid("bc15626a-75c8-4d27-bd69-7358cd618615"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9531), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 155", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9531), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 156, 0.0, new Guid("89306448-258e-41d3-9820-bd2b1641d2c9"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9541), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 156", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9542), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 157, 0.0, new Guid("86ec3faa-0d69-4c66-9e4d-6a45939e7440"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9551), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 157", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9552), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 158, 0.0, new Guid("c5ced65b-14ec-4397-8e2b-5eb63a3e1e0b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9561), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 158", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9562), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 159, 0.0, new Guid("c14b8423-8111-4d71-8fb6-60cf0978bb6b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9573), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 159", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9574), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 160, 0.0, new Guid("5c369f3c-4627-4c0d-93e4-6b91bcf453b9"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9589), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 160", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9589), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 161, 0.0, new Guid("fe2b0533-fd64-487f-be01-06a57e797ec6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9599), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 161", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9600), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 162, 0.0, new Guid("e21647bc-580c-40a2-9c3c-096cc46a847f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9609), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 162", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9610), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 163, 0.0, new Guid("0bd229bc-c1c9-4e4a-8278-8faa33192ecf"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9621), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 163", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9622), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 164, 0.0, new Guid("94ef5fd9-e92b-42a1-95bb-b0e741cbe19f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9631), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 164", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9631), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 165, 0.0, new Guid("e30f74ba-43e4-4bab-960f-9fd3c550913a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9641), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 165", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9641), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 166, 0.0, new Guid("f79b7af9-1335-43af-966f-397dd56733ea"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9651), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 166", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9651), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 167, 0.0, new Guid("8ac1698f-6558-43f2-a017-51d5f85a2d43"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9662), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 167", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9663), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 168, 0.0, new Guid("9340ec20-e764-4746-8d6b-7dc3416c0572"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9673), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 168", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9673), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 169, 0.0, new Guid("22faf017-a669-4c3a-b40c-cd37192d7804"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9683), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 169", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9683), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 170, 0.0, new Guid("ba125735-52bd-40b2-893e-cc2220392118"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9692), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 170", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9693), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 171, 0.0, new Guid("b6ca35f9-fb64-47dc-afe3-4f6e509768c4"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 171", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9705), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 172, 0.0, new Guid("567d1265-f290-468c-b27d-5e43b03743fc"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9719), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 172", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9720), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 173, 0.0, new Guid("590a4548-9199-44f6-a4d9-d7e95072529a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9729), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 173", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9730), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 174, 0.0, new Guid("b135e7c8-48d2-4a6a-9485-41494d21530f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9740), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 174", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9740), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 175, 0.0, new Guid("38b16c81-ee4f-4081-b4b5-5559c9a36856"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9751), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 175", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9752), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 176, 0.0, new Guid("c62e57af-d5ba-4a87-b521-99dc2517dbb3"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9761), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 176", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9762), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 177, 0.0, new Guid("d14b997e-62f1-4165-867d-9ef6cb20509c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9771), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 177", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9772), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 178, 0.0, new Guid("e5592255-2f82-4e24-b5de-db725961e80a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 178", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9781), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 179, 0.0, new Guid("a1016e33-3153-43e3-ae14-a93e7fcd1f01"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9793), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 179", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9793), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 180, 0.0, new Guid("03a441c2-5fd0-4c1c-acc8-c1c4a82f007f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9802), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 180", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9803), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 181, 0.0, new Guid("60c6b5c0-4a99-4b6d-bca0-969c1a0963e6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9812), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 181", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9813), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 182, 0.0, new Guid("19557ee9-2a35-4264-a162-eff5f6b644dd"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9822), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 182", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9823), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 183, 0.0, new Guid("41add696-d807-4940-a379-52734c00b7c5"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9834), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 183", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9834), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 184, 0.0, new Guid("f7783ed0-d4c4-4993-a53c-9c923a8fc130"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9849), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 184", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9849), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 185, 0.0, new Guid("667a2c53-19e1-43e9-ad8f-a4969d08ccf6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9859), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 185", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9859), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 186, 0.0, new Guid("c9503ed6-1799-46ff-80f9-3a405f873579"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9869), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 186", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9869), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 187, 0.0, new Guid("13f1d12b-60cc-4775-ad57-b8e21dcfa1c9"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9880), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 187", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9881), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 188, 0.0, new Guid("a4c62dd8-93c6-4b60-a728-2d563c93c0ad"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9890), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 188", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9891), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 189, 0.0, new Guid("a8e939e1-90ac-4bc1-9587-f3255950d34d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9900), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 189", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9901), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 190, 0.0, new Guid("9f99c2c8-83f4-4694-a7ba-6484dc7bba36"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9910), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 190", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9910), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 191, 0.0, new Guid("46ba78ba-d471-479c-a9c7-5656b422b425"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9922), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 191", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9923), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 192, 0.0, new Guid("ac0bb510-bac2-4ec4-8fcd-1307dd0dc068"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9932), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 192", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9932), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 193, 0.0, new Guid("b251c6a5-4de0-4520-97e3-bbc730a24e40"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 193", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9942), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 194, 0.0, new Guid("5be699ea-f60b-4a3b-8d6d-26e9e2140264"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9952), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 194", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9952), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 195, 0.0, new Guid("d6b5dd27-7d1e-44be-aee2-2a4e743aa413"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9964), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 195", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9964), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 196, 0.0, new Guid("531dde10-a02f-4f18-be37-fbd372c4680e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9980), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 196", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9980), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 197, 0.0, new Guid("067d99bf-229b-4707-8239-294d1cbfb544"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9990), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 197", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(9991), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 198, 0.0, new Guid("935ac045-9798-4a3d-9ff2-e0e2a5bd2396"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 198", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 199, 0.0, new Guid("98b6cefc-4fe8-4a36-a546-0102102dec04"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(12), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 199", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(13), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 400, 0.0, new Guid("9572569d-0275-49f1-be1a-b0f43f92da62"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(23), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 400", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(24), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 401, 0.0, new Guid("fa6c15bf-ac37-4adb-a363-860cd5d9dc65"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(35), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 401", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(36), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 402, 0.0, new Guid("d63bdc9f-88c7-4b9d-8d4a-76415b59f6d6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(46), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 402", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(46), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 403, 0.0, new Guid("f13ae3ed-bfdc-4e04-b3bf-18053eb678c9"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(57), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 403", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(58), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 404, 0.0, new Guid("7bdd55b9-f50f-4068-961a-6decf75291b2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(67), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 404", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(68), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 405, 0.0, new Guid("3cf4229a-61d9-4f19-ae2e-4d06d2778f19"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(77), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 405", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(78), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 406, 0.0, new Guid("cce1c035-de48-41cd-941a-2baaf9c10fda"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(87), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 406", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(88), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 407, 0.0, new Guid("77a54378-caf8-48b0-b4e1-5941d7ddb9ac"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(99), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 407", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(100), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 408, 0.0, new Guid("c3e166b9-0898-44d2-b210-39ed39e5b082"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(114), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 408", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(115), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 409, 0.0, new Guid("d6575ff3-75b4-46b9-ade7-8784814a5576"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(125), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 409", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(125), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 410, 0.0, new Guid("e19aaf44-9f6a-4e7d-a734-d96d83d31399"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(135), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 410", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(135), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 411, 0.0, new Guid("0fcb0ca2-39dd-4e3c-ab0c-286d1a436f0e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(147), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 411", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(147), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 412, 0.0, new Guid("28cacd13-b622-4e04-ab59-3159f702ac15"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(156), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 412", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(157), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 413, 0.0, new Guid("8e1d4dd3-571a-49b5-b5d4-86fdd7d5598b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(166), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 413", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(167), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 414, 0.0, new Guid("02790bc3-1e3e-42bc-be32-2f8cad3edbc2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(176), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 414", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(177), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 415, 0.0, new Guid("daaa3031-c184-4e74-a313-8c73c2a68971"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(188), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 415", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(189), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 416, 0.0, new Guid("a51d3dc9-e3fb-4b58-ad8f-366f263c1a14"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(198), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 416", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(199), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 417, 0.0, new Guid("d04bfb0b-bf60-4370-8c3f-dbceb07a3b96"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(215), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 417", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(215), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 418, 0.0, new Guid("cee7ce17-4235-4bcd-b717-6ca8f36fbc84"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(225), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 418", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(226), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 419, 0.0, new Guid("25dd8257-5edc-4ea6-8344-cbe6b725e580"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(238), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 419", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(238), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 420, 0.0, new Guid("faf43e66-9c7b-44ad-838e-30b8c24408ce"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(248), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 420", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(248), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 421, 0.0, new Guid("87e6a8a5-0e48-4e00-b939-c467d7e149b7"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(258), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 421", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(258), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 422, 0.0, new Guid("03125b6a-fd48-421f-9095-72d4f79a5de5"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(268), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 422", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(268), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 423, 0.0, new Guid("bfc45087-b23f-4647-a3d8-aed56f2703a9"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(279), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 423", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(280), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 424, 0.0, new Guid("59f69ba1-cb53-4c08-9fb9-bc0b165e476c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 424", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(290), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 425, 0.0, new Guid("1b9bf085-d7a5-4c96-a6d3-2749c6f22014"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(299), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 425", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(300), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 426, 0.0, new Guid("8ea80d9c-3b06-40a8-b847-829d54a847f2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(309), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 426", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(310), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 427, 0.0, new Guid("7bc0693f-6279-4989-b946-e3a81edc55c4"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 427", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(322), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 428, 0.0, new Guid("5164e702-072b-4bb1-b603-df9458afb32f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(331), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 428", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(332), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 429, 0.0, new Guid("eaeb0d0d-65db-47bd-90c0-76e08abc8d06"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(349), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 429", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(350), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 430, 0.0, new Guid("50ed4e8b-bd78-48ca-850b-b52c0ad3da82"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 430", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(360), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 431, 0.0, new Guid("cad2bc24-6672-41ac-9f43-707dac4272a9"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(371), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 431", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(372), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 432, 0.0, new Guid("51357fdf-1e1e-4e8c-b49a-86386b7cde37"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(381), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 432", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(382), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 433, 0.0, new Guid("e45f6b6a-3f28-42df-948d-defc950cb31c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(391), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 433", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(392), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 434, 0.0, new Guid("96beea17-bef1-4b3e-96f7-14e9ee9da3ad"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(401), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 434", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(402), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 435, 0.0, new Guid("21e28b21-8137-4878-89cd-68b46f755d87"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(413), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 435", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(413), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 436, 0.0, new Guid("9e808a6a-1882-46d5-bc64-c7e6b484c7d6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 436", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(423), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 437, 0.0, new Guid("31204ee8-84c7-413f-af11-4602b9db4faf"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(433), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 437", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(433), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 438, 0.0, new Guid("c08e0927-6ee6-4d92-8d73-2211610499e1"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(442), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 438", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(443), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 439, 0.0, new Guid("79923c8d-915a-4cd1-970a-9733fdb64991"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(454), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 439", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(455), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 440, 0.0, new Guid("8ddfdee8-4bdd-4794-830d-4a56f9a9d66c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(464), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 440", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(465), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 441, 0.0, new Guid("181af875-afda-45ee-be5e-dcfa053adc07"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(479), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 441", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(479), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 442, 0.0, new Guid("907cf24d-05f4-439d-8bba-c804c9fe0117"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(488), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 442", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(489), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 443, 0.0, new Guid("a7a696b5-3bc1-40a8-a700-58712d5de8bb"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(500), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 443", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(501), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 444, 0.0, new Guid("6f66d99f-f52a-4c4a-909d-1f1dab5bbf49"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 444", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(510), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 445, 0.0, new Guid("5d3bc633-94ff-456f-8d44-6202879163cf"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(520), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 445", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(520), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 446, 0.0, new Guid("f2c18cce-1948-48fe-af49-88041a08e74d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(530), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 446", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(530), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 447, 0.0, new Guid("64361490-c8bf-4cef-bda1-c6f0d17d7edd"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(541), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 447", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(542), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 448, 0.0, new Guid("4345790c-5620-41c9-91d8-416eb0db6b00"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(551), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 448", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(552), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 449, 0.0, new Guid("a8672575-b0b6-4f6e-9796-caa333745690"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(561), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 449", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(562), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 450, 0.0, new Guid("e31e26ef-68c7-4ab5-b240-7de507e263e1"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 450", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(572), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 451, 0.0, new Guid("f5da8a28-0b18-4f7d-bcf2-fc3a17631e04"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(583), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 451", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(584), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 452, 0.0, new Guid("f4505d30-6fc4-47ea-87ee-26297d68fada"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(593), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 452", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(594), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 453, 0.0, new Guid("1f5ecc94-5719-4a62-9312-d3eec2cc9d15"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(640), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 453", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(640), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 454, 0.0, new Guid("9912765d-8dcb-482a-bccd-fcc9c222b1c9"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(651), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 454", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(652), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 455, 0.0, new Guid("4e33c9e7-9be0-4d8d-a2c4-04a8791bc33a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 455", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(664), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 456, 0.0, new Guid("386e44e3-b501-4642-b0f9-34830efe8630"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(673), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 456", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(674), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 457, 0.0, new Guid("713d5a13-cc12-4d24-96c5-e122e0b41ce4"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(683), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 457", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(684), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 458, 0.0, new Guid("41e008d8-ec58-41e4-a401-5fa38fe9168b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(693), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 458", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(694), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 459, 0.0, new Guid("9865ad69-ad36-4964-b7cd-82cc197d86a4"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(705), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 459", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(705), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 460, 0.0, new Guid("81b76dc4-8107-4601-9183-8903b9c5a6b2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(714), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 460", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(715), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 461, 0.0, new Guid("85905e2e-8f89-47e9-98e9-3e6ba50e540b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(724), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 461", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(725), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 462, 0.0, new Guid("b080b4b4-f90b-4f0e-94d2-d328e0d2c4b3"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(734), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 462", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(734), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 463, 0.0, new Guid("d3242330-c5c7-42de-96cf-1258f5bc0f61"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(746), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 463", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(746), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 464, 0.0, new Guid("4dfd8507-7066-4a13-9f15-091e8fb697df"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(756), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 464", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(757), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 465, 0.0, new Guid("4b6c7057-d7aa-441c-8eff-356d8e1cba22"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(795), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 465", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(796), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 466, 0.0, new Guid("cf960bdd-45d8-44fb-93b8-bf281e69ee6c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(806), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 466", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(807), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 467, 0.0, new Guid("10e4b0df-f4dd-4bba-b20e-a58df53a093f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 467", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(819), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 468, 0.0, new Guid("00de0186-9ca7-46ba-8f2d-7e129a3e340b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(828), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 468", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(829), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 469, 0.0, new Guid("99dc91bd-4657-49ec-9514-6f9b10b95c2f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(839), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 469", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(839), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 470, 0.0, new Guid("71f7a85c-c47c-4abc-b13e-8da8fa1e26d1"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(849), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 470", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(849), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 471, 0.0, new Guid("27dc6f21-f1c4-4ac9-9de6-f9b2121993a2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(861), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 471", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(862), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 472, 0.0, new Guid("13907907-5a85-44ec-b44d-8a5f8ae61eea"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 472", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(872), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 473, 0.0, new Guid("28e55bd8-b4c8-46b2-882c-c5efeb44221b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(881), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 473", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(882), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 474, 0.0, new Guid("31118697-0371-433d-b6f6-b7a57eaecc7e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(891), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 474", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(892), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 475, 0.0, new Guid("6b745637-440f-43df-98f1-293d68193165"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(903), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 475", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(904), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 476, 0.0, new Guid("f676b63a-a9aa-4fd9-8282-c96fa97c0bd0"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(913), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 476", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(914), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 477, 0.0, new Guid("46deeb51-171f-4099-bf82-75c64c658573"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 477", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(953), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 478, 0.0, new Guid("16b593ee-788d-471a-9798-651388775eb4"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(963), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 478", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(964), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 479, 0.0, new Guid("a11d40f7-3b44-48e6-9984-cede729c4c35"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 479", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(976), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 480, 0.0, new Guid("9c9813d8-d1ae-46d4-aa5a-157d9e65d2a2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(986), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 480", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(986), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 481, 0.0, new Guid("667deef5-d58a-4e72-acb8-d80461e31a3b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(996), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 481", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(996), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 482, 0.0, new Guid("dd6ad512-80b0-42f0-9281-36c25bb5ec27"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1006), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 482", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1006), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 483, 0.0, new Guid("d4336b71-b938-4e2f-9e2c-b2038df62158"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1019), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 483", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1019), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 484, 0.0, new Guid("b98ac861-3d39-4e6f-95ef-31fb5c3d1649"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1028), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 484", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1029), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 485, 0.0, new Guid("b9de1562-36d3-4816-b594-b25080a4d3f6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1039), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 485", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1039), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 486, 0.0, new Guid("ba0d54e5-a4e7-4de2-888f-ab51238ab9a0"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1049), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 486", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1049), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 487, 0.0, new Guid("217af8c3-d449-498c-a771-853499900b34"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1061), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 487", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1061), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 488, 0.0, new Guid("9d341f22-ed71-4b4d-8aa3-62e0a850033f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1071), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 488", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1071), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 489, 0.0, new Guid("b0a5790c-95f7-492e-b023-55f359afc2dd"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1096), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 489", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1097), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 490, 0.0, new Guid("2812a2ad-0f91-4c6a-b770-fa4481e9f6d9"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1108), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 490", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1108), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 491, 0.0, new Guid("48fcfef9-b285-446f-952e-6760c6b214ad"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1120), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 491", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1120), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 492, 0.0, new Guid("40e771bf-0ec8-44c6-9cd1-bd2610cf2a0a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1130), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 492", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1130), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 493, 0.0, new Guid("78545591-36e9-468e-805a-8d16b702f265"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1140), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 493", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1140), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 494, 0.0, new Guid("850d6b97-92cd-4a35-b1b2-1d8934b23157"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1150), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 494", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1150), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 495, 0.0, new Guid("4097111d-d0bb-4f13-ba6f-e0150ab0423b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1162), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 495", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1163), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 496, 0.0, new Guid("bcaedb10-3346-4953-89d7-9d548ef79878"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1172), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 496", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1173), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 497, 0.0, new Guid("4a95c08d-f20a-442f-9804-445cdd699580"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1182), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 497", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1183), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 498, 0.0, new Guid("90f616a5-96d0-4753-892f-cff3bd3aee1e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1192), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 498", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1193), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 499, 0.0, new Guid("50aee532-8360-43f6-b8a3-535d2a93815c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1204), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 499", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1204), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "name", "slot", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("80cb6f37-c5b4-4d6f-a3c5-1a4e62e8c282"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5965), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViRide", 2, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5966), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("93e08bd4-465f-4787-9364-b6f717e30c28"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5983), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-4", 4, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5984), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("82b45b44-02d2-43f5-b00b-1a26384a981b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5993), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-7", 7, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5993), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1413), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1413), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1420), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1421), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1427), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1428), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1434), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1434), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1469), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1476), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1476), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 100, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1484), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+100", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1484), new TimeSpan(0, 7, 0, 0, 0)), 0, 100, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 101, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1496), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@100", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1497), new TimeSpan(0, 7, 0, 0, 0)), 0, 100 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 102, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1507), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+101", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1508), new TimeSpan(0, 7, 0, 0, 0)), 0, 101, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 103, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1515), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@101", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1516), new TimeSpan(0, 7, 0, 0, 0)), 0, 101 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 104, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1523), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+102", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1524), new TimeSpan(0, 7, 0, 0, 0)), 0, 102, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 105, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1532), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@102", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1532), new TimeSpan(0, 7, 0, 0, 0)), 0, 102 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 106, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1539), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+103", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1540), new TimeSpan(0, 7, 0, 0, 0)), 0, 103, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 107, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@103", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1549), new TimeSpan(0, 7, 0, 0, 0)), 0, 103 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 108, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1556), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+104", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1557), new TimeSpan(0, 7, 0, 0, 0)), 0, 104, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 109, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1566), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@104", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1566), new TimeSpan(0, 7, 0, 0, 0)), 0, 104 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 110, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1574), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+105", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1574), new TimeSpan(0, 7, 0, 0, 0)), 0, 105, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 111, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1582), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@105", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1583), new TimeSpan(0, 7, 0, 0, 0)), 0, 105 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 112, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1590), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+106", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1590), new TimeSpan(0, 7, 0, 0, 0)), 0, 106, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 113, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1598), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@106", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1599), new TimeSpan(0, 7, 0, 0, 0)), 0, 106 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 114, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1606), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+107", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1606), new TimeSpan(0, 7, 0, 0, 0)), 0, 107, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 115, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1614), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@107", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1615), new TimeSpan(0, 7, 0, 0, 0)), 0, 107 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 116, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1622), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+108", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1622), new TimeSpan(0, 7, 0, 0, 0)), 0, 108, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 117, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1630), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@108", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1630), new TimeSpan(0, 7, 0, 0, 0)), 0, 108 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 118, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1638), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+109", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1638), new TimeSpan(0, 7, 0, 0, 0)), 0, 109, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 119, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@109", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1677), new TimeSpan(0, 7, 0, 0, 0)), 0, 109 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 120, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1685), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+110", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1685), new TimeSpan(0, 7, 0, 0, 0)), 0, 110, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 121, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1693), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@110", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1694), new TimeSpan(0, 7, 0, 0, 0)), 0, 110 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 122, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1701), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+111", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1702), new TimeSpan(0, 7, 0, 0, 0)), 0, 111, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 123, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1709), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@111", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1710), new TimeSpan(0, 7, 0, 0, 0)), 0, 111 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 124, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1717), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+112", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1718), new TimeSpan(0, 7, 0, 0, 0)), 0, 112, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 125, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1725), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@112", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1726), new TimeSpan(0, 7, 0, 0, 0)), 0, 112 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 126, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1733), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+113", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1734), new TimeSpan(0, 7, 0, 0, 0)), 0, 113, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 127, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1741), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@113", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1742), new TimeSpan(0, 7, 0, 0, 0)), 0, 113 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 128, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1749), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+114", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1750), new TimeSpan(0, 7, 0, 0, 0)), 0, 114, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 129, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1758), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@114", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1758), new TimeSpan(0, 7, 0, 0, 0)), 0, 114 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 130, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1765), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+115", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1766), new TimeSpan(0, 7, 0, 0, 0)), 0, 115, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 131, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1774), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@115", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1774), new TimeSpan(0, 7, 0, 0, 0)), 0, 115 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 132, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+116", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1782), new TimeSpan(0, 7, 0, 0, 0)), 0, 116, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 133, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1790), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@116", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1790), new TimeSpan(0, 7, 0, 0, 0)), 0, 116 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 134, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1797), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+117", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1798), new TimeSpan(0, 7, 0, 0, 0)), 0, 117, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 135, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1805), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@117", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1806), new TimeSpan(0, 7, 0, 0, 0)), 0, 117 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 136, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1813), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+118", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1814), new TimeSpan(0, 7, 0, 0, 0)), 0, 118, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 137, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1821), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@118", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1822), new TimeSpan(0, 7, 0, 0, 0)), 0, 118 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 138, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1829), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+119", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1830), new TimeSpan(0, 7, 0, 0, 0)), 0, 119, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 139, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1837), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@119", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1838), new TimeSpan(0, 7, 0, 0, 0)), 0, 119 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 140, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1845), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+120", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1846), new TimeSpan(0, 7, 0, 0, 0)), 0, 120, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 141, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1885), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@120", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1886), new TimeSpan(0, 7, 0, 0, 0)), 0, 120 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 142, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+121", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1895), new TimeSpan(0, 7, 0, 0, 0)), 0, 121, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 143, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1903), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@121", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1904), new TimeSpan(0, 7, 0, 0, 0)), 0, 121 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 144, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1911), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+122", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1911), new TimeSpan(0, 7, 0, 0, 0)), 0, 122, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 145, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1919), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@122", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1920), new TimeSpan(0, 7, 0, 0, 0)), 0, 122 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 146, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1927), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+123", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1928), new TimeSpan(0, 7, 0, 0, 0)), 0, 123, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 147, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1936), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@123", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1936), new TimeSpan(0, 7, 0, 0, 0)), 0, 123 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 148, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1944), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+124", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1944), new TimeSpan(0, 7, 0, 0, 0)), 0, 124, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 149, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1952), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@124", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1953), new TimeSpan(0, 7, 0, 0, 0)), 0, 124 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 150, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1960), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+125", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1960), new TimeSpan(0, 7, 0, 0, 0)), 0, 125, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 151, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@125", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1968), new TimeSpan(0, 7, 0, 0, 0)), 0, 125 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 152, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1975), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+126", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1976), new TimeSpan(0, 7, 0, 0, 0)), 0, 126, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 153, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1984), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@126", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1984), new TimeSpan(0, 7, 0, 0, 0)), 0, 126 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 154, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1991), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+127", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1992), new TimeSpan(0, 7, 0, 0, 0)), 0, 127, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 155, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2000), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@127", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2000), new TimeSpan(0, 7, 0, 0, 0)), 0, 127 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 156, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2008), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+128", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2008), new TimeSpan(0, 7, 0, 0, 0)), 0, 128, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 157, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2016), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@128", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2016), new TimeSpan(0, 7, 0, 0, 0)), 0, 128 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 158, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2023), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+129", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2024), new TimeSpan(0, 7, 0, 0, 0)), 0, 129, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 159, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2031), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@129", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2032), new TimeSpan(0, 7, 0, 0, 0)), 0, 129 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 160, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2069), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+130", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2070), new TimeSpan(0, 7, 0, 0, 0)), 0, 130, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 161, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2080), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@130", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2080), new TimeSpan(0, 7, 0, 0, 0)), 0, 130 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 162, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2088), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+131", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2088), new TimeSpan(0, 7, 0, 0, 0)), 0, 131, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 163, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2096), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@131", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2096), new TimeSpan(0, 7, 0, 0, 0)), 0, 131 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 164, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2103), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+132", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2104), new TimeSpan(0, 7, 0, 0, 0)), 0, 132, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 165, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2111), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@132", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2112), new TimeSpan(0, 7, 0, 0, 0)), 0, 132 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 166, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2119), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+133", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2120), new TimeSpan(0, 7, 0, 0, 0)), 0, 133, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 167, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2128), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@133", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2128), new TimeSpan(0, 7, 0, 0, 0)), 0, 133 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 168, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2135), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+134", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2136), new TimeSpan(0, 7, 0, 0, 0)), 0, 134, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 169, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2143), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@134", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2144), new TimeSpan(0, 7, 0, 0, 0)), 0, 134 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 170, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2151), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+135", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2152), new TimeSpan(0, 7, 0, 0, 0)), 0, 135, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 171, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2159), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@135", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2160), new TimeSpan(0, 7, 0, 0, 0)), 0, 135 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 172, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+136", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2168), new TimeSpan(0, 7, 0, 0, 0)), 0, 136, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 173, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2175), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@136", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2176), new TimeSpan(0, 7, 0, 0, 0)), 0, 136 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 174, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2183), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+137", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2184), new TimeSpan(0, 7, 0, 0, 0)), 0, 137, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 175, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2191), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@137", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2192), new TimeSpan(0, 7, 0, 0, 0)), 0, 137 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 176, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2199), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+138", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2200), new TimeSpan(0, 7, 0, 0, 0)), 0, 138, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 177, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2207), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@138", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2208), new TimeSpan(0, 7, 0, 0, 0)), 0, 138 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 178, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2215), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+139", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2216), new TimeSpan(0, 7, 0, 0, 0)), 0, 139, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 179, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2223), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@139", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2224), new TimeSpan(0, 7, 0, 0, 0)), 0, 139 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 180, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2231), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+140", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2231), new TimeSpan(0, 7, 0, 0, 0)), 0, 140, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 181, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2239), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@140", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2239), new TimeSpan(0, 7, 0, 0, 0)), 0, 140 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 182, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2246), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+141", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2247), new TimeSpan(0, 7, 0, 0, 0)), 0, 141, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 183, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2282), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@141", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2283), new TimeSpan(0, 7, 0, 0, 0)), 0, 141 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 184, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2290), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+142", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2291), new TimeSpan(0, 7, 0, 0, 0)), 0, 142, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 185, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2298), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@142", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2299), new TimeSpan(0, 7, 0, 0, 0)), 0, 142 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 186, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2306), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+143", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2306), new TimeSpan(0, 7, 0, 0, 0)), 0, 143, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 187, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2314), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@143", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2314), new TimeSpan(0, 7, 0, 0, 0)), 0, 143 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 188, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+144", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2322), new TimeSpan(0, 7, 0, 0, 0)), 0, 144, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 189, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2329), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@144", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2330), new TimeSpan(0, 7, 0, 0, 0)), 0, 144 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 190, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2337), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+145", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2338), new TimeSpan(0, 7, 0, 0, 0)), 0, 145, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 191, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@145", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2346), new TimeSpan(0, 7, 0, 0, 0)), 0, 145 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 192, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2353), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+146", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2354), new TimeSpan(0, 7, 0, 0, 0)), 0, 146, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 193, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@146", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2362), new TimeSpan(0, 7, 0, 0, 0)), 0, 146 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 194, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2369), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+147", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2369), new TimeSpan(0, 7, 0, 0, 0)), 0, 147, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 195, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2377), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@147", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2378), new TimeSpan(0, 7, 0, 0, 0)), 0, 147 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 196, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2385), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+148", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2386), new TimeSpan(0, 7, 0, 0, 0)), 0, 148, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 197, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2393), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@148", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2394), new TimeSpan(0, 7, 0, 0, 0)), 0, 148 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 198, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2401), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+149", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2401), new TimeSpan(0, 7, 0, 0, 0)), 0, 149, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 199, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2409), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@149", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2410), new TimeSpan(0, 7, 0, 0, 0)), 0, 149 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 200, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2417), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+150", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2418), new TimeSpan(0, 7, 0, 0, 0)), 0, 150, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 201, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2425), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@150", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2426), new TimeSpan(0, 7, 0, 0, 0)), 0, 150 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 202, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2433), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+151", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2433), new TimeSpan(0, 7, 0, 0, 0)), 0, 151, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 203, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2441), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@151", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2442), new TimeSpan(0, 7, 0, 0, 0)), 0, 151 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 204, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2449), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+152", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2450), new TimeSpan(0, 7, 0, 0, 0)), 0, 152, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 205, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2485), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@152", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2485), new TimeSpan(0, 7, 0, 0, 0)), 0, 152 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 206, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2493), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+153", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2494), new TimeSpan(0, 7, 0, 0, 0)), 0, 153, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 207, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2501), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@153", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2502), new TimeSpan(0, 7, 0, 0, 0)), 0, 153 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 208, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2509), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+154", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2510), new TimeSpan(0, 7, 0, 0, 0)), 0, 154, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 209, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2518), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@154", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2518), new TimeSpan(0, 7, 0, 0, 0)), 0, 154 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 210, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2525), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+155", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2526), new TimeSpan(0, 7, 0, 0, 0)), 0, 155, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 211, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@155", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2534), new TimeSpan(0, 7, 0, 0, 0)), 0, 155 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 212, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2541), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+156", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2542), new TimeSpan(0, 7, 0, 0, 0)), 0, 156, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 213, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2549), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@156", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2550), new TimeSpan(0, 7, 0, 0, 0)), 0, 156 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 214, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2557), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+157", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2557), new TimeSpan(0, 7, 0, 0, 0)), 0, 157, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 215, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2565), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@157", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2566), new TimeSpan(0, 7, 0, 0, 0)), 0, 157 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 216, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2573), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+158", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2573), new TimeSpan(0, 7, 0, 0, 0)), 0, 158, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 217, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2581), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@158", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2582), new TimeSpan(0, 7, 0, 0, 0)), 0, 158 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 218, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2588), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+159", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2589), new TimeSpan(0, 7, 0, 0, 0)), 0, 159, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 219, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2597), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@159", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2597), new TimeSpan(0, 7, 0, 0, 0)), 0, 159 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 220, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2604), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+160", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2605), new TimeSpan(0, 7, 0, 0, 0)), 0, 160, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 221, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2639), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@160", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2640), new TimeSpan(0, 7, 0, 0, 0)), 0, 160 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 222, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2648), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+161", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2649), new TimeSpan(0, 7, 0, 0, 0)), 0, 161, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 223, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2656), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@161", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2657), new TimeSpan(0, 7, 0, 0, 0)), 0, 161 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 224, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2665), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+162", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2665), new TimeSpan(0, 7, 0, 0, 0)), 0, 162, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 225, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@162", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), 0, 162 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 226, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+163", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2681), new TimeSpan(0, 7, 0, 0, 0)), 0, 163, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 227, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@163", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2689), new TimeSpan(0, 7, 0, 0, 0)), 0, 163 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 228, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2696), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+164", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2697), new TimeSpan(0, 7, 0, 0, 0)), 0, 164, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 229, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@164", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2705), new TimeSpan(0, 7, 0, 0, 0)), 0, 164 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 230, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2712), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+165", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2712), new TimeSpan(0, 7, 0, 0, 0)), 0, 165, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 231, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2720), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@165", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2721), new TimeSpan(0, 7, 0, 0, 0)), 0, 165 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 232, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2728), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+166", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2728), new TimeSpan(0, 7, 0, 0, 0)), 0, 166, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 233, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2736), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@166", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2737), new TimeSpan(0, 7, 0, 0, 0)), 0, 166 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 234, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2744), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+167", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2744), new TimeSpan(0, 7, 0, 0, 0)), 0, 167, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 235, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2752), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@167", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2752), new TimeSpan(0, 7, 0, 0, 0)), 0, 167 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 236, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2759), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+168", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2760), new TimeSpan(0, 7, 0, 0, 0)), 0, 168, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 237, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2767), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@168", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2768), new TimeSpan(0, 7, 0, 0, 0)), 0, 168 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 238, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2775), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+169", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2776), new TimeSpan(0, 7, 0, 0, 0)), 0, 169, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 239, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2783), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@169", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2784), new TimeSpan(0, 7, 0, 0, 0)), 0, 169 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 240, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2791), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+170", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2792), new TimeSpan(0, 7, 0, 0, 0)), 0, 170, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 241, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2799), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@170", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2800), new TimeSpan(0, 7, 0, 0, 0)), 0, 170 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 242, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2807), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+171", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2807), new TimeSpan(0, 7, 0, 0, 0)), 0, 171, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 243, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2858), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@171", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2859), new TimeSpan(0, 7, 0, 0, 0)), 0, 171 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 244, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2870), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+172", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2871), new TimeSpan(0, 7, 0, 0, 0)), 0, 172, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 245, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@172", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2879), new TimeSpan(0, 7, 0, 0, 0)), 0, 172 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 246, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2887), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+173", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2887), new TimeSpan(0, 7, 0, 0, 0)), 0, 173, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 247, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@173", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2895), new TimeSpan(0, 7, 0, 0, 0)), 0, 173 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 248, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2903), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+174", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2903), new TimeSpan(0, 7, 0, 0, 0)), 0, 174, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 249, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2911), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@174", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2912), new TimeSpan(0, 7, 0, 0, 0)), 0, 174 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 250, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2919), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+175", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2919), new TimeSpan(0, 7, 0, 0, 0)), 0, 175, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 251, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2927), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@175", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2927), new TimeSpan(0, 7, 0, 0, 0)), 0, 175 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 252, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2935), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+176", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2935), new TimeSpan(0, 7, 0, 0, 0)), 0, 176, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 253, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2943), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@176", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2943), new TimeSpan(0, 7, 0, 0, 0)), 0, 176 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 254, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2951), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+177", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2951), new TimeSpan(0, 7, 0, 0, 0)), 0, 177, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 255, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@177", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2959), new TimeSpan(0, 7, 0, 0, 0)), 0, 177 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 256, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2967), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+178", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2967), new TimeSpan(0, 7, 0, 0, 0)), 0, 178, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 257, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2975), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@178", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2975), new TimeSpan(0, 7, 0, 0, 0)), 0, 178 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 258, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2983), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+179", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2983), new TimeSpan(0, 7, 0, 0, 0)), 0, 179, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 259, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2991), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@179", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2991), new TimeSpan(0, 7, 0, 0, 0)), 0, 179 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 260, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(2999), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+180", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3000), new TimeSpan(0, 7, 0, 0, 0)), 0, 180, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 261, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3007), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@180", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3008), new TimeSpan(0, 7, 0, 0, 0)), 0, 180 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 262, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3015), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+181", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3015), new TimeSpan(0, 7, 0, 0, 0)), 0, 181, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 263, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3023), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@181", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3024), new TimeSpan(0, 7, 0, 0, 0)), 0, 181 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 264, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3031), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+182", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3031), new TimeSpan(0, 7, 0, 0, 0)), 0, 182, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 265, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3039), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@182", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3040), new TimeSpan(0, 7, 0, 0, 0)), 0, 182 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 266, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3076), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+183", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3076), new TimeSpan(0, 7, 0, 0, 0)), 0, 183, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 267, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3084), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@183", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3085), new TimeSpan(0, 7, 0, 0, 0)), 0, 183 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 268, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3092), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+184", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3093), new TimeSpan(0, 7, 0, 0, 0)), 0, 184, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 269, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3100), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@184", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3101), new TimeSpan(0, 7, 0, 0, 0)), 0, 184 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 270, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3108), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+185", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3109), new TimeSpan(0, 7, 0, 0, 0)), 0, 185, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 271, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3116), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@185", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3117), new TimeSpan(0, 7, 0, 0, 0)), 0, 185 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 272, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3124), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+186", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3125), new TimeSpan(0, 7, 0, 0, 0)), 0, 186, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 273, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3132), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@186", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3133), new TimeSpan(0, 7, 0, 0, 0)), 0, 186 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 274, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3140), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+187", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3141), new TimeSpan(0, 7, 0, 0, 0)), 0, 187, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 275, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3148), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@187", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3149), new TimeSpan(0, 7, 0, 0, 0)), 0, 187 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 276, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3156), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+188", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3157), new TimeSpan(0, 7, 0, 0, 0)), 0, 188, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 277, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3164), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@188", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3165), new TimeSpan(0, 7, 0, 0, 0)), 0, 188 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 278, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3172), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+189", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3173), new TimeSpan(0, 7, 0, 0, 0)), 0, 189, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 279, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3180), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@189", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3181), new TimeSpan(0, 7, 0, 0, 0)), 0, 189 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 280, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3188), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+190", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3189), new TimeSpan(0, 7, 0, 0, 0)), 0, 190, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 281, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3196), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@190", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3197), new TimeSpan(0, 7, 0, 0, 0)), 0, 190 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 282, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3204), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+191", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3205), new TimeSpan(0, 7, 0, 0, 0)), 0, 191, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 283, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@191", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3213), new TimeSpan(0, 7, 0, 0, 0)), 0, 191 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 284, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3220), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+192", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3221), new TimeSpan(0, 7, 0, 0, 0)), 0, 192, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 285, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@192", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3229), new TimeSpan(0, 7, 0, 0, 0)), 0, 192 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 286, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3236), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+193", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3237), new TimeSpan(0, 7, 0, 0, 0)), 0, 193, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 287, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3244), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@193", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3245), new TimeSpan(0, 7, 0, 0, 0)), 0, 193 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 288, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3277), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+194", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3278), new TimeSpan(0, 7, 0, 0, 0)), 0, 194, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 289, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3286), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@194", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3287), new TimeSpan(0, 7, 0, 0, 0)), 0, 194 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 290, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3294), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+195", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3295), new TimeSpan(0, 7, 0, 0, 0)), 0, 195, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 291, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@195", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3303), new TimeSpan(0, 7, 0, 0, 0)), 0, 195 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 292, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+196", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3311), new TimeSpan(0, 7, 0, 0, 0)), 0, 196, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 293, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3318), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@196", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3319), new TimeSpan(0, 7, 0, 0, 0)), 0, 196 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 294, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3326), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+197", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3327), new TimeSpan(0, 7, 0, 0, 0)), 0, 197, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 295, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3334), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@197", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3335), new TimeSpan(0, 7, 0, 0, 0)), 0, 197 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 296, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3343), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+198", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3343), new TimeSpan(0, 7, 0, 0, 0)), 0, 198, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 297, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3351), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@198", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3351), new TimeSpan(0, 7, 0, 0, 0)), 0, 198 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 298, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3359), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+199", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3359), new TimeSpan(0, 7, 0, 0, 0)), 0, 199, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 299, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3367), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@199", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3367), new TimeSpan(0, 7, 0, 0, 0)), 0, 199 },
                    { 400, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3375), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+400", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3375), new TimeSpan(0, 7, 0, 0, 0)), 0, 400 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 401, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3383), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@400", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3384), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 402, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3392), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+401", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3393), new TimeSpan(0, 7, 0, 0, 0)), 0, 401 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 403, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3399), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@401", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3400), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 404, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3407), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+402", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3407), new TimeSpan(0, 7, 0, 0, 0)), 0, 402 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 405, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3414), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@402", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3415), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 406, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3422), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+403", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3422), new TimeSpan(0, 7, 0, 0, 0)), 0, 403 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 407, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3429), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@403", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3430), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 408, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3437), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+404", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3438), new TimeSpan(0, 7, 0, 0, 0)), 0, 404 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 409, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3444), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@404", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3445), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 410, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3479), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+405", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3480), new TimeSpan(0, 7, 0, 0, 0)), 0, 405 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 411, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3489), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@405", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3489), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 412, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3496), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+406", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3497), new TimeSpan(0, 7, 0, 0, 0)), 0, 406 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 413, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3504), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@406", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3504), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 414, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3511), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+407", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3512), new TimeSpan(0, 7, 0, 0, 0)), 0, 407 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 415, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3519), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@407", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3520), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 416, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3527), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+408", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3527), new TimeSpan(0, 7, 0, 0, 0)), 0, 408 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 417, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3534), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@408", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3535), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 418, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3542), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+409", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3543), new TimeSpan(0, 7, 0, 0, 0)), 0, 409 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 419, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3550), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@409", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3550), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 420, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3557), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+410", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3558), new TimeSpan(0, 7, 0, 0, 0)), 0, 410 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 421, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3566), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@410", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3566), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 422, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3573), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+411", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3574), new TimeSpan(0, 7, 0, 0, 0)), 0, 411 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 423, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3581), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@411", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3581), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 424, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3588), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+412", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3589), new TimeSpan(0, 7, 0, 0, 0)), 0, 412 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 425, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3596), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@412", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3597), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 426, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3604), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+413", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3604), new TimeSpan(0, 7, 0, 0, 0)), 0, 413 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 427, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3611), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@413", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3612), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 428, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3619), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+414", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3620), new TimeSpan(0, 7, 0, 0, 0)), 0, 414 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 429, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3627), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@414", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3627), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 430, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3634), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+415", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3635), new TimeSpan(0, 7, 0, 0, 0)), 0, 415 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 431, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3642), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@415", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3643), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 432, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+416", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3677), new TimeSpan(0, 7, 0, 0, 0)), 0, 416 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 433, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3687), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@416", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3687), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 434, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3695), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+417", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3695), new TimeSpan(0, 7, 0, 0, 0)), 0, 417 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 435, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3703), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@417", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3703), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 436, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3710), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+418", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3711), new TimeSpan(0, 7, 0, 0, 0)), 0, 418 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 437, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3718), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@418", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3719), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 438, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3726), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+419", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3726), new TimeSpan(0, 7, 0, 0, 0)), 0, 419 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 439, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3733), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@419", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3734), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 440, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3741), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+420", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3742), new TimeSpan(0, 7, 0, 0, 0)), 0, 420 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 441, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3749), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@420", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3750), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 442, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3757), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+421", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3757), new TimeSpan(0, 7, 0, 0, 0)), 0, 421 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 443, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3792), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@421", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3792), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 444, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3800), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+422", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3801), new TimeSpan(0, 7, 0, 0, 0)), 0, 422 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 445, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3808), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@422", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3809), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 446, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3816), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+423", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3817), new TimeSpan(0, 7, 0, 0, 0)), 0, 423 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 447, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3824), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@423", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3825), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 448, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3832), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+424", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3832), new TimeSpan(0, 7, 0, 0, 0)), 0, 424 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 449, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3840), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@424", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3840), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 450, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3848), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+425", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3848), new TimeSpan(0, 7, 0, 0, 0)), 0, 425 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 451, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3855), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@425", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3856), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 452, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3863), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+426", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3863), new TimeSpan(0, 7, 0, 0, 0)), 0, 426 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 453, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@426", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3871), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 454, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+427", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3879), new TimeSpan(0, 7, 0, 0, 0)), 0, 427 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 455, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3887), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@427", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3887), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 456, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3894), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+428", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3895), new TimeSpan(0, 7, 0, 0, 0)), 0, 428 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 457, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3902), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@428", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3903), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 458, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3910), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+429", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3910), new TimeSpan(0, 7, 0, 0, 0)), 0, 429 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 459, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3917), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@429", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3918), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 460, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3925), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+430", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3925), new TimeSpan(0, 7, 0, 0, 0)), 0, 430 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 461, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3932), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@430", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3933), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 462, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3940), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+431", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3940), new TimeSpan(0, 7, 0, 0, 0)), 0, 431 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 463, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3947), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@431", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3948), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 464, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3955), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+432", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3956), new TimeSpan(0, 7, 0, 0, 0)), 0, 432 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 465, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3989), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@432", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3990), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 466, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3999), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+433", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(3999), new TimeSpan(0, 7, 0, 0, 0)), 0, 433 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 467, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4007), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@433", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4007), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 468, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4014), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+434", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4015), new TimeSpan(0, 7, 0, 0, 0)), 0, 434 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 469, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4022), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@434", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4023), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 470, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4030), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+435", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4030), new TimeSpan(0, 7, 0, 0, 0)), 0, 435 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 471, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4038), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@435", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4038), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 472, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4045), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+436", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4046), new TimeSpan(0, 7, 0, 0, 0)), 0, 436 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 473, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4053), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@436", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4053), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 474, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4060), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+437", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4061), new TimeSpan(0, 7, 0, 0, 0)), 0, 437 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 475, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4068), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@437", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4069), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 476, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4076), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+438", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4076), new TimeSpan(0, 7, 0, 0, 0)), 0, 438 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 477, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4084), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@438", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4084), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 478, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4091), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+439", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4092), new TimeSpan(0, 7, 0, 0, 0)), 0, 439 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 479, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4099), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@439", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4100), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 480, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4107), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+440", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4107), new TimeSpan(0, 7, 0, 0, 0)), 0, 440 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 481, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4114), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@440", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4115), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 482, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4122), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+441", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4122), new TimeSpan(0, 7, 0, 0, 0)), 0, 441 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 483, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4130), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@441", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4130), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 484, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4137), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+442", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4138), new TimeSpan(0, 7, 0, 0, 0)), 0, 442 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 485, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4145), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@442", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4146), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 486, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4153), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+443", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4153), new TimeSpan(0, 7, 0, 0, 0)), 0, 443 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 487, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4160), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@443", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4161), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 488, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4194), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+444", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4195), new TimeSpan(0, 7, 0, 0, 0)), 0, 444 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 489, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4203), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@444", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4203), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 490, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4210), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+445", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4211), new TimeSpan(0, 7, 0, 0, 0)), 0, 445 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 491, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@445", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4219), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 492, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+446", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4226), new TimeSpan(0, 7, 0, 0, 0)), 0, 446 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 493, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4234), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@446", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4234), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 494, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4241), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+447", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4242), new TimeSpan(0, 7, 0, 0, 0)), 0, 447 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 495, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4249), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@447", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4249), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 496, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+448", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4257), new TimeSpan(0, 7, 0, 0, 0)), 0, 448 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 497, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4264), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@448", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4265), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 498, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4271), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+449", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4272), new TimeSpan(0, 7, 0, 0, 0)), 0, 449 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 499, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4279), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@449", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4280), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 500, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4287), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+450", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4288), new TimeSpan(0, 7, 0, 0, 0)), 0, 450 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 501, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4295), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@450", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4295), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 502, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+451", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4303), new TimeSpan(0, 7, 0, 0, 0)), 0, 451 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 503, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@451", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4310), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 504, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+452", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4318), new TimeSpan(0, 7, 0, 0, 0)), 0, 452 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 505, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4325), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@452", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4326), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 506, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4333), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+453", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4334), new TimeSpan(0, 7, 0, 0, 0)), 0, 453 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 507, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4341), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@453", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4341), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 508, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4348), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+454", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4349), new TimeSpan(0, 7, 0, 0, 0)), 0, 454 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 509, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4356), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@454", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4357), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 510, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+455", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4398), new TimeSpan(0, 7, 0, 0, 0)), 0, 455 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 511, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4406), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@455", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4406), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 512, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4413), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+456", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4414), new TimeSpan(0, 7, 0, 0, 0)), 0, 456 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 513, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4421), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@456", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4422), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 514, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4429), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+457", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4429), new TimeSpan(0, 7, 0, 0, 0)), 0, 457 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 515, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@457", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4437), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 516, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4444), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+458", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4445), new TimeSpan(0, 7, 0, 0, 0)), 0, 458 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 517, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4452), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@458", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4452), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 518, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4459), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+459", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4460), new TimeSpan(0, 7, 0, 0, 0)), 0, 459 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 519, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4467), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@459", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4467), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 520, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4475), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+460", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4475), new TimeSpan(0, 7, 0, 0, 0)), 0, 460 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 521, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4483), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@460", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4483), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 522, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4490), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+461", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4491), new TimeSpan(0, 7, 0, 0, 0)), 0, 461 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 523, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4498), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@461", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4498), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 524, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4505), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+462", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4506), new TimeSpan(0, 7, 0, 0, 0)), 0, 462 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 525, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4513), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@462", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4513), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 526, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4520), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+463", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4521), new TimeSpan(0, 7, 0, 0, 0)), 0, 463 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 527, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4528), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@463", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4529), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 528, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4536), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+464", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4537), new TimeSpan(0, 7, 0, 0, 0)), 0, 464 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 529, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4543), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@464", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4544), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 530, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4551), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+465", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4552), new TimeSpan(0, 7, 0, 0, 0)), 0, 465 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 531, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4559), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@465", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4559), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 532, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4592), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+466", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4592), new TimeSpan(0, 7, 0, 0, 0)), 0, 466 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 533, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4601), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@466", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4601), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 534, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4608), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+467", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4609), new TimeSpan(0, 7, 0, 0, 0)), 0, 467 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 535, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4616), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@467", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4617), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 536, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4624), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+468", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4624), new TimeSpan(0, 7, 0, 0, 0)), 0, 468 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 537, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4631), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@468", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4632), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 538, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4639), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+469", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4640), new TimeSpan(0, 7, 0, 0, 0)), 0, 469 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 539, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4646), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@469", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4647), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 540, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4654), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+470", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4655), new TimeSpan(0, 7, 0, 0, 0)), 0, 470 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 541, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4662), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@470", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4662), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 542, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4670), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+471", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4670), new TimeSpan(0, 7, 0, 0, 0)), 0, 471 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 543, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4677), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@471", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4678), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 544, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4685), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+472", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4686), new TimeSpan(0, 7, 0, 0, 0)), 0, 472 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 545, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4693), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@472", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4693), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 546, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4700), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+473", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4701), new TimeSpan(0, 7, 0, 0, 0)), 0, 473 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 547, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4708), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@473", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4708), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 548, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4715), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+474", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4716), new TimeSpan(0, 7, 0, 0, 0)), 0, 474 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 549, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4723), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@474", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4723), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 550, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4730), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+475", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4731), new TimeSpan(0, 7, 0, 0, 0)), 0, 475 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 551, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4738), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@475", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4738), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 552, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4746), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+476", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4746), new TimeSpan(0, 7, 0, 0, 0)), 0, 476 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 553, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4753), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@476", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4754), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 554, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4783), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+477", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4784), new TimeSpan(0, 7, 0, 0, 0)), 0, 477 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 555, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4792), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@477", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4792), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 556, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4800), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+478", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4800), new TimeSpan(0, 7, 0, 0, 0)), 0, 478 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 557, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4807), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@478", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4808), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 558, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4815), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+479", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4815), new TimeSpan(0, 7, 0, 0, 0)), 0, 479 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 559, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4822), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@479", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4823), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 560, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4830), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+480", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4831), new TimeSpan(0, 7, 0, 0, 0)), 0, 480 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 561, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4837), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@480", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4838), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 562, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4845), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+481", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4846), new TimeSpan(0, 7, 0, 0, 0)), 0, 481 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 563, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4852), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@481", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4853), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 564, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4860), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+482", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4860), new TimeSpan(0, 7, 0, 0, 0)), 0, 482 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 565, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4867), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@482", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4868), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 566, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4875), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+483", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4876), new TimeSpan(0, 7, 0, 0, 0)), 0, 483 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 567, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4882), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@483", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4883), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 568, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4890), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+484", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4891), new TimeSpan(0, 7, 0, 0, 0)), 0, 484 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 569, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4897), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@484", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4898), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 570, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+485", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4906), new TimeSpan(0, 7, 0, 0, 0)), 0, 485 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 571, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4912), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@485", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4913), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 572, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4920), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+486", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4921), new TimeSpan(0, 7, 0, 0, 0)), 0, 486 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 573, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4928), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@486", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4928), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 574, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4935), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+487", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4936), new TimeSpan(0, 7, 0, 0, 0)), 0, 487 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 575, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4943), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@487", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4943), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 576, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4977), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+488", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4977), new TimeSpan(0, 7, 0, 0, 0)), 0, 488 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 577, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4986), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@488", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4987), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 578, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4994), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+489", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(4994), new TimeSpan(0, 7, 0, 0, 0)), 0, 489 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 579, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5001), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@489", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5002), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 580, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5009), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+490", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5009), new TimeSpan(0, 7, 0, 0, 0)), 0, 490 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 581, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5016), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@490", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5017), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 582, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5024), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+491", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5024), new TimeSpan(0, 7, 0, 0, 0)), 0, 491 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 583, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5031), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@491", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5032), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 584, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5039), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+492", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5039), new TimeSpan(0, 7, 0, 0, 0)), 0, 492 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 585, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5046), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@492", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5047), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 586, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5054), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+493", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5054), new TimeSpan(0, 7, 0, 0, 0)), 0, 493 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 587, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5061), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@493", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5062), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 588, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5069), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+494", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5069), new TimeSpan(0, 7, 0, 0, 0)), 0, 494 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 589, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5076), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@494", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5077), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 590, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5084), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+495", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5084), new TimeSpan(0, 7, 0, 0, 0)), 0, 495 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 591, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5091), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@495", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5092), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 592, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5099), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+496", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5099), new TimeSpan(0, 7, 0, 0, 0)), 0, 496 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 593, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5106), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@496", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5107), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 594, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5114), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+497", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5114), new TimeSpan(0, 7, 0, 0, 0)), 0, 497 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 595, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5121), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@497", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5122), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 596, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+498", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5129), new TimeSpan(0, 7, 0, 0, 0)), 0, 498 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 597, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5137), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@498", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5137), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 598, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+499", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5145), new TimeSpan(0, 7, 0, 0, 0)), 0, 499 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 599, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5175), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@499", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5176), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, true });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "title", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5912), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, "What is Lorem Ipsum?", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5912), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5916), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, "Why do we use it?", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5917), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5918), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, "Where does it come from?", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5919), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5920), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, "Where can I get some?", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5920), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6001), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6001), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6006), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6007), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6009), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6009), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5395), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5395), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5415), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5416), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5435), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5435), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5200), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5200), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5213), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5244), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5245), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trip_rate", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "rating", "status", "suddenly_cancelled_trips", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 0.0, new Guid("02546bbf-515a-4d4e-9c6d-d9042becdbe9"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8683), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, 1, "Quach Dai Loi", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8683), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 0.0, new Guid("6f4ab8eb-1a07-4171-8c56-97273dbddd0b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8698), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, 1, "Do Trong Dat", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8699), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 0.0, new Guid("ee242ed7-2388-48f0-a7fd-016aa070231e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8714), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 3, 1, "Nguyen Dang Khoa", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8715), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 0.0, new Guid("8115e381-cc12-468d-a9b1-d49631852a89"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8728), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 4, 1, "Than Thanh Duy", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8729), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 0.0, new Guid("fdb2f767-89c7-4922-826a-3f84e7be96a5"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8738), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 5, 1, "Loi Quach", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8739), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 0.0, new Guid("ab4436dc-c4e8-45ea-9637-5b6df8311915"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8750), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 6, 1, "Dat Do", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8750), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 0.0, new Guid("e7c70e49-0a58-4514-81c8-8ee5e7774a3f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8759), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 7, 1, "Khoa Nguyen", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8760), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 0.0, new Guid("9f773e68-f28d-4bae-bf6b-411b77cdd1e1"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8771), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 8, 1, "Thanh Duy", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8772), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 0.0, new Guid("38cd6786-1c92-4650-8374-ef68e51d739a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8780), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 13, 1, "Admin Quach Dai Loi", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 293, DateTimeKind.Unspecified).AddTicks(8781), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 400, new Guid("6690b5aa-00ce-42d1-86b9-5850fb81b676"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6248), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.400", "Vehicle 400", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6248), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, 3 },
                    { 401, new Guid("f732f490-e82c-420d-bd15-6a0797ff8264"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.401", "Vehicle 401", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6257), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, 3 },
                    { 402, new Guid("7dc308fc-789a-4bae-a011-6c6ecbdf1eeb"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6261), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.402", "Vehicle 402", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6261), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, 3 },
                    { 403, new Guid("9a1892b0-f433-46a6-b0c9-66be0f061902"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6264), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.403", "Vehicle 403", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6265), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, 3 },
                    { 404, new Guid("c44e01fb-15ea-4e48-b3cb-eed1e703a3a8"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6268), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.404", "Vehicle 404", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6268), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, 3 },
                    { 405, new Guid("8fe84111-c14f-4155-a499-774448fad04b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6274), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.405", "Vehicle 405", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6274), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, 3 },
                    { 406, new Guid("586e79cc-8f1a-422e-8bac-046877520992"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6277), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.406", "Vehicle 406", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6278), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, 3 },
                    { 407, new Guid("fb703e0e-c43f-45d9-b306-eb34b4e9be8d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6281), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.407", "Vehicle 407", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6281), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, 3 },
                    { 408, new Guid("1c8efedb-08ad-4ee1-94df-98b247cfa48a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6284), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.408", "Vehicle 408", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6285), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, 3 },
                    { 409, new Guid("214f816d-725f-4e9e-9271-ea55890b283b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6288), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.409", "Vehicle 409", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6288), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, 3 },
                    { 410, new Guid("e42eb3eb-f334-4733-9155-1fc874ec19ac"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6291), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.410", "Vehicle 410", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6291), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, 3 },
                    { 411, new Guid("bae8997c-e5dd-4995-a580-fa68f0cc4b93"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6294), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.411", "Vehicle 411", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6295), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, 3 },
                    { 412, new Guid("f983d28e-63cb-4c44-8aa4-4315c40de41d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6298), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.412", "Vehicle 412", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6298), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, 3 },
                    { 413, new Guid("9bb621c0-6ef5-4b22-9346-19ebfda31764"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.413", "Vehicle 413", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6304), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, 3 },
                    { 414, new Guid("6aa4b378-8082-409b-a05f-4321023e4883"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6307), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.414", "Vehicle 414", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6307), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, 3 },
                    { 415, new Guid("afec9cba-908c-462f-ae69-8b0c0af0547b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.415", "Vehicle 415", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6311), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, 3 },
                    { 416, new Guid("5a822fb7-f591-4c2a-8b3f-a5dfac924c58"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6314), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.416", "Vehicle 416", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6314), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, 3 },
                    { 417, new Guid("613dc749-5854-442d-948d-ec01b03ddd1c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.417", "Vehicle 417", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6318), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, 3 },
                    { 418, new Guid("ad948236-5467-4165-9341-74a7f195b020"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.418", "Vehicle 418", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6321), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, 3 },
                    { 419, new Guid("8a1aba3d-19b7-4cdc-aaaa-9abeed6b4c53"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6324), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.419", "Vehicle 419", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6325), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, 3 },
                    { 420, new Guid("6b7cd4e2-c0ab-4166-b89a-38bd05255eea"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6328), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.420", "Vehicle 420", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6328), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, 3 },
                    { 421, new Guid("5a83f1f3-11d7-46de-aae9-1c10ba1b66dd"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6333), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.421", "Vehicle 421", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6333), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, 3 },
                    { 422, new Guid("8b6883a1-afea-474f-ad82-8e8b72fd3e12"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6336), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.422", "Vehicle 422", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6337), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, 3 },
                    { 423, new Guid("a6ed7d38-4800-424e-96c5-ce465fd2d855"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6340), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.423", "Vehicle 423", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6340), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, 3 },
                    { 424, new Guid("bdd98c82-3068-41a3-8991-3ddb8a612d0a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6343), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.424", "Vehicle 424", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6344), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, 3 },
                    { 425, new Guid("7c41e397-7d2a-4a4e-a0c8-28f6b878a9f9"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6347), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.425", "Vehicle 425", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6347), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, 3 },
                    { 426, new Guid("a19c6dfa-af96-4525-95a8-db1e92d64a8d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6350), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.426", "Vehicle 426", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6351), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, 3 },
                    { 427, new Guid("a3b7dd6c-f150-40ed-b55b-5b7646f900e6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6384), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.427", "Vehicle 427", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6385), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, 3 },
                    { 428, new Guid("b1d5522c-a4a7-44cd-8bed-1787886a76f2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6388), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.428", "Vehicle 428", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6388), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, 3 },
                    { 429, new Guid("55297296-3554-4e4e-8ad8-d7ddf0818cbf"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6394), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.429", "Vehicle 429", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6394), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, 3 },
                    { 430, new Guid("96671fe8-0133-4c59-9408-033c5cd57b63"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.430", "Vehicle 430", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6398), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, 3 },
                    { 431, new Guid("33e75ffd-73f1-41bf-843f-761c823a29d6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6401), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.431", "Vehicle 431", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6401), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, 3 },
                    { 432, new Guid("cb5c6abe-f0ca-43f7-902e-225b27e427a1"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.432", "Vehicle 432", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6405), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, 3 },
                    { 433, new Guid("dcb6850e-49e3-4e6e-9f70-327f6d126a88"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6408), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.433", "Vehicle 433", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6408), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, 3 },
                    { 434, new Guid("0bb88478-3a5c-414f-b6cd-85054cf41c3b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.434", "Vehicle 434", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6412), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, 3 },
                    { 435, new Guid("91493c30-cdf5-43eb-b620-7bf20122de20"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6415), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.435", "Vehicle 435", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6415), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, 3 },
                    { 436, new Guid("96ec94c7-2076-442a-bb09-99bee9fb8817"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6418), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.436", "Vehicle 436", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6419), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, 3 },
                    { 437, new Guid("5f639cb4-02c3-49a4-be3d-6a486379ee29"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.437", "Vehicle 437", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6424), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, 3 },
                    { 438, new Guid("47e1b18c-a496-473c-b975-f75d6601d4fe"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6427), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.438", "Vehicle 438", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6427), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, 3 },
                    { 439, new Guid("cfda6abf-08e3-40b6-9195-b4349e8bcab1"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6430), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.439", "Vehicle 439", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6431), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, 3 },
                    { 440, new Guid("9dad82e8-6428-444a-9424-1e0cb17edc1e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6433), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.440", "Vehicle 440", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6434), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, 3 },
                    { 441, new Guid("1c1e5a85-6a28-4451-91c9-ac6abcb1d96c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6437), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.441", "Vehicle 441", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6437), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, 3 },
                    { 442, new Guid("796f8528-eb96-4417-a7c2-64cb7ce774a6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6440), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.442", "Vehicle 442", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6441), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, 3 },
                    { 443, new Guid("fd7c1d6a-a390-48d1-8429-29f46d9b803e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6444), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.443", "Vehicle 443", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6444), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, 3 },
                    { 444, new Guid("87da5584-ce6d-4476-8cba-8fbf6f47570b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6447), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.444", "Vehicle 444", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6448), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, 3 },
                    { 445, new Guid("1c7dd89f-68ce-4c35-9531-35d8872fa49d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6452), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.445", "Vehicle 445", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6453), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, 3 },
                    { 446, new Guid("9f5c9165-ccb0-46b2-986f-59a6877ef5cf"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6456), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.446", "Vehicle 446", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6456), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, 3 },
                    { 447, new Guid("c5bd0190-5805-4ba7-bdab-b28b7380443e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6459), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.447", "Vehicle 447", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6460), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, 3 },
                    { 448, new Guid("5314a04f-ce9e-4f66-9f4e-a8d1dd4bc513"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6463), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.448", "Vehicle 448", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6463), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, 3 },
                    { 449, new Guid("a3a21eb7-059e-4959-bde2-1dff3f442957"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6466), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.449", "Vehicle 449", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6466), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, 3 },
                    { 450, new Guid("82bee720-50c1-4014-a41b-a8bc77c3e478"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6469), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.450", "Vehicle 450", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6470), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, 3 },
                    { 451, new Guid("b65d5d82-9efb-47f2-98b5-4134f60d9b94"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6473), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.451", "Vehicle 451", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6473), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, 3 },
                    { 452, new Guid("35878cfe-3a66-44e9-bc68-21ce61e2b36f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6476), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.452", "Vehicle 452", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6477), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, 3 },
                    { 453, new Guid("e9d01f5e-00dd-4fcb-85ce-d41a0c2afec9"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.453", "Vehicle 453", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6482), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, 3 },
                    { 454, new Guid("8929727b-5b3d-4023-b4aa-6cfc24e06de5"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6485), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.454", "Vehicle 454", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6485), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, 3 },
                    { 455, new Guid("025e0ebd-c818-4fae-bed5-7b3320dd1019"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6488), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.455", "Vehicle 455", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6488), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, 3 },
                    { 456, new Guid("c2e9934c-6ea7-4cd9-86f3-176182050abc"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6491), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.456", "Vehicle 456", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6492), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, 3 },
                    { 457, new Guid("cb0a765f-2c85-422a-aef1-41c1e5751751"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6495), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.457", "Vehicle 457", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6495), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, 3 },
                    { 458, new Guid("99e96a9b-d767-4244-a8ad-0c361ae54871"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6498), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.458", "Vehicle 458", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6499), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, 3 },
                    { 459, new Guid("ce9885cc-c312-4b32-b2cc-455b337ae4ab"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6528), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.459", "Vehicle 459", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6529), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, 3 },
                    { 460, new Guid("3709063f-e587-4246-aae7-5591bb3d3956"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6532), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.460", "Vehicle 460", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6533), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, 3 },
                    { 461, new Guid("40ea5c0a-00f4-4129-abbe-df7aa6e03dc0"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6538), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.461", "Vehicle 461", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6538), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, 3 },
                    { 462, new Guid("de66440e-a255-48e0-823c-a5e3ff64f6ab"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6541), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.462", "Vehicle 462", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6542), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, 3 },
                    { 463, new Guid("050fb7e1-43a0-4b90-b044-166d173fc2ee"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6545), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.463", "Vehicle 463", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6545), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, 3 },
                    { 464, new Guid("cb5f9c9e-861f-4200-bcc6-4029e7c48754"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.464", "Vehicle 464", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6549), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, 3 },
                    { 465, new Guid("23b9c9cc-bc44-479d-a868-6cfa82c5ad1f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6552), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.465", "Vehicle 465", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6552), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, 3 },
                    { 466, new Guid("64af55e0-4ccf-43cd-8249-e73570b9bcef"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6555), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.466", "Vehicle 466", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6556), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, 3 },
                    { 467, new Guid("84f170b0-89e4-4d2d-aa80-a574e96a5531"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6559), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.467", "Vehicle 467", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6559), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, 3 },
                    { 468, new Guid("ae5c26a5-6cef-4ad9-88b6-aef6bed9b0a5"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6562), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.468", "Vehicle 468", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6563), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, 3 },
                    { 469, new Guid("b8e3c817-2b18-45c9-a0ae-025375ee5ba3"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6567), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.469", "Vehicle 469", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6568), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, 3 },
                    { 470, new Guid("c462d62f-eb91-42f6-bf30-09e1c7f58c8f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.470", "Vehicle 470", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6571), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, 3 },
                    { 471, new Guid("b3db61ef-aaa6-49fb-958e-df5a1635073a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6574), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.471", "Vehicle 471", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6574), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, 3 },
                    { 472, new Guid("e3871d16-983d-4c87-97de-251b39cabb4a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6577), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.472", "Vehicle 472", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6578), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, 3 },
                    { 473, new Guid("b9374150-6483-41b5-994a-e98e6e35cd7d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6581), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.473", "Vehicle 473", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6581), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, 3 },
                    { 474, new Guid("33dde9bf-0a6c-4157-a83a-a148974b5eeb"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6584), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.474", "Vehicle 474", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6585), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, 3 },
                    { 475, new Guid("4b3cda56-2480-401f-bb6f-2223f75fd94e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6588), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.475", "Vehicle 475", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6588), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, 3 },
                    { 476, new Guid("1358e06e-2a45-4bd7-9bf2-8edf493b5177"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6591), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.476", "Vehicle 476", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6592), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, 3 },
                    { 477, new Guid("65df7f58-cb1f-40cc-9fee-26df48f58db4"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6596), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.477", "Vehicle 477", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6597), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, 3 },
                    { 478, new Guid("d81e7851-2825-45e9-a7e3-1f85e2a01b3f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6600), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.478", "Vehicle 478", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6600), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, 3 },
                    { 479, new Guid("8a14788b-cf0a-47eb-b9bf-39f1e3de5b5f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6603), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.479", "Vehicle 479", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6604), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, 3 },
                    { 480, new Guid("db752259-2b3c-49a3-a72b-762cbb745d7e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6607), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.480", "Vehicle 480", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6607), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, 3 },
                    { 481, new Guid("a7cf97a9-c0f9-4209-a96e-42808f80d911"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6610), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.481", "Vehicle 481", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6611), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, 3 },
                    { 482, new Guid("9627ab16-385f-4e52-ae67-b8b62341ab7b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6613), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.482", "Vehicle 482", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6614), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, 3 },
                    { 483, new Guid("f2106cee-dfde-45d3-9c32-c60195f23447"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6617), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.483", "Vehicle 483", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6617), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, 3 },
                    { 484, new Guid("8009b9ac-7cc7-4f80-985a-93a9b19f6390"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6620), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.484", "Vehicle 484", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6621), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, 3 },
                    { 485, new Guid("14c2ec61-2883-4220-bbfb-31dcb1ef82f1"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6625), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.485", "Vehicle 485", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6626), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, 3 },
                    { 486, new Guid("b40bffe0-e12c-410c-833b-f4339710a881"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6629), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.486", "Vehicle 486", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6629), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, 3 },
                    { 487, new Guid("7e736903-26dc-49ca-9808-97d3caa021d4"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6632), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.487", "Vehicle 487", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6633), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, 3 },
                    { 488, new Guid("a1593400-425e-43cf-b22d-7a76d679e73d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6663), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.488", "Vehicle 488", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6664), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, 3 },
                    { 489, new Guid("6928f5f1-89e7-4162-937f-680bf2865e1d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6667), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.489", "Vehicle 489", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6668), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, 3 },
                    { 490, new Guid("8724f8bd-ee0d-4563-994b-2c2fa0581c41"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6671), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.490", "Vehicle 490", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6671), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, 3 },
                    { 491, new Guid("c51822a9-6ec1-4663-b71f-b8dd3c75edca"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6674), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.491", "Vehicle 491", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6675), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, 3 },
                    { 492, new Guid("9efe5a57-acc4-4901-a85b-0b9ad594b84d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6678), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.492", "Vehicle 492", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6678), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, 3 },
                    { 493, new Guid("e0e4e2f7-cb88-421e-90e1-f6a37f133d9b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6683), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.493", "Vehicle 493", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6683), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, 3 },
                    { 494, new Guid("cd7432f9-df0b-412c-9f27-4a5abcbd7151"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6686), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.494", "Vehicle 494", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6687), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, 3 },
                    { 495, new Guid("e395c5f5-8b02-4a12-8355-bbc93bf294e5"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6690), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.495", "Vehicle 495", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6690), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, 3 },
                    { 496, new Guid("324a0456-2d2a-4dbf-b83e-d90f9ed0a7c2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6693), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.496", "Vehicle 496", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6693), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, 3 },
                    { 497, new Guid("64452381-7828-4c18-ad82-d9eb2775e018"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6696), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.497", "Vehicle 497", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6697), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, 3 },
                    { 498, new Guid("31a91b9f-de68-4acb-b4fc-ecf4ec461312"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6700), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.498", "Vehicle 498", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6701), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, 3 },
                    { 499, new Guid("2fc824a0-55e7-44b2-abad-a1f320dd36c7"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.499", "Vehicle 499", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6704), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, 3 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1278), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1279), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1288), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1289), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1296), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1297), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1304), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1304), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1311), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1319), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1320), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1326), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1327), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1334), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1334), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1340), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1341), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1348), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1349), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1355), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1356), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1362), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1363), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1369), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1370), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1376), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1377), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1383), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1384), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1391), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1391), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1398), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1406), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(1406), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "ceiling_extra_price", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6026), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6027), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6079), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6080), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6087), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6088), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6095), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6095), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6102), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6102), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6110), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6110), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6117), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6117), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6123), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6124), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6130), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6131), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6137), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6138), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6145), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6151), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6152), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6158), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6159), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "notifications",
                columns: new[] { "id", "code", "created_at", "created_by", "data", "deleted_at", "description", "event_id", "status", "type", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, new Guid("f8943889-e9b9-4bfd-91d9-b730c5e357c3"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6916), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 6, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6916), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 2, new Guid("54b7d677-ce8e-44a0-97cd-c80c8a70d09b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6950), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 3, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6951), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 3, new Guid("f96ccdc7-cd7a-430c-90ff-3be58659067b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 7, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6955), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 4, new Guid("251c161a-a3da-43e0-84aa-0749df0871a5"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 3, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6960), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 5, new Guid("ff7928fb-3a1e-4c8c-9884-1ae6a6a76ee7"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6963), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 3, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6963), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 6, new Guid("c4b3b17c-236c-4104-9bc4-efcc079537fd"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6969), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 8, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6969), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 7, new Guid("6df8e2b1-5161-423b-bd77-d28850a135da"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 8, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6973), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, new Guid("387be386-0f18-4176-ac45-aac5c1a6e64f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6977), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 8, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6978), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 9, new Guid("3cbe556d-7211-4f9b-9d43-33b375031e6b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6981), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 3, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6982), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 10, new Guid("8d492f2f-ca09-43ce-9ceb-df990963a669"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6987), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 3, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6987), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5262), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5263), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5371), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5372), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5459), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5460), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5487), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5487), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5510), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5524), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5525), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5538), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(5538), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, new Guid("e4f16326-8ac0-4182-ac08-4351adf084d6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6232), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6233), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("6174a2f4-538b-4827-b066-920614da86a8"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6241), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6241), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("606288f0-fd1b-4a6d-8079-f11b2e45250b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6243), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6243), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("f4bddc0a-345a-4ec1-94ad-41509c1204d4"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6245), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6245), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6799), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6800), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6804), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6804), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6806), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6807), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6808), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6808), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6809), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6810), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6811), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6812), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6814), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6814), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6816), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 44, 26, 294, DateTimeKind.Unspecified).AddTicks(6816), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
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
