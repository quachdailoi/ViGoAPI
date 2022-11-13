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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("3371b7ea-32c7-452a-a136-516d26afa2fc")),
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 17, DateTimeKind.Unspecified).AddTicks(2143), new TimeSpan(0, 7, 0, 0, 0))),
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("1dcb49e4-9839-45f8-a914-e3e40203df75")),
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
                    { 1, new Guid("964d97b0-4e31-4a96-95e3-2819498701a5"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5467), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5469), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("5290b3bd-dd7b-4c00-af3d-4c32cbffd849"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5487), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5487), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("83373aa7-5ab8-4b6a-be2a-86a9f109e578"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5483), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5484), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 11, "Be careful with the rate of cancelled trip, you reach 80% of permission of cancelled trip rate.", 1, "Be Cautions!!!", 0 },
                    { 12, "You reach the limit of permission of cannceled trip rate, you were banned now. Contact with our office for handling this problem.", 1, "You were banned!!!", 0 }
                });

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "path", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("15442ba7-26a7-4397-a01e-5eed2a8d8236"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3197), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("6a4c42a3-599e-4516-8af3-f510fe829d3b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3213), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("522d7009-53d3-4134-86d8-b178635a2b22"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3222), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3222), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("38cb1248-1bba-4dd6-9166-2d8e7e75aada"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3253), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3253), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("ac6a5a1c-07fd-4a61-85e2-b199f9600c90"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3262), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3263), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("c49f306d-4110-4619-9168-c3b2b093c93e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3274), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3275), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("f6c6f079-feb7-40b1-9a8a-d7a3483bb1d6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3324), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3324), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("8e5b639d-03c6-4ed3-aaf5-5168722a7f27"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3333), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3334), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("0f7d321f-2988-4e73-b80d-d2cd065b01d9"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3342), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3343), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("d509e99f-39d5-4d07-aea1-8a0400aa3130"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3353), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3354), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("9a513929-befb-4baa-b97e-2cbe231c8753"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3362), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3363), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("fce9981f-7400-4558-8c39-21931e0dd955"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3374), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3375), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("75f50643-afe8-4f12-875f-2b186143672f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3389), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3390), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "pricings",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "discount", "lower_bound", "updated_at", "updated_by", "upper_bound" },
                values: new object[,]
                {
                    { 1, new Guid("665bb7e0-59f3-46e4-972e-0b6fe06511bc"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5645), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.0, null, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5647), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 2, new Guid("06644607-a506-4f15-b966-271e584578bd"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5658), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.029999999999999999, 8, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5659), new TimeSpan(0, 7, 0, 0, 0)), 0, 30 },
                    { 3, new Guid("3fdf21e3-5721-4861-af45-d88b912b386d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5663), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.050000000000000003, 31, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5664), new TimeSpan(0, 7, 0, 0, 0)), 0, 90 },
                    { 4, new Guid("c2b76c83-5eee-4392-85e4-5f9ea9ee5435"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5671), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.070000000000000007, 91, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5672), new TimeSpan(0, 7, 0, 0, 0)), 0, null }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2623), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2624), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2636), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2648), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("6d00f996-05f9-49f7-9988-ed69a9aa9160"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3375), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3376), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3ebc0843-198a-4d63-91fe-bc58b50a0323"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3383), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3384), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ed544419-b232-4011-8b96-244dc76fad2f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3403), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3404), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("34136632-ef69-46fc-8de9-f4cdc6e4d63b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3407), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3408), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6d0287bc-187a-439b-95ca-1da0d7752cae"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3412), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3ca74508-95fe-4f88-9f33-bdf6ef19822d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3416), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3417), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3152ae9e-61c4-41dd-ba81-8394626aecd4"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3421), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3422), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("67dee4a5-70a4-4213-a1a6-332de876c8d1"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3424), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3425), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("4b155c9f-a62f-4567-8aff-918dc3a5d63c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3428), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3429), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("a52e1dd9-1ef5-4dbc-bfd6-d5960b3c8e79"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3433), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3434), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2b4115c0-720f-4543-b5fd-67762385fa94"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3440), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3441), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("24f9f505-caf0-4749-9daa-9e1e04b5327b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3444), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3445), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f06d149a-2435-406b-a7da-f0dd8e5182cf"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3447), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3448), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("ee860088-24c8-4d4f-ba4d-f695d2beb799"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3451), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3452), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4c7ae137-d2c1-4416-aa2a-f6fb3951729c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3455), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3456), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9cbe55c2-13df-4dde-aa5e-1b0df5d44d93"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3459), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3460), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0cf1074d-541e-4f09-8984-524890712c92"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3463), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3463), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0fdcd4b8-60d7-43bd-af08-bfb4de564b70"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3469), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e081b4b0-3bd3-4df6-bf65-c32b59067f12"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3476), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3476), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("324b2354-c342-42b8-94d1-53d3f99a4f2a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3479), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3480), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f35b34ad-0b4b-45c5-9565-21289d0a86e4"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3483), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3483), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("13c5adcc-e91d-455b-959b-9ae810eb930f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3486), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3487), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8a27cea2-d079-482b-b95e-3b5a7657239c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3493), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3494), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("11ddf1e5-9d42-4a85-ba8a-556c0f811fc6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3497), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3497), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ae29d585-ebc6-4953-b976-4da544627afc"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3534), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3536), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b3bb2ada-da7e-4bf9-b370-520d8da1f430"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3542), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3543), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f1d2c155-dd87-4b4b-a1f8-26821e477b5c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3545), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3546), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("09db3992-7738-46b2-9ae5-7fc55f7bc903"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3552), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3553), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e56f4a43-a04e-4f88-bada-7da4cfbb552d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3555), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3556), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("16a5bed9-1b4d-4d9f-ae48-cb917121c0f0"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3561), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3562), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9507f26a-57a7-4de7-86c5-6e32b03a665f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3564), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3565), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c7360e7c-a1c9-4523-961c-2e21abd28bc0"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3568), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3568), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6f2bfc4b-62fc-4f0f-a11f-d5d3c098216e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3573), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("09da5f14-8a69-4d0b-9d2b-29b3bc59b3ad"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3578), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3579), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dc26044b-331f-44e6-94de-3a60eb051c62"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3582), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3583), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9fd09901-f850-458d-bcef-3e69f3e66b48"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3586), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3587), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("00f279ad-6a9c-443f-82c4-0eab89d82acc"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3589), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3590), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bf047399-08b6-4fa6-a959-8a6281d65dc0"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3593), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3594), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("24e74842-d2ec-4f00-ba5f-1dcb2dc5e81e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3596), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3597), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("468ef7f1-7669-461a-b037-22a380044ff4"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3599), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3600), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("50a16e24-3f09-4d93-8f56-d099def13cb5"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3603), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3603), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("53474b1b-f6b6-4993-b12a-f5749c2874ee"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3609), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3609), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("60add791-40df-4db0-a5fa-b960383e5220"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3611), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3612), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("d40addf3-d9d9-4679-86bd-00ef90644a16"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3615), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3616), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("891b772a-aac2-436a-8045-35836b5fa086"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3618), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3619), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d722a759-681c-4802-81be-d6bef270bc2b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3623), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3624), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e8f02d18-e5d9-4e71-901e-9fa38319b5cb"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3626), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3627), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d9a94a63-54dd-4466-88f4-7cdd130f0c78"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3630), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3630), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0f9fb1f9-135f-4cf7-bd70-2c6ae367d599"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3633), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3634), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ef4935c5-0e38-4586-b5d9-08fe4905d3fe"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3639), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3640), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c1b6d5a2-9c7e-43a8-b00f-fcafa2956ea2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3643), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3644), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("337574e9-a4d1-4d05-b3ee-05824a9559c6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3646), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3647), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("edbfe9d8-d2fd-45fe-87d3-66c099c8cc2e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3649), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3650), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("55e9b759-aeeb-478f-ad91-048b19a15ca1"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3653), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3654), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("52772535-a2f6-4674-9bdc-d8cfc0a92d6d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3657), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3657), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9ca3384f-3cc1-4718-ad79-d165d408b554"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3660), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3661), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4d5dd011-05cb-4c8b-87eb-081473c34d89"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3665), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dcc45e5e-8729-4c61-bce8-61bd98face03"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3670), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3671), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("88ca930f-6c0b-4f93-96a6-b8bda5619e76"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3674), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3674), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f6b8181a-6c4f-421e-a13c-84b318c0e3c2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3677), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3678), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("14001a5f-eb7b-4393-99c3-10aa5b41f969"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3681), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3681), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b3466d7d-ba19-449d-b563-8b884b445339"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3684), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3685), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("efbc0729-3f9f-47e5-8d2b-d73ada8a6f65"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3687), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3688), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d0aaff13-553d-40cc-9d59-0b739ddafd33"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3690), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3691), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a3f04bef-2499-4b0b-abe0-68a51d62e0b9"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3732), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3734), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fb1809c5-5860-4abf-8b1c-59117624f213"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3740), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3741), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8ca0e9ec-49a2-4f8e-bfd9-1ca7a7cce1af"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3743), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3744), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4cd6b98c-8419-460f-bfd4-782dee55e0c8"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3747), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3748), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("33fba973-b8fb-4beb-ad68-05995983cb0a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3750), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3751), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6d6d36ad-822a-49c7-b054-5a595da12194"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3754), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3755), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("62d7b722-6e5a-4492-81fc-d91887bf830f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3758), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3758), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("099c1a73-7468-4139-8f9e-55737d764022"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3761), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3762), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4cabe435-21bb-4bc3-bce1-f55752aee8c8"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3765), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3766), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a41c7571-0c6e-484e-b5a1-9d5abb982988"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3771), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3772), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ba5fe5dd-fcb1-4db8-8c04-64f3137da7f3"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3775), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3776), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5287aa61-7aaa-448b-aa08-8d646963b362"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3778), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3779), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2b59ed27-71d1-4611-9a8e-43d8aee2449f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3782), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3017a784-ecaf-40f8-8b8b-5e94ccadbb97"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3785), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3786), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("713033a6-74c5-4968-8b1b-c3d7213a6222"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3788), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3789), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("8f57e9b4-aaa6-4fda-b890-cfdc516873e0"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3792), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3792), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("fe60c89c-4fd8-4b36-868c-50b928be050b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3795), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3796), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("02a5918b-43ed-4402-a8d2-5fb735fe3cca"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3801), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3802), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("0509df2f-c6e7-42bf-a3f6-273a269f927d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3804), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3805), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("7770d5b7-64cd-4389-bb73-d5c3d6439b81"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3807), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3808), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("69169e25-6eb9-4590-a811-716446311bbb"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3490), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3490), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô E2a-10 Đường, D2b Đ. D1, TP. Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam", new Guid("29455dd9-2bc0-419c-8ec7-5f0aba17feb6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3811), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3812), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trip_rate", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "rating", "status", "suddenly_cancelled_trips", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 10, 0.0, new Guid("4f31bc60-308c-404e-bf87-f16f9f1a12d5"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3813), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Than Thanh Duy", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3814), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 0.0, new Guid("88c76421-5f25-4f13-9776-361c9fa8efa0"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3825), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Nguyen Dang Khoa", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3826), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 0.0, new Guid("8622439e-8fe4-4f9f-b444-d6fce74b7fde"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3839), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Do Trong Dat", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3839), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 100, 0.0, new Guid("f246d109-c52b-463c-94ec-e6a793cd0d15"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3851), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 100", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3851), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 101, 0.0, new Guid("12431847-4df7-41a9-ae17-bdb107f1cbe0"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3889), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 101", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3889), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 102, 0.0, new Guid("a7d3c085-1f3e-43c0-9f6d-27c111f9299e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3915), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 102", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3915), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 103, 0.0, new Guid("9d355378-1e05-4c84-9f70-6789657d2c53"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3930), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 103", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3930), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 104, 0.0, new Guid("7f6b0773-0e3e-4835-b3b7-7cbae6e45b71"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3949), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 104", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3950), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 105, 0.0, new Guid("8e25cd06-9ead-4856-9fec-cf0f1b96d427"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3970), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 105", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3971), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 106, 0.0, new Guid("d64dfaaa-ad88-43e4-8dd2-58b8507922a5"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3990), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 106", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3991), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 107, 0.0, new Guid("4e9be1ba-ac36-42ad-b8f7-04aebec99a8d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4050), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 107", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4052), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 108, 0.0, new Guid("6d7bad7c-436d-4015-89c3-67807bd8b4f4"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4073), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 108", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4074), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 109, 0.0, new Guid("c262b6ec-bed2-4f0a-abf4-54f201e91c54"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4094), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 109", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4095), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 110, 0.0, new Guid("0cad7041-389b-462d-b84e-11b71d640c06"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4110), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 110", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4111), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 111, 0.0, new Guid("070a7d29-48b4-4a38-9625-9cad70c2699c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4124), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 111", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4125), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 112, 0.0, new Guid("5e7603a4-545f-4daa-8c9e-36efb11eb592"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4137), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 112", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4137), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 113, 0.0, new Guid("096c1074-beba-418a-87e0-fa70a39693c1"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4149), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 113", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4149), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 114, 0.0, new Guid("fce31e43-2922-4711-9671-dfb41ad0b01c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4160), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 114", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4161), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 115, 0.0, new Guid("f67887f8-a8f7-4676-8f45-5d6c096badbf"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 115", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4174), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 116, 0.0, new Guid("97978ecf-93b6-45ce-a058-e406c892d1b3"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4185), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 116", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4186), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 117, 0.0, new Guid("eb1a7793-9943-4a17-886a-21707ddab3cc"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4197), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 117", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4197), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 118, 0.0, new Guid("273c4699-1924-4749-a61c-c33f7ec17485"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4208), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 118", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4209), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 119, 0.0, new Guid("a6cafaa6-86f4-40f2-b551-09f651e10c7c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4249), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 119", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4249), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 120, 0.0, new Guid("a4ed8653-1302-4acd-a43d-6b223f1cbbaa"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4262), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 120", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4263), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 121, 0.0, new Guid("074052a5-be3c-4734-b129-42d90f6ff250"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4277), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 121", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4277), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 122, 0.0, new Guid("536d9b5f-da12-4070-bd2e-c48e1dda6790"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 122", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4290), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 123, 0.0, new Guid("be25a4b3-18d2-4feb-a5a2-de07533326ab"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 123", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4303), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 124, 0.0, new Guid("6aacfe6c-30fc-487b-868a-332acb0d9a99"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4315), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 124", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4315), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 125, 0.0, new Guid("5f52cb1c-d50e-4fd9-af74-fd1e9da6c520"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4326), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 125", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4327), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 126, 0.0, new Guid("185379af-bc26-4653-a238-091509b553d0"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4338), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 126", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4338), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 127, 0.0, new Guid("c282ad70-6724-43a7-a389-c61ab459b73e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4351), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 127", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4352), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 128, 0.0, new Guid("2a55cd12-3ebe-4ce1-872e-6f73521ce66f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4363), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 128", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4363), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 129, 0.0, new Guid("b8ab69bc-0ea0-4496-9cf3-fbe32b0d53e5"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4374), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 129", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4375), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 130, 0.0, new Guid("c62c5882-16b3-4c30-a1c6-0325a07ecfc6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4417), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 130", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4418), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 131, 0.0, new Guid("ce245b6f-7cf8-44e8-bfaa-30a35b49b1c7"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4432), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 131", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4433), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 132, 0.0, new Guid("01137d15-1c74-4cf0-9371-7cbc4f6dc178"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4444), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 132", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4445), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 133, 0.0, new Guid("42723523-2a1d-4757-9731-99ab6db98bae"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4456), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 133", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4457), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 134, 0.0, new Guid("5670ca9d-ff14-4744-90ab-c1865eb7cf49"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 134", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4468), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 135, 0.0, new Guid("1810163a-f456-4a96-a2f8-c88e203c9072"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 135", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4482), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 136, 0.0, new Guid("217c7642-036f-4f6f-a801-a1e9f0e62c6a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4493), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 136", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4494), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 137, 0.0, new Guid("618c372c-3ad8-4816-b069-3cd4800a4880"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4505), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 137", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4506), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 138, 0.0, new Guid("34536bd7-0b22-4b89-9d29-e256ef50edf9"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4523), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 138", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4524), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 139, 0.0, new Guid("bdb0fc6e-7e43-464b-9ba8-26029249c1b8"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4544), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 139", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4545), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 140, 0.0, new Guid("16372442-1b72-47ae-a4db-0cfd7434671e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4563), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 140", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4564), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 141, 0.0, new Guid("bebc830f-e673-4ece-bfc4-af64f6df7def"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4583), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 141", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4584), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 142, 0.0, new Guid("124aff5b-7ec9-437c-af4a-a4b42b8fc609"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 142", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4637), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 143, 0.0, new Guid("ba797a9a-ff02-4595-a87a-f5a9654875a2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4663), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 143", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4664), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 144, 0.0, new Guid("eb227aec-0138-4138-b256-c117738a2b59"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4683), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 144", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4684), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 145, 0.0, new Guid("29b76202-04ae-47fe-a737-757133b55b96"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4702), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 145", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4703), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 146, 0.0, new Guid("a9e0c873-e681-49a6-900a-4e514988c58e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4721), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 146", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4722), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 147, 0.0, new Guid("2d8be770-e0f9-464f-b8ea-0fa8d53418ba"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4743), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 147", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4744), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 148, 0.0, new Guid("ea720fa8-0e9d-4f06-8d56-f2e5087fd01a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 148", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4763), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 149, 0.0, new Guid("d4847d10-a87e-4da8-991b-2f5eec63a1c3"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 149", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4783), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 150, 0.0, new Guid("7461d584-6f37-43d4-9184-7956d3453eba"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4800), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 150", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4801), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 151, 0.0, new Guid("50f0ca7b-9b5f-4881-aac0-2f32261d7869"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4821), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 151", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4822), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 152, 0.0, new Guid("9f4b9fc4-9124-440f-8684-0364825c33c6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4841), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 152", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4842), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 153, 0.0, new Guid("0309553d-9f43-4f0c-87a3-cbe66e389985"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4902), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 153", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4903), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 154, 0.0, new Guid("211e829f-30b2-490d-95e8-0ca3015979a2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4921), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 154", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4922), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 155, 0.0, new Guid("e3756583-f2af-4f30-aa0a-6356e2361ba5"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4940), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 155", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4941), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 156, 0.0, new Guid("c6c048e6-7447-4815-81cf-dc3dcf2c1cbc"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 156", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4960), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 157, 0.0, new Guid("1267c3ad-461c-4430-a196-20cf4505e1c5"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4977), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 157", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4978), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 158, 0.0, new Guid("7fbc7ce0-2efb-41c9-9d70-0bcff5ade865"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4995), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 158", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(4996), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 159, 0.0, new Guid("d5522817-4172-4026-a722-41147f8271fb"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5015), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 159", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5017), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 160, 0.0, new Guid("0a637167-388d-4af3-85bf-50cd382aef13"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5037), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 160", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5038), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 161, 0.0, new Guid("a20affe6-daf2-4f55-9183-d3603ac8ee36"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5055), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 161", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5056), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 162, 0.0, new Guid("76502d3f-588b-46a1-b371-cb190e555cdd"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5073), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 162", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5074), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 163, 0.0, new Guid("7fbf1105-52c1-4194-a01a-e93680eee5d1"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5092), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 163", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5093), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 164, 0.0, new Guid("a6115946-a47e-43cf-967b-fe568aa50e19"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5111), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 164", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5111), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 165, 0.0, new Guid("d0147153-8cbd-4467-93c4-8f5d444ffd6e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5178), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 165", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5180), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 166, 0.0, new Guid("9717e85e-b7f3-46f1-8b6a-316a674def5e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5197), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 166", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5198), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 167, 0.0, new Guid("c73da2d6-3c60-4fb1-8a23-1d6fc18ba575"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5217), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 167", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5218), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 168, 0.0, new Guid("8b0516d8-712a-4aea-b746-18dd608cbfe8"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5235), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 168", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5236), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 169, 0.0, new Guid("85c3ef0f-6877-4f5c-9e26-0c748bdff828"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5252), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 169", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5253), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 170, 0.0, new Guid("7fb600de-8370-442b-9e03-80abff357002"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5270), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 170", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5271), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 171, 0.0, new Guid("52e8ce7a-8455-492a-a23b-d5682bf38b4e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 171", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5291), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 172, 0.0, new Guid("488587f4-e374-4e0d-8994-25150b99f4a6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5307), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 172", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5308), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 173, 0.0, new Guid("293dda1e-fe72-4e99-9aff-53ff60e84ca2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5325), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 173", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5326), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 174, 0.0, new Guid("ca820561-54db-46c8-9da2-7e0b42fde0cf"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5342), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 174", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5343), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 175, 0.0, new Guid("2a9c1f72-3ae5-4ff0-ae64-736f2ec9c075"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5363), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 175", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5364), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 176, 0.0, new Guid("b4127f52-8bd0-428f-8435-683683051162"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5381), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 176", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5382), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 177, 0.0, new Guid("d9df460e-ba6b-407d-a5eb-5491c1572a7e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5433), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 177", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5435), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 178, 0.0, new Guid("bf271926-f0f2-44f9-ab36-a18d43b40645"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5452), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 178", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5453), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 179, 0.0, new Guid("639d79ca-6044-475d-a076-6a04575afead"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5472), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 179", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5473), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 180, 0.0, new Guid("3cad2343-3211-45c6-932b-ecf3e2b1c5f9"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5490), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 180", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5491), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 181, 0.0, new Guid("7d02939c-c455-4562-b978-536177143ef1"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5509), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 181", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5510), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 182, 0.0, new Guid("cf73ecdb-a1f5-4e31-b9c7-b8ae2b2bcdc3"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5528), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 182", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5529), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 183, 0.0, new Guid("b7232f65-421b-414e-b696-dccfb2227244"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5550), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 183", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5551), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 184, 0.0, new Guid("2e90c9dc-a216-43a7-9d2d-3cf8fa5540ad"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5569), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 184", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5570), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 185, 0.0, new Guid("1901eba1-fe4b-47de-8240-c2789b721d1e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5588), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 185", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5589), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 186, 0.0, new Guid("1c4bfca2-f3f0-47ea-90e7-90daeee92dbc"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5606), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 186", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5607), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 187, 0.0, new Guid("b9db31cc-6e3e-4fbf-b033-789da17a55b4"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5628), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 187", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5629), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 188, 0.0, new Guid("c04d15fa-6124-4f2b-8986-59af116c5eba"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 188", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(5648), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 189, 0.0, new Guid("635193d1-2448-4ab3-9a6f-646903adb3a3"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1195), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 189", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1201), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 190, 0.0, new Guid("039cba78-34e7-4681-b642-20676b84d9c3"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1251), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 190", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1252), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 191, 0.0, new Guid("439bcdc2-c3bc-40e9-983c-7dce26e0dc60"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1270), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 191", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1271), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 192, 0.0, new Guid("a051e7f0-d77b-4916-86dc-084548346931"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1283), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 192", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1284), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 193, 0.0, new Guid("194150cc-c3a8-485d-babe-87c717b615eb"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1296), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 193", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1296), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 194, 0.0, new Guid("49d8642f-5876-4531-8639-4663fac440ea"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1308), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 194", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1309), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 195, 0.0, new Guid("24657253-a754-4c55-8c68-26723d8f2efd"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1322), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 195", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1322), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 196, 0.0, new Guid("fe7f9b26-5f51-46e2-b449-37645b10c7da"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1334), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 196", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1335), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 197, 0.0, new Guid("2f7a37fc-c2fb-4fdc-9916-77176ceb06ed"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1346), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 197", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1347), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 198, 0.0, new Guid("81c776a6-192b-4cc5-880c-7bc8e11121e1"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1358), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 198", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1358), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 199, 0.0, new Guid("73bf0c0b-e648-4e6c-92d2-24070e0ccb9f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1371), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 199", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1372), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 400, 0.0, new Guid("11d31e75-baf3-4203-b78b-de39b8af3f93"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1385), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 400", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1386), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 401, 0.0, new Guid("402f44d9-342e-4e68-bd45-1f2180325447"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1431), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 401", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1432), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 402, 0.0, new Guid("23db1e70-5380-4f54-a49a-02f139cf6172"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1444), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 402", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1445), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 403, 0.0, new Guid("52c5ca9f-cfc9-46e6-a633-732f05752c19"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 403", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1459), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 404, 0.0, new Guid("38f86924-c9e9-416e-8299-3d80354b820f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1471), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 404", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1471), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 405, 0.0, new Guid("6e9b0431-9d36-41fe-a481-62478cbaaa83"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1483), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 405", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1484), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 406, 0.0, new Guid("afebfebe-67d8-4e91-aee8-1365d2ef0946"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1495), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 406", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1495), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 407, 0.0, new Guid("cacba7a8-cce3-4761-af21-6d0604df601a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1509), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 407", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1510), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 408, 0.0, new Guid("e7d8e5a0-1dc2-4b12-80da-099075b1658a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1521), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 408", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1522), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 409, 0.0, new Guid("e3f47f24-3c04-478f-96f9-415514affc7e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 409", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1533), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 410, 0.0, new Guid("f3fff54e-6f1c-4545-a660-ece007c84f50"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1545), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 410", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1545), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 411, 0.0, new Guid("0cfa366e-da3b-4cd4-a09e-3b5ee532f381"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1558), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 411", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1559), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 412, 0.0, new Guid("c01e77b1-f803-436c-b0d0-d8ad1caa3a62"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1570), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 412", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1571), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 413, 0.0, new Guid("9b822318-c987-4c11-b741-074c7af73a85"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1612), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 413", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1613), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 414, 0.0, new Guid("61ba4b65-9a24-4a4e-b686-56da02c47f07"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1625), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 414", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1626), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 415, 0.0, new Guid("d8c5050c-5582-4876-9fc6-f3bca526ceba"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1639), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 415", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1640), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 416, 0.0, new Guid("d371ef17-b389-4b64-b50b-26643d4b65f3"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1651), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 416", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1652), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 417, 0.0, new Guid("30b84862-b43e-4683-8f21-ba8d56d454cd"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1668), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 417", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1669), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 418, 0.0, new Guid("3b7927ec-85de-40dc-b5ae-1b5047a20719"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 418", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1681), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 419, 0.0, new Guid("975ba17e-f408-4f62-ae81-ae9b44f922bc"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1694), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 419", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1694), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 420, 0.0, new Guid("5346b40b-1e0c-44d7-a4e4-06fb86fc5292"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1705), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 420", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1706), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 421, 0.0, new Guid("76c0cf50-3b77-4a10-99b8-c134c004ab4d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1717), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 421", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(1718), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 422, 0.0, new Guid("f038f48d-11e9-40aa-b9b2-6bfed361d137"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7096), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 422", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7100), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 423, 0.0, new Guid("9851bc08-1175-48d7-97c3-a2d7dc5fbb17"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7148), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 423", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7150), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 424, 0.0, new Guid("231c2be5-7ba3-42f8-960d-013fa5899b3b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7172), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 424", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7174), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 425, 0.0, new Guid("5f4f7dee-dc17-49d0-b62a-d3fb2fbcfcc1"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7193), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 425", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7194), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 426, 0.0, new Guid("d134d921-65a9-4735-be1a-22d15297876e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7207), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 426", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7208), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 427, 0.0, new Guid("2d153fae-f05c-4ffb-a8d3-3358eeb15c6a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7223), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 427", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7224), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 428, 0.0, new Guid("b8ff07ea-ee69-4fd7-9a0c-bdc28f7ffc4a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7235), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 428", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7235), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 429, 0.0, new Guid("196db1ed-882f-4e21-a6a1-b385f0ee9d97"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7247), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 429", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7248), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 430, 0.0, new Guid("07203207-3765-4865-96b9-cc11aa319adc"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7259), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 430", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7259), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 431, 0.0, new Guid("fe1a0f5a-7348-45e4-bab7-4032933f760a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7272), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 431", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7273), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 432, 0.0, new Guid("9e7cca87-559b-4005-bd27-31a60a2b321e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7284), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 432", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7285), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 433, 0.0, new Guid("76577032-3a70-47ad-aab1-9ca0df08c253"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7296), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 433", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7296), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 434, 0.0, new Guid("02f0a6b0-c60f-4395-ba1c-c59b91e43268"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7346), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 434", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7347), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 435, 0.0, new Guid("42225407-21b9-4fad-b40b-1b0a0f30d789"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 435", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7362), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 436, 0.0, new Guid("7c253d99-7dfa-416b-9f27-2e8983699b5c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7373), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 436", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7374), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 437, 0.0, new Guid("d2ad8178-1af5-473d-bc82-ce15c7647d67"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7384), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 437", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7384), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 438, 0.0, new Guid("c246325f-ad6b-4377-b86c-e97a8b9a5294"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 438", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7398), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 439, 0.0, new Guid("8fbae5e0-df30-4387-a46a-e042d8da5272"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7418), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 439", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7419), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 440, 0.0, new Guid("49cbeda2-b830-41bf-9b65-c8076240e681"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 440", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7437), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 441, 0.0, new Guid("893aebaf-1c15-4dd1-8c4a-8ec1993f853b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7454), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 441", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7456), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 442, 0.0, new Guid("d6832dbb-e815-49b8-a75a-907b02ca9ce2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7472), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 442", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7474), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 443, 0.0, new Guid("f267dba8-7231-471f-9daa-5efae26208a9"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7494), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 443", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7495), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 444, 0.0, new Guid("6fd75d0b-a7ae-43ef-b768-092210864ced"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7513), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 444", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7515), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 445, 0.0, new Guid("aa081c38-4937-4a00-bc38-353fbb26612f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7532), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 445", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7533), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 446, 0.0, new Guid("1a89ec5e-f961-40da-a99e-0ffd10924828"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7596), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 446", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 43, DateTimeKind.Unspecified).AddTicks(7598), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 447, 0.0, new Guid("78c9a6db-93cc-4a7a-b9e0-8bcf24bbe03c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(2965), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 447", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(2977), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 448, 0.0, new Guid("83f569c5-81b4-425b-aa73-44e8dc725414"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3061), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 448", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3062), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 449, 0.0, new Guid("86204825-3c78-4fa2-bac3-cf8a94aa5c9f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3079), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 449", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3080), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 450, 0.0, new Guid("c2f3473e-261c-40e1-9f99-300f87518db6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3094), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 450", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3095), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 451, 0.0, new Guid("4b2a3423-32c2-488a-8b49-f52ede2a6bf1"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3120), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 451", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3121), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 452, 0.0, new Guid("129decfc-ae1f-4589-b1b3-9774e88efd80"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3136), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 452", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3137), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 453, 0.0, new Guid("fd6a77a9-3423-48c3-9807-5f735b71f3cb"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3153), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 453", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3154), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 454, 0.0, new Guid("a5773266-3cd6-4e69-9f55-8951cf3f2004"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3168), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 454", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3169), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 455, 0.0, new Guid("96e247b5-a018-470c-b94e-ac024e07b809"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3186), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 455", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3187), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 456, 0.0, new Guid("4faf98a2-f018-4503-8352-3c031c1c1bc3"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3202), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 456", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3203), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 457, 0.0, new Guid("cc71a2ea-9f15-4732-be35-89a2a7b70d01"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 457", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3219), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 458, 0.0, new Guid("ff9829fb-9036-43ce-9dac-43af1ad3d6e3"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3278), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 458", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3279), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 459, 0.0, new Guid("cb7894d7-9d8f-454a-906c-e0f13ae2f12d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3298), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 459", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3299), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 460, 0.0, new Guid("745d7543-56a5-4e68-abff-d7b352f11919"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3314), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 460", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3315), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 461, 0.0, new Guid("7736ce2d-a2d8-4d2d-9029-82630fc4bc4a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3330), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 461", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3331), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 462, 0.0, new Guid("7ef0b92f-f4d0-4a57-a088-fd2446416153"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 462", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3346), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 463, 0.0, new Guid("d3f36261-07da-445f-865d-5121652491cd"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3363), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 463", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3364), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 464, 0.0, new Guid("bf66ddbc-0417-4052-9a8b-d21acf6a535a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 464", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3379), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 465, 0.0, new Guid("a86ad165-3bb9-430f-ae26-f5cfd3518b6f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3393), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 465", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3394), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 466, 0.0, new Guid("90e503ff-8e7e-4000-b139-e01ce9360d64"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3409), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 466", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3410), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 467, 0.0, new Guid("be07a285-e4d1-4387-9bdc-e45548f593ff"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3425), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 467", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3428), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 468, 0.0, new Guid("31031f4b-5397-45d2-8ef2-08985798118d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3443), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 468", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3444), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 469, 0.0, new Guid("e75d700f-da08-40fd-ac5e-bc51a761d9d4"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3459), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 469", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3460), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 470, 0.0, new Guid("e0eb15fd-a93b-4eb6-960b-7938f31f2bd1"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3507), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 470", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3508), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 471, 0.0, new Guid("57e7a598-4963-4bef-b3aa-9e4abbfc9773"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3526), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 471", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3527), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 472, 0.0, new Guid("63dd5637-3c6d-4b73-a307-3e855cf80218"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3542), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 472", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3543), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 473, 0.0, new Guid("986b50dc-4f4c-46a0-b75c-1cab47ac566a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3559), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 473", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3560), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 474, 0.0, new Guid("c49b3b44-10c2-4fbc-b712-f7b08e421add"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3575), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 474", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(3576), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 475, 0.0, new Guid("42560db0-7096-4a8f-b846-1a222977d594"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(8959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 475", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(8964), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 476, 0.0, new Guid("a01dce55-080f-4f27-8bab-f1261b77635f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9004), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 476", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9005), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 477, 0.0, new Guid("0a576d59-a578-4775-b2a6-69e55b044787"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9021), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 477", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9022), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 478, 0.0, new Guid("656995b5-693e-4d66-bd80-dc37717ec2ab"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9037), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 478", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9038), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 479, 0.0, new Guid("8b2a197a-6532-49f7-a210-ffca16f32fd0"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9056), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 479", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9057), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 480, 0.0, new Guid("597f7151-92c2-4944-b15d-d9b0c665504c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9072), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 480", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9073), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 481, 0.0, new Guid("bde1934c-740d-4751-90cc-b19c8b57bdf2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9089), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 481", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9090), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 482, 0.0, new Guid("5054c924-4554-4cf3-8c15-d88324bdadbd"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9181), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 482", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9182), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 483, 0.0, new Guid("52c73c9b-19ee-41eb-96dd-72f1e5a316d6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9205), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 483", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9206), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 484, 0.0, new Guid("c464cca8-b606-486d-957a-d03f0af48f3c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9221), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 484", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9223), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 485, 0.0, new Guid("61172ba0-3b9a-4be8-bb10-bf041e6bfd81"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9237), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 485", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9238), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 486, 0.0, new Guid("da1b5e34-5b36-4877-bad5-998b1b355908"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9253), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 486", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9255), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 487, 0.0, new Guid("8b608a93-6f3f-49ba-a95d-948d0728af0d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9272), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 487", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9273), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 488, 0.0, new Guid("5f4fb920-0851-4c6f-a984-2d5c302e6253"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 488", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9290), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 489, 0.0, new Guid("e215ef33-afcb-47cb-8d69-3f6ca2d830fc"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9305), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 489", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9306), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 490, 0.0, new Guid("bdf86a90-7cd2-4fa9-92e3-b54f68b1e76a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 490", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9322), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 491, 0.0, new Guid("9f882a4e-3491-4ad2-b9a7-7e42a86ea67d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9340), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 491", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9341), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 492, 0.0, new Guid("c3d90b7c-bd28-4b17-9183-737278d982b5"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9357), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 492", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9358), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 493, 0.0, new Guid("8f0ca4bc-8c42-490a-a509-4c20686588a2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9371), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 493", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9372), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 494, 0.0, new Guid("093c1869-5763-427f-9249-da344c9a8dbe"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 494", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9424), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 495, 0.0, new Guid("c053b83c-13be-4585-8df4-399e142fb27f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9445), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 495", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9447), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 496, 0.0, new Guid("0b2ff262-cf93-4a67-935f-61235dd2f480"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9462), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 496", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9463), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 497, 0.0, new Guid("83ff97d0-78a4-4955-8ac9-a0d20560e422"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9478), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 497", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 498, 0.0, new Guid("b66ad4e0-8ed6-4734-bcff-5ee8ea2c86a3"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9494), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 498", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9495), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 499, 0.0, new Guid("250c0e0c-a293-4938-8839-7b2ea4d21d65"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9513), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 499", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9514), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "name", "slot", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("82593e66-657c-44c0-8d3b-fbef326ff4e1"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4056), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViRide", 2, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4057), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("b3d26951-061c-4883-878c-f138bc65024f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4124), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-4", 4, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4126), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("e6d9ae8c-3916-4e89-adde-f4a05c2932b6"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4146), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-7", 7, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4147), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5094), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5095), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5102), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5102), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5112), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5113), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5123), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5124), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5135), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5135), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5146), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5147), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 100, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5163), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+100", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5164), new TimeSpan(0, 7, 0, 0, 0)), 0, 100, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 101, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5185), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@100", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5186), new TimeSpan(0, 7, 0, 0, 0)), 0, 100 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 102, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5201), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+101", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5202), new TimeSpan(0, 7, 0, 0, 0)), 0, 101, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 103, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5215), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@101", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5215), new TimeSpan(0, 7, 0, 0, 0)), 0, 101 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 104, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+102", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5228), new TimeSpan(0, 7, 0, 0, 0)), 0, 102, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 105, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5241), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@102", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5242), new TimeSpan(0, 7, 0, 0, 0)), 0, 102 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 106, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+103", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5266), new TimeSpan(0, 7, 0, 0, 0)), 0, 103, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 107, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5275), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@103", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5276), new TimeSpan(0, 7, 0, 0, 0)), 0, 103 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 108, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5282), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+104", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5283), new TimeSpan(0, 7, 0, 0, 0)), 0, 104, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 109, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@104", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5321), new TimeSpan(0, 7, 0, 0, 0)), 0, 104 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 110, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5329), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+105", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5329), new TimeSpan(0, 7, 0, 0, 0)), 0, 105, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 111, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5337), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@105", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5337), new TimeSpan(0, 7, 0, 0, 0)), 0, 105 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 112, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5344), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+106", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5345), new TimeSpan(0, 7, 0, 0, 0)), 0, 106, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 113, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5351), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@106", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5352), new TimeSpan(0, 7, 0, 0, 0)), 0, 106 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 114, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5359), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+107", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5360), new TimeSpan(0, 7, 0, 0, 0)), 0, 107, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 115, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5366), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@107", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5367), new TimeSpan(0, 7, 0, 0, 0)), 0, 107 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 116, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5374), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+108", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5374), new TimeSpan(0, 7, 0, 0, 0)), 0, 108, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 117, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5381), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@108", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5382), new TimeSpan(0, 7, 0, 0, 0)), 0, 108 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 118, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5388), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+109", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5389), new TimeSpan(0, 7, 0, 0, 0)), 0, 109, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 119, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5395), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@109", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5396), new TimeSpan(0, 7, 0, 0, 0)), 0, 109 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 120, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5402), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+110", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5403), new TimeSpan(0, 7, 0, 0, 0)), 0, 110, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 121, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5410), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@110", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5410), new TimeSpan(0, 7, 0, 0, 0)), 0, 110 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 122, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5417), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+111", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5418), new TimeSpan(0, 7, 0, 0, 0)), 0, 111, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 123, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5425), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@111", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5425), new TimeSpan(0, 7, 0, 0, 0)), 0, 111 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 124, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5432), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+112", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5432), new TimeSpan(0, 7, 0, 0, 0)), 0, 112, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 125, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5439), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@112", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5440), new TimeSpan(0, 7, 0, 0, 0)), 0, 112 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 126, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5447), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+113", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5447), new TimeSpan(0, 7, 0, 0, 0)), 0, 113, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 127, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5454), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@113", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5454), new TimeSpan(0, 7, 0, 0, 0)), 0, 113 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 128, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5461), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+114", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5462), new TimeSpan(0, 7, 0, 0, 0)), 0, 114, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 129, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@114", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5469), new TimeSpan(0, 7, 0, 0, 0)), 0, 114 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 130, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5498), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+115", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5498), new TimeSpan(0, 7, 0, 0, 0)), 0, 115, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 131, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(874), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@115", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(876), new TimeSpan(0, 7, 0, 0, 0)), 0, 115 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 132, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(902), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+116", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(903), new TimeSpan(0, 7, 0, 0, 0)), 0, 116, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 133, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(916), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@116", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(917), new TimeSpan(0, 7, 0, 0, 0)), 0, 116 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 134, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(924), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+117", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(925), new TimeSpan(0, 7, 0, 0, 0)), 0, 117, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 135, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(932), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@117", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(932), new TimeSpan(0, 7, 0, 0, 0)), 0, 117 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 136, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(939), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+118", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(940), new TimeSpan(0, 7, 0, 0, 0)), 0, 118, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 137, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(947), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@118", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(948), new TimeSpan(0, 7, 0, 0, 0)), 0, 118 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 138, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(955), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+119", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(955), new TimeSpan(0, 7, 0, 0, 0)), 0, 119, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 139, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@119", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(963), new TimeSpan(0, 7, 0, 0, 0)), 0, 119 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 140, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(970), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+120", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(970), new TimeSpan(0, 7, 0, 0, 0)), 0, 120, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 141, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(980), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@120", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(981), new TimeSpan(0, 7, 0, 0, 0)), 0, 120 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 142, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(988), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+121", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(989), new TimeSpan(0, 7, 0, 0, 0)), 0, 121, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 143, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(995), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@121", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(996), new TimeSpan(0, 7, 0, 0, 0)), 0, 121 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 144, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1003), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+122", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1003), new TimeSpan(0, 7, 0, 0, 0)), 0, 122, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 145, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1010), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@122", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1011), new TimeSpan(0, 7, 0, 0, 0)), 0, 122 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 146, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1018), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+123", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1018), new TimeSpan(0, 7, 0, 0, 0)), 0, 123, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 147, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@123", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1026), new TimeSpan(0, 7, 0, 0, 0)), 0, 123 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 148, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1032), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+124", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1033), new TimeSpan(0, 7, 0, 0, 0)), 0, 124, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 149, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1040), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@124", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1040), new TimeSpan(0, 7, 0, 0, 0)), 0, 124 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 150, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1074), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+125", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1074), new TimeSpan(0, 7, 0, 0, 0)), 0, 125, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 151, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1082), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@125", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1082), new TimeSpan(0, 7, 0, 0, 0)), 0, 125 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 152, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1089), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+126", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1090), new TimeSpan(0, 7, 0, 0, 0)), 0, 126, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 153, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1096), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@126", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1097), new TimeSpan(0, 7, 0, 0, 0)), 0, 126 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 154, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1103), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+127", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1104), new TimeSpan(0, 7, 0, 0, 0)), 0, 127, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 155, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1110), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@127", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1111), new TimeSpan(0, 7, 0, 0, 0)), 0, 127 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 156, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1118), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+128", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1119), new TimeSpan(0, 7, 0, 0, 0)), 0, 128, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 157, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1125), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@128", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1126), new TimeSpan(0, 7, 0, 0, 0)), 0, 128 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 158, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1133), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+129", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1133), new TimeSpan(0, 7, 0, 0, 0)), 0, 129, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 159, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1140), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@129", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1141), new TimeSpan(0, 7, 0, 0, 0)), 0, 129 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 160, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1148), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+130", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1148), new TimeSpan(0, 7, 0, 0, 0)), 0, 130, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 161, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1155), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@130", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1155), new TimeSpan(0, 7, 0, 0, 0)), 0, 130 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 162, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1162), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+131", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1163), new TimeSpan(0, 7, 0, 0, 0)), 0, 131, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 163, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1169), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@131", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1170), new TimeSpan(0, 7, 0, 0, 0)), 0, 131 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 164, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1176), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+132", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1177), new TimeSpan(0, 7, 0, 0, 0)), 0, 132, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 165, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1183), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@132", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1184), new TimeSpan(0, 7, 0, 0, 0)), 0, 132 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 166, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1190), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+133", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1191), new TimeSpan(0, 7, 0, 0, 0)), 0, 133, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 167, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1197), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@133", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1198), new TimeSpan(0, 7, 0, 0, 0)), 0, 133 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 168, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1205), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+134", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1205), new TimeSpan(0, 7, 0, 0, 0)), 0, 134, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 169, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@134", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1213), new TimeSpan(0, 7, 0, 0, 0)), 0, 134 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 170, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1219), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+135", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1220), new TimeSpan(0, 7, 0, 0, 0)), 0, 135, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 171, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@135", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1227), new TimeSpan(0, 7, 0, 0, 0)), 0, 135 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 172, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1259), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+136", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1259), new TimeSpan(0, 7, 0, 0, 0)), 0, 136, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 173, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@136", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1268), new TimeSpan(0, 7, 0, 0, 0)), 0, 136 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 174, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1275), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+137", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1276), new TimeSpan(0, 7, 0, 0, 0)), 0, 137, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 175, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1283), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@137", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1283), new TimeSpan(0, 7, 0, 0, 0)), 0, 137 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 176, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1290), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+138", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1291), new TimeSpan(0, 7, 0, 0, 0)), 0, 138, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 177, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1297), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@138", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1298), new TimeSpan(0, 7, 0, 0, 0)), 0, 138 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 178, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1305), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+139", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1306), new TimeSpan(0, 7, 0, 0, 0)), 0, 139, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 179, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1314), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@139", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1315), new TimeSpan(0, 7, 0, 0, 0)), 0, 139 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 180, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1326), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+140", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1326), new TimeSpan(0, 7, 0, 0, 0)), 0, 140, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 181, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1338), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@140", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1339), new TimeSpan(0, 7, 0, 0, 0)), 0, 140 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 182, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1350), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+141", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1351), new TimeSpan(0, 7, 0, 0, 0)), 0, 141, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 183, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1362), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@141", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1363), new TimeSpan(0, 7, 0, 0, 0)), 0, 141 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 184, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1375), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+142", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1376), new TimeSpan(0, 7, 0, 0, 0)), 0, 142, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 185, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1387), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@142", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1388), new TimeSpan(0, 7, 0, 0, 0)), 0, 142 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 186, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1399), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+143", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1400), new TimeSpan(0, 7, 0, 0, 0)), 0, 143, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 187, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@143", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1412), new TimeSpan(0, 7, 0, 0, 0)), 0, 143 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 188, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+144", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1424), new TimeSpan(0, 7, 0, 0, 0)), 0, 144, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 189, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@144", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1436), new TimeSpan(0, 7, 0, 0, 0)), 0, 144 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 190, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1448), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+145", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1449), new TimeSpan(0, 7, 0, 0, 0)), 0, 145, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 191, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1460), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@145", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1461), new TimeSpan(0, 7, 0, 0, 0)), 0, 145 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 192, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1473), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+146", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1474), new TimeSpan(0, 7, 0, 0, 0)), 0, 146, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 193, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1486), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@146", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(1486), new TimeSpan(0, 7, 0, 0, 0)), 0, 146 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 194, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6761), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+147", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6763), new TimeSpan(0, 7, 0, 0, 0)), 0, 147, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 195, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6778), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@147", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6778), new TimeSpan(0, 7, 0, 0, 0)), 0, 147 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 196, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6786), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+148", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6787), new TimeSpan(0, 7, 0, 0, 0)), 0, 148, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 197, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6794), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@148", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6795), new TimeSpan(0, 7, 0, 0, 0)), 0, 148 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 198, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6802), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+149", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6802), new TimeSpan(0, 7, 0, 0, 0)), 0, 149, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 199, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6809), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@149", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6810), new TimeSpan(0, 7, 0, 0, 0)), 0, 149 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 200, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6816), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+150", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6817), new TimeSpan(0, 7, 0, 0, 0)), 0, 150, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 201, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6825), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@150", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6825), new TimeSpan(0, 7, 0, 0, 0)), 0, 150 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 202, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6832), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+151", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6833), new TimeSpan(0, 7, 0, 0, 0)), 0, 151, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 203, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6840), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@151", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6841), new TimeSpan(0, 7, 0, 0, 0)), 0, 151 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 204, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6851), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+152", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6852), new TimeSpan(0, 7, 0, 0, 0)), 0, 152, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 205, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6867), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@152", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6868), new TimeSpan(0, 7, 0, 0, 0)), 0, 152 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 206, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+153", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6880), new TimeSpan(0, 7, 0, 0, 0)), 0, 153, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 207, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6891), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@153", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6892), new TimeSpan(0, 7, 0, 0, 0)), 0, 153 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 208, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6904), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+154", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6905), new TimeSpan(0, 7, 0, 0, 0)), 0, 154, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 209, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6916), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@154", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6917), new TimeSpan(0, 7, 0, 0, 0)), 0, 154 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 210, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6929), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+155", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(6930), new TimeSpan(0, 7, 0, 0, 0)), 0, 155, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 211, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7010), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@155", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7011), new TimeSpan(0, 7, 0, 0, 0)), 0, 155 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 212, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7021), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+156", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7022), new TimeSpan(0, 7, 0, 0, 0)), 0, 156, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 213, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7029), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@156", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7029), new TimeSpan(0, 7, 0, 0, 0)), 0, 156 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 214, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7036), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+157", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7037), new TimeSpan(0, 7, 0, 0, 0)), 0, 157, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 215, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7044), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@157", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7044), new TimeSpan(0, 7, 0, 0, 0)), 0, 157 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 216, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7051), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+158", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7052), new TimeSpan(0, 7, 0, 0, 0)), 0, 158, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 217, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7058), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@158", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7059), new TimeSpan(0, 7, 0, 0, 0)), 0, 158 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 218, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7066), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+159", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7066), new TimeSpan(0, 7, 0, 0, 0)), 0, 159, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 219, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7073), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@159", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7074), new TimeSpan(0, 7, 0, 0, 0)), 0, 159 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 220, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7081), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+160", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7081), new TimeSpan(0, 7, 0, 0, 0)), 0, 160, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 221, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7088), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@160", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7089), new TimeSpan(0, 7, 0, 0, 0)), 0, 160 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 222, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7096), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+161", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7096), new TimeSpan(0, 7, 0, 0, 0)), 0, 161, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 223, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7103), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@161", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7104), new TimeSpan(0, 7, 0, 0, 0)), 0, 161 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 224, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7112), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+162", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7113), new TimeSpan(0, 7, 0, 0, 0)), 0, 162, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 225, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7124), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@162", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7125), new TimeSpan(0, 7, 0, 0, 0)), 0, 162 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 226, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7136), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+163", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7137), new TimeSpan(0, 7, 0, 0, 0)), 0, 163, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 227, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7148), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@163", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7150), new TimeSpan(0, 7, 0, 0, 0)), 0, 163 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 228, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7162), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+164", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7163), new TimeSpan(0, 7, 0, 0, 0)), 0, 164, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 229, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@164", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7175), new TimeSpan(0, 7, 0, 0, 0)), 0, 164 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 230, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7186), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+165", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7187), new TimeSpan(0, 7, 0, 0, 0)), 0, 165, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 231, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7201), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@165", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7201), new TimeSpan(0, 7, 0, 0, 0)), 0, 165 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 232, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+166", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7213), new TimeSpan(0, 7, 0, 0, 0)), 0, 166, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 233, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7259), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@166", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7260), new TimeSpan(0, 7, 0, 0, 0)), 0, 166 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 234, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+167", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7274), new TimeSpan(0, 7, 0, 0, 0)), 0, 167, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 235, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7285), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@167", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7286), new TimeSpan(0, 7, 0, 0, 0)), 0, 167 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 236, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7297), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+168", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7298), new TimeSpan(0, 7, 0, 0, 0)), 0, 168, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 237, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7308), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@168", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 46, DateTimeKind.Unspecified).AddTicks(7309), new TimeSpan(0, 7, 0, 0, 0)), 0, 168 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 238, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2708), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+169", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2713), new TimeSpan(0, 7, 0, 0, 0)), 0, 169, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 239, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2739), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@169", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2739), new TimeSpan(0, 7, 0, 0, 0)), 0, 169 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 240, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2747), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+170", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2748), new TimeSpan(0, 7, 0, 0, 0)), 0, 170, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 241, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@170", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2755), new TimeSpan(0, 7, 0, 0, 0)), 0, 170 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 242, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+171", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2763), new TimeSpan(0, 7, 0, 0, 0)), 0, 171, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 243, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2770), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@171", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2770), new TimeSpan(0, 7, 0, 0, 0)), 0, 171 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 244, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2778), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+172", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2779), new TimeSpan(0, 7, 0, 0, 0)), 0, 172, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 245, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2786), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@172", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2787), new TimeSpan(0, 7, 0, 0, 0)), 0, 172 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 246, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2793), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+173", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2794), new TimeSpan(0, 7, 0, 0, 0)), 0, 173, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 247, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2801), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@173", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2802), new TimeSpan(0, 7, 0, 0, 0)), 0, 173 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 248, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2808), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+174", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2809), new TimeSpan(0, 7, 0, 0, 0)), 0, 174, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 249, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2816), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@174", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2816), new TimeSpan(0, 7, 0, 0, 0)), 0, 174 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 250, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2823), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+175", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2824), new TimeSpan(0, 7, 0, 0, 0)), 0, 175, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 251, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2830), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@175", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2831), new TimeSpan(0, 7, 0, 0, 0)), 0, 175 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 252, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2837), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+176", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2838), new TimeSpan(0, 7, 0, 0, 0)), 0, 176, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 253, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2845), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@176", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2845), new TimeSpan(0, 7, 0, 0, 0)), 0, 176 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 254, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2852), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+177", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2853), new TimeSpan(0, 7, 0, 0, 0)), 0, 177, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 255, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2890), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@177", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2890), new TimeSpan(0, 7, 0, 0, 0)), 0, 177 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 256, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2899), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+178", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 7, 0, 0, 0)), 0, 178, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 257, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2909), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@178", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2910), new TimeSpan(0, 7, 0, 0, 0)), 0, 178 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 258, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2921), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+179", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2922), new TimeSpan(0, 7, 0, 0, 0)), 0, 179, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 259, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2933), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@179", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2934), new TimeSpan(0, 7, 0, 0, 0)), 0, 179 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 260, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2945), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+180", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2946), new TimeSpan(0, 7, 0, 0, 0)), 0, 180, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 261, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2957), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@180", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2958), new TimeSpan(0, 7, 0, 0, 0)), 0, 180 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 262, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2969), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+181", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2970), new TimeSpan(0, 7, 0, 0, 0)), 0, 181, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 263, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2981), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@181", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2982), new TimeSpan(0, 7, 0, 0, 0)), 0, 181 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 264, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2993), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+182", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(2993), new TimeSpan(0, 7, 0, 0, 0)), 0, 182, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 265, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3004), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@182", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3005), new TimeSpan(0, 7, 0, 0, 0)), 0, 182 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 266, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3017), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+183", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3018), new TimeSpan(0, 7, 0, 0, 0)), 0, 183, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 267, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3029), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@183", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3030), new TimeSpan(0, 7, 0, 0, 0)), 0, 183 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 268, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3042), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+184", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3043), new TimeSpan(0, 7, 0, 0, 0)), 0, 184, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 269, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3055), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@184", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3056), new TimeSpan(0, 7, 0, 0, 0)), 0, 184 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 270, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3068), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+185", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3068), new TimeSpan(0, 7, 0, 0, 0)), 0, 185, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 271, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3079), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@185", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3080), new TimeSpan(0, 7, 0, 0, 0)), 0, 185 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 272, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3091), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+186", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3092), new TimeSpan(0, 7, 0, 0, 0)), 0, 186, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 273, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3104), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@186", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3105), new TimeSpan(0, 7, 0, 0, 0)), 0, 186 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 274, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3117), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+187", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3118), new TimeSpan(0, 7, 0, 0, 0)), 0, 187, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 275, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3130), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@187", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3131), new TimeSpan(0, 7, 0, 0, 0)), 0, 187 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 276, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3142), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+188", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3143), new TimeSpan(0, 7, 0, 0, 0)), 0, 188, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 277, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3187), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@188", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3188), new TimeSpan(0, 7, 0, 0, 0)), 0, 188 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 278, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3203), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+189", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3203), new TimeSpan(0, 7, 0, 0, 0)), 0, 189, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 279, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3215), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@189", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3216), new TimeSpan(0, 7, 0, 0, 0)), 0, 189 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 280, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+190", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3227), new TimeSpan(0, 7, 0, 0, 0)), 0, 190, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 281, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3239), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@190", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3240), new TimeSpan(0, 7, 0, 0, 0)), 0, 190 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 282, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3251), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+191", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3252), new TimeSpan(0, 7, 0, 0, 0)), 0, 191, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 283, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3263), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@191", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3264), new TimeSpan(0, 7, 0, 0, 0)), 0, 191 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 284, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3275), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+192", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3276), new TimeSpan(0, 7, 0, 0, 0)), 0, 192, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 285, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@192", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3289), new TimeSpan(0, 7, 0, 0, 0)), 0, 192 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 286, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3305), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+193", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3306), new TimeSpan(0, 7, 0, 0, 0)), 0, 193, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 287, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3314), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@193", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3314), new TimeSpan(0, 7, 0, 0, 0)), 0, 193 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 288, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3322), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+194", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3322), new TimeSpan(0, 7, 0, 0, 0)), 0, 194, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 289, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3329), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@194", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(3330), new TimeSpan(0, 7, 0, 0, 0)), 0, 194 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 290, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8619), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+195", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8621), new TimeSpan(0, 7, 0, 0, 0)), 0, 195, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 291, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8637), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@195", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8637), new TimeSpan(0, 7, 0, 0, 0)), 0, 195 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 292, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8645), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+196", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8646), new TimeSpan(0, 7, 0, 0, 0)), 0, 196, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 293, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8653), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@196", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8653), new TimeSpan(0, 7, 0, 0, 0)), 0, 196 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 294, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8660), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+197", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8661), new TimeSpan(0, 7, 0, 0, 0)), 0, 197, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 295, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8668), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@197", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8668), new TimeSpan(0, 7, 0, 0, 0)), 0, 197 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 296, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8675), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+198", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8676), new TimeSpan(0, 7, 0, 0, 0)), 0, 198, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 297, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8683), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@198", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8683), new TimeSpan(0, 7, 0, 0, 0)), 0, 198 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 298, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8690), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+199", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8691), new TimeSpan(0, 7, 0, 0, 0)), 0, 199, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 299, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8697), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@199", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8698), new TimeSpan(0, 7, 0, 0, 0)), 0, 199 },
                    { 400, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8760), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+400", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8760), new TimeSpan(0, 7, 0, 0, 0)), 0, 400 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 401, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8773), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@400", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8774), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 402, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8786), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+401", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8787), new TimeSpan(0, 7, 0, 0, 0)), 0, 401 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 403, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8799), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@401", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8799), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 404, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8812), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+402", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8812), new TimeSpan(0, 7, 0, 0, 0)), 0, 402 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 405, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8824), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@402", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8825), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 406, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8837), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+403", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8838), new TimeSpan(0, 7, 0, 0, 0)), 0, 403 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 407, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8850), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@403", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8851), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 408, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8886), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+404", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8887), new TimeSpan(0, 7, 0, 0, 0)), 0, 404 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 409, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8899), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@404", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8900), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 410, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8911), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+405", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8912), new TimeSpan(0, 7, 0, 0, 0)), 0, 405 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 411, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8923), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@405", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8924), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 412, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8935), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+406", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8936), new TimeSpan(0, 7, 0, 0, 0)), 0, 406 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 413, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8948), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@406", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8949), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 414, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8960), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+407", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8961), new TimeSpan(0, 7, 0, 0, 0)), 0, 407 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 415, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@407", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8973), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 416, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8984), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+408", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8985), new TimeSpan(0, 7, 0, 0, 0)), 0, 408 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 417, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8996), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@408", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(8997), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 418, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9007), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+409", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9008), new TimeSpan(0, 7, 0, 0, 0)), 0, 409 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 419, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9018), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@409", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9019), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 420, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9030), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+410", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9030), new TimeSpan(0, 7, 0, 0, 0)), 0, 410 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 421, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9041), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@410", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9042), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 422, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9095), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+411", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9096), new TimeSpan(0, 7, 0, 0, 0)), 0, 411 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 423, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9109), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@411", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9110), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 424, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9121), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+412", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9122), new TimeSpan(0, 7, 0, 0, 0)), 0, 412 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 425, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9133), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@412", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9134), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 426, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9145), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+413", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9146), new TimeSpan(0, 7, 0, 0, 0)), 0, 413 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 427, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@413", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9158), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 428, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9169), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+414", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9170), new TimeSpan(0, 7, 0, 0, 0)), 0, 414 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 429, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9181), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@414", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9182), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 430, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9194), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+415", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9194), new TimeSpan(0, 7, 0, 0, 0)), 0, 415 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 431, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9206), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@415", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9209), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 432, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+416", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 47, DateTimeKind.Unspecified).AddTicks(9219), new TimeSpan(0, 7, 0, 0, 0)), 0, 416 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 433, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4566), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@416", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4569), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 434, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4594), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+417", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4595), new TimeSpan(0, 7, 0, 0, 0)), 0, 417 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 435, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4610), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@417", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4610), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 436, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4619), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+418", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4619), new TimeSpan(0, 7, 0, 0, 0)), 0, 418 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 437, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4626), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@418", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4627), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 438, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4634), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+419", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4635), new TimeSpan(0, 7, 0, 0, 0)), 0, 419 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 439, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4642), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@419", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4642), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 440, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4649), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+420", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4650), new TimeSpan(0, 7, 0, 0, 0)), 0, 420 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 441, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4657), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@420", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4657), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 442, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+421", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4665), new TimeSpan(0, 7, 0, 0, 0)), 0, 421 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 443, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4672), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@421", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4672), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 444, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4679), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+422", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4680), new TimeSpan(0, 7, 0, 0, 0)), 0, 422 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 445, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4686), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@422", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4687), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 446, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4694), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+423", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4694), new TimeSpan(0, 7, 0, 0, 0)), 0, 423 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 447, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4701), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@423", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4702), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 448, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4708), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+424", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4709), new TimeSpan(0, 7, 0, 0, 0)), 0, 424 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 449, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4716), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@424", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4716), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 450, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4723), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+425", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4723), new TimeSpan(0, 7, 0, 0, 0)), 0, 425 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 451, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4730), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@425", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4730), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 452, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4737), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+426", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4738), new TimeSpan(0, 7, 0, 0, 0)), 0, 426 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 453, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4744), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@426", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4745), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 454, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4751), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+427", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4752), new TimeSpan(0, 7, 0, 0, 0)), 0, 427 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 455, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4798), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@427", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4799), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 456, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4807), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+428", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4807), new TimeSpan(0, 7, 0, 0, 0)), 0, 428 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 457, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4814), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@428", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4815), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 458, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4822), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+429", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4822), new TimeSpan(0, 7, 0, 0, 0)), 0, 429 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 459, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4829), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@429", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4830), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 460, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4836), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+430", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4837), new TimeSpan(0, 7, 0, 0, 0)), 0, 430 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 461, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4844), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@430", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4844), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 462, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4851), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+431", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4852), new TimeSpan(0, 7, 0, 0, 0)), 0, 431 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 463, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4858), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@431", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4859), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 464, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4865), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+432", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4866), new TimeSpan(0, 7, 0, 0, 0)), 0, 432 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 465, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4873), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@432", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4873), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 466, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4880), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+433", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4881), new TimeSpan(0, 7, 0, 0, 0)), 0, 433 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 467, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4887), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@433", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4888), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 468, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+434", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4896), new TimeSpan(0, 7, 0, 0, 0)), 0, 434 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 469, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4902), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@434", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4903), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 470, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4909), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+435", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4910), new TimeSpan(0, 7, 0, 0, 0)), 0, 435 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 471, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4916), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@435", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4917), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 472, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4924), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+436", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4925), new TimeSpan(0, 7, 0, 0, 0)), 0, 436 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 473, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4931), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@436", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4932), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 474, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4939), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+437", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4939), new TimeSpan(0, 7, 0, 0, 0)), 0, 437 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 475, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4946), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@437", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4946), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 476, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+438", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(4953), new TimeSpan(0, 7, 0, 0, 0)), 0, 438 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 477, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5019), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@438", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5020), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 478, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5035), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+439", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5036), new TimeSpan(0, 7, 0, 0, 0)), 0, 439 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 479, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5049), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@439", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5050), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 480, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5061), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+440", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5062), new TimeSpan(0, 7, 0, 0, 0)), 0, 440 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 481, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5073), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@440", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5074), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 482, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5086), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+441", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5087), new TimeSpan(0, 7, 0, 0, 0)), 0, 441 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 483, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5099), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@441", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5099), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 484, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5111), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+442", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5112), new TimeSpan(0, 7, 0, 0, 0)), 0, 442 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 485, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5123), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@442", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5124), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 486, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5135), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+443", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5136), new TimeSpan(0, 7, 0, 0, 0)), 0, 443 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 487, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5147), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@443", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5148), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 488, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5160), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+444", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5161), new TimeSpan(0, 7, 0, 0, 0)), 0, 444 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 489, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5172), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@444", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 48, DateTimeKind.Unspecified).AddTicks(5177), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 490, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(734), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+445", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(738), new TimeSpan(0, 7, 0, 0, 0)), 0, 445 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 491, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(748), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@445", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(748), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 492, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+446", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(756), new TimeSpan(0, 7, 0, 0, 0)), 0, 446 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 493, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(763), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@446", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(764), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 494, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(771), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+447", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(772), new TimeSpan(0, 7, 0, 0, 0)), 0, 447 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 495, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(779), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@447", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(779), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 496, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(786), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+448", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(787), new TimeSpan(0, 7, 0, 0, 0)), 0, 448 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 497, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(794), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@448", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(794), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 498, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(801), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+449", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(802), new TimeSpan(0, 7, 0, 0, 0)), 0, 449 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 499, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(846), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@449", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(847), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 500, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(860), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+450", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(861), new TimeSpan(0, 7, 0, 0, 0)), 0, 450 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 501, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(873), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@450", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(874), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 502, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(885), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+451", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(886), new TimeSpan(0, 7, 0, 0, 0)), 0, 451 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 503, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(896), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@451", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(897), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 504, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(909), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+452", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(910), new TimeSpan(0, 7, 0, 0, 0)), 0, 452 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 505, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(922), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@452", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(922), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 506, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(934), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+453", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(935), new TimeSpan(0, 7, 0, 0, 0)), 0, 453 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 507, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(946), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@453", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(947), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 508, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+454", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(960), new TimeSpan(0, 7, 0, 0, 0)), 0, 454 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 509, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@454", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(972), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 510, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(984), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+455", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(985), new TimeSpan(0, 7, 0, 0, 0)), 0, 455 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 511, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(996), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@455", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(997), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 512, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(1009), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+456", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(1009), new TimeSpan(0, 7, 0, 0, 0)), 0, 456 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 513, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(1021), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@456", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(1021), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 514, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(1033), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+457", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(1034), new TimeSpan(0, 7, 0, 0, 0)), 0, 457 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 515, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(1045), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@457", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(1046), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 516, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(1057), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+458", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(1058), new TimeSpan(0, 7, 0, 0, 0)), 0, 458 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 517, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6344), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@458", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6346), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 518, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6369), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+459", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6370), new TimeSpan(0, 7, 0, 0, 0)), 0, 459 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 519, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6383), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@459", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6384), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 520, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+460", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6396), new TimeSpan(0, 7, 0, 0, 0)), 0, 460 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 521, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6408), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@460", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6409), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 522, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6473), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+461", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6474), new TimeSpan(0, 7, 0, 0, 0)), 0, 461 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 523, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6483), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@461", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6483), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 524, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6490), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+462", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6491), new TimeSpan(0, 7, 0, 0, 0)), 0, 462 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 525, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6498), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@462", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6498), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 526, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6505), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+463", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6506), new TimeSpan(0, 7, 0, 0, 0)), 0, 463 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 527, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6512), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@463", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6513), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 528, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6520), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+464", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6520), new TimeSpan(0, 7, 0, 0, 0)), 0, 464 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 529, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6527), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@464", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6528), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 530, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6534), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+465", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6535), new TimeSpan(0, 7, 0, 0, 0)), 0, 465 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 531, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6542), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@465", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6542), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 532, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6549), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+466", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6549), new TimeSpan(0, 7, 0, 0, 0)), 0, 466 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 533, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6556), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@466", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6557), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 534, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6563), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+467", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6564), new TimeSpan(0, 7, 0, 0, 0)), 0, 467 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 535, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@467", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6571), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 536, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6578), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+468", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6578), new TimeSpan(0, 7, 0, 0, 0)), 0, 468 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 537, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6585), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@468", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6586), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 538, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6592), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+469", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6593), new TimeSpan(0, 7, 0, 0, 0)), 0, 469 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 539, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6600), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@469", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6600), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 540, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6607), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+470", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6607), new TimeSpan(0, 7, 0, 0, 0)), 0, 470 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 541, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6614), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@470", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6615), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 542, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6621), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+471", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6622), new TimeSpan(0, 7, 0, 0, 0)), 0, 471 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 543, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6628), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@471", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6629), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 544, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+472", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6665), new TimeSpan(0, 7, 0, 0, 0)), 0, 472 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 545, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6672), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@472", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6673), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 546, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+473", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6681), new TimeSpan(0, 7, 0, 0, 0)), 0, 473 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 547, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6687), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@473", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6688), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 548, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6695), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+474", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6695), new TimeSpan(0, 7, 0, 0, 0)), 0, 474 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 549, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6702), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@474", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6703), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 550, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6710), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+475", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6711), new TimeSpan(0, 7, 0, 0, 0)), 0, 475 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 551, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6718), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@475", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6718), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 552, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6725), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+476", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6726), new TimeSpan(0, 7, 0, 0, 0)), 0, 476 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 553, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6733), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@476", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6733), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 554, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6740), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+477", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6741), new TimeSpan(0, 7, 0, 0, 0)), 0, 477 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 555, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6747), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@477", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6748), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 556, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+478", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6755), new TimeSpan(0, 7, 0, 0, 0)), 0, 478 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 557, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@478", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6763), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 558, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+479", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6770), new TimeSpan(0, 7, 0, 0, 0)), 0, 479 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 559, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6776), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@479", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6777), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 560, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6784), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+480", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6784), new TimeSpan(0, 7, 0, 0, 0)), 0, 480 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 561, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6791), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@480", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6792), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 562, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6798), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+481", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6799), new TimeSpan(0, 7, 0, 0, 0)), 0, 481 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 563, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6806), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@481", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6807), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 564, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6813), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+482", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6814), new TimeSpan(0, 7, 0, 0, 0)), 0, 482 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 565, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6821), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@482", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6822), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 566, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6867), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+483", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6868), new TimeSpan(0, 7, 0, 0, 0)), 0, 483 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 567, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6881), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@483", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6882), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 568, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6893), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+484", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6894), new TimeSpan(0, 7, 0, 0, 0)), 0, 484 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 569, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@484", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6906), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 570, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6917), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+485", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6918), new TimeSpan(0, 7, 0, 0, 0)), 0, 485 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 571, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6929), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@485", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6930), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 572, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+486", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6943), new TimeSpan(0, 7, 0, 0, 0)), 0, 486 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 573, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6955), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@486", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 49, DateTimeKind.Unspecified).AddTicks(6955), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 574, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(1975), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+487", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(1992), new TimeSpan(0, 7, 0, 0, 0)), 0, 487 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 575, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2099), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@487", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2101), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 576, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2119), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+488", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2120), new TimeSpan(0, 7, 0, 0, 0)), 0, 488 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 577, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2134), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@488", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2135), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 578, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2148), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+489", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2149), new TimeSpan(0, 7, 0, 0, 0)), 0, 489 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 579, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2161), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@489", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2162), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 580, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+490", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2175), new TimeSpan(0, 7, 0, 0, 0)), 0, 490 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 581, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2186), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@490", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2187), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 582, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2199), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+491", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2200), new TimeSpan(0, 7, 0, 0, 0)), 0, 491 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 583, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@491", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2213), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 584, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2224), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+492", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2225), new TimeSpan(0, 7, 0, 0, 0)), 0, 492 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 585, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2237), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@492", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2238), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 586, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2249), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+493", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2250), new TimeSpan(0, 7, 0, 0, 0)), 0, 493 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 587, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2263), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@493", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2264), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 588, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2399), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+494", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2400), new TimeSpan(0, 7, 0, 0, 0)), 0, 494 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 589, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@494", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2424), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 590, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+495", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2437), new TimeSpan(0, 7, 0, 0, 0)), 0, 495 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 591, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2449), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@495", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2450), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 592, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2461), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+496", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2462), new TimeSpan(0, 7, 0, 0, 0)), 0, 496 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 593, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2473), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@496", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2474), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 594, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2485), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+497", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2486), new TimeSpan(0, 7, 0, 0, 0)), 0, 497 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 595, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2497), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@497", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2498), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 596, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+498", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2511), new TimeSpan(0, 7, 0, 0, 0)), 0, 498 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 597, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2523), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@498", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2523), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 598, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2535), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+499", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2536), new TimeSpan(0, 7, 0, 0, 0)), 0, 499 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 599, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@499", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2549), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, true });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "title", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3939), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, "What is Lorem Ipsum?", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3941), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3950), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, "Why do we use it?", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3951), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, "Where does it come from?", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3954), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3956), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, "Where can I get some?", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3956), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4159), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4160), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4165), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4166), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4168), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4169), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2973), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2974), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3062), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3063), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3105), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3107), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2583), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2584), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2609), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2610), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2724), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2725), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trip_rate", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "rating", "status", "suddenly_cancelled_trips", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 0.0, new Guid("2986de67-865a-40fe-8bd8-360b6b441277"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3426), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, 1, "Quach Dai Loi", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3428), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 0.0, new Guid("efe9eef2-e2ce-4119-8ad3-8178d58b2558"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3469), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, 1, "Do Trong Dat", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3486), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 0.0, new Guid("ed87df27-9251-401e-9b39-390cf8480fc2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 3, 1, "Nguyen Dang Khoa", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3542), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 0.0, new Guid("ecfcc259-b6cb-4d50-88ea-ac1e8bb00d3e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3566), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 4, 1, "Than Thanh Duy", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3567), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 0.0, new Guid("a51d119d-bf23-426e-8861-926dfb2990bc"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3582), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 5, 1, "Loi Quach", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3583), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 0.0, new Guid("c47128b7-ad41-4616-aea9-b041c893ca99"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3661), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 6, 1, "Dat Do", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3662), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 0.0, new Guid("8996408d-9f5d-48c4-94ae-e7031ffffd08"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 7, 1, "Khoa Nguyen", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3676), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 0.0, new Guid("16affa47-d31b-4042-befe-280b7ffc2cf4"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3690), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 8, 1, "Thanh Duy", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3691), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 0.0, new Guid("0a9f9b55-d730-4f9f-852a-df5b5b5b4bbc"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3779), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 13, 1, "Admin Quach Dai Loi", null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 42, DateTimeKind.Unspecified).AddTicks(3780), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 400, new Guid("11f4c680-a581-4456-9d45-05f6b2ca1b5d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4619), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.400", "Vehicle 400", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4620), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, 3 },
                    { 401, new Guid("1de5b4c4-9cdc-4c54-bfaa-68e19392a732"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4634), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.401", "Vehicle 401", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4635), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, 3 },
                    { 402, new Guid("29e33836-10d8-49fe-8bd7-8a38a4033a95"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4645), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.402", "Vehicle 402", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4646), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, 3 },
                    { 403, new Guid("37844a6d-5024-4d22-9111-c37c6f1d1153"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4650), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.403", "Vehicle 403", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4651), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, 3 },
                    { 404, new Guid("e810c102-1079-4941-9b3a-9241c4fb63c1"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4655), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.404", "Vehicle 404", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4656), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, 3 },
                    { 405, new Guid("ac067e50-91f7-4a32-b957-300f070eca98"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4662), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.405", "Vehicle 405", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4662), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, 3 },
                    { 406, new Guid("b79f9b37-8bb9-41fd-97e3-e2012c153443"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4667), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.406", "Vehicle 406", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4668), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, 3 },
                    { 407, new Guid("5a0e07ec-d742-4be5-b414-756ad7247fbb"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4672), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.407", "Vehicle 407", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4673), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, 3 },
                    { 408, new Guid("b05d05f3-e2aa-478e-a611-af78dfa0b300"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4677), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.408", "Vehicle 408", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4678), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, 3 },
                    { 409, new Guid("d3c82976-151d-4261-9cad-9f0c09bf2552"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4682), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.409", "Vehicle 409", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4683), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, 3 },
                    { 410, new Guid("6148a59f-30a8-4c1a-8dc1-524ae32e7ade"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4690), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.410", "Vehicle 410", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4691), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, 3 },
                    { 411, new Guid("6db6634c-0ff1-47a3-8450-9f31507c7d6a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4695), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.411", "Vehicle 411", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4696), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, 3 },
                    { 412, new Guid("8b230bd5-905b-4765-baf4-3ba23d981fb0"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4747), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.412", "Vehicle 412", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4748), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, 3 },
                    { 413, new Guid("0b1eb864-ddfc-488f-a49e-94de2dabfadf"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4753), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.413", "Vehicle 413", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4754), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, 3 },
                    { 414, new Guid("9a5a5aae-d90d-4164-8dbc-3b9d65b34e92"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4758), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.414", "Vehicle 414", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4759), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, 3 },
                    { 415, new Guid("5e8ee487-7472-4a2d-8be1-b0d997eea2f2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4763), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.415", "Vehicle 415", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4764), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, 3 },
                    { 416, new Guid("d361ec72-143c-42de-857a-641f2fd7324c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4768), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.416", "Vehicle 416", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4769), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, 3 },
                    { 417, new Guid("1f71b35a-085a-4f51-ae86-8fdd52da0321"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4774), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.417", "Vehicle 417", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4775), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, 3 },
                    { 418, new Guid("14eef0f5-c520-4b1c-85fb-13e5539d006f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4782), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.418", "Vehicle 418", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4783), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, 3 },
                    { 419, new Guid("e12f6cdc-7eb6-4fce-a5e5-9c2db258452f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4787), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.419", "Vehicle 419", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4788), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, 3 },
                    { 420, new Guid("0febb041-817e-4636-884b-2284bad89157"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4792), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.420", "Vehicle 420", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4793), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, 3 },
                    { 421, new Guid("ab6bc8f5-8f2f-4a4d-ab22-f146b2c814e4"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4797), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.421", "Vehicle 421", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4798), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, 3 },
                    { 422, new Guid("8c86d160-9b11-4b17-bc26-440a64903e2d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4802), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.422", "Vehicle 422", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4803), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, 3 },
                    { 423, new Guid("661ba628-d665-420d-9c2a-b4515b899b6f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4808), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.423", "Vehicle 423", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4809), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, 3 },
                    { 424, new Guid("e16a9d65-122e-4d42-a464-5914e50e6544"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4813), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.424", "Vehicle 424", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4814), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, 3 },
                    { 425, new Guid("6ae8d32d-f1c9-45cc-85e5-47a30829d828"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.425", "Vehicle 425", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4819), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, 3 },
                    { 426, new Guid("da12c4eb-c2d9-4fa6-a823-9c68e37bde48"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4826), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.426", "Vehicle 426", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4826), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, 3 },
                    { 427, new Guid("6f1cd696-5304-4c02-93f8-b42c12305c78"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4830), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.427", "Vehicle 427", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4831), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, 3 },
                    { 428, new Guid("8f8be951-ccb7-4875-99c3-b1bdf028fcca"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4835), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.428", "Vehicle 428", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4836), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, 3 },
                    { 429, new Guid("c803e916-0ebb-4ee8-900a-087fadf8340c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4842), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.429", "Vehicle 429", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4843), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, 3 },
                    { 430, new Guid("a74b7264-8da0-4cac-9516-bdd6ff9d334b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.430", "Vehicle 430", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4848), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, 3 },
                    { 431, new Guid("cf770153-81b5-4b17-a19a-74d112d692a1"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4852), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.431", "Vehicle 431", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4853), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, 3 },
                    { 432, new Guid("1a06ce18-b4be-4b53-85cf-14fd7743d8a3"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4858), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.432", "Vehicle 432", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4859), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, 3 },
                    { 433, new Guid("a14e0761-64b9-4005-8714-ac1d44436e88"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4863), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.433", "Vehicle 433", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4864), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, 3 },
                    { 434, new Guid("b921aeed-63d9-4797-92ae-90697eaae464"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.434", "Vehicle 434", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4872), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, 3 },
                    { 435, new Guid("a26f73d8-7e79-427d-ba67-15ce163d1b76"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4876), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.435", "Vehicle 435", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4877), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, 3 },
                    { 436, new Guid("1b2a8338-d7bb-42fa-b778-9e9ca82e94ed"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4881), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.436", "Vehicle 436", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4882), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, 3 },
                    { 437, new Guid("abaf0714-f179-44e3-93fa-d0d7eb2f00c9"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4886), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.437", "Vehicle 437", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4887), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, 3 },
                    { 438, new Guid("2beb47fb-f1ac-4688-8735-13134345311e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4891), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.438", "Vehicle 438", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4892), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, 3 },
                    { 439, new Guid("8dbb74cb-23ae-45e6-9bb5-b825735eb966"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4896), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.439", "Vehicle 439", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4897), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, 3 },
                    { 440, new Guid("ac49254f-c251-4e80-bee9-c6f9a30f7ab2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4901), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.440", "Vehicle 440", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4902), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, 3 },
                    { 441, new Guid("911da1af-d43f-4369-975b-f6dac9286ff9"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4906), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.441", "Vehicle 441", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4906), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, 3 },
                    { 442, new Guid("3dcd7a2a-9db3-4d99-91f7-8b5d67293ae7"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4945), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.442", "Vehicle 442", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4946), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, 3 },
                    { 443, new Guid("854467c9-5dd6-4160-bbbd-49f1dc318f84"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4952), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.443", "Vehicle 443", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4953), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, 3 },
                    { 444, new Guid("34761624-9439-4fa9-9099-caf35eb8d715"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4957), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.444", "Vehicle 444", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4958), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, 3 },
                    { 445, new Guid("28ef5f27-1f18-4685-b3b7-88a061bea879"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.445", "Vehicle 445", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4963), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, 3 },
                    { 446, new Guid("c07a969b-24d7-479e-b544-33e2d6d3dad3"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4967), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.446", "Vehicle 446", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4968), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, 3 },
                    { 447, new Guid("19bdfc7b-c345-4de5-a0ea-6f4db98e6261"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.447", "Vehicle 447", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4972), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, 3 },
                    { 448, new Guid("5939112d-e816-4770-8df9-3fa84eb849d7"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.448", "Vehicle 448", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4977), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, 3 },
                    { 449, new Guid("e5272315-0e35-4a4c-bd59-624416e8d9ea"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4981), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.449", "Vehicle 449", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4982), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, 3 },
                    { 450, new Guid("ff7b293b-3aa0-4e3a-ae52-c9747dad7e9c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4988), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.450", "Vehicle 450", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4989), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, 3 },
                    { 451, new Guid("e71696a6-585c-449a-8203-595d0ed55630"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4993), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.451", "Vehicle 451", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4994), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, 3 },
                    { 452, new Guid("5ee18130-2503-4ef4-ae8d-d6baccca3b50"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4999), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.452", "Vehicle 452", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5000), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, 3 },
                    { 453, new Guid("93f04042-f5ea-4ef4-81a3-167f80da905b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5004), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.453", "Vehicle 453", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5004), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, 3 },
                    { 454, new Guid("414c12bd-a1f2-49e6-890c-e24b8e4af17c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5008), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.454", "Vehicle 454", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5009), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, 3 },
                    { 455, new Guid("354ade34-ee2e-43a5-b4bc-0e077aee9fdb"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5013), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.455", "Vehicle 455", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5014), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, 3 },
                    { 456, new Guid("20f8cd1a-fd33-48e8-9a3d-9dd70f1812cb"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5018), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.456", "Vehicle 456", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5018), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, 3 },
                    { 457, new Guid("6e711f35-d867-4694-8089-181e6e101256"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5022), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.457", "Vehicle 457", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5023), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, 3 },
                    { 458, new Guid("fdcecad3-8352-4137-b233-749f0c44dbc8"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5030), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.458", "Vehicle 458", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5031), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, 3 },
                    { 459, new Guid("055beb99-2faf-4353-b29b-abd5ed070234"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5035), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.459", "Vehicle 459", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5036), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, 3 },
                    { 460, new Guid("2d9c4a4f-b8df-46ec-9fca-bda5092fcbd7"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5040), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.460", "Vehicle 460", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5042), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, 3 },
                    { 461, new Guid("c1e7779f-c0c0-4ebe-848f-1c70ff224f1f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5047), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.461", "Vehicle 461", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5048), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, 3 },
                    { 462, new Guid("eeac45f0-9a9e-4c71-8f88-f1441a9555b2"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5052), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.462", "Vehicle 462", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5053), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, 3 },
                    { 463, new Guid("6487ca20-05c2-46f5-8e5f-cad0c59f53fd"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5057), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.463", "Vehicle 463", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5058), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, 3 },
                    { 464, new Guid("690fb228-6fad-40c7-a208-15b28871ee0d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5062), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.464", "Vehicle 464", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5063), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, 3 },
                    { 465, new Guid("2db5435d-c11c-4de4-bd78-296b2fbb6287"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5068), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.465", "Vehicle 465", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5068), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, 3 },
                    { 466, new Guid("4bf5e33d-0998-4ce7-bd7f-736a0e90519d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5075), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.466", "Vehicle 466", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5076), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, 3 },
                    { 467, new Guid("977659bf-7bae-4e01-8697-32cc2becef20"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5080), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.467", "Vehicle 467", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5081), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, 3 },
                    { 468, new Guid("f6e4dacd-6e6e-4ecd-a149-bf7dd3d3c534"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5086), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.468", "Vehicle 468", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5086), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, 3 },
                    { 469, new Guid("f1af0ce4-2b44-477e-83d5-34a74971856d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5091), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.469", "Vehicle 469", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5091), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, 3 },
                    { 470, new Guid("bec27b17-2a91-443a-aa5c-b642e8aaa34e"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5095), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.470", "Vehicle 470", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5096), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, 3 },
                    { 471, new Guid("5b301a24-1589-4d42-9016-017b3e40d3fb"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5100), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.471", "Vehicle 471", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5101), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, 3 },
                    { 472, new Guid("71bdb4c8-7fe8-48d8-a28b-be52c06685ba"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.472", "Vehicle 472", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5145), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, 3 },
                    { 473, new Guid("dab601c5-e751-4226-ba8a-e0490287ae8c"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5150), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.473", "Vehicle 473", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5151), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, 3 },
                    { 474, new Guid("0cccebc8-44ef-4430-b6b9-6ec22322943a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5158), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.474", "Vehicle 474", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5158), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, 3 },
                    { 475, new Guid("77031c12-7521-45ff-9295-1b395fc45d25"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5162), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.475", "Vehicle 475", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5163), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, 3 },
                    { 476, new Guid("31245750-eedd-4164-92aa-efdd2ed3a0f3"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.476", "Vehicle 476", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5168), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, 3 },
                    { 477, new Guid("b222c389-0352-4532-845e-3df17ad26f37"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5172), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.477", "Vehicle 477", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5173), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, 3 },
                    { 478, new Guid("86350db0-b791-4b7e-b825-6245f8340586"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5177), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.478", "Vehicle 478", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5178), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, 3 },
                    { 479, new Guid("bc5b8dc0-4dff-4da5-b0e4-93ef450b0d6a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5182), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.479", "Vehicle 479", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5183), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, 3 },
                    { 480, new Guid("08c879fd-e8a3-4aea-8bb0-544d6b15bcbd"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5186), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.480", "Vehicle 480", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5187), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, 3 },
                    { 481, new Guid("6c962e24-a73f-4123-b172-2613b47297c0"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5191), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.481", "Vehicle 481", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5192), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, 3 },
                    { 482, new Guid("e7d27c61-5f8c-4499-bfde-fa0e37b33a43"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5198), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.482", "Vehicle 482", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5199), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, 3 },
                    { 483, new Guid("939816d7-6912-4280-8354-53b0641a9668"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5203), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.483", "Vehicle 483", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5204), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, 3 },
                    { 484, new Guid("574fc472-3eeb-4684-9ec1-404a471eea52"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5208), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.484", "Vehicle 484", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5209), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, 3 },
                    { 485, new Guid("96612843-8d3f-4f07-89a2-96f4fc82e105"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5213), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.485", "Vehicle 485", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5214), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, 3 },
                    { 486, new Guid("99ab3657-5e32-40c0-9f22-2a241aebf818"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5219), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.486", "Vehicle 486", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5219), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, 3 },
                    { 487, new Guid("45f72c57-d7a1-492a-adf7-9c365deb169d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5224), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.487", "Vehicle 487", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5225), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, 3 },
                    { 488, new Guid("d0eb929b-781e-4fcd-b66d-a8fb06488271"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5229), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.488", "Vehicle 488", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5230), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, 3 },
                    { 489, new Guid("ff016457-235d-48fd-8aa7-4d80caf5952d"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5234), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.489", "Vehicle 489", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5235), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, 3 },
                    { 490, new Guid("77a3bb8d-5f66-499e-8b5d-f03ba1ec8cc0"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5242), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.490", "Vehicle 490", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5242), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, 3 },
                    { 491, new Guid("b8f04798-2bea-4d77-b8bf-b86689823a10"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5247), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.491", "Vehicle 491", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5248), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, 3 },
                    { 492, new Guid("9172e805-b17b-4374-a687-5ceaf5a7f872"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5252), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.492", "Vehicle 492", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5253), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, 3 },
                    { 493, new Guid("a61d2486-eb58-487b-8bfa-06baafa6ae18"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.493", "Vehicle 493", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5258), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, 3 },
                    { 494, new Guid("e715ff25-3621-41bd-836e-6674578d436b"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5262), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.494", "Vehicle 494", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5263), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, 3 },
                    { 495, new Guid("6ae57442-2bdc-446c-b0c4-1ef1a371cfc0"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.495", "Vehicle 495", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5268), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, 3 },
                    { 496, new Guid("9a0881ec-d80b-4a00-8cd8-5bba9c6aac63"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5272), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.496", "Vehicle 496", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5273), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, 3 },
                    { 497, new Guid("c774b919-f1b5-4faa-977d-daa5e3f7a2ed"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5277), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.497", "Vehicle 497", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5278), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, 3 },
                    { 498, new Guid("10f7c562-1f7f-4c2d-9acd-d64dad55c756"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5285), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.498", "Vehicle 498", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5286), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, 3 },
                    { 499, new Guid("c9cc08fc-3c0a-48a9-bded-abb7f6c49e47"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5290), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.499", "Vehicle 499", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5291), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, 3 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9545), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 44, DateTimeKind.Unspecified).AddTicks(9546), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(4914), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(4918), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(4933), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(4934), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(4941), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(4941), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(4948), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(4948), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(4959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(4960), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(4968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(4968), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(4975), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(4975), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(4981), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(4982), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(4990), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(4990), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(4997), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(4997), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5039), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5040), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5049), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5050), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5056), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5057), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5065), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5065), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5072), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5072), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5079), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5079), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5087), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 45, DateTimeKind.Unspecified).AddTicks(5088), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "ceiling_extra_price", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4205), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4206), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4286), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4287), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4300), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4301), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4312), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4313), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4326), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4327), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4397), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4412), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4413), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4425), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4426), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4475), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4476), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4490), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4491), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4502), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4503), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4514), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4515), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4527), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4528), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "notifications",
                columns: new[] { "id", "code", "created_at", "created_by", "data", "deleted_at", "description", "event_id", "status", "type", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, new Guid("f535dfa6-75d5-4204-9b18-8bb90298cc99"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5686), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 2, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5687), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 2, new Guid("72d1f07f-6c26-4315-93c9-f6c422157ad8"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5736), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 1, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5737), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 3, new Guid("282a5582-a94e-41f0-9d9e-1903d3a5a4e1"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5745), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 3, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5746), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 4, new Guid("20a9e295-da9a-4dc7-b9db-3a4f8c081a79"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5750), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 3, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5751), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 5, new Guid("c2b481eb-21b2-46b6-802e-b476f2076aa5"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5758), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 6, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5758), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 6, new Guid("f62dc849-847f-4118-bc00-6d5d49541cb8"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5763), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 1, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5764), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 7, new Guid("a8138d73-4392-4e60-83b8-ae3587d78b08"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5811), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 4, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5812), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, new Guid("e8d46b20-e5ac-42cd-870e-38d8486c902a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5816), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 1, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5817), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 9, new Guid("53a48636-762b-4ee5-baf0-4bbcc6aebd5f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5823), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 2, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5824), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 10, new Guid("d6b74ea0-1439-4b7e-b6a0-1ffcc4dade6f"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5829), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 2, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5830), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2933), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(2935), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3142), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3234), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3235), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3270), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3271), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3292), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3293), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3314), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(3315), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, new Guid("ec93d670-a295-4e18-8800-a8c2dff35448"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4596), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4598), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("ba9ff1ab-2486-48d3-ac35-1897e234ebec"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4609), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4610), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("293fa5cb-2f3f-4751-8cf5-d85f2202f020"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4613), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4613), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("015d0d10-f655-446d-a6c7-ae734d965f2a"), new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4616), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(4617), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5527), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5528), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5536), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5538), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5540), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5542), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5543), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5545), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5546), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5549), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5551), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5552), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5553), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 13, 16, 12, 51, 50, DateTimeKind.Unspecified).AddTicks(5554), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
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
