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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("9a098144-22bb-44a6-be5f-0fbbf0ae36de")),
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 547, DateTimeKind.Unspecified).AddTicks(2427), new TimeSpan(0, 7, 0, 0, 0))),
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("38dfb9fa-df76-470f-a82a-9d395192dd22")),
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
                    { 1, new Guid("a2784bb9-12a8-4b68-94a2-872788ff764f"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6268), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("52636f72-670f-4af1-912e-697fa7b56988"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6274), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6275), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("fe7be423-3643-4d01-824f-68216135dcab"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6272), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6273), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 1, new Guid("e1c04258-cb77-4969-90cb-bd4b9f8b17e0"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7198), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7215), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("4e6404d7-30c6-4dc8-a06f-826bf15d3f47"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7229), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("cacc5e13-e734-47eb-979b-d1c06b881ad3"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7238), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7238), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("ca7f8514-8cc6-4525-b712-10d61128565a"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7247), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7247), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("0f6bfa5d-8139-451a-8d65-d193eccab45f"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7257), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("7a1cad29-b32c-4e74-95b4-1e3d0faf04bb"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7268), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7268), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("1043c3e4-c2bb-4669-9091-fcd37e5e4cd4"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7278), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7278), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("55e66208-b915-4ffb-beba-296d94ae2e2c"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7297), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7297), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("96ed7f72-23df-4c30-995c-7e78dfb99941"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7306), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7307), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("1aaf1374-6332-4620-85c2-d91c429ca1b7"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7317), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("1131041a-63c4-4a3c-bddc-ca01b67da0a8"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7326), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7327), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("7d91bfa6-509d-4d6e-83c9-53e2374ef679"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7336), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7336), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("203aa9d2-d074-459c-a384-f0b92b99bd0c"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7346), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, new Guid("d7b65df0-75e2-47fa-bebd-f61a906ab607"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 4, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7355), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, new Guid("423b0ca9-b0e4-4ad7-94ea-578e425e8937"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7364), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 5, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7364), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, new Guid("eb0a7152-fcd9-49e1-bb7a-297554a8e85d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7405), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 6, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7406), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, new Guid("5fc984d5-f976-48d8-8476-87405ed66212"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7417), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 7, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7417), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, new Guid("db1e62ac-660e-4b7a-b362-e4b2cf400e83"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7427), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 8, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7427), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, new Guid("222fb5cd-6733-47ea-8aab-700bcf9d9d96"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 9, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7436), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "license_types",
                columns: new[] { "id", "code", "name" },
                values: new object[,]
                {
                    { 1, new Guid("3a1735a4-e2f4-4953-a569-7475120090bf"), "Identification" },
                    { 2, new Guid("ed940784-f995-4e32-952b-48f430689555"), "Driver License" },
                    { 3, new Guid("a23f973d-bc14-4811-b09d-7a5f350ab1e1"), "Vehicle Registration Certificate" }
                });

            migrationBuilder.InsertData(
                table: "pricings",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "discount", "lower_bound", "updated_at", "updated_by", "upper_bound" },
                values: new object[,]
                {
                    { 1, new Guid("a4e1a507-61c9-4839-aa0f-f97d562ec8a6"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6360), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.0, null, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6361), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 2, new Guid("fbba0d36-32bf-4746-8b4d-fa9cedac283e"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6364), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.029999999999999999, 8, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6364), new TimeSpan(0, 7, 0, 0, 0)), 0, 30 },
                    { 3, new Guid("da0a44e8-5fbe-43e6-a55b-b7534b08a6a5"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6366), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.050000000000000003, 31, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6366), new TimeSpan(0, 7, 0, 0, 0)), 0, 90 },
                    { 4, new Guid("8fe827c3-c642-4aac-aded-c20e1845d1d6"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.070000000000000007, 91, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6368), new TimeSpan(0, 7, 0, 0, 0)), 0, null }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4766), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4767), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4776), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4776), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4785), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4785), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 19, "LastDayNumberForNextMonthRoutine", "7" },
                    { 20, "DiscountPerEachSharingCase", "0.1" },
                    { 21, "DriverRegistrationFileSizeLimit", "20" }
                });

            migrationBuilder.InsertData(
                table: "stations",
                columns: new[] { "id", "address", "code", "created_at", "created_by", "deleted_at", "latitude", "longitude", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("dcb8e6a6-cda4-4dda-abf8-5ed5dce6944b"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5115), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5116), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("38692a61-b5e2-452c-a558-f31e3e28ce0c"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5122), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5123), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("11c9e96f-402f-465b-a051-a6ec460f70a0"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5125), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5126), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("95973b15-5453-4122-86cc-d4e62d54cc75"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5127), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5128), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8eddf680-269b-49e2-b701-eb4bb23587df"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5133), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5134), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1ff2fa79-bdaf-4bea-9ff4-32dbedeebb8e"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5137), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5137), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("861603b9-d9ec-4857-be17-0d7d8eb7b468"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5140), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5140), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0903c7ed-21fa-4114-9f4a-6268fc4f4ea0"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5142), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5143), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("2e19425b-0140-4456-bca7-4f1ac7887ed5"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5145), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5146), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("08af479b-6e12-4d59-a085-d74209937196"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5148), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5149), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b027a894-08e1-4356-9072-043f75933f66"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5150), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5151), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("54c75858-155f-4ff6-ac47-7bea49a558ca"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5153), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5154), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6d758d60-8331-4eab-91e1-7de44ce0ce6c"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5158), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("efc1f2e9-f3d7-4be2-987d-05cbc7a920f2"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5160), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5160), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("13d476b0-d850-49ca-8468-625276451a3e"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5162), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5162), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6f81f6b8-f9a4-488f-82c0-54773cbf0056"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5164), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5165), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a7369707-6a50-40cb-8551-3789276710cc"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5168), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("68dabe7a-c218-44ff-a3fa-6b3172f7991a"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5171), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5171), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("293acdd0-7236-4442-abd8-253474b364e5"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5174), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("151ce392-5ded-43c5-b3f8-00171a7d389d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5175), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5176), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("34e6b183-04b8-49eb-806b-59ddb73e905a"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5179), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5180), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("65f1a0d1-d01c-418f-8075-80d568df3092"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5181), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5182), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2fe2a52e-246f-4340-ab58-5ad04c6ade3d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5187), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5187), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fb527a13-e959-4db1-bbfa-9ead0701fa62"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5189), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5190), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3107849f-84e3-4799-bb90-d9f2bad01614"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5191), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5192), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("76c4a0fe-984f-4d59-bd86-9f626490194a"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5223), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5223), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("facc6c07-cf7f-4eef-b48e-7d9d4288b43d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5226), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1d04462d-aaf7-49a6-944d-1e5eaccbc0ab"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5230), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5230), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9381d286-12db-465c-98d4-d693e65418ed"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5232), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5233), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fb1832cb-cec7-4152-830c-4353826493ce"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5235), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5235), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d73a4e26-32d1-47af-919c-d33f893361c5"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5237), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5238), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ae78db31-b546-4d69-90c8-5bc4edb5f06c"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5239), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5240), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("72112fbc-0aa9-446e-b2df-c2cd509bdc1d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5244), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5244), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9cff24e9-bcb7-49b6-b31c-3e22d3f3e82e"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5246), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5246), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("10ec375c-9b05-401d-aeb4-f85cb3871cfa"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5248), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5249), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dd6e2dd0-4986-4bc9-8511-e90a7e6cd726"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5252), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5253), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("d8edd726-2856-4142-98da-d14ec91827db"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5254), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5255), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c4c7056a-3892-4338-8221-a10b8471a61e"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5257), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ba29be53-26c8-4e3e-bf8a-13d95b9b4b89"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5260), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5261), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5c6f615e-fbb3-4973-a21b-b103aab5a38f"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5262), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5263), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("574c6881-d91c-4889-b71c-063f3dbe873c"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5265), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5265), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fdaa3933-44ef-40bb-ab08-240d12ea15c3"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5268), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("3240d128-8a6b-41f5-b230-600ed622f30b"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5269), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5270), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("fa22a8c7-a4cf-46b6-873b-80fb60a2b6ca"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5274), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5274), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("af387eef-9399-4709-8f32-7af35e6c9664"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5276), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5277), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e0cb69f5-d79a-4336-b8a7-fafc25a39c91"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5278), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5279), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("23d38c1e-5242-4d7a-bacd-d9f6c0490a45"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5281), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5281), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cfea6f63-2555-402b-85c8-5349c30e09bd"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5283), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5284), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("438d7e8b-d8db-4fc2-bcdc-bfe89ac9a644"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5285), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5286), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("eaa965b5-9840-4b5f-8de1-e5990cdb70b1"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5288), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5288), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4a9550d3-5a21-4d47-99d1-cec0f6f787ff"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5290), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5291), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f9c65f2a-ce36-4f93-a7d8-6d8e45cb16ae"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5294), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5295), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c7bb7c26-235d-49ce-b696-fee30daf29aa"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5296), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5297), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("610b33d7-6e2a-461a-805e-7d7d80b551d3"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5299), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5299), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("260d08cb-3b3a-45e5-bae5-481dc9d0e740"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5301), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5302), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3dc6c52e-e340-4195-8932-35c22e113dcb"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5303), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5304), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("195eb124-6412-467f-820b-b55d35a926c8"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5306), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5306), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0f62ceb8-a6ef-4226-9795-28d580ec098b"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5308), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5309), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("618f4b02-133f-48cf-9dae-48759b5b6b02"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5311), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c7a07c4d-d52f-429b-9056-1b5212664837"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5314), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5315), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8da46465-1cec-4c35-9583-ca1e79e436c5"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5317), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f072da7a-268b-4223-ae60-692965df860e"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5320), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5321), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f0ea0e33-bdbc-43de-b296-8bd4716580b7"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5322), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5323), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8a06bb74-65ee-47cd-b2a1-967840a45b82"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5325), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5326), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9e30b10d-ad50-440d-b18f-75bb8a3c9525"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5353), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5353), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("69b9b6a5-2d6a-4553-b39d-88683defeefb"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5355), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5356), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c3becc0e-d1fe-404f-8d5d-3e43aecd984b"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5357), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5358), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("68ef1c1a-afe2-4a90-a169-1a2d3933941b"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5362), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3be1854a-8988-494e-b940-645411556294"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5364), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5364), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c96021d1-1457-4362-9c20-bd79354b0805"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5366), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5367), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("74a9b9ed-0f99-4054-80d0-559587487931"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5369), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f7b3a1d7-6e5b-4a01-b074-650027d1fce8"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5371), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5371), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("42ffe7ae-345e-4daa-a829-0329baf0afd5"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5373), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5373), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("2e6d0f1e-4a91-4ad5-a650-dc749fa178d1"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5375), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5376), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a70cf840-8792-4f13-a556-db7e9b195117"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5378), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("945ecf01-356d-4a90-a418-f51cd68d48e1"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5382), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5382), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("db960189-f4f4-44ba-8c44-8fe4b9c350ef"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5384), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5384), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5e100c4c-930a-43c7-9018-0efe86b739cd"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5386), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5387), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("776dcf6d-b8e5-4f60-a265-6428f15e9bb4"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5389), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5389), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("d78aadb1-0aca-4865-bf39-f701f6e3bf85"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5391), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5392), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("b804f532-9c79-4cba-a4e4-19fd817dbcfd"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5393), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5394), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("097e875f-a0b2-41fc-9823-20187f1185b1"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5396), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("f3c33848-378e-4c57-99aa-8795b71913ab"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5398), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5399), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("a4dcbf0d-cb8f-48d3-8e00-5319032e83c0"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5402), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5402), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d9198fb1-f410-4dbc-af0e-ab9fae1ed345"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5184), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5185), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô E2a-10 Đường, D2b Đ. D1, TP. Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam", new Guid("2acce0f1-92c9-4ae2-991e-8225356bfb02"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5405), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trip_rate", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "rating", "status", "suddenly_cancelled_trips", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 10, 0.0, new Guid("b78e6f91-d20b-4e3f-9f47-175151fa1fbb"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7602), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Than Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7602), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 0.0, new Guid("48ab584a-0ad5-4b41-9216-224fb050156f"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7615), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Nguyen Dang Khoa", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7615), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 0.0, new Guid("dab78093-4b63-46b6-b0f1-c00043586c0f"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7625), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Admin Do Trong Dat", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7626), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 100, 0.0, new Guid("d5453f95-068d-496a-8427-7b368756544e"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7636), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 100", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7636), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 101, 0.0, new Guid("9bea50d5-fe30-4adb-99c9-d81c06ab7e47"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7677), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 101", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7678), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 102, 0.0, new Guid("d5aeb603-9fd3-40ad-a5ca-b0298c88f3ab"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7692), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 102", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7693), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 103, 0.0, new Guid("0a151dae-21e3-4aca-b778-5c614cc88d08"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 103", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7705), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 104, 0.0, new Guid("7c033425-0d28-4eb0-a630-41590029c07f"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7716), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 104", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7717), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 105, 0.0, new Guid("75cd1691-1e09-40f1-87b8-c35201d05a57"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7729), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 105", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7730), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 106, 0.0, new Guid("6e98e07f-2986-4b7f-901b-5a12dd78a5ee"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7768), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 106", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7769), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 107, 0.0, new Guid("b1ad64cc-fadb-4c5b-9ea6-895b6c6a9bb5"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 107", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7782), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 108, 0.0, new Guid("9ca1ebb9-8f8e-4f5c-a805-5cbf84b0f7a7"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7793), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 108", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7793), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 109, 0.0, new Guid("786ce77e-b539-4694-bb6f-eb9f4ebf81ec"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7804), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 109", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7804), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 110, 0.0, new Guid("34f9872e-27c4-411b-9db6-3f0b4fd59560"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7817), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 110", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7817), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 111, 0.0, new Guid("92a4b609-6417-4357-827f-0a37663aa4f5"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7828), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 111", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7829), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 112, 0.0, new Guid("1361f3e2-5e89-447a-9ece-88bf3a5e56de"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7840), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 112", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7840), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 113, 0.0, new Guid("66f7c728-fece-43ff-a83b-f0f313d6c28d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7851), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 113", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7852), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 114, 0.0, new Guid("7b4bdabb-0097-478c-b445-0c78688d1ea0"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7864), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 114", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7865), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 115, 0.0, new Guid("0ba4dadb-3af3-4c01-a820-b5d43ff8bb3e"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7876), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 115", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7877), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 116, 0.0, new Guid("10432404-172e-4170-9581-41d961cb3707"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7888), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 116", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7888), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 117, 0.0, new Guid("0025776e-76bc-4778-9ce6-f07d18e80942"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7922), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 117", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7923), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 118, 0.0, new Guid("0e19f21b-41b6-433f-8bb2-2c8074bf3d0e"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7937), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 118", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7938), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 119, 0.0, new Guid("1d0b4a47-25fa-49e5-8f8b-69ce9b0a9517"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7948), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 119", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7949), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 120, 0.0, new Guid("1d012333-8b95-42ef-ad10-5830fdc4d402"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7960), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 120", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7961), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 121, 0.0, new Guid("f1907ca7-439c-411c-9973-a000deeadb4c"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7973), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 121", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7974), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 122, 0.0, new Guid("4194d4ab-4dae-4747-bf61-242333b5d8b2"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7987), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 122", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7987), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 123, 0.0, new Guid("2b691558-d6e0-420e-873f-34eee80f2bde"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 123", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7999), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 124, 0.0, new Guid("ec04b580-f3fc-4aed-a6f7-41f80dea2056"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8010), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 124", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8010), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 125, 0.0, new Guid("2296507c-d87b-45e4-9163-3d7025a45c6d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8021), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 125", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8022), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 126, 0.0, new Guid("a8d0c1f5-fb78-4bf0-a028-137739e1a847"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8034), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 126", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8035), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 127, 0.0, new Guid("4e31a291-49f2-4a1d-ae1f-def96b7f0e45"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8072), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 127", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8073), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 128, 0.0, new Guid("37a1b056-dd5f-4879-b0b4-560b01e2fa97"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8085), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 128", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8086), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 129, 0.0, new Guid("435af61d-e9f1-491a-84f4-56aa0b68c71a"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8097), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 129", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8097), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 130, 0.0, new Guid("703c75d6-3e29-42ca-8314-1b705f59e78d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8110), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 130", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8111), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 131, 0.0, new Guid("c980cf7b-de16-42c5-a8af-1ef94eb88a01"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8122), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 131", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8122), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 132, 0.0, new Guid("f4945751-4a07-4312-a66d-cbc3340f00b5"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8133), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 132", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8134), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 133, 0.0, new Guid("3b2353f6-227b-43b2-a1b5-9c667206f328"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 133", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8145), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 134, 0.0, new Guid("d6daef12-7cfb-4c70-b61f-0807ed2e5c05"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 134", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8158), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 135, 0.0, new Guid("df3a4916-fb38-41d3-a5fa-a7bd7e82b802"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8169), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 135", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8169), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 136, 0.0, new Guid("92ce8086-1a0b-45b1-9c63-02ad4364179f"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8180), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 136", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8180), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 137, 0.0, new Guid("25385d52-d9ed-49ce-beb9-d9984c36a144"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8191), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 137", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8191), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 138, 0.0, new Guid("338af846-54df-4c9e-9f93-04417738ecb8"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8249), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 138", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8250), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 139, 0.0, new Guid("7513c827-8380-4767-81ab-3bb80fdb9412"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8262), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 139", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8263), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 140, 0.0, new Guid("1304f9e3-6bc5-4bce-b6ec-6d8356c8b425"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8274), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 140", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8275), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 141, 0.0, new Guid("e234aebf-5a8a-4d3a-89de-44c86985425e"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8285), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 141", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8286), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 142, 0.0, new Guid("2c1ae614-2c85-477e-abf9-c8451b346db0"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8298), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 142", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8299), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 143, 0.0, new Guid("d7d16c63-fb3b-42c9-9b94-ce751985ce5c"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 143", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8311), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 144, 0.0, new Guid("17902cac-79e0-428e-b6f1-f760c4cc786c"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8322), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 144", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8323), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 145, 0.0, new Guid("f2a08b8d-ca31-495d-865f-f5187b135550"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8333), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 145", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8334), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 146, 0.0, new Guid("871f6645-42c8-4c2b-a374-95ab5099faa9"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8347), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 146", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8347), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 147, 0.0, new Guid("7a7e881c-7793-478c-b2e5-7ce7224a8c17"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8358), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 147", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8359), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 148, 0.0, new Guid("7f0705a2-6931-4ca2-84ee-d6543d4f8fcb"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8392), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 148", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8393), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 149, 0.0, new Guid("4779e9eb-8f91-4811-b53f-357e06dde428"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8406), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 149", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8407), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 150, 0.0, new Guid("7f3527a3-945d-4487-8aca-1a4799743ea3"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8419), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 150", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8420), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 151, 0.0, new Guid("da11b34a-607b-4964-9171-c633d1175d1b"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8431), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 151", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8432), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 152, 0.0, new Guid("12167afc-33bd-4cb9-830b-b47cc8755797"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8443), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 152", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8443), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 153, 0.0, new Guid("91671fcb-17c6-461e-aad7-269377180297"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8456), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 153", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8457), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 154, 0.0, new Guid("ccae13d1-e734-4863-a156-fa6d595956a0"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8469), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 154", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8470), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 155, 0.0, new Guid("ee183b65-2c13-4723-98c7-3fb571d004e2"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 155", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8482), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 156, 0.0, new Guid("69d84ecb-076a-425c-98e1-ddebb1adc07b"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8492), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 156", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8493), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 157, 0.0, new Guid("c9c1ab80-8317-4735-ad9a-94826eb95f0c"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8504), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 157", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8505), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 158, 0.0, new Guid("35e89816-b4ec-4a5a-a913-50844755f684"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8541), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 158", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8542), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 159, 0.0, new Guid("185c188b-ee1b-4ba1-b9d9-81e8b72a46e3"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8553), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 159", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8554), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 160, 0.0, new Guid("91e44fac-b8fc-431b-9b92-5d17d319580d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8565), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 160", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8565), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 161, 0.0, new Guid("a0724b3e-49e3-40a8-9012-4c0a77085b91"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8575), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 161", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8576), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 162, 0.0, new Guid("70ef8c6e-fdc0-4177-b1a0-f9a15183d9e9"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8588), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 162", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8589), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 163, 0.0, new Guid("98b4ffdb-d2fb-4189-a0a7-62c14eaf253c"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8599), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 163", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8600), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 164, 0.0, new Guid("b412e29e-a736-4ca8-9964-1e032acb99dd"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8610), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 164", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8611), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 165, 0.0, new Guid("008294df-df14-4934-a528-a0dd8836ea43"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8621), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 165", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8622), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 166, 0.0, new Guid("55187132-973a-4027-a898-5a8af17a7252"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8634), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 166", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8635), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 167, 0.0, new Guid("2f17f8e3-1588-45de-a3d3-5ac00db5369b"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8645), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 167", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8646), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 168, 0.0, new Guid("583389ab-90a5-467a-a60d-a9b321d2daf4"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8681), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 168", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8681), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 169, 0.0, new Guid("2dc838ed-ecc1-4fdb-a481-062b5a25bf38"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8694), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 169", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8695), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 170, 0.0, new Guid("f6e26b36-3f2a-4d67-9129-966eb51dbb8b"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8707), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 170", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8708), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 171, 0.0, new Guid("59d46a0e-5a31-4196-a2aa-86bc54137fda"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8719), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 171", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8720), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 172, 0.0, new Guid("789386b4-579b-4697-bf1d-d268c49aad31"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8730), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 172", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8731), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 173, 0.0, new Guid("f62de6e9-8ce7-4d3b-a4c1-da2995fc1be4"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8741), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 173", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8742), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 174, 0.0, new Guid("067bd28f-4a1b-4e98-aaf3-93e489ccd6bb"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8754), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 174", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8754), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 175, 0.0, new Guid("dbab944a-6eac-41a3-bd1b-9f98161a3e23"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8765), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 175", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8766), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 176, 0.0, new Guid("82ead807-a040-4e3c-a21a-8571dddd28ee"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8776), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 176", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8777), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 177, 0.0, new Guid("a7e749db-4940-4071-b2db-62af76d1a35f"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8787), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 177", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8788), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 178, 0.0, new Guid("4f19c939-334c-46dd-9196-55888d307116"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8800), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 178", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8800), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 179, 0.0, new Guid("4b817621-b19d-4490-8018-9d2fb018e710"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8835), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 179", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8836), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 180, 0.0, new Guid("2ab2da2f-addd-4b25-9e3c-540e1090d88d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8848), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 180", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8849), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 181, 0.0, new Guid("9d9c8656-1f2c-40c9-b3a5-9f65e56e8ac1"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8859), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 181", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8860), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 182, 0.0, new Guid("8c3e6bb7-2d39-4534-9455-6898855a57a8"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8873), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 182", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8874), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 183, 0.0, new Guid("0dfae834-abc8-48b9-9df3-b64f6deddae0"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8885), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 183", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8885), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 184, 0.0, new Guid("6b2d33bf-b6d4-415a-b459-a1c1ab5b22df"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8896), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 184", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8896), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 185, 0.0, new Guid("52a6ab70-82cd-4505-bf8c-46746a8a1a04"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8906), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 185", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8907), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 186, 0.0, new Guid("9c16e881-2b6c-4da2-a589-0c36e53ac7ea"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8919), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 186", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8920), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 187, 0.0, new Guid("42f84c67-e256-411f-915f-964c3fce353b"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8931), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 187", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8931), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 188, 0.0, new Guid("4e38bbf3-c2f8-49ec-9191-ef6c14758be7"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 188", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8942), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 189, 0.0, new Guid("1f6f9c11-bdc7-4446-9a90-146322126ff2"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 189", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8953), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 190, 0.0, new Guid("04158cf4-3481-4696-8763-6f776fbacf0c"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8989), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 190", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(8990), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 191, 0.0, new Guid("2363e741-1707-492e-89f6-c5e341361460"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9003), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 191", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9003), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 192, 0.0, new Guid("54810119-b7c8-4eec-9000-38191d203f01"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9014), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 192", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9015), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 193, 0.0, new Guid("fbc5b347-12a0-41b1-b94d-13c4b95ca1fa"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 193", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9026), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 194, 0.0, new Guid("e6da9129-6633-4d13-8c1a-3ae6cc2842bc"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9038), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 194", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9039), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 195, 0.0, new Guid("9a640787-7f98-412a-b164-b81c1aef005f"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9050), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 195", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9050), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 196, 0.0, new Guid("a57f21d7-25e7-4ed9-989c-0f17bb571978"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9061), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 196", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9062), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 197, 0.0, new Guid("9dd7c34b-1195-44c3-a40c-c283a0e11379"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9072), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 197", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9073), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 198, 0.0, new Guid("1627aabc-be7f-48c1-a016-3224e4634d9b"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9085), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 198", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9086), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 199, 0.0, new Guid("3c5fd6f1-37a3-4cca-ba12-8550922727bd"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9097), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Booker 199", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9097), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 400, 0.0, new Guid("fc0841e0-a1f1-49c7-a556-b58253e7f1bc"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9109), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 400", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9110), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 401, 0.0, new Guid("326bc9c3-231d-4709-bb1f-ff0ffb141d12"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9146), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 401", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9147), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 402, 0.0, new Guid("7fb0690a-4341-4ddc-aa7a-661d8ea01200"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9162), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 402", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9163), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 403, 0.0, new Guid("111982fc-e263-402d-89fd-87ce34098d72"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 403", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9175), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 404, 0.0, new Guid("312f529f-01ed-46e9-801b-749c6e5afe5d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9185), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 404", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9186), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 405, 0.0, new Guid("6001ab3e-5136-4543-9b30-109e6d842df3"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9196), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 405", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9197), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 406, 0.0, new Guid("eabdc7b4-8647-42b9-84e1-7226e665d3c0"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9209), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 406", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9210), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 407, 0.0, new Guid("81298abd-9775-4f02-a3a7-eb51b6f45c38"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9220), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 407", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9221), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 408, 0.0, new Guid("539c9dae-260c-4696-932c-18dc9532613a"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9232), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 408", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9232), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 409, 0.0, new Guid("ac86f13e-1d13-44ab-b3df-246eb795d95a"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9243), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 409", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9243), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 410, 0.0, new Guid("08c11a92-bc30-437c-9ee7-0bc6e84dc1c7"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 410", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9256), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 411, 0.0, new Guid("5515514d-58da-4027-8d3e-4b847b0742cb"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9300), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 411", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9301), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 412, 0.0, new Guid("d13c57d2-22f7-447b-a269-e5700d33a855"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9325), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 412", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9326), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 413, 0.0, new Guid("27c76cb2-147b-42fb-b62b-df9079e95e9f"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9344), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 413", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9345), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 414, 0.0, new Guid("39b0379d-70e1-4792-afda-8b87fb027f84"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9365), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 414", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9367), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 415, 0.0, new Guid("edd93c22-59aa-4ea1-ab97-dce5c0f62fc8"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9384), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 415", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9385), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 416, 0.0, new Guid("70918479-cfe7-43df-b275-dd8487f4e4df"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9402), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 416", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9403), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 417, 0.0, new Guid("6898e82c-7986-4bfb-ada3-c79fc322819e"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9426), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 417", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9427), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 418, 0.0, new Guid("e15ecf38-4454-48d4-abe3-895dff873ff2"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9448), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 418", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9450), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 419, 0.0, new Guid("a8ea83a5-87ad-4c88-8548-ca4f40b0e427"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9508), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 419", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9509), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 420, 0.0, new Guid("d7d177dc-bc27-439f-a4c9-9b8e1a6e9725"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9525), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 420", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9526), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 421, 0.0, new Guid("c8337d25-3831-42d5-8cc1-ad317cec64c1"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9537), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 421", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9537), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 422, 0.0, new Guid("b1f2811e-eae0-477e-8d8a-1728b7926969"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9551), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 422", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9552), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 423, 0.0, new Guid("a3d5e1da-e89b-4727-8cce-e26839644456"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9563), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 423", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9563), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 424, 0.0, new Guid("d80ce2d3-b5d6-4e86-8c27-2b3266635897"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9574), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 424", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9575), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 425, 0.0, new Guid("b7ea730f-9cf7-4c6d-8b4b-baf553665500"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9586), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 425", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9586), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 426, 0.0, new Guid("bdb22404-8068-4556-9dcf-c4dd501dab55"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9599), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 426", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9599), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 427, 0.0, new Guid("17e0e301-1d79-4428-9d47-ed04fca7d650"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9610), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 427", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9611), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 428, 0.0, new Guid("9bfccb97-232a-42ea-9575-34b081c0b4af"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9622), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 428", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9622), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 429, 0.0, new Guid("03af53ad-019a-46a4-b16b-33d8eff0d29e"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9633), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 429", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9634), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 430, 0.0, new Guid("63076d4d-6d8c-4c81-b99a-80775843a51d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9671), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 430", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9672), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 431, 0.0, new Guid("0c610df4-e369-44fb-9ee8-5a57a89b898f"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9685), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 431", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9685), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 432, 0.0, new Guid("24313668-7464-4a0e-b45a-6142d037734e"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9696), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 432", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9697), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 433, 0.0, new Guid("73495ae9-c75b-4b3f-9067-82bb0087e569"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9707), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 433", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9708), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 434, 0.0, new Guid("12d717a2-af41-4034-8c8c-da1b28200fd5"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9720), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 434", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9721), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 435, 0.0, new Guid("c7234f4a-d89f-4677-9f77-6d5a3f6ebbfb"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9732), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 435", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9732), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 436, 0.0, new Guid("df8ef6ab-6555-435c-a7fb-0a7f19baa18d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9743), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 436", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9743), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 437, 0.0, new Guid("57f902c0-5b0f-486c-81b8-ca80f3ebf3c4"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9754), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 437", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9754), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 438, 0.0, new Guid("d8f29add-3540-4af6-affe-5ed8a145fa7e"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9767), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 438", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9767), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 439, 0.0, new Guid("c919a6fd-d1ac-49d7-802c-9c74227ad6e9"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9778), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 439", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9779), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 440, 0.0, new Guid("9d2756a0-aa3b-47e1-999a-e7bd8b331c6b"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9789), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 440", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9790), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 441, 0.0, new Guid("3f5e34c9-efa7-4f0f-b9e3-5462f9b56827"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9824), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 441", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9825), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 442, 0.0, new Guid("ec49c6c1-384b-424a-b665-68f8a29488e3"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9839), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 442", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9839), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 443, 0.0, new Guid("35d26293-7dcb-454b-a925-e3426c1ecb3c"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9850), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 443", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9851), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 444, 0.0, new Guid("0a6469cf-c7c7-4a70-a4f7-0977f3a22133"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9861), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 444", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9862), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 445, 0.0, new Guid("19bcd5d5-39a3-45f3-a69b-3b47589d03d3"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9873), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 445", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9873), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 446, 0.0, new Guid("8d2387ba-afbf-4508-9899-76cee69a7884"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9885), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 446", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9886), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 447, 0.0, new Guid("bcbd7ee7-5628-4056-8b5f-cc907dea29f0"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9897), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 447", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9897), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 448, 0.0, new Guid("a9481a93-ecdf-4d5c-8ff0-5fe6f9f0d5ac"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9908), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 448", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9909), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 449, 0.0, new Guid("24104d11-c235-4b95-970a-19f55434cef4"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9920), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 449", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9920), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 450, 0.0, new Guid("3dda0116-b384-4d1f-a474-2a397d17995e"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9933), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 450", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9933), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 451, 0.0, new Guid("3f8d6311-0299-4cc7-afa5-5c00bf012c38"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9944), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 451", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9945), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 452, 0.0, new Guid("65cefd6f-033a-4a72-88b5-74095ed16c61"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9981), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 452", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9982), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 453, 0.0, new Guid("464304b6-c0b9-4dc8-af5e-7dc92971976a"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9994), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 453", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(9994), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 454, 0.0, new Guid("41ccb58f-eeb7-49cc-b4fb-2f56544692fb"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(7), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 454", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(7), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 455, 0.0, new Guid("693bd364-d065-44dc-b95f-06ec4ef770d5"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(18), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 455", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(19), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 456, 0.0, new Guid("921192db-225d-46e6-ae54-355f133f642d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(29), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 456", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(30), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 457, 0.0, new Guid("2fee260e-5a95-432e-940b-251efef1d64a"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(41), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 457", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(41), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 458, 0.0, new Guid("c182b611-8d5f-4b46-9f6a-31353d105df6"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(53), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 458", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(54), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 459, 0.0, new Guid("0307d51d-d821-437d-8d99-53dbd228f834"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(65), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 459", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(66), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 460, 0.0, new Guid("876efbe4-0d9b-4401-9c4f-d8950c3274ef"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(76), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 460", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(77), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 461, 0.0, new Guid("c5c33cd5-9194-4a88-8d97-d46fbb0aa300"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(87), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 461", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(88), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 462, 0.0, new Guid("06e9a017-a14c-4ec9-bc3b-88d35b536708"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 462", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(130), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 463, 0.0, new Guid("b0b8c724-c93c-4dad-8976-49dd1d989cb4"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(143), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 463", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(144), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 464, 0.0, new Guid("45774295-2019-4617-9d77-77a8dad7438c"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(155), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 464", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(156), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 465, 0.0, new Guid("6d9e3c8d-329c-49b3-b52c-d928a9ffe3ad"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(166), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 465", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(167), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 466, 0.0, new Guid("e2945c2e-6316-4b53-b1f1-333084e425c9"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(179), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 466", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(180), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 467, 0.0, new Guid("3ff9d2fb-4694-45a5-a944-eba897456ee9"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(190), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 467", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(191), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 468, 0.0, new Guid("cef6fa50-2611-40f2-a43b-5accdd458493"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(202), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 468", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(202), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 469, 0.0, new Guid("ee9546a7-82af-4f00-a771-55e8f0693d8d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(213), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 469", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(214), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 470, 0.0, new Guid("de000c27-c843-4852-8227-7f699a1c9e70"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 470", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(227), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 471, 0.0, new Guid("02d683f2-beb2-463d-990f-4e8d1bb19473"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(238), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 471", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(238), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 472, 0.0, new Guid("60df3028-e34b-427f-84fd-f388047a746a"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(249), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 472", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(250), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 473, 0.0, new Guid("ff162d4f-cbbf-4d6e-befe-099783b45035"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(287), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 473", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(288), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 474, 0.0, new Guid("008f7658-acf8-46fc-a6c4-b31079330f2d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 474", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(303), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 475, 0.0, new Guid("6cc41d93-0e2a-4860-bacc-f48714c79134"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(314), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 475", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(314), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 476, 0.0, new Guid("42e537a8-bd91-4a7e-b4c5-55cdca45e626"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(325), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 476", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(326), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 477, 0.0, new Guid("456439f7-0592-4c22-b9ba-a64d15260236"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(336), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 477", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(337), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 478, 0.0, new Guid("03eb89a4-8262-4d26-90a5-7027c93e9b65"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(349), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 478", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(349), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 479, 0.0, new Guid("5a04045f-a656-4639-ac30-b4c64590d10c"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(360), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 479", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(361), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 480, 0.0, new Guid("7fc13cd7-dd33-4926-8378-de50a8859dba"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(372), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 480", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(372), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 481, 0.0, new Guid("03427ef5-6bb5-41f2-afd7-c9b38ad8277a"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(383), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 481", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(384), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 482, 0.0, new Guid("1d6a7f53-e198-4012-ad92-9cf3440f84de"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 482", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(397), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 483, 0.0, new Guid("345ca937-41de-4fe8-865a-d64832863299"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(407), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 483", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(408), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 484, 0.0, new Guid("08c3b6a1-01f0-4c45-a283-3bd5fc4976ac"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(443), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 484", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(444), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 485, 0.0, new Guid("0e20c948-473a-47c0-8bcd-0b4cff4f1c70"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(457), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 485", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(457), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 486, 0.0, new Guid("a06a5d42-beff-48d3-ac3f-f6b11eb1064a"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(470), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 486", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(470), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 487, 0.0, new Guid("b8886215-bd52-4fce-9aff-aa36b7d8fb0e"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(482), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 487", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(482), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 488, 0.0, new Guid("239812b6-6e65-4af4-8c8a-940d95f05c7e"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(493), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 488", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(493), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 489, 0.0, new Guid("509cdf53-06a5-4304-aba4-963ee69bd3cb"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(504), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 489", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(504), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 490, 0.0, new Guid("3c685d67-3257-4d1a-8bc9-076ec5bc063a"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 490", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(517), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 491, 0.0, new Guid("5f1bdbaa-6a2b-41ba-bd99-a1217820d6f8"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(528), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 491", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(529), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 492, 0.0, new Guid("638d14e8-f6aa-47ab-8f50-bac0416151ab"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 492", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(540), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 493, 0.0, new Guid("5a6325bf-6358-48b9-8d8a-4565fb6324b8"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(551), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 493", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(552), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 494, 0.0, new Guid("2dfdd8fd-2f42-475c-94be-2b6683ff352f"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(564), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 494", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(564), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 495, 0.0, new Guid("86ff40c5-8142-49ed-a5f0-8a797e004522"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(605), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 495", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(606), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 496, 0.0, new Guid("9d0cb465-ca9f-4952-a16c-c49d83711b49"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(617), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 496", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(618), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 497, 0.0, new Guid("c41be1fd-a4b7-4136-a1ae-316d5e630340"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(629), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 497", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(629), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 498, 0.0, new Guid("c61cd7a7-ba65-4b60-8cf3-10c07c2972f0"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(642), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 498", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(642), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 499, 0.0, new Guid("f5fc51a6-2c4b-4235-9daa-641641a1e3c2"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(654), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 499", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(654), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "name", "slot", "status", "type" },
                values: new object[,]
                {
                    { 1, new Guid("b4f4311a-93ab-43b0-bb09-10928168d421"), "ViRide", 2, 1, 0 },
                    { 2, new Guid("2512050b-eaa7-45db-912f-2d4683d83866"), "ViCar-4", 4, 1, 1 },
                    { 3, new Guid("6a6bfb39-548a-4cbe-b136-da356fb75969"), "ViCar-7", 7, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "type", "updated_at", "updated_by", "user_id" },
                values: new object[] { 9, 0.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6310), new TimeSpan(0, 7, 0, 0, 0)), 0, null });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(864), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(865), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(872), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(873), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(880), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(886), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(887), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(894), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(894), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(901), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(901), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 100, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(909), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+100", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(909), new TimeSpan(0, 7, 0, 0, 0)), 0, 100, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 101, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(920), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@100", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(921), new TimeSpan(0, 7, 0, 0, 0)), 0, 100 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 102, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(932), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+101", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(932), new TimeSpan(0, 7, 0, 0, 0)), 0, 101, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 103, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(940), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@101", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(941), new TimeSpan(0, 7, 0, 0, 0)), 0, 101 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 104, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(948), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+102", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(949), new TimeSpan(0, 7, 0, 0, 0)), 0, 102, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 105, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(957), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@102", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(957), new TimeSpan(0, 7, 0, 0, 0)), 0, 102 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 106, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(965), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+103", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(966), new TimeSpan(0, 7, 0, 0, 0)), 0, 103, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 107, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(973), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@103", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(974), new TimeSpan(0, 7, 0, 0, 0)), 0, 103 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 108, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(981), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+104", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(982), new TimeSpan(0, 7, 0, 0, 0)), 0, 104, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 109, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1017), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@104", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1018), new TimeSpan(0, 7, 0, 0, 0)), 0, 104 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 110, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1027), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+105", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1027), new TimeSpan(0, 7, 0, 0, 0)), 0, 105, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 111, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1035), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@105", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1035), new TimeSpan(0, 7, 0, 0, 0)), 0, 105 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 112, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1043), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+106", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1044), new TimeSpan(0, 7, 0, 0, 0)), 0, 106, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 113, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1051), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@106", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1052), new TimeSpan(0, 7, 0, 0, 0)), 0, 106 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 114, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1059), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+107", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1060), new TimeSpan(0, 7, 0, 0, 0)), 0, 107, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 115, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1068), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@107", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1068), new TimeSpan(0, 7, 0, 0, 0)), 0, 107 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 116, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1076), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+108", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1077), new TimeSpan(0, 7, 0, 0, 0)), 0, 108, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 117, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1085), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@108", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1085), new TimeSpan(0, 7, 0, 0, 0)), 0, 108 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 118, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1093), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+109", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1094), new TimeSpan(0, 7, 0, 0, 0)), 0, 109, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 119, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1101), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@109", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1102), new TimeSpan(0, 7, 0, 0, 0)), 0, 109 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 120, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1109), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+110", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1110), new TimeSpan(0, 7, 0, 0, 0)), 0, 110, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 121, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1117), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@110", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1118), new TimeSpan(0, 7, 0, 0, 0)), 0, 110 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 122, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1125), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+111", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1126), new TimeSpan(0, 7, 0, 0, 0)), 0, 111, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 123, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1134), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@111", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1134), new TimeSpan(0, 7, 0, 0, 0)), 0, 111 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 124, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+112", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1142), new TimeSpan(0, 7, 0, 0, 0)), 0, 112, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 125, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1150), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@112", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1150), new TimeSpan(0, 7, 0, 0, 0)), 0, 112 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 126, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1158), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+113", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1158), new TimeSpan(0, 7, 0, 0, 0)), 0, 113, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 127, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1166), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@113", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1166), new TimeSpan(0, 7, 0, 0, 0)), 0, 113 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 128, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+114", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1174), new TimeSpan(0, 7, 0, 0, 0)), 0, 114, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 129, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1182), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@114", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1183), new TimeSpan(0, 7, 0, 0, 0)), 0, 114 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 130, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1191), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+115", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1191), new TimeSpan(0, 7, 0, 0, 0)), 0, 115, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 131, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1227), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@115", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1228), new TimeSpan(0, 7, 0, 0, 0)), 0, 115 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 132, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1237), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+116", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1237), new TimeSpan(0, 7, 0, 0, 0)), 0, 116, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 133, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1245), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@116", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1246), new TimeSpan(0, 7, 0, 0, 0)), 0, 116 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 134, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1253), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+117", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1254), new TimeSpan(0, 7, 0, 0, 0)), 0, 117, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 135, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1262), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@117", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1262), new TimeSpan(0, 7, 0, 0, 0)), 0, 117 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 136, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1270), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+118", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1270), new TimeSpan(0, 7, 0, 0, 0)), 0, 118, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 137, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1278), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@118", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1279), new TimeSpan(0, 7, 0, 0, 0)), 0, 118 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 138, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1286), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+119", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1287), new TimeSpan(0, 7, 0, 0, 0)), 0, 119, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 139, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1294), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@119", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1295), new TimeSpan(0, 7, 0, 0, 0)), 0, 119 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 140, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+120", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1303), new TimeSpan(0, 7, 0, 0, 0)), 0, 120, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 141, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1313), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@120", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1313), new TimeSpan(0, 7, 0, 0, 0)), 0, 120 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 142, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+121", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1322), new TimeSpan(0, 7, 0, 0, 0)), 0, 121, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 143, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1329), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@121", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1330), new TimeSpan(0, 7, 0, 0, 0)), 0, 121 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 144, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1337), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+122", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1338), new TimeSpan(0, 7, 0, 0, 0)), 0, 122, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 145, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@122", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1346), new TimeSpan(0, 7, 0, 0, 0)), 0, 122 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 146, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+123", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1354), new TimeSpan(0, 7, 0, 0, 0)), 0, 123, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 147, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1362), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@123", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1363), new TimeSpan(0, 7, 0, 0, 0)), 0, 123 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 148, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1370), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+124", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1370), new TimeSpan(0, 7, 0, 0, 0)), 0, 124, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 149, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@124", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1379), new TimeSpan(0, 7, 0, 0, 0)), 0, 124 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 150, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1411), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+125", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1412), new TimeSpan(0, 7, 0, 0, 0)), 0, 125, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 151, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1422), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@125", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1422), new TimeSpan(0, 7, 0, 0, 0)), 0, 125 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 152, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1430), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+126", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1430), new TimeSpan(0, 7, 0, 0, 0)), 0, 126, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 153, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1438), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@126", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1438), new TimeSpan(0, 7, 0, 0, 0)), 0, 126 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 154, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1446), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+127", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1446), new TimeSpan(0, 7, 0, 0, 0)), 0, 127, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 155, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1454), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@127", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1454), new TimeSpan(0, 7, 0, 0, 0)), 0, 127 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 156, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1462), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+128", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1463), new TimeSpan(0, 7, 0, 0, 0)), 0, 128, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 157, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1470), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@128", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1470), new TimeSpan(0, 7, 0, 0, 0)), 0, 128 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 158, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1478), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+129", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1478), new TimeSpan(0, 7, 0, 0, 0)), 0, 129, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 159, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1486), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@129", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1486), new TimeSpan(0, 7, 0, 0, 0)), 0, 129 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 160, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1494), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+130", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1494), new TimeSpan(0, 7, 0, 0, 0)), 0, 130, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 161, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1502), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@130", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1502), new TimeSpan(0, 7, 0, 0, 0)), 0, 130 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 162, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1509), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+131", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1510), new TimeSpan(0, 7, 0, 0, 0)), 0, 131, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 163, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@131", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1518), new TimeSpan(0, 7, 0, 0, 0)), 0, 131 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 164, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1525), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+132", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1526), new TimeSpan(0, 7, 0, 0, 0)), 0, 132, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 165, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@132", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1534), new TimeSpan(0, 7, 0, 0, 0)), 0, 132 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 166, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1541), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+133", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1542), new TimeSpan(0, 7, 0, 0, 0)), 0, 133, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 167, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1550), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@133", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1550), new TimeSpan(0, 7, 0, 0, 0)), 0, 133 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 168, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1558), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+134", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1558), new TimeSpan(0, 7, 0, 0, 0)), 0, 134, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 169, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1566), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@134", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1566), new TimeSpan(0, 7, 0, 0, 0)), 0, 134 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 170, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1574), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+135", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1574), new TimeSpan(0, 7, 0, 0, 0)), 0, 135, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 171, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1582), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@135", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1582), new TimeSpan(0, 7, 0, 0, 0)), 0, 135 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 172, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1590), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+136", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1590), new TimeSpan(0, 7, 0, 0, 0)), 0, 136, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 173, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1644), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@136", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1645), new TimeSpan(0, 7, 0, 0, 0)), 0, 136 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 174, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1653), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+137", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1654), new TimeSpan(0, 7, 0, 0, 0)), 0, 137, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 175, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1661), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@137", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1662), new TimeSpan(0, 7, 0, 0, 0)), 0, 137 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 176, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1669), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+138", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1670), new TimeSpan(0, 7, 0, 0, 0)), 0, 138, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 177, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1677), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@138", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1678), new TimeSpan(0, 7, 0, 0, 0)), 0, 138 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 178, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1686), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+139", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1686), new TimeSpan(0, 7, 0, 0, 0)), 0, 139, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 179, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1693), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@139", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1694), new TimeSpan(0, 7, 0, 0, 0)), 0, 139 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 180, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1701), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+140", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1702), new TimeSpan(0, 7, 0, 0, 0)), 0, 140, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 181, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1709), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@140", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1710), new TimeSpan(0, 7, 0, 0, 0)), 0, 140 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 182, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1718), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+141", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1718), new TimeSpan(0, 7, 0, 0, 0)), 0, 141, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 183, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1725), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@141", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1726), new TimeSpan(0, 7, 0, 0, 0)), 0, 141 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 184, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1734), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+142", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1734), new TimeSpan(0, 7, 0, 0, 0)), 0, 142, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 185, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1742), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@142", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1742), new TimeSpan(0, 7, 0, 0, 0)), 0, 142 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 186, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1750), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+143", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1750), new TimeSpan(0, 7, 0, 0, 0)), 0, 143, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 187, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1758), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@143", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1758), new TimeSpan(0, 7, 0, 0, 0)), 0, 143 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 188, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1766), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+144", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1766), new TimeSpan(0, 7, 0, 0, 0)), 0, 144, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 189, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1774), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@144", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1775), new TimeSpan(0, 7, 0, 0, 0)), 0, 144 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 190, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1782), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+145", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1783), new TimeSpan(0, 7, 0, 0, 0)), 0, 145, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 191, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1791), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@145", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1791), new TimeSpan(0, 7, 0, 0, 0)), 0, 145 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 192, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1799), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+146", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1799), new TimeSpan(0, 7, 0, 0, 0)), 0, 146, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 193, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1807), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@146", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1807), new TimeSpan(0, 7, 0, 0, 0)), 0, 146 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 194, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1815), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+147", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1816), new TimeSpan(0, 7, 0, 0, 0)), 0, 147, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 195, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1852), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@147", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1852), new TimeSpan(0, 7, 0, 0, 0)), 0, 147 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 196, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1861), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+148", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1861), new TimeSpan(0, 7, 0, 0, 0)), 0, 148, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 197, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1869), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@148", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1870), new TimeSpan(0, 7, 0, 0, 0)), 0, 148 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 198, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1877), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+149", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1878), new TimeSpan(0, 7, 0, 0, 0)), 0, 149, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 199, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1885), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@149", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1886), new TimeSpan(0, 7, 0, 0, 0)), 0, 149 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 200, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1894), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+150", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1894), new TimeSpan(0, 7, 0, 0, 0)), 0, 150, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 201, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1902), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@150", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1903), new TimeSpan(0, 7, 0, 0, 0)), 0, 150 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 202, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1910), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+151", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1911), new TimeSpan(0, 7, 0, 0, 0)), 0, 151, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 203, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1918), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@151", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1919), new TimeSpan(0, 7, 0, 0, 0)), 0, 151 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 204, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1926), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+152", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1927), new TimeSpan(0, 7, 0, 0, 0)), 0, 152, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 205, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1937), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@152", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1938), new TimeSpan(0, 7, 0, 0, 0)), 0, 152 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 206, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1945), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+153", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1946), new TimeSpan(0, 7, 0, 0, 0)), 0, 153, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 207, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@153", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1954), new TimeSpan(0, 7, 0, 0, 0)), 0, 153 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 208, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+154", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1962), new TimeSpan(0, 7, 0, 0, 0)), 0, 154, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 209, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1970), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@154", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1971), new TimeSpan(0, 7, 0, 0, 0)), 0, 154 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 210, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1978), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+155", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(1979), new TimeSpan(0, 7, 0, 0, 0)), 0, 155, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 211, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2014), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@155", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2015), new TimeSpan(0, 7, 0, 0, 0)), 0, 155 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 212, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2024), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+156", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2024), new TimeSpan(0, 7, 0, 0, 0)), 0, 156, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 213, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2032), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@156", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2033), new TimeSpan(0, 7, 0, 0, 0)), 0, 156 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 214, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2041), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+157", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2041), new TimeSpan(0, 7, 0, 0, 0)), 0, 157, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 215, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2049), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@157", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2050), new TimeSpan(0, 7, 0, 0, 0)), 0, 157 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 216, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2057), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+158", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2058), new TimeSpan(0, 7, 0, 0, 0)), 0, 158, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 217, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2066), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@158", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2067), new TimeSpan(0, 7, 0, 0, 0)), 0, 158 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 218, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2074), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+159", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2075), new TimeSpan(0, 7, 0, 0, 0)), 0, 159, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 219, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2082), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@159", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2083), new TimeSpan(0, 7, 0, 0, 0)), 0, 159 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 220, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2090), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+160", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2091), new TimeSpan(0, 7, 0, 0, 0)), 0, 160, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 221, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2099), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@160", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2099), new TimeSpan(0, 7, 0, 0, 0)), 0, 160 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 222, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2107), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+161", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2108), new TimeSpan(0, 7, 0, 0, 0)), 0, 161, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 223, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2116), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@161", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2116), new TimeSpan(0, 7, 0, 0, 0)), 0, 161 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 224, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2124), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+162", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2125), new TimeSpan(0, 7, 0, 0, 0)), 0, 162, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 225, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2132), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@162", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2133), new TimeSpan(0, 7, 0, 0, 0)), 0, 162 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 226, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+163", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2142), new TimeSpan(0, 7, 0, 0, 0)), 0, 163, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 227, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2149), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@163", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2150), new TimeSpan(0, 7, 0, 0, 0)), 0, 163 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 228, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+164", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2158), new TimeSpan(0, 7, 0, 0, 0)), 0, 164, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 229, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2166), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@164", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2166), new TimeSpan(0, 7, 0, 0, 0)), 0, 164 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 230, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+165", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2175), new TimeSpan(0, 7, 0, 0, 0)), 0, 165, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 231, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2182), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@165", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2183), new TimeSpan(0, 7, 0, 0, 0)), 0, 165 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 232, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2190), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+166", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2191), new TimeSpan(0, 7, 0, 0, 0)), 0, 166, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 233, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2199), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@166", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2199), new TimeSpan(0, 7, 0, 0, 0)), 0, 166 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 234, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2236), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+167", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2237), new TimeSpan(0, 7, 0, 0, 0)), 0, 167, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 235, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2244), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@167", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2245), new TimeSpan(0, 7, 0, 0, 0)), 0, 167 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 236, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2253), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+168", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2253), new TimeSpan(0, 7, 0, 0, 0)), 0, 168, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 237, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2261), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@168", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2261), new TimeSpan(0, 7, 0, 0, 0)), 0, 168 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 238, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2269), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+169", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2269), new TimeSpan(0, 7, 0, 0, 0)), 0, 169, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 239, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2277), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@169", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2277), new TimeSpan(0, 7, 0, 0, 0)), 0, 169 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 240, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2285), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+170", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2285), new TimeSpan(0, 7, 0, 0, 0)), 0, 170, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 241, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2293), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@170", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2293), new TimeSpan(0, 7, 0, 0, 0)), 0, 170 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 242, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2301), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+171", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2301), new TimeSpan(0, 7, 0, 0, 0)), 0, 171, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 243, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2309), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@171", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2309), new TimeSpan(0, 7, 0, 0, 0)), 0, 171 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 244, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2317), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+172", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2318), new TimeSpan(0, 7, 0, 0, 0)), 0, 172, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 245, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2325), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@172", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2326), new TimeSpan(0, 7, 0, 0, 0)), 0, 172 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 246, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2333), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+173", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2333), new TimeSpan(0, 7, 0, 0, 0)), 0, 173, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 247, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2341), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@173", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2341), new TimeSpan(0, 7, 0, 0, 0)), 0, 173 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 248, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2349), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+174", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2349), new TimeSpan(0, 7, 0, 0, 0)), 0, 174, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 249, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2357), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@174", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2357), new TimeSpan(0, 7, 0, 0, 0)), 0, 174 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 250, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2365), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+175", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2365), new TimeSpan(0, 7, 0, 0, 0)), 0, 175, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 251, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2373), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@175", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2374), new TimeSpan(0, 7, 0, 0, 0)), 0, 175 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 252, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2381), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+176", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2381), new TimeSpan(0, 7, 0, 0, 0)), 0, 176, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 253, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2389), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@176", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2389), new TimeSpan(0, 7, 0, 0, 0)), 0, 176 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 254, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+177", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2397), new TimeSpan(0, 7, 0, 0, 0)), 0, 177, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 255, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@177", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2405), new TimeSpan(0, 7, 0, 0, 0)), 0, 177 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 256, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2441), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+178", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2442), new TimeSpan(0, 7, 0, 0, 0)), 0, 178, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 257, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2450), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@178", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2450), new TimeSpan(0, 7, 0, 0, 0)), 0, 178 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 258, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2458), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+179", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2459), new TimeSpan(0, 7, 0, 0, 0)), 0, 179, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 259, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2466), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@179", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2467), new TimeSpan(0, 7, 0, 0, 0)), 0, 179 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 260, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2474), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+180", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2475), new TimeSpan(0, 7, 0, 0, 0)), 0, 180, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 261, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2482), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@180", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2483), new TimeSpan(0, 7, 0, 0, 0)), 0, 180 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 262, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2490), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+181", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2491), new TimeSpan(0, 7, 0, 0, 0)), 0, 181, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 263, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2498), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@181", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2499), new TimeSpan(0, 7, 0, 0, 0)), 0, 181 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 264, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2506), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+182", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2507), new TimeSpan(0, 7, 0, 0, 0)), 0, 182, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 265, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2514), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@182", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2515), new TimeSpan(0, 7, 0, 0, 0)), 0, 182 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 266, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2522), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+183", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2522), new TimeSpan(0, 7, 0, 0, 0)), 0, 183, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 267, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2530), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@183", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2531), new TimeSpan(0, 7, 0, 0, 0)), 0, 183 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 268, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2538), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+184", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2539), new TimeSpan(0, 7, 0, 0, 0)), 0, 184, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 269, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2546), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@184", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2546), new TimeSpan(0, 7, 0, 0, 0)), 0, 184 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 270, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2554), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+185", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2554), new TimeSpan(0, 7, 0, 0, 0)), 0, 185, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 271, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2562), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@185", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2563), new TimeSpan(0, 7, 0, 0, 0)), 0, 185 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 272, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2570), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+186", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2571), new TimeSpan(0, 7, 0, 0, 0)), 0, 186, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 273, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2578), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@186", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2578), new TimeSpan(0, 7, 0, 0, 0)), 0, 186 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 274, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2586), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+187", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2586), new TimeSpan(0, 7, 0, 0, 0)), 0, 187, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 275, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2594), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@187", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2594), new TimeSpan(0, 7, 0, 0, 0)), 0, 187 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 276, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2602), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+188", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2602), new TimeSpan(0, 7, 0, 0, 0)), 0, 188, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 277, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2610), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@188", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2610), new TimeSpan(0, 7, 0, 0, 0)), 0, 188 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 278, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2652), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+189", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2653), new TimeSpan(0, 7, 0, 0, 0)), 0, 189, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 279, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2662), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@189", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2662), new TimeSpan(0, 7, 0, 0, 0)), 0, 189 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 280, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2670), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+190", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2671), new TimeSpan(0, 7, 0, 0, 0)), 0, 190, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 281, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2678), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@190", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2679), new TimeSpan(0, 7, 0, 0, 0)), 0, 190 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 282, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2687), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+191", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2688), new TimeSpan(0, 7, 0, 0, 0)), 0, 191, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 283, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2695), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@191", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2696), new TimeSpan(0, 7, 0, 0, 0)), 0, 191 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 284, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2703), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+192", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2704), new TimeSpan(0, 7, 0, 0, 0)), 0, 192, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 285, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2712), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@192", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2713), new TimeSpan(0, 7, 0, 0, 0)), 0, 192 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 286, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2720), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+193", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2721), new TimeSpan(0, 7, 0, 0, 0)), 0, 193, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 287, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2728), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@193", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2729), new TimeSpan(0, 7, 0, 0, 0)), 0, 193 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 288, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2736), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+194", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2737), new TimeSpan(0, 7, 0, 0, 0)), 0, 194, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 289, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2745), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@194", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2746), new TimeSpan(0, 7, 0, 0, 0)), 0, 194 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 290, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2753), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+195", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2754), new TimeSpan(0, 7, 0, 0, 0)), 0, 195, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 291, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2761), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@195", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2762), new TimeSpan(0, 7, 0, 0, 0)), 0, 195 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 292, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2770), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+196", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2771), new TimeSpan(0, 7, 0, 0, 0)), 0, 196, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 293, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2792), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@196", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2793), new TimeSpan(0, 7, 0, 0, 0)), 0, 196 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 294, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2801), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+197", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2802), new TimeSpan(0, 7, 0, 0, 0)), 0, 197, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 295, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2810), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@197", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2810), new TimeSpan(0, 7, 0, 0, 0)), 0, 197 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 296, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+198", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2819), new TimeSpan(0, 7, 0, 0, 0)), 0, 198, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 297, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2826), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@198", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2827), new TimeSpan(0, 7, 0, 0, 0)), 0, 198 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 298, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2834), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+199", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2835), new TimeSpan(0, 7, 0, 0, 0)), 0, 199, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 299, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2843), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@199", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2843), new TimeSpan(0, 7, 0, 0, 0)), 0, 199 },
                    { 400, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2878), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+400", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2879), new TimeSpan(0, 7, 0, 0, 0)), 0, 400 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 401, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2889), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@400", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2890), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 402, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2898), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+401", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2899), new TimeSpan(0, 7, 0, 0, 0)), 0, 401 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 403, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2906), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@401", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2907), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 404, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2914), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+402", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2915), new TimeSpan(0, 7, 0, 0, 0)), 0, 402 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 405, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2922), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@402", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2923), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 406, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2930), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+403", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2931), new TimeSpan(0, 7, 0, 0, 0)), 0, 403 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 407, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2938), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@403", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2938), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 408, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2945), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+404", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2946), new TimeSpan(0, 7, 0, 0, 0)), 0, 404 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 409, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@404", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2954), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 410, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2961), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+405", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2962), new TimeSpan(0, 7, 0, 0, 0)), 0, 405 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 411, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2969), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@405", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2969), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 412, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2977), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+406", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2978), new TimeSpan(0, 7, 0, 0, 0)), 0, 406 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 413, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2985), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@406", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2986), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 414, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2993), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+407", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(2993), new TimeSpan(0, 7, 0, 0, 0)), 0, 407 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 415, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3000), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@407", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3001), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 416, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3008), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+408", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3009), new TimeSpan(0, 7, 0, 0, 0)), 0, 408 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 417, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3016), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@408", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3017), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 418, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3024), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+409", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3025), new TimeSpan(0, 7, 0, 0, 0)), 0, 409 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 419, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3032), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@409", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3032), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 420, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3039), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+410", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3040), new TimeSpan(0, 7, 0, 0, 0)), 0, 410 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 421, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3047), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@410", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3048), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 422, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3081), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+411", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3083), new TimeSpan(0, 7, 0, 0, 0)), 0, 411 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 423, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3091), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@411", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3092), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 424, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3099), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+412", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3100), new TimeSpan(0, 7, 0, 0, 0)), 0, 412 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 425, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3107), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@412", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3108), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 426, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3115), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+413", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3116), new TimeSpan(0, 7, 0, 0, 0)), 0, 413 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 427, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3123), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@413", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3123), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 428, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3130), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+414", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3131), new TimeSpan(0, 7, 0, 0, 0)), 0, 414 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 429, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3138), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@414", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3139), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 430, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3146), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+415", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3147), new TimeSpan(0, 7, 0, 0, 0)), 0, 415 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 431, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3154), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@415", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3155), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 432, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3162), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+416", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3162), new TimeSpan(0, 7, 0, 0, 0)), 0, 416 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 433, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3198), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@416", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3199), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 434, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3208), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+417", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3209), new TimeSpan(0, 7, 0, 0, 0)), 0, 417 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 435, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3216), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@417", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3217), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 436, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3224), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+418", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3225), new TimeSpan(0, 7, 0, 0, 0)), 0, 418 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 437, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3232), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@418", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3233), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 438, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3240), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+419", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3241), new TimeSpan(0, 7, 0, 0, 0)), 0, 419 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 439, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3248), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@419", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3249), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 440, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+420", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3257), new TimeSpan(0, 7, 0, 0, 0)), 0, 420 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 441, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3264), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@420", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3265), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 442, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3272), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+421", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3273), new TimeSpan(0, 7, 0, 0, 0)), 0, 421 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 443, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3280), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@421", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3281), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 444, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3288), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+422", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3289), new TimeSpan(0, 7, 0, 0, 0)), 0, 422 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 445, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3296), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@422", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3297), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 446, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3304), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+423", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3305), new TimeSpan(0, 7, 0, 0, 0)), 0, 423 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 447, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3312), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@423", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3313), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 448, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3320), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+424", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3321), new TimeSpan(0, 7, 0, 0, 0)), 0, 424 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 449, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3328), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@424", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3329), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 450, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3337), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+425", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3337), new TimeSpan(0, 7, 0, 0, 0)), 0, 425 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 451, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3344), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@425", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3345), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 452, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3352), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+426", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3353), new TimeSpan(0, 7, 0, 0, 0)), 0, 426 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 453, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3360), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@426", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3361), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 454, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+427", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3369), new TimeSpan(0, 7, 0, 0, 0)), 0, 427 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 455, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3376), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@427", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3377), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 456, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3413), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+428", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3414), new TimeSpan(0, 7, 0, 0, 0)), 0, 428 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 457, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3422), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@428", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3422), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 458, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3429), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+429", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3430), new TimeSpan(0, 7, 0, 0, 0)), 0, 429 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 459, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3437), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@429", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3438), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 460, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3445), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+430", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3446), new TimeSpan(0, 7, 0, 0, 0)), 0, 430 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 461, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3453), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@430", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3453), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 462, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3461), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+431", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3461), new TimeSpan(0, 7, 0, 0, 0)), 0, 431 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 463, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@431", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3469), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 464, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3476), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+432", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3477), new TimeSpan(0, 7, 0, 0, 0)), 0, 432 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 465, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3484), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@432", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3485), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 466, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3492), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+433", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3492), new TimeSpan(0, 7, 0, 0, 0)), 0, 433 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 467, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3500), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@433", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3500), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 468, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3507), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+434", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3508), new TimeSpan(0, 7, 0, 0, 0)), 0, 434 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 469, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3515), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@434", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3516), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 470, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3523), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+435", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3523), new TimeSpan(0, 7, 0, 0, 0)), 0, 435 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 471, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3530), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@435", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3531), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 472, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3538), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+436", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3539), new TimeSpan(0, 7, 0, 0, 0)), 0, 436 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 473, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3546), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@436", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3547), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 474, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3554), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+437", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3555), new TimeSpan(0, 7, 0, 0, 0)), 0, 437 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 475, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3562), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@437", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3563), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 476, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3570), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+438", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3570), new TimeSpan(0, 7, 0, 0, 0)), 0, 438 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 477, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3578), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@438", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3579), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 478, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3613), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+439", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3614), new TimeSpan(0, 7, 0, 0, 0)), 0, 439 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 479, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3621), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@439", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3622), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 480, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3630), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+440", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3630), new TimeSpan(0, 7, 0, 0, 0)), 0, 440 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 481, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3637), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@440", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3638), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 482, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3645), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+441", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3646), new TimeSpan(0, 7, 0, 0, 0)), 0, 441 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 483, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3653), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@441", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3653), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 484, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3660), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+442", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3661), new TimeSpan(0, 7, 0, 0, 0)), 0, 442 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 485, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3668), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@442", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3669), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 486, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+443", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3677), new TimeSpan(0, 7, 0, 0, 0)), 0, 443 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 487, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3684), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@443", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3685), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 488, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3692), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+444", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3693), new TimeSpan(0, 7, 0, 0, 0)), 0, 444 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 489, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3700), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@444", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3701), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 490, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3708), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+445", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3709), new TimeSpan(0, 7, 0, 0, 0)), 0, 445 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 491, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3716), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@445", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3716), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 492, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3723), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+446", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3724), new TimeSpan(0, 7, 0, 0, 0)), 0, 446 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 493, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3731), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@446", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3732), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 494, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3739), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+447", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3739), new TimeSpan(0, 7, 0, 0, 0)), 0, 447 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 495, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3746), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@447", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3747), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 496, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3754), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+448", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3755), new TimeSpan(0, 7, 0, 0, 0)), 0, 448 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 497, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@448", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3762), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 498, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+449", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3770), new TimeSpan(0, 7, 0, 0, 0)), 0, 449 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 499, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3777), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@449", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3778), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 500, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3814), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+450", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3815), new TimeSpan(0, 7, 0, 0, 0)), 0, 450 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 501, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3823), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@450", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3823), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 502, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3831), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+451", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3832), new TimeSpan(0, 7, 0, 0, 0)), 0, 451 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 503, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3838), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@451", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3839), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 504, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+452", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3847), new TimeSpan(0, 7, 0, 0, 0)), 0, 452 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 505, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3854), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@452", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3855), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 506, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3862), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+453", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3863), new TimeSpan(0, 7, 0, 0, 0)), 0, 453 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 507, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3870), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@453", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3870), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 508, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3878), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+454", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3878), new TimeSpan(0, 7, 0, 0, 0)), 0, 454 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 509, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3885), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@454", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3886), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 510, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3893), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+455", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3894), new TimeSpan(0, 7, 0, 0, 0)), 0, 455 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 511, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3901), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@455", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3902), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 512, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3909), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+456", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3909), new TimeSpan(0, 7, 0, 0, 0)), 0, 456 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 513, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3917), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@456", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3917), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 514, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3924), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+457", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3925), new TimeSpan(0, 7, 0, 0, 0)), 0, 457 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 515, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3932), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@457", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3933), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 516, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3940), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+458", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3941), new TimeSpan(0, 7, 0, 0, 0)), 0, 458 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 517, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3948), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@458", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3949), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 518, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3956), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+459", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3956), new TimeSpan(0, 7, 0, 0, 0)), 0, 459 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 519, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3963), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@459", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3964), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 520, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3971), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+460", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3972), new TimeSpan(0, 7, 0, 0, 0)), 0, 460 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 521, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3979), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@460", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(3980), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 522, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4015), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+461", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4015), new TimeSpan(0, 7, 0, 0, 0)), 0, 461 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 523, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4024), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@461", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4024), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 524, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4031), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+462", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4032), new TimeSpan(0, 7, 0, 0, 0)), 0, 462 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 525, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4039), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@462", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4039), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 526, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4047), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+463", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4047), new TimeSpan(0, 7, 0, 0, 0)), 0, 463 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 527, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4054), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@463", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4055), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 528, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4062), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+464", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4063), new TimeSpan(0, 7, 0, 0, 0)), 0, 464 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 529, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4070), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@464", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4071), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 530, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4078), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+465", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4079), new TimeSpan(0, 7, 0, 0, 0)), 0, 465 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 531, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4086), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@465", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4086), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 532, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4094), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+466", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4095), new TimeSpan(0, 7, 0, 0, 0)), 0, 466 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 533, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4102), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@466", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4103), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 534, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4110), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+467", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4110), new TimeSpan(0, 7, 0, 0, 0)), 0, 467 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 535, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4118), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@467", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4118), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 536, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4125), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+468", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4126), new TimeSpan(0, 7, 0, 0, 0)), 0, 468 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 537, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4133), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@468", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4134), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 538, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+469", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4142), new TimeSpan(0, 7, 0, 0, 0)), 0, 469 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 539, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4149), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@469", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4150), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 540, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+470", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4158), new TimeSpan(0, 7, 0, 0, 0)), 0, 470 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 541, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4165), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@470", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4166), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 542, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+471", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4174), new TimeSpan(0, 7, 0, 0, 0)), 0, 471 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 543, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4181), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@471", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4182), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 544, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4224), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+472", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4224), new TimeSpan(0, 7, 0, 0, 0)), 0, 472 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 545, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4235), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@472", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4235), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 546, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4243), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+473", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4243), new TimeSpan(0, 7, 0, 0, 0)), 0, 473 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 547, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4251), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@473", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4251), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 548, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4259), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+474", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4259), new TimeSpan(0, 7, 0, 0, 0)), 0, 474 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 549, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@474", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4267), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 550, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4274), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+475", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4275), new TimeSpan(0, 7, 0, 0, 0)), 0, 475 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 551, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4282), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@475", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4283), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 552, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4290), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+476", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4291), new TimeSpan(0, 7, 0, 0, 0)), 0, 476 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 553, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4298), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@476", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4299), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 554, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4306), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+477", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4306), new TimeSpan(0, 7, 0, 0, 0)), 0, 477 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 555, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4313), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@477", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4314), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 556, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+478", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4322), new TimeSpan(0, 7, 0, 0, 0)), 0, 478 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 557, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4329), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@478", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4330), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 558, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4337), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+479", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4338), new TimeSpan(0, 7, 0, 0, 0)), 0, 479 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 559, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@479", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4345), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 560, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4352), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+480", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4353), new TimeSpan(0, 7, 0, 0, 0)), 0, 480 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 561, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4360), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@480", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4361), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 562, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+481", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4369), new TimeSpan(0, 7, 0, 0, 0)), 0, 481 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 563, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4376), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@481", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4377), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 564, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4384), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+482", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4385), new TimeSpan(0, 7, 0, 0, 0)), 0, 482 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 565, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4392), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@482", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4393), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 566, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4400), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+483", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4401), new TimeSpan(0, 7, 0, 0, 0)), 0, 483 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 567, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4437), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@483", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4438), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 568, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4445), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+484", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4446), new TimeSpan(0, 7, 0, 0, 0)), 0, 484 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 569, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4453), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@484", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4454), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 570, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4461), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+485", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4462), new TimeSpan(0, 7, 0, 0, 0)), 0, 485 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 571, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4469), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@485", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4469), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 572, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4477), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+486", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4477), new TimeSpan(0, 7, 0, 0, 0)), 0, 486 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 573, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4484), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@486", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4485), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 574, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4492), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+487", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4493), new TimeSpan(0, 7, 0, 0, 0)), 0, 487 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 575, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4500), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@487", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4501), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 576, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4508), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+488", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4509), new TimeSpan(0, 7, 0, 0, 0)), 0, 488 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 577, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4516), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@488", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4517), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 578, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4524), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+489", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4525), new TimeSpan(0, 7, 0, 0, 0)), 0, 489 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 579, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4532), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@489", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4533), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 580, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+490", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4541), new TimeSpan(0, 7, 0, 0, 0)), 0, 490 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 581, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@490", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4549), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 582, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4556), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+491", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4557), new TimeSpan(0, 7, 0, 0, 0)), 0, 491 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 583, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4564), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@491", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4565), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 584, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+492", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4573), new TimeSpan(0, 7, 0, 0, 0)), 0, 492 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 585, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4580), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@492", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4580), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 586, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4588), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+493", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4588), new TimeSpan(0, 7, 0, 0, 0)), 0, 493 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 587, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4595), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@493", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4596), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 588, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4603), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+494", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4604), new TimeSpan(0, 7, 0, 0, 0)), 0, 494 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 589, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4639), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@494", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4640), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 590, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4648), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+495", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4649), new TimeSpan(0, 7, 0, 0, 0)), 0, 495 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 591, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4656), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@495", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4657), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 592, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+496", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4665), new TimeSpan(0, 7, 0, 0, 0)), 0, 496 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 593, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4672), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@496", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4673), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 594, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+497", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4681), new TimeSpan(0, 7, 0, 0, 0)), 0, 497 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 595, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@497", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4689), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 596, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4696), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+498", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4696), new TimeSpan(0, 7, 0, 0, 0)), 0, 498 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 597, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@498", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4704), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 598, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4712), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+499", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4713), new TimeSpan(0, 7, 0, 0, 0)), 0, 499 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 599, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4721), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@499", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4721), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, true });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "title", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5437), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, "What is Lorem Ipsum?", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5438), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5442), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, "Why do we use it?", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5442), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5443), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, "Where does it come from?", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5444), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5445), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, "Where can I get some?", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5445), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5534), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5537), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5537), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5539), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5539), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4927), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4928), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4977), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4999), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5000), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4742), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4743), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4758), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4758), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4794), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4795), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trip_rate", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "rating", "status", "suddenly_cancelled_trips", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 0.0, new Guid("ee310928-afbe-45c6-9087-c22ede2f84a1"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7461), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, 1, "Quach Dai Loi", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7462), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 0.0, new Guid("28b602c0-6b48-4cdf-8f1a-737e214827d3"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7477), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, 1, "Do Trong Dat", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7477), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 0.0, new Guid("d9e8072b-4c65-4893-a924-cfa8394f8f85"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7491), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 3, 1, "Nguyen Dang Khoa", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7491), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 0.0, new Guid("97877c79-31be-4680-a1ac-d2665c9cc7a8"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7502), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 4, 1, "Than Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7503), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 0.0, new Guid("b251766d-1590-43ba-8990-c8d4e9854664"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7513), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 5, 1, "Loi Quach", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7513), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 0.0, new Guid("077684ea-bee8-4adf-a192-b3276fe08d9e"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7525), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 6, 1, "Dat Do", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7526), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 0.0, new Guid("6e5193b7-8dfd-4c5f-b57b-195dd45f31d4"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7538), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 7, 1, "Khoa Nguyen", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7539), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 0.0, new Guid("d1604477-576f-4cfc-9a4d-4c34be322cdc"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7549), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 8, 1, "Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7549), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 0.0, new Guid("402a92ee-11c0-4976-9c11-0a0debccb9f5"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 13, 1, "Admin Quach Dai Loi", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 561, DateTimeKind.Unspecified).AddTicks(7587), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 400, new Guid("0de36515-e3c9-4ebd-adea-99a52c1cb1b9"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5718), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.400", "Vehicle 400", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5718), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, 2 },
                    { 401, new Guid("7eb2525c-bb80-4d53-8853-283022ed4c91"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5727), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.401", "Vehicle 401", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5728), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, 2 },
                    { 402, new Guid("a7bdd43e-a1c1-43c1-8bd7-bfeac21ffede"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5731), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.402", "Vehicle 402", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5732), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, 2 },
                    { 403, new Guid("00f1cd32-0608-4585-9ce5-3067522539d2"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5734), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.403", "Vehicle 403", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5735), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, 2 },
                    { 404, new Guid("050dadeb-73c3-4023-a7a1-498fcda17ef3"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5740), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.404", "Vehicle 404", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5740), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, 2 },
                    { 405, new Guid("5ed09548-b281-490e-b4a0-02ac17314259"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5744), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.405", "Vehicle 405", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5745), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, 2 },
                    { 406, new Guid("fc22bbb2-8839-4304-8b3e-17a1281b9e89"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5748), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.406", "Vehicle 406", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5749), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, 2 },
                    { 407, new Guid("aab5eeff-6b4d-4d70-a88c-990de39ea716"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5752), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.407", "Vehicle 407", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5752), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, 2 },
                    { 408, new Guid("7fe18006-d0cb-4010-9c1f-5492c6e2c9ee"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.408", "Vehicle 408", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5756), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, 2 },
                    { 409, new Guid("f1bd344a-3030-4667-a5b0-0f506946f6b5"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5758), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.409", "Vehicle 409", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5759), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, 2 },
                    { 410, new Guid("5078c512-0c73-4d00-bccb-f18f194afc1f"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.410", "Vehicle 410", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5762), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, 2 },
                    { 411, new Guid("a71910fe-600a-47c7-a422-50b63e7610bd"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5765), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.411", "Vehicle 411", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5766), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, 2 },
                    { 412, new Guid("94d040fe-0b8c-42b1-add4-6d13f46bc623"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5770), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.412", "Vehicle 412", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5771), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, 2 },
                    { 413, new Guid("80b1f2b9-fb6b-45d0-9503-7b18533917e7"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5803), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.413", "Vehicle 413", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5804), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, 2 },
                    { 414, new Guid("c7082ef9-3085-4dea-b1e4-6aee79af369e"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5807), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.414", "Vehicle 414", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, 2 },
                    { 415, new Guid("5838bca2-09d8-4fd3-8363-e34db0ab608b"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5811), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.415", "Vehicle 415", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5811), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, 2 },
                    { 416, new Guid("866a8305-9dcc-4076-bc22-2abd6dc72180"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5814), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.416", "Vehicle 416", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5815), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, 2 },
                    { 417, new Guid("d1b1ca58-a25e-47e7-b77a-0676d4a1ec1d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.417", "Vehicle 417", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5818), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, 2 },
                    { 418, new Guid("60ebfa97-9dbb-4d41-a0fd-34631f226fc5"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5821), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.418", "Vehicle 418", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5822), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, 2 },
                    { 419, new Guid("e1352ed7-04b5-46f8-8519-fff8902a316b"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5824), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.419", "Vehicle 419", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5825), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, 2 },
                    { 420, new Guid("10f4b2af-d1ae-48b3-bc83-2d75583ef272"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5830), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.420", "Vehicle 420", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5830), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, 2 },
                    { 421, new Guid("032236c2-c149-476f-bfd9-045261d877f2"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5833), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.421", "Vehicle 421", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5834), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, 2 },
                    { 422, new Guid("f4494c92-2cf2-4f1e-a2da-e9c6ec69b51c"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5837), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.422", "Vehicle 422", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5838), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, 2 },
                    { 423, new Guid("e06cebc9-c6b9-497e-8a00-a2bfae3e6a50"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5840), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.423", "Vehicle 423", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5841), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, 2 },
                    { 424, new Guid("be2e6d86-e5d6-4f09-9943-0f94ef678827"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5844), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.424", "Vehicle 424", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5844), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, 2 },
                    { 425, new Guid("56f8204d-9b42-451a-b9eb-2767fe06daf4"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.425", "Vehicle 425", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5848), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, 2 },
                    { 426, new Guid("92863c3b-04eb-4711-8524-4f34d2450809"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5851), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.426", "Vehicle 426", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5851), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, 2 },
                    { 427, new Guid("b6d0d80a-6640-4ce6-b4f3-368e9681b617"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5854), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.427", "Vehicle 427", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5855), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, 2 },
                    { 428, new Guid("84442ad2-3d67-4665-a8a6-b0e1cea5f896"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5859), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.428", "Vehicle 428", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5860), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, 2 },
                    { 429, new Guid("3b813791-7352-4523-917d-3ba834ed9858"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5864), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.429", "Vehicle 429", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5865), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, 2 },
                    { 430, new Guid("251bb67c-2d63-4cf2-b8b5-a1c9b58188d7"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5867), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.430", "Vehicle 430", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5868), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, 2 },
                    { 431, new Guid("99499901-b286-44bc-9cc3-30cb0b4ea1c8"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.431", "Vehicle 431", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5871), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, 2 },
                    { 432, new Guid("78a2a8a2-a2a9-4e48-a399-d0a0fdd49932"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5874), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.432", "Vehicle 432", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5875), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, 2 },
                    { 433, new Guid("0916855e-db45-4029-b375-98b4e96d4da8"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5878), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.433", "Vehicle 433", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5878), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, 2 },
                    { 434, new Guid("99d029d2-a094-4231-8e3c-255799a45fd3"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5881), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.434", "Vehicle 434", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5882), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, 2 },
                    { 435, new Guid("cd17bb83-8672-4e20-aab5-86cdbb99b7d6"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5885), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.435", "Vehicle 435", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5885), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, 2 },
                    { 436, new Guid("1d919b2b-cb75-4d82-a06b-9015affbb26a"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5890), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.436", "Vehicle 436", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5890), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, 2 },
                    { 437, new Guid("7beeb4b3-f150-474d-bb14-1b10d72a910d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5893), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.437", "Vehicle 437", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5894), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, 2 },
                    { 438, new Guid("32e8f814-5aa8-4d8d-905d-5e959be60fb7"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5897), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.438", "Vehicle 438", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5898), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, 2 },
                    { 439, new Guid("5dc7e272-8ff1-4443-b14c-dd6e13e420a8"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5900), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.439", "Vehicle 439", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5901), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, 2 },
                    { 440, new Guid("7a4e45f9-44d4-4e79-b2cb-c59e789aebac"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5904), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.440", "Vehicle 440", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5904), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, 2 },
                    { 441, new Guid("a4d5b1d1-8e36-4b66-b606-b7f6fa1f7064"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5907), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.441", "Vehicle 441", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5908), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, 2 },
                    { 442, new Guid("4049347b-c031-4bef-8cd2-d741082e1856"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5911), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.442", "Vehicle 442", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5911), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, 2 },
                    { 443, new Guid("ced4eff7-57f2-44fe-8439-0a5ec1175ead"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5914), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.443", "Vehicle 443", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5915), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, 2 },
                    { 444, new Guid("d31f801a-f2f8-412c-9d8b-3139439eeb7a"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5958), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.444", "Vehicle 444", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5959), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, 2 },
                    { 445, new Guid("3aca16fe-8eea-4fb3-add0-9e795220ddc1"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.445", "Vehicle 445", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5963), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, 2 },
                    { 446, new Guid("7489e107-53df-4f10-93c3-3f88855e994f"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5966), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.446", "Vehicle 446", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5967), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, 2 },
                    { 447, new Guid("af17a27c-ae3a-4381-b6c4-732d5ba3ead5"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5969), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.447", "Vehicle 447", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5970), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, 2 },
                    { 448, new Guid("2aada4a3-5d84-4590-b8bf-d0793f0000e2"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5973), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.448", "Vehicle 448", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5973), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, 2 },
                    { 449, new Guid("21c3ea8a-0f99-46b9-a2d3-527c0d4171aa"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.449", "Vehicle 449", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5977), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, 2 },
                    { 450, new Guid("4766475b-8ff5-4ebf-b26e-58feec8dbb75"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5980), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.450", "Vehicle 450", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5980), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, 2 },
                    { 451, new Guid("fe170fba-c6df-4b93-8fef-4d94e5d022d7"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5983), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.451", "Vehicle 451", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5984), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, 2 },
                    { 452, new Guid("35048199-22aa-4387-9bfd-058511e02cd0"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5988), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.452", "Vehicle 452", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5989), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, 2 },
                    { 453, new Guid("556fc965-342f-4f0b-b53f-11f1ec2c56b3"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5992), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.453", "Vehicle 453", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5992), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, 2 },
                    { 454, new Guid("dae7ebac-9831-4b55-9e90-7eb4e4791217"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5995), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.454", "Vehicle 454", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5996), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, 2 },
                    { 455, new Guid("03d998ed-aab2-442d-ab33-a94b382b1ed6"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.455", "Vehicle 455", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5999), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, 2 },
                    { 456, new Guid("b7e67eb7-0c54-4a02-995b-683eea1032ca"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6002), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.456", "Vehicle 456", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6003), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, 2 },
                    { 457, new Guid("138bb37a-d6a7-4127-906a-0be08abd6e85"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6005), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.457", "Vehicle 457", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6006), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, 2 },
                    { 458, new Guid("822e67f0-73bb-4038-9a62-6a1b4c1d34ab"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6009), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.458", "Vehicle 458", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6009), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, 2 },
                    { 459, new Guid("5740e612-f921-4775-b0d7-ad4a3d2d51af"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6012), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.459", "Vehicle 459", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6013), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, 2 },
                    { 460, new Guid("e03d103f-3551-4586-b175-94f70e968ed6"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6017), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.460", "Vehicle 460", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6018), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, 2 },
                    { 461, new Guid("fa21f08b-d101-4852-9575-d1b43fd73364"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6021), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.461", "Vehicle 461", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6022), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, 2 },
                    { 462, new Guid("aa1468ff-89eb-4ee8-b618-7431c08fc565"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.462", "Vehicle 462", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6026), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, 2 },
                    { 463, new Guid("012831d9-a980-42f1-bb24-4ad556d22f16"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6029), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.463", "Vehicle 463", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6029), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, 2 },
                    { 464, new Guid("f795fc42-677e-458d-b10e-4ba3f1b9424d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6032), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.464", "Vehicle 464", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6033), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, 2 },
                    { 465, new Guid("b30b7982-6427-4ce0-8fc8-c046add62967"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6036), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.465", "Vehicle 465", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6036), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, 2 },
                    { 466, new Guid("724f8f0c-3086-4d10-9b55-9a64456c74b4"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6039), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.466", "Vehicle 466", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6040), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, 2 },
                    { 467, new Guid("fe877249-4286-48f3-b87e-d2d630c12e8f"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6042), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.467", "Vehicle 467", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6043), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, 2 },
                    { 468, new Guid("fbddd660-724f-4ace-aba6-50d696cc59d0"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6048), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.468", "Vehicle 468", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6048), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, 2 },
                    { 469, new Guid("b850d880-2c2d-40bf-8bf5-ebcc9cdfbeab"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6051), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.469", "Vehicle 469", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6052), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, 2 },
                    { 470, new Guid("de93b0d6-d944-4541-b9d3-47e49a269b5e"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6055), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.470", "Vehicle 470", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6055), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, 2 },
                    { 471, new Guid("f5d1685b-f634-4137-80cd-5c5b68aa07ef"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6058), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.471", "Vehicle 471", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6059), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, 2 },
                    { 472, new Guid("617cf787-68d7-437a-b21a-3cd9d4b76d2b"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6061), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.472", "Vehicle 472", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6062), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, 2 },
                    { 473, new Guid("79202a5c-7a50-4919-a54c-1c52972ffa6f"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6065), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.473", "Vehicle 473", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6065), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, 2 },
                    { 474, new Guid("63c0e928-9524-4023-bc54-e51213e7e7a1"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6094), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.474", "Vehicle 474", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6095), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, 2 },
                    { 475, new Guid("c161c28f-a57c-44fe-b7df-3f14093c8376"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6098), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.475", "Vehicle 475", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6099), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, 2 },
                    { 476, new Guid("99d0ce21-dff6-4b9e-ae55-5e5b25b851e3"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6103), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.476", "Vehicle 476", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6104), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, 2 },
                    { 477, new Guid("ff3fa4c5-6b1d-4fe6-bf29-47f90815cf2b"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6107), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.477", "Vehicle 477", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6107), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, 2 },
                    { 478, new Guid("ce24bb3e-3e02-4f5b-ad4e-c19b228a3be8"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6110), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.478", "Vehicle 478", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6111), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, 2 },
                    { 479, new Guid("9239d9ee-f1a5-42fd-b0f3-bebda9af5af8"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6113), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.479", "Vehicle 479", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6114), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, 2 },
                    { 480, new Guid("525cdd11-502b-4ad3-bbca-adaa23334355"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6117), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.480", "Vehicle 480", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6117), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, 2 },
                    { 481, new Guid("1ebca263-b9ff-4439-94a6-f558d7638222"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6120), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.481", "Vehicle 481", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6121), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, 2 },
                    { 482, new Guid("d03c8173-dbec-404a-ba39-24a1ba182d2d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6124), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.482", "Vehicle 482", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6124), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, 2 },
                    { 483, new Guid("6d12a93f-dfd7-4629-a9ae-b1cab9267831"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6127), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.483", "Vehicle 483", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6128), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, 2 },
                    { 484, new Guid("0cacfe58-9442-496e-aca6-6b21671b0dae"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6132), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.484", "Vehicle 484", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6133), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, 2 },
                    { 485, new Guid("711e3d8e-1b4f-448f-914c-b954e7132372"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6136), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.485", "Vehicle 485", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6136), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, 2 },
                    { 486, new Guid("4b42e195-7b28-45ae-acb6-f81ffa54df5d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6139), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.486", "Vehicle 486", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6140), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, 2 },
                    { 487, new Guid("f29edb8f-e333-4c7c-8056-561043303846"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6142), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.487", "Vehicle 487", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6143), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, 2 },
                    { 488, new Guid("cfba2687-c0fd-4c42-8d41-acef9f8971b5"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6146), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.488", "Vehicle 488", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6146), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, 2 },
                    { 489, new Guid("33a684d9-4210-4ce8-8063-77bca21318aa"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6149), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.489", "Vehicle 489", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6150), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, 2 },
                    { 490, new Guid("5e53fb7f-6206-4a06-bfd9-549565a13c10"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6153), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.490", "Vehicle 490", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6153), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, 2 },
                    { 491, new Guid("05e5b0e0-f9d4-47b5-89a3-b9ccacd2ef10"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6156), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.491", "Vehicle 491", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6157), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, 2 },
                    { 492, new Guid("013fc859-e23e-4149-8473-8b1ee58390fa"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6161), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.492", "Vehicle 492", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6162), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, 2 },
                    { 493, new Guid("f15def4e-9c40-4f55-b898-0ad7a409ab10"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6165), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.493", "Vehicle 493", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6165), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, 2 },
                    { 494, new Guid("3f9b43cf-2543-4842-ba9e-b2edec6075a9"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6168), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.494", "Vehicle 494", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6169), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, 2 },
                    { 495, new Guid("2a1d045c-3fbc-4f2c-9bfe-0725126cc94d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6172), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.495", "Vehicle 495", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6172), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, 2 },
                    { 496, new Guid("159d6b83-42c6-4805-8870-63304e7c02a0"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6175), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.496", "Vehicle 496", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6176), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, 2 },
                    { 497, new Guid("12ae8766-3389-4afe-8998-e0c2acac21b8"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6178), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.497", "Vehicle 497", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6179), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, 2 },
                    { 498, new Guid("40e6a5ee-a652-4867-aabe-d9a88fc07698"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6182), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.498", "Vehicle 498", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6183), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, 2 },
                    { 499, new Guid("248f880d-fa4e-4d48-9e0e-6e3c0e7ee13d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6185), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.499", "Vehicle 499", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6186), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, 2 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(677), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(689), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(689), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(698), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(698), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(705), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(706), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(713), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(714), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(722), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(723), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(730), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(731), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(738), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(738), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(745), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(746), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(754), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(754), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(761), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(762), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(769), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(814), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(815), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(824), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(824), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(832), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(833), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(840), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(840), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(848), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(857), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(857), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "ceiling_extra_price", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5556), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5557), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5598), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5598), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5605), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5605), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5612), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5612), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5620), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5620), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5628), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5628), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5635), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5642), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5642), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5649), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5649), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5657), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5657), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5664), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5671), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5671), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5678), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5679), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4807), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4808), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(4905), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5021), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5022), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5045), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5046), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5064), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5065), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5079), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5080), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5094), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5094), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

            migrationBuilder.InsertData(
                table: "user_licenses",
                columns: new[] { "id", "back_side_file_id", "code", "created_at", "created_by", "deleted_at", "front_side_file_id", "license_type_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 15, "f15f351c-0a28-4f5b-bd1c-b88ded109fba", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6745), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 14, 1, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6746), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 17, "943ca938-1683-4527-882c-ee844d72d5d9", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 16, 2, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6763), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, 19, "dd93fe49-4ec2-4623-bc99-487d3bee6975", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6805), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 18, 3, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6806), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, new Guid("20542ed4-78ce-4ad3-b0c9-2ccca94ea46f"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5706), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5707), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("3336b694-6cfc-45ef-ba06-9b2de455a4dd"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5711), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5712), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("54c69db1-2e67-46cb-b4e0-cb9ccaff728d"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5713), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5714), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("36c1c3ce-0c2c-4d81-a526-ebd5f51a7f24"), new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5716), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(5716), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "type", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 0.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6292), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6293), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 0.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6297), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6297), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 0.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6299), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6299), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 0.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6300), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6301), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 0.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6302), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 0.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6305), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6305), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 0.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6306), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6307), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 0.0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6308), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 18, 11, 38, 26, 562, DateTimeKind.Unspecified).AddTicks(6308), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
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
                unique: true);

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
