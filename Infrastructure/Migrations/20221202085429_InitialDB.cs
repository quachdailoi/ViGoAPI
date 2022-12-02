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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("23080ffb-6772-4213-a759-e6bbb6615c28")),
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 34, DateTimeKind.Unspecified).AddTicks(6588), new TimeSpan(0, 7, 0, 0, 0))),
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("3d23689e-2f6b-49b6-b4b0-bedae71f0539")),
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
                    { 1, new Guid("44a9cebf-875a-4f3e-a203-770056e32b6b"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(392), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(392), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("04e019b2-21d1-4633-89da-eccfb10b1fbf"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(398), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(399), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("f89bbd9a-f8bc-4595-80ac-9758d1cd3f6d"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(396), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 1, new Guid("435e09e3-2185-4e55-86c8-6f96e9093c59"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1058), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1076), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("96ca5d85-2478-460f-a4a9-0f0fb9364832"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1090), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1090), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("20690bc5-26d7-4ff4-a775-4d54122beb3e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1109), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1110), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("e7692f26-8668-45f6-a190-f870e0dd7ee2"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1118), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1119), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("a876ca00-ce40-4a98-9163-9479fb01548a"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1127), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1128), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("9a8dfb55-6a08-492e-bc31-5ce2b1ee01d3"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1138), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1139), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("2d8080b1-aa3d-4f0b-9b24-2adc439d2ef9"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1146), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1147), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("d7313e2f-6ed4-4602-8819-f06f64763b98"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1154), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1155), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("f61989d2-9f09-4452-8edc-9390a09cf605"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1163), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1164), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("4ef22bef-952d-4027-83ce-d2082e10ecec"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1174), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("07c956e1-56a2-459f-9437-f0636e538b88"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1184), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1185), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("556a79ac-2eac-440b-ac76-9e0eb4c5aca5"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1192), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 3, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1193), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("3fe45374-308c-4901-92c2-5e03ca232e06"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1237), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1237), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, new Guid("7ae0d5d1-52d2-43a3-a009-7bd1d4ef59c1"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1246), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 4, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1247), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, new Guid("d16a123c-3731-4f23-8fd2-14b56d6cced5"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1254), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 5, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1255), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, new Guid("05af72b7-cba1-4c50-9d18-21561dd884b5"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1263), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 6, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1263), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, new Guid("6f8040fd-b4a5-4ec7-980c-a990c01a4497"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1271), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 7, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1272), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, new Guid("a9cdf5ec-f647-4aec-a0b8-e42b87111317"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1281), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 8, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1282), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, new Guid("5c9f9699-6eeb-4c0c-8227-9b959a7bffa1"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1292), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 9, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1292), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "license_types",
                columns: new[] { "id", "code", "name" },
                values: new object[,]
                {
                    { 1, new Guid("0abf9bec-0fd5-4f6d-adee-c8634feb77f9"), "Identification" },
                    { 2, new Guid("8bb1db6e-7d4c-4ac6-9584-8058ab3408ef"), "Driver License" },
                    { 3, new Guid("59273a3d-7da1-42f0-8b0c-82940e403827"), "Vehicle Registration Certificate" }
                });

            migrationBuilder.InsertData(
                table: "pricings",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "discount", "lower_bound", "updated_at", "updated_by", "upper_bound" },
                values: new object[,]
                {
                    { 1, new Guid("5582b4f2-1d4b-42e0-bf71-e24fd3907ac3"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(504), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.0, null, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(504), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 2, new Guid("606cc2d7-9c9f-4b66-af22-65c71b88effe"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(536), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.029999999999999999, 8, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(537), new TimeSpan(0, 7, 0, 0, 0)), 0, 30 },
                    { 3, new Guid("8713af86-9e00-434b-a9ea-9bc4fbf3bd83"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(539), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.050000000000000003, 31, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(540), new TimeSpan(0, 7, 0, 0, 0)), 0, 90 },
                    { 4, new Guid("11892de0-1685-4e41-b96b-66284f5a5d0a"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(541), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.070000000000000007, 91, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(542), new TimeSpan(0, 7, 0, 0, 0)), 0, null }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8851), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8851), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8859), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8859), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8866), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8867), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("0bfe3836-f0b6-4a89-935d-0a99a49be92b"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9195), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9195), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d03defec-49cd-4ac3-a78f-86d6ad81c847"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9200), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9201), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ffaaacd8-f833-4e3b-a2b0-cd721a718ca3"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9203), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9203), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("27a58465-85f4-4dc9-a5bf-4c3567af314a"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9205), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9206), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e527c5a2-0689-400a-808c-d9ff73d8d583"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9208), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9208), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a1223fb5-3557-4b8a-b184-ee25b99bf651"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9211), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9212), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e860683b-f9bc-4e9a-9529-34dd179ecea4"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9213), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9214), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7d084e6d-113f-4371-9012-c5beb537706c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9219), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9220), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("56b765d0-867a-455d-ae84-ef5a8858a11c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9221), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9222), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("b4521b81-9cb9-406d-beae-bdaeabf45163"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9225), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9225), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dcc238fb-81c0-4f8b-be4a-c03c50d11a30"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9227), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9228), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7706ec2d-378c-46cf-bfab-497550dfa101"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9229), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9230), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("55d3032d-7beb-47c8-ba05-158e7a7f5e46"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9232), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9232), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("91591843-f12b-4448-9922-41c1f87d0fa1"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9234), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9234), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a9e6da6a-881b-480b-84c3-106166f0512d"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9236), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9237), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7b20702e-954b-457a-8920-13c8050dc646"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9240), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9240), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1f3fed7f-6f06-4a13-a399-27b2c34f4461"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9242), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9243), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d20e031f-6a46-4730-a0fa-261b81d5a761"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9245), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9246), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("28b3ac6b-d9d9-4ce6-9374-f1a51abdf19c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9249), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9250), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("28f90e1c-e3b6-442c-9c79-afedd614bb89"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9252), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9252), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("229c8413-a559-43ce-93ad-3cf208fd4b25"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9255), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9255), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d54d3bec-adbe-437b-8301-4b5bc7f9336f"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9257), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("40b10400-3db3-4c6f-8061-e36adbc348cf"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9305), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9305), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5d851928-6ecb-43bc-b409-ac464c59f43c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9307), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9308), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("978a0e0b-a051-4065-a72e-f9b9724dfcf9"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9309), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9310), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("820b8e93-7f97-4da9-a5e6-a9435ec69a31"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9312), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9312), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("42041f5d-7c77-42f4-95c8-33204eb0a353"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9314), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9315), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bfc5cc74-fd8e-4487-96d7-ad22d12e4bb4"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9316), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9317), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a6e4b937-5c84-43b6-812a-cd087fc53c03"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9318), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9319), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fb0a8732-3e1f-47ad-8b19-6d618f3da8cf"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9321), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("96675e61-0efb-4ef3-838d-f7dad5e2336c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9324), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9325), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("de5edde9-a4ab-4652-8997-1744299b7819"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9327), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9327), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6bd3a2d3-bb9c-48d8-9fd2-dda7bcdba919"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9330), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9331), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bfcd9146-2583-4733-8b4e-863d77c6fc85"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9332), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9333), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4f5d681b-1e78-45e4-8a0c-b9f101046339"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9335), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9335), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("91fb8fa3-c03e-439a-b2c5-29cf6c249060"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9337), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9337), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hòa, Dĩ An, Bình Dương", new Guid("67d4c19a-98ac-4737-9b6e-7fc98ec953c3"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9339), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9339), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("990c7550-57a2-42ba-8c60-9941b6547fb0"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9341), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9342), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("73b89c6a-1cab-49b7-a2e5-cb243f0c05c2"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9345), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e6221f3d-6b6a-46e5-82a7-73276229ef96"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9347), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9348), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("be5774be-e68e-480a-95ca-785efc693f3a"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9349), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9350), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3d80b445-1a3f-4d93-afa8-43a1be6c5f35"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9352), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9352), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("6b4ac050-c588-46de-a31c-182294335232"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9355), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("1b5ba592-15b8-4277-b8aa-8f1b3b8bdbee"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9357), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9358), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c60c015b-3427-4108-9223-d2b3f5a3f7ec"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9359), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9360), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("327a571b-14f2-4b7e-9151-e01a930df7d8"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9362), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9362), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("58dd1d31-951c-4d86-b8cf-c32e4213f6bd"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9365), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9366), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d25e9e66-7d26-4552-8bd3-bafc243c9e99"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9368), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("44a9f6e6-550c-4155-91e5-d37cfe38ba18"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9370), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9371), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("01d30f32-11c7-4dfe-811c-7ced3215a44e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9372), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9373), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a2bb5f3f-60b0-4e2b-99d6-481fe9d94591"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9375), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9375), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cb56a32c-c6dc-40ac-9246-1c12c4089bf8"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9377), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9377), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("25398867-7ce7-4f4b-83cd-fa70b1d1559e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9379), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9380), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8b3ec0d7-2d59-44cb-8203-22bf6a66068c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9381), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9382), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fd7e1970-95ef-4f3b-98fe-2f2f2a6e383b"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9385), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9386), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6dbb0768-2f21-4951-bad3-c7b41fef66c0"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9387), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9388), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1a5000ff-532d-4140-af1e-26a319194e99"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9390), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9390), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("afb1570d-50dd-440b-8236-aeb735ae6e89"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9392), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9392), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("726e7d68-88e8-4edc-8ed3-4562cab5d26a"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9394), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9394), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("81b903d5-3140-4e3b-852a-56f5d157b6eb"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9397), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("61ddf56d-ec5a-4bf3-a958-3a1384586a79"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9398), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9399), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f148b35f-e061-4dcf-991a-b6e009f5d66d"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9400), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9401), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("59dea239-c057-4bd3-a136-0e935e1c432c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9469), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("af54b6c7-bd6b-45f8-88c6-d78dec2bf6f1"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9471), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9472), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7b397289-b7dc-4336-98d5-ef949417da2b"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9475), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9475), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4599213d-c2fb-4bd6-9ee4-1406654c076b"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9477), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9478), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("675bfc6a-71b6-498b-b816-a772384b9fb5"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9480), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e4d2b3fb-b792-471c-b95c-ff2a4ac1533e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9482), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("59f502e6-d476-4d47-8d9a-a06775434417"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9484), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9484), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d398b7ea-3b07-4c75-b30a-01b510c551cb"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1f1eacbc-250f-4d66-b07c-8493e35e9e76"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9490), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9490), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b26cb4ab-2831-4e50-a33e-4e421d37359e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9492), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9493), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c81e757d-76b6-4e96-a924-9812fdd30150"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9494), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9495), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f46fb4ff-0893-42da-a932-e59f2e376b6d"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9496), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9497), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fdcac7bd-3011-49d5-942a-1ffef86091a3"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9499), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9499), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("cd554ec8-0856-4312-94cd-9cd15d2ddb7d"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9501), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9501), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("606cf98b-7fc1-433e-8de9-ae8440dadd43"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9503), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9503), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0dc873fe-b6a9-4e1f-b799-94ef73220318"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9505), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9505), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, An Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("28de879b-a583-4104-a7c4-d84a3b7de791"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9509), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9509), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("4394a98d-9714-47c6-a6aa-378d9a5a3fb6"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9511), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9511), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("165b3c03-1ed9-4acd-a564-ead1b29daba6"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9513), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9514), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("c48e9ecc-56e0-4f36-b705-e3b0faf886c9"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9515), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9516), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("112355d8-3df1-496e-bf20-a5694c8012aa"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9518), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("28e045bd-e108-47ee-9ddd-49dc377fc7c7"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9520), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9520), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d50eccfb-0793-4021-abe0-26a6a7befc2e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9299), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9300), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô K1-G3 Đường D1, Phường Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("dd4c3474-5862-465b-a156-32418705b643"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9522), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9522), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trip_rate", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "rating", "status", "suddenly_cancelled_trips", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 10, 0.0, new Guid("b4d37d69-1b47-43f9-ba7f-8f1fe9ed795e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1482), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1484), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Admin Than Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1483), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 0.0, new Guid("b3096087-13d9-449e-acf5-428f00b1dce9"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1494), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1495), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Admin Nguyen Dang Khoa", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1494), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 0.0, new Guid("a9169cee-f8e0-499c-809d-948679962c5d"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1505), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1509), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Admin Do Trong Dat", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1506), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 100, 0.0, new Guid("d44a9bd8-f367-42cc-ae47-f57ae35b56dd"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1519), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1537), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 100", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1520), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 101, 0.0, new Guid("b838f9eb-eea8-467a-9bfd-3a2d8e6a0803"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1549), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1552), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 101", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1550), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 102, 0.0, new Guid("c629ef1e-0ba2-4024-b715-3e62aa0c566b"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1562), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1564), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 102", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1562), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 103, 0.0, new Guid("0a0bbf49-9aac-41f4-bb9a-246d568b09ed"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1575), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1580), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 103", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1576), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 104, 0.0, new Guid("2ff37da5-dd9a-4ee1-b82b-df64e050d3b6"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1590), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1593), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 104", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1591), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 105, 0.0, new Guid("e83cdd22-6906-4e83-bc19-8a9bbdbdc439"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1652), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1655), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 105", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1652), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 106, 0.0, new Guid("9bfd431a-9c81-4681-b18d-63d999dd9a3a"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1669), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1672), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 106", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1669), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 107, 0.0, new Guid("844f8fd9-efa7-40a4-8669-1beafd2e08dc"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1682), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1689), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 107", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1683), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 108, 0.0, new Guid("be08547e-7e33-4624-83b7-d0c2e9143878"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1707), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1711), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 108", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1708), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 109, 0.0, new Guid("81bed84a-c165-4e84-8c2d-b7046289de9e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1728), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1733), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 109", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1729), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 110, 0.0, new Guid("06d6ffd8-dd81-4c00-b2be-46c1d56235df"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1749), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1754), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 110", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1750), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 111, 0.0, new Guid("74653748-e5dc-4c66-a1e2-e78b142b865c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1770), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1777), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 111", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1771), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 112, 0.0, new Guid("d2fae981-0b72-428e-983a-5523900214e8"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1794), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1799), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 112", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1795), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 113, 0.0, new Guid("a9d0750f-022c-4ec8-b72c-8180262b2a0e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1819), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1823), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 113", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1820), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 114, 0.0, new Guid("3cbe3463-204e-4055-a375-004a5830568a"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1838), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1843), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 114", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1839), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 115, 0.0, new Guid("deff6692-04e9-45cc-bdbd-e19e6f6bbe60"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1861), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1868), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 115", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1862), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 116, 0.0, new Guid("ec479a21-7244-49e0-84e1-a412f0972a67"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1926), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1931), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 116", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1928), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 117, 0.0, new Guid("10f99f80-569a-47e0-9957-b66a8487705e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1950), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1954), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 117", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1951), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 118, 0.0, new Guid("39e1b270-f7fb-449f-bb6f-44668e0814ad"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1972), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1977), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 118", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1973), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 119, 0.0, new Guid("cf915514-6ac3-48d4-b3df-5a7a87740693"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1993), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2001), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 119", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1994), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 120, 0.0, new Guid("3d64bb8e-6f69-47b1-aa55-73bbe2f4f939"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2018), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2023), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 120", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2020), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 121, 0.0, new Guid("9642ff83-53b7-4d3d-ab87-1e235e2e64c1"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2044), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2048), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 121", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2045), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 122, 0.0, new Guid("eb907b7f-fa38-4aac-96c2-46f5f9be0c8c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2065), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2069), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 122", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2066), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 123, 0.0, new Guid("c49c620e-a174-43ce-a3a2-485058d2004a"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2085), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2093), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 123", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2086), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 124, 0.0, new Guid("f76c38cb-951a-43f2-a154-909bcd1860b3"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2110), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2115), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 124", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2112), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 125, 0.0, new Guid("6b008c59-12a6-4769-83ab-ef6e699c3cbf"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2130), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2133), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 125", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2131), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 126, 0.0, new Guid("a26f3637-06ae-4f96-9060-f84a69573351"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2177), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2180), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 126", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2178), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 127, 0.0, new Guid("f60eb1d5-56c8-4ff2-b2d5-3324194e7046"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2192), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2197), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 127", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2192), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 128, 0.0, new Guid("843d8de5-d5aa-40b8-a2a2-c934ca3266bc"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2207), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2209), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 128", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2207), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 129, 0.0, new Guid("188e2c51-143b-4317-ac34-1f2f16730a24"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2219), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2222), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 129", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2220), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 130, 0.0, new Guid("dd54a97c-6bc5-418c-8b7f-9302d9081ae9"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2232), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2234), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 130", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2232), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 131, 0.0, new Guid("8cb003a8-6d36-4fad-b5b9-7af9c701d907"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2245), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2249), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 131", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2245), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 132, 0.0, new Guid("2d68ff7b-3a72-4d6e-a238-b729b6f6e6a3"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2259), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2261), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 132", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2259), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 133, 0.0, new Guid("1e6112b4-58f1-4ef5-9bfa-17731dca7e3c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2271), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2274), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 133", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2272), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 134, 0.0, new Guid("b445d533-a81d-4bc9-be35-1b75d37ec485"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2284), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2286), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 134", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2284), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 135, 0.0, new Guid("08d69f50-e1cf-4714-a8a5-3086e192ea21"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2296), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2300), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 135", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2297), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 136, 0.0, new Guid("a79464db-3141-4c45-9960-ea4f76eae825"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2339), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2342), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 136", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2339), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 137, 0.0, new Guid("2b59bf9c-d4a3-47cd-bf04-a798ab86d75b"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2354), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2357), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 137", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2355), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 138, 0.0, new Guid("e7507eeb-1f34-4feb-8285-1600be99609a"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2367), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2370), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 138", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2368), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 139, 0.0, new Guid("796aea95-06a5-443b-a186-ba6557615377"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2380), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2384), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 139", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2381), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 140, 0.0, new Guid("f6b77e5d-7ea0-48dd-a7da-766263f917a0"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2395), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2397), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 140", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2395), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 141, 0.0, new Guid("1c19e943-8715-4246-9eac-15400531255a"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2407), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2410), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 141", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2408), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 142, 0.0, new Guid("73fe5d1f-860d-495c-9fe4-66aa965f4eb8"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2420), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2422), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 142", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2420), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 143, 0.0, new Guid("77ecdc96-f2d8-416f-b6db-f734abd520c5"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2432), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2437), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 143", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2433), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 144, 0.0, new Guid("194cd52f-66e3-4adc-81aa-adbabc6fe34e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2447), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2449), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 144", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2447), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 145, 0.0, new Guid("9e4a2c15-877c-4d37-9bfe-bba38585cb19"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2460), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2462), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 145", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2460), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 146, 0.0, new Guid("6b81f199-5055-41de-8b42-fb5c60be49ae"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2476), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2479), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 146", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2477), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 147, 0.0, new Guid("3e0debd9-6c51-4335-87e7-eeb9a51656c8"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2517), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2522), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 147", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2517), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 148, 0.0, new Guid("587b57d2-55de-4aeb-86a7-ef087c4137b0"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2533), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2536), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 148", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2534), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 149, 0.0, new Guid("b0031a50-9816-4a7e-91d7-dfdbd6c94e56"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2546), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2549), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 149", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2546), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 150, 0.0, new Guid("ef529f3a-699c-462d-89cc-e9a8d8fd6f99"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2559), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2561), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 150", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2559), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 151, 0.0, new Guid("51eeec6b-a005-4709-8ae2-4f71d52880ee"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2571), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2575), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 151", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2572), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 152, 0.0, new Guid("9e8b0c98-c378-4d06-b17a-9e6f72164841"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2585), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2588), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 152", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2586), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 153, 0.0, new Guid("f01d230d-fc8c-4106-bad9-fb3c7fd1223b"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2600), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2603), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 153", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2601), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 154, 0.0, new Guid("3024c3e3-29fb-4269-bcf9-2af927433e91"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2613), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2615), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 154", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2614), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 155, 0.0, new Guid("3d3115f7-13be-4f8a-81a5-e06a6e92e0c6"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2626), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2630), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 155", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2626), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 156, 0.0, new Guid("bef0b45f-d0ad-4ebc-b752-ff3717520fb9"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2641), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2672), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 156", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2641), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 157, 0.0, new Guid("50f8f052-510f-4483-a933-c71305ec79ac"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2685), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2688), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 157", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2686), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 158, 0.0, new Guid("460b39a4-7064-4176-9e41-1d5161e9b510"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2698), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2701), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 158", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2699), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 159, 0.0, new Guid("4221adeb-6408-484c-b17c-9f73a3bcd793"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2711), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2715), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 159", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2711), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 160, 0.0, new Guid("2a348c61-0574-4f21-bb42-cefa727835f4"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2725), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2728), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 160", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2725), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 161, 0.0, new Guid("1b745103-79f2-4843-8295-68e99d17b4e7"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2737), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2740), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 161", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2738), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 162, 0.0, new Guid("f1a23a4a-56bf-47a9-8d93-4537dcfc69f8"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2749), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2752), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 162", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2750), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 163, 0.0, new Guid("7cc85510-b17c-4932-84a5-8bc26f0c589e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2762), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2766), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 163", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2762), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 164, 0.0, new Guid("51055339-a7c1-4915-8b6a-68c7cbbf1495"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2776), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2779), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 164", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2777), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 165, 0.0, new Guid("9897a3a3-1df8-4da4-924c-bc70b7399836"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2789), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2791), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 165", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2789), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 166, 0.0, new Guid("df1f46b3-e2d4-4523-b58f-96e4d99e2bc3"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2801), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2804), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 166", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2802), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 167, 0.0, new Guid("6605537f-743c-4d68-9cfe-6c4219559381"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2842), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2847), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 167", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2842), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 168, 0.0, new Guid("2217ad8f-a757-4262-a702-3e88f3f58d0b"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2859), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2862), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 168", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2859), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 169, 0.0, new Guid("05153fc2-01c3-4853-bb58-562830cc94c7"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2873), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2875), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 169", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2873), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 170, 0.0, new Guid("726d16b1-82f0-48e1-b306-4268266317b1"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2885), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2888), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 170", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2886), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 171, 0.0, new Guid("38f821cc-f6ce-431d-a5a7-569cfcf79c32"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2898), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2902), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 171", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2898), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 172, 0.0, new Guid("583f175f-93bd-4df0-a502-b4516ad6cd14"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2912), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2915), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 172", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2913), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 173, 0.0, new Guid("90da9163-5f5c-45ff-ba74-374fe3d849ef"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2925), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2927), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 173", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2925), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 174, 0.0, new Guid("813429c2-6f7a-4721-b881-8312bee8c864"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2937), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2940), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 174", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2938), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 175, 0.0, new Guid("238ade16-15c6-4f86-9c33-29281471a9de"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2950), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2954), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 175", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2950), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 176, 0.0, new Guid("a8df4b08-6308-434f-b5d5-de76f50e4dba"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2964), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2967), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 176", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2965), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 177, 0.0, new Guid("0be642b7-fb59-4467-bc91-28f6503cca54"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2976), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2979), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 177", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(2977), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 178, 0.0, new Guid("f69dc315-a11e-4981-8857-afac5ab4a8a4"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3032), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3035), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 178", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3033), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 179, 0.0, new Guid("f9d70fb4-c9ae-4a58-9315-db82d1f974ee"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3048), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3052), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 179", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3048), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 180, 0.0, new Guid("b00f42a9-8af5-40f8-89b0-6a93b7ef2ec9"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3063), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3066), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 180", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3064), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 181, 0.0, new Guid("43dbf918-f86a-4059-a967-7a6134ad7c4e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3076), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3078), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 181", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3076), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 182, 0.0, new Guid("f09bcd0f-cab2-48ed-9b2e-a02590f05e4c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3088), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3091), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 182", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3089), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 183, 0.0, new Guid("46c40e9b-b094-4d5d-92c6-af30dbeac820"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3102), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3106), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 183", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3102), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 184, 0.0, new Guid("92d275c0-981c-464d-afef-583b791524b5"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3116), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3119), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 184", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3117), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 185, 0.0, new Guid("f1897438-01b0-445b-8e44-90785e65ecb1"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3129), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3131), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 185", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3129), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 186, 0.0, new Guid("46c2c7b0-7d20-424d-bf3d-eac1dedfdb89"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3141), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3144), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 186", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3142), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 187, 0.0, new Guid("9927beef-09b3-4237-a36a-7f8b12a04fab"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3153), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3157), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 187", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3154), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 188, 0.0, new Guid("dc29848f-739c-4145-8cd5-d52b55962ed5"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3168), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3170), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 188", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3168), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 189, 0.0, new Guid("24b01013-0d68-421a-9e50-2127ceed58c6"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3223), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3226), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 189", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3224), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 190, 0.0, new Guid("bab3e16b-88be-4db9-b86e-0267a65c7478"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3239), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3242), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 190", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3240), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 191, 0.0, new Guid("84b79f14-5c47-4e86-8d2d-4be54996f19c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3252), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3257), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 191", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3253), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 192, 0.0, new Guid("7fab6c9b-790f-4871-ad17-b13b31520eef"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3267), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3270), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 192", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3268), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 193, 0.0, new Guid("88db2f72-1bc5-484d-b423-150747a5e1a9"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3279), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3282), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 193", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3280), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 194, 0.0, new Guid("3acb3494-e483-4523-b099-346d3b46ef8c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3292), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3295), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 194", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3293), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 195, 0.0, new Guid("f12dfa4b-5688-4025-8b03-f3124112a8d4"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3305), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3309), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 195", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3305), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 196, 0.0, new Guid("cd882892-7ab9-4649-9820-6a7acafc2824"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3319), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3322), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 196", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3320), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 197, 0.0, new Guid("281c9f26-8d66-4492-b1eb-ef0f84e88fe0"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3332), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3334), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 197", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3332), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 198, 0.0, new Guid("49007965-7db7-4375-b386-8e6932818c7a"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3344), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3346), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 198", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3344), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 199, 0.0, new Guid("8fee3340-1530-4e31-a14c-e6f7aa4d62b8"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3356), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3394), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, 1, "Booker 199", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3357), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 400, 0.0, new Guid("215e7ed9-9a65-44a4-b00f-3a74acd8dad1"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3409), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 400", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3409), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 401, 0.0, new Guid("22f9439f-ef0e-4627-97f8-446a7e1862ce"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 401", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3424), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 402, 0.0, new Guid("e0a58a3d-cd5d-4172-9809-ef2d6b66f3db"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3436), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 402", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3437), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 403, 0.0, new Guid("dcf591f7-2943-4caa-bbdf-611af97a2ff3"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3448), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 403", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3448), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 404, 0.0, new Guid("cc82100d-5cd2-43f4-8e8f-250ecbf8a7e6"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3462), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 404", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3462), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 405, 0.0, new Guid("50a2548d-a11c-49fd-9df6-7f05555dcc0d"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3473), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 405", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3474), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 406, 0.0, new Guid("5f92027d-f466-476f-b638-63aad560099e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3484), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 406", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3485), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 407, 0.0, new Guid("720f13ee-3c31-4555-bd59-bb6e2ca28be8"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3496), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 407", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3496), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 408, 0.0, new Guid("eb2a7e2f-e130-479d-8504-699e06b34db3"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 408", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3511), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 409, 0.0, new Guid("eb29f54a-b5ff-4ec1-9711-19998c7c3829"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3522), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 409", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3522), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 410, 0.0, new Guid("a4ef273b-88dc-4eb0-8a49-660d25a8ac5d"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3575), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 410", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3576), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 411, 0.0, new Guid("ede601ee-4a12-472e-8413-69bdea5dbe39"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3592), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 411", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3592), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 412, 0.0, new Guid("e3086f67-6c64-4250-80ae-ececb499ce7c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3606), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 412", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3606), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 413, 0.0, new Guid("7b6b05c7-2cce-4030-8af1-e64f88075741"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3618), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 413", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3618), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 414, 0.0, new Guid("11aa9522-0f86-44af-b26e-cea833a94b4e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3629), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 414", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3630), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 415, 0.0, new Guid("3413eea3-df8e-490c-aa21-eac72a91e68f"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3641), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 415", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3641), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 416, 0.0, new Guid("30ebecd3-1f4e-48b9-a291-ef36c71f790e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3654), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 416", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3655), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 417, 0.0, new Guid("dcbc9f34-b9a3-4f54-a4f5-a36173c57aa6"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3669), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 417", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3670), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 418, 0.0, new Guid("d17f7b5c-385c-4e76-8240-c963883e35a5"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3709), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 418", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3710), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 419, 0.0, new Guid("4d04aca5-beb3-4ae1-9f49-890f9b1a66b8"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3723), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 419", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3724), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 420, 0.0, new Guid("8ad08970-3eb4-471d-b969-6bd998a8b5e7"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3737), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 420", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3738), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 421, 0.0, new Guid("bbbcc918-bd3c-4e0c-9e3b-b3e70ef04b2e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3749), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 421", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3750), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 422, 0.0, new Guid("91876f9a-8743-4283-87bb-7865619a83ff"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3760), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 422", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3761), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 423, 0.0, new Guid("7b71636b-2027-441a-bddb-6d5933d76e02"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3772), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 423", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3773), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 424, 0.0, new Guid("ceb9148f-e3ab-4a3e-9f67-92879faae32b"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3785), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 424", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3786), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 425, 0.0, new Guid("d58b5150-0c35-4ebe-bb0f-8ed013d8834a"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3797), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 425", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3798), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 426, 0.0, new Guid("6fd9a82a-5f61-4dc5-9181-1d3bcb6d629e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3809), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 426", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3810), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 427, 0.0, new Guid("e42d136d-69f4-49bc-8fcf-b0397d580246"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3820), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 427", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3821), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 428, 0.0, new Guid("e9280aa5-6c74-429a-842f-4ed32385351d"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3834), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 428", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3835), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 429, 0.0, new Guid("467eae9d-3bef-48db-835b-d0ef9a0e5809"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3873), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 429", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3874), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 430, 0.0, new Guid("58631b66-85f7-44e2-a258-e4a62f5a91a6"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3886), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 430", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3887), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 431, 0.0, new Guid("32b64183-fee1-4ec0-8d82-c9ee09d03810"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3898), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 431", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3898), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 432, 0.0, new Guid("c9116f14-941f-418d-bfbe-33f244c034ba"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3913), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 432", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3913), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 433, 0.0, new Guid("3231240a-252e-4903-b5d2-c7076466eca8"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3924), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 433", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3925), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 434, 0.0, new Guid("e16dd277-f7e6-43e4-8c45-5fcd148c92cd"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3936), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 434", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3937), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 435, 0.0, new Guid("20111e1d-9689-40a6-bc37-9c9134f6f1d3"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3947), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 435", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3948), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 436, 0.0, new Guid("cc21c4b7-77b7-452a-8efe-646f3c30ece0"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 436", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3962), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 437, 0.0, new Guid("06e2f42a-ee4d-4032-8710-a1d2a865e75c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 437", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3974), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 438, 0.0, new Guid("6821691a-e0c0-438e-b096-bfc30cf1f25c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3985), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 438", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3986), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 439, 0.0, new Guid("2ed12085-6761-4454-b161-dd8f9facf2d4"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3996), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 439", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(3997), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 440, 0.0, new Guid("b87e767a-81a2-4c78-a677-75c517d2903e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4038), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 440", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4039), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 441, 0.0, new Guid("6644930c-e5ae-4a85-bce8-46049cb632a9"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4052), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 441", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4053), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 442, 0.0, new Guid("e30a4714-36e2-4d74-a981-15571ae45d6f"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4064), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 442", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4065), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 443, 0.0, new Guid("86c96e5a-6101-4aaf-a781-96a5563869de"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4076), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 443", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4076), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 444, 0.0, new Guid("bf0cfc1a-2009-4750-ad0c-816ae0c36eff"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4089), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 444", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4090), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 445, 0.0, new Guid("9d1e02af-9bea-4346-b06b-03dee0f5394c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4101), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 445", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4102), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 446, 0.0, new Guid("267970b1-8e69-46cb-95af-b6faae17d246"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4113), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 446", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4113), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 447, 0.0, new Guid("342096c2-564e-4a87-96c7-4f2b53d10723"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4124), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 447", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4125), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 448, 0.0, new Guid("778fddfa-4f4f-4b26-8f65-b8ff800d6604"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4138), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 448", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4138), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 449, 0.0, new Guid("8e311b3e-bfb1-41f1-a620-b2f7925e912a"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4149), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 449", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4150), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 450, 0.0, new Guid("94f53b40-d8e4-4567-8b2b-0a9e58e9950f"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4161), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 450", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4161), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 451, 0.0, new Guid("3cd733f5-c4cf-48a9-840b-8967207124c3"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4202), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 451", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4203), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 452, 0.0, new Guid("e74b6109-c216-46c9-8c97-d7e6d25d2afe"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4217), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 452", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4217), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 453, 0.0, new Guid("8fae8d0e-dda0-4c7a-8bd9-95234116ec03"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4229), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 453", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4229), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 454, 0.0, new Guid("9605620a-48fe-4bd1-b8a0-9b71b558488c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4240), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 454", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4240), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 455, 0.0, new Guid("a57959a6-71e9-4059-b6ca-5e8eec6257fc"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4251), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 455", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4252), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 456, 0.0, new Guid("504c7a7d-4c55-4366-8b2a-750709cd9715"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4265), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 456", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4266), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 457, 0.0, new Guid("1f254efb-84b5-4ff4-a917-f753b1e70943"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4276), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 457", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4277), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 458, 0.0, new Guid("be75ace0-5932-4fa1-a3c0-ae7f00fb4e2b"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4288), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 458", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4289), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 459, 0.0, new Guid("70f4279e-017b-4ec3-a0c5-c225f893309c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4300), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 459", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4300), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 460, 0.0, new Guid("5e552606-410b-4e04-b596-2fa7ba2bf721"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4313), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 460", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4314), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 461, 0.0, new Guid("f1d9cb3c-92df-484d-afc3-35af1de6e1f6"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4353), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 461", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4353), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 462, 0.0, new Guid("905eee83-fc2f-4e2d-a29b-14eadb9a9509"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 462", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4368), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 463, 0.0, new Guid("d493fe43-0778-4251-a75b-d25af3ee5a51"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 463", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4380), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 464, 0.0, new Guid("239a885c-c1c1-45e2-8e40-7526104c6585"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4393), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 464", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4394), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 465, 0.0, new Guid("e2cdf58f-8fe1-4f9c-b083-4a0c5ce3e47e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4405), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 465", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4405), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 466, 0.0, new Guid("cc504018-4dd6-4d51-bad7-6d36c0212ff6"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4416), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 466", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4417), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 467, 0.0, new Guid("e5bdd107-95a8-452b-b238-b4945097c2ea"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4428), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 467", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4428), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 468, 0.0, new Guid("27e931dd-2567-4de4-8dd3-2111dd66f66d"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4441), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 468", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4442), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 469, 0.0, new Guid("3c38a805-7ad7-4abe-8053-c92a9447ba4e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4453), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 469", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4453), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 470, 0.0, new Guid("f53f3835-e59f-4e04-96ba-8d5b4b923b53"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4465), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 470", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4465), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 471, 0.0, new Guid("0491c50e-f543-41d9-97d7-db4e0c1358cd"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4476), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 471", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4477), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 472, 0.0, new Guid("5df10f35-0962-4e02-99e3-437c6d9a1b5a"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4527), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 472", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4527), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 473, 0.0, new Guid("fa70df24-40c8-4cff-aef1-0cef176fa927"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4542), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 473", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4543), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 474, 0.0, new Guid("8ebd56e7-7001-4920-99b6-a36ec692c819"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4554), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 474", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4555), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 475, 0.0, new Guid("0565eb1b-903d-4ed0-8d0b-ea1ad382dc10"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4567), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 475", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4567), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 476, 0.0, new Guid("eaaf44a1-44ba-4268-9e73-87ff21dd37a5"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4580), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 476", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4581), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 477, 0.0, new Guid("95fd750f-3d15-40ad-871d-41ca2d46c5d2"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4592), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 477", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4593), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 478, 0.0, new Guid("5dfc42e9-087a-429d-84e8-fd0974f3077b"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4604), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 478", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4605), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 479, 0.0, new Guid("9fe5829b-bde9-4a72-8f65-9d830088144c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4616), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 479", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4617), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 480, 0.0, new Guid("d16f6caa-2734-4dcf-8992-b0dfd2e05766"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4629), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 480", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4630), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 481, 0.0, new Guid("d756b27f-23e0-4071-9e44-2247b4b9c965"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4641), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 481", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4641), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 482, 0.0, new Guid("e4265bf9-f7fd-4028-87e0-4440f6851296"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4652), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 482", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4653), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 483, 0.0, new Guid("166b7109-aca7-46b7-814d-2231e5d137bd"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4691), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 483", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4691), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 484, 0.0, new Guid("25d32501-39b5-48e7-a526-e3f51a4244bd"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4707), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 484", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4708), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 485, 0.0, new Guid("361e9afb-fbb0-43a6-b61e-81c02eee1589"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4719), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 485", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4720), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 486, 0.0, new Guid("247ef83f-511f-454d-8abc-408d3457931d"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4730), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 486", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4731), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 487, 0.0, new Guid("68dfa178-e59f-4a59-95b3-d3be79efeebf"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4742), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 487", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4742), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 488, 0.0, new Guid("95090b5f-82e9-44e4-bae0-26ad383fa2bf"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 488", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4756), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 489, 0.0, new Guid("1e2cf950-1440-4fa6-bb0d-42aa0b432d27"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4767), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 489", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4768), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 490, 0.0, new Guid("6714d933-d322-4d18-87fc-c261aaf3a532"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4778), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 490", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4779), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 491, 0.0, new Guid("fc00ae2a-40d5-40ef-82d7-dd43e07f54c9"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4789), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 491", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4790), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 492, 0.0, new Guid("ddbac509-9256-4a7a-ab34-154c7f901bbc"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4803), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 492", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4804), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 493, 0.0, new Guid("e0e582c7-800a-44c2-b073-4288987e29fd"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4814), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 493", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4815), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 494, 0.0, new Guid("b5668c83-f939-460a-8119-9607972b80f5"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4856), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 494", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4857), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 495, 0.0, new Guid("469092db-5d0e-462e-a50e-30a70116b9b9"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4869), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 495", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4870), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 496, 0.0, new Guid("32b8d804-f4a3-402d-8db7-748d7d6b23ee"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4883), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 496", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4884), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 497, 0.0, new Guid("96608393-ebfd-491b-bc0d-37b00da74cf8"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 497", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4895), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 498, 0.0, new Guid("e7774fc7-4ee9-4870-96b4-f694280ff114"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4906), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 498", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4907), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 499, 0.0, new Guid("f41561c0-e62f-4131-9109-2796036375b0"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4918), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, null, 1, "Driver 499", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4918), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "name", "slot", "status", "type" },
                values: new object[,]
                {
                    { 1, new Guid("32c5a9e2-209c-47e7-b83f-5cc14f72f5aa"), "ViRide", 2, 1, 0 },
                    { 2, new Guid("d875da64-9667-47c5-a0ca-45a0ae50d5fa"), "ViCar-4", 4, 1, 1 },
                    { 3, new Guid("66bf71cd-f0e4-4ccc-97ff-17ca30c7f5d2"), "ViCar-7", 7, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "type", "updated_at", "updated_by", "user_id" },
                values: new object[] { 9, 0.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(440), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(441), new TimeSpan(0, 7, 0, 0, 0)), 0, null });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5119), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5119), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5127), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5127), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5134), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5135), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5142), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5149), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5150), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5156), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5157), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 100, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5165), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+100", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5166), new TimeSpan(0, 7, 0, 0, 0)), 0, 100, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 101, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5177), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@100", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5177), new TimeSpan(0, 7, 0, 0, 0)), 0, 100 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 102, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5188), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+101", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5188), new TimeSpan(0, 7, 0, 0, 0)), 0, 101, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 103, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5196), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@101", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5196), new TimeSpan(0, 7, 0, 0, 0)), 0, 101 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 104, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5203), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+102", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5204), new TimeSpan(0, 7, 0, 0, 0)), 0, 102, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 105, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5211), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@102", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5212), new TimeSpan(0, 7, 0, 0, 0)), 0, 102 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 106, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5219), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+103", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5219), new TimeSpan(0, 7, 0, 0, 0)), 0, 103, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 107, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@103", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5227), new TimeSpan(0, 7, 0, 0, 0)), 0, 103 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 108, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+104", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5267), new TimeSpan(0, 7, 0, 0, 0)), 0, 104, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 109, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5277), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@104", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5277), new TimeSpan(0, 7, 0, 0, 0)), 0, 104 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 110, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5285), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+105", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5285), new TimeSpan(0, 7, 0, 0, 0)), 0, 105, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 111, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5292), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@105", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5293), new TimeSpan(0, 7, 0, 0, 0)), 0, 105 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 112, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5300), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+106", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5300), new TimeSpan(0, 7, 0, 0, 0)), 0, 106, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 113, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5307), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@106", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5308), new TimeSpan(0, 7, 0, 0, 0)), 0, 106 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 114, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5315), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+107", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5315), new TimeSpan(0, 7, 0, 0, 0)), 0, 107, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 115, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5323), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@107", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5323), new TimeSpan(0, 7, 0, 0, 0)), 0, 107 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 116, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5330), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+108", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5331), new TimeSpan(0, 7, 0, 0, 0)), 0, 108, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 117, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5338), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@108", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5338), new TimeSpan(0, 7, 0, 0, 0)), 0, 108 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 118, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5345), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+109", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5346), new TimeSpan(0, 7, 0, 0, 0)), 0, 109, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 119, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5353), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@109", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5354), new TimeSpan(0, 7, 0, 0, 0)), 0, 109 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 120, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5361), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+110", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5361), new TimeSpan(0, 7, 0, 0, 0)), 0, 110, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 121, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@110", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5369), new TimeSpan(0, 7, 0, 0, 0)), 0, 110 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 122, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5376), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+111", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5376), new TimeSpan(0, 7, 0, 0, 0)), 0, 111, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 123, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5383), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@111", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5384), new TimeSpan(0, 7, 0, 0, 0)), 0, 111 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 124, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5391), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+112", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5391), new TimeSpan(0, 7, 0, 0, 0)), 0, 112, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 125, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5398), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@112", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5399), new TimeSpan(0, 7, 0, 0, 0)), 0, 112 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 126, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5406), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+113", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5406), new TimeSpan(0, 7, 0, 0, 0)), 0, 113, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 127, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5413), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@113", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5414), new TimeSpan(0, 7, 0, 0, 0)), 0, 113 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 128, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5421), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+114", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5421), new TimeSpan(0, 7, 0, 0, 0)), 0, 114, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 129, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5456), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@114", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5457), new TimeSpan(0, 7, 0, 0, 0)), 0, 114 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 130, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5465), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+115", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5465), new TimeSpan(0, 7, 0, 0, 0)), 0, 115, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 131, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5472), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@115", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5473), new TimeSpan(0, 7, 0, 0, 0)), 0, 115 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 132, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5479), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+116", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5480), new TimeSpan(0, 7, 0, 0, 0)), 0, 116, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 133, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5487), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@116", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5488), new TimeSpan(0, 7, 0, 0, 0)), 0, 116 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 134, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5495), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+117", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5496), new TimeSpan(0, 7, 0, 0, 0)), 0, 117, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 135, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5502), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@117", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5503), new TimeSpan(0, 7, 0, 0, 0)), 0, 117 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 136, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+118", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5511), new TimeSpan(0, 7, 0, 0, 0)), 0, 118, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 137, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5518), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@118", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5518), new TimeSpan(0, 7, 0, 0, 0)), 0, 118 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 138, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5525), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+119", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5526), new TimeSpan(0, 7, 0, 0, 0)), 0, 119, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 139, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@119", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5533), new TimeSpan(0, 7, 0, 0, 0)), 0, 119 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 140, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5541), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+120", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5541), new TimeSpan(0, 7, 0, 0, 0)), 0, 120, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 141, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5550), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@120", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5550), new TimeSpan(0, 7, 0, 0, 0)), 0, 120 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 142, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5558), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+121", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5558), new TimeSpan(0, 7, 0, 0, 0)), 0, 121, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 143, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5565), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@121", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5566), new TimeSpan(0, 7, 0, 0, 0)), 0, 121 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 144, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5573), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+122", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5573), new TimeSpan(0, 7, 0, 0, 0)), 0, 122, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 145, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5580), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@122", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5581), new TimeSpan(0, 7, 0, 0, 0)), 0, 122 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 146, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5588), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+123", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5588), new TimeSpan(0, 7, 0, 0, 0)), 0, 123, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 147, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5596), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@123", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5596), new TimeSpan(0, 7, 0, 0, 0)), 0, 123 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 148, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5630), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+124", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5632), new TimeSpan(0, 7, 0, 0, 0)), 0, 124, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 149, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5641), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@124", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5642), new TimeSpan(0, 7, 0, 0, 0)), 0, 124 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 150, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5649), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+125", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5649), new TimeSpan(0, 7, 0, 0, 0)), 0, 125, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 151, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5656), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@125", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5657), new TimeSpan(0, 7, 0, 0, 0)), 0, 125 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 152, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+126", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5664), new TimeSpan(0, 7, 0, 0, 0)), 0, 126, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 153, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5671), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@126", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5672), new TimeSpan(0, 7, 0, 0, 0)), 0, 126 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 154, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5679), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+127", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5679), new TimeSpan(0, 7, 0, 0, 0)), 0, 127, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 155, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5686), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@127", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5687), new TimeSpan(0, 7, 0, 0, 0)), 0, 127 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 156, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5694), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+128", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5695), new TimeSpan(0, 7, 0, 0, 0)), 0, 128, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 157, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5702), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@128", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5702), new TimeSpan(0, 7, 0, 0, 0)), 0, 128 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 158, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5709), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+129", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5710), new TimeSpan(0, 7, 0, 0, 0)), 0, 129, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 159, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5717), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@129", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5717), new TimeSpan(0, 7, 0, 0, 0)), 0, 129 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 160, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5724), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+130", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5725), new TimeSpan(0, 7, 0, 0, 0)), 0, 130, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 161, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5732), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@130", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5732), new TimeSpan(0, 7, 0, 0, 0)), 0, 130 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 162, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5739), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+131", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5740), new TimeSpan(0, 7, 0, 0, 0)), 0, 131, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 163, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5747), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@131", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5747), new TimeSpan(0, 7, 0, 0, 0)), 0, 131 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 164, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5754), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+132", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5755), new TimeSpan(0, 7, 0, 0, 0)), 0, 132, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 165, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5762), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@132", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5763), new TimeSpan(0, 7, 0, 0, 0)), 0, 132 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 166, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+133", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5770), new TimeSpan(0, 7, 0, 0, 0)), 0, 133, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 167, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5777), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@133", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5777), new TimeSpan(0, 7, 0, 0, 0)), 0, 133 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 168, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5784), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+134", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5785), new TimeSpan(0, 7, 0, 0, 0)), 0, 134, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 169, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5792), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@134", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5792), new TimeSpan(0, 7, 0, 0, 0)), 0, 134 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 170, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5829), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+135", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5830), new TimeSpan(0, 7, 0, 0, 0)), 0, 135, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 171, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5839), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@135", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5840), new TimeSpan(0, 7, 0, 0, 0)), 0, 135 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 172, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5846), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+136", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5847), new TimeSpan(0, 7, 0, 0, 0)), 0, 136, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 173, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5854), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@136", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5854), new TimeSpan(0, 7, 0, 0, 0)), 0, 136 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 174, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5861), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+137", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5862), new TimeSpan(0, 7, 0, 0, 0)), 0, 137, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 175, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5869), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@137", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5870), new TimeSpan(0, 7, 0, 0, 0)), 0, 137 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 176, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5877), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+138", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5877), new TimeSpan(0, 7, 0, 0, 0)), 0, 138, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 177, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5884), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@138", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5885), new TimeSpan(0, 7, 0, 0, 0)), 0, 138 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 178, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5892), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+139", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5893), new TimeSpan(0, 7, 0, 0, 0)), 0, 139, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 179, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5900), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@139", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5900), new TimeSpan(0, 7, 0, 0, 0)), 0, 139 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 180, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5907), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+140", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5908), new TimeSpan(0, 7, 0, 0, 0)), 0, 140, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 181, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5915), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@140", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5916), new TimeSpan(0, 7, 0, 0, 0)), 0, 140 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 182, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5923), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+141", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5924), new TimeSpan(0, 7, 0, 0, 0)), 0, 141, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 183, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5931), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@141", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5932), new TimeSpan(0, 7, 0, 0, 0)), 0, 141 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 184, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5939), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+142", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5939), new TimeSpan(0, 7, 0, 0, 0)), 0, 142, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 185, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5946), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@142", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5947), new TimeSpan(0, 7, 0, 0, 0)), 0, 142 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 186, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+143", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5955), new TimeSpan(0, 7, 0, 0, 0)), 0, 143, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 187, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@143", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5962), new TimeSpan(0, 7, 0, 0, 0)), 0, 143 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 188, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5969), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+144", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5970), new TimeSpan(0, 7, 0, 0, 0)), 0, 144, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 189, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5977), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@144", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5978), new TimeSpan(0, 7, 0, 0, 0)), 0, 144 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 190, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5985), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+145", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5985), new TimeSpan(0, 7, 0, 0, 0)), 0, 145, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 191, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5992), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@145", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5993), new TimeSpan(0, 7, 0, 0, 0)), 0, 145 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 192, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6036), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+146", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6037), new TimeSpan(0, 7, 0, 0, 0)), 0, 146, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 193, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6047), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@146", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6048), new TimeSpan(0, 7, 0, 0, 0)), 0, 146 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 194, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6055), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+147", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6055), new TimeSpan(0, 7, 0, 0, 0)), 0, 147, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 195, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6062), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@147", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6063), new TimeSpan(0, 7, 0, 0, 0)), 0, 147 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 196, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6070), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+148", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6070), new TimeSpan(0, 7, 0, 0, 0)), 0, 148, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 197, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6077), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@148", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6078), new TimeSpan(0, 7, 0, 0, 0)), 0, 148 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 198, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6085), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+149", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6085), new TimeSpan(0, 7, 0, 0, 0)), 0, 149, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 199, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6092), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@149", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6093), new TimeSpan(0, 7, 0, 0, 0)), 0, 149 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 200, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6099), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+150", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6100), new TimeSpan(0, 7, 0, 0, 0)), 0, 150, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 201, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6107), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@150", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6107), new TimeSpan(0, 7, 0, 0, 0)), 0, 150 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 202, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6114), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+151", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6115), new TimeSpan(0, 7, 0, 0, 0)), 0, 151, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 203, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6121), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@151", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6122), new TimeSpan(0, 7, 0, 0, 0)), 0, 151 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 204, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+152", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6130), new TimeSpan(0, 7, 0, 0, 0)), 0, 152, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 205, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6139), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@152", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6139), new TimeSpan(0, 7, 0, 0, 0)), 0, 152 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 206, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6147), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+153", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6147), new TimeSpan(0, 7, 0, 0, 0)), 0, 153, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 207, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6154), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@153", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6155), new TimeSpan(0, 7, 0, 0, 0)), 0, 153 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 208, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6162), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+154", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6163), new TimeSpan(0, 7, 0, 0, 0)), 0, 154, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 209, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6199), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@154", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6200), new TimeSpan(0, 7, 0, 0, 0)), 0, 154 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 210, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6207), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+155", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6208), new TimeSpan(0, 7, 0, 0, 0)), 0, 155, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 211, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6215), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@155", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6216), new TimeSpan(0, 7, 0, 0, 0)), 0, 155 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 212, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6222), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+156", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6223), new TimeSpan(0, 7, 0, 0, 0)), 0, 156, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 213, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6230), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@156", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6230), new TimeSpan(0, 7, 0, 0, 0)), 0, 156 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 214, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6237), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+157", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6238), new TimeSpan(0, 7, 0, 0, 0)), 0, 157, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 215, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6245), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@157", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6246), new TimeSpan(0, 7, 0, 0, 0)), 0, 157 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 216, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6253), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+158", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6253), new TimeSpan(0, 7, 0, 0, 0)), 0, 158, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 217, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6260), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@158", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6261), new TimeSpan(0, 7, 0, 0, 0)), 0, 158 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 218, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6268), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+159", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6269), new TimeSpan(0, 7, 0, 0, 0)), 0, 159, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 219, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6276), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@159", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6276), new TimeSpan(0, 7, 0, 0, 0)), 0, 159 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 220, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6283), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+160", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6284), new TimeSpan(0, 7, 0, 0, 0)), 0, 160, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 221, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6291), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@160", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6291), new TimeSpan(0, 7, 0, 0, 0)), 0, 160 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 222, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6298), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+161", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6299), new TimeSpan(0, 7, 0, 0, 0)), 0, 161, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 223, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6306), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@161", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6306), new TimeSpan(0, 7, 0, 0, 0)), 0, 161 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 224, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6313), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+162", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6314), new TimeSpan(0, 7, 0, 0, 0)), 0, 162, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 225, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@162", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6322), new TimeSpan(0, 7, 0, 0, 0)), 0, 162 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 226, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6329), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+163", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6329), new TimeSpan(0, 7, 0, 0, 0)), 0, 163, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 227, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6336), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@163", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6337), new TimeSpan(0, 7, 0, 0, 0)), 0, 163 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 228, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6344), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+164", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6344), new TimeSpan(0, 7, 0, 0, 0)), 0, 164, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 229, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6351), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@164", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6352), new TimeSpan(0, 7, 0, 0, 0)), 0, 164 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 230, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6359), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+165", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6359), new TimeSpan(0, 7, 0, 0, 0)), 0, 165, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 231, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6394), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@165", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6395), new TimeSpan(0, 7, 0, 0, 0)), 0, 165 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 232, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6404), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+166", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6405), new TimeSpan(0, 7, 0, 0, 0)), 0, 166, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 233, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6412), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@166", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6412), new TimeSpan(0, 7, 0, 0, 0)), 0, 166 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 234, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6419), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+167", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6420), new TimeSpan(0, 7, 0, 0, 0)), 0, 167, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 235, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6427), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@167", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6428), new TimeSpan(0, 7, 0, 0, 0)), 0, 167 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 236, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6434), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+168", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6435), new TimeSpan(0, 7, 0, 0, 0)), 0, 168, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 237, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6442), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@168", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6443), new TimeSpan(0, 7, 0, 0, 0)), 0, 168 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 238, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6450), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+169", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6450), new TimeSpan(0, 7, 0, 0, 0)), 0, 169, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 239, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6457), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@169", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6458), new TimeSpan(0, 7, 0, 0, 0)), 0, 169 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 240, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6465), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+170", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6465), new TimeSpan(0, 7, 0, 0, 0)), 0, 170, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 241, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6472), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@170", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6473), new TimeSpan(0, 7, 0, 0, 0)), 0, 170 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 242, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6480), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+171", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 7, 0, 0, 0)), 0, 171, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 243, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6487), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@171", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6488), new TimeSpan(0, 7, 0, 0, 0)), 0, 171 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 244, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6495), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+172", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6496), new TimeSpan(0, 7, 0, 0, 0)), 0, 172, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 245, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6503), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@172", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6503), new TimeSpan(0, 7, 0, 0, 0)), 0, 172 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 246, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+173", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6511), new TimeSpan(0, 7, 0, 0, 0)), 0, 173, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 247, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6517), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@173", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6518), new TimeSpan(0, 7, 0, 0, 0)), 0, 173 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 248, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6525), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+174", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6525), new TimeSpan(0, 7, 0, 0, 0)), 0, 174, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 249, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6532), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@174", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6533), new TimeSpan(0, 7, 0, 0, 0)), 0, 174 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 250, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+175", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6541), new TimeSpan(0, 7, 0, 0, 0)), 0, 175, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 251, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@175", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6548), new TimeSpan(0, 7, 0, 0, 0)), 0, 175 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 252, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6555), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+176", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6556), new TimeSpan(0, 7, 0, 0, 0)), 0, 176, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 253, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6591), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@176", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6592), new TimeSpan(0, 7, 0, 0, 0)), 0, 176 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 254, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6602), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+177", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6602), new TimeSpan(0, 7, 0, 0, 0)), 0, 177, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 255, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6609), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@177", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6610), new TimeSpan(0, 7, 0, 0, 0)), 0, 177 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 256, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6616), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+178", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6617), new TimeSpan(0, 7, 0, 0, 0)), 0, 178, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 257, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6624), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@178", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6625), new TimeSpan(0, 7, 0, 0, 0)), 0, 178 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 258, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6632), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+179", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6632), new TimeSpan(0, 7, 0, 0, 0)), 0, 179, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 259, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6639), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@179", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6640), new TimeSpan(0, 7, 0, 0, 0)), 0, 179 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 260, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6647), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+180", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6647), new TimeSpan(0, 7, 0, 0, 0)), 0, 180, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 261, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6654), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@180", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6655), new TimeSpan(0, 7, 0, 0, 0)), 0, 180 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 262, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6662), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+181", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6662), new TimeSpan(0, 7, 0, 0, 0)), 0, 181, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 263, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6669), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@181", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6670), new TimeSpan(0, 7, 0, 0, 0)), 0, 181 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 264, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+182", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6677), new TimeSpan(0, 7, 0, 0, 0)), 0, 182, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 265, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6684), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@182", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6684), new TimeSpan(0, 7, 0, 0, 0)), 0, 182 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 266, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6691), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+183", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6692), new TimeSpan(0, 7, 0, 0, 0)), 0, 183, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 267, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6699), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@183", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6700), new TimeSpan(0, 7, 0, 0, 0)), 0, 183 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 268, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6706), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+184", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6707), new TimeSpan(0, 7, 0, 0, 0)), 0, 184, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 269, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6714), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@184", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6715), new TimeSpan(0, 7, 0, 0, 0)), 0, 184 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 270, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6722), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+185", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6722), new TimeSpan(0, 7, 0, 0, 0)), 0, 185, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 271, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6729), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@185", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6730), new TimeSpan(0, 7, 0, 0, 0)), 0, 185 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 272, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6737), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+186", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6737), new TimeSpan(0, 7, 0, 0, 0)), 0, 186, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 273, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6744), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@186", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6745), new TimeSpan(0, 7, 0, 0, 0)), 0, 186 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 274, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6752), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+187", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6752), new TimeSpan(0, 7, 0, 0, 0)), 0, 187, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 275, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6759), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@187", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6760), new TimeSpan(0, 7, 0, 0, 0)), 0, 187 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 276, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6796), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+188", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6797), new TimeSpan(0, 7, 0, 0, 0)), 0, 188, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 277, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6804), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@188", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6804), new TimeSpan(0, 7, 0, 0, 0)), 0, 188 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 278, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6811), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+189", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6812), new TimeSpan(0, 7, 0, 0, 0)), 0, 189, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 279, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6819), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@189", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6819), new TimeSpan(0, 7, 0, 0, 0)), 0, 189 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 280, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6826), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+190", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6827), new TimeSpan(0, 7, 0, 0, 0)), 0, 190, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 281, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6834), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@190", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6835), new TimeSpan(0, 7, 0, 0, 0)), 0, 190 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 282, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6842), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+191", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6842), new TimeSpan(0, 7, 0, 0, 0)), 0, 191, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 283, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6849), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@191", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6850), new TimeSpan(0, 7, 0, 0, 0)), 0, 191 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 284, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6857), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+192", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6858), new TimeSpan(0, 7, 0, 0, 0)), 0, 192, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 285, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6864), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@192", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6865), new TimeSpan(0, 7, 0, 0, 0)), 0, 192 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 286, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6872), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+193", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6872), new TimeSpan(0, 7, 0, 0, 0)), 0, 193, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 287, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@193", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6880), new TimeSpan(0, 7, 0, 0, 0)), 0, 193 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 288, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6887), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+194", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6888), new TimeSpan(0, 7, 0, 0, 0)), 0, 194, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 289, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@194", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6895), new TimeSpan(0, 7, 0, 0, 0)), 0, 194 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 290, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6902), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+195", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6903), new TimeSpan(0, 7, 0, 0, 0)), 0, 195, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 291, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6910), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@195", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6910), new TimeSpan(0, 7, 0, 0, 0)), 0, 195 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 292, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6917), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+196", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6918), new TimeSpan(0, 7, 0, 0, 0)), 0, 196, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 293, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6925), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@196", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6925), new TimeSpan(0, 7, 0, 0, 0)), 0, 196 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 294, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6932), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+197", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6933), new TimeSpan(0, 7, 0, 0, 0)), 0, 197, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 295, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6940), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@197", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6940), new TimeSpan(0, 7, 0, 0, 0)), 0, 197 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 296, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6947), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+198", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6948), new TimeSpan(0, 7, 0, 0, 0)), 0, 198, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 297, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@198", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6955), new TimeSpan(0, 7, 0, 0, 0)), 0, 198 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 298, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6991), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+199", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(6992), new TimeSpan(0, 7, 0, 0, 0)), 0, 199, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 299, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7000), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@199", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7001), new TimeSpan(0, 7, 0, 0, 0)), 0, 199 },
                    { 400, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7008), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+400", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7009), new TimeSpan(0, 7, 0, 0, 0)), 0, 400 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 401, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7017), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@400", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7017), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 402, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+401", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7026), new TimeSpan(0, 7, 0, 0, 0)), 0, 401 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 403, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7033), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@401", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7033), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 404, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7040), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+402", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7041), new TimeSpan(0, 7, 0, 0, 0)), 0, 402 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 405, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7048), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@402", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7048), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 406, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7055), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+403", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7056), new TimeSpan(0, 7, 0, 0, 0)), 0, 403 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 407, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7063), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@403", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7064), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 408, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7070), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+404", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7071), new TimeSpan(0, 7, 0, 0, 0)), 0, 404 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 409, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7078), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@404", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7079), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 410, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7085), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+405", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7086), new TimeSpan(0, 7, 0, 0, 0)), 0, 405 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 411, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7092), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@405", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7093), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 412, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7100), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+406", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7101), new TimeSpan(0, 7, 0, 0, 0)), 0, 406 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 413, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7107), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@406", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7108), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 414, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7115), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+407", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7115), new TimeSpan(0, 7, 0, 0, 0)), 0, 407 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 415, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7122), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@407", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7123), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 416, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+408", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7130), new TimeSpan(0, 7, 0, 0, 0)), 0, 408 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 417, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7137), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@408", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7137), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 418, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+409", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7145), new TimeSpan(0, 7, 0, 0, 0)), 0, 409 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 419, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7151), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@409", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7152), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 420, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7187), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+410", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7188), new TimeSpan(0, 7, 0, 0, 0)), 0, 410 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 421, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7196), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@410", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7197), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 422, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7204), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+411", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7205), new TimeSpan(0, 7, 0, 0, 0)), 0, 411 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 423, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@411", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7212), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 424, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7219), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+412", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7220), new TimeSpan(0, 7, 0, 0, 0)), 0, 412 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 425, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@412", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7227), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 426, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7234), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+413", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7235), new TimeSpan(0, 7, 0, 0, 0)), 0, 413 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 427, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7242), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@413", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7243), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 428, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7249), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+414", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7250), new TimeSpan(0, 7, 0, 0, 0)), 0, 414 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 429, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@414", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7258), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 430, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7264), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+415", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7265), new TimeSpan(0, 7, 0, 0, 0)), 0, 415 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 431, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7272), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@415", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7273), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 432, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7280), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+416", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7280), new TimeSpan(0, 7, 0, 0, 0)), 0, 416 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 433, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7318), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@416", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7319), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 434, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7341), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+417", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7342), new TimeSpan(0, 7, 0, 0, 0)), 0, 417 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 435, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7349), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@417", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7350), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 436, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7357), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+418", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7358), new TimeSpan(0, 7, 0, 0, 0)), 0, 418 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 437, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7365), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@418", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7365), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 438, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7372), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+419", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7373), new TimeSpan(0, 7, 0, 0, 0)), 0, 419 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 439, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@419", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7380), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 440, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7387), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+420", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7388), new TimeSpan(0, 7, 0, 0, 0)), 0, 420 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 441, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7395), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@420", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7395), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 442, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7402), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+421", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7403), new TimeSpan(0, 7, 0, 0, 0)), 0, 421 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 443, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7410), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@421", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7411), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 444, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7418), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+422", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7419), new TimeSpan(0, 7, 0, 0, 0)), 0, 422 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 445, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7425), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@422", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7426), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 446, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7433), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+423", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7434), new TimeSpan(0, 7, 0, 0, 0)), 0, 423 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 447, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7440), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@423", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7441), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 448, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7448), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+424", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7449), new TimeSpan(0, 7, 0, 0, 0)), 0, 424 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 449, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7456), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@424", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7456), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 450, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7464), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+425", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7464), new TimeSpan(0, 7, 0, 0, 0)), 0, 425 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 451, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7471), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@425", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7472), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 452, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7479), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+426", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7479), new TimeSpan(0, 7, 0, 0, 0)), 0, 426 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 453, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7523), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@426", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7524), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 454, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7534), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+427", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7534), new TimeSpan(0, 7, 0, 0, 0)), 0, 427 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 455, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7541), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@427", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7542), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 456, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7549), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+428", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7550), new TimeSpan(0, 7, 0, 0, 0)), 0, 428 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 457, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7557), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@428", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7557), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 458, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7564), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+429", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7565), new TimeSpan(0, 7, 0, 0, 0)), 0, 429 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 459, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7571), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@429", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7572), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 460, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7579), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+430", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7579), new TimeSpan(0, 7, 0, 0, 0)), 0, 430 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 461, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7586), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@430", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7587), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 462, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7594), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+431", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7594), new TimeSpan(0, 7, 0, 0, 0)), 0, 431 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 463, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7601), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@431", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7602), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 464, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7609), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+432", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7609), new TimeSpan(0, 7, 0, 0, 0)), 0, 432 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 465, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7616), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@432", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7617), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 466, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7623), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+433", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7624), new TimeSpan(0, 7, 0, 0, 0)), 0, 433 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 467, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7631), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@433", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7632), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 468, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7638), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+434", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7639), new TimeSpan(0, 7, 0, 0, 0)), 0, 434 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 469, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7646), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@434", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7646), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 470, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7653), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+435", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7654), new TimeSpan(0, 7, 0, 0, 0)), 0, 435 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 471, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7661), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@435", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7661), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 472, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7668), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+436", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7669), new TimeSpan(0, 7, 0, 0, 0)), 0, 436 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 473, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@436", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7677), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 474, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7683), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+437", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7684), new TimeSpan(0, 7, 0, 0, 0)), 0, 437 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 475, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7718), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@437", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7719), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 476, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7729), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+438", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7729), new TimeSpan(0, 7, 0, 0, 0)), 0, 438 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 477, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7736), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@438", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7736), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 478, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7743), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+439", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7744), new TimeSpan(0, 7, 0, 0, 0)), 0, 439 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 479, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7751), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@439", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7751), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 480, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7758), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+440", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7759), new TimeSpan(0, 7, 0, 0, 0)), 0, 440 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 481, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7766), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@440", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7766), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 482, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7773), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+441", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7774), new TimeSpan(0, 7, 0, 0, 0)), 0, 441 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 483, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@441", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7782), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 484, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7788), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+442", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7789), new TimeSpan(0, 7, 0, 0, 0)), 0, 442 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 485, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7796), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@442", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7796), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 486, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7803), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+443", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7804), new TimeSpan(0, 7, 0, 0, 0)), 0, 443 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 487, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7811), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@443", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7812), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 488, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7819), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+444", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7819), new TimeSpan(0, 7, 0, 0, 0)), 0, 444 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 489, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7826), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@444", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7827), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 490, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7834), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+445", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7834), new TimeSpan(0, 7, 0, 0, 0)), 0, 445 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 491, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7841), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@445", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7842), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 492, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7849), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+446", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7849), new TimeSpan(0, 7, 0, 0, 0)), 0, 446 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 493, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7856), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@446", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7857), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 494, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7864), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+447", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7864), new TimeSpan(0, 7, 0, 0, 0)), 0, 447 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 495, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@447", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7872), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 496, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+448", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7879), new TimeSpan(0, 7, 0, 0, 0)), 0, 448 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 497, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7886), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@448", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7887), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 498, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7923), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+449", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7923), new TimeSpan(0, 7, 0, 0, 0)), 0, 449 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 499, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7931), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@449", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7931), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 500, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7938), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+450", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7939), new TimeSpan(0, 7, 0, 0, 0)), 0, 450 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 501, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7946), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@450", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7947), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 502, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7953), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+451", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7954), new TimeSpan(0, 7, 0, 0, 0)), 0, 451 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 503, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7961), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@451", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7961), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 504, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7969), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+452", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7969), new TimeSpan(0, 7, 0, 0, 0)), 0, 452 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 505, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7976), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@452", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7977), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 506, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7983), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+453", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7984), new TimeSpan(0, 7, 0, 0, 0)), 0, 453 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 507, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7991), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@453", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7992), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 508, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(7999), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+454", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8000), new TimeSpan(0, 7, 0, 0, 0)), 0, 454 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 509, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8007), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@454", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8007), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 510, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8014), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+455", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8015), new TimeSpan(0, 7, 0, 0, 0)), 0, 455 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 511, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8022), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@455", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8022), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 512, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8029), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+456", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8030), new TimeSpan(0, 7, 0, 0, 0)), 0, 456 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 513, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8037), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@456", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8037), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 514, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8044), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+457", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8045), new TimeSpan(0, 7, 0, 0, 0)), 0, 457 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 515, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8052), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@457", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8052), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 516, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8059), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+458", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8060), new TimeSpan(0, 7, 0, 0, 0)), 0, 458 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 517, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8067), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@458", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8067), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 518, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8074), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+459", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8075), new TimeSpan(0, 7, 0, 0, 0)), 0, 459 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 519, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8082), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@459", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8082), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 520, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8117), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+460", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8118), new TimeSpan(0, 7, 0, 0, 0)), 0, 460 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 521, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8125), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@460", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8126), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 522, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8133), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+461", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8134), new TimeSpan(0, 7, 0, 0, 0)), 0, 461 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 523, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@461", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8141), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 524, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8148), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+462", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8149), new TimeSpan(0, 7, 0, 0, 0)), 0, 462 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 525, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8156), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@462", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8157), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 526, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8164), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+463", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8164), new TimeSpan(0, 7, 0, 0, 0)), 0, 463 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 527, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8171), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@463", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8172), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 528, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8179), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+464", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8180), new TimeSpan(0, 7, 0, 0, 0)), 0, 464 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 529, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8186), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@464", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8187), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 530, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8194), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+465", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8195), new TimeSpan(0, 7, 0, 0, 0)), 0, 465 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 531, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8202), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@465", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8202), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 532, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8209), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+466", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8210), new TimeSpan(0, 7, 0, 0, 0)), 0, 466 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 533, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8216), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@466", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8217), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 534, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8224), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+467", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8225), new TimeSpan(0, 7, 0, 0, 0)), 0, 467 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 535, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8231), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@467", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8232), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 536, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8239), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+468", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8240), new TimeSpan(0, 7, 0, 0, 0)), 0, 468 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 537, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8247), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@468", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8247), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 538, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8254), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+469", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8255), new TimeSpan(0, 7, 0, 0, 0)), 0, 469 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 539, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8261), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@469", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8262), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 540, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8269), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+470", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8270), new TimeSpan(0, 7, 0, 0, 0)), 0, 470 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 541, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8277), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@470", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8277), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 542, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8315), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+471", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8316), new TimeSpan(0, 7, 0, 0, 0)), 0, 471 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 543, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8324), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@471", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8325), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 544, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8331), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+472", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8332), new TimeSpan(0, 7, 0, 0, 0)), 0, 472 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 545, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8339), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@472", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8340), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 546, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8346), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+473", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8347), new TimeSpan(0, 7, 0, 0, 0)), 0, 473 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 547, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@473", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8355), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 548, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8362), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+474", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8362), new TimeSpan(0, 7, 0, 0, 0)), 0, 474 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 549, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8369), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@474", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8370), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 550, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8377), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+475", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8377), new TimeSpan(0, 7, 0, 0, 0)), 0, 475 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 551, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8384), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@475", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8385), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 552, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8392), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+476", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8392), new TimeSpan(0, 7, 0, 0, 0)), 0, 476 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 553, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8399), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@476", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8400), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 554, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8407), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+477", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8408), new TimeSpan(0, 7, 0, 0, 0)), 0, 477 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 555, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8415), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@477", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8415), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 556, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8422), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+478", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8423), new TimeSpan(0, 7, 0, 0, 0)), 0, 478 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 557, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8430), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@478", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8431), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 558, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8438), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+479", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8438), new TimeSpan(0, 7, 0, 0, 0)), 0, 479 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 559, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8445), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@479", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8446), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 560, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8453), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+480", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8453), new TimeSpan(0, 7, 0, 0, 0)), 0, 480 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 561, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8460), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@480", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8461), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 562, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+481", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8469), new TimeSpan(0, 7, 0, 0, 0)), 0, 481 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 563, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8476), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@481", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8476), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 564, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8511), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+482", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8512), new TimeSpan(0, 7, 0, 0, 0)), 0, 482 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 565, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8521), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@482", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8521), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 566, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8528), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+483", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8529), new TimeSpan(0, 7, 0, 0, 0)), 0, 483 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 567, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8536), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@483", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8537), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 568, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8544), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+484", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8544), new TimeSpan(0, 7, 0, 0, 0)), 0, 484 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 569, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8551), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@484", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8552), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 570, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8559), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+485", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8559), new TimeSpan(0, 7, 0, 0, 0)), 0, 485 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 571, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8566), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@485", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8567), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 572, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8574), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+486", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8574), new TimeSpan(0, 7, 0, 0, 0)), 0, 486 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 573, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8581), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@486", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8582), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 574, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8589), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+487", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8590), new TimeSpan(0, 7, 0, 0, 0)), 0, 487 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 575, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8597), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@487", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8598), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 576, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8605), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+488", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8605), new TimeSpan(0, 7, 0, 0, 0)), 0, 488 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 577, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8612), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@488", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8613), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 578, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8620), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+489", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8620), new TimeSpan(0, 7, 0, 0, 0)), 0, 489 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 579, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8627), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@489", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8628), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 580, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+490", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8635), new TimeSpan(0, 7, 0, 0, 0)), 0, 490 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 581, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8642), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@490", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8643), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 582, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8650), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+491", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8651), new TimeSpan(0, 7, 0, 0, 0)), 0, 491 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 583, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8658), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@491", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8658), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 584, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8665), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+492", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8666), new TimeSpan(0, 7, 0, 0, 0)), 0, 492 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 585, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8673), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@492", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8673), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 586, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8709), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+493", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8709), new TimeSpan(0, 7, 0, 0, 0)), 0, 493 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 587, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8718), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@493", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8719), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 588, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8726), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+494", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8726), new TimeSpan(0, 7, 0, 0, 0)), 0, 494 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 589, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8733), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@494", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8734), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 590, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8741), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+495", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8741), new TimeSpan(0, 7, 0, 0, 0)), 0, 495 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 591, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8748), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@495", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8749), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 592, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8756), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+496", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8757), new TimeSpan(0, 7, 0, 0, 0)), 0, 496 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 593, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8764), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@496", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8764), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 594, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8771), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+497", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8772), new TimeSpan(0, 7, 0, 0, 0)), 0, 497 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 595, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8779), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@497", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8779), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 596, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8786), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+498", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8787), new TimeSpan(0, 7, 0, 0, 0)), 0, 498 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 597, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8794), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@498", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8795), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 598, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8802), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+499", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8802), new TimeSpan(0, 7, 0, 0, 0)), 0, 499 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 599, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8809), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@499", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8810), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, true });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "title", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9555), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, "What is Lorem Ipsum?", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9555), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9562), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, "Why do we use it?", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9562), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9564), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, "Where does it come from?", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9564), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9593), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, "Where can I get some?", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9594), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9674), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9675), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9679), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9679), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9681), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9681), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9039), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9039), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9058), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9058), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9075), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9076), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8830), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8831), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8842), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8843), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8875), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8876), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "cancelled_trip_rate", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "fcm_token", "file_id", "gender", "name", "rating", "status", "suddenly_cancelled_trips", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 0.0, new Guid("58782d14-5c38-400f-9664-216e0bb2fce7"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1317), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1321), new TimeSpan(0, 7, 0, 0, 0)), null, null, 1, 1, "Quach Dai Loi", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1318), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 0.0, new Guid("b6b05d13-b5d7-4847-992a-85fec0baf76f"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1340), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1342), new TimeSpan(0, 7, 0, 0, 0)), null, null, 2, 1, "Do Trong Dat", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1341), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 0.0, new Guid("31208146-6583-4b09-8dad-b62ff16181b4"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1353), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1355), new TimeSpan(0, 7, 0, 0, 0)), null, null, 3, 1, "Nguyen Dang Khoa", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1354), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 0.0, new Guid("9ea4468a-ccc4-4642-8bad-f6e416be1611"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1366), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1370), new TimeSpan(0, 7, 0, 0, 0)), null, null, 4, 1, "Than Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1366), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 0.0, new Guid("c582d27e-a698-40f0-9fb6-18a0d7fb8518"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1381), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1383), new TimeSpan(0, 7, 0, 0, 0)), null, null, 5, 1, "Loi Quach", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1382), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 0.0, new Guid("ef43126e-8b46-439d-82d2-e2b6800821af"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1396), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1398), new TimeSpan(0, 7, 0, 0, 0)), null, null, 6, 1, "Dat Do", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1397), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 0.0, new Guid("0213f42e-06c9-40b1-a75d-889f5b3d3015"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1439), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1441), new TimeSpan(0, 7, 0, 0, 0)), null, null, 7, 1, "Khoa Nguyen", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1440), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 0.0, new Guid("574a6ea7-6d61-4347-adba-168a8302dcf7"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1454), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1458), new TimeSpan(0, 7, 0, 0, 0)), null, null, 8, 1, "Thanh Duy", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1454), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 0.0, new Guid("2585d2d1-fa3d-4254-a4d1-9a4b05c4b3f7"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1468), new TimeSpan(0, 7, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2000, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1470), new TimeSpan(0, 7, 0, 0, 0)), null, null, 13, 1, "Admin Quach Dai Loi", 5.0, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(1469), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 400, new Guid("c19bfdd6-9d56-4e1b-a260-1b47bbe75c62"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9865), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.400", "Vehicle 400", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9865), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, 2 },
                    { 401, new Guid("910eb23e-03f2-4e07-9463-4c63177c9c88"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9875), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.401", "Vehicle 401", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9876), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, 2 },
                    { 402, new Guid("7ee04de1-8b7a-4697-89f2-63b9ccf0ada9"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.402", "Vehicle 402", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9880), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, 2 },
                    { 403, new Guid("71f23c8c-5f76-4118-bbb8-c2a82b4a21f9"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9882), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.403", "Vehicle 403", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9883), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, 2 },
                    { 404, new Guid("29e04152-004a-4893-9d97-f00ccfb980e8"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9886), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.404", "Vehicle 404", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9886), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, 2 },
                    { 405, new Guid("e7988692-1363-4dd0-838e-a8cad34695ae"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9890), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.405", "Vehicle 405", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9890), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, 2 },
                    { 406, new Guid("44ee29ce-dd89-407a-b76c-d52cb1f84783"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9893), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.406", "Vehicle 406", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9894), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, 2 },
                    { 407, new Guid("4db5d791-be0d-4d40-93dc-76c5b051edcb"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9898), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.407", "Vehicle 407", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9899), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, 2 },
                    { 408, new Guid("38fe87e7-77dd-416f-84b1-6efa7b6f968b"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9902), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.408", "Vehicle 408", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9902), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, 2 },
                    { 409, new Guid("cee5812e-ae32-453e-bb91-1ef577902036"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.409", "Vehicle 409", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9905), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, 2 },
                    { 410, new Guid("acb474a0-58fd-4849-bf8c-c019fffc73a6"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9939), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.410", "Vehicle 410", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9940), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, 2 },
                    { 411, new Guid("ad55f5d6-2b04-46ef-8fd0-521d49ebaa6a"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9943), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.411", "Vehicle 411", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9944), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, 2 },
                    { 412, new Guid("dba968ae-4441-474f-b441-93ac7b90fd96"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9946), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.412", "Vehicle 412", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9947), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, 2 },
                    { 413, new Guid("0ba5a5df-fd49-41bf-9a5b-c94978744f6c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9951), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.413", "Vehicle 413", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9951), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, 2 },
                    { 414, new Guid("513197c4-b7cf-46d9-8ce7-dd2c6016f97f"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.414", "Vehicle 414", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9955), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, 2 },
                    { 415, new Guid("07261433-c9ac-49c6-b740-0e7a62b70483"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.415", "Vehicle 415", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9960), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, 2 },
                    { 416, new Guid("2974c959-4c17-412e-b0b5-3a76c221cb5c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.416", "Vehicle 416", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9963), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, 2 },
                    { 417, new Guid("d560d059-5cf9-427e-96ed-a65e19f8fc4f"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9966), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.417", "Vehicle 417", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9966), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, 2 },
                    { 418, new Guid("1bf1cfd8-a6c5-4940-a620-0961fc89badc"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9969), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.418", "Vehicle 418", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9970), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, 2 },
                    { 419, new Guid("8d191a32-17fe-4193-8148-3d3cce5cadcb"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.419", "Vehicle 419", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9973), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, 2 },
                    { 420, new Guid("68b21a83-edf3-4f30-820c-ab88ee0a67b3"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9975), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.420", "Vehicle 420", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9976), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, 2 },
                    { 421, new Guid("bff583ce-6d91-4dec-aada-cce9979772c1"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9979), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.421", "Vehicle 421", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9979), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, 2 },
                    { 422, new Guid("49ad69ba-9b4b-457a-89b3-8125b8b14f6b"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9982), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.422", "Vehicle 422", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9983), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, 2 },
                    { 423, new Guid("5add534c-8843-4bb7-921a-e7dd56f101d8"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9987), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.423", "Vehicle 423", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9987), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, 2 },
                    { 424, new Guid("59fbc445-b501-44f1-9bc9-21a1be50161f"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9990), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.424", "Vehicle 424", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9991), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, 2 },
                    { 425, new Guid("a34b2621-0f58-44fa-b874-11361979fe16"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9994), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.425", "Vehicle 425", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9994), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, 2 },
                    { 426, new Guid("4a929a00-2bed-4847-8851-fb5f5d1b6946"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9997), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.426", "Vehicle 426", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9997), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, 2 },
                    { 427, new Guid("5fd03b8a-9380-45e8-84a7-5ada9306541f"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.427", "Vehicle 427", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(1), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, 2 },
                    { 428, new Guid("cc332b11-6013-4220-a145-5187a8ae7c5e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(3), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.428", "Vehicle 428", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(4), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, 2 },
                    { 429, new Guid("0ca47f76-c230-454f-8cb8-1ab43b18391a"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(8), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.429", "Vehicle 429", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(8), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, 2 },
                    { 430, new Guid("1652c681-e0dc-45a8-b9e4-44110f05feca"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(11), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.430", "Vehicle 430", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(12), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, 2 },
                    { 431, new Guid("34bb5bae-96ab-45ba-9d49-d4cc653fd262"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(16), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.431", "Vehicle 431", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(16), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, 2 },
                    { 432, new Guid("a8ba1f43-65f3-4365-a031-30a88c4a0119"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(19), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.432", "Vehicle 432", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(20), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, 2 },
                    { 433, new Guid("ae49b038-ea4f-4cb8-91df-5963524897da"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(22), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.433", "Vehicle 433", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(23), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, 2 },
                    { 434, new Guid("222d162c-7cda-4159-b508-0cb3aa7ce04d"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(26), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.434", "Vehicle 434", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(26), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, 2 },
                    { 435, new Guid("2812ca3e-de88-4e16-8507-144d7eda7442"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(29), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.435", "Vehicle 435", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(29), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, 2 },
                    { 436, new Guid("8e9adbb2-549c-45a0-b8a1-943aa87fc699"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(32), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.436", "Vehicle 436", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(33), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, 2 },
                    { 437, new Guid("a02bad21-cd05-412a-b497-fd8ed5ef558f"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(36), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.437", "Vehicle 437", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(36), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, 2 },
                    { 438, new Guid("79593a78-1eaa-4509-a4ee-8d57de4b6266"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(39), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.438", "Vehicle 438", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(39), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, 2 },
                    { 439, new Guid("65f3e7a6-0f31-4e73-aea0-6eb7b94aaf42"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(44), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.439", "Vehicle 439", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(44), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, 2 },
                    { 440, new Guid("166b019f-57fd-40d9-8d17-4ab760e7cd9b"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(73), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.440", "Vehicle 440", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(74), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, 2 },
                    { 441, new Guid("e68bcd19-babc-4b38-beec-03e78dd0e7a1"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(77), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.441", "Vehicle 441", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(77), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, 2 },
                    { 442, new Guid("720b0206-9b5a-4892-8c99-2ea5b8db9675"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(80), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.442", "Vehicle 442", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(81), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, 2 },
                    { 443, new Guid("82c03f6b-ad9a-4422-adcd-9fb6a13d6f1f"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(83), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.443", "Vehicle 443", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(84), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, 2 },
                    { 444, new Guid("eec50866-12b0-43cd-8ec0-db2fe7976960"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(86), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.444", "Vehicle 444", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(87), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, 2 },
                    { 445, new Guid("c41fb107-feed-4492-9f48-d3f0bfe8edbf"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(90), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.445", "Vehicle 445", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(90), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, 2 },
                    { 446, new Guid("2f2ee04f-9f2e-446e-bfd8-dd97308b404f"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(93), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.446", "Vehicle 446", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(93), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, 2 },
                    { 447, new Guid("4ad6b3d8-6133-4418-9263-294aa9e5fa98"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(98), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.447", "Vehicle 447", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(98), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, 2 },
                    { 448, new Guid("3f18b396-c11b-4c51-a083-6004686d730b"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(101), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.448", "Vehicle 448", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(102), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, 2 },
                    { 449, new Guid("1ca6569f-201c-45fe-9b04-c8680becc1c3"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(104), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.449", "Vehicle 449", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(105), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, 2 },
                    { 450, new Guid("20b073e2-3037-407c-9edf-8aa25e608df0"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(108), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.450", "Vehicle 450", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(108), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, 2 },
                    { 451, new Guid("af2d838b-9e8b-47dd-892d-ffe3c7b562cc"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(111), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.451", "Vehicle 451", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(111), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, 2 },
                    { 452, new Guid("786dcf8b-3bec-430d-b190-a5ddc8c8a7fc"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(114), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.452", "Vehicle 452", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(115), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, 2 },
                    { 453, new Guid("436683dc-9439-44d4-b402-8a7158a5d8c0"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(117), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.453", "Vehicle 453", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(118), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, 2 },
                    { 454, new Guid("a6ae5b4f-ec8e-4b71-aa88-8bad5d3bfef4"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(120), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.454", "Vehicle 454", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(121), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, 2 },
                    { 455, new Guid("1f70ef95-9dda-4b87-b583-89cee25c0e6c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(125), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.455", "Vehicle 455", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(126), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, 2 },
                    { 456, new Guid("c5437cfb-13a8-495f-a43c-d0127f26c474"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.456", "Vehicle 456", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(129), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, 2 },
                    { 457, new Guid("6a23d442-ac40-4dca-887d-d223627e442c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(132), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.457", "Vehicle 457", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(132), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, 2 },
                    { 458, new Guid("ec93b4ac-1b36-49fc-8b9d-374425af2ea3"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(135), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.458", "Vehicle 458", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(136), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, 2 },
                    { 459, new Guid("2cff355c-d335-46eb-a990-99923d44565d"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(138), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.459", "Vehicle 459", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(139), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, 2 },
                    { 460, new Guid("c7b0f6bf-582c-4eb6-aefb-faba10db05b1"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(141), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.460", "Vehicle 460", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(142), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, 2 },
                    { 461, new Guid("084cc86f-8e78-478a-a7a9-0ca3bb737858"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(146), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.461", "Vehicle 461", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(146), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, 2 },
                    { 462, new Guid("d324acc4-fcb6-4ad7-a082-2c75d98d5739"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(149), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.462", "Vehicle 462", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(150), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, 2 },
                    { 463, new Guid("5475fec9-e5bc-489e-8aad-1c038f348e3e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(154), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.463", "Vehicle 463", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(155), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, 2 },
                    { 464, new Guid("ee62b4d7-b528-4727-bd94-89d82da6c46e"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(157), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.464", "Vehicle 464", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(158), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, 2 },
                    { 465, new Guid("3e00e151-0ef8-4ab8-a070-805fc39cb4cc"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(161), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.465", "Vehicle 465", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(161), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, 2 },
                    { 466, new Guid("2aa777c4-2dc4-4d47-9103-eb4a2a577173"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(164), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.466", "Vehicle 466", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(164), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, 2 },
                    { 467, new Guid("eaea93ae-a579-4556-8a5e-5df4317d5e44"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.467", "Vehicle 467", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(168), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, 2 },
                    { 468, new Guid("77c223ac-3b52-4f60-8fee-b694c0a27105"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.468", "Vehicle 468", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(171), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, 2 },
                    { 469, new Guid("a7d66d58-dc93-4bca-afe8-cc712710bad2"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.469", "Vehicle 469", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(174), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, 2 },
                    { 470, new Guid("93e5aaac-46b9-4ff7-8014-bb5b0c43b02f"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(203), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.470", "Vehicle 470", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(204), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, 2 },
                    { 471, new Guid("d0cf25ad-f6b3-4707-b2b4-8786e1c54f9f"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(208), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.471", "Vehicle 471", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(209), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, 2 },
                    { 472, new Guid("9a1e1ac0-552c-494f-998b-4c6653b0a434"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(212), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.472", "Vehicle 472", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(212), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, 2 },
                    { 473, new Guid("04bbbaa5-db18-4b88-a56f-0a7ed10e5145"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(215), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.473", "Vehicle 473", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(215), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, 2 },
                    { 474, new Guid("6c77e53c-f7d2-49cd-8268-cec1eee7b88f"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.474", "Vehicle 474", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(219), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, 2 },
                    { 475, new Guid("6d5195d2-0ff5-4fff-898b-1fd55f0c2f70"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(221), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.475", "Vehicle 475", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(222), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, 2 },
                    { 476, new Guid("5a57818d-e026-4afb-a9f7-52901e83655d"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(224), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.476", "Vehicle 476", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(225), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, 2 },
                    { 477, new Guid("9a04a10f-0b4a-4ab0-8f2f-65cf0331546a"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.477", "Vehicle 477", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(228), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, 2 },
                    { 478, new Guid("e82b44bc-336c-4f0b-9d5b-f69ddaa7c927"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(231), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.478", "Vehicle 478", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(232), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, 2 },
                    { 479, new Guid("340cacc7-761c-499a-8958-2084a8180c33"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(236), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.479", "Vehicle 479", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(237), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, 2 },
                    { 480, new Guid("306c246e-2b99-4e32-940a-c3fa2977a188"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(239), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.480", "Vehicle 480", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(240), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, 2 },
                    { 481, new Guid("cb187a6a-e3b8-4f74-af3d-dc962f0a47fe"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(243), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.481", "Vehicle 481", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(243), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, 2 },
                    { 482, new Guid("6b4300bb-d373-4591-b903-1f9c3b466b4d"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(246), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.482", "Vehicle 482", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(246), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, 2 },
                    { 483, new Guid("eddf2ce0-521b-45b8-832c-e1a58256a91f"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(249), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.483", "Vehicle 483", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(250), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, 2 },
                    { 484, new Guid("5468262b-62db-44e8-a5fc-c9128c2d42c9"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(252), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.484", "Vehicle 484", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(253), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, 2 },
                    { 485, new Guid("43839cdf-afb4-4ffb-b72a-1b885c7b1d05"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.485", "Vehicle 485", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(256), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, 2 },
                    { 486, new Guid("362f2457-09b4-4daa-963a-789cefeb07a4"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(259), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.486", "Vehicle 486", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(259), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, 2 },
                    { 487, new Guid("81282ebb-7a5d-4277-bca7-7658fc25285f"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(264), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.487", "Vehicle 487", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(264), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, 2 },
                    { 488, new Guid("f828bd05-6a9f-4ff9-a7e7-3226fa1aec62"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.488", "Vehicle 488", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(267), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, 2 },
                    { 489, new Guid("9042e8a4-5e74-44aa-b003-7de17b5a02bf"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(270), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.489", "Vehicle 489", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(271), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, 2 },
                    { 490, new Guid("e8b057bd-3efa-423c-ba91-84effd880be6"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.490", "Vehicle 490", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(274), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, 2 },
                    { 491, new Guid("bf3c4044-db49-4fd8-a89d-ce9d327d695c"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(277), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.491", "Vehicle 491", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(277), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, 2 },
                    { 492, new Guid("f0f7c89a-1ba9-4dd7-a995-c202f75ed758"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(280), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.492", "Vehicle 492", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(280), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, 2 },
                    { 493, new Guid("e54f840d-51ba-41c6-8843-883c99361f94"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(283), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.493", "Vehicle 493", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(284), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, 2 },
                    { 494, new Guid("a5f60af5-0872-40f0-a7fb-3ba0781fce76"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(286), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.494", "Vehicle 494", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(287), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, 2 },
                    { 495, new Guid("481f8e93-38c8-46cb-93aa-b7957965b855"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(291), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.495", "Vehicle 495", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(292), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, 2 },
                    { 496, new Guid("3e5adb75-81b2-4fc9-9825-c1c99ad1f934"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(294), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.496", "Vehicle 496", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(295), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, 2 },
                    { 497, new Guid("1cd15739-2856-46ea-a4b0-bdc89fa3eb35"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(298), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.497", "Vehicle 497", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(298), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, 2 },
                    { 498, new Guid("f127ba88-45eb-47b6-951a-5e9986dafa2d"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(301), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.498", "Vehicle 498", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(302), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, 2 },
                    { 499, new Guid("500675a5-4183-4af7-81c9-fec650a4a48f"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(304), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.499", "Vehicle 499", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(305), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, 2 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4942), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4952), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4953), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4962), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4969), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4970), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4977), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4978), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4986), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4987), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4994), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(4994), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5001), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5002), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5008), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5009), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5047), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5048), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5057), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5058), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5064), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5065), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5072), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5072), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5079), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5080), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5088), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5088), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5095), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5095), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5102), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5103), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5111), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(5112), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "ceiling_extra_price", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9702), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9703), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9743), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9743), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9751), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9751), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9758), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9758), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9765), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9765), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9772), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9773), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9780), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9780), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9787), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9787), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9794), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9794), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9801), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9802), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9808), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9809), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9815), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9816), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9822), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9822), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8894), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(8895), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9014), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9015), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9095), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9095), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9121), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9121), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9139), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9139), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9153), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9154), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9167), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

            migrationBuilder.InsertData(
                table: "user_licenses",
                columns: new[] { "id", "back_side_file_id", "code", "created_at", "created_by", "deleted_at", "front_side_file_id", "license_type_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 15, "c42a9d4b-aadf-414c-8928-8b8a58f90c1d", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(918), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 14, 1, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(919), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 17, "8d1b91c5-9023-4fc6-89ce-2b278aede2bf", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(935), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 16, 2, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(936), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, 19, "859b56e8-a590-44d2-83f5-d903f8068911", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(946), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 18, 3, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(946), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, new Guid("eaa98710-ea66-45a5-8d35-ce8661e39a1f"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9852), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9852), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("42f08d44-fe11-4669-b375-c510e1d3818a"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9856), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9857), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("7604d8a8-dd87-4415-9ab4-4511ccdd6e86"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9858), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9859), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("4bb0474a-7874-4309-9c55-a5d8d62f0b4d"), new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9862), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 49, DateTimeKind.Unspecified).AddTicks(9863), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "type", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 0.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(423), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(423), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 0.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(427), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(428), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 0.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(429), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(430), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 0.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(431), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(431), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 0.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(432), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(433), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 0.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(435), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(436), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 0.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(437), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(437), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 0.0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(438), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, 0, new DateTimeOffset(new DateTime(2022, 12, 2, 15, 54, 29, 50, DateTimeKind.Unspecified).AddTicks(439), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
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
