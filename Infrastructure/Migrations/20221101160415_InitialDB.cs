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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("8b9a8758-aed3-4621-ad46-e38ed1bae77e")),
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
                    last_seen_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 28, DateTimeKind.Unspecified).AddTicks(6468), new TimeSpan(0, 7, 0, 0, 0))),
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
                    code = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("f5208569-19b5-40e0-8740-91f483fd1cf4")),
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
                    { 1, new Guid("363f3ff4-7ca4-40e9-8027-9a0df0d00101"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(437), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Momo", 0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(438), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("ce8f5b02-03d4-4122-9d71-31120aad9abf"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(446), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "VNPay", 0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(447), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("1575801a-00da-47d2-ae85-3a80ef403d69"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(449), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ZaloPay", 0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(450), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "path", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("3e9a18c3-49d7-40d8-8013-11334aaea7d5"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8751), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8772), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("c71747ea-0e0a-4008-aba9-42619b600dc9"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8788), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8788), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("378519a8-d779-43fd-93a9-412e98406680"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8799), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8800), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("59504abb-9941-4aba-a7b6-7e9c878c9837"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8810), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8811), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("da09b79e-2171-417f-9b77-572edcfb522b"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8820), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8821), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("2a159882-dcc9-4cd4-a646-bf12f74150eb"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8848), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("fd74772f-269f-41aa-9155-48618b0081d6"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8907), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8908), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("91e49335-b4bf-426e-859d-5ae5562a5e5d"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8920), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8921), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("4dbbe867-b498-4888-b351-6a8dcfe7fd44"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8931), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/285640182_5344668362254863_4230282646432249568_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8932), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, new Guid("36ee1dd1-7c2d-47fe-83c8-8c634d7930a1"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8943), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/292718124_1043378296364294_8747140355237126885_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8944), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("6644060a-7077-4700-928b-e2c21b24ea34"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8955), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("051edbf3-bb84-44cd-b60a-eff5c0b1d74d"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8964), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "promotion/300978304_2290809087749954_8259423704505319939_n.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8965), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, new Guid("9cfce33e-7f07-4b12-9efb-6782a77e1f25"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "user/avatar/default-user-avatar.png", true, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(8975), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "pricings",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "discount", "lower_bound", "updated_at", "updated_by", "upper_bound" },
                values: new object[,]
                {
                    { 1, new Guid("de6bee03-502e-489f-8a6c-4b93e78c55b3"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(513), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.0, null, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(513), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 2, new Guid("7567b656-8b1a-49df-8700-9a767021b7cc"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(525), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.029999999999999999, 8, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(526), new TimeSpan(0, 7, 0, 0, 0)), 0, 30 },
                    { 3, new Guid("28770bf3-66c3-44cd-acd6-22a7cb3dd695"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(528), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.050000000000000003, 31, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(529), new TimeSpan(0, 7, 0, 0, 0)), 0, 90 },
                    { 4, new Guid("7749e2b5-1d86-40ad-a3b7-cc8d5e4dab13"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(531), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 0.070000000000000007, 91, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(532), new TimeSpan(0, 7, 0, 0, 0)), 0, null }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 3, "HOLIDAY", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8484), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.", 0.29999999999999999, null, 300000.0, "Holiday Promotion", 1, 0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8484), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "ABC", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8492), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.", 0.10000000000000001, null, 300000.0, "ABC Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8493), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "VIRIDE2022", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8501), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViRide: Discount 10% with max decrease 100k for the booking with minimum total price 300k.", 0.10000000000000001, null, 100000.0, "ViRide Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8502), new TimeSpan(0, 7, 0, 0, 0)), 0 }
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
                    { 1, "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương", new Guid("1d958899-f0d3-4527-b9b2-679d4a9f1cb7"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8941), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879650683124561, 106.81402589177823, "Ga Metro Bến Xe Suối Tiên", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8942), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c3cd7dc4-2829-49fc-8843-7d98f9c0be97"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8948), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.8664854431366, 106.80126112015681, "Ga Metro Đại học Quốc Gia", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8949), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c7544d8c-ca4a-43d7-bc24-0f93d3ea74d9"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8952), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.85917304306453, 106.78884645537156, "Ga Metro Công Viên Công Nghệ Cao", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8952), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d18f4430-5805-4f65-be37-ff85f096178e"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8955), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.846402468851362, 106.77154946668446, "Ga Metro Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8956), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("929667df-69bc-4230-9472-0144e7e35b82"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8958), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821402021794112, 106.75836408336727, "Ga Metro Phước Long", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8959), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b0b2e566-1c75-4987-ba90-0f075fea6c41"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8963), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.808505238748038, 106.75523952123311, "Ga Metro Gạch Chiếc", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8964), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ff0b0b78-cf64-48d3-841e-95e1169f5023"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8966), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802254217820691, 106.74223332879555, "Ga Metro An Phú", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8967), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("30b44b88-dbc5-4486-a11f-8da49dbb5b8d"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8969), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.800728306627473, 106.73370791313042, "Ga Metro Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8969), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam", new Guid("ff976246-a43d-4c91-afc2-d6b0ba57b2e7"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798621063183687, 106.72327125155881, "Ga Metro Tân Cảng", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8975), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("59d4cad5-7b41-4811-a9b1-fcdd600778ac"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8978), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.796160596763055, 106.71548797723645, "Ga Metro Khu du lịch Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8979), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bbd1a6f7-0928-4c56-8356-ae54dc11d32b"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8981), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836558412392224, 106.76576466834388, "Ga Metro Bình Thái", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8982), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f685cf45-501c-4e2c-b866-6cf0bdec28e5"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8984), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855748533595877, 106.78914067676806, "AI InnovationHub", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8985), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5f2c6382-919c-4726-b5bf-1d31ddcd9df3"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8987), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853144521692798, 106.79643313765459, "Tòa nhà HD Bank", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8987), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 14, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh ", new Guid("844046bb-98bd-429c-bfdc-4eb8061efb92"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8990), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851138424399943, 106.79857191639908, "FPT Software - Ftown 1,2", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8991), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 15, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("24f28b88-fcb4-428c-b4ba-b7af167a824d"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8994), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.842755223277589, 106.80737654998441, "Tòa nhà VPI phía Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8994), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 16, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("69214567-8b6c-4756-810f-607a98e79784"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8996), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.841160382489567, 106.80898373894351, "Viện công nghệ cao Hutech", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8997), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 17, "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c3de8d88-8dad-4140-a72b-0ed86148ea46"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9004), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836238463608794, 106.814245107947, "Cổng Jabil Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9004), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 18, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("0d5628b2-df5f-4031-b4ee-4082abf18cb9"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9008), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832233088594503, 106.82046132230808, "Saigon Silicon", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9008), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 19, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("100def9d-24ac-4148-9ed0-c5916b4e7d7e"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9010), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.836776238894464, 106.81401100053891, "ISMARTCITY (ISC)", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9011), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 20, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("28309854-b953-4024-8137-609b137dca0b"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9013), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840578398658391, 106.8099978721756, "Trường đại học FPT", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9014), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 21, "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f4a1f344-d629-405e-959e-f6f88abe25fa"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9016), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.84578835745819, 106.80454376198392, "Công Ty CP Công Nghệ Sinh Học Dược Nanogen", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9017), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 22, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("837c6dc6-c6fe-4ec6-b4ad-60d358ae3a9e"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9019), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.853375488919204, 106.79658230436019, "Intel VietNam", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9019), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 23, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1a0c0a97-d2e7-4d1c-9d3a-0900e08f7435"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9024), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854860900718421, 106.79189382870402, "CMC Data Center", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9025), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 24, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("24daeb9d-9f9a-4414-ba8b-f2404fb7d53b"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9030), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.856082809107784, 106.78924956530844, "Inverter ups Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9030), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 25, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d6c2e952-abf8-41e7-9ddb-134590371fbb"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9032), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.838027429470513, 106.81035219090674, "Trường đại học Nguyễn Tất Thành", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9033), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 26, "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5d25b1a4-eaa4-4fa8-a05a-b42e92347ec8"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9036), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834922120966135, 106.80776601621393, "FPT Software - Ftown 3", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9037), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 27, "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b1173b81-915a-45e0-b419-208d96b7bec5"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9039), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.834215900566933, 106.80727419233645, "Công ty Cổ phần Hàng không VietJet", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9040), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 28, "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("18b35fe5-202f-4bd4-9578-709dfaba9cc3"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9042), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.832245246386895, 106.80598499131753, "Sài Gòn Trapoco", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9042), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 29, "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("afb31709-f0f4-46cc-a404-33d4d5e821a1"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9044), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830911650064834, 106.80503995362199, "Công ty kỹ thuật công nghệ cao sài gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9045), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 30, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f7d9d1e4-3ace-481a-b74c-ae48d5f728b1"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9085), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825858875527519, 106.79860212469366, "Nhà máy Samsung Khu CNC", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9085), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 31, "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8bec9c01-e79c-4a34-b924-e28cd61b941f"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9088), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.826685687856866, 106.8001755286645, "Công ty công nghệ cao Điện Quang", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9089), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 32, "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b93b4c7b-5c18-4c10-b1b1-61fde54a8974"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9093), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829932294153192, 106.80446003004153, "Công ty Thảo Dược Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9094), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 33, "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9e4ca5b1-aba3-4387-8572-60ec92fe4d6a"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9097), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830577375598693, 106.80512235256614, "Công ty Daihan Vina", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9098), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 34, "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7ee6c998-859c-4787-b54c-915a9fa01d61"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9100), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.867306661370069, 106.78773791444128, "Trường Đại học Nông Lâm", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9101), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 35, "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("430a5d25-49cb-496c-af77-5702299d867c"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9103), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.869235667646493, 106.77793783791677, "Trường đại học Kinh Tế Luật", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9104), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 36, "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("f2424359-8dfa-4c7f-9ec3-50d2a5236c24"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9106), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.871997549994893, 106.80277007274188, "Đại học Khoa học Xã hội và Nhân văn", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9106), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 37, "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương", new Guid("69517229-5a65-4071-8598-afd62d3f0643"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9108), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875092307642346, 106.80144678877895, "Nhà Văn Hóa Sinh Viên ĐHQG", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9109), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 38, "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d0fc2428-217c-4629-be36-a7592a8eeef8"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9111), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870481440652956, 106.80198596270417, "Cổng A - Trường đại học Công Nghệ Thông Tin", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9112), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 39, "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("4e5fbab2-f110-40d5-b0df-21d77d8081b3"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9114), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.870503469555034, 106.79628492520538, "Trường đại học Thể dục Thể thao", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9115), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 40, "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("b6c73541-b79d-4e51-83d3-bc731c0a5d13"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9119), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.875477130935243, 106.79903376051722, "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9120), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 41, "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e919f740-a891-44da-b033-61eef6208dda"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9122), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.876446815885343, 106.80177999819321, "Trường đại học Quốc Tế", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9123), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 42, "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("e8298d6f-9d8d-4c9b-bce5-60319bc5b089"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9125), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.878197830285536, 106.80614795287057, "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9125), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 43, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("3e16ab85-0ee4-4081-a083-f8a22a85c85a"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9127), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.879768516539494, 106.80697880277312, "Trường đại học Bách Khoa (cơ sở 2)", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9128), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 44, "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương", new Guid("c4da7a14-d92e-4b2b-af4d-98b1ec2d5419"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9130), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.877545337230165, 106.80552329008295, "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9131), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 45, "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("71867e6e-18cf-463e-a7e6-7589acea3495"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9133), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.849721027334326, 106.77164269167564, "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9133), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 46, "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9f1b1368-f509-423c-b6d3-c1416856fc19"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9135), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.851623294286195, 106.7599477126918, "Trường Cao đẳng Công nghệ Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9136), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 50, "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("36e3496d-1cbe-447e-b688-6721dbd469cd"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9138), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.852653003274197, 106.76018734231964, "Trung tâm thể dục thể thao Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9139), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 51, "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d3444fce-380e-4c14-b5c0-a80026294a84"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9143), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854723648720167, 106.76032173572378, "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9144), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 52, "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("08d0199f-480f-4e69-860a-d5b2baa58a6f"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9148), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.855800383594074, 106.76151598927879, "Trường đại học Ngân hàng", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9148), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 53, "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9c016607-14e7-4947-ae75-a31f24186f00"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9150), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.83090741994997, 106.76359240459003, "Trường đại học Điện Lực", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9151), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 54, "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("59dea89c-0710-4571-8cad-68d2f14440b7"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9153), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.831781684548069, 106.76462343340792, "Metro Star - Quận 9 | Tập đoàn CT Group+", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9154), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 55, "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("d543190f-8834-4005-b94c-1e4521f7974b"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9156), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.830438851236304, 106.76388396745739, "Chi nhánh công ty CyberTech Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9157), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 56, "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("97ba7c18-b539-4347-93d1-9658110f2a26"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9159), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.829834904338366, 106.76426274528296, "Zenpix Việt Nam", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9159), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 57, "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("24c3e310-b0e2-4527-a6e4-58449e572fe2"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9161), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840946385700587, 106.76509820241216, "Nhà máy sữa Thống Nhất (Vinamilk)", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9162), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 58, "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("950eb491-c337-4f11-8e90-ef5e1c8a589d"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9164), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840432688988782, 106.76088713432273, "Công ty xuất nhập khẩu Tây Tiến", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9165), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 59, "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("6f865e2c-44ee-4354-9d6d-4d953184c3e9"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9170), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.844257732572313, 106.76276736279874, "Trung tâm tiêm chủng vắc xin VNVC", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9170), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 60, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("02aec5fb-8990-4663-b330-1ee35f562199"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.825780208240717, 106.75924170740572, "Công ty cổ phần Thép Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9173), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 61, "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("63b05250-63f3-48aa-b323-e591f841de94"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9175), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82825779372371, 106.76092968863129, "Công Ty Cổ Phần Cơ Điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9176), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 62, "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("915442df-1823-495c-a1c8-212bf1b6c413"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9178), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827423240919156, 106.75761821078893, "Công ty TNHH Nhiệt điện Thủ Đức", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9179), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 63, "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("bdc208e3-d6ed-41bd-88b1-8d342f2e1040"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9181), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.827933659643358, 106.75322566624341, "Cảng Trường Thọ", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9181), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 64, "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ecd19b2a-e117-4a9e-8254-0866a18efaa7"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9184), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82037580579453, 106.75928223003976, "Công ty TNHH BeuHomes", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9184), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 65, "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("58c47d8e-6b9f-46fe-8e52-85817a9d7420"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9186), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.821744734671684, 106.76019934624064, "Công ty TNHH Creative Engineering", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9187), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 66, "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("467ae109-2ee3-4b06-a934-798459c5909d"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9189), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.82220109625001, 106.75952721927021, "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9190), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 67, "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("1f157392-97a2-406c-9f0c-946f159dab74"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9195), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805200229819087, 106.75206770837505, "Golfzon Park Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9195), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 68, "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a715dc93-0c57-4835-b6bc-5e88a63cdda0"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9199), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803332925851043, 106.7488580702081, "Saigon Town and Country Club", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9199), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 69, "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("c51ace6e-dd41-4cfd-9ef3-ed6c8bcad1f7"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9238), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804563036954756, 106.74393815975716, "The Nassim Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9239), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 70, "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("674a415e-5f28-4404-9887-e69367cb1116"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9241), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.807262850388623, 106.74530677686282, "Blue Mangoo Software", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9242), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 71, "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("7112fbc5-1832-4546-a95e-d8f8078c5099"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9244), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.805401459108982, 106.73134189331353, "Trường Đại học Văn hóa TP.HCM - Cơ sở 1", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9244), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 72, "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3f5c2649-1ae2-466d-ade2-78232949f278"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9246), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806048021383644, 106.72928364712546, "Trường song ngữ quốc tế Horizon", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9247), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 73, "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("5113a905-7891-434e-b7d7-258de83e82fb"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9249), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.809270864831371, 106.72846844993934, "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9250), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 74, "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh", new Guid("25f87533-7ff3-4571-b790-2881b1e21bb0"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9252), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806246963358644, 106.72589627507526, "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9253), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 75, "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("3eaa6e34-29f3-4c1e-aae2-734c3b9ee862"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9258), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.803458791026568, 106.72806621661472, "Trường đại học Quốc Tế Thành phố Hồ Chí Minh", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9258), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 76, "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("72a9c8bd-9020-44d6-9ee2-fc8898f35d8d"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9260), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.797897644669561, 106.73143206816108, "SCB Trần Não - Ngân hàng TMCP Sài Gòn", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9261), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 77, "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("209e1588-8d55-41f6-b013-ec5f361622e5"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9263), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.793905585531592, 106.7293406127999, "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9264), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 78, "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("fa8cb894-f12e-4826-86ad-610d2434b55b"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.789891277804319, 106.72895399848618, "Tòa nhà Microspace Building", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9266), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 79, "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("401e19b3-8806-4926-9ef0-766fc5efb2f4"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9268), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786711346588366, 106.72783903612815, "Công ty TNHH vận tải - thi công cơ giới Xuân Thao", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9269), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 80, "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("a06ddda5-cf76-43e1-9e65-9303ba9780a3"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9271), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.780549913195312, 106.72849002239546, "Công Ty TNHH Ch Resource Vietnam", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9272), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 81, "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("9c26c87f-7991-40c8-a444-cf39081c65be"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9274), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.786744237747117, 106.72969521262236, "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9275), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 82, "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("ae3ac2a8-854a-4932-8fb0-6890ea2b58ed"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9277), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.792554668741762, 106.73067177064897, "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9277), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 83, "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("b332fbb9-f381-4100-8db1-f394860261e9"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9282), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.798737294717368, 106.72126763097279, "Tòa Nhà Melody Tower, Cty Toi", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9283), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 84, "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("8e63c566-1716-4e57-8028-1a9b3845d0cc"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9285), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.799795706410299, 106.71843607604076, "Pearl Plaza Văn Thánh", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9286), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 85, "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("df4d6dec-5351-45a6-bd35-1ad51a5dd0a6"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9288), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.802303255825205, 106.71812789316297, "Căn hộ Wilton Tower", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9289), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 86, "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("b97ed1b9-8532-4509-9bca-15b235d25714"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9291), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.804470786914793, 106.7167285754774, "Trường đại học Giao Thông Vận Tải", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9291), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 87, "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh", new Guid("fab03010-400d-4c2e-97b5-affb9680cb99"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9293), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.806564326384949, 106.71296786250547, "Trường Đại học Ngoại thương - Cơ sở 2", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9294), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 88, "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", new Guid("8fdcaba6-e25e-43c4-9e06-02df072a10b6"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9021), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.854367872934622, 106.79375338625633, "Nidec VietNam", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9022), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 89, "Lô E2a-10 Đường, D2b Đ. D1, TP. Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam", new Guid("6998191d-dbd0-480d-8964-1aa37e0536d2"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9296), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10.840147321061634, 106.81262497275418, "Vườn ươm doanh nghiệp Công Nghệ Cao - SHTP", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9297), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 10, new Guid("552142dd-fb52-48bf-a7ce-13cde3826dbc"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9206), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9207), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, new Guid("915757ce-5f23-42b7-bb2d-3525ccd1cb6e"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9223), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9224), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, new Guid("fd8bcf04-f220-4b37-b2ec-9e25d9dfc8ef"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9236), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Admin Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9237), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 100, new Guid("8e32ccad-c386-4403-85a6-e1d17decb18e"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9255), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 100", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9256), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 101, new Guid("d041ac09-7acf-4b93-ad56-aecbcde7db07"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9313), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 101", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9314), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 102, new Guid("f953182d-2952-4031-a567-bb5485163059"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9329), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 102", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9330), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 103, new Guid("5b18f77a-b53d-45dd-a53d-c64266e1355b"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9344), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 103", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9345), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 104, new Guid("c2ac5b64-72a4-49bb-8f83-387321bc9c01"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9363), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 104", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9364), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 105, new Guid("954c3275-ae94-44b2-92ab-194dcef7c5b0"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 105", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9381), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 106, new Guid("862ac62d-a01d-47cf-a05a-a57b1047c1f7"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9396), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 106", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9397), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 107, new Guid("24cd0eda-0861-4939-afbb-425b5022e539"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9410), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 107", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9411), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 108, new Guid("c36153a2-92be-44f0-8403-87cbdb84c2b2"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9428), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 108", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9429), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 109, new Guid("6890876d-b45c-4704-aeda-b48b4f20290e"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9502), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 109", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9503), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 110, new Guid("3f1535cb-bdb1-4a40-9945-ed92c7e97685"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9521), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 110", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9522), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 111, new Guid("4b76b73a-e5a9-473a-add8-5d85ea4160e1"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9536), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 111", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9537), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 112, new Guid("58debf0f-9250-487b-b60b-874b78bd2635"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9554), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 112", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9555), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 113, new Guid("32e75119-7e75-4dd0-905e-d4152325659e"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9570), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 113", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9571), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 114, new Guid("d7dec6cf-2dae-4f50-b3bb-f2e11ceb1a43"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9585), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 114", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9586), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 115, new Guid("d595d241-ffd5-42bf-889d-d3a408164ad1"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9600), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 115", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9601), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 116, new Guid("6cc71caf-a2eb-47e6-b60c-19694335d508"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9618), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 116", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9619), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 117, new Guid("cf3b18b6-5160-461d-941f-4af1ec97f551"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9634), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 117", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9635), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 118, new Guid("64b2ea76-c07a-4074-92be-d257ee946328"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9649), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 118", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 119, new Guid("cc3c3184-d5e0-4d42-954e-592453322176"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9664), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 119", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9665), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 120, new Guid("59986709-eeb9-4155-ae09-dc68a226a035"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9681), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 120", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9683), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 121, new Guid("753b830b-e532-4d58-a4ce-40381ab4367d"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9734), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 121", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9736), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 122, new Guid("d0a6617d-05b0-4b44-bee8-73b7ac3d521e"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9752), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 122", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9753), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 123, new Guid("9523a4c6-43ab-4852-ba90-c6051628cced"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9767), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 123", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9768), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 124, new Guid("28f0c3a1-16d5-4fc8-8282-b171f829bffa"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9784), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 124", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9785), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 125, new Guid("a5ed44e5-2e1a-4629-b3d9-2fb20054f15e"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9800), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 125", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9801), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 126, new Guid("6e709591-541c-43fa-9940-b5a01c0f40ef"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9815), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 126", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9816), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 127, new Guid("054e9936-5432-4244-ba77-d3dbe7cfe128"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9830), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 127", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9831), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 128, new Guid("76a86fe9-6c79-4322-9e20-3de0c81544ef"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 128", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9848), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 129, new Guid("841da922-0c71-4ba9-a7e0-7fa482e3393c"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9863), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 129", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9864), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 130, new Guid("503fa7eb-7a15-40fa-8a00-4ebb18abcf6f"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9878), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 130", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9879), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 131, new Guid("b353795a-4d9c-43aa-a9b7-1f765dd359a4"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9893), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 131", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9894), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 132, new Guid("687c6a8a-9590-4818-bd35-071cd37ead8c"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9910), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 132", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9911), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 133, new Guid("3b8b5162-7ff5-4811-9a2e-51ee891742d7"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9926), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 133", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9927), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 134, new Guid("c7e0efc8-d8c4-4de7-a824-273498e30a4c"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9977), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 134", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9978), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 135, new Guid("19a92884-3cb7-4293-8430-04ae8345e726"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9994), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 135", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9995), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 136, new Guid("0cd77f64-6b11-4cb8-b9fc-212451032637"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(12), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 136", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(13), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 137, new Guid("23b55afe-b6b9-4e37-8b17-74e52b5bde9b"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(27), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 137", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(28), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 138, new Guid("e801f37b-ed4d-4456-a88e-2799007be877"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(42), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 138", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(43), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 139, new Guid("3d465318-2e14-457a-bf8a-2f328232b44a"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(57), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 139", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(58), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 140, new Guid("953942f1-af8c-4161-9c38-0c9341268be0"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(75), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 140", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(76), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 141, new Guid("d18a74fd-6f23-4a5e-ae33-9915ae1e3444"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(90), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 141", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(91), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 142, new Guid("632ed408-4958-4e55-9b5c-261ccd570a3f"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(105), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 142", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(106), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 143, new Guid("1711a254-72c7-4e26-b634-5636cf239fba"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(120), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 143", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(121), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 144, new Guid("bf6110c7-a0a4-4448-b7a4-ee4b89fc5f4a"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(137), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 144", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(138), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 145, new Guid("8d00fb80-4c72-4748-adf5-69cf5f86da90"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(152), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 145", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(153), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 146, new Guid("eafa2625-919b-4cbb-8a5c-6a51a9dc188e"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 146", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(168), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 147, new Guid("8491cbc1-5f9d-49fd-aaec-12e332f74340"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(237), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 147", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(239), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 148, new Guid("0f954adb-d9c5-4f07-878a-67bc46436881"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 148", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(259), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 149, new Guid("c21f611e-c9a3-4aa9-9d9c-50b5c78bfafb"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 149", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(274), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 150, new Guid("77cc17a5-8c0c-4742-9687-be3ed577d918"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(288), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 150", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(289), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 151, new Guid("1e67671b-bc2b-41cf-abe0-f5f1dfeed7f5"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 151", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(303), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 152, new Guid("63de0125-abc8-4c76-9658-2e5310d3870b"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(320), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 152", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(321), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 153, new Guid("f031d15e-84cc-4d2f-9bf6-cd7a494af4aa"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(338), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 153", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(339), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 154, new Guid("dbc14dbb-a3bf-493e-b713-074584d30e07"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(353), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 154", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(354), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 155, new Guid("3d16d9db-0796-4eec-80e1-6089b7f7efc0"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 155", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(369), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 156, new Guid("de2485bb-42fb-4e07-a8f9-da2f1978ae7a"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(385), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 156", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(386), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 157, new Guid("76d9e54a-8663-47e2-bdd4-c006a6c07713"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(401), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 157", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(402), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 158, new Guid("b178a973-afbb-4eeb-ad54-7bd34da8e0b0"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(456), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 158", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(457), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 159, new Guid("e739206d-af78-4a84-9139-2c1939cd8eb6"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(473), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 159", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(474), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 160, new Guid("9335c7e6-2e52-43b3-9770-e8b226b27b12"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(491), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 160", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(492), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 161, new Guid("41b8d7b1-0556-4389-a1c4-93d656ddc8c2"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(506), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 161", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(507), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 162, new Guid("3f3b1b42-38e0-43a0-a659-d9c97b85cfcd"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(522), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 162", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(523), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 163, new Guid("af217a3f-1d64-4ee8-8ee7-429d39963574"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(536), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 163", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(537), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 164, new Guid("d189b1bd-53a1-4476-a0ba-53c1fc383c96"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(554), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 164", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(555), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 165, new Guid("1b168dc7-0a3c-4fb5-adf1-bbc81764f9f4"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(570), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 165", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(571), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 166, new Guid("ddf2396d-1f83-4ea7-a1b1-bde3fc4b138a"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(585), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 166", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(586), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 167, new Guid("9854bc70-0456-4e41-acfd-73ccd3096e10"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(599), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 167", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(600), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 168, new Guid("f183c6f3-6fee-48c6-a1ad-b67e0a010a99"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(617), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 168", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(618), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 169, new Guid("c12ba794-095c-45a1-bcdf-93efd636185d"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(633), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 169", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(634), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 170, new Guid("33f1640e-0733-45bb-a621-567be155743e"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(648), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 170", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(649), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 171, new Guid("5cd1629c-c751-4a55-91f9-a3cec9485370"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(700), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 171", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(701), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 172, new Guid("55cbc76f-a0f4-4101-b25d-d07b522cf7d9"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(719), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 172", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(720), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 173, new Guid("bb785cdd-274a-4124-a13a-7b96233969d6"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(734), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 173", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(735), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 174, new Guid("86320e2e-6b0e-411a-9612-18c8c4baea96"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(749), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 174", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(750), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 175, new Guid("fc47e2d6-9ed8-4da9-8585-6121308b890a"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(764), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 175", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(765), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 176, new Guid("9ac3d18b-ea7a-41ea-a959-36a0111aa64c"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(782), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 176", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(783), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 177, new Guid("18bfa086-01ef-4eb6-9e4b-d6375a04c728"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(797), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 177", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(798), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 178, new Guid("a7b98a25-2fd5-4a2d-a663-613bbc36a02d"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(812), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 178", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(813), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 179, new Guid("8c38c79b-46f2-4f08-a7d3-2fff9d2559c0"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(827), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 179", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(828), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 180, new Guid("6100c653-13f9-488d-9b44-df00e50c3786"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(845), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 180", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(846), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 181, new Guid("97ad7aad-af2f-4f01-b25f-8eb4d1df51f4"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(860), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 181", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(861), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 182, new Guid("c13aca7c-3a98-4b13-ad3e-6ee96b79ddaa"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(874), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 182", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(875), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 183, new Guid("7499859c-6a95-45dc-ba5a-87cbad8fd88f"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(925), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 183", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(926), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 184, new Guid("0832f8b2-546f-49f8-a4ad-82c48b97e47f"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(945), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 184", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(946), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 185, new Guid("7bc87450-c6f4-4ae8-afd7-1ac7ad879165"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(961), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 185", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(962), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 186, new Guid("d64dac97-f254-46ad-95c8-b0ccf256587b"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(975), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 186", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(976), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 187, new Guid("4a4f28f9-21d2-457a-8343-fd0755d88d61"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(990), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 187", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(991), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 188, new Guid("e00096bf-dec0-43a9-9e25-64e597753232"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1008), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 188", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1009), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 189, new Guid("0a529572-2709-4ae6-a2b7-94c2e2be92aa"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1023), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 189", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1024), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 190, new Guid("620f0c4c-2365-4534-838b-7ba8144d3ad4"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1038), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 190", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1039), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 191, new Guid("e16a6e27-f987-46a1-9724-cd3061d4a754"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1053), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 191", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1054), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 192, new Guid("69afdd27-319f-4a42-81d5-1860c9622a87"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1071), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 192", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1072), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 193, new Guid("c0de62e1-f341-41d1-831d-01337c9c29b4"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1086), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 193", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1087), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 194, new Guid("03d03765-91c1-47f6-8989-30fa704f3cd6"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1101), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 194", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1102), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 195, new Guid("aba5d06d-67b5-4d44-8ac1-55de30e6b046"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1115), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 195", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1116), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 196, new Guid("95307ceb-af2d-4bd0-9a25-e87e5be1141b"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1186), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 196", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1187), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 197, new Guid("5c99fa0f-a377-4fdd-a5b3-e0c05957e9b6"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1205), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 197", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1206), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 198, new Guid("3dce4b39-de6f-4231-85a7-bb38231a44dc"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1221), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 198", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1222), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 199, new Guid("2dd7ec15-5b5f-4380-8764-d90dc9bf5205"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1235), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Booker 199", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1237), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 400, new Guid("64e2889e-9dce-4f8a-bc2c-37ff8c54921e"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1253), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 400", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1254), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 401, new Guid("c77dfc49-82e2-47a0-855f-58496e77f5f8"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1272), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 401", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1272), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 402, new Guid("ac3c74eb-19db-4cc5-ad42-2f3a5608884e"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1287), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 402", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1288), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 403, new Guid("12c7be7b-3001-4f88-bdbd-071c673633de"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1302), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 403", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1303), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 404, new Guid("41e634b9-3a66-42b5-ba0e-36a68a0ee962"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1320), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 404", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1321), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 405, new Guid("7428e720-ebc4-4f8f-a0e2-51b6b2f7020a"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1335), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 405", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1336), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 406, new Guid("5ac3087f-ae93-45c4-b946-2ef06dadd5ee"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1350), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 406", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1351), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 407, new Guid("89481cec-c8f6-4b0b-bd21-e3c61fd2def2"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1364), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 407", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1365), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 408, new Guid("6c535cc6-3b08-4d59-b0ae-13c0fcd43788"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1382), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 408", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1383), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 409, new Guid("6171c782-c949-4f07-af59-a67527339170"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1435), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 409", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1436), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 410, new Guid("e68828a6-6fd0-43ea-b775-ea1f26272c9f"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1452), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 410", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1453), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 411, new Guid("39ecba63-7dd3-4a8f-a22b-dbba58c8520c"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1467), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 411", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1468), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 412, new Guid("6a4fd9bf-fb2a-42c3-b345-c9905ade1d59"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1485), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 412", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1486), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 413, new Guid("22327931-88d2-4e9f-92ec-bb0c4d2b916e"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1500), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 413", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1501), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 414, new Guid("359dd114-8998-495d-b409-471e6b07fcbc"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1515), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 414", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1516), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 415, new Guid("176b9242-8817-4fed-8f98-c4f64bd4593a"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1529), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 415", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1530), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 416, new Guid("77b65319-88e1-493c-a9ec-a0a0ec6093e3"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1547), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 416", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1548), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 417, new Guid("4e7a89aa-1e1e-4f67-9631-52080411bfb6"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1564), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 417", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1565), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 418, new Guid("2a0254ad-a64d-4559-b277-15c8f0a44415"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1579), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 418", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1580), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 419, new Guid("90e43d91-c061-4d26-8a77-dcf356791fa8"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1632), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 419", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1633), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 420, new Guid("dd37eb37-7d16-4911-a01f-5228da152164"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1650), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 420", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1651), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 421, new Guid("34de6505-e866-4e60-b8cb-6ec07ed77c63"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1665), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 421", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1666), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 422, new Guid("b95407eb-8f63-4158-810e-f987cbe0cd1d"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1680), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 422", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1681), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 423, new Guid("bd416353-6ec5-4734-b5fc-8d2d0d8dd2d0"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1695), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 423", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1696), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 424, new Guid("53e33b43-edcc-438c-a621-c822c75ca4ad"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1712), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 424", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1713), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 425, new Guid("9892b106-4a11-4c26-a453-fdba79e6ba2e"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1728), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 425", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1729), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 426, new Guid("b96c3313-d3fb-4030-a3c8-16ded3e80629"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1742), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 426", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1743), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 427, new Guid("6728b001-9172-421f-bd42-e1a055f890e6"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1757), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 427", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1758), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 428, new Guid("589be547-384f-485e-b71e-d24b6c0592f0"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1774), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 428", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1775), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 429, new Guid("00bc3e1d-c8a2-419b-848d-b8a54ab000c5"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1789), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 429", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1790), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 430, new Guid("d9a666c5-1a3c-4ed5-b8aa-dc96b8fa3ef1"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1804), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 430", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1805), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 431, new Guid("6065cdca-1551-4667-9486-f9432a5b4c42"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1886), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 431", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1887), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 432, new Guid("22fa2e44-a3c9-4ec1-9f93-7919ff0f8f41"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1906), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 432", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1907), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 433, new Guid("1a4a7751-409a-4917-9ddf-47f9d3a3b6f6"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1922), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 433", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1922), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 434, new Guid("b881dd8f-a550-4889-afd1-d3ca3e97a85f"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1936), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 434", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1937), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 435, new Guid("0d321930-2593-45c6-9928-55446b906d2e"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1951), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 435", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1952), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 436, new Guid("8ac09ce5-c7d6-46d9-881d-a128a8f807c9"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1968), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 436", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1969), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 437, new Guid("fc8f9d77-6603-495b-a21c-823880ab2660"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1983), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 437", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1984), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 438, new Guid("0cc9b64c-1668-4985-a81c-5e5a7abd147f"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 438", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(1999), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 439, new Guid("281ab0ed-7101-4585-b33c-c5b6d5530847"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2013), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 439", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2014), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 440, new Guid("57d696d2-3441-4d1f-81e4-6bbea12e910c"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2030), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 440", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2031), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 441, new Guid("926b2aac-5430-4410-89b5-3c3f0dafeb05"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2045), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 441", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2046), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 442, new Guid("5980f32b-ec54-4e6a-9bfb-976f94bd2b67"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2060), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 442", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2061), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 443, new Guid("895219dc-8469-41b0-9536-d3cdeb8f7acd"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2074), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 443", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2075), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 444, new Guid("a87d6c38-69ad-41c5-8e9b-2561b414425f"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2128), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 444", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2129), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 445, new Guid("0e78420b-bd60-4e2f-b920-98c1084bc951"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 445", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2145), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 446, new Guid("f5adebd4-1e4d-4e58-86b0-89da3af3967d"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2159), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 446", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2160), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 447, new Guid("06335f8f-7bf4-4970-aa5d-86a097be2d42"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2174), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 447", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2175), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 448, new Guid("ade0fc4d-7439-46de-9661-c2033f5df698"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2191), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 448", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2192), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 449, new Guid("ff2fcdf9-030a-4b75-9b11-e4d8c64f7bdd"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2206), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 449", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2207), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 450, new Guid("0f044f43-871a-4324-8be4-c05c62ed10ff"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2221), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 450", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2222), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 451, new Guid("9a726eea-f0b6-4e72-bae1-9bcc07a8ce60"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2236), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 451", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2237), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 452, new Guid("cb271c62-6019-40e4-b1af-69f593497de4"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2254), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 452", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2255), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 453, new Guid("c3e5c3b9-24e6-4c8b-bf3a-450560f57c47"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2269), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 453", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2270), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 454, new Guid("3f20a042-c126-41eb-86f4-c2de44726cf8"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2284), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 454", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2285), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 455, new Guid("eef06a07-309b-42d4-9601-e2d7ee4a81a9"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2298), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 455", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2299), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 456, new Guid("99270c8a-95d4-4e00-a6a9-c1357a411d56"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2315), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 456", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2316), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 457, new Guid("ab98c193-fde9-4b4e-ac7b-d7e84a5e919a"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 457", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2368), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 458, new Guid("16b1fb61-9b69-471e-966f-4b4a5e6e7e6b"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2384), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 458", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2385), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 459, new Guid("cd66986d-ab0e-4e2f-9a51-fcbe22240220"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2400), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 459", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2401), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 460, new Guid("a569f1c1-610e-4e57-90a2-60d802cfc3af"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2491), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 460", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2492), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 461, new Guid("7e18f696-07f3-4473-b9df-6dd4e6445bed"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2507), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 461", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2508), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 462, new Guid("ee98afe8-a26c-4733-9c20-3deb8b3b826c"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2522), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 462", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2523), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 463, new Guid("fcb6cf58-9a00-4a13-a41b-108406285c85"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2537), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 463", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2538), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 464, new Guid("99f7106d-7894-4538-8a2d-182bde4c49c4"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2554), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 464", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2555), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 465, new Guid("deaac53c-679b-45af-97ad-c1fa0924edea"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2569), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 465", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2570), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 466, new Guid("c4d94da3-8328-4407-a177-ab9e254fd7eb"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2584), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 466", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2585), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 467, new Guid("75122f7f-10e2-43ff-8930-92c245bde4a6"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2599), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 467", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2600), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 468, new Guid("0da2be95-e11e-41f6-a844-3b3b8cbc627e"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2616), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 468", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2617), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 469, new Guid("86915312-5aa1-4841-ae69-b5aaceee0929"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2631), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 469", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2632), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 470, new Guid("6b3fec96-13fa-4e5e-9498-6763a58b8695"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2687), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 470", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2689), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 471, new Guid("a484f00e-db7d-4c24-80a7-b2dc21273ad0"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2703), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 471", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2703), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 472, new Guid("2a06a54d-e35b-41a2-8b72-095c79031ec1"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2720), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 472", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2721), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 473, new Guid("a1fc9110-32ce-4990-ae80-664dd193f9cc"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2735), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 473", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2736), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 474, new Guid("4160e916-2a6b-4112-8fae-64da68a5b5fe"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2750), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 474", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2751), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 475, new Guid("074b1082-8264-4213-b4bf-b7aa55bc0e51"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2764), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 475", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2765), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 476, new Guid("8d32e2f8-3d84-4885-b216-18159f317162"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2782), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 476", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2783), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 477, new Guid("67877b53-6a07-4e7e-9289-e435a2abecc5"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2797), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 477", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2798), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 478, new Guid("2114ce37-6ec0-4e78-ad62-69def359b220"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2811), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 478", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2812), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 479, new Guid("048af1ed-9cb0-4916-a55f-7c00d30ceb2a"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2826), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 479", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2827), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 480, new Guid("f69a81d5-4612-4ff0-89c4-d458aba1c824"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2843), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 480", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2844), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 481, new Guid("4552cc66-d55d-43ff-9fda-cd821dfd53d1"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2858), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 481", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2859), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 482, new Guid("b0d70d66-ee9b-472b-a1b3-9d0e2fe98835"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2909), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 482", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2910), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 483, new Guid("ff249df6-ab5d-4e98-81fa-9ffe113a8de0"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2926), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 483", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2927), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 484, new Guid("f55f4f84-fe0d-4a91-b05c-2dde4f719097"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2944), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 484", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2945), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 485, new Guid("b29027a7-66ed-41f4-9096-8351ff32eabc"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 485", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2960), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 486, new Guid("036222d1-03ec-4ad7-aca0-1c2287445661"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 486", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2975), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 487, new Guid("b308477a-f9f8-4745-bec3-ec3388eeb499"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2989), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 487", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(2990), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 488, new Guid("5e33a5af-e6f5-42f0-9cbf-15cb6105d7d3"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3006), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 488", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3007), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 489, new Guid("373af2c8-42fa-4b48-8534-bf3307ebfce7"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3021), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 489", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3022), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 490, new Guid("4fecfde6-fde3-4d56-b7a8-2b331264101e"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3036), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 490", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3037), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 491, new Guid("51bc5b5f-4438-4515-94cc-2973d001fba2"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3050), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 491", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3051), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 492, new Guid("c05fd4ca-bc42-4a5b-9fd7-b755262d6a56"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3068), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 492", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3069), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 493, new Guid("f6b58a84-d691-4def-a80a-b197a1014a7e"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3083), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 493", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3084), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 494, new Guid("0abd9657-04a9-48f2-8530-5ec7ed876d11"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3098), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 494", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3099), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 495, new Guid("8747ab91-bbc0-4f98-a2b9-e87e26352078"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3167), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 495", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3168), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 496, new Guid("7779dd36-25a3-47cf-9c57-81b8c30ee90b"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3187), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 496", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3188), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 497, new Guid("e5cd5b41-577f-4fc6-9f2d-005ed08354b7"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3202), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 497", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3203), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 498, new Guid("032dcba3-e65a-4149-ba7d-0ff336e2a184"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3217), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 498", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3218), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 499, new Guid("b1de3cfb-a792-4887-b3b9-bad75fc83e32"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3232), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 1, "Driver 499", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3233), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "name", "slot", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("cdb70293-0804-44d3-8478-4bd77e33ccd2"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViRide", 2, 1, 0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9398), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("0a08b82a-ff21-45c7-89e6-5eedb5a658e0"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9419), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-4", 4, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9420), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("02fe01d5-c127-485c-8170-2b66cfdc26a1"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9433), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "ViCar-7", 7, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9433), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3468), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3469), new TimeSpan(0, 7, 0, 0, 0)), 0, 11, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3477), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3478), new TimeSpan(0, 7, 0, 0, 0)), 0, 11 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3486), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3486), new TimeSpan(0, 7, 0, 0, 0)), 0, 10, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 22, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3494), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3495), new TimeSpan(0, 7, 0, 0, 0)), 0, 10 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 23, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3502), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3503), new TimeSpan(0, 7, 0, 0, 0)), 0, 12, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3511), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3512), new TimeSpan(0, 7, 0, 0, 0)), 0, 12 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 100, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3520), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+100", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3521), new TimeSpan(0, 7, 0, 0, 0)), 0, 100, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 101, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@100", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3534), new TimeSpan(0, 7, 0, 0, 0)), 0, 100 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 102, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3546), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+101", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3547), new TimeSpan(0, 7, 0, 0, 0)), 0, 101, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 103, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3556), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@101", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3557), new TimeSpan(0, 7, 0, 0, 0)), 0, 101 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 104, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3566), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+102", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3567), new TimeSpan(0, 7, 0, 0, 0)), 0, 102, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 105, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3575), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@102", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3576), new TimeSpan(0, 7, 0, 0, 0)), 0, 102 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 106, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3585), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+103", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3586), new TimeSpan(0, 7, 0, 0, 0)), 0, 103, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 107, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3595), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@103", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3595), new TimeSpan(0, 7, 0, 0, 0)), 0, 103 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 108, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3604), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+104", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3605), new TimeSpan(0, 7, 0, 0, 0)), 0, 104, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 109, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3615), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@104", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3616), new TimeSpan(0, 7, 0, 0, 0)), 0, 104 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 110, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3624), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+105", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3625), new TimeSpan(0, 7, 0, 0, 0)), 0, 105, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 111, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3671), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@105", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3672), new TimeSpan(0, 7, 0, 0, 0)), 0, 105 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 112, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3683), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+106", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3683), new TimeSpan(0, 7, 0, 0, 0)), 0, 106, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 113, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3693), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@106", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3693), new TimeSpan(0, 7, 0, 0, 0)), 0, 106 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 114, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3703), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+107", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3703), new TimeSpan(0, 7, 0, 0, 0)), 0, 107, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 115, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3712), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@107", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3713), new TimeSpan(0, 7, 0, 0, 0)), 0, 107 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 116, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3722), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+108", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3722), new TimeSpan(0, 7, 0, 0, 0)), 0, 108, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 117, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3732), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@108", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3732), new TimeSpan(0, 7, 0, 0, 0)), 0, 108 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 118, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3741), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+109", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3742), new TimeSpan(0, 7, 0, 0, 0)), 0, 109, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 119, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3751), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@109", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3752), new TimeSpan(0, 7, 0, 0, 0)), 0, 109 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 120, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3761), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+110", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3761), new TimeSpan(0, 7, 0, 0, 0)), 0, 110, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 121, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3770), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@110", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3771), new TimeSpan(0, 7, 0, 0, 0)), 0, 110 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 122, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+111", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3781), new TimeSpan(0, 7, 0, 0, 0)), 0, 111, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 123, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3790), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@111", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3791), new TimeSpan(0, 7, 0, 0, 0)), 0, 111 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 124, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3800), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+112", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3800), new TimeSpan(0, 7, 0, 0, 0)), 0, 112, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 125, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3809), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@112", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3810), new TimeSpan(0, 7, 0, 0, 0)), 0, 112 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 126, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3819), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+113", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3819), new TimeSpan(0, 7, 0, 0, 0)), 0, 113, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 127, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3828), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@113", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3829), new TimeSpan(0, 7, 0, 0, 0)), 0, 113 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 128, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3838), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+114", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3839), new TimeSpan(0, 7, 0, 0, 0)), 0, 114, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 129, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@114", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3848), new TimeSpan(0, 7, 0, 0, 0)), 0, 114 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 130, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3857), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+115", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3858), new TimeSpan(0, 7, 0, 0, 0)), 0, 115, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 131, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3866), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@115", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3867), new TimeSpan(0, 7, 0, 0, 0)), 0, 115 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 132, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3876), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+116", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3876), new TimeSpan(0, 7, 0, 0, 0)), 0, 116, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 133, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3923), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@116", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3924), new TimeSpan(0, 7, 0, 0, 0)), 0, 116 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 134, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3935), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+117", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3935), new TimeSpan(0, 7, 0, 0, 0)), 0, 117, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 135, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3944), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@117", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3945), new TimeSpan(0, 7, 0, 0, 0)), 0, 117 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 136, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+118", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3955), new TimeSpan(0, 7, 0, 0, 0)), 0, 118, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 137, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3964), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@118", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3964), new TimeSpan(0, 7, 0, 0, 0)), 0, 118 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 138, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3973), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+119", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3974), new TimeSpan(0, 7, 0, 0, 0)), 0, 119, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 139, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3983), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@119", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3984), new TimeSpan(0, 7, 0, 0, 0)), 0, 119 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 140, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3993), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+120", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3993), new TimeSpan(0, 7, 0, 0, 0)), 0, 120, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 141, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4004), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@120", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4005), new TimeSpan(0, 7, 0, 0, 0)), 0, 120 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 142, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4014), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+121", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4015), new TimeSpan(0, 7, 0, 0, 0)), 0, 121, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 143, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4024), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@121", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4025), new TimeSpan(0, 7, 0, 0, 0)), 0, 121 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 144, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4033), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+122", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4034), new TimeSpan(0, 7, 0, 0, 0)), 0, 122, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 145, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4043), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@122", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4044), new TimeSpan(0, 7, 0, 0, 0)), 0, 122 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 146, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4053), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+123", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4054), new TimeSpan(0, 7, 0, 0, 0)), 0, 123, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 147, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4063), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@123", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4064), new TimeSpan(0, 7, 0, 0, 0)), 0, 123 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 148, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4072), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+124", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4073), new TimeSpan(0, 7, 0, 0, 0)), 0, 124, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 149, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4082), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@124", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4083), new TimeSpan(0, 7, 0, 0, 0)), 0, 124 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 150, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4091), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+125", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4092), new TimeSpan(0, 7, 0, 0, 0)), 0, 125, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 151, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4101), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@125", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4102), new TimeSpan(0, 7, 0, 0, 0)), 0, 125 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 152, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4111), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+126", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4111), new TimeSpan(0, 7, 0, 0, 0)), 0, 126, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 153, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4158), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@126", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4159), new TimeSpan(0, 7, 0, 0, 0)), 0, 126 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 154, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4169), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+127", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4170), new TimeSpan(0, 7, 0, 0, 0)), 0, 127, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 155, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4179), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@127", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4180), new TimeSpan(0, 7, 0, 0, 0)), 0, 127 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 156, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4189), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+128", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4189), new TimeSpan(0, 7, 0, 0, 0)), 0, 128, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 157, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4198), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@128", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4199), new TimeSpan(0, 7, 0, 0, 0)), 0, 128 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 158, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4208), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+129", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4208), new TimeSpan(0, 7, 0, 0, 0)), 0, 129, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 159, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@129", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4218), new TimeSpan(0, 7, 0, 0, 0)), 0, 129 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 160, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4227), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+130", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4228), new TimeSpan(0, 7, 0, 0, 0)), 0, 130, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 161, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4237), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@130", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4238), new TimeSpan(0, 7, 0, 0, 0)), 0, 130 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 162, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4247), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+131", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4247), new TimeSpan(0, 7, 0, 0, 0)), 0, 131, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 163, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@131", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4257), new TimeSpan(0, 7, 0, 0, 0)), 0, 131 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 164, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+132", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4267), new TimeSpan(0, 7, 0, 0, 0)), 0, 132, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 165, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4276), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@132", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4276), new TimeSpan(0, 7, 0, 0, 0)), 0, 132 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 166, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4285), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+133", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4286), new TimeSpan(0, 7, 0, 0, 0)), 0, 133, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 167, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4295), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@133", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4296), new TimeSpan(0, 7, 0, 0, 0)), 0, 133 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 168, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4305), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+134", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4306), new TimeSpan(0, 7, 0, 0, 0)), 0, 134, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 169, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4315), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@134", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4315), new TimeSpan(0, 7, 0, 0, 0)), 0, 134 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 170, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4324), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+135", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4325), new TimeSpan(0, 7, 0, 0, 0)), 0, 135, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 171, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4334), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@135", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4335), new TimeSpan(0, 7, 0, 0, 0)), 0, 135 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 172, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4344), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+136", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4345), new TimeSpan(0, 7, 0, 0, 0)), 0, 136, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 173, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@136", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4354), new TimeSpan(0, 7, 0, 0, 0)), 0, 136 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 174, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4363), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+137", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4364), new TimeSpan(0, 7, 0, 0, 0)), 0, 137, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 175, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4450), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@137", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4450), new TimeSpan(0, 7, 0, 0, 0)), 0, 137 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 176, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4461), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+138", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4462), new TimeSpan(0, 7, 0, 0, 0)), 0, 138, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 177, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4471), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@138", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4472), new TimeSpan(0, 7, 0, 0, 0)), 0, 138 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 178, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+139", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4482), new TimeSpan(0, 7, 0, 0, 0)), 0, 139, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 179, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4490), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@139", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4491), new TimeSpan(0, 7, 0, 0, 0)), 0, 139 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 180, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4500), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+140", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4501), new TimeSpan(0, 7, 0, 0, 0)), 0, 140, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 181, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@140", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4511), new TimeSpan(0, 7, 0, 0, 0)), 0, 140 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 182, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4519), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+141", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4520), new TimeSpan(0, 7, 0, 0, 0)), 0, 141, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 183, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4529), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@141", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4530), new TimeSpan(0, 7, 0, 0, 0)), 0, 141 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 184, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4538), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+142", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4539), new TimeSpan(0, 7, 0, 0, 0)), 0, 142, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 185, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4548), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@142", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4549), new TimeSpan(0, 7, 0, 0, 0)), 0, 142 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 186, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4558), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+143", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4559), new TimeSpan(0, 7, 0, 0, 0)), 0, 143, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 187, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4568), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@143", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4569), new TimeSpan(0, 7, 0, 0, 0)), 0, 143 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 188, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4578), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+144", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4578), new TimeSpan(0, 7, 0, 0, 0)), 0, 144, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 189, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@144", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4588), new TimeSpan(0, 7, 0, 0, 0)), 0, 144 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 190, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4597), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+145", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4597), new TimeSpan(0, 7, 0, 0, 0)), 0, 145, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 191, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4606), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@145", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4607), new TimeSpan(0, 7, 0, 0, 0)), 0, 145 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 192, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4616), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+146", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4617), new TimeSpan(0, 7, 0, 0, 0)), 0, 146, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 193, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4626), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@146", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4626), new TimeSpan(0, 7, 0, 0, 0)), 0, 146 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 194, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4635), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+147", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4636), new TimeSpan(0, 7, 0, 0, 0)), 0, 147, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 195, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4645), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@147", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4646), new TimeSpan(0, 7, 0, 0, 0)), 0, 147 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 196, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4655), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+148", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4656), new TimeSpan(0, 7, 0, 0, 0)), 0, 148, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 197, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4704), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@148", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4705), new TimeSpan(0, 7, 0, 0, 0)), 0, 148 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 198, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4716), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+149", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4716), new TimeSpan(0, 7, 0, 0, 0)), 0, 149, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 199, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4726), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@149", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4726), new TimeSpan(0, 7, 0, 0, 0)), 0, 149 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 200, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4735), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+150", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4736), new TimeSpan(0, 7, 0, 0, 0)), 0, 150, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 201, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4745), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@150", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4746), new TimeSpan(0, 7, 0, 0, 0)), 0, 150 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 202, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+151", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4756), new TimeSpan(0, 7, 0, 0, 0)), 0, 151, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 203, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4765), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@151", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4765), new TimeSpan(0, 7, 0, 0, 0)), 0, 151 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 204, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4775), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+152", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4775), new TimeSpan(0, 7, 0, 0, 0)), 0, 152, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 205, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4787), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@152", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4787), new TimeSpan(0, 7, 0, 0, 0)), 0, 152 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 206, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4797), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+153", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4798), new TimeSpan(0, 7, 0, 0, 0)), 0, 153, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 207, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4807), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@153", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4808), new TimeSpan(0, 7, 0, 0, 0)), 0, 153 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 208, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4817), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+154", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4818), new TimeSpan(0, 7, 0, 0, 0)), 0, 154, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 209, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4827), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@154", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4828), new TimeSpan(0, 7, 0, 0, 0)), 0, 154 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 210, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4837), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+155", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4838), new TimeSpan(0, 7, 0, 0, 0)), 0, 155, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 211, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4847), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@155", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4848), new TimeSpan(0, 7, 0, 0, 0)), 0, 155 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 212, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4857), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+156", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4857), new TimeSpan(0, 7, 0, 0, 0)), 0, 156, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 213, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4866), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@156", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4867), new TimeSpan(0, 7, 0, 0, 0)), 0, 156 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 214, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4934), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+157", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4935), new TimeSpan(0, 7, 0, 0, 0)), 0, 157, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 215, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4945), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@157", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4945), new TimeSpan(0, 7, 0, 0, 0)), 0, 157 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 216, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4954), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+158", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4955), new TimeSpan(0, 7, 0, 0, 0)), 0, 158, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 217, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4964), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@158", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4965), new TimeSpan(0, 7, 0, 0, 0)), 0, 158 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 218, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4974), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+159", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4974), new TimeSpan(0, 7, 0, 0, 0)), 0, 159, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 219, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4983), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@159", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4984), new TimeSpan(0, 7, 0, 0, 0)), 0, 159 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 220, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4993), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+160", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(4994), new TimeSpan(0, 7, 0, 0, 0)), 0, 160, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 221, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5003), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@160", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5004), new TimeSpan(0, 7, 0, 0, 0)), 0, 160 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 222, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5013), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+161", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5013), new TimeSpan(0, 7, 0, 0, 0)), 0, 161, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 223, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5022), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@161", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5023), new TimeSpan(0, 7, 0, 0, 0)), 0, 161 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 224, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5032), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+162", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5033), new TimeSpan(0, 7, 0, 0, 0)), 0, 162, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 225, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5042), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@162", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5043), new TimeSpan(0, 7, 0, 0, 0)), 0, 162 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 226, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5052), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+163", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5053), new TimeSpan(0, 7, 0, 0, 0)), 0, 163, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 227, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5062), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@163", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5062), new TimeSpan(0, 7, 0, 0, 0)), 0, 163 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 228, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5071), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+164", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5072), new TimeSpan(0, 7, 0, 0, 0)), 0, 164, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 229, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5081), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@164", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5082), new TimeSpan(0, 7, 0, 0, 0)), 0, 164 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 230, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5091), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+165", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5092), new TimeSpan(0, 7, 0, 0, 0)), 0, 165, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 231, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5101), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@165", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5102), new TimeSpan(0, 7, 0, 0, 0)), 0, 165 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 232, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5110), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+166", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5111), new TimeSpan(0, 7, 0, 0, 0)), 0, 166, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 233, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5120), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@166", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5121), new TimeSpan(0, 7, 0, 0, 0)), 0, 166 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 234, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5129), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+167", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5130), new TimeSpan(0, 7, 0, 0, 0)), 0, 167, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 235, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5139), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@167", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5140), new TimeSpan(0, 7, 0, 0, 0)), 0, 167 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 236, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5186), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+168", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5187), new TimeSpan(0, 7, 0, 0, 0)), 0, 168, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 237, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5197), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@168", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5198), new TimeSpan(0, 7, 0, 0, 0)), 0, 168 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 238, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5207), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+169", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5208), new TimeSpan(0, 7, 0, 0, 0)), 0, 169, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 239, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5217), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@169", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5217), new TimeSpan(0, 7, 0, 0, 0)), 0, 169 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 240, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+170", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5227), new TimeSpan(0, 7, 0, 0, 0)), 0, 170, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 241, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5236), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@170", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5237), new TimeSpan(0, 7, 0, 0, 0)), 0, 170 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 242, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5246), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+171", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5247), new TimeSpan(0, 7, 0, 0, 0)), 0, 171, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 243, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@171", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5256), new TimeSpan(0, 7, 0, 0, 0)), 0, 171 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 244, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5266), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+172", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5266), new TimeSpan(0, 7, 0, 0, 0)), 0, 172, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 245, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5275), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@172", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5276), new TimeSpan(0, 7, 0, 0, 0)), 0, 172 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 246, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5285), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+173", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5286), new TimeSpan(0, 7, 0, 0, 0)), 0, 173, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 247, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5295), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@173", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5296), new TimeSpan(0, 7, 0, 0, 0)), 0, 173 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 248, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5305), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+174", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5306), new TimeSpan(0, 7, 0, 0, 0)), 0, 174, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 249, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5315), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@174", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5316), new TimeSpan(0, 7, 0, 0, 0)), 0, 174 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 250, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5324), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+175", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5325), new TimeSpan(0, 7, 0, 0, 0)), 0, 175, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 251, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5334), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@175", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5335), new TimeSpan(0, 7, 0, 0, 0)), 0, 175 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 252, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5344), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+176", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5344), new TimeSpan(0, 7, 0, 0, 0)), 0, 176, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 253, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5354), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@176", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5354), new TimeSpan(0, 7, 0, 0, 0)), 0, 176 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 254, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5363), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+177", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5364), new TimeSpan(0, 7, 0, 0, 0)), 0, 177, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 255, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5374), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@177", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5374), new TimeSpan(0, 7, 0, 0, 0)), 0, 177 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 256, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5383), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+178", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5384), new TimeSpan(0, 7, 0, 0, 0)), 0, 178, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 257, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5393), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@178", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5394), new TimeSpan(0, 7, 0, 0, 0)), 0, 178 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 258, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5445), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+179", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5446), new TimeSpan(0, 7, 0, 0, 0)), 0, 179, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 259, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5456), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@179", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5456), new TimeSpan(0, 7, 0, 0, 0)), 0, 179 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 260, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5465), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+180", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5466), new TimeSpan(0, 7, 0, 0, 0)), 0, 180, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 261, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5475), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@180", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5475), new TimeSpan(0, 7, 0, 0, 0)), 0, 180 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 262, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5484), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+181", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5485), new TimeSpan(0, 7, 0, 0, 0)), 0, 181, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 263, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5494), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@181", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5495), new TimeSpan(0, 7, 0, 0, 0)), 0, 181 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 264, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5504), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+182", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5505), new TimeSpan(0, 7, 0, 0, 0)), 0, 182, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 265, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5514), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@182", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5514), new TimeSpan(0, 7, 0, 0, 0)), 0, 182 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 266, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5523), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+183", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5524), new TimeSpan(0, 7, 0, 0, 0)), 0, 183, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 267, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@183", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5534), new TimeSpan(0, 7, 0, 0, 0)), 0, 183 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 268, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5542), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+184", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5543), new TimeSpan(0, 7, 0, 0, 0)), 0, 184, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 269, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5553), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@184", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5553), new TimeSpan(0, 7, 0, 0, 0)), 0, 184 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 270, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5562), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+185", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5563), new TimeSpan(0, 7, 0, 0, 0)), 0, 185, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 271, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@185", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5572), new TimeSpan(0, 7, 0, 0, 0)), 0, 185 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 272, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5581), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+186", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5582), new TimeSpan(0, 7, 0, 0, 0)), 0, 186, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 273, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5591), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@186", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5592), new TimeSpan(0, 7, 0, 0, 0)), 0, 186 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 274, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5601), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+187", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5601), new TimeSpan(0, 7, 0, 0, 0)), 0, 187, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 275, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5610), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@187", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5611), new TimeSpan(0, 7, 0, 0, 0)), 0, 187 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 276, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5620), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+188", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5621), new TimeSpan(0, 7, 0, 0, 0)), 0, 188, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 277, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5630), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@188", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5631), new TimeSpan(0, 7, 0, 0, 0)), 0, 188 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 278, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5639), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+189", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5640), new TimeSpan(0, 7, 0, 0, 0)), 0, 189, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 279, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5649), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@189", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5650), new TimeSpan(0, 7, 0, 0, 0)), 0, 189 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 280, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5694), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+190", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5695), new TimeSpan(0, 7, 0, 0, 0)), 0, 190, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 281, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5705), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@190", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5706), new TimeSpan(0, 7, 0, 0, 0)), 0, 190 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 282, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5715), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+191", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5716), new TimeSpan(0, 7, 0, 0, 0)), 0, 191, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 283, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5725), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@191", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5726), new TimeSpan(0, 7, 0, 0, 0)), 0, 191 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 284, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5735), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+192", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5736), new TimeSpan(0, 7, 0, 0, 0)), 0, 192, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 285, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5745), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@192", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5746), new TimeSpan(0, 7, 0, 0, 0)), 0, 192 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 286, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5755), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+193", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5755), new TimeSpan(0, 7, 0, 0, 0)), 0, 193, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 287, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5764), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@193", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5765), new TimeSpan(0, 7, 0, 0, 0)), 0, 193 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 288, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5774), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+194", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5775), new TimeSpan(0, 7, 0, 0, 0)), 0, 194, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 289, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5784), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@194", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5784), new TimeSpan(0, 7, 0, 0, 0)), 0, 194 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 290, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5793), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+195", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5794), new TimeSpan(0, 7, 0, 0, 0)), 0, 195, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 291, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5803), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@195", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5804), new TimeSpan(0, 7, 0, 0, 0)), 0, 195 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 292, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5813), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+196", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5813), new TimeSpan(0, 7, 0, 0, 0)), 0, 196, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 293, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5822), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@196", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5823), new TimeSpan(0, 7, 0, 0, 0)), 0, 196 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 294, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5832), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+197", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5833), new TimeSpan(0, 7, 0, 0, 0)), 0, 197, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 295, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5842), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@197", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5843), new TimeSpan(0, 7, 0, 0, 0)), 0, 197 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 296, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5852), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+198", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5853), new TimeSpan(0, 7, 0, 0, 0)), 0, 198, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 297, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5862), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@198", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5863), new TimeSpan(0, 7, 0, 0, 0)), 0, 198 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 298, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+199", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5872), new TimeSpan(0, 7, 0, 0, 0)), 0, 199, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 299, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5881), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@199", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5882), new TimeSpan(0, 7, 0, 0, 0)), 0, 199 },
                    { 400, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5892), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+400", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5892), new TimeSpan(0, 7, 0, 0, 0)), 0, 400 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 401, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5903), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@400", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5903), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 402, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5949), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+401", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5950), new TimeSpan(0, 7, 0, 0, 0)), 0, 401 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 403, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5962), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@401", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5962), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 404, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5972), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+402", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5972), new TimeSpan(0, 7, 0, 0, 0)), 0, 402 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 405, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5982), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@402", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5982), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 406, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5991), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+403", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(5992), new TimeSpan(0, 7, 0, 0, 0)), 0, 403 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 407, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6001), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@403", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6002), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 408, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6011), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+404", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6012), new TimeSpan(0, 7, 0, 0, 0)), 0, 404 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 409, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6021), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@404", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6022), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 410, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6031), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+405", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6032), new TimeSpan(0, 7, 0, 0, 0)), 0, 405 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 411, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6041), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@405", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6042), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 412, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6051), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+406", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6052), new TimeSpan(0, 7, 0, 0, 0)), 0, 406 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 413, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6061), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@406", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6062), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 414, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6071), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+407", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6072), new TimeSpan(0, 7, 0, 0, 0)), 0, 407 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 415, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6081), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@407", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6082), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 416, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6091), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+408", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6091), new TimeSpan(0, 7, 0, 0, 0)), 0, 408 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 417, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6101), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@408", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6102), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 418, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6110), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+409", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6111), new TimeSpan(0, 7, 0, 0, 0)), 0, 409 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 419, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6120), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@409", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6121), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 420, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6130), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+410", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6131), new TimeSpan(0, 7, 0, 0, 0)), 0, 410 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 421, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6140), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@410", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6141), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 422, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6150), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+411", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6150), new TimeSpan(0, 7, 0, 0, 0)), 0, 411 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 423, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6160), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@411", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6160), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 424, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6169), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+412", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6170), new TimeSpan(0, 7, 0, 0, 0)), 0, 412 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 425, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6218), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@412", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6218), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 426, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6228), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+413", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6229), new TimeSpan(0, 7, 0, 0, 0)), 0, 413 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 427, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6238), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@413", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6239), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 428, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6248), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+414", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6248), new TimeSpan(0, 7, 0, 0, 0)), 0, 414 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 429, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6257), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@414", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6258), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 430, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6267), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+415", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6267), new TimeSpan(0, 7, 0, 0, 0)), 0, 415 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 431, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6276), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@415", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6277), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 432, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6286), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+416", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6287), new TimeSpan(0, 7, 0, 0, 0)), 0, 416 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 433, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6300), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@416", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6300), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 434, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+417", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6311), new TimeSpan(0, 7, 0, 0, 0)), 0, 417 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 435, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6319), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@417", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6320), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 436, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6367), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+418", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6368), new TimeSpan(0, 7, 0, 0, 0)), 0, 418 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 437, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@418", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6378), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 438, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6387), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+419", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6388), new TimeSpan(0, 7, 0, 0, 0)), 0, 419 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 439, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6397), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@419", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6398), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 440, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6407), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+420", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6408), new TimeSpan(0, 7, 0, 0, 0)), 0, 420 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 441, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6417), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@420", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6418), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 442, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6427), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+421", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6428), new TimeSpan(0, 7, 0, 0, 0)), 0, 421 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 443, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6502), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@421", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6503), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 444, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6513), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+422", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6513), new TimeSpan(0, 7, 0, 0, 0)), 0, 422 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 445, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6522), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@422", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6523), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 446, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6532), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+423", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6533), new TimeSpan(0, 7, 0, 0, 0)), 0, 423 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 447, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6543), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@423", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6543), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 448, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6552), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+424", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6553), new TimeSpan(0, 7, 0, 0, 0)), 0, 424 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 449, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6562), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@424", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6563), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 450, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6572), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+425", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6573), new TimeSpan(0, 7, 0, 0, 0)), 0, 425 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 451, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6582), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@425", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6582), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 452, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6592), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+426", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6593), new TimeSpan(0, 7, 0, 0, 0)), 0, 426 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 453, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6602), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@426", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6602), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 454, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6611), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+427", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6612), new TimeSpan(0, 7, 0, 0, 0)), 0, 427 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 455, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6621), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@427", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6622), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 456, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6631), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+428", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6632), new TimeSpan(0, 7, 0, 0, 0)), 0, 428 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 457, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6641), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@428", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6642), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 458, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6690), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+429", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6691), new TimeSpan(0, 7, 0, 0, 0)), 0, 429 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 459, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6701), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@429", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6702), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 460, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6712), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+430", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6712), new TimeSpan(0, 7, 0, 0, 0)), 0, 430 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 461, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6749), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@430", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6750), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 462, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6759), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+431", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6760), new TimeSpan(0, 7, 0, 0, 0)), 0, 431 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 463, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6769), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@431", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6770), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 464, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6779), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+432", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6780), new TimeSpan(0, 7, 0, 0, 0)), 0, 432 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 465, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6789), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@432", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6790), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 466, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6799), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+433", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6800), new TimeSpan(0, 7, 0, 0, 0)), 0, 433 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 467, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6809), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@433", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6810), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 468, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6819), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+434", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6820), new TimeSpan(0, 7, 0, 0, 0)), 0, 434 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 469, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6829), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@434", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6830), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 470, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6839), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+435", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6840), new TimeSpan(0, 7, 0, 0, 0)), 0, 435 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 471, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6849), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@435", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6850), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 472, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6859), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+436", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6860), new TimeSpan(0, 7, 0, 0, 0)), 0, 436 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 473, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6869), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@436", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6870), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 474, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6879), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+437", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6880), new TimeSpan(0, 7, 0, 0, 0)), 0, 437 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 475, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6889), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@437", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6889), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 476, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6899), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+438", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6899), new TimeSpan(0, 7, 0, 0, 0)), 0, 438 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 477, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6909), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@438", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6909), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 478, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6918), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+439", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6919), new TimeSpan(0, 7, 0, 0, 0)), 0, 439 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 479, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6928), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@439", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(6929), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 480, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7013), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+440", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7014), new TimeSpan(0, 7, 0, 0, 0)), 0, 440 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 481, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7025), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@440", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7026), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 482, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7035), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+441", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7036), new TimeSpan(0, 7, 0, 0, 0)), 0, 441 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 483, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7046), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@441", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7047), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 484, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7056), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+442", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7057), new TimeSpan(0, 7, 0, 0, 0)), 0, 442 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 485, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7066), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@442", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7066), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 486, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7076), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+443", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7077), new TimeSpan(0, 7, 0, 0, 0)), 0, 443 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 487, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7086), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@443", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7086), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 488, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7096), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+444", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7097), new TimeSpan(0, 7, 0, 0, 0)), 0, 444 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 489, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7106), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@444", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7107), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 490, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7116), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+445", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7117), new TimeSpan(0, 7, 0, 0, 0)), 0, 445 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 491, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7126), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@445", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7127), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 492, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7136), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+446", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7137), new TimeSpan(0, 7, 0, 0, 0)), 0, 446 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 493, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7146), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@446", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7147), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 494, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7156), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+447", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7157), new TimeSpan(0, 7, 0, 0, 0)), 0, 447 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 495, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7166), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@447", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7166), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 496, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7175), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+448", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7176), new TimeSpan(0, 7, 0, 0, 0)), 0, 448 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 497, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7185), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@448", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7186), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 498, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7195), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+449", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7196), new TimeSpan(0, 7, 0, 0, 0)), 0, 449 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 499, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7205), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@449", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7206), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 500, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7215), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+450", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7215), new TimeSpan(0, 7, 0, 0, 0)), 0, 450 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 501, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7225), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@450", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7225), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 502, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7307), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+451", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7308), new TimeSpan(0, 7, 0, 0, 0)), 0, 451 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 503, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7320), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@451", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7320), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 504, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7330), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+452", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7330), new TimeSpan(0, 7, 0, 0, 0)), 0, 452 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 505, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7340), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@452", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7340), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 506, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7350), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+453", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7350), new TimeSpan(0, 7, 0, 0, 0)), 0, 453 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 507, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7359), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@453", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7360), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 508, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7370), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+454", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7370), new TimeSpan(0, 7, 0, 0, 0)), 0, 454 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 509, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@454", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7380), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 510, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7389), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+455", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7390), new TimeSpan(0, 7, 0, 0, 0)), 0, 455 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 511, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7399), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@455", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7400), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 512, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7409), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+456", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7410), new TimeSpan(0, 7, 0, 0, 0)), 0, 456 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 513, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7419), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@456", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7420), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 514, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7429), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+457", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7430), new TimeSpan(0, 7, 0, 0, 0)), 0, 457 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 515, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7439), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@457", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7440), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 516, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7449), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+458", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7450), new TimeSpan(0, 7, 0, 0, 0)), 0, 458 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 517, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7459), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@458", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7460), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 518, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7469), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+459", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7470), new TimeSpan(0, 7, 0, 0, 0)), 0, 459 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 519, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7479), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@459", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7480), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 520, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7489), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+460", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7490), new TimeSpan(0, 7, 0, 0, 0)), 0, 460 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 521, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7499), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@460", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7500), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 522, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7509), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+461", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7510), new TimeSpan(0, 7, 0, 0, 0)), 0, 461 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 523, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7519), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@461", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7520), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 524, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7564), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+462", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7565), new TimeSpan(0, 7, 0, 0, 0)), 0, 462 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 525, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7577), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@462", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7577), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 526, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7587), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+463", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7587), new TimeSpan(0, 7, 0, 0, 0)), 0, 463 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 527, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7597), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@463", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7598), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 528, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7607), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+464", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7607), new TimeSpan(0, 7, 0, 0, 0)), 0, 464 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 529, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7616), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@464", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7617), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 530, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7626), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+465", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7627), new TimeSpan(0, 7, 0, 0, 0)), 0, 465 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 531, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7636), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@465", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7637), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 532, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7646), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+466", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7647), new TimeSpan(0, 7, 0, 0, 0)), 0, 466 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 533, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7656), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@466", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7657), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 534, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7666), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+467", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7667), new TimeSpan(0, 7, 0, 0, 0)), 0, 467 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 535, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@467", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7676), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 536, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7686), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+468", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7686), new TimeSpan(0, 7, 0, 0, 0)), 0, 468 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 537, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7695), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@468", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7696), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 538, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7705), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+469", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7706), new TimeSpan(0, 7, 0, 0, 0)), 0, 469 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 539, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7715), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@469", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7716), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 540, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7725), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+470", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7726), new TimeSpan(0, 7, 0, 0, 0)), 0, 470 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 541, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7735), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@470", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7735), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 542, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7744), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+471", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7745), new TimeSpan(0, 7, 0, 0, 0)), 0, 471 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 543, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7754), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@471", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7755), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 544, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7764), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+472", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7765), new TimeSpan(0, 7, 0, 0, 0)), 0, 472 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 545, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7773), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@472", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7774), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 546, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7784), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+473", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7784), new TimeSpan(0, 7, 0, 0, 0)), 0, 473 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 547, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7831), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@473", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7832), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 548, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7841), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+474", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7842), new TimeSpan(0, 7, 0, 0, 0)), 0, 474 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 549, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7851), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@474", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7852), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 550, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7861), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+475", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7862), new TimeSpan(0, 7, 0, 0, 0)), 0, 475 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 551, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@475", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7872), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 552, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7881), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+476", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7881), new TimeSpan(0, 7, 0, 0, 0)), 0, 476 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 553, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7891), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@476", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7891), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 554, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7900), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+477", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7901), new TimeSpan(0, 7, 0, 0, 0)), 0, 477 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 555, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7910), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@477", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7911), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 556, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7920), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+478", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7920), new TimeSpan(0, 7, 0, 0, 0)), 0, 478 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 557, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7929), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@478", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7930), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 558, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7939), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+479", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7940), new TimeSpan(0, 7, 0, 0, 0)), 0, 479 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 559, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7949), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@479", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7950), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 560, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+480", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7960), new TimeSpan(0, 7, 0, 0, 0)), 0, 480 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 561, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7969), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@480", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7970), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 562, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7979), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+481", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7979), new TimeSpan(0, 7, 0, 0, 0)), 0, 481 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 563, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7988), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@481", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7989), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 564, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7998), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+482", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(7999), new TimeSpan(0, 7, 0, 0, 0)), 0, 482 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 565, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8008), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@482", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8009), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 566, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8018), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+483", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8018), new TimeSpan(0, 7, 0, 0, 0)), 0, 483 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 567, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8028), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@483", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8028), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 568, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8037), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+484", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8038), new TimeSpan(0, 7, 0, 0, 0)), 0, 484 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 569, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8102), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@484", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8103), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 570, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8114), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+485", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8114), new TimeSpan(0, 7, 0, 0, 0)), 0, 485 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 571, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8124), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@485", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8124), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 572, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8133), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+486", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8134), new TimeSpan(0, 7, 0, 0, 0)), 0, 486 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 573, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8143), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@486", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8144), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 574, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8153), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+487", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8154), new TimeSpan(0, 7, 0, 0, 0)), 0, 487 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 575, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8163), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@487", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8164), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 576, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8173), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+488", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8174), new TimeSpan(0, 7, 0, 0, 0)), 0, 488 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 577, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8183), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@488", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8183), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 578, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8193), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+489", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8194), new TimeSpan(0, 7, 0, 0, 0)), 0, 489 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 579, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8203), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@489", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8203), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 580, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8213), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+490", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8213), new TimeSpan(0, 7, 0, 0, 0)), 0, 490 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 581, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8222), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@490", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8223), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 582, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8232), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+491", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8233), new TimeSpan(0, 7, 0, 0, 0)), 0, 491 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 583, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8242), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@491", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8243), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 584, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8252), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+492", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8252), new TimeSpan(0, 7, 0, 0, 0)), 0, 492 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 585, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8261), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@492", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8262), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 586, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8272), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+493", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8272), new TimeSpan(0, 7, 0, 0, 0)), 0, 493 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 587, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8281), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@493", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8282), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 588, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8291), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+494", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8292), new TimeSpan(0, 7, 0, 0, 0)), 0, 494 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 589, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8301), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@494", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8302), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 590, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8311), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+495", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8312), new TimeSpan(0, 7, 0, 0, 0)), 0, 495 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 591, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8357), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@495", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8358), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 592, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8368), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+496", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8369), new TimeSpan(0, 7, 0, 0, 0)), 0, 496 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 593, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8378), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@496", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8379), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 594, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8388), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+497", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8389), new TimeSpan(0, 7, 0, 0, 0)), 0, 497 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 595, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8398), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@497", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8398), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 596, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8408), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+498", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8409), new TimeSpan(0, 7, 0, 0, 0)), 0, 498 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 597, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8418), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@498", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8419), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 598, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8428), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+499", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8428), new TimeSpan(0, 7, 0, 0, 0)), 0, 499 });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 599, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8437), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "@499", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8438), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, true });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "active", "content", "created_at", "created_by", "deleted_at", "file_id", "priority", "title", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9338), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 9, 1, "What is Lorem Ipsum?", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9339), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, true, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9344), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10, 2, "Why do we use it?", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9345), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, true, "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9346), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 11, 3, "Where does it come from?", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9347), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, true, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9348), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12, null, "Where can I get some?", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9349), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "fares",
                columns: new[] { "id", "base_distance", "base_price", "created_at", "created_by", "deleted_at", "price_per_km", "updated_at", "updated_by", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, 2000, 12000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9505), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 4000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9506), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 2000, 20000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9510), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 10000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9510), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 2000, 30000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9512), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 12000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9513), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8688), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1000000f, null, 3, 50, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8689), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 2, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8709), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 20, 500000f, null, 4, 50, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8710), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 9, 2, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8730), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 300000f, null, 5, 500, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8731), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "details", "discount_percentage", "file_id", "max_decrease", "name", "status", "type", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "HELLO2022", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8460), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.", 0.20000000000000001, 9, 200000.0, "New User Promotion", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8460), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, "BDAY2022", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8474), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.", 0.10000000000000001, 10, 150000.0, "Beautiful Month", 1, 0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8475), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, "VICAR2022", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8511), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "Promotion for ViCar: Discount 15% with max decrease 350k for the booking with minimum total price 500k.", 0.14999999999999999, 11, 350000.0, "ViCar Promotion", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8512), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "code", "created_at", "created_by", "date_of_birth", "deleted_at", "file_id", "gender", "name", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new Guid("00fd878c-57f8-47f5-ae18-d742c16980ca"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9004), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 1, 1, "Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9005), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, new Guid("afa58b78-f176-4040-8109-56a01cc24582"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9022), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 2, 1, "Do Trong Dat", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9023), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, new Guid("6cf53959-cc65-4c11-b42f-9058190fab5d"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9037), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 3, 1, "Nguyen Dang Khoa", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9038), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, new Guid("e1be0d93-af7b-4a9b-8e02-7d8f8f995abe"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9052), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 4, 1, "Than Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9052), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, new Guid("6a190547-f0b9-45e2-8419-648934388cd8"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9068), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 5, 1, "Loi Quach", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9069), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, new Guid("25ae04bd-61f0-4bd1-bb01-ca15232935d6"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9084), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 6, 1, "Dat Do", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9084), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, new Guid("0d3f8a29-86b4-44db-be51-20c6456e3c94"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9097), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 7, 1, "Khoa Nguyen", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9098), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, new Guid("ec154d99-4152-4653-99db-9cf45514f5ee"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9111), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 8, 1, "Thanh Duy", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9112), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, new Guid("3ec12107-5de9-45a4-80d4-e7b1ac772de7"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9127), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 13, 1, "Admin Quach Dai Loi", 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 40, DateTimeKind.Unspecified).AddTicks(9128), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 400, new Guid("5e9ff70b-065f-4a63-a5a9-27c101520169"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9734), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.400", "Vehicle 400", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9735), new TimeSpan(0, 7, 0, 0, 0)), 0, 400, 3 },
                    { 401, new Guid("94636621-936a-429a-981f-f86d611c2c55"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9746), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.401", "Vehicle 401", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9747), new TimeSpan(0, 7, 0, 0, 0)), 0, 401, 3 },
                    { 402, new Guid("ede4268d-6756-4d0a-9d9b-23f5f9d9d750"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9751), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.402", "Vehicle 402", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9752), new TimeSpan(0, 7, 0, 0, 0)), 0, 402, 3 },
                    { 403, new Guid("3b86699e-22f9-4ac5-88f0-9172b466f66b"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9756), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.403", "Vehicle 403", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9756), new TimeSpan(0, 7, 0, 0, 0)), 0, 403, 3 },
                    { 404, new Guid("f8ad79c7-75ff-4fd9-bb6f-625e22ed56c7"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9760), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.404", "Vehicle 404", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9761), new TimeSpan(0, 7, 0, 0, 0)), 0, 404, 3 },
                    { 405, new Guid("e804cb12-1f7d-4a26-8883-7e9a13bb0c61"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9765), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.405", "Vehicle 405", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9766), new TimeSpan(0, 7, 0, 0, 0)), 0, 405, 3 },
                    { 406, new Guid("ce9e5c3e-04ef-4d70-b6f7-f29c01d95382"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9770), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.406", "Vehicle 406", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9770), new TimeSpan(0, 7, 0, 0, 0)), 0, 406, 3 },
                    { 407, new Guid("ba92bb03-08c6-4ea1-9ce8-aa0a9ec3e43b"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9774), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.407", "Vehicle 407", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9775), new TimeSpan(0, 7, 0, 0, 0)), 0, 407, 3 },
                    { 408, new Guid("71d06c6e-3ed7-4df2-b6e4-419a73f3d9cb"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9781), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.408", "Vehicle 408", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9782), new TimeSpan(0, 7, 0, 0, 0)), 0, 408, 3 },
                    { 409, new Guid("a71a4e7b-3e86-4252-9b0e-216743ad5a72"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9786), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.409", "Vehicle 409", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9786), new TimeSpan(0, 7, 0, 0, 0)), 0, 409, 3 },
                    { 410, new Guid("2ee52b72-3f48-44c1-baa3-3f4db4f4d9f3"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9790), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.410", "Vehicle 410", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9791), new TimeSpan(0, 7, 0, 0, 0)), 0, 410, 3 },
                    { 411, new Guid("93d4d278-6b2e-48d6-9cad-268d62c88e0c"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9794), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.411", "Vehicle 411", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9795), new TimeSpan(0, 7, 0, 0, 0)), 0, 411, 3 },
                    { 412, new Guid("904bc1a6-2686-4a1e-a77e-d99e7965481f"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9799), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.412", "Vehicle 412", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9799), new TimeSpan(0, 7, 0, 0, 0)), 0, 412, 3 },
                    { 413, new Guid("edf71ba2-016a-426c-9aae-6d709621b4b9"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9804), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.413", "Vehicle 413", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9805), new TimeSpan(0, 7, 0, 0, 0)), 0, 413, 3 },
                    { 414, new Guid("caeb194d-4d53-4de9-ba68-d1526647132d"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9808), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.414", "Vehicle 414", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9809), new TimeSpan(0, 7, 0, 0, 0)), 0, 414, 3 },
                    { 415, new Guid("fcadcd8c-f697-4852-b5a6-41856dc26f36"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9851), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.415", "Vehicle 415", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9852), new TimeSpan(0, 7, 0, 0, 0)), 0, 415, 3 },
                    { 416, new Guid("2882e4e4-8272-4739-a26d-473cf9e12eb3"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9858), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.416", "Vehicle 416", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9859), new TimeSpan(0, 7, 0, 0, 0)), 0, 416, 3 },
                    { 417, new Guid("33aa1a1a-5320-4cbc-9cd2-8a46d0eccca7"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9862), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.417", "Vehicle 417", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9863), new TimeSpan(0, 7, 0, 0, 0)), 0, 417, 3 },
                    { 418, new Guid("e8cf2b64-828d-4f4c-af5c-a9309f6175aa"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9867), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.418", "Vehicle 418", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9867), new TimeSpan(0, 7, 0, 0, 0)), 0, 418, 3 },
                    { 419, new Guid("f25462bb-4af5-48e5-8f82-703056a48905"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9871), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.419", "Vehicle 419", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9872), new TimeSpan(0, 7, 0, 0, 0)), 0, 419, 3 },
                    { 420, new Guid("255bceb6-73fb-4d7c-8634-b3ca8be156ec"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9876), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.420", "Vehicle 420", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9876), new TimeSpan(0, 7, 0, 0, 0)), 0, 420, 3 },
                    { 421, new Guid("96e74663-000d-445d-8061-2110e5cb76fb"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9880), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.421", "Vehicle 421", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9880), new TimeSpan(0, 7, 0, 0, 0)), 0, 421, 3 },
                    { 422, new Guid("d679a7a2-1422-48a6-b7db-465267955a65"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9884), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.422", "Vehicle 422", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9885), new TimeSpan(0, 7, 0, 0, 0)), 0, 422, 3 },
                    { 423, new Guid("d8f04c05-c534-4b85-8651-c53f349ba915"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9888), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.423", "Vehicle 423", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9889), new TimeSpan(0, 7, 0, 0, 0)), 0, 423, 3 },
                    { 424, new Guid("dcc03010-afed-4190-957b-20307badf222"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9895), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.424", "Vehicle 424", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9896), new TimeSpan(0, 7, 0, 0, 0)), 0, 424, 3 },
                    { 425, new Guid("6c2544f7-7074-465c-b8c2-fbd81c520aed"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9899), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.425", "Vehicle 425", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9900), new TimeSpan(0, 7, 0, 0, 0)), 0, 425, 3 },
                    { 426, new Guid("4a939a32-cdfb-4122-8bc1-02c5974b987e"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9904), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.426", "Vehicle 426", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9904), new TimeSpan(0, 7, 0, 0, 0)), 0, 426, 3 },
                    { 427, new Guid("85f5a475-833c-498c-9cef-fb8c9637af30"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9908), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.427", "Vehicle 427", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9909), new TimeSpan(0, 7, 0, 0, 0)), 0, 427, 3 },
                    { 428, new Guid("51cf854c-f929-4f9d-a32f-b1ff811d50a3"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9912), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.428", "Vehicle 428", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9913), new TimeSpan(0, 7, 0, 0, 0)), 0, 428, 3 },
                    { 429, new Guid("74d43732-27d6-4d99-b27f-06f8ac6be582"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9918), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.429", "Vehicle 429", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9918), new TimeSpan(0, 7, 0, 0, 0)), 0, 429, 3 },
                    { 430, new Guid("1d2ab47d-30f1-4bea-bc89-b2b8b240058c"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9922), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.430", "Vehicle 430", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9923), new TimeSpan(0, 7, 0, 0, 0)), 0, 430, 3 },
                    { 431, new Guid("71bd548a-d763-4d67-97a1-dae2dad609c7"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9927), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.431", "Vehicle 431", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9927), new TimeSpan(0, 7, 0, 0, 0)), 0, 431, 3 },
                    { 432, new Guid("38d80a24-cd9e-4a90-99d5-52548ec7250e"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9934), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.432", "Vehicle 432", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9934), new TimeSpan(0, 7, 0, 0, 0)), 0, 432, 3 },
                    { 433, new Guid("1e3cf59b-690d-4b64-a43b-a03382047989"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9938), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.433", "Vehicle 433", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9939), new TimeSpan(0, 7, 0, 0, 0)), 0, 433, 3 },
                    { 434, new Guid("df8fd3ab-e594-4b1a-a718-5bdb3100920f"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9942), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.434", "Vehicle 434", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9943), new TimeSpan(0, 7, 0, 0, 0)), 0, 434, 3 },
                    { 435, new Guid("831362a2-5671-4287-b95b-e0af2c137c7f"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9946), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.435", "Vehicle 435", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9947), new TimeSpan(0, 7, 0, 0, 0)), 0, 435, 3 },
                    { 436, new Guid("fbba133e-c4a3-4a2f-a792-fad68fc9987f"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9951), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.436", "Vehicle 436", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9951), new TimeSpan(0, 7, 0, 0, 0)), 0, 436, 3 },
                    { 437, new Guid("af2a664c-fdc0-44f5-bdf4-a956d41892d6"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9955), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.437", "Vehicle 437", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9956), new TimeSpan(0, 7, 0, 0, 0)), 0, 437, 3 },
                    { 438, new Guid("33b2fad0-6e26-47a7-86a3-e81d0a6397af"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9959), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.438", "Vehicle 438", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9960), new TimeSpan(0, 7, 0, 0, 0)), 0, 438, 3 },
                    { 439, new Guid("50b42872-fb95-4f28-b23d-4b86893b4f74"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9964), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.439", "Vehicle 439", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9964), new TimeSpan(0, 7, 0, 0, 0)), 0, 439, 3 },
                    { 440, new Guid("6c65d36c-45a4-4aab-b205-c8e075308a88"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9970), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.440", "Vehicle 440", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9971), new TimeSpan(0, 7, 0, 0, 0)), 0, 440, 3 },
                    { 441, new Guid("f7d90c9b-2baf-4e8c-98ae-6ab3e21a7476"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9975), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.441", "Vehicle 441", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9975), new TimeSpan(0, 7, 0, 0, 0)), 0, 441, 3 },
                    { 442, new Guid("c86d9b44-8428-4f71-b028-fe083de6c784"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9979), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.442", "Vehicle 442", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9980), new TimeSpan(0, 7, 0, 0, 0)), 0, 442, 3 },
                    { 443, new Guid("c1f45b86-db86-4847-a893-b0ebbab7e4d8"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9983), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.443", "Vehicle 443", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9984), new TimeSpan(0, 7, 0, 0, 0)), 0, 443, 3 },
                    { 444, new Guid("4cfe9a55-4b3d-42f1-ae89-4d79982b420d"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9988), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.444", "Vehicle 444", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9988), new TimeSpan(0, 7, 0, 0, 0)), 0, 444, 3 },
                    { 445, new Guid("7c01b363-3b02-4540-9342-1c78594b9ee7"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9992), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.445", "Vehicle 445", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9992), new TimeSpan(0, 7, 0, 0, 0)), 0, 445, 3 },
                    { 446, new Guid("b36f4189-4d4f-4886-91dc-b2fed609e95f"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9996), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.446", "Vehicle 446", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9997), new TimeSpan(0, 7, 0, 0, 0)), 0, 446, 3 },
                    { 447, new Guid("8dd3797c-cb30-4f03-bcfd-996660c20109"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(36), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.447", "Vehicle 447", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(37), new TimeSpan(0, 7, 0, 0, 0)), 0, 447, 3 },
                    { 448, new Guid("dec35bd4-46f0-4e63-b4ed-3a5c8ec66859"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(43), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.448", "Vehicle 448", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(43), new TimeSpan(0, 7, 0, 0, 0)), 0, 448, 3 },
                    { 449, new Guid("6ea8f960-1bbb-4769-8a74-58c10b3a409f"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(47), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.449", "Vehicle 449", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(48), new TimeSpan(0, 7, 0, 0, 0)), 0, 449, 3 },
                    { 450, new Guid("5e7028f9-9d81-4833-9a13-936549114580"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(51), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.450", "Vehicle 450", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(52), new TimeSpan(0, 7, 0, 0, 0)), 0, 450, 3 },
                    { 451, new Guid("cf6e09bd-ccf1-4eee-8cd3-c743220ed202"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(56), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.451", "Vehicle 451", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(56), new TimeSpan(0, 7, 0, 0, 0)), 0, 451, 3 },
                    { 452, new Guid("efc6a9e9-42c0-4474-9f5e-2ee8c4e18ee0"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(60), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.452", "Vehicle 452", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(61), new TimeSpan(0, 7, 0, 0, 0)), 0, 452, 3 },
                    { 453, new Guid("fe715dff-b6db-4278-83d9-8b570fb37561"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(64), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.453", "Vehicle 453", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(65), new TimeSpan(0, 7, 0, 0, 0)), 0, 453, 3 },
                    { 454, new Guid("655df375-bee5-4c74-b707-3dc9b95af917"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(68), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.454", "Vehicle 454", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(69), new TimeSpan(0, 7, 0, 0, 0)), 0, 454, 3 },
                    { 455, new Guid("752d7101-bc30-4a27-abdb-daf92fad30c4"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(73), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.455", "Vehicle 455", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(73), new TimeSpan(0, 7, 0, 0, 0)), 0, 455, 3 },
                    { 456, new Guid("4342cc1e-efed-4d44-8c25-b0660745f040"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(80), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.456", "Vehicle 456", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(80), new TimeSpan(0, 7, 0, 0, 0)), 0, 456, 3 },
                    { 457, new Guid("08bf3666-5ddc-481e-be27-18281c5639cf"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(84), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.457", "Vehicle 457", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(85), new TimeSpan(0, 7, 0, 0, 0)), 0, 457, 3 },
                    { 458, new Guid("eac4a44a-21e0-46b4-8679-01af59e1a96d"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(88), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.458", "Vehicle 458", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(89), new TimeSpan(0, 7, 0, 0, 0)), 0, 458, 3 },
                    { 459, new Guid("e6f5faf7-2b8e-45b5-9852-765de6e090c6"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(93), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.459", "Vehicle 459", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(93), new TimeSpan(0, 7, 0, 0, 0)), 0, 459, 3 },
                    { 460, new Guid("2c51dce0-2399-422d-aba7-5f383793dd9c"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(97), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.460", "Vehicle 460", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(98), new TimeSpan(0, 7, 0, 0, 0)), 0, 460, 3 },
                    { 461, new Guid("bf6521e5-bbf8-4c03-ac1c-5f2a7a980e9f"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(102), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.461", "Vehicle 461", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(103), new TimeSpan(0, 7, 0, 0, 0)), 0, 461, 3 },
                    { 462, new Guid("ff50cf42-4c8f-42b3-ac80-6d37e475bfc9"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(107), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.462", "Vehicle 462", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(107), new TimeSpan(0, 7, 0, 0, 0)), 0, 462, 3 },
                    { 463, new Guid("4f3cff3a-b8b9-4b5b-b039-7e7205865489"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(111), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.463", "Vehicle 463", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(112), new TimeSpan(0, 7, 0, 0, 0)), 0, 463, 3 },
                    { 464, new Guid("c8819d48-8d03-4557-b817-ff92019c8cf3"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(118), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.464", "Vehicle 464", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(118), new TimeSpan(0, 7, 0, 0, 0)), 0, 464, 3 },
                    { 465, new Guid("54ce702d-cc80-44b3-9c90-09820c762845"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(122), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.465", "Vehicle 465", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(123), new TimeSpan(0, 7, 0, 0, 0)), 0, 465, 3 },
                    { 466, new Guid("8a471a28-3e5d-4d92-8d0f-5976e8e1c2fd"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(126), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.466", "Vehicle 466", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(127), new TimeSpan(0, 7, 0, 0, 0)), 0, 466, 3 },
                    { 467, new Guid("21025098-cfe4-4755-a506-2a0f8dc05597"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(131), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.467", "Vehicle 467", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(131), new TimeSpan(0, 7, 0, 0, 0)), 0, 467, 3 },
                    { 468, new Guid("b81a7f19-e910-4bc4-b371-ef96f34aed7b"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(135), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.468", "Vehicle 468", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(136), new TimeSpan(0, 7, 0, 0, 0)), 0, 468, 3 },
                    { 469, new Guid("26360421-69ec-448b-b109-4a123abb54ee"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(139), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.469", "Vehicle 469", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(140), new TimeSpan(0, 7, 0, 0, 0)), 0, 469, 3 },
                    { 470, new Guid("276db587-17bd-41bf-94e7-a1842035781c"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(144), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.470", "Vehicle 470", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(144), new TimeSpan(0, 7, 0, 0, 0)), 0, 470, 3 },
                    { 471, new Guid("627e921c-3dee-4b80-88b5-d758ef2e0c43"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(148), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.471", "Vehicle 471", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(149), new TimeSpan(0, 7, 0, 0, 0)), 0, 471, 3 },
                    { 472, new Guid("bfc5c9e3-0bf8-48bd-95d3-fbbf22052efb"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(155), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.472", "Vehicle 472", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(156), new TimeSpan(0, 7, 0, 0, 0)), 0, 472, 3 },
                    { 473, new Guid("5ddce9e9-64fa-4ceb-ba07-7dfa6be90322"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(159), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.473", "Vehicle 473", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(160), new TimeSpan(0, 7, 0, 0, 0)), 0, 473, 3 },
                    { 474, new Guid("bf937c2c-48fc-4926-8254-5636a1db45ef"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(163), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.474", "Vehicle 474", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(164), new TimeSpan(0, 7, 0, 0, 0)), 0, 474, 3 },
                    { 475, new Guid("082fc9ec-a33a-4bd5-9246-8ef475947827"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(168), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.475", "Vehicle 475", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(168), new TimeSpan(0, 7, 0, 0, 0)), 0, 475, 3 },
                    { 476, new Guid("466e3288-f65b-4d72-b6d7-f5d98943b39e"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(226), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.476", "Vehicle 476", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(227), new TimeSpan(0, 7, 0, 0, 0)), 0, 476, 3 },
                    { 477, new Guid("01312a2c-7cab-4bbf-89f7-27a2e684ec15"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(231), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.477", "Vehicle 477", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(232), new TimeSpan(0, 7, 0, 0, 0)), 0, 477, 3 },
                    { 478, new Guid("9d78064f-97eb-4b45-94d1-38edfa3f8f32"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(236), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.478", "Vehicle 478", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(236), new TimeSpan(0, 7, 0, 0, 0)), 0, 478, 3 },
                    { 479, new Guid("6256f841-a1d7-44d8-b324-a92d5a0e3e54"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(240), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.479", "Vehicle 479", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(240), new TimeSpan(0, 7, 0, 0, 0)), 0, 479, 3 },
                    { 480, new Guid("570471ae-4c66-4c4b-a85a-859b7c8f79c0"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(247), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.480", "Vehicle 480", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(248), new TimeSpan(0, 7, 0, 0, 0)), 0, 480, 3 },
                    { 481, new Guid("39b09ea1-2756-49e7-bcfe-7666cbf2967f"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(251), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.481", "Vehicle 481", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(252), new TimeSpan(0, 7, 0, 0, 0)), 0, 481, 3 },
                    { 482, new Guid("eef73dea-0dcb-42ea-93e5-343852fd1f68"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.482", "Vehicle 482", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(256), new TimeSpan(0, 7, 0, 0, 0)), 0, 482, 3 },
                    { 483, new Guid("3b8a4157-cd6d-419b-aead-fb064722e5be"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(260), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.483", "Vehicle 483", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(261), new TimeSpan(0, 7, 0, 0, 0)), 0, 483, 3 },
                    { 484, new Guid("56afa9fe-968a-44ad-94c2-8f90d7bb85a6"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(264), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.484", "Vehicle 484", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(265), new TimeSpan(0, 7, 0, 0, 0)), 0, 484, 3 },
                    { 485, new Guid("cdd268cf-1b11-403a-8d97-cae9e3ca65e2"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(269), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.485", "Vehicle 485", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(269), new TimeSpan(0, 7, 0, 0, 0)), 0, 485, 3 },
                    { 486, new Guid("3e282044-3404-4f9d-92a0-90a2930924e3"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(273), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.486", "Vehicle 486", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(274), new TimeSpan(0, 7, 0, 0, 0)), 0, 486, 3 },
                    { 487, new Guid("78c98f0b-aa60-4232-9c43-d8c21be41b5a"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(277), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.487", "Vehicle 487", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(278), new TimeSpan(0, 7, 0, 0, 0)), 0, 487, 3 },
                    { 488, new Guid("f4878577-c1de-4240-af84-0f86308a70fc"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(284), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.488", "Vehicle 488", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(284), new TimeSpan(0, 7, 0, 0, 0)), 0, 488, 3 },
                    { 489, new Guid("468bea8c-f5b8-497e-a922-d14295edb51f"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(288), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.489", "Vehicle 489", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(289), new TimeSpan(0, 7, 0, 0, 0)), 0, 489, 3 },
                    { 490, new Guid("763e75f8-b7aa-479d-a76c-f86e3c025045"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(293), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.490", "Vehicle 490", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(293), new TimeSpan(0, 7, 0, 0, 0)), 0, 490, 3 },
                    { 491, new Guid("72a2d0c8-b280-4e63-a1a7-f014642bf415"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(297), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.491", "Vehicle 491", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(298), new TimeSpan(0, 7, 0, 0, 0)), 0, 491, 3 },
                    { 492, new Guid("2d574e03-7157-4cae-b945-e57dce53f1d2"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(301), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.492", "Vehicle 492", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(302), new TimeSpan(0, 7, 0, 0, 0)), 0, 492, 3 },
                    { 493, new Guid("7f8c9a52-48d3-46e1-8e26-5f32d083c0ea"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(305), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.493", "Vehicle 493", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(306), new TimeSpan(0, 7, 0, 0, 0)), 0, 493, 3 },
                    { 494, new Guid("969bbae1-d4fe-45d6-8fb7-d41e8f6420fd"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(310), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.494", "Vehicle 494", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(311), new TimeSpan(0, 7, 0, 0, 0)), 0, 494, 3 },
                    { 495, new Guid("cca283e2-58e3-4536-9a0d-eec3ea3d06c3"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(314), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.495", "Vehicle 495", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(315), new TimeSpan(0, 7, 0, 0, 0)), 0, 495, 3 },
                    { 496, new Guid("560bb758-9b19-4375-8b22-96f7700f353b"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(321), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.496", "Vehicle 496", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(322), new TimeSpan(0, 7, 0, 0, 0)), 0, 496, 3 },
                    { 497, new Guid("c7e5ab10-f52f-432d-9bcd-6f8016d2ca05"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(325), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.497", "Vehicle 497", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(326), new TimeSpan(0, 7, 0, 0, 0)), 0, 497, 3 },
                    { 498, new Guid("fafd70fd-760f-4618-9e22-bb7e47c6518e"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(330), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.498", "Vehicle 498", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(330), new TimeSpan(0, 7, 0, 0, 0)), 0, 498, 3 },
                    { 499, new Guid("90bc1e8e-c4f0-4369-8029-24367f30461f"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(334), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.499", "Vehicle 499", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(335), new TimeSpan(0, 7, 0, 0, 0)), 0, 499, 3 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3256), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3257), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, true });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3269), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3270), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3279), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3279), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 4, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3288), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84837226239", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3288), new TimeSpan(0, 7, 0, 0, 0)), 0, 5, true },
                    { 5, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3297), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3297), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3307), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3308), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 7, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3318), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "datdtse140920@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3319), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3327), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84377322919", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3328), new TimeSpan(0, 7, 0, 0, 0)), 0, 6, true },
                    { 9, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3336), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse1409770@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3336), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 10, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3346), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3347), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 11, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3355), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "khoandse140977@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3355), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 12, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3363), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84914669962", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3364), new TimeSpan(0, 7, 0, 0, 0)), 0, 7, true },
                    { 13, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3372), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3373), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 14, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3380), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3381), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 15, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3427), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "duyttse140971@fpt.edu.vn", 0, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3428), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "registration", "registration_type", "role_id", "updated_at", "updated_by", "user_id", "verified" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3438), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3439), new TimeSpan(0, 7, 0, 0, 0)), 0, 8, true },
                    { 17, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3447), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "+84376826328", 1, 3, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3448), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true },
                    { 18, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3459), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "loiqdse140970@fpt.edu.vn", 0, 3, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(3460), new TimeSpan(0, 7, 0, 0, 0)), 0, 9, true }
                });

            migrationBuilder.InsertData(
                table: "fare_timelines",
                columns: new[] { "id", "ceiling_extra_price", "created_at", "created_by", "deleted_at", "end_time", "extra_fee_per_km", "fare_id", "start_time", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9540), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 1, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9540), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 2, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9590), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 1, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9591), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 3, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9599), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 2000.0, 1, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9600), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 4, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9607), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 1500.0, 1, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9608), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 5, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9616), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 2, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9616), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 6, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9626), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 2, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9626), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 7, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9634), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 2, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9635), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 8, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9642), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2000.0, 2, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9643), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 9, 7000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9651), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(8, 0, 0), 2000.0, 3, new TimeOnly(6, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9651), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 10, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9660), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(10, 0, 0), 1000.0, 3, new TimeOnly(8, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9661), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 11, 6000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9668), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(17, 0, 0), 1500.0, 3, new TimeOnly(15, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9669), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 12, 10000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9676), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(19, 0, 0), 2500.0, 3, new TimeOnly(17, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9677), new TimeSpan(0, 7, 0, 0, 0)), 0 },
                    { 13, 5000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9684), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new TimeOnly(15, 0, 0), 1000.0, 3, new TimeOnly(14, 0, 0), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9684), new TimeSpan(0, 7, 0, 0, 0)), 0 }
                });

            migrationBuilder.InsertData(
                table: "promotion_conditions",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "min_tickets", "min_total_price", "payment_methods", "promotion_id", "total_usage", "updated_at", "updated_by", "usage_per_user", "valid_from", "valid_until", "vehicle_types" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8533), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 1, null, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8534), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8662), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 200000f, null, 2, 50, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8663), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8818), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, 500000f, null, 6, 500, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8818), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8852), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8853), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8875), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 10, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8875), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 6 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "user_id" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8891), new TimeSpan(0, 7, 0, 0, 0)), 0, null, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8891), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 });

            migrationBuilder.InsertData(
                table: "promotion_users",
                columns: new[] { "id", "created_at", "created_by", "deleted_at", "expired_time", "PromotionConditionId", "promotion_id", "updated_at", "updated_by", "used", "user_id" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8905), new TimeSpan(0, 7, 0, 0, 0)), 0, null, null, null, 2, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(8906), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 6 });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "code", "created_at", "created_by", "deleted_at", "license_plate", "name", "updated_at", "updated_by", "user_id", "vehicle_type_id" },
                values: new object[,]
                {
                    { 1, new Guid("e69106fc-de3c-4838-a324-ce6ced293854"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9717), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.01", "Wave Alpha", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9718), new TimeSpan(0, 7, 0, 0, 0)), 0, 2, 1 },
                    { 2, new Guid("7a319dc1-3902-47d6-ac3d-a3ff6b8cfff8"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9723), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.02", "BMW I8", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9723), new TimeSpan(0, 7, 0, 0, 0)), 0, 1, 2 },
                    { 3, new Guid("b4395c3f-e8da-4eb6-9fcd-1182c7412c6f"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9725), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.03", "Mazda CX-8", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9726), new TimeSpan(0, 7, 0, 0, 0)), 0, 3, 3 },
                    { 4, new Guid("fa467dff-bd72-4d69-a828-cd13f95e31a9"), new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9728), new TimeSpan(0, 7, 0, 0, 0)), 0, null, "51B.000.04", "Honda CR-V", new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 41, DateTimeKind.Unspecified).AddTicks(9729), new TimeSpan(0, 7, 0, 0, 0)), 0, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "balance", "created_at", "created_by", "deleted_at", "status", "updated_at", "updated_by", "user_id" },
                values: new object[,]
                {
                    { 1, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(472), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(473), new TimeSpan(0, 7, 0, 0, 0)), 0, 1 },
                    { 2, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(477), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(478), new TimeSpan(0, 7, 0, 0, 0)), 0, 2 },
                    { 3, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(479), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(480), new TimeSpan(0, 7, 0, 0, 0)), 0, 3 },
                    { 4, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(481), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(482), new TimeSpan(0, 7, 0, 0, 0)), 0, 4 },
                    { 5, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(483), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(484), new TimeSpan(0, 7, 0, 0, 0)), 0, 5 },
                    { 6, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(487), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(488), new TimeSpan(0, 7, 0, 0, 0)), 0, 6 },
                    { 7, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(489), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(490), new TimeSpan(0, 7, 0, 0, 0)), 0, 7 },
                    { 8, 500000.0, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(491), new TimeSpan(0, 7, 0, 0, 0)), 0, null, 1, new DateTimeOffset(new DateTime(2022, 11, 1, 23, 4, 15, 42, DateTimeKind.Unspecified).AddTicks(492), new TimeSpan(0, 7, 0, 0, 0)), 0, 8 }
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
                column: "booking_id",
                unique: true);

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
