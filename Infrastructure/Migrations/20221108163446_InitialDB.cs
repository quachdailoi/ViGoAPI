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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("37f7ca64-cd7c-438d-8ae9-1212ee182582")),
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 252, DateTimeKind.Unspecified).AddTicks(7660), new TimeSpan(0, 7, 0, 0, 0))),
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("69790a1b-9846-43ec-9651-26050f6ba3e1")),
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
                    { 1, new Guid("65aa4c42-6bc6-4c0e-8f62-41a1f74193de"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6252), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6253), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("ca6d9171-efc3-498c-baef-a9b0ee854a73"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6263), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6264), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("53cd3e11-2c98-4d08-b8f6-2a91e02da717"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6258), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6258), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "path", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("94e9ea37-344e-4ca0-9c47-6f66b49ed07b"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4364), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("14e25612-d7df-4128-b615-c67513934da1"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4379), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4379), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("2f5bedcd-50bb-403d-95ab-b9581056ac1a"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4390), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4391), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("a35112a1-64a3-4522-8baf-89bce8c9ca03"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4412), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("c5e5dcd9-d873-4d40-a631-c0c1346182b4"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4422), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4423), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("e0e424ff-2f51-4a37-a189-4f9f04bfbc7b"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4437), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("1986a650-dba0-486a-99b6-69beba397158"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4447), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4447), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("3c3d043b-6ceb-4ffb-af99-fd91eef76e11"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4458), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("699b0136-8032-4361-823f-a1d5f662a9b8"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4469), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("eeffe7c1-55dd-439d-8e52-e1460789d70c"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4480), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4481), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("5010711d-7cc4-4276-bbd4-05ebeeb34ec8"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4491), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4492), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("2300d19d-4a04-47e5-985e-1a59eb0c7a93"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4505), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4505), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("20f9b8b3-51d8-468b-b65a-8025f254fc67"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4516), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4516), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "pricings",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "discount", "lower_bound", "updated_at", "updated_by", "upper_bound" },
                values: new object[,]
                {
                    { 1, new Guid("503a74f7-9e1a-445f-9d33-24e019eeb88f"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6372), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.0, null, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6373), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 2, new Guid("8c318f27-792e-44ff-ae05-20c751a7e96f"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6377), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.029999999999999999, 8, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6378), new TimeSpan(0, 7, 0, 0, 0)), 0, 30 },
                    { 3, new Guid("22545306-b35f-4246-ab01-1a69afaa11ea"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.050000000000000003, 31, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6380), new TimeSpan(0, 7, 0, 0, 0)), 0, 90 },
                    { 4, new Guid("7834f11f-8971-4eea-9a7b-b5dc8166be6d"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6382), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.070000000000000007, 91, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6383), new TimeSpan(0, 7, 0, 0, 0)), 0, null }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3917), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3918), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3926), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3927), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3935), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3936), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 4, "TradeDiscount", "0.2" }
                });

            migrationBuilder.InsertData(
                table: "stations",
                columns: new[] { "id", "address", "code", "created_at", "created_by", "deleted_at", "latitude", "longitude", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("10468017-ddfa-4b1c-9429-5eb9c1e24d16"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4347), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4348), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a08c3126-1f6a-48f6-8db9-fbb529c45741"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4353), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4353), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f9e7aea4-4f9f-45d7-9f39-98085d3899ff"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4356), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4357), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2a512bed-c956-49cf-be20-b0db10bd9b03"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4359), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4360), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fe0418d3-3959-4434-a50e-bd217e84aef3"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4362), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4362), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dcadd450-4efb-416e-8237-9e2adc504784"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4366), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4367), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("372500a2-e0b0-44ec-b6e4-0375a690e03f"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4374), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4374), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("46cec0b3-be4b-4bd4-8127-631e73c87c3f"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4377), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4378), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("20ea946c-18fc-4853-8b13-a27618f4d3c6"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4381), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4381), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("42360592-f4e5-41b6-b01f-7c8b072e851a"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4384), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4385), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e5eacc65-6a79-4a61-b953-8510ac394966"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4387), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4388), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1aa934eb-b7db-41c5-b4e4-7ed3a01fa7ce"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4390), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4391), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6d2585bd-f82e-4739-8fce-8c0054d39643"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4393), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4393), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("70cfa35d-ce22-4100-aebd-f84c3d081de8"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4396), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bcdcc8ca-fdc5-4977-ba08-0b9bdb48226d"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4401), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4402), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ccbe7804-1c8e-4525-bb9d-548076763119"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4404), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("41b76dd7-9307-4856-84b1-5dd66813ba7e"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4407), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4407), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2be9033f-0bdc-4f27-ad93-f4977bac7db9"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4410), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4411), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3c6ad829-903a-4a83-b8fd-52aefe460b27"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4413), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4414), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f7ae1357-6a83-45fc-9807-59b0ca0a9cba"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4416), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4417), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d98e941f-edfd-4594-a2f1-15acd85f84ad"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4419), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4419), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("38047da3-2a1d-4465-94b4-d49e5f921193"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4422), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4422), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e32761db-75dc-4481-82c9-b12eabf9d6ee"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4430), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4430), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a7b4fa4a-54ee-48eb-8ad4-bd4cbb2b022a"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4432), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4433), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("99f0d290-f367-4911-b46b-3e46729b33b6"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4435), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4436), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2d62020a-6268-4982-8cea-c96c2225541b"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4438), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4439), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cc088f2a-e980-4c07-b760-3d86f5999a1d"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4441), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4441), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("020f8249-32ae-482d-9276-c12cebd21bac"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4443), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4444), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4b2a6dca-9b47-4598-a4f6-cbda827a02b0"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4446), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4447), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7b78644c-f332-4619-81a0-9787f72dce8f"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4451), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4452), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3ee1ec95-fca3-48e9-8f72-672dbb2bc91e"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4455), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4456), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bdd3d555-bb4d-44d7-9c5d-87b35498bc6a"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4458), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("efda2dd0-f842-4bd4-8406-82dcdd128203"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4520), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4520), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8885e2be-e120-4fe9-a4e5-e4dffd7cf1e3"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4523), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4524), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9dbf8455-6853-4492-9337-c98b6bdc4631"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4526), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4527), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c7893dd4-3d24-4306-a19e-e12e8418132b"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4529), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4529), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("243d489f-7464-4c00-8e16-d9bb7b436cec"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4531), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4532), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3eae66b3-18ea-46d3-b86f-72f3b1cd7d77"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4537), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4538), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a9614f80-835f-4946-9181-e2840be3c94a"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4540), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bd75dbd8-a1ee-4346-91d4-d34385063992"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4542), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4543), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e17ebee5-5fb5-4b59-8fa8-c3f24361c7a2"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4545), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4546), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1d5bc27b-8403-4d08-a72e-6e179eb1ad42"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4549), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("fa66e975-bc8b-4ab3-bc76-4b5810508907"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4551), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4551), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("2ee222d2-ec7b-46f4-9667-c8ac723370c1"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4553), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4554), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4e722306-0042-486b-97be-ed6e37a772d1"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4556), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4557), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("91385f4c-d67e-455d-9b28-82abea054dfc"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4562), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4562), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a2c5e4c0-0922-4832-a58b-f13d07363434"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4564), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4565), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("664494de-4679-4c2a-b6a2-c04f93db9078"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4567), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4568), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("10516514-dc1d-4881-9ccd-105374c764eb"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4570), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4570), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("af8090e0-8562-4adc-8944-27d28fe7310a"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4573), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2b717485-1ee0-4592-a041-27698d3d0abc"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4575), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4576), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7f05f40e-adfe-4b5f-89e2-7bc19a7a12c5"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4578), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4578), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2eef65b7-b2f8-434d-84de-72be0e99b390"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4580), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4581), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("34b43f6b-087d-4bab-9c88-237986f52203"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5030), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5031), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f2ed925f-633a-4b22-b94a-db2dece52788"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5034), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5035), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("df0f2c51-6df9-4973-a90d-8ddcfb5be7d6"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5037), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5037), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6ab2abea-fcc1-4d28-a27a-7dc6e964d6d3"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5040), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5040), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("71a0a555-96b3-4f34-a38c-1827de6d870e"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5042), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5043), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1b026d9c-7475-449a-b530-c40fe8e811d6"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5045), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5046), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a140af61-4537-4c6b-bd23-75a074cb54f3"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5048), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5048), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("25235276-fd83-4fa5-865c-0bc33d8f77ab"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5051), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5051), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("78f60fa0-e46b-443a-acd1-71c1fc83aed3"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5056), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5056), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d92fbc50-e1c9-4399-865f-56c106cf4201"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5059), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5059), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d0c2eb47-fd7c-4d07-a541-cfefac84d7b1"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5061), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5062), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b66974cf-4ac7-47df-93e5-aaa068c5daf7"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5066), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5067), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4ab1e38e-5f64-4ebc-8c14-6d13b30bbf2d"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5069), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5069), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ffdd9855-1047-4e7c-b457-12035349a764"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5071), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5072), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2ad05857-6813-4a29-a69d-129b99479b3d"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5074), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5075), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b9f93712-f3a2-4806-8606-4ca579e540df"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5077), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5078), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("30f9e8e5-21a0-42a6-985f-6662fc014450"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5082), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5083), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("bfd82b3c-342b-4c6c-bc75-118d5013a610"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5123), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5123), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f6aef0ba-03eb-45dc-bac6-bdd6721ed6c7"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5126), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5126), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("016b876d-f787-4997-8a98-db51126605c3"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5129), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("112c1af1-cea0-42c2-bc31-4fcd52dbdc83"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5131), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5132), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dfdc0861-452f-4551-9c53-d45e2e960828"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5134), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5135), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("19e982e8-23a2-48c6-b51f-9d82de0fcc44"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5137), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5137), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4f82d1ee-8e62-484b-8533-ac111c982024"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5140), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5141), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("145f2d1c-fd3e-416d-b5c5-dcfb65a2dfc2"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5145), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5146), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("46f824ba-83a6-4592-bcc0-8e6673fe6760"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5148), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5149), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("20495262-538c-4091-a977-7eb577b6a21b"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5151), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5151), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("241c125d-89c7-4d6d-b7ee-979319b033b7"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5154), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5155), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("336b06bc-bf6c-4cda-9e4f-adc71eb2592e"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5157), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("f31c1402-18ab-4200-b43b-6cbbfcc2beae"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5159), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5160), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("3877dff1-a7b2-42d7-aabc-c9bdbeb25985"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5162), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5163), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8d93f283-f7d6-4396-8a50-c4b016457ac1"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4427), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4427), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô E2a-10 Đường, D2b Đ. D1, TP. Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam", new Guid("34d5c9d0-83d5-404d-98b3-39c447b44f55"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5165), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5166), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 10, new Guid("f85de0ca-5b98-4369-9f81-829443323932"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4719), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4720), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("d24a1c08-e04c-45aa-9223-da6a70a13881"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4733), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4733), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("ca26f2f3-391d-421d-9033-b2a2234e9ae0"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4748), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4749), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 100, new Guid("1e9bb12a-53c2-41ff-960f-3ad37e20d734"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 100", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4762), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 101, new Guid("30d77c10-d4c7-4fda-80c8-719fcba2022f"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4856), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 101", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4857), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 102, new Guid("92b443f2-a487-4a77-83ad-143781c8a887"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4872), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 102", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4873), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 103, new Guid("3a58b39f-d2ae-43c1-a1ab-3c0adf6cf18b"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4889), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 103", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4890), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 104, new Guid("748d58d0-aa0a-4e86-a043-70d0712da90d"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4903), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 104", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4904), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 105, new Guid("0ce5a32d-36aa-4106-b1d1-444cd660bbfb"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4918), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 105", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4919), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 106, new Guid("50f47ec5-17c1-4093-8cba-ea0b384127c8"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4932), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 106", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4933), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 107, new Guid("667c3bb2-bbb0-4f6f-9917-2a5999abbfcf"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4948), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 107", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4949), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 108, new Guid("430a8884-ef50-427d-962d-3d7149cd3403"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4963), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 108", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4963), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 109, new Guid("1facbdd1-7fdb-4b94-b1b8-de318500888f"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 109", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4977), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 110, new Guid("65855c14-068c-4920-9900-558d15978c09"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4990), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 110", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4991), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 111, new Guid("a8dc08a7-8cf7-45d9-a2d2-f168cb25f1d0"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5006), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 111", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5007), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 112, new Guid("d2b6a690-f8fd-4878-b5cb-81ea0bf66a1c"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5020), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 112", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5021), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 113, new Guid("e79260fb-353b-443d-a995-2da566c036d3"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5079), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 113", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5079), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 114, new Guid("78b8b0cf-87e7-43c9-89ad-9c27740102be"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5094), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 114", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5095), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 115, new Guid("fab76e67-1d84-487e-91ab-1ee9ca7eaeec"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5110), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 115", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5111), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 116, new Guid("a8bdea9e-75ff-4cdd-8110-bc0fe4253ebd"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5125), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 116", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5125), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 117, new Guid("6370defe-d2df-47ad-878b-f01786ec52c9"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5139), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 117", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5140), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 118, new Guid("3f30a292-1100-402b-ab8f-fdea2ee2b9b8"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5153), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 118", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5153), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 119, new Guid("100d5add-64bb-47c8-b0f9-59a0de0f7024"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5169), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 119", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5170), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 120, new Guid("f6a72a94-efb1-493d-9cd9-8bb6e599e490"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5183), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 120", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5184), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 121, new Guid("1c21330d-5fa9-4a81-8fe9-e842ef391684"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5200), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 121", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5200), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 122, new Guid("01fa2d31-8af8-446b-a57e-e23f4bed2a39"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5214), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 122", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5215), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 123, new Guid("294cff85-3f4e-4857-8aff-3a743ee309a4"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5230), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 123", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5231), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 124, new Guid("de29e60b-8335-4d8c-b2a3-1f093307f3b8"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5245), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 124", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5245), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 125, new Guid("a9edacf8-bb67-4787-bac1-78a32f3bfc77"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5323), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 125", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5324), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 126, new Guid("58eea172-c3db-4c4d-b5f7-2ba0a3b5a12d"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5340), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 126", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5341), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 127, new Guid("46958a01-e46e-4f4a-9091-18cffa71e36f"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5357), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 127", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5358), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 128, new Guid("d2c5eaf0-cb60-40ec-a3d0-dc2001f6479b"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5371), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 128", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5371), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 129, new Guid("105b9197-440a-4b15-91c5-3f6e21e922e2"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5384), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 129", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5385), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 130, new Guid("9507b6db-7fb8-42c7-a9a8-425fb89a0357"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5398), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 130", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5399), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 131, new Guid("15905a51-d103-4838-b53f-47a3141505f6"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5414), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 131", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5415), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 132, new Guid("96ae63f3-687e-425b-b054-b6cd4d8c64eb"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5428), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 132", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5429), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 133, new Guid("f2227135-edea-4cc7-ae2c-79437d854305"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5443), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 133", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5444), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 134, new Guid("6cd7a34d-40ee-47d1-bbd4-2848241a85e1"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5457), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 134", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5458), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 135, new Guid("9ebc2979-2794-4d8b-9df3-95e5d33d0f42"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5473), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 135", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5474), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 136, new Guid("fc6bd0bd-f723-442f-b5f5-70b58abc2f32"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5487), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 136", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5488), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 137, new Guid("cf36edcd-0f23-46ef-a54d-17d096872325"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5502), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 137", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5502), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 138, new Guid("2a389615-4bd3-46a8-ad45-0a04b68b975f"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5558), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 138", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5559), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 139, new Guid("e7d359ed-5a0f-42ca-87eb-fadf2a14c0c0"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5575), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 139", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5576), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 140, new Guid("96a40d10-3ae2-4318-847a-be42654a543a"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5589), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 140", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5590), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 141, new Guid("f892ea7b-4176-48db-95e8-1123dccb74ed"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5603), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 141", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5604), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 142, new Guid("3b1428fa-c164-43dd-9532-77583c27f3fd"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5617), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 142", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5618), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 143, new Guid("c21d5591-ce8a-46e1-b0aa-effc21900db2"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5633), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 143", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5634), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 144, new Guid("d12cdbd1-d9a9-478d-8400-cb16e0261db2"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5648), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 144", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5648), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 145, new Guid("93499b25-4fa8-4a47-8d37-12ac55c4804f"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5662), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 145", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5663), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 146, new Guid("7777b861-2a81-478b-97f0-958e467c0b00"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 146", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5677), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 147, new Guid("15a140ae-6964-4f11-9fa5-2362c3260c02"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5692), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 147", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5693), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 148, new Guid("eac1df04-e7b5-443e-b8f7-32cd6e7bccdb"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5706), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 148", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5706), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 149, new Guid("1b8555d6-fe34-4504-aa82-023dc1e2597a"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5719), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 149", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5720), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 150, new Guid("f3729f53-c99f-4bb2-af91-b2aded1c2367"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 150", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5770), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 151, new Guid("e49e3bae-1528-4262-ad1e-a5c51a8da396"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5788), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 151", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5789), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 152, new Guid("67109991-19fa-458b-a604-f8f027064d18"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5802), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 152", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5803), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 153, new Guid("213baf23-a952-4a7f-89de-e33e42cdefcf"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 153", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5819), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 154, new Guid("ffd9509c-0e6e-4193-88ed-1f73bb3f798a"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5836), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 154", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5837), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 155, new Guid("b34a1e96-b58e-44f6-b719-7b363a1230a2"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5853), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 155", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5854), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 156, new Guid("5061bda1-b44a-4d14-9e14-17ccaf4a8b08"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5867), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 156", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5868), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 157, new Guid("bc3cc0fb-2b1e-4524-9b5d-71e84d3d820f"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5881), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 157", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5882), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 158, new Guid("c7cd6959-399b-4ebf-95f3-d3645b0d6865"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 158", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5896), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 159, new Guid("22787366-0733-4407-a78a-192e28480299"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5911), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 159", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5912), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 160, new Guid("47122f91-17a2-4b18-86b7-324a12fc996f"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5925), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 160", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(5926), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 161, new Guid("a66f5c83-2ba4-4fd6-b13d-62ed79d908bb"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 161", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6016), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 162, new Guid("bf4785bc-d7cb-4d48-8737-748a7f5d3bf1"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6032), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 162", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6033), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 163, new Guid("61d9c1e3-f52d-4ba5-856b-e58e667e2ded"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6049), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 163", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6050), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 164, new Guid("b9a18094-8958-45b5-ae40-d4d5d8853fa7"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6063), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 164", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6063), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 165, new Guid("194ed134-98ae-4521-af97-49ebed0a4fff"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6076), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 165", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6077), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 166, new Guid("c440e658-4041-4f24-a89e-3bd2570ed1bb"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6090), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 166", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6091), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 167, new Guid("284d4130-f6f0-4f01-9a2d-93ac9e2933bb"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6106), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 167", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6107), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 168, new Guid("3c77d508-39ab-4cd0-8dd8-b329f2ed3717"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6120), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 168", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6121), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 169, new Guid("94dde750-975f-4200-983c-78c58ea395a5"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6133), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 169", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6134), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 170, new Guid("a37f5a81-51a4-4b7c-a584-d86eb8a8d273"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6147), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 170", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6148), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 171, new Guid("9f87b144-2fd9-431e-b347-5fee9f37a35e"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6163), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 171", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6164), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 172, new Guid("61616516-74b2-40f4-b2bf-112bf8401b17"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6177), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 172", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6178), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 173, new Guid("848765eb-dfbe-4f9c-bd46-f401c59ec837"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6248), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 173", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6249), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 174, new Guid("c77dead2-b907-4356-828f-63fb5f7a550b"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6265), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 174", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6266), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 175, new Guid("68093741-a9be-4136-8d29-b8b7cf436c32"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6281), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 175", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6282), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 176, new Guid("1d14db43-9fb2-47d7-b0e7-087c3e27b66c"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6295), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 176", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6295), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 177, new Guid("c8d21731-2298-4968-873e-a6768b178fa2"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6308), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 177", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6309), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 178, new Guid("bb7e77d3-5f1c-4a73-81b9-32aa9997c124"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6322), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 178", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6323), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 179, new Guid("2fb6f796-9d2b-42c8-a864-509933dfb214"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6338), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 179", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6339), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 180, new Guid("f37e9284-1158-4112-9597-377cf787e522"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6352), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 180", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6353), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 181, new Guid("7685d997-40ed-47d2-b8c5-22b8dd78f282"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6366), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 181", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6367), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 182, new Guid("d8177f5d-b071-414a-95e8-9afa5f91ead9"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6379), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 182", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6380), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 183, new Guid("5eed51ca-20be-4bdf-bdc8-d62065dcf651"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 183", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6396), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 184, new Guid("ae99a129-b75e-4905-af5c-1fddcc5b861f"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6409), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 184", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6410), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 185, new Guid("300fbc3d-faa8-4780-ba83-6627197b0309"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 185", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6423), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 186, new Guid("14954312-b0fb-4d82-8e77-68dac84bcc70"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6474), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 186", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6474), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 187, new Guid("ef61323b-fe85-46e6-a5ce-e7ecde9a85e1"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6492), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 187", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6492), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 188, new Guid("f5a50535-fc4d-40d9-a7c4-47ef8152166f"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6506), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 188", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6506), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 189, new Guid("e6c1d67d-d913-48ac-8d44-97a04bc7d8df"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6519), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 189", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6520), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 190, new Guid("4aed7546-671e-45b9-87f2-5887f06709fe"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 190", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6534), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 191, new Guid("d5fbbe25-f879-4525-ab28-dde60c9b2e6d"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6549), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 191", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6550), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 192, new Guid("12a30ab3-f5f0-447e-aa1e-a80dd7b5c4b1"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6563), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 192", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6564), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 193, new Guid("05f83769-f398-409b-a60e-65f3cd5811d6"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6576), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 193", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6577), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 194, new Guid("34ae4ac7-36f9-4b3c-ba2a-d5638b7343d9"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6590), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 194", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6591), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 195, new Guid("7a4b9d5f-7ccf-4016-ad1e-76e6a1b094d7"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6606), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 195", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6607), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 196, new Guid("d1fc5c5b-6760-4943-8ac6-fe3d31d78924"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6620), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 196", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6620), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 197, new Guid("d61d7fd0-b31e-436e-ad14-849fc67b6348"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6633), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 197", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6634), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 198, new Guid("623c1754-a607-4838-b9ca-14870c756032"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6646), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 198", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6647), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 199, new Guid("15c1a6ed-bb31-4790-b280-c143dd5adb0a"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6699), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 199", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6700), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 400, new Guid("cd5cebe8-3541-4481-bbbe-da3d2c90de09"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6715), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 400", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6716), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 401, new Guid("de6b3766-3a5e-48e3-bdce-95453200c380"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6731), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 401", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6732), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 402, new Guid("dea84aef-c9f2-4663-99ee-a663e2bc147d"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6745), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 402", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6746), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 403, new Guid("b98b5c1e-bab8-4041-a38a-96c1c6f08bdd"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 403", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6762), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 404, new Guid("656cd763-e5cd-4f98-9178-56d6ae73c4da"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6776), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 404", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6776), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 405, new Guid("770b496e-2bb6-4afc-86a0-0a9a635e2405"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6789), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 405", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6790), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 406, new Guid("7f02937e-de52-4abc-a67b-3e14f5b91072"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6803), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 406", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6804), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 407, new Guid("f0dd95fa-1fd1-4ffe-9b4e-bb840acccb53"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6819), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 407", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6820), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 408, new Guid("2d7b9a9b-76c2-49d0-9402-6c3e33f32503"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6833), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 408", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6834), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 409, new Guid("c14e051a-464f-48a0-ad31-8010f2f2ab57"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6846), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 409", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6847), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 410, new Guid("2aed23a8-e28e-4c9a-8b35-60ff0b6cb87e"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6860), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 410", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6861), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 411, new Guid("e42a604d-7afd-4c4e-b91f-09da43efc34a"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6914), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 411", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6915), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 412, new Guid("b6876464-dd79-4ce1-ba2d-f97e15dd25d5"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6930), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 412", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6930), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 413, new Guid("a50c2473-7b25-4efa-99ef-31c771e25625"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6943), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 413", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6944), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 414, new Guid("f7392fd0-a1d4-4d06-9ddd-ef5377702963"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6957), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 414", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6958), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 415, new Guid("e6a88656-cfe0-4649-8af5-d6c1ff786e3a"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6973), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 415", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6974), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 416, new Guid("b28167f0-4485-4fa0-b5d1-9335db857240"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6987), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 416", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(6988), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 417, new Guid("bfddca79-265b-4ed1-a450-a63592ac7a8e"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7003), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 417", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7003), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 418, new Guid("ef2c8cb5-6dbb-41e0-a4de-4f38115b5e9d"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7017), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 418", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7018), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 419, new Guid("27496320-b61c-4a3b-b5f3-d47cde513383"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7033), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 419", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7034), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 420, new Guid("a51b1053-ffd8-4de8-ba17-b0be6c74918c"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7047), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 420", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7047), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 421, new Guid("f9a74ee6-e9d5-4ad3-967d-372bfbb382ad"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7098), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 421", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7099), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 422, new Guid("aca0f90f-2491-4500-a4ff-12ae4a57a46e"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7113), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 422", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7113), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 423, new Guid("361edfd1-3f32-4ca4-b5af-454d790845e8"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 423", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7129), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 424, new Guid("5fa2a49c-4f8b-44ae-9ade-709236fa45d9"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7143), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 424", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7143), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 425, new Guid("d9b5a493-86e9-400e-b276-337cbfcf06ee"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7156), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 425", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7157), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 426, new Guid("b48aac6c-d42c-4ece-bd7c-fb23766eb6d1"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7169), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 426", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7170), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 427, new Guid("61229f7c-0586-4506-8088-0f374d3ed08a"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7185), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 427", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7186), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 428, new Guid("6fc15af5-65b7-425a-bd0d-2c6ebb279a77"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7199), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 428", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7200), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 429, new Guid("42ef9d05-a086-4a0d-ab61-f4cb6ffe2ffd"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 429", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7213), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 430, new Guid("42cce932-c0a8-4883-a9d7-693fdc1ad947"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 430", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7227), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 431, new Guid("ed7ef689-eb61-4165-a95e-747191b9eae8"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7242), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 431", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7243), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 432, new Guid("d08c5506-d320-4d0c-b829-41365dc974a5"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 432", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7257), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 433, new Guid("29905d62-4d4a-4ac2-b1d8-f33521161e1d"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7306), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 433", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7307), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 434, new Guid("24c4856b-1ab0-453c-8cd0-5a18d8bedfdf"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7322), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 434", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7323), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 435, new Guid("ffe935f3-fe72-4b7b-95d0-6cab622fe3a4"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7338), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 435", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7339), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 436, new Guid("7cd471f6-3cbb-433d-8823-bf5d2f5f4475"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7352), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 436", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7353), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 437, new Guid("97f42c5b-4cc8-4a58-a383-dccc27995551"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7366), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 437", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7367), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 438, new Guid("ef960428-07bf-438a-b9de-0df98f753f0c"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 438", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7381), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 439, new Guid("c0fc909f-c195-48f0-b4dc-b2c6c971b377"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 439", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7397), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 440, new Guid("2f34c1ad-d4a7-4762-9a74-e1f4b96d94aa"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7410), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 440", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7411), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 441, new Guid("ac1a138a-0513-4997-a4b8-8c3d1b8615c9"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7424), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 441", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7425), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 442, new Guid("755283da-5d72-4716-aa5d-ec17959a8c12"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7438), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 442", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7439), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 443, new Guid("80ea7483-af04-4ca5-94e3-77941c10d058"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7454), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 443", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7455), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 444, new Guid("9d3ff07c-df3b-42aa-bcf5-807562a97237"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 444", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7469), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 445, new Guid("f438e8b3-3886-4c8d-9d1f-2658093c6985"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7482), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 445", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7482), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 446, new Guid("38d88d52-0989-4652-a0c6-5bed289ef21e"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 446", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7534), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 447, new Guid("660fa761-0c4d-4320-a22e-b834c903d3de"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7551), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 447", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7552), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 448, new Guid("99936a71-b3c3-4de2-9b74-ca2b76d425dd"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7565), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 448", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7565), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 449, new Guid("6dea9004-b827-48d7-b39b-998673299712"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7578), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 449", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7579), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 450, new Guid("1f1dedc1-f54f-4783-859d-3feb9c0021ec"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7592), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 450", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7593), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 451, new Guid("f4f216eb-c702-4fb8-8e61-5cb74f36b2d0"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7608), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 451", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7608), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 452, new Guid("5b71d91c-07ff-44b6-8244-d93297ad78d7"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7621), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 452", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7622), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 453, new Guid("10cb2d91-f9d2-4361-a074-90fa03b841a9"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 453", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7636), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 454, new Guid("b2934fbf-dcb5-4049-bbcb-809a7cc183f7"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7649), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 454", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 455, new Guid("c980d44a-261e-4325-8714-4d89c1000bfd"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7665), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 455", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7666), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 456, new Guid("38b56aa7-4ecc-4be5-a6c6-e50c5b781ae0"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7679), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 456", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7679), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 457, new Guid("7120b2a0-a1b5-4153-8258-7e88d50520df"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7692), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 457", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7693), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 458, new Guid("8776d72e-64cb-48b6-9d6a-2099ab961a47"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7706), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 458", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7706), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 459, new Guid("e81bdbb5-c452-4d97-ba5d-861813450002"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7764), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 459", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7765), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 460, new Guid("79e6f76c-e127-4452-880d-392b3d164fe7"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7778), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 460", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7779), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 461, new Guid("283e1305-0202-4e6a-955c-0f9787dff064"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7792), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 461", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7793), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 462, new Guid("1380c6e1-f883-452d-8dd1-558d3796055b"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7805), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 462", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7806), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 463, new Guid("83cce4c1-7ca7-44ac-957c-d605af2ade16"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7821), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 463", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7822), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 464, new Guid("c85702bf-f7df-470d-a311-d021112ae1d9"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7835), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 464", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7836), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 465, new Guid("9b1b646b-3a00-4d2e-9d3b-6dd2fa879833"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7849), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 465", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7850), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 466, new Guid("c9290d60-7737-4c11-8157-1e1c984d2766"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7863), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 466", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7863), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 467, new Guid("27697294-fdac-4604-941f-602eff718a50"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 467", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7879), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 468, new Guid("dfa5d7f3-a0da-4b2e-9f6a-0838682fdc56"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7892), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 468", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7893), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 469, new Guid("9989f44d-2155-4c93-880d-d1baa30c5fdf"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7906), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 469", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7906), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 470, new Guid("59cbbcf6-ee55-4e3e-a93c-2a2027031b65"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7919), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 470", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7920), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 471, new Guid("1fe66344-62c6-43bf-9642-a47067e9d453"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7990), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 471", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(7991), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 472, new Guid("ba53b5a0-493b-4d05-a2be-017dfd0c92ce"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8008), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 472", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8008), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 473, new Guid("3d0e8599-caf2-4a73-8cee-411cdc3209a7"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8096), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 473", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8097), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 474, new Guid("d6f8978c-23ed-4f33-a81e-c5bb86d311b1"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8112), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 474", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8113), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 475, new Guid("407e68a7-7f4b-42b6-ab25-5ad497123fa7"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 475", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8129), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 476, new Guid("2fdfdb80-5864-42af-b8ed-68710937afd3"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8143), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 476", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8144), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 477, new Guid("4ee799a7-d9f3-4485-b639-2bb87389ca7b"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 477", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8157), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 478, new Guid("2b5c697a-7b00-4f95-a531-7f4c0cbfdf52"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 478", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8171), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 479, new Guid("26963225-6212-45ac-af4e-fc263f3e9875"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8186), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 479", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8187), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 480, new Guid("c27ac688-fb61-4c8d-8034-6a470904afdc"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8200), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 480", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8201), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 481, new Guid("4bf298a3-fc9d-4c7a-834d-ee603f8d92cb"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8213), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 481", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8214), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 482, new Guid("f2543dd9-d663-4a9d-a031-86e739498d6d"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 482", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8228), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 483, new Guid("fbc6b1a1-14ff-4ec7-9d19-03a7db7e6dd4"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8244), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 483", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8244), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 484, new Guid("ac59d475-b4d1-4aea-964c-34a17c2badbd"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 484", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8303), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 485, new Guid("64884bc1-be19-400d-91af-dfc5fcffb547"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 485", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8318), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 486, new Guid("f94ea81f-cd5a-4c30-8060-88be3d636244"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8330), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 486", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8331), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 487, new Guid("09ba1e4a-683a-4cd1-8d3f-d335a30e2704"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8347), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 487", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8348), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 488, new Guid("7e5e25e5-462b-4f2d-b8ad-28346602412b"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 488", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8361), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 489, new Guid("6f4fa4ae-d39c-4619-8daa-0e7c7fd4c116"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8374), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 489", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8375), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 490, new Guid("e8e5c8a3-2afa-4fbb-a46a-201746f6758b"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8388), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 490", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8389), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 491, new Guid("b7d71afb-472b-4bf4-a056-9775cfe6716e"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 491", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8405), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 492, new Guid("96f3fd79-b46d-4225-9f0b-9c1d4d1da808"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8418), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 492", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8418), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 493, new Guid("e9801e2b-afb0-4960-8d1f-ce0038d489c2"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8431), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 493", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8432), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 494, new Guid("3b354afb-73b6-497c-9fd1-1cab8f5d73ae"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8445), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 494", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8446), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 495, new Guid("2617c382-f421-42fb-bcd1-c3e188f59f73"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8461), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 495", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8462), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 496, new Guid("1355e6c8-0af6-4a69-894f-60c954d53cdd"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8515), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 496", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8516), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 497, new Guid("75a5352f-356a-454c-a042-94b8717f5671"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8531), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 497", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8531), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 498, new Guid("49d512c8-898b-4f44-98a9-775ff1882ed3"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8544), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 498", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8545), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 499, new Guid("a85d85fa-c375-4dc3-9b59-6bba80e01489"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8560), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 499", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8561), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "name", "slot", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("665499b7-342c-41de-968a-c9272f589e6d"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5274), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViRide", 2, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5275), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("6ed57ee0-1d72-42f4-9c22-8da0c264664f"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5294), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-4", 4, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5294), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("cdc6a631-4fe0-4a89-a35a-95725426cfd8"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5307), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-7", 7, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5307), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8804), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8805), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8813), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8814), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8823), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8823), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8832), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8833), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8841), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8842), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8851), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8851), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 100, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8861), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+100", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8861), new TimeSpan(0, 7, 0, 0, 0)), 0, 100, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 101, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8873), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@100", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8874), new TimeSpan(0, 7, 0, 0, 0)), 0, 100 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 102, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8888), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+101", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8888), new TimeSpan(0, 7, 0, 0, 0)), 0, 101, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 103, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8898), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@101", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8899), new TimeSpan(0, 7, 0, 0, 0)), 0, 101 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 104, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8908), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+102", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8909), new TimeSpan(0, 7, 0, 0, 0)), 0, 102, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 105, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8919), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@102", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8919), new TimeSpan(0, 7, 0, 0, 0)), 0, 102 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 106, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8929), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+103", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8930), new TimeSpan(0, 7, 0, 0, 0)), 0, 103, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 107, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8939), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@103", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8940), new TimeSpan(0, 7, 0, 0, 0)), 0, 103 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 108, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8949), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+104", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8950), new TimeSpan(0, 7, 0, 0, 0)), 0, 104, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 109, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8961), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@104", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8962), new TimeSpan(0, 7, 0, 0, 0)), 0, 104 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 110, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+105", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8972), new TimeSpan(0, 7, 0, 0, 0)), 0, 105, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 111, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8982), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@105", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8983), new TimeSpan(0, 7, 0, 0, 0)), 0, 105 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 112, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8993), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+106", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8993), new TimeSpan(0, 7, 0, 0, 0)), 0, 106, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 113, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9040), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@106", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9041), new TimeSpan(0, 7, 0, 0, 0)), 0, 106 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 114, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9052), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+107", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9053), new TimeSpan(0, 7, 0, 0, 0)), 0, 107, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 115, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9063), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@107", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9064), new TimeSpan(0, 7, 0, 0, 0)), 0, 107 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 116, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9073), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+108", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9074), new TimeSpan(0, 7, 0, 0, 0)), 0, 108, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 117, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9083), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@108", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9084), new TimeSpan(0, 7, 0, 0, 0)), 0, 108 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 118, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9093), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+109", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9094), new TimeSpan(0, 7, 0, 0, 0)), 0, 109, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 119, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9103), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@109", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9104), new TimeSpan(0, 7, 0, 0, 0)), 0, 109 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 120, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9113), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+110", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9114), new TimeSpan(0, 7, 0, 0, 0)), 0, 110, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 121, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9124), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@110", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9124), new TimeSpan(0, 7, 0, 0, 0)), 0, 110 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 122, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9134), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+111", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9135), new TimeSpan(0, 7, 0, 0, 0)), 0, 111, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 123, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@111", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9145), new TimeSpan(0, 7, 0, 0, 0)), 0, 111 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 124, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9154), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+112", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9155), new TimeSpan(0, 7, 0, 0, 0)), 0, 112, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 125, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9164), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@112", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9165), new TimeSpan(0, 7, 0, 0, 0)), 0, 112 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 126, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+113", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9175), new TimeSpan(0, 7, 0, 0, 0)), 0, 113, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 127, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9185), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@113", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9185), new TimeSpan(0, 7, 0, 0, 0)), 0, 113 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 128, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9195), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+114", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9195), new TimeSpan(0, 7, 0, 0, 0)), 0, 114, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 129, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9205), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@114", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9205), new TimeSpan(0, 7, 0, 0, 0)), 0, 114 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 130, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9216), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+115", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9216), new TimeSpan(0, 7, 0, 0, 0)), 0, 115, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 131, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@115", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9227), new TimeSpan(0, 7, 0, 0, 0)), 0, 115 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 132, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9236), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+116", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9237), new TimeSpan(0, 7, 0, 0, 0)), 0, 116, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 133, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9246), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@116", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9247), new TimeSpan(0, 7, 0, 0, 0)), 0, 116 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 134, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+117", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9257), new TimeSpan(0, 7, 0, 0, 0)), 0, 117, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 135, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@117", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9305), new TimeSpan(0, 7, 0, 0, 0)), 0, 117 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 136, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9316), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+118", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9316), new TimeSpan(0, 7, 0, 0, 0)), 0, 118, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 137, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9326), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@118", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9327), new TimeSpan(0, 7, 0, 0, 0)), 0, 118 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 138, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9336), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+119", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9337), new TimeSpan(0, 7, 0, 0, 0)), 0, 119, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 139, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9346), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@119", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9347), new TimeSpan(0, 7, 0, 0, 0)), 0, 119 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 140, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9356), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+120", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9357), new TimeSpan(0, 7, 0, 0, 0)), 0, 120, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 141, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@120", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9369), new TimeSpan(0, 7, 0, 0, 0)), 0, 120 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 142, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9379), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+121", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9380), new TimeSpan(0, 7, 0, 0, 0)), 0, 121, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 143, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9390), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@121", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9390), new TimeSpan(0, 7, 0, 0, 0)), 0, 121 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 144, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9400), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+122", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9400), new TimeSpan(0, 7, 0, 0, 0)), 0, 122, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 145, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9410), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@122", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9410), new TimeSpan(0, 7, 0, 0, 0)), 0, 122 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 146, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9420), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+123", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9421), new TimeSpan(0, 7, 0, 0, 0)), 0, 123, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 147, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9430), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@123", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9431), new TimeSpan(0, 7, 0, 0, 0)), 0, 123 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 148, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9440), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+124", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9441), new TimeSpan(0, 7, 0, 0, 0)), 0, 124, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 149, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9450), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@124", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9451), new TimeSpan(0, 7, 0, 0, 0)), 0, 124 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 150, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9460), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+125", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9461), new TimeSpan(0, 7, 0, 0, 0)), 0, 125, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 151, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9471), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@125", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9471), new TimeSpan(0, 7, 0, 0, 0)), 0, 125 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 152, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+126", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9482), new TimeSpan(0, 7, 0, 0, 0)), 0, 126, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 153, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9491), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@126", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9492), new TimeSpan(0, 7, 0, 0, 0)), 0, 126 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 154, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9501), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+127", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9502), new TimeSpan(0, 7, 0, 0, 0)), 0, 127, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 155, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9550), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@127", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9551), new TimeSpan(0, 7, 0, 0, 0)), 0, 127 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 156, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9561), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+128", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9562), new TimeSpan(0, 7, 0, 0, 0)), 0, 128, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 157, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@128", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9571), new TimeSpan(0, 7, 0, 0, 0)), 0, 128 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 158, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9581), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+129", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9582), new TimeSpan(0, 7, 0, 0, 0)), 0, 129, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 159, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9591), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@129", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9592), new TimeSpan(0, 7, 0, 0, 0)), 0, 129 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 160, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9601), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+130", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9602), new TimeSpan(0, 7, 0, 0, 0)), 0, 130, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 161, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9611), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@130", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9612), new TimeSpan(0, 7, 0, 0, 0)), 0, 130 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 162, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9621), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+131", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9622), new TimeSpan(0, 7, 0, 0, 0)), 0, 131, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 163, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9632), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@131", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9633), new TimeSpan(0, 7, 0, 0, 0)), 0, 131 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 164, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9642), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+132", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9643), new TimeSpan(0, 7, 0, 0, 0)), 0, 132, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 165, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9653), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@132", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9653), new TimeSpan(0, 7, 0, 0, 0)), 0, 132 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 166, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9663), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+133", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9664), new TimeSpan(0, 7, 0, 0, 0)), 0, 133, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 167, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9674), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@133", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9674), new TimeSpan(0, 7, 0, 0, 0)), 0, 133 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 168, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9683), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+134", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9684), new TimeSpan(0, 7, 0, 0, 0)), 0, 134, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 169, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9694), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@134", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9695), new TimeSpan(0, 7, 0, 0, 0)), 0, 134 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 170, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+135", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9705), new TimeSpan(0, 7, 0, 0, 0)), 0, 135, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 171, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9714), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@135", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9715), new TimeSpan(0, 7, 0, 0, 0)), 0, 135 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 172, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9724), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+136", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9725), new TimeSpan(0, 7, 0, 0, 0)), 0, 136, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 173, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9735), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@136", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9735), new TimeSpan(0, 7, 0, 0, 0)), 0, 136 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 174, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9745), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+137", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9746), new TimeSpan(0, 7, 0, 0, 0)), 0, 137, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 175, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@137", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9756), new TimeSpan(0, 7, 0, 0, 0)), 0, 137 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 176, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9765), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+138", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9766), new TimeSpan(0, 7, 0, 0, 0)), 0, 138, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 177, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@138", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9819), new TimeSpan(0, 7, 0, 0, 0)), 0, 138 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 178, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9830), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+139", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9830), new TimeSpan(0, 7, 0, 0, 0)), 0, 139, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 179, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9840), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@139", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9840), new TimeSpan(0, 7, 0, 0, 0)), 0, 139 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 180, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9850), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+140", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9850), new TimeSpan(0, 7, 0, 0, 0)), 0, 140, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 181, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9860), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@140", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9860), new TimeSpan(0, 7, 0, 0, 0)), 0, 140 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 182, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9870), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+141", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9870), new TimeSpan(0, 7, 0, 0, 0)), 0, 141, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 183, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9880), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@141", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9880), new TimeSpan(0, 7, 0, 0, 0)), 0, 141 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 184, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9890), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+142", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9891), new TimeSpan(0, 7, 0, 0, 0)), 0, 142, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 185, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9900), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@142", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9901), new TimeSpan(0, 7, 0, 0, 0)), 0, 142 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 186, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9910), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+143", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9911), new TimeSpan(0, 7, 0, 0, 0)), 0, 143, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 187, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9920), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@143", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9921), new TimeSpan(0, 7, 0, 0, 0)), 0, 143 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 188, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9931), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+144", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9931), new TimeSpan(0, 7, 0, 0, 0)), 0, 144, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 189, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9941), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@144", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9942), new TimeSpan(0, 7, 0, 0, 0)), 0, 144 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 190, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9951), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+145", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9952), new TimeSpan(0, 7, 0, 0, 0)), 0, 145, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 191, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9961), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@145", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9962), new TimeSpan(0, 7, 0, 0, 0)), 0, 145 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 192, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9971), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+146", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9972), new TimeSpan(0, 7, 0, 0, 0)), 0, 146, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 193, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9981), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@146", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9982), new TimeSpan(0, 7, 0, 0, 0)), 0, 146 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 194, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9992), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+147", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(9993), new TimeSpan(0, 7, 0, 0, 0)), 0, 147, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 195, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@147", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3), new TimeSpan(0, 7, 0, 0, 0)), 0, 147 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 196, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(12), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+148", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(13), new TimeSpan(0, 7, 0, 0, 0)), 0, 148, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 197, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(22), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@148", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(23), new TimeSpan(0, 7, 0, 0, 0)), 0, 148 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 198, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(32), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+149", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(33), new TimeSpan(0, 7, 0, 0, 0)), 0, 149, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 199, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(103), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@149", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(104), new TimeSpan(0, 7, 0, 0, 0)), 0, 149 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 200, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(116), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+150", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(117), new TimeSpan(0, 7, 0, 0, 0)), 0, 150, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 201, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(126), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@150", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(127), new TimeSpan(0, 7, 0, 0, 0)), 0, 150 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 202, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(136), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+151", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(137), new TimeSpan(0, 7, 0, 0, 0)), 0, 151, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 203, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(147), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@151", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(147), new TimeSpan(0, 7, 0, 0, 0)), 0, 151 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 204, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+152", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(157), new TimeSpan(0, 7, 0, 0, 0)), 0, 152, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 205, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(169), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@152", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(170), new TimeSpan(0, 7, 0, 0, 0)), 0, 152 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 206, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(180), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+153", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(180), new TimeSpan(0, 7, 0, 0, 0)), 0, 153, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 207, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(190), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@153", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(190), new TimeSpan(0, 7, 0, 0, 0)), 0, 153 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 208, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(200), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+154", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(201), new TimeSpan(0, 7, 0, 0, 0)), 0, 154, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 209, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(210), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@154", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(211), new TimeSpan(0, 7, 0, 0, 0)), 0, 154 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 210, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(220), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+155", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(221), new TimeSpan(0, 7, 0, 0, 0)), 0, 155, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 211, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(230), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@155", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(231), new TimeSpan(0, 7, 0, 0, 0)), 0, 155 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 212, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(240), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+156", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(241), new TimeSpan(0, 7, 0, 0, 0)), 0, 156, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 213, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(251), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@156", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(251), new TimeSpan(0, 7, 0, 0, 0)), 0, 156 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 214, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(261), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+157", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(262), new TimeSpan(0, 7, 0, 0, 0)), 0, 157, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 215, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(271), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@157", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(272), new TimeSpan(0, 7, 0, 0, 0)), 0, 157 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 216, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(322), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+158", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(322), new TimeSpan(0, 7, 0, 0, 0)), 0, 158, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 217, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(332), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@158", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(333), new TimeSpan(0, 7, 0, 0, 0)), 0, 158 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 218, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(342), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+159", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(343), new TimeSpan(0, 7, 0, 0, 0)), 0, 159, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 219, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(352), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@159", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(353), new TimeSpan(0, 7, 0, 0, 0)), 0, 159 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 220, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(362), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+160", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(363), new TimeSpan(0, 7, 0, 0, 0)), 0, 160, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 221, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(373), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@160", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(374), new TimeSpan(0, 7, 0, 0, 0)), 0, 160 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 222, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(383), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+161", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(384), new TimeSpan(0, 7, 0, 0, 0)), 0, 161, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 223, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(393), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@161", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(394), new TimeSpan(0, 7, 0, 0, 0)), 0, 161 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 224, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+162", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(405), new TimeSpan(0, 7, 0, 0, 0)), 0, 162, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 225, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(414), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@162", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(415), new TimeSpan(0, 7, 0, 0, 0)), 0, 162 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 226, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(425), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+163", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(425), new TimeSpan(0, 7, 0, 0, 0)), 0, 163, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 227, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(435), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@163", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(436), new TimeSpan(0, 7, 0, 0, 0)), 0, 163 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 228, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(445), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+164", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(446), new TimeSpan(0, 7, 0, 0, 0)), 0, 164, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 229, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(455), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@164", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(456), new TimeSpan(0, 7, 0, 0, 0)), 0, 164 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 230, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(465), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+165", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(466), new TimeSpan(0, 7, 0, 0, 0)), 0, 165, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 231, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(476), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@165", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(477), new TimeSpan(0, 7, 0, 0, 0)), 0, 165 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 232, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(486), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+166", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(487), new TimeSpan(0, 7, 0, 0, 0)), 0, 166, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 233, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(496), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@166", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(497), new TimeSpan(0, 7, 0, 0, 0)), 0, 166 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 234, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(506), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+167", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(507), new TimeSpan(0, 7, 0, 0, 0)), 0, 167, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 235, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(516), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@167", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(517), new TimeSpan(0, 7, 0, 0, 0)), 0, 167 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 236, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(527), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+168", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(527), new TimeSpan(0, 7, 0, 0, 0)), 0, 168, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 237, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(537), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@168", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(538), new TimeSpan(0, 7, 0, 0, 0)), 0, 168 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 238, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(584), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+169", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(585), new TimeSpan(0, 7, 0, 0, 0)), 0, 169, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 239, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(596), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@169", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(596), new TimeSpan(0, 7, 0, 0, 0)), 0, 169 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 240, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(605), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+170", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(606), new TimeSpan(0, 7, 0, 0, 0)), 0, 170, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 241, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(615), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@170", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(616), new TimeSpan(0, 7, 0, 0, 0)), 0, 170 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 242, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(625), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+171", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(626), new TimeSpan(0, 7, 0, 0, 0)), 0, 171, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 243, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@171", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(636), new TimeSpan(0, 7, 0, 0, 0)), 0, 171 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 244, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(646), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+172", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(646), new TimeSpan(0, 7, 0, 0, 0)), 0, 172, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 245, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(656), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@172", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(657), new TimeSpan(0, 7, 0, 0, 0)), 0, 172 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 246, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(666), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+173", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(667), new TimeSpan(0, 7, 0, 0, 0)), 0, 173, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 247, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@173", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(677), new TimeSpan(0, 7, 0, 0, 0)), 0, 173 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 248, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(686), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+174", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(687), new TimeSpan(0, 7, 0, 0, 0)), 0, 174, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 249, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(696), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@174", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(697), new TimeSpan(0, 7, 0, 0, 0)), 0, 174 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 250, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(706), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+175", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(707), new TimeSpan(0, 7, 0, 0, 0)), 0, 175, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 251, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(716), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@175", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(717), new TimeSpan(0, 7, 0, 0, 0)), 0, 175 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 252, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(726), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+176", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(727), new TimeSpan(0, 7, 0, 0, 0)), 0, 176, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 253, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(736), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@176", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(737), new TimeSpan(0, 7, 0, 0, 0)), 0, 176 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 254, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(746), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+177", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(747), new TimeSpan(0, 7, 0, 0, 0)), 0, 177, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 255, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(757), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@177", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(757), new TimeSpan(0, 7, 0, 0, 0)), 0, 177 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 256, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(766), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+178", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(767), new TimeSpan(0, 7, 0, 0, 0)), 0, 178, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 257, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(776), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@178", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(777), new TimeSpan(0, 7, 0, 0, 0)), 0, 178 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 258, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(787), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+179", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(788), new TimeSpan(0, 7, 0, 0, 0)), 0, 179, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 259, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(797), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@179", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(798), new TimeSpan(0, 7, 0, 0, 0)), 0, 179 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 260, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(845), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+180", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(845), new TimeSpan(0, 7, 0, 0, 0)), 0, 180, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 261, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(857), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@180", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(857), new TimeSpan(0, 7, 0, 0, 0)), 0, 180 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 262, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(867), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+181", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(868), new TimeSpan(0, 7, 0, 0, 0)), 0, 181, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 263, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(878), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@181", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(878), new TimeSpan(0, 7, 0, 0, 0)), 0, 181 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 264, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(888), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+182", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(889), new TimeSpan(0, 7, 0, 0, 0)), 0, 182, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 265, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(898), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@182", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(899), new TimeSpan(0, 7, 0, 0, 0)), 0, 182 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 266, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(908), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+183", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(909), new TimeSpan(0, 7, 0, 0, 0)), 0, 183, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 267, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(918), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@183", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(919), new TimeSpan(0, 7, 0, 0, 0)), 0, 183 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 268, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(928), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+184", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(929), new TimeSpan(0, 7, 0, 0, 0)), 0, 184, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 269, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(938), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@184", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(939), new TimeSpan(0, 7, 0, 0, 0)), 0, 184 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 270, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(948), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+185", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(949), new TimeSpan(0, 7, 0, 0, 0)), 0, 185, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 271, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(958), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@185", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(959), new TimeSpan(0, 7, 0, 0, 0)), 0, 185 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 272, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+186", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(969), new TimeSpan(0, 7, 0, 0, 0)), 0, 186, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 273, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(978), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@186", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(979), new TimeSpan(0, 7, 0, 0, 0)), 0, 186 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 274, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(988), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+187", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(989), new TimeSpan(0, 7, 0, 0, 0)), 0, 187, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 275, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@187", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(999), new TimeSpan(0, 7, 0, 0, 0)), 0, 187 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 276, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1008), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+188", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1009), new TimeSpan(0, 7, 0, 0, 0)), 0, 188, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 277, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1018), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@188", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1019), new TimeSpan(0, 7, 0, 0, 0)), 0, 188 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 278, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1028), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+189", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1029), new TimeSpan(0, 7, 0, 0, 0)), 0, 189, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 279, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1038), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@189", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1039), new TimeSpan(0, 7, 0, 0, 0)), 0, 189 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 280, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1048), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+190", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1049), new TimeSpan(0, 7, 0, 0, 0)), 0, 190, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 281, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1058), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@190", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1059), new TimeSpan(0, 7, 0, 0, 0)), 0, 190 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 282, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1104), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+191", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1105), new TimeSpan(0, 7, 0, 0, 0)), 0, 191, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 283, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1116), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@191", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1117), new TimeSpan(0, 7, 0, 0, 0)), 0, 191 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 284, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1127), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+192", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1127), new TimeSpan(0, 7, 0, 0, 0)), 0, 192, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 285, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1137), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@192", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1138), new TimeSpan(0, 7, 0, 0, 0)), 0, 192 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 286, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1147), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+193", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1148), new TimeSpan(0, 7, 0, 0, 0)), 0, 193, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 287, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@193", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1158), new TimeSpan(0, 7, 0, 0, 0)), 0, 193 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 288, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+194", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1168), new TimeSpan(0, 7, 0, 0, 0)), 0, 194, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 289, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1177), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@194", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1178), new TimeSpan(0, 7, 0, 0, 0)), 0, 194 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 290, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1188), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+195", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1188), new TimeSpan(0, 7, 0, 0, 0)), 0, 195, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 291, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1198), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@195", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1198), new TimeSpan(0, 7, 0, 0, 0)), 0, 195 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 292, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1208), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+196", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1208), new TimeSpan(0, 7, 0, 0, 0)), 0, 196, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 293, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@196", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1218), new TimeSpan(0, 7, 0, 0, 0)), 0, 196 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 294, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+197", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1228), new TimeSpan(0, 7, 0, 0, 0)), 0, 197, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 295, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1238), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@197", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1239), new TimeSpan(0, 7, 0, 0, 0)), 0, 197 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 296, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1248), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+198", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1249), new TimeSpan(0, 7, 0, 0, 0)), 0, 198, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 297, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1258), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@198", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1259), new TimeSpan(0, 7, 0, 0, 0)), 0, 198 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 298, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1268), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+199", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1269), new TimeSpan(0, 7, 0, 0, 0)), 0, 199, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 299, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1278), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@199", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1279), new TimeSpan(0, 7, 0, 0, 0)), 0, 199 },
                    { 400, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1289), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+400", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1289), new TimeSpan(0, 7, 0, 0, 0)), 0, 400 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 401, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1300), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@400", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1301), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 402, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+401", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1311), new TimeSpan(0, 7, 0, 0, 0)), 0, 401 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 403, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@401", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1321), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 404, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1365), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+402", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1366), new TimeSpan(0, 7, 0, 0, 0)), 0, 402 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 405, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1377), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@402", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1378), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 406, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1387), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+403", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1388), new TimeSpan(0, 7, 0, 0, 0)), 0, 403 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 407, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@403", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1398), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 408, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1407), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+404", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1408), new TimeSpan(0, 7, 0, 0, 0)), 0, 404 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 409, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1417), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@404", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1418), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 410, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1427), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+405", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1428), new TimeSpan(0, 7, 0, 0, 0)), 0, 405 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 411, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1438), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@405", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1438), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 412, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1447), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+406", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1448), new TimeSpan(0, 7, 0, 0, 0)), 0, 406 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 413, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@406", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1458), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 414, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+407", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1468), new TimeSpan(0, 7, 0, 0, 0)), 0, 407 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 415, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1478), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@407", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1478), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 416, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1488), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+408", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1488), new TimeSpan(0, 7, 0, 0, 0)), 0, 408 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 417, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1498), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@408", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1498), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 418, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1508), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+409", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1508), new TimeSpan(0, 7, 0, 0, 0)), 0, 409 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 419, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1518), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@409", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1519), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 420, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1528), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+410", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1529), new TimeSpan(0, 7, 0, 0, 0)), 0, 410 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 421, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1538), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@410", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1539), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 422, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+411", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1549), new TimeSpan(0, 7, 0, 0, 0)), 0, 411 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 423, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1558), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@411", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1559), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 424, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1568), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+412", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1568), new TimeSpan(0, 7, 0, 0, 0)), 0, 412 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 425, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1578), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@412", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1578), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 426, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1588), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+413", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1588), new TimeSpan(0, 7, 0, 0, 0)), 0, 413 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 427, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1634), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@413", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1635), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 428, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1645), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+414", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1646), new TimeSpan(0, 7, 0, 0, 0)), 0, 414 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 429, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1655), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@414", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1656), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 430, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1665), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+415", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1666), new TimeSpan(0, 7, 0, 0, 0)), 0, 415 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 431, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1675), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@415", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1676), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 432, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1685), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+416", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1686), new TimeSpan(0, 7, 0, 0, 0)), 0, 416 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 433, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1698), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@416", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1699), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 434, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1708), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+417", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1709), new TimeSpan(0, 7, 0, 0, 0)), 0, 417 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 435, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1718), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@417", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1719), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 436, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1728), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+418", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1729), new TimeSpan(0, 7, 0, 0, 0)), 0, 418 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 437, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1739), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@418", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1739), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 438, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1789), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+419", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1789), new TimeSpan(0, 7, 0, 0, 0)), 0, 419 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 439, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1799), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@419", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1800), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 440, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1809), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+420", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1810), new TimeSpan(0, 7, 0, 0, 0)), 0, 420 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 441, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1819), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@420", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1820), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 442, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1829), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+421", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1830), new TimeSpan(0, 7, 0, 0, 0)), 0, 421 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 443, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1839), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@421", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1840), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 444, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1850), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+422", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1850), new TimeSpan(0, 7, 0, 0, 0)), 0, 422 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 445, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1860), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@422", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1861), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 446, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1870), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+423", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1871), new TimeSpan(0, 7, 0, 0, 0)), 0, 423 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 447, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1880), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@423", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1881), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 448, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1891), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+424", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1891), new TimeSpan(0, 7, 0, 0, 0)), 0, 424 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 449, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1901), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@424", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1902), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 450, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1911), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+425", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1912), new TimeSpan(0, 7, 0, 0, 0)), 0, 425 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 451, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1922), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@425", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1923), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 452, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1932), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+426", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1933), new TimeSpan(0, 7, 0, 0, 0)), 0, 426 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 453, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@426", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1943), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 454, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1952), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+427", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1953), new TimeSpan(0, 7, 0, 0, 0)), 0, 427 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 455, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@427", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1963), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 456, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1973), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+428", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1974), new TimeSpan(0, 7, 0, 0, 0)), 0, 428 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 457, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1983), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@428", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1984), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 458, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1993), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+429", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(1994), new TimeSpan(0, 7, 0, 0, 0)), 0, 429 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 459, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2003), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@429", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2004), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 460, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2133), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+430", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2134), new TimeSpan(0, 7, 0, 0, 0)), 0, 430 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 461, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2145), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@430", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2146), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 462, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2156), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+431", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2157), new TimeSpan(0, 7, 0, 0, 0)), 0, 431 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 463, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2166), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@431", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2167), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 464, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2176), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+432", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2177), new TimeSpan(0, 7, 0, 0, 0)), 0, 432 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 465, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2186), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@432", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2187), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 466, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2196), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+433", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2197), new TimeSpan(0, 7, 0, 0, 0)), 0, 433 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 467, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2206), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@433", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2207), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 468, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2216), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+434", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2217), new TimeSpan(0, 7, 0, 0, 0)), 0, 434 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 469, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@434", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2227), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 470, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2237), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+435", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2237), new TimeSpan(0, 7, 0, 0, 0)), 0, 435 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 471, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2247), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@435", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2247), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 472, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+436", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2258), new TimeSpan(0, 7, 0, 0, 0)), 0, 436 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 473, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@436", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2268), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 474, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2277), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+437", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2278), new TimeSpan(0, 7, 0, 0, 0)), 0, 437 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 475, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2287), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@437", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2288), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 476, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2297), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+438", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2298), new TimeSpan(0, 7, 0, 0, 0)), 0, 438 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 477, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2307), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@438", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2308), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 478, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+439", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2318), new TimeSpan(0, 7, 0, 0, 0)), 0, 439 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 479, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2328), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@439", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2328), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 480, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2338), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+440", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2339), new TimeSpan(0, 7, 0, 0, 0)), 0, 440 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 481, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2348), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@440", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2349), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 482, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2392), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+441", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2393), new TimeSpan(0, 7, 0, 0, 0)), 0, 441 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 483, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@441", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2405), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 484, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2414), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+442", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2415), new TimeSpan(0, 7, 0, 0, 0)), 0, 442 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 485, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2425), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@442", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2425), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 486, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2435), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+443", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2436), new TimeSpan(0, 7, 0, 0, 0)), 0, 443 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 487, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2445), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@443", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2446), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 488, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2455), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+444", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2456), new TimeSpan(0, 7, 0, 0, 0)), 0, 444 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 489, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2465), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@444", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2466), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 490, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2475), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+445", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2476), new TimeSpan(0, 7, 0, 0, 0)), 0, 445 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 491, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2485), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@445", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2486), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 492, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2496), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+446", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2496), new TimeSpan(0, 7, 0, 0, 0)), 0, 446 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 493, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2506), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@446", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2507), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 494, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+447", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2517), new TimeSpan(0, 7, 0, 0, 0)), 0, 447 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 495, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2527), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@447", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2528), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 496, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2537), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+448", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2538), new TimeSpan(0, 7, 0, 0, 0)), 0, 448 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 497, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2547), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@448", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2548), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 498, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2557), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+449", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2558), new TimeSpan(0, 7, 0, 0, 0)), 0, 449 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 499, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2567), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@449", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2568), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 500, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2577), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+450", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2578), new TimeSpan(0, 7, 0, 0, 0)), 0, 450 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 501, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@450", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2588), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 502, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2598), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+451", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2598), new TimeSpan(0, 7, 0, 0, 0)), 0, 451 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 503, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2608), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@451", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2608), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 504, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2652), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+452", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2653), new TimeSpan(0, 7, 0, 0, 0)), 0, 452 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 505, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@452", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2665), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 506, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2674), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+453", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2675), new TimeSpan(0, 7, 0, 0, 0)), 0, 453 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 507, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2685), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@453", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2685), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 508, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2695), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+454", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2695), new TimeSpan(0, 7, 0, 0, 0)), 0, 454 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 509, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2705), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@454", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2705), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 510, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2715), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+455", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2715), new TimeSpan(0, 7, 0, 0, 0)), 0, 455 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 511, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2725), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@455", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2725), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 512, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2735), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+456", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2736), new TimeSpan(0, 7, 0, 0, 0)), 0, 456 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 513, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2745), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@456", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2746), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 514, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+457", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 7, 0, 0, 0)), 0, 457 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 515, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2765), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@457", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2766), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 516, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2775), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+458", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2776), new TimeSpan(0, 7, 0, 0, 0)), 0, 458 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 517, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2785), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@458", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2786), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 518, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2795), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+459", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2796), new TimeSpan(0, 7, 0, 0, 0)), 0, 459 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 519, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2806), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@459", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2806), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 520, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2816), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+460", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2816), new TimeSpan(0, 7, 0, 0, 0)), 0, 460 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 521, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2826), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@460", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2826), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 522, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2836), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+461", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2836), new TimeSpan(0, 7, 0, 0, 0)), 0, 461 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 523, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2846), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@461", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2847), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 524, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2857), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+462", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2857), new TimeSpan(0, 7, 0, 0, 0)), 0, 462 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 525, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2867), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@462", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2868), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 526, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2914), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+463", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2914), new TimeSpan(0, 7, 0, 0, 0)), 0, 463 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 527, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2925), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@463", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2926), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 528, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2935), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+464", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2936), new TimeSpan(0, 7, 0, 0, 0)), 0, 464 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 529, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2945), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@464", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2946), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 530, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2956), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+465", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2956), new TimeSpan(0, 7, 0, 0, 0)), 0, 465 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 531, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2966), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@465", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2966), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 532, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+466", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2976), new TimeSpan(0, 7, 0, 0, 0)), 0, 466 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 533, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2986), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@466", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2986), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 534, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2996), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+467", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(2996), new TimeSpan(0, 7, 0, 0, 0)), 0, 467 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 535, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3006), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@467", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3006), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 536, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3016), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+468", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3016), new TimeSpan(0, 7, 0, 0, 0)), 0, 468 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 537, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3026), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@468", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3027), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 538, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3036), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+469", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3037), new TimeSpan(0, 7, 0, 0, 0)), 0, 469 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 539, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3046), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@469", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3047), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 540, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3056), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+470", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3057), new TimeSpan(0, 7, 0, 0, 0)), 0, 470 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 541, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3066), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@470", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3067), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 542, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3076), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+471", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3077), new TimeSpan(0, 7, 0, 0, 0)), 0, 471 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 543, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3087), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@471", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3087), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 544, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3097), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+472", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3098), new TimeSpan(0, 7, 0, 0, 0)), 0, 472 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 545, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3107), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@472", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3108), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 546, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3117), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+473", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3118), new TimeSpan(0, 7, 0, 0, 0)), 0, 473 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 547, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3127), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@473", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3128), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 548, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3137), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+474", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3137), new TimeSpan(0, 7, 0, 0, 0)), 0, 474 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 549, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3184), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@474", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3185), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 550, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3195), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+475", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3196), new TimeSpan(0, 7, 0, 0, 0)), 0, 475 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 551, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3205), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@475", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3206), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 552, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3215), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+476", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3216), new TimeSpan(0, 7, 0, 0, 0)), 0, 476 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 553, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@476", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3226), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 554, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3236), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+477", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3237), new TimeSpan(0, 7, 0, 0, 0)), 0, 477 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 555, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3246), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@477", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3247), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 556, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+478", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3257), new TimeSpan(0, 7, 0, 0, 0)), 0, 478 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 557, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@478", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3267), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 558, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3276), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+479", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3277), new TimeSpan(0, 7, 0, 0, 0)), 0, 479 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 559, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3287), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@479", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3287), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 560, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3297), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+480", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3298), new TimeSpan(0, 7, 0, 0, 0)), 0, 480 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 561, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3307), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@480", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3308), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 562, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+481", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3318), new TimeSpan(0, 7, 0, 0, 0)), 0, 481 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 563, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3327), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@481", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3328), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 564, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3341), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+482", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3342), new TimeSpan(0, 7, 0, 0, 0)), 0, 482 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 565, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3360), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@482", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3361), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 566, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+483", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3379), new TimeSpan(0, 7, 0, 0, 0)), 0, 483 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 567, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3395), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@483", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3396), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 568, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3413), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+484", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3414), new TimeSpan(0, 7, 0, 0, 0)), 0, 484 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 569, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3463), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@484", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3465), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 570, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3491), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+485", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3492), new TimeSpan(0, 7, 0, 0, 0)), 0, 485 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 571, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3542), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@485", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3543), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 572, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3553), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+486", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3554), new TimeSpan(0, 7, 0, 0, 0)), 0, 486 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 573, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3564), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@486", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3564), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 574, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3574), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+487", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3575), new TimeSpan(0, 7, 0, 0, 0)), 0, 487 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 575, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3585), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@487", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3585), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 576, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3595), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+488", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3595), new TimeSpan(0, 7, 0, 0, 0)), 0, 488 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 577, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3605), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@488", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3606), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 578, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3615), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+489", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3616), new TimeSpan(0, 7, 0, 0, 0)), 0, 489 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 579, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3625), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@489", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3626), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 580, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3636), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+490", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3636), new TimeSpan(0, 7, 0, 0, 0)), 0, 490 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 581, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3646), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@490", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3646), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 582, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3656), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+491", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3657), new TimeSpan(0, 7, 0, 0, 0)), 0, 491 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 583, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3666), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@491", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3667), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 584, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3677), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+492", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3677), new TimeSpan(0, 7, 0, 0, 0)), 0, 492 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 585, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3687), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@492", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3688), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 586, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3698), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+493", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3699), new TimeSpan(0, 7, 0, 0, 0)), 0, 493 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 587, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3708), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@493", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3709), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 588, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3719), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+494", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3720), new TimeSpan(0, 7, 0, 0, 0)), 0, 494 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 589, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3729), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@494", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3730), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 590, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3739), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+495", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3740), new TimeSpan(0, 7, 0, 0, 0)), 0, 495 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 591, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3749), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@495", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3750), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 592, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3760), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+496", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3760), new TimeSpan(0, 7, 0, 0, 0)), 0, 496 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 593, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3806), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@496", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3807), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 594, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+497", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3819), new TimeSpan(0, 7, 0, 0, 0)), 0, 497 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 595, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3828), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@497", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3829), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 596, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3839), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+498", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3840), new TimeSpan(0, 7, 0, 0, 0)), 0, 498 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 597, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3849), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@498", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3850), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 598, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3859), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+499", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3860), new TimeSpan(0, 7, 0, 0, 0)), 0, 499 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 599, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3870), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@499", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3870), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, true });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "title", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5208), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, "What is Lorem Ipsum?", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5209), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5214), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, "Why do we use it?", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5215), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5216), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, "Where does it come from?", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5217), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, "Where can I get some?", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5219), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5318), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5319), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5322), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5323), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5324), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5325), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4110), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4111), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4134), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4134), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4156), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4157), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3892), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3892), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3907), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3908), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3947), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3947), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("9d9b9471-ed3d-47d4-b162-9625e98291cf"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4584), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, 1, "Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4585), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("4e9a4661-91e8-44b5-876d-d6330ef865a2"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4605), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, 1, "Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4606), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("a5258201-c865-4807-8090-756e14c081d7"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4619), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4619), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("c7f6c399-9d41-4249-8864-595d6a057644"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 4, 1, "Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4635), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("e5a89b95-51b6-4ba5-917c-f85fc1af5422"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4648), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 5, 1, "Loi Quach", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4648), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("3c72dc21-f308-4596-9f93-b1731ca23a7d"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4662), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 6, 1, "Dat Do", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4663), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("2d7230ab-efb3-490f-b049-b0bf538dd302"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 7, 1, "Khoa Nguyen", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4676), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("3de5eb20-99c1-487d-aaf2-2cec4c531f50"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4692), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 8, 1, "Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4693), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("c87b5f90-b84e-4605-b493-3e90334b0452"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4705), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 13, 1, "Admin Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(4706), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 400, new Guid("abcd62f9-565d-4afc-9fcc-92f9bbdc0730"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5592), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.400", "Vehicle 400", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5593), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, 3 },
                    { 401, new Guid("3f004f58-4442-447b-8c3c-1e946fcbf695"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5604), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.401", "Vehicle 401", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5605), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, 3 },
                    { 402, new Guid("7edad106-798f-477e-a8b4-eacf8a11c3d3"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5609), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.402", "Vehicle 402", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5610), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, 3 },
                    { 403, new Guid("86db9853-9e97-4612-841d-c842f2e4b96a"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5614), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.403", "Vehicle 403", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5614), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, 3 },
                    { 404, new Guid("1d22a0ec-a0a6-4556-96ad-ee575d1c36c6"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5618), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.404", "Vehicle 404", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5619), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, 3 },
                    { 405, new Guid("1961263e-9614-4860-8dd1-516d45a8d948"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5624), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.405", "Vehicle 405", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5625), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, 3 },
                    { 406, new Guid("1f0e9cc9-b611-4600-b6bd-9e6daff2c7b1"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5631), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.406", "Vehicle 406", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5631), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, 3 },
                    { 407, new Guid("baadcfd9-888a-4e1f-a48f-45b8f8401b23"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.407", "Vehicle 407", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5636), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, 3 },
                    { 408, new Guid("a1dfa0fa-01cf-4847-be83-f94f9a79517b"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5640), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.408", "Vehicle 408", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5640), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, 3 },
                    { 409, new Guid("4db78009-d355-4101-b304-275c026da274"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5644), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.409", "Vehicle 409", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5645), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, 3 },
                    { 410, new Guid("48f93533-4831-4e9c-86de-e56f2467aa85"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5649), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.410", "Vehicle 410", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5649), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, 3 },
                    { 411, new Guid("bc0f9d8f-8436-4b68-be58-cd8363070681"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5653), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.411", "Vehicle 411", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5654), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, 3 },
                    { 412, new Guid("da793b21-1813-428c-a4f0-685f91932135"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5658), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.412", "Vehicle 412", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5658), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, 3 },
                    { 413, new Guid("5eb8f344-1c92-46e3-b8ea-e140b9559a86"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5663), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.413", "Vehicle 413", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5664), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, 3 },
                    { 414, new Guid("f7318d65-04be-4535-9c6d-a12375f29f5a"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5670), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.414", "Vehicle 414", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5671), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, 3 },
                    { 415, new Guid("d3f68866-af64-495a-bf36-e81d3cf6da4c"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5674), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.415", "Vehicle 415", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5675), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, 3 },
                    { 416, new Guid("049d1b04-cc3b-4988-8d01-70eaa4942ba3"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5679), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.416", "Vehicle 416", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5680), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, 3 },
                    { 417, new Guid("c412a13f-1a1a-4cce-bb30-51ca06f28a6f"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5683), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.417", "Vehicle 417", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5684), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, 3 },
                    { 418, new Guid("97f82233-ff10-467e-83ae-db8f525d2574"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5726), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.418", "Vehicle 418", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5727), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, 3 },
                    { 419, new Guid("67a1ae95-8f36-4441-bb30-14520ee6c608"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5731), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.419", "Vehicle 419", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5731), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, 3 },
                    { 420, new Guid("5a83020c-40f8-49d3-823c-9fba987ac74d"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5735), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.420", "Vehicle 420", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5736), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, 3 },
                    { 421, new Guid("1f09e29a-70bc-46c1-ba8b-79fd01698b7f"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5739), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.421", "Vehicle 421", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5740), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, 3 },
                    { 422, new Guid("711831bc-15e2-481f-b566-a521ef8c2e74"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5746), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.422", "Vehicle 422", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5747), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, 3 },
                    { 423, new Guid("3fdbad75-805f-45b1-9e58-825d9547b10b"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5750), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.423", "Vehicle 423", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5751), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, 3 },
                    { 424, new Guid("523c2a12-50d1-45c7-95b9-a3a424b75eb8"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.424", "Vehicle 424", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5756), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, 3 },
                    { 425, new Guid("f5a9d7bf-dc2c-4f87-8de9-35d8cfd8cd08"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5759), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.425", "Vehicle 425", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5760), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, 3 },
                    { 426, new Guid("cba72380-aa70-49d8-9312-3e977bad7fd2"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5763), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.426", "Vehicle 426", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5764), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, 3 },
                    { 427, new Guid("bbe608fd-85a9-428a-9c61-3f48703dcef6"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5768), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.427", "Vehicle 427", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5769), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, 3 },
                    { 428, new Guid("e70abd8e-db92-4e01-8f4b-20540439f411"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5772), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.428", "Vehicle 428", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5773), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, 3 },
                    { 429, new Guid("c22bdaf5-1e7c-422d-a52c-6bb64cd2bdc3"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5778), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.429", "Vehicle 429", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5778), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, 3 },
                    { 430, new Guid("266dd0ae-4f6f-4caa-b707-e9a8a3a6630a"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5785), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.430", "Vehicle 430", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5785), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, 3 },
                    { 431, new Guid("e5def3cb-d9d6-41b3-bee0-ee9b3d24137d"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5789), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.431", "Vehicle 431", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5790), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, 3 },
                    { 432, new Guid("b078c7cd-fcbb-4c01-97eb-13c3188cf3a2"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5793), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.432", "Vehicle 432", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5794), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, 3 },
                    { 433, new Guid("e82232e2-d94c-46d2-a8da-9aec3dcfa0d7"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5798), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.433", "Vehicle 433", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5799), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, 3 },
                    { 434, new Guid("60358697-5159-401b-a053-a4f3809b2506"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5802), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.434", "Vehicle 434", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5803), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, 3 },
                    { 435, new Guid("358ff2dc-119a-4589-ad63-e8ec1c7288da"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5807), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.435", "Vehicle 435", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5807), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, 3 },
                    { 436, new Guid("4fde6a7f-3f3b-401a-9b18-e3414d8430ec"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5811), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.436", "Vehicle 436", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5812), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, 3 },
                    { 437, new Guid("61bc338b-ebff-481f-aa1b-9d11d6b33e10"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5815), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.437", "Vehicle 437", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5816), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, 3 },
                    { 438, new Guid("14f823e5-3e44-4b17-986a-a7386ab97c97"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5822), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.438", "Vehicle 438", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5823), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, 3 },
                    { 439, new Guid("31c12755-0dfa-4a9b-83b5-e4b53f3237b6"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5827), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.439", "Vehicle 439", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5827), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, 3 },
                    { 440, new Guid("4befdb7f-3a64-4f3a-b09b-212913377a0b"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5831), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.440", "Vehicle 440", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5832), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, 3 },
                    { 441, new Guid("08afc45c-9ec7-48c6-a98b-4a8ed3d47bbc"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5835), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.441", "Vehicle 441", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5836), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, 3 },
                    { 442, new Guid("72aef63c-5d7b-40ce-829d-c02ab86ffe65"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5840), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.442", "Vehicle 442", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5841), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, 3 },
                    { 443, new Guid("3b3f80a0-5148-4eb1-8da1-898d88029c46"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5844), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.443", "Vehicle 443", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5845), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, 3 },
                    { 444, new Guid("1aa3317c-87b4-4cd0-a97d-e9b300d9d10a"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5849), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.444", "Vehicle 444", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5850), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, 3 },
                    { 445, new Guid("b189c775-f4ad-48ff-8c92-f8ae800a69fb"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5853), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.445", "Vehicle 445", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5854), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, 3 },
                    { 446, new Guid("6717f698-484c-448d-af2a-40dff85c93ce"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5860), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.446", "Vehicle 446", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5861), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, 3 },
                    { 447, new Guid("6de4ba4d-5e83-40d6-bb47-1d9bd861b966"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5864), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.447", "Vehicle 447", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5865), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, 3 },
                    { 448, new Guid("81623fc1-303b-444a-975a-6ac61e92cac1"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5869), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.448", "Vehicle 448", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5869), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, 3 },
                    { 449, new Guid("7bb883b6-37ce-4d61-b7f5-4328c2e1e3c8"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5873), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.449", "Vehicle 449", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5874), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, 3 },
                    { 450, new Guid("c1409eeb-2504-4cac-97bc-5591d767e87a"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5915), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.450", "Vehicle 450", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5915), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, 3 },
                    { 451, new Guid("f10a571a-4a26-4304-a343-329d214cc86c"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5919), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.451", "Vehicle 451", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5920), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, 3 },
                    { 452, new Guid("1e3c757b-a449-47a0-8c12-9e9997cdbfca"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5924), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.452", "Vehicle 452", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5925), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, 3 },
                    { 453, new Guid("b515e5b5-b29b-4df7-ab2e-6a5709fac23f"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5929), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.453", "Vehicle 453", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5929), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, 3 },
                    { 454, new Guid("adb95a16-2721-45fe-92d5-8b049fa633b6"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5935), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.454", "Vehicle 454", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5936), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, 3 },
                    { 455, new Guid("6e3e65a7-0ae9-4b35-9473-efdbd37e58e0"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5940), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.455", "Vehicle 455", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5941), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, 3 },
                    { 456, new Guid("8199be41-1af9-4e5d-b5a4-d6ddd21db638"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5944), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.456", "Vehicle 456", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5945), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, 3 },
                    { 457, new Guid("b56abcb1-33d3-470d-be08-5c50a766097b"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5949), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.457", "Vehicle 457", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5950), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, 3 },
                    { 458, new Guid("0598928a-74bf-4d7a-9a7c-4ffd6b3ba2e8"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.458", "Vehicle 458", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5954), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, 3 },
                    { 459, new Guid("77b5b25b-f734-429e-8e74-7b69d570eb56"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5958), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.459", "Vehicle 459", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5958), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, 3 },
                    { 460, new Guid("10575d38-896c-407e-b29e-c22f7814d6ce"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.460", "Vehicle 460", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5963), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, 3 },
                    { 461, new Guid("9cbe23af-7053-4aa9-bf5f-94e562e5bfe5"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.461", "Vehicle 461", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5968), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, 3 },
                    { 462, new Guid("73b9f9a3-455d-413b-9e4c-c8ba8b2baff3"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5975), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.462", "Vehicle 462", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5975), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, 3 },
                    { 463, new Guid("32e95300-54c2-4fd8-9969-a012fc25b1ff"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5979), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.463", "Vehicle 463", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5980), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, 3 },
                    { 464, new Guid("0f491f53-3b76-4c69-8bab-19bcb48f65a9"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5984), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.464", "Vehicle 464", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5984), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, 3 },
                    { 465, new Guid("830787eb-42c2-460e-bed1-9328a1ac17fe"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5988), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.465", "Vehicle 465", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5988), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, 3 },
                    { 466, new Guid("4d58de1c-9dac-4d07-8635-fa5e4c713b26"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5992), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.466", "Vehicle 466", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5993), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, 3 },
                    { 467, new Guid("73022e67-1a9f-4400-aa37-576c0b188608"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5997), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.467", "Vehicle 467", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5997), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, 3 },
                    { 468, new Guid("7af9b9c8-a94d-42d3-a3df-4c1f4cc5b47f"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6001), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.468", "Vehicle 468", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6002), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, 3 },
                    { 469, new Guid("1aaf6d9f-6503-434a-9f98-bd1b2e9b9222"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6005), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.469", "Vehicle 469", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6006), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, 3 },
                    { 470, new Guid("c73a0c67-27d5-415f-85b5-f90b0a8f5e84"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6012), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.470", "Vehicle 470", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6013), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, 3 },
                    { 471, new Guid("35167e9d-35b4-43b5-b49d-a017e3d4b9f8"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6017), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.471", "Vehicle 471", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6017), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, 3 },
                    { 472, new Guid("e8856634-d39a-479f-bcad-db23d320de98"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6021), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.472", "Vehicle 472", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6022), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, 3 },
                    { 473, new Guid("779ae57f-33d8-4d7e-8a16-90a67875da79"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.473", "Vehicle 473", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6026), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, 3 },
                    { 474, new Guid("345cd6a2-7edc-498b-8c7a-e6841b840aca"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6030), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.474", "Vehicle 474", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6030), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, 3 },
                    { 475, new Guid("eb6ecbb2-59ce-489a-bc8f-8517f9796811"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6034), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.475", "Vehicle 475", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6035), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, 3 },
                    { 476, new Guid("7bd76eb4-338d-4646-9eaa-e1f436206731"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6039), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.476", "Vehicle 476", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6039), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, 3 },
                    { 477, new Guid("56c9b516-02f5-4785-9e4a-84beeb987a24"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6043), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.477", "Vehicle 477", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6044), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, 3 },
                    { 478, new Guid("59e5d3ee-63ce-46b6-a8c1-14b192be6200"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6050), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.478", "Vehicle 478", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6051), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, 3 },
                    { 479, new Guid("b380500d-687c-4127-ad1d-6664260d4afd"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6054), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.479", "Vehicle 479", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6055), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, 3 },
                    { 480, new Guid("3f31168e-2922-48a3-8a8c-7d4cae65fd2f"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6098), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.480", "Vehicle 480", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6099), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, 3 },
                    { 481, new Guid("83d71291-bf92-4539-b6b4-4832a02b5dd2"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6103), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.481", "Vehicle 481", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6104), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, 3 },
                    { 482, new Guid("0057142b-6d43-4ec3-bf78-35746b4876aa"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6107), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.482", "Vehicle 482", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6108), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, 3 },
                    { 483, new Guid("9124c31c-275d-4c91-a527-520091801759"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6112), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.483", "Vehicle 483", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6112), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, 3 },
                    { 484, new Guid("8c432523-2135-4d88-8f73-10e99466b018"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6116), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.484", "Vehicle 484", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6117), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, 3 },
                    { 485, new Guid("239dd2b3-e16a-41ba-b098-b784f3c9dba0"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6121), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.485", "Vehicle 485", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6121), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, 3 },
                    { 486, new Guid("d1ca5ef9-2d18-45e1-9cb5-ab83984f5d98"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6127), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.486", "Vehicle 486", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6128), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, 3 },
                    { 487, new Guid("fde50e7b-7a74-47fe-a375-56296d0896d6"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6132), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.487", "Vehicle 487", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6133), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, 3 },
                    { 488, new Guid("9fcc6b22-096f-4374-a528-198286826a14"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6136), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.488", "Vehicle 488", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6137), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, 3 },
                    { 489, new Guid("fd7b5455-c47f-4dfb-8f0e-9dcde8006509"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6140), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.489", "Vehicle 489", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6141), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, 3 },
                    { 490, new Guid("61a6fc6a-7a07-42ce-b665-9c8f5fd71123"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6145), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.490", "Vehicle 490", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6146), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, 3 },
                    { 491, new Guid("08f65fc0-1288-4bb1-8d3f-586613b2b199"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6149), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.491", "Vehicle 491", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6150), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, 3 },
                    { 492, new Guid("1439549d-7515-43b3-9202-81a5a4ee8c84"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6153), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.492", "Vehicle 492", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6154), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, 3 },
                    { 493, new Guid("d84b74c0-9f39-4e9f-bcbf-fe358b094b41"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6158), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.493", "Vehicle 493", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6159), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, 3 },
                    { 494, new Guid("a3742739-1f42-444e-9ff5-36c34e126a11"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6165), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.494", "Vehicle 494", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6165), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, 3 },
                    { 495, new Guid("8f61b903-a95e-4a4c-8fab-7dde34ffb95c"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6169), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.495", "Vehicle 495", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6170), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, 3 },
                    { 496, new Guid("92661f6e-e1d0-4e18-9ea0-b263b7946895"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.496", "Vehicle 496", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6174), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, 3 },
                    { 497, new Guid("38f52ec6-1f34-407c-9bf0-e4e28fd57f84"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6177), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.497", "Vehicle 497", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6178), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, 3 },
                    { 498, new Guid("b882c359-ed1b-4846-941a-6f7b24af8bf2"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6182), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.498", "Vehicle 498", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6183), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, 3 },
                    { 499, new Guid("571e46f0-d440-4a0a-a77e-9a2d8d1cf142"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6186), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.499", "Vehicle 499", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6187), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, 3 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8583), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8583), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8597), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8598), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8608), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8609), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8617), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8618), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8627), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8628), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8638), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8639), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8649), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8649), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8658), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8659), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8668), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8669), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8678), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8679), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8688), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8697), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8698), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8706), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8707), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8717), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8717), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8726), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8727), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8735), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8735), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8744), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8745), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8794), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 269, DateTimeKind.Unspecified).AddTicks(8795), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "ceiling_extra_price", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5387), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5388), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5443), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5444), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5453), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5454), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5461), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5462), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5469), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5470), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5478), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5479), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5487), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5488), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5495), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5496), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5503), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5504), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5513), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5513), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5521), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5522), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5529), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5530), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5537), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5538), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3971), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(3972), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4082), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4083), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4181), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4182), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4210), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4211), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4272), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4273), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4292), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4293), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4309), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(4309), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, new Guid("11d1a839-6db8-47c2-bbb5-d71cef4a2f6c"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5575), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5576), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("c8798619-f6b6-4b79-b735-5f506e10fcef"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5581), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5582), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("2f426bb7-2c48-43a2-83c8-d1f1bd44b194"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5588), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("af4c3699-00f0-4bdb-9f1d-b17de64e60e3"), new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5590), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(5590), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6329), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6330), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6334), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6335), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6337), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6337), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6339), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6339), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6341), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6342), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6344), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6345), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6346), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6347), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6348), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 23, 34, 45, 270, DateTimeKind.Unspecified).AddTicks(6349), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
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
