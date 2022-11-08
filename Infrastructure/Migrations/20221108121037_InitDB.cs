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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("4ce6849d-5679-4daf-a84f-11922384b586")),
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
                    point = table.Column<double>(type: "double precision", nullable: true),
                    rated_trips = table.Column<int>(type: "integer", nullable: false),
                    cancelled_trips = table.Column<int>(type: "integer", nullable: false),
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 410, DateTimeKind.Unspecified).AddTicks(6870), new TimeSpan(0, 7, 0, 0, 0))),
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("cf4199a0-cabc-4b8a-b1fe-febaacda955d")),
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
                    { 1, new Guid("6c045326-e78f-4043-82fe-2f3b471bbd2f"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8709), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8710), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("7ca3fb93-708a-4ea6-86d2-55d3796d58e9"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8716), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8717), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("0bdd8478-1c77-4e39-b43f-3e2b9a625db0"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8714), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8715), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 8, "You have arrived, see you again in a next trip.", 1, "Complete trip", 0 }
                });

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "path", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("e2137535-0b94-46b5-851d-6ecf2bc7d09a"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(118), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(136), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("9c32ece3-e020-484d-a815-865f7006d5c5"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(151), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(152), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("32d42ef1-4ae1-4af9-954d-abe12befaf47"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(159), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(160), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("0efc792e-39fc-45bf-80e9-319aa29f586c"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(167), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("876d4fe0-d9ac-4c03-b14c-2e19ec4ea58f"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(175), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("1baa7849-d0d9-482b-ba01-dc976c480742"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(184), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(185), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("7e170e75-4a69-4f78-a5d4-2e57480cafc7"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(192), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(193), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("04d91027-1c4f-4376-bbbe-a0588718d060"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(200), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(200), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("bbc85f80-9add-4391-8dc2-b160bc5b6b20"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(210), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(211), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("13d6c84d-9f46-4cb1-a541-f5106359c701"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(219), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(220), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("606162c3-0c58-43db-874a-59f3fd9e2be0"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(227), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(228), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("51ed9c94-1d30-437c-ba61-f3b99ec0fcfe"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(234), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(235), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("f96bb8e5-1bda-450f-81e3-b267ed8ca344"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(242), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(242), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "pricings",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "discount", "lower_bound", "updated_at", "updated_by", "upper_bound" },
                values: new object[,]
                {
                    { 1, new Guid("5a2588c6-83fb-42ca-83e3-b87a0cd8f0eb"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8797), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.0, null, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8798), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 2, new Guid("c86b87f0-8602-4eee-bd2c-b58c4f7371c9"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8802), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.029999999999999999, 8, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8802), new TimeSpan(0, 7, 0, 0, 0)), 0, 30 },
                    { 3, new Guid("95b40237-c688-48dc-9704-2c279c5a8d4f"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8804), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.050000000000000003, 31, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8805), new TimeSpan(0, 7, 0, 0, 0)), 0, 90 },
                    { 4, new Guid("b3744893-dc1c-428c-ab30-6c27a4d690d0"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8807), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.070000000000000007, 91, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8807), new TimeSpan(0, 7, 0, 0, 0)), 0, null }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6962), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6969), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6970), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6977), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6978), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("0d8bd44c-dfaf-4a94-bbc5-da719db3e4d0"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7284), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7285), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9c23006d-eefe-48ca-baeb-0879e3185844"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7290), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7291), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5f1a145f-9f39-4f05-a250-08c981c9d84e"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7293), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7293), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("891db093-bab7-4460-868c-14a28c1d14cc"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7298), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7299), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4e285625-baf8-44ed-9327-d2a117b8e887"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7300), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7301), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6a0eba34-cb14-46c6-a793-d192ee159b2d"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7305), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7305), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d001f5bf-f004-4e24-b724-f75ef6376a03"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7307), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7308), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("eafbb3e1-ab15-4e48-911a-ce88e434c569"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7309), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7310), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("97761135-2819-47c7-9f57-873f0608e1ff"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7311), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7312), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("4fd0681a-3e9f-4685-8387-f80400cab700"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7314), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7315), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3507f113-5060-445a-ae1d-f4a9e710d063"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7317), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("358b6810-bd34-4627-bc91-62ae8507ca9e"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7321), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d3121926-8b5c-4e64-b775-06ef3bf5d402"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7323), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7324), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("12c55eb4-f358-4ac5-8c40-019f06dc4cd4"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7325), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7326), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9b1a981b-b13a-4fdd-9ade-2cef6a6ba75d"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7328), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7328), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6ec98ed0-08d7-4581-832b-b6c2f651c2ee"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7330), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7331), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("aa69918f-58b8-4205-b635-4c45e95ae3aa"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7332), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7333), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("325d85b7-f82f-4ef0-9829-8a7203742637"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7336), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7337), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0e04f867-3a9d-49fa-88ee-dfde1815cd30"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7338), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7339), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d82a29cd-0045-4d44-bf6f-dbf3b0707eb4"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7367), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7368), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("66640bf6-4beb-42ad-b9ec-545c09ff9b12"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7370), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7371), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a1c804a4-9fd4-42f8-a3ea-c6fc7ab6803d"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7373), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7373), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c4d3699a-e916-4c7c-9254-5b8bc531a08d"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7378), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("78e5bcc9-be2d-4527-bc82-38c215668c05"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7380), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e94b0a3e-bf1a-4932-9204-f334a941b412"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7382), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7383), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("38d14641-6924-412f-ae89-14e47251d84f"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7384), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7385), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("407c783c-370c-48b1-9069-a23b544472a2"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7388), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7389), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ddec038e-5a7d-47d8-b77a-c579bed45130"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7391), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7391), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("725b8fcf-d1fb-4af2-9f5e-57c2d358c84b"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7393), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7394), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a80af257-eb6d-4143-91fb-9f23fa615b94"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7395), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7396), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0a5d64e5-c12e-438e-a3ee-002cb970fa79"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7398), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7398), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7f08c6cb-0a9e-4cd5-bcbf-aacc594e5c1d"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7400), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7400), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0321bd3f-348c-4848-9585-87f3ab6a67e3"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7403), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7404), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f28b6f50-c07b-4690-b58b-ddef32faf389"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7405), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7406), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("341353c6-532c-4f9a-88cb-9ddcacce495a"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7409), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7410), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f5f9836d-b9f3-419c-a67c-07bed2095175"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7412), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("75187bf1-981a-41de-9727-0f1025f9be4b"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7414), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7414), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9b1fb28b-b2a0-44a4-82af-96ec4beecf6f"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7416), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7416), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5f110c16-9d23-46be-892d-6c9d38c36cb8"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7418), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7419), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bec7fb7f-a516-4cbf-8848-e63f00c8d342"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7422), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7422), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("12e3a76a-15c7-4281-b601-ba29e5610de5"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7424), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7425), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a6ca9a0d-c228-4b29-8626-e31b50ea4b8b"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7426), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7427), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("3bdda4f0-07af-4419-9d51-4a194c40454f"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7430), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7431), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("d631f669-6f34-4dd4-9129-fd2bae59601e"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7433), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7433), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4474ccbc-601b-413f-918b-4ba09affef8a"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7435), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7435), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7c561396-c460-43e0-bca9-937ef9873937"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7437), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7438), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2d0e36b6-acff-4088-8767-06ec21c6397d"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7439), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7440), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a6836512-7a39-4b1b-8fff-ff167a0dd5f3"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7442), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7442), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d2d84e05-416a-4015-98f6-aa34b2bb28c0"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7444), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7445), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b97cdb03-d527-4e09-8a8c-c712e2b3b429"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7446), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7447), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("37526dda-f0f3-4759-8442-f614520cb035"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7451), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7451), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a15b174c-64ec-4448-b299-0335b2cde19c"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7454), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7455), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("60534c4c-235a-475d-ac52-5120cd25cf7c"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7457), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7458), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("94bf8d27-fb90-4f59-94a3-b4c75974c6e3"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7459), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7460), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0464a4db-4996-4480-b445-affe2b8c8296"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7462), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7462), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("94a97d38-b0bf-4cb7-994d-71768f0f0fd5"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7464), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7465), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7bb0872e-c1d1-40fb-bdfb-83a7b445bb7a"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7466), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7467), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("02a86c6b-7128-448a-a7e9-6827e1b83401"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7469), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7469), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("20d6bd38-b3db-44b7-bd59-53d1f35d6a16"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7472), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7473), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d9427308-e9c9-4cd6-803e-efb34f37e222"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7475), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7476), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fac26675-0869-42c3-aa6d-d750cb5789a8"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7500), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7501), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bbb6ee4f-7717-48bb-8fb7-b2b4d7642496"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7504), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7504), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7ea4840f-39ce-4fb2-ad25-7f9a0621098b"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7507), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7508), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7dcdec6d-a879-4bf2-b37b-e4478d64ee60"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7512), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7513), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("072d140b-014d-4a1d-9a8a-b476e7e16fb4"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7516), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7516), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("82554056-60fd-443a-bdb1-fa85e0b69bb0"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7518), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7519), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fb40f041-46ac-4c62-beff-b1affa9f3936"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7522), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7523), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c04d16a2-1966-4055-93c5-8b20069a6cb3"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7524), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7525), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("caac884f-e512-4b81-86eb-181c642fa372"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7527), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7528), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("90ef0b43-4943-43a0-981c-21a91e9f9501"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7530), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7531), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("4283bf8c-7f2e-475c-880e-4ec07662e0dd"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7533), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("59ca6f30-722b-429f-998a-0856f9ce8331"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7535), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7536), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("deecdca5-222e-4466-b0fa-9d7eff48c6ac"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7538), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7538), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("00f5c5a0-f72e-421a-8d4b-3b58f994738c"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7540), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b92a06f1-8619-483b-8fef-050e5974bc23"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7544), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7544), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("276af88c-2ab5-404d-a7d5-acf40cc129a2"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7546), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7547), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e663881b-bbf8-425b-95e5-68db331d9f45"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7549), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fe6918c7-eadf-4fed-b152-73dd3f312885"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7551), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7552), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9e404135-12ac-49d8-b150-ba7c33a2de4b"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7554), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7554), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("52f3df08-a8bb-41e5-9c6a-26d22f6b8e56"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7556), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7557), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("e9f6fe2d-8012-4bed-a2f4-86b29869c890"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7559), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7560), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("ac0fa84e-60f2-424c-bc8f-b2330463ec08"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7561), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7562), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("82e77aa2-99d6-41e3-a04d-eb431ab5dbd5"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7565), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7566), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("781da764-a90f-4bf0-8863-0e5071870e20"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7568), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7569), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e2f3dc18-ab69-4f22-b544-c52a837525a6"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7375), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7376), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô E2a-10 Đường, D2b Đ. D1, TP. Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam", new Guid("abfa25bc-db02-439e-aec9-3b086eb0e379"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7570), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7571), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trips", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "point", "rated_trips", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 10, 0, new Guid("00bbe46d-1d6b-4c78-9707-88521a61caed"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(395), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Than Thanh Duy", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(396), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 0, new Guid("abe2ecd2-ec0b-43ee-b471-0ab17b98b8b0"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(406), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Nguyen Dang Khoa", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(407), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 0, new Guid("60f9af60-bfd1-4444-b5c9-4c9163153a02"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(416), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Do Trong Dat", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(417), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 100, 0, new Guid("89c90a28-40f9-480b-99cf-9e3811936c25"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(426), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 100", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(426), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 101, 0, new Guid("1b3ddf4b-3ced-4adb-8803-cc8203b57ef0"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(462), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 101", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(463), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 102, 0, new Guid("894f6d4a-00f6-4bb5-867f-0fd5c06fa9a3"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(477), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 102", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(477), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 103, 0, new Guid("4c9b9a03-dddc-454c-86f7-0ddda2eb5895"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(488), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 103", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(489), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 104, 0, new Guid("3f569368-3014-4ec2-b0fb-ffa5d5d09af1"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(524), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 104", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(525), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 105, 0, new Guid("52d5b99c-093a-47a2-b75d-4c42c15052ef"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(536), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 105", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(537), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 106, 0, new Guid("a869e192-093a-4d57-8213-c2270705a51e"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(549), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 106", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(550), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 107, 0, new Guid("93dce5cc-549b-40e8-9a05-cbac5c150aa9"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(560), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 107", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(560), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 108, 0, new Guid("bcfe85d1-be38-46b8-9f2a-34a8e17d1888"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 108", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(571), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 109, 0, new Guid("1c8d51bf-bcd8-4162-b507-80222dc0f68b"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(582), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 109", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(582), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 110, 0, new Guid("daa19010-b36e-404d-87ac-c46ea33c3a5e"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(595), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 110", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(595), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 111, 0, new Guid("cb19a64d-7e77-423d-9f39-13ada41c6689"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(605), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 111", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(606), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 112, 0, new Guid("0a47a98c-573c-4536-ae94-f70468c88c54"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(616), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 112", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(616), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 113, 0, new Guid("4e9dc3e1-2241-47ec-8e5f-aba60a0af2f2"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(626), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 113", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(627), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 114, 0, new Guid("0cb8b94d-5940-4e7c-bd79-2e724489d594"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(638), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 114", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(639), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 115, 0, new Guid("07343d51-1b7a-4840-8cc6-9d5651ab31de"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(672), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 115", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(673), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 116, 0, new Guid("af88bb06-b976-48ba-a463-8a77e2246d2a"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(685), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 116", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(686), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 117, 0, new Guid("829cfb8c-542e-4e67-9016-c855e1394d60"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(696), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 117", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(696), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 118, 0, new Guid("3323ec18-9339-42fa-99d2-ad81c881dada"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(711), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 118", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(711), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 119, 0, new Guid("d5ff2c89-8e60-4d80-929e-8da397247832"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(722), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 119", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(723), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 120, 0, new Guid("6a0a174f-df58-41ed-97af-4bf87b3e2ae9"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(733), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 120", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(733), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 121, 0, new Guid("2bf41348-0c48-4a20-bdf4-910c624aa999"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(745), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 121", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(746), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 122, 0, new Guid("ea6439ea-5401-43e1-865a-2476339abd8c"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(758), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 122", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(759), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 123, 0, new Guid("fdc6e4e5-2c2f-4657-91d3-6803596b3fae"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(768), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 123", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(769), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 124, 0, new Guid("952237d8-0e79-4fb0-bc5d-699f7f821d01"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(779), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 124", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(780), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 125, 0, new Guid("e4c1b33d-8b65-4fad-98ae-1a32cd3b74b9"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(790), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 125", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(791), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 126, 0, new Guid("b9bf44fa-6bd4-422c-9e37-126ecc50b782"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(803), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 126", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(803), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 127, 0, new Guid("2b43486d-5e3a-46fc-a6c7-c6b64e0f4b28"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(858), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 127", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(859), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 128, 0, new Guid("02babe5a-65e4-407c-82a1-7073ca876e37"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 128", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(872), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 129, 0, new Guid("f5a359c0-bccd-4686-b724-8258a5ca6a9a"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(882), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 129", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(882), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 130, 0, new Guid("17930d08-4995-4b51-b942-4089a25fc3ef"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 130", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(895), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 131, 0, new Guid("c9f31068-e759-4f33-bc6c-db96b4402b2c"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(906), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 131", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(906), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 132, 0, new Guid("fd1cf09d-abb7-4d47-ab88-b7561d67f11e"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(916), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 132", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(917), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 133, 0, new Guid("8d990c7d-a831-44f7-b41d-c8659210731a"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(927), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 133", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(928), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 134, 0, new Guid("e1d4a40c-31ce-497b-a17f-e5e4820c1951"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(940), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 134", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(940), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 135, 0, new Guid("b89c3a23-7f5f-4ee2-9d42-0a941d77f3db"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(950), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 135", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(951), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 136, 0, new Guid("2a6c388f-f068-41c5-b390-6000f536d696"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(961), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 136", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(961), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 137, 0, new Guid("bec85ace-e47f-4732-9846-15189ff7e52c"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 137", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(972), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 138, 0, new Guid("b5a38e75-3639-40aa-94ec-f6bd9e12bb6b"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(984), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 138", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(985), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 139, 0, new Guid("41c8b51b-8679-4486-bf64-5c8cd75364cf"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1018), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 139", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1018), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 140, 0, new Guid("23b0a17c-e36e-4b0e-ba4e-b5dac8640100"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1030), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 140", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1031), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 141, 0, new Guid("7048c1b4-e876-4b0d-9d6e-ff98145e101a"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1041), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 141", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1042), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 142, 0, new Guid("d2fae8c9-2674-4829-bc86-1da04a62da0b"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1054), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 142", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1055), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 143, 0, new Guid("faddd42b-2fd8-4194-8436-085af0097b6b"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1065), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 143", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1065), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 144, 0, new Guid("4765c412-ce00-4fb4-922c-699cdba97faa"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1076), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 144", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1076), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 145, 0, new Guid("fb6c29fd-07e4-46bb-9096-3d37423b5335"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1086), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 145", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1087), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 146, 0, new Guid("53ae9217-e2f6-4eae-9c2d-c98eb3182881"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1099), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 146", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1100), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 147, 0, new Guid("8e29d084-7747-42a9-aa19-d0fdd892f6cf"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1110), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 147", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1110), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 148, 0, new Guid("6e3c1540-b0b5-4bfd-835a-67007c740eb7"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1120), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 148", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1121), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 149, 0, new Guid("718c7d67-621f-4d3f-95f6-f957f58f4199"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1131), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 149", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1131), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 150, 0, new Guid("f916c583-39b1-4759-913b-4f4388c4fca4"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1143), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 150", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1144), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 151, 0, new Guid("45210313-2cfc-4d5a-95dd-f463ab1ca916"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1177), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 151", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1178), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 152, 0, new Guid("affdd7ae-6cd1-4583-a3a3-33a33fa51b08"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1189), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 152", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1190), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 153, 0, new Guid("8d2771d8-e129-44b3-8254-be882109a052"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1202), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 153", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1202), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 154, 0, new Guid("b9482e8a-3bc6-403c-8aea-ab9e0d39a098"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1215), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 154", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1215), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 155, 0, new Guid("74c9a49c-4594-4595-97f1-6f498616901d"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 155", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1226), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 156, 0, new Guid("293210d3-17ef-4ef6-80d0-a8dce89e8f3b"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1236), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 156", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1237), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 157, 0, new Guid("2be0f2ff-ca29-4b1d-8a10-eb2e756d4047"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1247), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 157", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1247), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 158, 0, new Guid("575c252e-373e-4bdf-8802-9825c9c6cc6f"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1259), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 158", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1260), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 159, 0, new Guid("6f410c1c-9bd6-42ae-8635-8f7affc3fa7f"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1269), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 159", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1270), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 160, 0, new Guid("1503fefd-7b17-458c-abc3-412ba64aca05"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1280), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 160", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1280), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 161, 0, new Guid("7dbbde45-242d-4aad-9eb0-246b20e6b481"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1290), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 161", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1291), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 162, 0, new Guid("b587afa1-3f22-4c54-9a0c-194d662b000e"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1328), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 162", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1328), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 163, 0, new Guid("5a7f1bff-217a-44e0-bd4c-b4a81baa4e78"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1339), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 163", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1340), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 164, 0, new Guid("616cc43f-8daa-42d0-933c-10fdd4ba165b"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1350), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 164", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1350), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 165, 0, new Guid("51b31730-164b-4085-9b66-cca015e23cf9"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 165", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1361), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 166, 0, new Guid("a75b5520-0e19-47e5-a43f-ee1b65204719"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1373), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 166", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1374), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 167, 0, new Guid("d660a67e-0448-4794-a4c0-5f447f0947a4"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1384), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 167", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1384), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 168, 0, new Guid("6aec557d-2221-496a-8769-295f4525a444"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1394), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 168", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1395), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 169, 0, new Guid("ec222841-bed5-4bd3-8aee-b9a6d29c8711"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1405), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 169", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1406), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 170, 0, new Guid("b2717695-c524-4490-9f89-d70d32d1dded"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1418), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 170", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1418), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 171, 0, new Guid("e513fea1-af17-4efc-83fb-2bf930c92b1c"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1428), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 171", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1429), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 172, 0, new Guid("a1deb59d-038d-4f45-bb3e-b3c5103c2df9"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1439), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 172", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1440), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 173, 0, new Guid("a18f498f-00c5-4b6a-900e-43db07e11dd3"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1450), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 173", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1451), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 174, 0, new Guid("39a41b8e-8f3b-4807-85b5-2567c42bd2cd"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1487), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 174", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1488), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 175, 0, new Guid("8e8f0a2c-68ae-495c-95a3-277ac8214411"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1498), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 175", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1499), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 176, 0, new Guid("5390151d-8b62-4e25-bf4c-3565b78d6c50"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1509), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 176", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1510), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 177, 0, new Guid("0ad48820-1c68-46f9-8418-fb1ce12f259d"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1520), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 177", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1520), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 178, 0, new Guid("43117943-fc3a-486c-9be6-50ebd371b67e"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1532), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 178", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1533), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 179, 0, new Guid("d5ffb1bc-0d47-4335-b35f-7d2a8ed80edb"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1543), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 179", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1544), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 180, 0, new Guid("89a1c21e-7ad9-4a58-b2ed-dba5412f0029"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1553), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 180", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1554), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 181, 0, new Guid("53b9206b-3977-4d04-adad-f14cbe8ae05d"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1564), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 181", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1565), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 182, 0, new Guid("27562a07-8d1e-4c97-940c-f934569be715"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1577), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 182", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1578), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 183, 0, new Guid("166783e8-35ec-4881-81ae-44f8fda101a3"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1588), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 183", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1589), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 184, 0, new Guid("aa8e9a11-a594-47f8-95d1-45f4f9362a2c"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1599), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 184", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1599), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 185, 0, new Guid("168e26e2-eca1-4be9-ae1d-0e7c577d2446"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1609), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 185", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1610), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 186, 0, new Guid("731a10c9-8a91-4cd1-b061-702f0cb0b2dd"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 186", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1647), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 187, 0, new Guid("c8df2987-21ae-467a-838a-b093ce6484cd"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1659), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 187", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1659), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 188, 0, new Guid("8492dd5d-5049-45a0-92f6-33251bf3b49a"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1670), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 188", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1670), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 189, 0, new Guid("962b85f9-8a37-4fa7-b3a1-dcae01ccdb87"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1681), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 189", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1681), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 190, 0, new Guid("17b6c733-1f74-4bbe-8115-29957f8d5968"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1693), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 190", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1694), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 191, 0, new Guid("977d3d78-7f5a-46e6-99da-299ae4e8b8df"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 191", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1705), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 192, 0, new Guid("78c6f491-ca9d-46b9-a1c4-319b95472128"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1715), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 192", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1716), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 193, 0, new Guid("71946f42-8e8d-4e0b-abc5-e87b0bd310bd"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1725), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 193", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1726), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 194, 0, new Guid("396db945-f31e-4372-890f-0cab085d17e6"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1737), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 194", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1738), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 195, 0, new Guid("38f2e85c-4283-4bdb-a62e-5da567099aeb"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1748), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 195", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1749), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 196, 0, new Guid("18e8d993-105b-4101-b595-a110d9915237"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1759), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 196", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1759), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 197, 0, new Guid("b9c94847-233d-4704-aff3-b4db4e263732"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 197", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1770), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 198, 0, new Guid("a6d5f78b-abb8-43b3-8594-6e5a914cbef3"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1806), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 198", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1807), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 199, 0, new Guid("910ff0d3-f0ee-48c1-bdc9-5bef4d5da408"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 199", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1819), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 400, 0, new Guid("8295dd55-7be6-4bd7-ba7d-33d62d113969"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1829), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 400", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1830), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 401, 0, new Guid("81ebc3b4-29d4-4df3-b7d0-411c0ff90f48"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1841), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 401", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1842), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 402, 0, new Guid("dada7df2-7052-419d-b762-4cbf0c06a174"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1854), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 402", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1855), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 403, 0, new Guid("a677a45b-4d5f-4dc8-93ad-02c28d1a7c94"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1865), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 403", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1866), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 404, 0, new Guid("042487cf-771b-40f4-bd78-745586aab446"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1876), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 404", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1877), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 405, 0, new Guid("2816ca4b-da19-4cb5-b1d9-9fea9bd1d31a"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1887), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 405", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1888), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 406, 0, new Guid("b85b8923-d676-4642-9389-b619a4d5da3c"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1899), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 406", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1900), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 407, 0, new Guid("5d19104c-8cd4-4e48-b10a-b3bb3d56588f"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1910), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 407", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1910), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 408, 0, new Guid("e3aa69aa-3147-45c5-8621-d27919dccee7"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1920), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 408", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1921), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 409, 0, new Guid("58b2cb5f-90b0-4dec-af75-188747587446"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1931), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 409", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1932), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 410, 0, new Guid("66a29de3-3b75-48c3-b55f-2b0375a4d980"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1967), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 410", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1968), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 411, 0, new Guid("f192bb5e-6355-4c12-8ad9-d28474aede71"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1979), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 411", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1980), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 412, 0, new Guid("f0d3bbad-03ae-4ade-90ba-98767e0233fd"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1990), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 412", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(1991), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 413, 0, new Guid("3541f946-4c63-4ea2-bacc-6bdab842ffe2"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2001), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 413", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2002), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 414, 0, new Guid("b4e952d8-344f-4a2a-92ab-bd726348b147"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2013), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 414", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2014), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 415, 0, new Guid("68f65b86-6a40-4de0-b462-9dde27569b66"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2024), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 415", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2025), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 416, 0, new Guid("aceb31ca-f6ae-4076-b6b5-251163157a8d"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2034), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 416", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2035), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 417, 0, new Guid("4910dcdd-f4c7-49b1-9111-e464bff1ccc4"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2047), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 417", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2048), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 418, 0, new Guid("8cdb2eed-13d7-4d7a-8e86-1db120c44005"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2060), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 418", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2061), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 419, 0, new Guid("d1d75cd3-6221-45d5-b2dd-0a5751298f51"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2104), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 419", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2105), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 420, 0, new Guid("6a46d76f-ddb8-4107-92ae-49ffa15428e0"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2118), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 420", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2119), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 421, 0, new Guid("fc2eb45e-e9c8-405f-811b-17592b34074f"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2128), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 421", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2129), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 422, 0, new Guid("561f5b03-17e6-4544-9cad-45c5f31651d2"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 422", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2142), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 423, 0, new Guid("b0291822-f40a-48f1-8148-b8aaedbc378f"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2152), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 423", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2152), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 424, 0, new Guid("80c4f0ab-8239-4d64-a63a-76ed49e86138"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2162), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 424", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2163), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 425, 0, new Guid("e49b380d-38d1-4fa0-8bc4-59cf18b01af2"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 425", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2173), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 426, 0, new Guid("fc5e22db-c7e5-448e-9830-83a32813e8de"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2185), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 426", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2186), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 427, 0, new Guid("1c5f6f3e-7425-451a-a67b-a2f8ca4358c6"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2195), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 427", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2196), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 428, 0, new Guid("f4da03f7-3c07-44b4-8280-fa402776bf0f"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2206), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 428", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2207), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 429, 0, new Guid("204e21c7-73dd-4e5b-9307-0fdc342a3cc4"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2216), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 429", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2217), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 430, 0, new Guid("59877a1f-2c90-40ec-a8f8-1fb432ecde64"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 430", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2229), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 431, 0, new Guid("fa1a7286-501e-456a-9a2d-b931bc9fb6ad"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2261), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 431", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2261), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 432, 0, new Guid("c60af5a0-c166-4252-986f-3b77ef9dee6f"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 432", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2273), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 433, 0, new Guid("03060fe4-caf7-49bc-9c82-7eac6c9e8f98"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2284), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 433", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2285), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 434, 0, new Guid("2bc91d3f-95c3-4119-abcb-90fc5b66437d"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2297), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 434", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2297), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 435, 0, new Guid("f7598527-0d69-4ea5-8126-68467a2a8b29"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2307), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 435", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2308), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 436, 0, new Guid("01714dfd-8750-4c59-b256-69c126677907"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2318), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 436", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2319), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 437, 0, new Guid("0bce9b63-1751-42bb-8581-469d368de5e9"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2329), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 437", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2329), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 438, 0, new Guid("eb144550-a1c6-4604-bf17-e44434dc49a4"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2341), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 438", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2342), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 439, 0, new Guid("8e807dbf-3b68-4d03-8728-2585f5e7b2d5"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2351), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 439", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2352), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 440, 0, new Guid("b722500b-4417-4e76-8962-dda0d2619038"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2362), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 440", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2363), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 441, 0, new Guid("e80f30f9-5259-4a7e-8d95-070bd985a426"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2373), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 441", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2374), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 442, 0, new Guid("074fe219-8ff8-432e-b804-1247d416db69"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2385), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 442", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2386), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 443, 0, new Guid("4050f221-6fb5-4cd1-a629-e860bdbda4a3"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 443", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2396), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 444, 0, new Guid("4f287427-c925-4305-a6c1-111bc041f165"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2430), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 444", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2431), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 445, 0, new Guid("ba60ee3c-4cd8-48ab-bd96-2adc22f4c912"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2441), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 445", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2442), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 446, 0, new Guid("ae2b8760-6e07-4202-982d-6700a39e635b"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2454), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 446", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2455), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 447, 0, new Guid("96c54ba3-6833-486d-8859-27fa17cf0d64"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2465), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 447", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2465), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 448, 0, new Guid("8032be87-6a93-4ec3-9d51-155be74f1c64"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2475), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 448", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2476), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 449, 0, new Guid("7781369f-fc30-4bd7-a800-74af2dc3a0b3"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2485), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 449", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2486), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 450, 0, new Guid("dab4f19a-9493-463c-97e6-c534bdf09a21"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2498), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 450", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2498), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 451, 0, new Guid("13061596-5aac-4968-8aab-2dd7051ea48d"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2508), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 451", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2509), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 452, 0, new Guid("efa96d8f-1b37-4be7-8455-6a4d82dc81c2"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2519), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 452", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2520), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 453, 0, new Guid("4d26c078-1af1-4d4f-8ac3-dbc60b767311"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2530), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 453", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2530), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 454, 0, new Guid("ebf80263-b488-41e9-b263-ffb17922c86b"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2542), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 454", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2543), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 455, 0, new Guid("8812de34-85a8-4c4a-b7b8-72641c58649f"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2553), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 455", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2554), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 456, 0, new Guid("e57dd7c3-7d93-4a35-b5a4-615ab2fcad75"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 456", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2588), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 457, 0, new Guid("0fff8093-6258-4c01-93af-d7bc1adf1e32"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2599), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 457", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2600), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 458, 0, new Guid("f85a8be1-aba7-433a-89a6-3cf3cfa20fe1"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2612), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 458", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2613), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 459, 0, new Guid("3c859d2c-0e74-4044-a3cf-c80a298898d8"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2623), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 459", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2624), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 460, 0, new Guid("d7205847-95bc-4a8a-bf91-87972bd26570"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2634), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 460", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2635), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 461, 0, new Guid("9e189895-1698-4449-8997-cf50955a51d5"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2644), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 461", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2645), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 462, 0, new Guid("fee6141f-3b5a-4039-9b6b-34b5947fa8cc"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2657), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 462", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2658), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 463, 0, new Guid("a0c5f121-38f9-496d-a486-b19eccdf095b"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2668), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 463", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2668), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 464, 0, new Guid("e0a2e65c-f7c5-4be7-ae6c-7ee037b2933b"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2678), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 464", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2679), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 465, 0, new Guid("8953c78c-31aa-42da-8bd3-d4e12f362856"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2689), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 465", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2690), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 466, 0, new Guid("3f15e210-8105-4e9e-a29b-ca8e2fdf413f"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2701), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 466", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2702), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 467, 0, new Guid("610c5e44-d3ab-4c82-a022-d176f23088f7"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2712), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 467", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2713), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 468, 0, new Guid("18b81a81-999e-4a74-a7f3-ab44f4d9e050"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2749), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 468", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2750), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 469, 0, new Guid("0bc62894-f932-49ed-9129-49feee3de51c"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2761), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 469", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2762), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 470, 0, new Guid("f0176b52-2e9e-4d71-a537-31c974a7674c"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2774), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 470", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2775), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 471, 0, new Guid("b29fd15a-dd1b-4285-8a41-2077f80b4d42"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2785), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 471", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2785), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 472, 0, new Guid("a67591be-d548-4727-934d-e8933b9b8f23"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2795), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 472", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2796), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 473, 0, new Guid("97d76dbb-3406-46a1-861b-d716e4f967fe"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2806), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 473", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2806), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 474, 0, new Guid("e5d2d496-6f9b-4ead-b036-1fdfaefdb0fc"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 474", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2819), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 475, 0, new Guid("3c16450c-155b-4d64-a4a7-f0fe5b7615f4"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2829), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 475", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2830), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 476, 0, new Guid("462b502a-f5fe-4ca2-b5d7-c07f8c2c6d45"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2840), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 476", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2840), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 477, 0, new Guid("a98822ff-0f2f-47d1-a771-42ff7f769f1a"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2850), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 477", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2851), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 478, 0, new Guid("f82eba5b-7a2e-4590-80a4-1673b0c47a21"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2863), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 478", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2863), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 479, 0, new Guid("f439b0b4-47b5-4fa4-a94a-a6365ae77717"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2873), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 479", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2874), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 480, 0, new Guid("d2cde229-2d2f-4d5d-bfc5-cea9ec8319b2"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2907), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 480", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2908), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 481, 0, new Guid("a2ac8c2d-a0d4-4dcb-8100-5fa99cfdfaca"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2919), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 481", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2920), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 482, 0, new Guid("58ce3e3b-6be5-4643-9239-15a1123cce31"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2932), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 482", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2932), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 483, 0, new Guid("a8bcef34-8ec5-4b2b-b183-a1cd04d2efef"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 483", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2943), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 484, 0, new Guid("479f7e10-c48f-448e-a3e4-e8e3365e07a4"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 484", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2954), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 485, 0, new Guid("c6194abb-bcb8-49d0-805b-1bf6dffe90db"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2964), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 485", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2964), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 486, 0, new Guid("3875d414-0513-4c47-98e1-882a9489d293"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 486", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2977), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 487, 0, new Guid("c8512e69-d8bd-44e1-a2e9-038ccef1c66a"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2987), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 487", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2987), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 488, 0, new Guid("16361707-21d8-40c3-a8e9-a2f7611f1f4c"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2997), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 488", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(2997), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 489, 0, new Guid("cc5ae5b4-de39-4530-bb3c-e7607b6cabf6"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3007), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 489", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3008), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 490, 0, new Guid("e4a94146-40f0-460a-8933-9d7d881fba8f"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3020), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 490", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3021), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 491, 0, new Guid("f3bc7990-39a4-43cc-a010-771068db5b9e"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3030), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 491", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3031), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 492, 0, new Guid("797fac92-def8-463d-99de-89883cef37a9"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3063), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 492", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3064), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 493, 0, new Guid("481482d5-641f-4932-a596-6db720fdd5c3"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3075), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 493", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3076), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 494, 0, new Guid("0de0e24b-9603-46bb-a59c-95112681963c"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3088), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 494", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3089), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 495, 0, new Guid("babbfa1c-38de-486e-b71f-43be659c2219"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3099), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 495", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3099), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 496, 0, new Guid("b8d021ff-ae91-46a8-824b-e60a23a7159b"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3109), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 496", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3110), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 497, 0, new Guid("f3e8e311-182e-4d31-a797-16a8fb13bb73"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3120), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 497", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3120), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 498, 0, new Guid("9e31ea3d-75af-4bfe-b2df-36aca7eafe78"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3132), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 498", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3133), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 499, 0, new Guid("e6c219b8-0744-49b5-bd69-51c548210ba2"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3143), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 499", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3144), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "name", "slot", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("42e6390f-0df1-452a-aeb3-331c60f7e108"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7665), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViRide", 2, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7666), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("d52a4304-c997-4411-817d-f37b89c4d0b7"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7679), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-4", 4, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7679), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("783fa477-b2dd-4c4d-b7b9-1a67a9952e5e"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-7", 7, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7689), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3325), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3325), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3332), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3332), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3339), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3339), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3346), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3346), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3353), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3353), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3360), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3360), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 100, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3367), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+100", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3368), new TimeSpan(0, 7, 0, 0, 0)), 0, 100, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 101, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3377), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@100", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3377), new TimeSpan(0, 7, 0, 0, 0)), 0, 100 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 102, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3388), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+101", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3388), new TimeSpan(0, 7, 0, 0, 0)), 0, 101, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 103, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3395), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@101", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3396), new TimeSpan(0, 7, 0, 0, 0)), 0, 101 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 104, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3403), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+102", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3403), new TimeSpan(0, 7, 0, 0, 0)), 0, 102, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 105, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3410), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@102", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3411), new TimeSpan(0, 7, 0, 0, 0)), 0, 102 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 106, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3418), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+103", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3419), new TimeSpan(0, 7, 0, 0, 0)), 0, 103, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 107, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3462), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@103", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3462), new TimeSpan(0, 7, 0, 0, 0)), 0, 103 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 108, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3471), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+104", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3471), new TimeSpan(0, 7, 0, 0, 0)), 0, 104, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 109, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3480), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@104", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3480), new TimeSpan(0, 7, 0, 0, 0)), 0, 104 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 110, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3487), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+105", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3488), new TimeSpan(0, 7, 0, 0, 0)), 0, 105, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 111, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3495), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@105", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3495), new TimeSpan(0, 7, 0, 0, 0)), 0, 105 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 112, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3503), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+106", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3503), new TimeSpan(0, 7, 0, 0, 0)), 0, 106, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 113, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@106", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3511), new TimeSpan(0, 7, 0, 0, 0)), 0, 106 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 114, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+107", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3518), new TimeSpan(0, 7, 0, 0, 0)), 0, 107, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 115, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3525), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@107", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3526), new TimeSpan(0, 7, 0, 0, 0)), 0, 107 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 116, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+108", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3533), new TimeSpan(0, 7, 0, 0, 0)), 0, 108, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 117, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@108", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3541), new TimeSpan(0, 7, 0, 0, 0)), 0, 108 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 118, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+109", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3548), new TimeSpan(0, 7, 0, 0, 0)), 0, 109, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 119, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3555), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@109", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3556), new TimeSpan(0, 7, 0, 0, 0)), 0, 109 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 120, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3563), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+110", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3563), new TimeSpan(0, 7, 0, 0, 0)), 0, 110, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 121, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3570), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@110", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3571), new TimeSpan(0, 7, 0, 0, 0)), 0, 110 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 122, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3578), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+111", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3578), new TimeSpan(0, 7, 0, 0, 0)), 0, 111, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 123, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3585), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@111", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3586), new TimeSpan(0, 7, 0, 0, 0)), 0, 111 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 124, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3593), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+112", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3593), new TimeSpan(0, 7, 0, 0, 0)), 0, 112, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 125, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3600), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@112", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3601), new TimeSpan(0, 7, 0, 0, 0)), 0, 112 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 126, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3607), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+113", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3608), new TimeSpan(0, 7, 0, 0, 0)), 0, 113, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 127, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3615), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@113", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3615), new TimeSpan(0, 7, 0, 0, 0)), 0, 113 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 128, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3646), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+114", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3647), new TimeSpan(0, 7, 0, 0, 0)), 0, 114, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 129, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3654), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@114", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3655), new TimeSpan(0, 7, 0, 0, 0)), 0, 114 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 130, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3661), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+115", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3662), new TimeSpan(0, 7, 0, 0, 0)), 0, 115, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 131, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3669), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@115", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3670), new TimeSpan(0, 7, 0, 0, 0)), 0, 115 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 132, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3677), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+116", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3678), new TimeSpan(0, 7, 0, 0, 0)), 0, 116, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 133, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3684), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@116", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3685), new TimeSpan(0, 7, 0, 0, 0)), 0, 116 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 134, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3692), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+117", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3693), new TimeSpan(0, 7, 0, 0, 0)), 0, 117, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 135, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3699), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@117", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3700), new TimeSpan(0, 7, 0, 0, 0)), 0, 117 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 136, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3707), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+118", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3707), new TimeSpan(0, 7, 0, 0, 0)), 0, 118, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 137, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3715), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@118", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3715), new TimeSpan(0, 7, 0, 0, 0)), 0, 118 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 138, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3722), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+119", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3723), new TimeSpan(0, 7, 0, 0, 0)), 0, 119, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 139, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3730), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@119", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3731), new TimeSpan(0, 7, 0, 0, 0)), 0, 119 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 140, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3738), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+120", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3738), new TimeSpan(0, 7, 0, 0, 0)), 0, 120, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 141, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3746), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@120", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3747), new TimeSpan(0, 7, 0, 0, 0)), 0, 120 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 142, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3754), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+121", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3754), new TimeSpan(0, 7, 0, 0, 0)), 0, 121, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 143, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3761), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@121", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3762), new TimeSpan(0, 7, 0, 0, 0)), 0, 121 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 144, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+122", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3769), new TimeSpan(0, 7, 0, 0, 0)), 0, 122, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 145, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3776), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@122", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3777), new TimeSpan(0, 7, 0, 0, 0)), 0, 122 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 146, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3784), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+123", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3784), new TimeSpan(0, 7, 0, 0, 0)), 0, 123, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 147, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3815), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@123", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3816), new TimeSpan(0, 7, 0, 0, 0)), 0, 123 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 148, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3823), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+124", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3824), new TimeSpan(0, 7, 0, 0, 0)), 0, 124, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 149, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3830), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@124", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3831), new TimeSpan(0, 7, 0, 0, 0)), 0, 124 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 150, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3838), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+125", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3838), new TimeSpan(0, 7, 0, 0, 0)), 0, 125, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 151, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3845), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@125", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3846), new TimeSpan(0, 7, 0, 0, 0)), 0, 125 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 152, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3852), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+126", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3853), new TimeSpan(0, 7, 0, 0, 0)), 0, 126, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 153, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3860), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@126", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3861), new TimeSpan(0, 7, 0, 0, 0)), 0, 126 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 154, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3868), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+127", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3868), new TimeSpan(0, 7, 0, 0, 0)), 0, 127, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 155, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3875), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@127", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3876), new TimeSpan(0, 7, 0, 0, 0)), 0, 127 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 156, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3882), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+128", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3883), new TimeSpan(0, 7, 0, 0, 0)), 0, 128, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 157, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3890), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@128", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3890), new TimeSpan(0, 7, 0, 0, 0)), 0, 128 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 158, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3897), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+129", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3898), new TimeSpan(0, 7, 0, 0, 0)), 0, 129, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 159, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@129", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3905), new TimeSpan(0, 7, 0, 0, 0)), 0, 129 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 160, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3912), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+130", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3913), new TimeSpan(0, 7, 0, 0, 0)), 0, 130, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 161, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3920), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@130", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3920), new TimeSpan(0, 7, 0, 0, 0)), 0, 130 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 162, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3927), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+131", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3928), new TimeSpan(0, 7, 0, 0, 0)), 0, 131, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 163, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3935), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@131", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3935), new TimeSpan(0, 7, 0, 0, 0)), 0, 131 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 164, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+132", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3943), new TimeSpan(0, 7, 0, 0, 0)), 0, 132, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 165, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3950), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@132", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3950), new TimeSpan(0, 7, 0, 0, 0)), 0, 132 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 166, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3957), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+133", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3958), new TimeSpan(0, 7, 0, 0, 0)), 0, 133, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 167, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3964), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@133", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3965), new TimeSpan(0, 7, 0, 0, 0)), 0, 133 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 168, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+134", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3973), new TimeSpan(0, 7, 0, 0, 0)), 0, 134, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 169, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4004), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@134", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4005), new TimeSpan(0, 7, 0, 0, 0)), 0, 134 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 170, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4013), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+135", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4014), new TimeSpan(0, 7, 0, 0, 0)), 0, 135, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 171, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4021), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@135", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4022), new TimeSpan(0, 7, 0, 0, 0)), 0, 135 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 172, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4029), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+136", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4029), new TimeSpan(0, 7, 0, 0, 0)), 0, 136, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 173, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4036), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@136", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4037), new TimeSpan(0, 7, 0, 0, 0)), 0, 136 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 174, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4044), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+137", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4045), new TimeSpan(0, 7, 0, 0, 0)), 0, 137, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 175, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4052), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@137", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4053), new TimeSpan(0, 7, 0, 0, 0)), 0, 137 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 176, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4060), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+138", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4060), new TimeSpan(0, 7, 0, 0, 0)), 0, 138, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 177, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4067), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@138", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4068), new TimeSpan(0, 7, 0, 0, 0)), 0, 138 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 178, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4075), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+139", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4076), new TimeSpan(0, 7, 0, 0, 0)), 0, 139, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 179, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4083), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@139", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4084), new TimeSpan(0, 7, 0, 0, 0)), 0, 139 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 180, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4091), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+140", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4091), new TimeSpan(0, 7, 0, 0, 0)), 0, 140, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 181, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4098), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@140", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4099), new TimeSpan(0, 7, 0, 0, 0)), 0, 140 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 182, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4106), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+141", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4107), new TimeSpan(0, 7, 0, 0, 0)), 0, 141, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 183, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4113), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@141", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4114), new TimeSpan(0, 7, 0, 0, 0)), 0, 141 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 184, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4121), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+142", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4122), new TimeSpan(0, 7, 0, 0, 0)), 0, 142, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 185, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@142", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4130), new TimeSpan(0, 7, 0, 0, 0)), 0, 142 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 186, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4137), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+143", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4138), new TimeSpan(0, 7, 0, 0, 0)), 0, 143, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 187, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4145), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@143", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4145), new TimeSpan(0, 7, 0, 0, 0)), 0, 143 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 188, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4152), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+144", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4152), new TimeSpan(0, 7, 0, 0, 0)), 0, 144, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 189, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4159), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@144", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4160), new TimeSpan(0, 7, 0, 0, 0)), 0, 144 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 190, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+145", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4168), new TimeSpan(0, 7, 0, 0, 0)), 0, 145, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 191, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4197), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@145", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4198), new TimeSpan(0, 7, 0, 0, 0)), 0, 145 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 192, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4206), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+146", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4207), new TimeSpan(0, 7, 0, 0, 0)), 0, 146, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 193, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4214), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@146", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4215), new TimeSpan(0, 7, 0, 0, 0)), 0, 146 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 194, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4221), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+147", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4222), new TimeSpan(0, 7, 0, 0, 0)), 0, 147, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 195, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4229), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@147", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4230), new TimeSpan(0, 7, 0, 0, 0)), 0, 147 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 196, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4237), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+148", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4238), new TimeSpan(0, 7, 0, 0, 0)), 0, 148, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 197, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4245), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@148", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4245), new TimeSpan(0, 7, 0, 0, 0)), 0, 148 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 198, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4252), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+149", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4253), new TimeSpan(0, 7, 0, 0, 0)), 0, 149, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 199, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4260), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@149", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4261), new TimeSpan(0, 7, 0, 0, 0)), 0, 149 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 200, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4268), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+150", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4268), new TimeSpan(0, 7, 0, 0, 0)), 0, 150, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 201, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4275), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@150", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4276), new TimeSpan(0, 7, 0, 0, 0)), 0, 150 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 202, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4283), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+151", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4284), new TimeSpan(0, 7, 0, 0, 0)), 0, 151, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 203, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4291), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@151", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4291), new TimeSpan(0, 7, 0, 0, 0)), 0, 151 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 204, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4298), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+152", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4299), new TimeSpan(0, 7, 0, 0, 0)), 0, 152, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 205, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4308), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@152", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4308), new TimeSpan(0, 7, 0, 0, 0)), 0, 152 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 206, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4315), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+153", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4316), new TimeSpan(0, 7, 0, 0, 0)), 0, 153, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 207, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4323), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@153", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4324), new TimeSpan(0, 7, 0, 0, 0)), 0, 153 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 208, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+154", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4355), new TimeSpan(0, 7, 0, 0, 0)), 0, 154, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 209, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4362), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@154", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4363), new TimeSpan(0, 7, 0, 0, 0)), 0, 154 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 210, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4370), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+155", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4371), new TimeSpan(0, 7, 0, 0, 0)), 0, 155, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 211, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@155", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4378), new TimeSpan(0, 7, 0, 0, 0)), 0, 155 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 212, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4385), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+156", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4386), new TimeSpan(0, 7, 0, 0, 0)), 0, 156, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 213, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4393), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@156", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4393), new TimeSpan(0, 7, 0, 0, 0)), 0, 156 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 214, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4400), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+157", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4401), new TimeSpan(0, 7, 0, 0, 0)), 0, 157, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 215, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4408), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@157", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4408), new TimeSpan(0, 7, 0, 0, 0)), 0, 157 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 216, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4416), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+158", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4416), new TimeSpan(0, 7, 0, 0, 0)), 0, 158, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 217, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@158", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4424), new TimeSpan(0, 7, 0, 0, 0)), 0, 158 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 218, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4431), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+159", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4431), new TimeSpan(0, 7, 0, 0, 0)), 0, 159, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 219, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4438), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@159", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4439), new TimeSpan(0, 7, 0, 0, 0)), 0, 159 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 220, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4446), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+160", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4446), new TimeSpan(0, 7, 0, 0, 0)), 0, 160, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 221, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4453), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@160", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4454), new TimeSpan(0, 7, 0, 0, 0)), 0, 160 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 222, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4461), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+161", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4461), new TimeSpan(0, 7, 0, 0, 0)), 0, 161, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 223, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@161", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4469), new TimeSpan(0, 7, 0, 0, 0)), 0, 161 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 224, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4476), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+162", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4477), new TimeSpan(0, 7, 0, 0, 0)), 0, 162, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 225, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4484), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@162", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4484), new TimeSpan(0, 7, 0, 0, 0)), 0, 162 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 226, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4491), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+163", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4492), new TimeSpan(0, 7, 0, 0, 0)), 0, 163, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 227, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4499), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@163", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4500), new TimeSpan(0, 7, 0, 0, 0)), 0, 163 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 228, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4506), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+164", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4507), new TimeSpan(0, 7, 0, 0, 0)), 0, 164, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 229, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4514), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@164", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4515), new TimeSpan(0, 7, 0, 0, 0)), 0, 164 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 230, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4546), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+165", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4547), new TimeSpan(0, 7, 0, 0, 0)), 0, 165, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 231, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4555), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@165", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4556), new TimeSpan(0, 7, 0, 0, 0)), 0, 165 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 232, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4563), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+166", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4564), new TimeSpan(0, 7, 0, 0, 0)), 0, 166, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 233, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@166", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4571), new TimeSpan(0, 7, 0, 0, 0)), 0, 166 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 234, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4578), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+167", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4579), new TimeSpan(0, 7, 0, 0, 0)), 0, 167, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 235, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@167", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4587), new TimeSpan(0, 7, 0, 0, 0)), 0, 167 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 236, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4594), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+168", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4595), new TimeSpan(0, 7, 0, 0, 0)), 0, 168, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 237, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4602), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@168", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4603), new TimeSpan(0, 7, 0, 0, 0)), 0, 168 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 238, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4610), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+169", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4610), new TimeSpan(0, 7, 0, 0, 0)), 0, 169, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 239, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4617), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@169", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4618), new TimeSpan(0, 7, 0, 0, 0)), 0, 169 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 240, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4624), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+170", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4625), new TimeSpan(0, 7, 0, 0, 0)), 0, 170, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 241, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4632), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@170", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4633), new TimeSpan(0, 7, 0, 0, 0)), 0, 170 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 242, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4640), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+171", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4640), new TimeSpan(0, 7, 0, 0, 0)), 0, 171, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 243, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@171", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4648), new TimeSpan(0, 7, 0, 0, 0)), 0, 171 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 244, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4655), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+172", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4655), new TimeSpan(0, 7, 0, 0, 0)), 0, 172, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 245, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4662), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@172", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4663), new TimeSpan(0, 7, 0, 0, 0)), 0, 172 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 246, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4670), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+173", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4670), new TimeSpan(0, 7, 0, 0, 0)), 0, 173, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 247, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4677), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@173", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4678), new TimeSpan(0, 7, 0, 0, 0)), 0, 173 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 248, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4685), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+174", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4685), new TimeSpan(0, 7, 0, 0, 0)), 0, 174, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 249, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4692), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@174", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4693), new TimeSpan(0, 7, 0, 0, 0)), 0, 174 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 250, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4700), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+175", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4700), new TimeSpan(0, 7, 0, 0, 0)), 0, 175, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 251, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4707), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@175", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4708), new TimeSpan(0, 7, 0, 0, 0)), 0, 175 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 252, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4737), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+176", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4738), new TimeSpan(0, 7, 0, 0, 0)), 0, 176, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 253, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4746), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@176", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4747), new TimeSpan(0, 7, 0, 0, 0)), 0, 176 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 254, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4754), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+177", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4754), new TimeSpan(0, 7, 0, 0, 0)), 0, 177, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 255, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4761), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@177", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4762), new TimeSpan(0, 7, 0, 0, 0)), 0, 177 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 256, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+178", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 7, 0, 0, 0)), 0, 178, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 257, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4777), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@178", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4777), new TimeSpan(0, 7, 0, 0, 0)), 0, 178 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 258, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4785), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+179", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4785), new TimeSpan(0, 7, 0, 0, 0)), 0, 179, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 259, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4792), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@179", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4793), new TimeSpan(0, 7, 0, 0, 0)), 0, 179 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 260, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4800), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+180", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4800), new TimeSpan(0, 7, 0, 0, 0)), 0, 180, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 261, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4807), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@180", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4808), new TimeSpan(0, 7, 0, 0, 0)), 0, 180 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 262, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4815), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+181", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4816), new TimeSpan(0, 7, 0, 0, 0)), 0, 181, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 263, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4823), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@181", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4823), new TimeSpan(0, 7, 0, 0, 0)), 0, 181 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 264, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4831), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+182", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4832), new TimeSpan(0, 7, 0, 0, 0)), 0, 182, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 265, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4839), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@182", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4839), new TimeSpan(0, 7, 0, 0, 0)), 0, 182 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 266, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4846), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+183", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4847), new TimeSpan(0, 7, 0, 0, 0)), 0, 183, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 267, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4854), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@183", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4854), new TimeSpan(0, 7, 0, 0, 0)), 0, 183 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 268, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4861), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+184", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4862), new TimeSpan(0, 7, 0, 0, 0)), 0, 184, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 269, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4869), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@184", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4869), new TimeSpan(0, 7, 0, 0, 0)), 0, 184 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 270, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4876), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+185", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4877), new TimeSpan(0, 7, 0, 0, 0)), 0, 185, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 271, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4884), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@185", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4885), new TimeSpan(0, 7, 0, 0, 0)), 0, 185 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 272, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4892), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+186", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4892), new TimeSpan(0, 7, 0, 0, 0)), 0, 186, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 273, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4899), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@186", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4900), new TimeSpan(0, 7, 0, 0, 0)), 0, 186 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 274, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4938), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+187", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4939), new TimeSpan(0, 7, 0, 0, 0)), 0, 187, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 275, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4949), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@187", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4949), new TimeSpan(0, 7, 0, 0, 0)), 0, 187 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 276, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4956), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+188", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4957), new TimeSpan(0, 7, 0, 0, 0)), 0, 188, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 277, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4964), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@188", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4965), new TimeSpan(0, 7, 0, 0, 0)), 0, 188 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 278, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4971), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+189", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4972), new TimeSpan(0, 7, 0, 0, 0)), 0, 189, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 279, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4979), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@189", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4980), new TimeSpan(0, 7, 0, 0, 0)), 0, 189 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 280, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4987), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+190", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4987), new TimeSpan(0, 7, 0, 0, 0)), 0, 190, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 281, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4994), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@190", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(4995), new TimeSpan(0, 7, 0, 0, 0)), 0, 190 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 282, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5002), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+191", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5003), new TimeSpan(0, 7, 0, 0, 0)), 0, 191, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 283, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5010), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@191", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5010), new TimeSpan(0, 7, 0, 0, 0)), 0, 191 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 284, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5017), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+192", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5018), new TimeSpan(0, 7, 0, 0, 0)), 0, 192, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 285, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@192", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5025), new TimeSpan(0, 7, 0, 0, 0)), 0, 192 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 286, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5032), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+193", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5033), new TimeSpan(0, 7, 0, 0, 0)), 0, 193, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 287, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5040), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@193", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5041), new TimeSpan(0, 7, 0, 0, 0)), 0, 193 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 288, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5048), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+194", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5048), new TimeSpan(0, 7, 0, 0, 0)), 0, 194, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 289, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5055), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@194", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5056), new TimeSpan(0, 7, 0, 0, 0)), 0, 194 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 290, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5063), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+195", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5063), new TimeSpan(0, 7, 0, 0, 0)), 0, 195, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 291, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5070), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@195", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5071), new TimeSpan(0, 7, 0, 0, 0)), 0, 195 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 292, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5078), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+196", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5079), new TimeSpan(0, 7, 0, 0, 0)), 0, 196, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 293, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5085), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@196", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5086), new TimeSpan(0, 7, 0, 0, 0)), 0, 196 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 294, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5093), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+197", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5093), new TimeSpan(0, 7, 0, 0, 0)), 0, 197, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 295, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5100), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@197", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5101), new TimeSpan(0, 7, 0, 0, 0)), 0, 197 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 296, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5108), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+198", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5109), new TimeSpan(0, 7, 0, 0, 0)), 0, 198, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 297, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5138), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@198", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5139), new TimeSpan(0, 7, 0, 0, 0)), 0, 198 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 298, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5146), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+199", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5147), new TimeSpan(0, 7, 0, 0, 0)), 0, 199, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 299, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5154), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@199", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5155), new TimeSpan(0, 7, 0, 0, 0)), 0, 199 },
                    { 400, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5162), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+400", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5163), new TimeSpan(0, 7, 0, 0, 0)), 0, 400 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 401, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5171), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@400", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5172), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 402, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5179), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+401", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5180), new TimeSpan(0, 7, 0, 0, 0)), 0, 401 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 403, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5187), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@401", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5188), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 404, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5195), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+402", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5196), new TimeSpan(0, 7, 0, 0, 0)), 0, 402 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 405, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5203), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@402", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5203), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 406, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5210), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+403", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5211), new TimeSpan(0, 7, 0, 0, 0)), 0, 403 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 407, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@403", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5218), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 408, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5225), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+404", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5226), new TimeSpan(0, 7, 0, 0, 0)), 0, 404 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 409, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5233), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@404", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5234), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 410, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5241), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+405", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5242), new TimeSpan(0, 7, 0, 0, 0)), 0, 405 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 411, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5249), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@405", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5249), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 412, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+406", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5257), new TimeSpan(0, 7, 0, 0, 0)), 0, 406 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 413, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5264), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@406", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5265), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 414, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5272), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+407", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5273), new TimeSpan(0, 7, 0, 0, 0)), 0, 407 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 415, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5280), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@407", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5280), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 416, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5287), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+408", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5288), new TimeSpan(0, 7, 0, 0, 0)), 0, 408 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 417, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5295), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@408", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5295), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 418, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+409", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5303), new TimeSpan(0, 7, 0, 0, 0)), 0, 409 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 419, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5335), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@409", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5335), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 420, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5343), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+410", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5344), new TimeSpan(0, 7, 0, 0, 0)), 0, 410 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 421, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5351), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@410", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5352), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 422, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5359), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+411", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5359), new TimeSpan(0, 7, 0, 0, 0)), 0, 411 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 423, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5366), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@411", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5367), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 424, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5374), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+412", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5374), new TimeSpan(0, 7, 0, 0, 0)), 0, 412 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 425, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5382), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@412", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5382), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 426, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5389), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+413", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5390), new TimeSpan(0, 7, 0, 0, 0)), 0, 413 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 427, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@413", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5397), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 428, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+414", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5405), new TimeSpan(0, 7, 0, 0, 0)), 0, 414 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 429, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5412), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@414", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5412), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 430, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5419), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+415", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5420), new TimeSpan(0, 7, 0, 0, 0)), 0, 415 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 431, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5427), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@415", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5427), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 432, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5434), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+416", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5435), new TimeSpan(0, 7, 0, 0, 0)), 0, 416 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 433, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5472), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@416", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5473), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 434, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+417", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5481), new TimeSpan(0, 7, 0, 0, 0)), 0, 417 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 435, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5488), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@417", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5489), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 436, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5496), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+418", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5497), new TimeSpan(0, 7, 0, 0, 0)), 0, 418 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 437, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5504), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@418", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5504), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 438, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5511), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+419", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5512), new TimeSpan(0, 7, 0, 0, 0)), 0, 419 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 439, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5519), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@419", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5520), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 440, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5527), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+420", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5527), new TimeSpan(0, 7, 0, 0, 0)), 0, 420 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 441, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5534), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@420", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5535), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 442, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5542), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+421", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5543), new TimeSpan(0, 7, 0, 0, 0)), 0, 421 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 443, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5550), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@421", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5551), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 444, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5558), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+422", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5558), new TimeSpan(0, 7, 0, 0, 0)), 0, 422 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 445, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5565), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@422", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5566), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 446, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5573), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+423", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5574), new TimeSpan(0, 7, 0, 0, 0)), 0, 423 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 447, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5581), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@423", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5581), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 448, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5588), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+424", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5589), new TimeSpan(0, 7, 0, 0, 0)), 0, 424 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 449, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5596), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@424", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5596), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 450, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5603), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+425", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5604), new TimeSpan(0, 7, 0, 0, 0)), 0, 425 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 451, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5611), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@425", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5612), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 452, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5641), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+426", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5641), new TimeSpan(0, 7, 0, 0, 0)), 0, 426 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 453, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5649), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@426", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5650), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 454, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5657), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+427", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5658), new TimeSpan(0, 7, 0, 0, 0)), 0, 427 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 455, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5665), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@427", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5666), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 456, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5672), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+428", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5673), new TimeSpan(0, 7, 0, 0, 0)), 0, 428 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 457, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@428", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5681), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 458, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+429", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5689), new TimeSpan(0, 7, 0, 0, 0)), 0, 429 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 459, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5696), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@429", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5696), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 460, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5703), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+430", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5704), new TimeSpan(0, 7, 0, 0, 0)), 0, 430 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 461, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5711), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@430", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5712), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 462, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5719), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+431", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5720), new TimeSpan(0, 7, 0, 0, 0)), 0, 431 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 463, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5727), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@431", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5728), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 464, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5734), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+432", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5735), new TimeSpan(0, 7, 0, 0, 0)), 0, 432 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 465, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5742), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@432", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5743), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 466, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5750), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+433", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5751), new TimeSpan(0, 7, 0, 0, 0)), 0, 433 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 467, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5758), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@433", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5759), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 468, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5766), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+434", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5766), new TimeSpan(0, 7, 0, 0, 0)), 0, 434 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 469, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5773), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@434", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5774), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 470, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+435", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5782), new TimeSpan(0, 7, 0, 0, 0)), 0, 435 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 471, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5789), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@435", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5789), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 472, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5796), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+436", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5797), new TimeSpan(0, 7, 0, 0, 0)), 0, 436 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 473, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5804), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@436", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5805), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 474, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5834), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+437", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5835), new TimeSpan(0, 7, 0, 0, 0)), 0, 437 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 475, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5843), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@437", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5844), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 476, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5851), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+438", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5852), new TimeSpan(0, 7, 0, 0, 0)), 0, 438 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 477, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5859), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@438", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5859), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 478, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5866), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+439", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5867), new TimeSpan(0, 7, 0, 0, 0)), 0, 439 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 479, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5874), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@439", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5875), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 480, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5882), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+440", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5882), new TimeSpan(0, 7, 0, 0, 0)), 0, 440 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 481, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5889), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@440", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5890), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 482, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5897), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+441", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5898), new TimeSpan(0, 7, 0, 0, 0)), 0, 441 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 483, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5904), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@441", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5905), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 484, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5912), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+442", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5913), new TimeSpan(0, 7, 0, 0, 0)), 0, 442 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 485, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5920), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@442", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5920), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 486, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5927), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+443", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5928), new TimeSpan(0, 7, 0, 0, 0)), 0, 443 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 487, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5935), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@443", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5936), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 488, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5943), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+444", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5943), new TimeSpan(0, 7, 0, 0, 0)), 0, 444 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 489, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5950), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@444", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5951), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 490, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5958), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+445", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5958), new TimeSpan(0, 7, 0, 0, 0)), 0, 445 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 491, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5966), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@445", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5966), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 492, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5973), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+446", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5974), new TimeSpan(0, 7, 0, 0, 0)), 0, 446 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 493, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5981), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@446", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5982), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 494, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5988), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+447", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5989), new TimeSpan(0, 7, 0, 0, 0)), 0, 447 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 495, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5996), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@447", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(5996), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 496, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6026), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+448", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6027), new TimeSpan(0, 7, 0, 0, 0)), 0, 448 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 497, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6036), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@448", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6037), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 498, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6044), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+449", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6045), new TimeSpan(0, 7, 0, 0, 0)), 0, 449 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 499, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6052), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@449", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6052), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 500, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6059), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+450", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6060), new TimeSpan(0, 7, 0, 0, 0)), 0, 450 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 501, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6067), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@450", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6068), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 502, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6075), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+451", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6075), new TimeSpan(0, 7, 0, 0, 0)), 0, 451 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 503, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6082), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@451", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6083), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 504, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6090), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+452", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6091), new TimeSpan(0, 7, 0, 0, 0)), 0, 452 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 505, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6098), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@452", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6098), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 506, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6105), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+453", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6106), new TimeSpan(0, 7, 0, 0, 0)), 0, 453 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 507, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6113), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@453", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6113), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 508, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6120), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+454", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6121), new TimeSpan(0, 7, 0, 0, 0)), 0, 454 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 509, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6128), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@454", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6129), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 510, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6136), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+455", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6136), new TimeSpan(0, 7, 0, 0, 0)), 0, 455 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 511, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6143), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@455", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6144), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 512, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6151), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+456", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6152), new TimeSpan(0, 7, 0, 0, 0)), 0, 456 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 513, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6159), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@456", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6160), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 514, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+457", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6167), new TimeSpan(0, 7, 0, 0, 0)), 0, 457 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 515, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6175), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@457", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6175), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 516, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6182), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+458", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6183), new TimeSpan(0, 7, 0, 0, 0)), 0, 458 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 517, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6190), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@458", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6191), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 518, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6198), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+459", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6198), new TimeSpan(0, 7, 0, 0, 0)), 0, 459 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 519, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6229), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@459", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6229), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 520, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6237), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+460", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6237), new TimeSpan(0, 7, 0, 0, 0)), 0, 460 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 521, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6245), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@460", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6246), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 522, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6253), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+461", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6254), new TimeSpan(0, 7, 0, 0, 0)), 0, 461 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 523, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6260), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@461", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6261), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 524, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6268), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+462", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6269), new TimeSpan(0, 7, 0, 0, 0)), 0, 462 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 525, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6276), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@462", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6276), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 526, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6283), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+463", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6284), new TimeSpan(0, 7, 0, 0, 0)), 0, 463 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 527, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6291), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@463", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6292), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 528, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6298), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+464", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6299), new TimeSpan(0, 7, 0, 0, 0)), 0, 464 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 529, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6306), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@464", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6307), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 530, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6314), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+465", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6314), new TimeSpan(0, 7, 0, 0, 0)), 0, 465 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 531, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6322), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@465", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6323), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 532, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6330), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+466", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6330), new TimeSpan(0, 7, 0, 0, 0)), 0, 466 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 533, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6338), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@466", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6338), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 534, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+467", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6346), new TimeSpan(0, 7, 0, 0, 0)), 0, 467 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 535, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6353), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@467", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6354), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 536, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+468", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6362), new TimeSpan(0, 7, 0, 0, 0)), 0, 468 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 537, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6369), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@468", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6369), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 538, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6376), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+469", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6377), new TimeSpan(0, 7, 0, 0, 0)), 0, 469 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 539, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6384), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@469", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6384), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 540, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6391), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+470", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6392), new TimeSpan(0, 7, 0, 0, 0)), 0, 470 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 541, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6433), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@470", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6434), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 542, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6442), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+471", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6443), new TimeSpan(0, 7, 0, 0, 0)), 0, 471 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 543, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6450), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@471", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6450), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 544, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6457), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+472", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6458), new TimeSpan(0, 7, 0, 0, 0)), 0, 472 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 545, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6465), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@472", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6465), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 546, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6472), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+473", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6473), new TimeSpan(0, 7, 0, 0, 0)), 0, 473 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 547, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6480), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@473", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 548, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6487), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+474", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6488), new TimeSpan(0, 7, 0, 0, 0)), 0, 474 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 549, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6495), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@474", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6496), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 550, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6503), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+475", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6503), new TimeSpan(0, 7, 0, 0, 0)), 0, 475 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 551, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@475", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6511), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 552, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6518), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+476", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6519), new TimeSpan(0, 7, 0, 0, 0)), 0, 476 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 553, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6526), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@476", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6526), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 554, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+477", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6534), new TimeSpan(0, 7, 0, 0, 0)), 0, 477 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 555, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6541), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@477", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6542), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 556, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6549), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+478", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6550), new TimeSpan(0, 7, 0, 0, 0)), 0, 478 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 557, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6556), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@478", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6557), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 558, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6564), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+479", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6565), new TimeSpan(0, 7, 0, 0, 0)), 0, 479 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 559, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@479", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6572), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 560, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6579), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+480", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6580), new TimeSpan(0, 7, 0, 0, 0)), 0, 480 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 561, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@480", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6587), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 562, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6594), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+481", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6595), new TimeSpan(0, 7, 0, 0, 0)), 0, 481 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 563, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6624), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@481", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6625), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 564, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6633), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+482", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6634), new TimeSpan(0, 7, 0, 0, 0)), 0, 482 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 565, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6641), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@482", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6642), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 566, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6649), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+483", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6649), new TimeSpan(0, 7, 0, 0, 0)), 0, 483 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 567, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6656), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@483", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6657), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 568, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+484", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6665), new TimeSpan(0, 7, 0, 0, 0)), 0, 484 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 569, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6672), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@484", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6672), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 570, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6679), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+485", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6680), new TimeSpan(0, 7, 0, 0, 0)), 0, 485 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 571, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6687), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@485", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6688), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 572, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6695), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+486", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6696), new TimeSpan(0, 7, 0, 0, 0)), 0, 486 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 573, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6703), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@486", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6703), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 574, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6710), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+487", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6711), new TimeSpan(0, 7, 0, 0, 0)), 0, 487 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 575, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6718), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@487", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6719), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 576, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6725), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+488", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6726), new TimeSpan(0, 7, 0, 0, 0)), 0, 488 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 577, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6733), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@488", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6734), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 578, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6740), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+489", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6741), new TimeSpan(0, 7, 0, 0, 0)), 0, 489 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 579, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6748), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@489", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6749), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 580, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6756), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+490", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6756), new TimeSpan(0, 7, 0, 0, 0)), 0, 490 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 581, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6763), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@490", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6764), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 582, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6771), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+491", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6772), new TimeSpan(0, 7, 0, 0, 0)), 0, 491 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 583, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6778), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@491", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6779), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 584, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6786), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+492", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6786), new TimeSpan(0, 7, 0, 0, 0)), 0, 492 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 585, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@492", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6819), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 586, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6827), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+493", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6828), new TimeSpan(0, 7, 0, 0, 0)), 0, 493 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 587, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6835), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@493", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6835), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 588, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6843), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+494", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6843), new TimeSpan(0, 7, 0, 0, 0)), 0, 494 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 589, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6850), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@494", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6851), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 590, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6857), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+495", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6858), new TimeSpan(0, 7, 0, 0, 0)), 0, 495 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 591, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6865), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@495", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6866), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 592, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6873), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+496", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6873), new TimeSpan(0, 7, 0, 0, 0)), 0, 496 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 593, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6880), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@496", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6881), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 594, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6888), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+497", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6888), new TimeSpan(0, 7, 0, 0, 0)), 0, 497 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 595, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@497", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6896), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 596, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6903), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+498", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6903), new TimeSpan(0, 7, 0, 0, 0)), 0, 498 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 597, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6910), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@498", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6911), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 598, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6918), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+499", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6919), new TimeSpan(0, 7, 0, 0, 0)), 0, 499 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 599, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6925), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@499", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6926), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, true });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "title", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7598), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, "What is Lorem Ipsum?", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7598), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7625), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, "Why do we use it?", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7626), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7628), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, "Where does it come from?", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7628), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7629), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, "Where can I get some?", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7630), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7699), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7699), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7702), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7703), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7705), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7139), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7140), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7158), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7175), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7175), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6942), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6955), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6985), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(6986), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trips", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "point", "rated_trips", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 0, new Guid("24f1bb4c-f696-45df-b131-7dcae57c174b"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(262), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, 1, "Quach Dai Loi", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(263), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 0, new Guid("d9cb5e22-fb59-4bf7-b89f-bad80ed24d91"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(276), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, 1, "Do Trong Dat", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(277), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 0, new Guid("2880dc2a-87a1-4f28-950f-207c1c550b57"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(290), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 3, 1, "Nguyen Dang Khoa", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(290), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 0, new Guid("2b0ef1a7-fcc1-46ce-829c-8ef42d522a7c"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(301), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 4, 1, "Than Thanh Duy", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(302), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 0, new Guid("e4219a79-55c4-4f1a-9fe1-bb2ad7af326b"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(337), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 5, 1, "Loi Quach", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(338), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 0, new Guid("ee2f6d0e-5583-40c4-b34e-4032582ad312"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(351), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 6, 1, "Dat Do", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(352), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 0, new Guid("d57b19ff-d947-4419-9328-91d488ed2b2d"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(364), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 7, 1, "Khoa Nguyen", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(365), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 0, new Guid("12ec293c-b343-418e-ae75-0b61b42c6239"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(375), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 8, 1, "Thanh Duy", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(375), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 0, new Guid("0e35faf9-e4b7-41da-b2d2-d5f190c55f78"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(384), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 13, 1, "Admin Quach Dai Loi", null, 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(385), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 400, new Guid("d4d3ded1-8683-42e4-aa15-d61f6e6de1d0"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7876), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.400", "Vehicle 400", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7877), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, 3 },
                    { 401, new Guid("23c7fb9a-0edd-46e8-b401-bdca627b1e8a"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7886), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.401", "Vehicle 401", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7886), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, 3 },
                    { 402, new Guid("b09854c7-ce7e-4f05-afad-0ac180c78cb0"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7889), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.402", "Vehicle 402", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7890), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, 3 },
                    { 403, new Guid("ff8e53ea-7333-4bc1-ba49-6c18700166ca"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7894), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.403", "Vehicle 403", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7895), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, 3 },
                    { 404, new Guid("7834b239-99ba-4683-8ddd-3d6d34be2ad0"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7897), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.404", "Vehicle 404", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7898), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, 3 },
                    { 405, new Guid("e1e1556a-be3c-4676-8cdc-2f4ce067119b"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7901), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.405", "Vehicle 405", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7902), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, 3 },
                    { 406, new Guid("b6684555-6292-4a67-87dd-5422fc99326e"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7904), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.406", "Vehicle 406", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7905), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, 3 },
                    { 407, new Guid("b94840b2-4e4a-4ccb-a8e4-da96c9d3ec6f"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7931), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.407", "Vehicle 407", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7932), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, 3 },
                    { 408, new Guid("26ee4a99-9249-41f3-af83-a31245794cbd"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7935), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.408", "Vehicle 408", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7935), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, 3 },
                    { 409, new Guid("c6feacd0-e00c-4223-ade8-e4e6dc9e19b9"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7938), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.409", "Vehicle 409", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7939), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, 3 },
                    { 410, new Guid("e7d06722-9ba6-43a3-a08e-3d49cc6af162"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7941), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.410", "Vehicle 410", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7942), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, 3 },
                    { 411, new Guid("92c7a3df-2729-4793-8ac4-e05ce0652d29"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7946), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.411", "Vehicle 411", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7947), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, 3 },
                    { 412, new Guid("df19c671-ae62-4e43-b677-bb8653a5daa4"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7949), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.412", "Vehicle 412", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7950), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, 3 },
                    { 413, new Guid("6e21b85f-1e9a-4411-9ce5-dfc4d4c5d87c"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.413", "Vehicle 413", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7954), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, 3 },
                    { 414, new Guid("74938811-b7fc-4c7f-9dac-4f1b3fbaaf5c"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7957), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.414", "Vehicle 414", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7957), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, 3 },
                    { 415, new Guid("d02ac93a-cf60-4aef-990e-aa31bdf29eb3"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7960), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.415", "Vehicle 415", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7960), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, 3 },
                    { 416, new Guid("b051b191-bbc4-41bd-9a1c-c6a672baa6d4"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7963), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.416", "Vehicle 416", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7963), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, 3 },
                    { 417, new Guid("49b3ff36-45c1-46ac-9fdf-cf88d68fe843"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7966), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.417", "Vehicle 417", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7966), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, 3 },
                    { 418, new Guid("a85d8676-45e8-4678-a2af-c52ac7cef8cf"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7969), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.418", "Vehicle 418", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7970), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, 3 },
                    { 419, new Guid("e6c443aa-9cf8-4d16-9fa1-2c30e729c5b7"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.419", "Vehicle 419", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7974), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, 3 },
                    { 420, new Guid("4ed0671c-849f-4cf9-9d8d-696d7dce22aa"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7977), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.420", "Vehicle 420", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7977), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, 3 },
                    { 421, new Guid("709a2f0e-334c-4c95-87d1-acacf15ecf30"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7980), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.421", "Vehicle 421", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7980), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, 3 },
                    { 422, new Guid("9ac950ac-8603-4536-9a80-2bd8836a9c26"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7983), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.422", "Vehicle 422", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7983), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, 3 },
                    { 423, new Guid("d39ceb32-1553-483a-9845-e892a0d688f2"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7986), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.423", "Vehicle 423", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7987), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, 3 },
                    { 424, new Guid("4d466cd1-464d-4392-969d-7af857ea4ffe"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7989), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.424", "Vehicle 424", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7990), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, 3 },
                    { 425, new Guid("c7eae9d3-ae3b-48ae-9e84-a075977aa853"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7992), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.425", "Vehicle 425", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7993), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, 3 },
                    { 426, new Guid("4105a2c0-632b-4c7f-a707-fda62065be58"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7995), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.426", "Vehicle 426", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7996), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, 3 },
                    { 427, new Guid("ade43238-57cf-4e64-b077-09fae5e5ff70"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8000), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.427", "Vehicle 427", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8001), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, 3 },
                    { 428, new Guid("74d4c1b0-318c-4d96-9bf8-898b6a015621"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8003), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.428", "Vehicle 428", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8004), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, 3 },
                    { 429, new Guid("583abf36-fcbc-4585-9d0b-2f40ddf7fbfe"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8007), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.429", "Vehicle 429", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8008), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, 3 },
                    { 430, new Guid("20512964-5b91-4509-a9c8-ba85f91850ba"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8011), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.430", "Vehicle 430", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8011), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, 3 },
                    { 431, new Guid("2ae95507-856e-4d6a-a7c0-d63348a92de6"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8014), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.431", "Vehicle 431", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8014), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, 3 },
                    { 432, new Guid("eafe109b-d5e8-4c83-833c-25039b8d7ba0"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8017), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.432", "Vehicle 432", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8018), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, 3 },
                    { 433, new Guid("5a102140-ce1c-4d59-8418-26362ba21aa5"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8020), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.433", "Vehicle 433", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8021), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, 3 },
                    { 434, new Guid("8b18ebde-ee9b-4c7f-8f24-477940c62189"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8023), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.434", "Vehicle 434", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8024), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, 3 },
                    { 435, new Guid("9e4c8bfb-d2f8-4d0a-8989-56d7e2ac4957"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8028), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.435", "Vehicle 435", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8029), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, 3 },
                    { 436, new Guid("86e4faa4-d018-48fc-a4be-f288762d357e"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8031), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.436", "Vehicle 436", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8032), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, 3 },
                    { 437, new Guid("965afdac-c9e6-4e78-bc55-44755910ded4"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8034), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.437", "Vehicle 437", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8035), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, 3 },
                    { 438, new Guid("3f9e1d8a-3ddf-48ba-8973-5358e27b94e3"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8088), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.438", "Vehicle 438", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8089), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, 3 },
                    { 439, new Guid("dd97aedf-ffaa-4bf1-82c5-c1bdbe072750"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8092), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.439", "Vehicle 439", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8092), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, 3 },
                    { 440, new Guid("876bd64f-79a6-479c-b71e-7c8155464439"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8095), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.440", "Vehicle 440", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8095), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, 3 },
                    { 441, new Guid("9c6eb178-fc8c-425d-8f4e-6de69e427fb5"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8383), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.441", "Vehicle 441", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8384), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, 3 },
                    { 442, new Guid("04d90c15-bc2e-421f-86ad-94193fc3d03f"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8387), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.442", "Vehicle 442", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8387), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, 3 },
                    { 443, new Guid("d823584a-f501-4b56-841d-9d15ef2dbe50"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8393), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.443", "Vehicle 443", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8394), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, 3 },
                    { 444, new Guid("f6d463d6-af9a-4097-bf90-c63064740230"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.444", "Vehicle 444", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8397), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, 3 },
                    { 445, new Guid("0ec0f735-4425-4736-a525-b099be8b26c1"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8400), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.445", "Vehicle 445", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8400), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, 3 },
                    { 446, new Guid("9c9bd3c9-8e77-4d05-8741-2e7b084ab393"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8403), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.446", "Vehicle 446", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8404), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, 3 },
                    { 447, new Guid("de86b75a-b245-49f2-ad72-0ac6dce134f0"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8406), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.447", "Vehicle 447", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8407), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, 3 },
                    { 448, new Guid("c5c78a60-f4e4-4228-8c85-484b2f476da4"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8409), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.448", "Vehicle 448", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8410), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, 3 },
                    { 449, new Guid("70080cca-c1b1-4a80-bcb3-2095ec98262e"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8412), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.449", "Vehicle 449", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8413), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, 3 },
                    { 450, new Guid("f86f9dbe-e2c8-4ccd-9efc-df78d0ad93a7"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8415), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.450", "Vehicle 450", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8416), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, 3 },
                    { 451, new Guid("f4a312ad-7228-4f08-8976-41ec8db89250"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8420), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.451", "Vehicle 451", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8421), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, 3 },
                    { 452, new Guid("731ac175-dc71-4e0d-92ed-808e07e7a7d6"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.452", "Vehicle 452", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8424), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, 3 },
                    { 453, new Guid("7749c054-d56b-41c5-8b65-583cf2691a1f"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8427), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.453", "Vehicle 453", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8427), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, 3 },
                    { 454, new Guid("af4bfc8a-02fc-4e2c-9471-b3f18f1e080a"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8430), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.454", "Vehicle 454", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8430), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, 3 },
                    { 455, new Guid("8f31db49-d4cf-4c85-abf0-71412ad2c7e2"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8433), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.455", "Vehicle 455", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8433), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, 3 },
                    { 456, new Guid("5f375fd3-c3ff-43c8-9765-1868b073ccd6"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.456", "Vehicle 456", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8437), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, 3 },
                    { 457, new Guid("45124311-ac5d-4164-b12b-fcdafc89f7eb"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8439), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.457", "Vehicle 457", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8440), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, 3 },
                    { 458, new Guid("c45f667d-2a11-499a-b2e1-3e6c97cf0674"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8442), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.458", "Vehicle 458", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8443), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, 3 },
                    { 459, new Guid("ef04b84b-cfa0-4ebe-9415-00bc0baecfba"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8447), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.459", "Vehicle 459", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8448), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, 3 },
                    { 460, new Guid("8e0acd47-844e-4ec0-9133-b43693bae92b"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8450), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.460", "Vehicle 460", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8451), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, 3 },
                    { 461, new Guid("9ebd63e1-50a0-4867-b01b-36ab4154fdb6"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8457), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.461", "Vehicle 461", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8457), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, 3 },
                    { 462, new Guid("897c1e80-e145-4ddf-8675-63257eabf795"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8460), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.462", "Vehicle 462", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8460), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, 3 },
                    { 463, new Guid("60c0f4c7-63f2-41ab-b144-e81a1555d19d"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8463), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.463", "Vehicle 463", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8463), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, 3 },
                    { 464, new Guid("c9078409-394b-4f36-9c14-9bced5125069"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8466), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.464", "Vehicle 464", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8467), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, 3 },
                    { 465, new Guid("9fff7a5e-4951-4a3f-8a94-fd12f17170d8"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8469), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.465", "Vehicle 465", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8470), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, 3 },
                    { 466, new Guid("391dd287-fe0c-4134-9e8b-0139f293de77"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8472), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.466", "Vehicle 466", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8473), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, 3 },
                    { 467, new Guid("2e1f087a-abd8-40a5-b1da-60d37ed220f6"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8477), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.467", "Vehicle 467", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8478), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, 3 },
                    { 468, new Guid("3bc199de-4ea0-4d3a-b0c9-839e6b118b5d"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.468", "Vehicle 468", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8511), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, 3 },
                    { 469, new Guid("f0bc682c-b011-4eb6-80d7-a95e55ae3501"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8513), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.469", "Vehicle 469", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8514), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, 3 },
                    { 470, new Guid("84283672-9e67-4f0b-b7ea-938b141c1fce"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.470", "Vehicle 470", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8517), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, 3 },
                    { 471, new Guid("a9868f70-9384-4cab-94b5-5e7a01c5e8e4"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8520), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.471", "Vehicle 471", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8520), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, 3 },
                    { 472, new Guid("8bbbb99c-00cd-43d4-b25f-c851d49b765b"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8523), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.472", "Vehicle 472", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8523), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, 3 },
                    { 473, new Guid("09b8e198-e62f-43d4-8319-1083542fd958"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8526), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.473", "Vehicle 473", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8526), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, 3 },
                    { 474, new Guid("e08bb3eb-7f9d-428f-bac0-5438f0b21503"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8529), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.474", "Vehicle 474", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8530), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, 3 },
                    { 475, new Guid("951d5dd3-ec8c-4b7d-8b5e-afb20c45571b"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8534), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.475", "Vehicle 475", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8535), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, 3 },
                    { 476, new Guid("c4058bf0-2794-450e-9455-92acd33022b3"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8537), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.476", "Vehicle 476", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8538), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, 3 },
                    { 477, new Guid("d6154a91-30e8-4205-b02b-e66bc7e0a5f1"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.477", "Vehicle 477", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8541), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, 3 },
                    { 478, new Guid("b1747aac-cd35-4c69-bd5d-0d5b002225b7"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8543), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.478", "Vehicle 478", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8544), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, 3 },
                    { 479, new Guid("e8654065-2e48-48d3-836b-dca0b5cbd8f2"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8547), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.479", "Vehicle 479", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8548), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, 3 },
                    { 480, new Guid("c411fe73-cf41-4f02-85fa-84f1e31619dd"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8551), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.480", "Vehicle 480", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8551), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, 3 },
                    { 481, new Guid("b4439729-fef5-444f-8b0d-00b3eac686f4"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8554), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.481", "Vehicle 481", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8554), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, 3 },
                    { 482, new Guid("6c92d09b-82cb-41d3-87ed-da29d4c39a58"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8557), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.482", "Vehicle 482", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8557), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, 3 },
                    { 483, new Guid("8416a525-800c-4e30-8970-ebb2100a15de"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8562), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.483", "Vehicle 483", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8562), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, 3 },
                    { 484, new Guid("a113538f-eafd-4ac9-8c51-f9ef259d3025"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8565), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.484", "Vehicle 484", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8565), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, 3 },
                    { 485, new Guid("c2f1850b-ea6e-4860-bb0f-87424e8526d0"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8568), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.485", "Vehicle 485", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8569), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, 3 },
                    { 486, new Guid("99a7f516-9e43-470c-bca0-ef2682c1cea8"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.486", "Vehicle 486", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8572), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, 3 },
                    { 487, new Guid("3f44be23-d4b9-41a7-a692-ad4af9715c93"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8574), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.487", "Vehicle 487", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8575), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, 3 },
                    { 488, new Guid("a02f37ae-db64-429e-afc8-11c784e044b3"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8578), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.488", "Vehicle 488", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8578), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, 3 },
                    { 489, new Guid("4f8857e1-5484-4b21-8b60-23c2bf184f6c"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8581), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.489", "Vehicle 489", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8581), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, 3 },
                    { 490, new Guid("dbdc01de-74dc-4b4f-b4cf-d47c41186070"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8584), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.490", "Vehicle 490", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8584), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, 3 },
                    { 491, new Guid("a6f7d3e8-4040-4bb9-b9d8-e89edcf0be84"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8589), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.491", "Vehicle 491", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8589), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, 3 },
                    { 492, new Guid("01f24056-3885-4f8a-af13-bcb8f8536b9e"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8592), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.492", "Vehicle 492", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8592), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, 3 },
                    { 493, new Guid("ff17dcd9-e584-4a83-aed9-73a574c88025"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8595), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.493", "Vehicle 493", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8596), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, 3 },
                    { 494, new Guid("cc201dfa-53c0-40e2-b15c-1a09c1d18015"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8598), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.494", "Vehicle 494", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8599), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, 3 },
                    { 495, new Guid("2cf20999-187e-432f-ab1e-29784458a3c9"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8602), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.495", "Vehicle 495", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8602), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, 3 },
                    { 496, new Guid("80fd6e07-095c-4886-8f90-9918861d4e57"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8605), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.496", "Vehicle 496", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8605), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, 3 },
                    { 497, new Guid("71378474-e4e1-4472-8344-e367ffb7b0cb"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8608), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.497", "Vehicle 497", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8608), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, 3 },
                    { 498, new Guid("396e4ad1-a4ca-41d0-bf5f-1427fcc92a55"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8611), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.498", "Vehicle 498", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8612), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, 3 },
                    { 499, new Guid("18aaf844-3ff8-4ad3-a038-f3b5f65b8454"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8616), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.499", "Vehicle 499", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8616), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, 3 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3163), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3163), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3174), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3181), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3182), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3189), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3189), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3196), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3196), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3204), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3204), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3211), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3211), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3217), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3218), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3248), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3248), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3258), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3259), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3266), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3273), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3280), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3281), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3287), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3288), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3294), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3295), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3302), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3309), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3309), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3318), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(3318), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "ceiling_extra_price", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7721), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7722), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7760), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7761), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7768), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7768), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7775), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7775), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7782), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7789), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7790), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7796), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7797), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7803), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7803), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7810), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7810), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7817), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7818), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7825), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7826), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7831), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7832), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7838), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7838), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "notifications",
                columns: new[] { "id", "code", "created_at", "created_by", "data", "deleted_at", "description", "event_id", "status", "type", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, new Guid("8e362c11-e15c-4f34-b968-47df0c5a3792"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8817), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 6, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8818), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 2, new Guid("b3646a78-039b-4de6-897d-3679f680161e"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8849), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 3, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8850), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 3, new Guid("a2f5326b-b454-41b2-81c9-86c732689496"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8855), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 6, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8855), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 4, new Guid("bad83bed-2a87-4b1d-9701-9d2f85a93508"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8858), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 6, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8859), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 5, new Guid("7fa3da33-432d-423b-a390-cf1fe3d04136"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8888), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 2, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8888), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 6, new Guid("9d088660-5033-4adc-8af0-207e11c2abc6"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8893), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 8, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8893), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 7, new Guid("93102c04-4058-4b0d-b185-fc836516d2a7"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8898), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 7, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8898), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, new Guid("b7793d68-c0d2-4673-bd0d-46a3dff07647"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8901), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 4, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8902), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 9, new Guid("2d3b2c6c-bab8-4c99-a8ab-a8696c0f1c37"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8907), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 3, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8907), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 10, new Guid("bab7b819-ea95-40de-afe1-01fbcecc221f"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8911), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, "", 2, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8912), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7023), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7024), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7118), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7118), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7195), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7196), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7219), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7235), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7236), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7248), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7248), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7260), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7261), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, new Guid("808f28c0-d9c2-4ba8-a5b0-988c078482d0"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7864), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7865), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("3e6a21d5-e8c6-4513-99e1-5180342937b0"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7869), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7869), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("e349265f-0988-4301-9540-124c47fff557"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7872), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("9f039c86-91af-4c6e-aff0-5bbb9bba45bc"), new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7874), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(7874), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8736), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8736), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8739), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8740), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8742), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8742), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8743), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8744), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8745), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8746), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8748), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8749), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8750), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8751), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8752), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 8, 19, 10, 36, 421, DateTimeKind.Unspecified).AddTicks(8753), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
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
